using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.SplineFlower.Content;
using System.Windows.Forms;

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
            MySplineWalker.SetInput(Microsoft.Xna.Framework.Input.Keys.W, Microsoft.Xna.Framework.Input.Keys.S, SplineWalker.SplineWalkerTriggerMode.TriggerByTrigger);
            //MySplineWalker.SetInput(Buttons.DPadUp, Buttons.DPadDown, SplineWalker.SplineWalkerTriggerMode.TriggerByTrigger);

            MoveSplineToScreenCenter();

            SetMultiSampleCount(8);

            AlwaysEnableKeyboardInput = true;
        }

        public void SplineControl_RecalculateBezierCenter()
        {
            if (MySpline != null) MySpline.CalculateBezierCenter(MySpline.GetAllPoints());
        }

        public void MoveSplineToScreenCenter()
        {
            if (MySpline != null) TranslateAllPointsToScreenCenter(MySpline.GetBezierCenter);
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
