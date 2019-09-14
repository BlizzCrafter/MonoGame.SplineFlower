using System.Windows.Forms;
using Microsoft.Xna.Framework;
using MonoGame.SplineFlower.Content;

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
            Setup.Initialize(GraphicsDevice);

            MySpline = new BezierSpline();
            MySpline.Reset();
            GetSpline = MySpline;

            MySplineWalker = new Car();
            MySplineWalker.CreateSplineWalker(MySpline, SplineWalker.SplineWalkerMode.Once, 7);
            MySplineWalker.LoadContent(Editor.Content, Editor.Font);

            MySplineMarker = new Marker();
            MySplineMarker.CreateSplineWalker(MySpline, SplineWalker.SplineWalkerMode.Once, 0, false, autoStart: false);
            MySplineMarker.LoadContent(Editor.Content);

            MoveSplineToScreenCenter();

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

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            
            if (e.Button == MouseButtons.Right)
            {
                SelectedTransform = GetSpline.TryGetTransformFromPosition(new Vector2(e.X, e.Y));
                if (SelectedTransform != null && !SelectedTransform.IsCenterSpline)
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

                Editor.spriteBatch.DrawString(Editor.Font, "Marker: " + MySplineMarker.GetProgress.ToString(), new Vector2(10, 10), Color.White);
                Editor.spriteBatch.DrawString(Editor.Font, "Walker: " + MySplineWalker.GetProgress.ToString(), new Vector2(10, 30), Color.White);

                Editor.spriteBatch.End();

                Editor.EndAntialising();
                Editor.DrawDisplay();
            }
        }
    }
}
