using Microsoft.Xna.Framework;
using MonoGame.SplineFlower.Content;
using System.Windows.Forms;

namespace MonoGame.SplineFlower.Samples.Controls
{
    public class CatMulRomSpline : TransformControl
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
            MySpline.CatMulRom = true;
            MySpline.Loop = true;
            TryGetTransformFromPosition = MySpline.TryGetTransformFromPosition;
            TryGetTriggerFromPosition = MySpline.TryGetTriggerFromPosition;
            GetAllPoints = MySpline.GetAllPoints;
            GetAllTrigger = MySpline.GetAllTrigger;
            RecalculateBezierCenter += SplineControl_RecalculateBezierCenter; ;
            MovePointDiff += SplineEditor_MovePointDiff;

            MoveSplineToScreenCenter();

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
            if (MySpline != null) TranslateAllPointsToScreenCenter(MySpline.GetSplineCenter.Position);
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

                Editor.spriteBatch.DrawString(Editor.Font, "Marker: " + MySplineMarker.GetProgress.ToString(), new Vector2(10, 10), Color.White);
                Editor.spriteBatch.DrawString(Editor.Font, "Walker: " + MySplineWalker.GetProgress.ToString(), new Vector2(10, 30), Color.White);

                Editor.spriteBatch.End();

                Editor.EndAntialising();
                Editor.DrawDisplay();
            }
        }
    }
}
