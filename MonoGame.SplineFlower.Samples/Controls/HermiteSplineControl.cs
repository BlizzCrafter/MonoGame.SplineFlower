using Microsoft.Xna.Framework;
using MonoGame.SplineFlower.Content;
using MonoGame.SplineFlower.Spline.Types;
using System.Windows.Forms;
using static MonoGame.SplineFlower.Spline.SplineBase;

namespace MonoGame.SplineFlower.Samples.Controls
{
    public class HermiteSplineControl : TransformControl
    {
        public HermiteSpline MySpline;
        public Car MySplineWalker;
        public Marker MySplineMarker;

        private string _TangentText = "";

        protected override void Initialize()
        {
            base.Initialize();
            Setup.Initialize(Editor.graphics);
            Setup.ShowCurves = true;

            MySpline = new HermiteSpline();
            //Custom ctr-Test
            //MySpline = new HermitSpline(new Transform[] {
            //    new Transform(new Vector2(0, 0)),
            //    new Transform(new Vector2(250, 0)),
            //    new Transform(new Vector2(0, 250))
            //});
            MySpline.Loop = false;
            MySpline.TangentSelected += MySpline_TangentSelected;
            MySpline.TangentDeselected += MySpline_TangentDeselected;
            GetSpline = MySpline;

            CenterSpline();

            MySplineWalker = new Car();
            MySplineWalker.CreateSplineWalker(MySpline, SplineWalker.SplineWalkerMode.Loop, 7);
            MySplineWalker.LoadContent(Editor.Content, Editor.Font);

            MySplineMarker = new Marker();
            MySplineMarker.CreateSplineWalker(MySpline, SplineWalker.SplineWalkerMode.Once, 0, false, autoStart: false);
            MySplineMarker.LoadContent(Editor.Content);

            SetMultiSampleCount(8);

            Editor.SetDisplayStyle = Forms.Services.GFXService.DisplayStyle.TopRight;
            Editor.ShowCursorPosition = false;
            Editor.ShowFPS = false;
        }

        private void MySpline_TangentSelected(int index)
        {
            _TangentText = $"Tangent #{index}";
        }

        private void MySpline_TangentDeselected()
        {
            _TangentText = "";
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
                    ControlPointMode nextMode = MySpline.GetControlPointMode(GetSpline.SelectedTransform.Index).Next();
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

                Editor.spriteBatch.DrawString(Editor.Font, "Marker: " + MySplineMarker.GetProgress.ToString(), new Vector2(10, 10), Color.White);
                Editor.spriteBatch.DrawString(Editor.Font, "Walker: " + MySplineWalker.GetProgress.ToString(), new Vector2(10, 30), Color.White);

                if (!string.IsNullOrEmpty(_TangentText)) Editor.spriteBatch.DrawString(Editor.Font, _TangentText, 
                    new Vector2(
                        Editor.graphics.Viewport.Width - Editor.Font.MeasureString(_TangentText).X - 10, 
                        Editor.graphics.Viewport.Height - 125), 
                    Color.White);

                Editor.spriteBatch.End();

                Editor.EndAntialising();
                Editor.DrawDisplay();
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            MySpline.TangentSelected -= MySpline_TangentSelected;
            MySpline.TangentDeselected -= MySpline_TangentDeselected;
        }
    }
}
