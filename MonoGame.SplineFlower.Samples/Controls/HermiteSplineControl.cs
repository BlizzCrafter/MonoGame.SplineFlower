using Microsoft.Xna.Framework;
using MonoGame.SplineFlower.Spline.Types;
using static MonoGame.SplineFlower.Spline.SplineBase;
using Color = Microsoft.Xna.Framework.Color;

namespace MonoGame.SplineFlower.Samples.Controls
{
    public class HermiteSplineControl : TransformControl
    {
        public Car MySplineWalker;
        public Marker MySplineMarker;

        private string _TangentText = "";

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

            MySpline = new HermiteSpline();
            ((HermiteSpline)MySpline).GetAllTangents[1].Translate(new Vector2(125, 200));
            ((HermiteSpline)MySpline).GetAllTangents[2].Translate(new Vector2(125, 0));
            ((HermiteSpline)MySpline).AddTension(30f);
            ((HermiteSpline)MySpline).AddBias(2.5f);
            ((HermiteSpline)MySpline).TangentSelected += MySpline_TangentSelected;
            ((HermiteSpline)MySpline).TangentDeselected += MySpline_TangentDeselected;

            CenterSpline();

            MySplineWalker = new Car();
            MySplineWalker.CreateSplineWalker(MySpline, SplineWalker.SplineWalkerMode.Loop, 7);
            MySplineWalker.LoadContent(Editor.Content, Editor.Font);

            MySplineMarker = new Marker();
            MySplineMarker.CreateSplineWalker(MySpline, SplineWalker.SplineWalkerMode.Once, 0, false, autoStart: false);
            MySplineMarker.LoadContent(Editor.Content);

            SetMultiSampleCount(8);

            Editor.FPSCounter.SetDisplayStyle = Forms.NET.Components.FPSCounter.DisplayStyle.TopRight;
            Editor.FPSCounter.ShowCursorPosition = false;
            Editor.FPSCounter.ShowFPS = false;
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
                if (MySpline.SelectTransform(new Vector2(e.X, e.Y)) != null && !MySpline.SelectedTransform.IsCenter)
                {
                    ControlPointMode nextMode = MySpline.GetControlPointMode(MySpline.SelectedTransform.Index).Next();
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
            if (MySplineMarker != null && MySplineMarker.Initialized) MySplineMarker.Update(gameTime);
        }

        protected override void Draw()
        {
            if (Editor != null)
            {
                Editor.BeginAntialising();

                Editor.spriteBatch.Begin();

                if (MySpline != null) MySpline.Draw(Editor.spriteBatch);
                if (MySplineWalker != null && MySplineWalker.Initialized) MySplineWalker.Draw(Editor.spriteBatch);
                if (MySplineMarker != null && MySplineMarker.Initialized) MySplineMarker.Draw(Editor.spriteBatch);

                Editor.spriteBatch.DrawString(Editor.Font, "Marker: " + MySplineMarker.GetProgress.ToString(), new Vector2(10, 10), Color.White);
                Editor.spriteBatch.DrawString(Editor.Font, "Walker: " + MySplineWalker.GetProgress.ToString(), new Vector2(10, 30), Color.White);

                if (!string.IsNullOrEmpty(_TangentText)) Editor.spriteBatch.DrawString(Editor.Font, _TangentText, 
                    new Vector2(
                        Editor.GraphicsDevice.Viewport.Width - Editor.Font.MeasureString(_TangentText).X - 10, 
                        Editor.GraphicsDevice.Viewport.Height - 125), 
                    Color.White);

                Editor.spriteBatch.End();

                Editor.EndAntialising();
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (MySpline != null)
            {
                ((HermiteSpline)MySpline).TangentSelected -= MySpline_TangentSelected;
                ((HermiteSpline)MySpline).TangentDeselected -= MySpline_TangentDeselected;
            }
        }
    }
}
