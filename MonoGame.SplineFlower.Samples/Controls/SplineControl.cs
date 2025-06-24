using Microsoft.Xna.Framework;
using MonoGame.SplineFlower.Spline;
using MonoGame.SplineFlower.Spline.Types;
using Color = Microsoft.Xna.Framework.Color;

namespace MonoGame.SplineFlower.Samples.Controls
{
    public class SplineControl : TransformControl
    {
        public Car MySplineWalker;
        public Marker MySplineMarker;

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

            CreateBezierSpline();

            CenterSpline();

            SetMultiSampleCount(8);

            Editor.FPSCounter.SetDisplayStyle = Forms.NET.Components.FPSCounter.DisplayStyle.TopRight;
            Editor.FPSCounter.ShowCursorPosition = false;
            Editor.FPSCounter.ShowFPS = false;
        }

        public void CreateBezierSpline()
        {
            MySpline = new BezierSpline();
            CreateSplineWalkerAndSplineMarker();
        }
        public void CreateCatMulRomSpline()
        {
            MySpline = new CatMulRomSpline();
            CreateSplineWalkerAndSplineMarker();
        }
        public void CreateHermiteSpline()
        {
            MySpline = new HermiteSpline();
            CreateSplineWalkerAndSplineMarker();
        }
        public void CreateSplineWalkerAndSplineMarker()
        {
            MySplineWalker = new Car();
            MySplineWalker.CreateSplineWalker(MySpline, SplineWalker.SplineWalkerMode.Once, 7);
            MySplineWalker.LoadContent(Editor.Content, Editor.Font);

            MySplineMarker = new Marker();
            MySplineMarker.CreateSplineWalker(MySpline, SplineWalker.SplineWalkerMode.Once, 0, false, autoStart: false);
            MySplineMarker.LoadContent(Editor.Content);
        }

        public void ReorderTriggerList()
        {
            if (MySpline != null) MySpline.ReorderTriggerList();
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
            if (MySplineMarker != null && MySplineMarker.Initialized) MySplineMarker.Update(gameTime);
        }

        protected override void Draw()
        {
            if (Editor != null)
            {
                Editor.BeginAntialising();

                Editor.spriteBatch.Begin();

                if (MySpline != null) MySpline.Draw(Editor.spriteBatch);
                if (MySplineWalker != null && MySplineWalker.Initialized)
                {
                    MySplineWalker.Draw(Editor.spriteBatch);
                    Editor.spriteBatch.DrawString(Editor.Font, "Walker: " + MySplineWalker.GetProgress.ToString(), new Vector2(10, 30), Color.White);
                }
                if (MySplineMarker != null && MySplineMarker.Initialized)
                {
                    MySplineMarker.Draw(Editor.spriteBatch);
                    Editor.spriteBatch.DrawString(Editor.Font, "Marker: " + MySplineMarker.GetProgress.ToString(), new Vector2(10, 10), Color.White);
                }

                Editor.spriteBatch.End();

                Editor.EndAntialising();
            }
        }
    }
}
