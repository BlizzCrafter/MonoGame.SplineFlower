using Microsoft.Xna.Framework;
using MonoGame.SplineFlower.Spline.Types;
using Color = Microsoft.Xna.Framework.Color;

namespace MonoGame.SplineFlower.Samples.Controls
{
    public class FindNearestPointControl : TransformControl
    {
        private Vector2 _NearestPoint = Vector2.Zero;
        private float _NearestPointSplinePosition = 0f;

        protected override void Initialize()
        {
            Setup.Initialize(Editor.GraphicsDevice);
        }

        public override void InitializeSplineControlSample()
        {
            Setup.ShowCurves = true;
            Setup.ShowDirectionVectors = true;
            Setup.ShowLines = true;
            Setup.ShowPoints = true;

            MySpline = new BezierSpline();

            CenterSpline();

            TestTransform = new Transform(new Vector2(200, 350));

            SetMultiSampleCount(8);

            Editor.FPSCounter.SetDisplayStyle = Forms.NET.Components.FPSCounter.DisplayStyle.TopRight;
            Editor.FPSCounter.ShowCursorPosition = false;
            Editor.FPSCounter.ShowFPS = false;
        }

        public void CreateCatMulRomSpline()
        {
            MySpline = new CatMulRomSpline();
            CenterSpline();
        }

        public void CreateBezierSpline()
        {
            MySpline = new BezierSpline();
            CenterSpline();
        }

        public void ReorderTriggerList()
        {
            if (MySpline != null) MySpline.ReorderTriggerList();
        }

        public void SplineControl_RecalculateSplineCenter()
        {
            if (MySpline != null) MySpline.CalculateSplineCenter(MySpline.GetAllPoints);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (MySpline.SelectedTransform != null) MySpline.EnforceMode(MySpline.SelectedTransform.Index);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (MySpline != null)
            {
                _NearestPoint = MySpline.FindNearestPoint(TestTransform.Position, out _NearestPointSplinePosition, Setup.SplineMarkerResolution);
            }
        }

        protected override void Draw()
        {
            if (Editor != null)
            {
                Editor.BeginAntialising();

                Editor.spriteBatch.Begin();

                if (MySpline != null) MySpline.Draw(Editor.spriteBatch);

                Editor.spriteBatch.DrawCircle(_NearestPoint, Color.LightGreen);
                Editor.spriteBatch.DrawPoint(TestTransform.Position, Color.LightGreen);

                Editor.spriteBatch.DrawString(Editor.Font, _NearestPointSplinePosition.ToString(), _NearestPoint + new Vector2(10, 0), Color.White);

                Editor.spriteBatch.End();

                Editor.EndAntialising();
            }
        }
    }
}
