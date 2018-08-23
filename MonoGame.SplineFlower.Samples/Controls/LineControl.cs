using MonoGame.SplineFlower.Content;

namespace MonoGame.SplineFlower.Samples.Controls
{
    public class LineControl : TransformControl
    {
        public Line MyLine { get; set; }

        protected override void Initialize()
        {
            base.Initialize();
            Setup.Initialize(Editor.graphics);

            MyLine = new Line();
            TryGetTransformFromPosition = MyLine.TryGetTransformFromPosition;
            GetAllPoints = MyLine.GetAllPoints;
            RecalculateBezierCenter += LineControl_RecalculateBezierCenter;
            MyLine.Reset();

            MoveSplineToScreenCenter();

            SetMultiSampleCount(8);
        }

        public void LineControl_RecalculateBezierCenter()
        {
            if (MyLine != null) MyLine.CalculateBezierCenter(MyLine.GetAllPoints());
        }

        public void MoveSplineToScreenCenter()
        {
            if (MyLine != null) TranslateAllPointsToScreenCenter(MyLine.GetBezierCenter);
        }

        protected override void Draw()
        {
            base.Draw();

            Editor.BeginAntialising();

            Editor.spriteBatch.Begin();

            if (MyLine != null) MyLine.DrawLine(Editor.spriteBatch);

            Editor.spriteBatch.End();

            Editor.EndAntialising();
        }
    }
}
