namespace SplineSharp.Samples.Controls
{
    public class LineControl : TransformControl
    {
        public Line MyLine { get; set; }
        private bool FirstPointSet = false;
        private bool SecondPointSet = false;

        protected override void Initialize()
        {
            base.Initialize();
            Setup.Initialize(Editor.graphics);

            MyLine = new Line();
            TryGetTransformFromPosition = MyLine.TryGetTransformFromPosition;
            GetAllPoints = MyLine.GetAllPoints;
            MyLine.Reset();
        }

        protected override void Draw()
        {
            base.Draw();

            Editor.spriteBatch.Begin();

            if (MyLine != null) MyLine.DrawLine(Editor.spriteBatch);

            Editor.spriteBatch.End();
        }
    }
}
