using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.SplineFlower.Content;
using MonoGame.SplineFlower.Spline.Types;

namespace MonoGame.SplineFlower.Samples.Controls
{
    public class ChainSplineControl : TransformControl
    {
        private bool _RotatePlus, _RotateMinus;

        GraphicsMetrics metrics;

        protected override void Initialize()
        {
            base.Initialize();
            Setup.Initialize(Editor.graphics);
        }

        public override void InitializeSplineControlSample()
        {
            Setup.ShowCurves = true;
            Setup.ShowDirectionVectors = false;
            Setup.ShowLines = true;
            Setup.ShowPoints = true;

            CreateSpline(1);

            SetMultiSampleCount(8);

            Editor.SetDisplayStyle = Forms.Services.GFXService.DisplayStyle.TopRight;
            Editor.ShowCursorPosition = false;
            Editor.ShowFPS = true;
        }

        public void CreateSpline(int curveCount)
        {
            if (curveCount > 3000) curveCount = 3000;
            else if (curveCount < 2) curveCount = 2;

            MySpline = new CatMulRomSpline();
            for (int i = 0; i < curveCount / 2; i++)
            {
                MySpline.AddCurveLeft();
                MySpline.AddCurveRight();
            }
            MySpline.CreateChain();

            CenterSpline();
        }

        public void SplineControl_RecalculateSplineCenter()
        {
            if (MySpline != null) MySpline.CalculateSplineCenter(MySpline.GetAllPoints);
        }

        public void RotatePlus()
        {
            _RotateMinus = false;
            _RotatePlus = true;
        }

        public void RotateStop()
        {
            _RotateMinus = false;
            _RotatePlus = false;
        }

        public void RotateMinus()
        {
            _RotateMinus = true;
            _RotatePlus = false;
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (MySpline != null)
            {
                if (_RotatePlus) MySpline.ScaleRotate(-100f);
                else if (_RotateMinus) MySpline.ScaleRotate(1f);
            }
        }

        protected override void Draw()
        {
            base.Draw();

            GraphicsDevice.Metrics = new GraphicsMetrics();
            
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

                metrics = GraphicsDevice.Metrics;

                Editor.DrawDisplay();

                Editor.spriteBatch.Begin();

                Editor.spriteBatch.DrawString(Editor.Font, $"Sprites: {metrics.PrimitiveCount / 2}", new Vector2(20, 20), Color.White);
                Editor.spriteBatch.DrawString(Editor.Font, $"Points: {MySpline.ControlPointCount}", new Vector2(20, 40), Color.White);

                Editor.spriteBatch.End();

            }
        }
    }
}
