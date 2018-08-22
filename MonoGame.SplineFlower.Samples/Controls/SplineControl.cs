using System.Windows.Forms;
using Microsoft.Xna.Framework;

namespace MonoGame.SplineFlower.Samples.Controls
{
    public class SplineControl : TransformControl
    {
        public BezierSpline MySpline;
        public Car MySplineWalker;
        public Marker MySplineMarker;

        protected override void Initialize()
        {
            base.Initialize();
            Setup.Initialize(Editor.graphics);

            MySpline = new BezierSpline();
            MySpline.Reset();
            TryGetTransformFromPosition = MySpline.TryGetTransformFromPosition;
            TryGetTriggerFromPosition = MySpline.TryGetTriggerFromPosition;
            GetAllPoints = MySpline.GetAllPoints;
            RecalculateBezierCenter += SplineControl_RecalculateBezierCenter; ;
            MovePointDiff += SplineEditor_MovePointDiff;

            MySplineWalker = new Car();
            MySplineWalker.CreateSplineWalker(MySpline, SplineWalker.SplineWalkerMode.Once, 7);
            MySplineWalker.LoadContent(Editor.Content, Editor.Font);

            MySplineMarker = new Marker();
            MySplineMarker.CreateSplineWalker(MySpline, SplineWalker.SplineWalkerMode.Once, 0, false, false);
            MySplineMarker.LoadContent(Editor.Content);

            MoveSplineToScreenCenter();

            SetMultiSampleCount(8);
        }

        public void ReorderTriggerList()
        {
            if (MySpline != null) MySpline.ReorderTriggerList();
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
            if (MySplineMarker != null && MySplineMarker.Initialized) MySplineMarker.Update(gameTime);
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
                if (MySplineMarker != null && MySplineMarker.Initialized) MySplineMarker.Draw(Editor.spriteBatch);

                Editor.spriteBatch.DrawString(Editor.Font, "Marker: " + MySplineMarker._Progress.ToString(), new Vector2(10, 10), Color.White);
                Editor.spriteBatch.DrawString(Editor.Font, "Walker: " + MySplineWalker._Progress.ToString(), new Vector2(10, 30), Color.White);

                Editor.spriteBatch.End();

                Editor.EndAntialising();
            }
        }
    }
}
