using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.SplineFlower.Content;
using MonoGame.SplineFlower.Spline;
using System.Collections.Generic;
using System.Windows.Forms;

using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace MonoGame.SplineFlower.Samples.Controls
{
    public class AdvancedControl : TransformControl
    {
        public SplineBase MySpline;
        public Tank MySplineWalker;

        protected override void Initialize()
        {
            base.Initialize();
            Setup.Initialize(Editor.graphics);
            Setup.ShowCurves = true;
            Setup.ShowDirectionVectors = false;
            Setup.ShowLines = false;
            Setup.ShowPoints = true;

            MySpline = Editor.Content.Load<SplineBase>("SplineTrack");
            //UpdateTriggerRotation() should be called after loading a spline with visual triggers to make sure they are rotated correctly on the spline
            MySpline.UpdateTriggerRotation(); 
            GetSpline = MySpline;

            MySplineWalker = new Tank();
            MySplineWalker.CreateSplineWalker(
                MySpline, 
                SplineWalker.SplineWalkerMode.Loop, 
                9,
                triggerDirection: SplineWalker.SplineWalkerTriggerDirection.ForwardAndBackward);
            MySplineWalker.LoadContent(Editor.Content);
            MySplineWalker.TurnWhenWalkingBackwards = true;

            MySplineWalker.SetInput(
                new List<Keys>() { Keys.W, Keys.D, Keys.Up, Keys.Right },
                new List<Keys>() { Keys.S, Keys.A, Keys.Down, Keys.Left },
                SplineWalker.SplineWalkerTriggerMode.Dynamic);

            MySplineWalker.SetInput(
                new List<Buttons> { Buttons.DPadUp, Buttons.DPadRight, Buttons.RightTrigger, Buttons.LeftThumbstickUp, Buttons.LeftThumbstickRight },
                new List<Buttons> { Buttons.DPadDown, Buttons.DPadLeft, Buttons.LeftTrigger, Buttons.LeftThumbstickDown, Buttons.LeftThumbstickLeft },
                SplineWalker.SplineWalkerTriggerMode.Dynamic);

            CenterSpline();

            SetMultiSampleCount(8);

            AlwaysEnableKeyboardInput = true;
        }

        public void SplineControl_RecalculateSplineCenter()
        {
            if (MySpline != null) MySpline.CalculateSplineCenter(MySpline.GetAllPoints);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Right)
            {
                if (GetSpline.SelectTransform(new Vector2(e.X, e.Y)) != null && !GetSpline.SelectedTransform.IsCenter)
                {
                    SplineBase.ControlPointMode nextMode = MySpline.GetControlPointMode(GetSpline.SelectedTransform.Index).Next();
                    MySpline.SetControlPointMode(GetSpline.SelectedTransform.Index, nextMode);
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (GetSpline.SelectedTransform != null) MySpline.EnforceMode(GetSpline.SelectedTransform.Index);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (MySplineWalker != null && MySplineWalker.Initialized) MySplineWalker.Update(gameTime);
        }

        protected override void Draw()
        {
            base.Draw();

            if (Editor != null)
            {
                Editor.BeginAntialising();

                Editor.spriteBatch.Begin();

                if (MySpline != null) MySpline.DrawSpline(Editor.spriteBatch);
                if (MySplineWalker != null && MySplineWalker.Initialized) MySplineWalker.Draw(Editor.spriteBatch);
                
                Editor.spriteBatch.DrawString(Editor.Font, "Walker: " + MySplineWalker.GetProgress.ToString(), new Vector2(10, 30), Color.White);
                Editor.spriteBatch.DrawString(Editor.Font, "TriggerIndex: " + MySplineWalker._CurrentTriggerIndex.ToString(), new Vector2(10, 60), Color.White);

                Editor.spriteBatch.End();

                Editor.EndAntialising();
            }
        }
    }
}
