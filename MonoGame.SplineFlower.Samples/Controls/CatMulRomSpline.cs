using Microsoft.Xna.Framework;
using MonoGame.SplineFlower.Content;
using System.Windows.Forms;

namespace MonoGame.SplineFlower.Samples.Controls
{
    public class CatMulRomSpline : TransformControl
    {
        public BezierSpline MySpline;

        protected override void Initialize()
        {
            base.Initialize();
            Setup.Initialize(Editor.graphics);

            MySpline = new BezierSpline();
            MySpline.Reset();
            MySpline.CatMulRom = true;
            MySpline.Loop = false;
            TryGetTransformFromPosition = MySpline.TryGetTransformFromPosition;
            TryGetTriggerFromPosition = MySpline.TryGetTriggerFromPosition;
            GetAllPoints = MySpline.GetAllPoints;
            GetAllTrigger = MySpline.GetAllTrigger;
            RecalculateBezierCenter += SplineControl_RecalculateBezierCenter; ;
            MovePointDiff += SplineEditor_MovePointDiff;

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
        }

        protected override void Draw()
        {
            base.Draw();

            if (Editor != null)
            {
                Editor.BeginAntialising();

                Editor.spriteBatch.Begin();

                if (MySpline != null) MySpline.DrawSpline(Editor.spriteBatch);

                Editor.spriteBatch.End();

                Editor.EndAntialising();
                Editor.DrawDisplay();
            }
        }
    }
}
