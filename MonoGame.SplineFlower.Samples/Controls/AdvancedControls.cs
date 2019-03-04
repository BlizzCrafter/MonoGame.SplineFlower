using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.SplineFlower.Content;
using System.Collections.Generic;
using System.Windows.Forms;

using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace MonoGame.SplineFlower.Samples.Controls
{
    public class AdvancedControls : TransformControl
    {
        public BezierSpline MySpline;
        public Tank MySplineWalker;

        protected override void Initialize()
        {
            base.Initialize();
            Setup.Initialize(Editor.graphics);

            MySpline = new BezierSpline();
            MySpline = Editor.Content.Load<BezierSpline>(@"TankTrack");
            TryGetTransformFromPosition = MySpline.TryGetTransformFromPosition;
            TryGetTriggerFromPosition = MySpline.TryGetTriggerFromPosition;
            GetAllPoints = MySpline.GetAllPoints;
            GetAllTrigger = MySpline.GetAllTrigger;
            RecalculateBezierCenter += SplineControl_RecalculateBezierCenter;
            MovePointDiff += SplineEditor_MovePointDiff;

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

            MoveSplineToScreenCenter();

            SetMultiSampleCount(8);

            AlwaysEnableKeyboardInput = true;
        }

        public void SplineControl_RecalculateBezierCenter()
        {
            if (MySpline != null) MySpline.CalculateSplineCenter(MySpline.GetAllPoints());
        }

        public void MoveSplineToScreenCenter()
        {
            if (MySpline != null) TranslateAllPointsToScreenCenter(MySpline.GetSplineCenter.Position);
        }

        private void SplineEditor_MovePointDiff(Vector2 obj)
        {
            MySpline.MoveAxis(SelectedTransform.Index, obj);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Right)
            {
                SelectedTransform = TryGetTransformFromPosition(new Vector2(e.X, e.Y));
                if (SelectedTransform != null)
                {
                    BezierSpline.BezierControlPointMode nextMode = MySpline.GetControlPointMode(SelectedTransform.Index).Next();
                    MySpline.SetControlPointMode(SelectedTransform.Index, nextMode);
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (SelectedTransform != null) MySpline.EnforceMode(SelectedTransform.Index);
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
