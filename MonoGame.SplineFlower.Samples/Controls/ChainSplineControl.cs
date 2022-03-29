using MonoGame.SplineFlower.Content;
using MonoGame.SplineFlower.Spline.Types;

namespace MonoGame.SplineFlower.Samples.Controls
{
    public class ChainSplineControl : TransformControl
    {
        public CatMulRomSpline MySpline;

        protected override void Initialize()
        {
            base.Initialize();
            Setup.Initialize(Editor.graphics);
            Setup.ShowCurves = true;
            Setup.ShowDirectionVectors = false;
            Setup.ShowLines = true;
            Setup.ShowPoints = true;

            MySpline = new CatMulRomSpline();
            MySpline.AddCurveLeft();
            MySpline.AddCurveRight();
            MySpline.CreateChain();
            GetSpline = MySpline;

            CenterSpline();

            SetMultiSampleCount(8);

            Editor.SetDisplayStyle = Forms.Services.GFXService.DisplayStyle.TopRight;
            Editor.ShowCursorPosition = false;
            Editor.ShowFPS = false;
        }

        public void SplineControl_RecalculateSplineCenter()
        {
            if (MySpline != null) MySpline.CalculateSplineCenter(MySpline.GetAllPoints);
        }

        protected override void Draw()
        {
            base.Draw();

            if (Editor != null)
            {
                Editor.BeginAntialising();

                Editor.spriteBatch.Begin();

                if (MySpline != null)
                {
                    MySpline.Draw(Editor.spriteBatch);

                    #region DEBUG
                    //if (MySpline.SelectedTransform != null)
                    //{
                    //    if (MySpline.SelectedTransform.Left != null)
                    //    {
                    //        Editor.spriteBatch.DrawString(Editor.Font, "LEFT", new Vector2(MySpline.SelectedTransform.Left.Position.X, MySpline.SelectedTransform.Left.Position.Y - MySpline.SelectedTransform.Left.Size.Height), Color.White);
                    //    }

                    //    if (MySpline.SelectedTransform.Right != null)
                    //    {
                    //        Editor.spriteBatch.DrawString(Editor.Font, "RIGHT", new Vector2(MySpline.SelectedTransform.Right.Position.X, MySpline.SelectedTransform.Right.Position.Y - MySpline.SelectedTransform.Right.Size.Height), Color.White);
                    //    }
                    //}
                    #endregion
                }

                Editor.spriteBatch.End();

                Editor.EndAntialising();
                Editor.DrawDisplay();
            }
        }
    }
}
