﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.SplineFlower.Spline;
using Color = Microsoft.Xna.Framework.Color;
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace MonoGame.SplineFlower.Samples.Controls
{
    public class AdvancedControl : TransformControl
    {
        public CarAdvanced MySplineWalker;

        protected override void Initialize()
        {
            Setup.Initialize(Editor.GraphicsDevice);
        }

        public override void InitializeSplineControlSample()
        {
            Setup.ShowCurves = true;
            Setup.ShowDirectionVectors = false;
            Setup.ShowLines = false;
            Setup.ShowPoints = true;

            MySpline = Editor.Content.Load<SplineBase>("SplineTrack");
            //UpdateTriggerRotation() should be called after loading a spline with visual triggers to make sure they are rotated correctly on the spline
            MySpline.UpdateTriggerRotation();

            MySplineWalker = new CarAdvanced();
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
                if (MySpline.SelectTransform(new Vector2(e.X, e.Y)) != null && !MySpline.SelectedTransform.IsCenter)
                {
                    SplineBase.ControlPointMode nextMode = MySpline.GetControlPointMode(MySpline.SelectedTransform.Index).Next();
                    MySpline.SetControlPointMode(MySpline.SelectedTransform.Index, nextMode);
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (MySpline.SelectedTransform != null) MySpline.EnforceMode(MySpline.SelectedTransform.Index);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (MySplineWalker != null && MySplineWalker.Initialized) MySplineWalker.Update(gameTime);
        }

        protected override void Draw()
        {
            if (Editor != null)
            {
                Editor.BeginAntialising();

                Editor.spriteBatch.Begin();

                if (MySpline != null) MySpline.Draw(Editor.spriteBatch);
                if (MySplineWalker != null && MySplineWalker.Initialized) MySplineWalker.Draw(Editor.spriteBatch);
                
                Editor.spriteBatch.DrawString(Editor.Font, "Walker: " + MySplineWalker.GetProgress.ToString(), new Vector2(10, 70), Color.White);
                Editor.spriteBatch.DrawString(Editor.Font, "TriggerIndex: " + MySplineWalker._CurrentTriggerIndex.ToString(), new Vector2(10, 100), Color.White);

                Editor.spriteBatch.End();

                Editor.EndAntialising();
            }
        }
    }
}
