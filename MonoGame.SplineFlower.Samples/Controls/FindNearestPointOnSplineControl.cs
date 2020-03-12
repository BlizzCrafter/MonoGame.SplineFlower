using System.Windows.Forms;
using Microsoft.Xna.Framework;
using MonoGame.SplineFlower.Content;

namespace MonoGame.SplineFlower.Samples.Controls
{
    public class FindNearestPointControl : TransformControl
    {
        public BezierSpline MySpline;

        private Vector2 _NearestPoint = Vector2.Zero;
        private float _NearestPointSplinePosition = 0f;
        public float NearestPointAccuracy { get; set; } = Setup.SplineMarkerResolution;

        protected override void Initialize()
        {
            base.Initialize();
            Setup.Initialize(GraphicsDevice);

            MySpline = new BezierSpline();
            MySpline.Reset();
            GetSpline = MySpline;

            MoveSplineToScreenCenter();

            TestTransform = new Transform(new Vector2(200, 350));

            SetMultiSampleCount(8);

            Editor.SetDisplayStyle = Forms.Services.GFXService.DisplayStyle.TopRight;
            Editor.ShowCursorPosition = false;
            Editor.ShowFPS = false;
        }

        public void ReorderTriggerList()
        {
            if (MySpline != null) MySpline.ReorderTriggerList();
        }

        public void SplineControl_RecalculateBezierCenter()
        {
            if (MySpline != null) MySpline.CalculateSplineCenter(MySpline.GetAllPoints());
        }

        public void MoveSplineToScreenCenter()
        {
            if (MySpline != null) TranslateAllPointsToScreenCenter(MySpline.CenterSpline.Position);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (SelectedTransform != null) MySpline.EnforceMode(SelectedTransform.Index);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (MySpline != null)
            {
                _NearestPoint = MySpline.FindNearestPoint(TestTransform.Position, out _NearestPointSplinePosition, NearestPointAccuracy);
            }
        }

        protected override void Draw()
        {
            base.Draw();

            if (Editor != null)
            {
                Editor.BeginAntialising();

                Editor.spriteBatch.Begin();

                if (MySpline != null) MySpline.DrawSpline(Editor.spriteBatch);

                Editor.spriteBatch.DrawCircle(_NearestPoint, Color.LightGreen);
                Editor.spriteBatch.DrawPoint(TestTransform.Position, Color.LightGreen);

                Editor.spriteBatch.DrawString(Editor.Font, _NearestPointSplinePosition.ToString(), _NearestPoint + new Vector2(10, 0), Color.White);

                Editor.spriteBatch.End();

                Editor.EndAntialising();
                Editor.DrawDisplay();
            }
        }
    }
}
