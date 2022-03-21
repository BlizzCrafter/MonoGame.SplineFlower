using Microsoft.Xna.Framework;
using MonoGame.SplineFlower.Content;
using MonoGame.SplineFlower.Spline.Types;
using System.Linq;

namespace MonoGame.SplineFlower.Samples.Controls
{
    public class ChainSplineControl : TransformControl
    {
        public HermiteSpline MySpline;

        protected override void Initialize()
        {
            base.Initialize();
            Setup.Initialize(Editor.graphics);
            Setup.ShowCurves = true;
            Setup.ShowDirectionVectors = false;
            Setup.ShowLines = true;
            Setup.ShowPoints = true;

            MySpline = new HermiteSpline(new Transform[] 
            {
                new Transform(new Vector2(0, 0)),
                new Transform(new Vector2(100, 0)),
                new Transform(new Vector2(100, 100)),
                new Transform(new Vector2(0, 100))
            });
            MySpline.GetAllTangents.ToList().ForEach(x => x.Translate(new Vector2(0, 50)));
            MySpline.Loop = true;
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

                if (MySpline != null)
                {
                    MySpline.DrawSpline(Editor.spriteBatch);

                    if (MySpline.SelectedTransform != null)
                    {
                        if (MySpline.SelectedTransform.Left != null)
                        {
                            Editor.spriteBatch.DrawString(Editor.Font, "LEFT", new Vector2(MySpline.SelectedTransform.Left.Position.X, MySpline.SelectedTransform.Left.Position.Y - MySpline.SelectedTransform.Left.Size.Height), Color.White);
                        }

                        if (MySpline.SelectedTransform.Right != null)
                        {
                            Editor.spriteBatch.DrawString(Editor.Font, "RIGHT", new Vector2(MySpline.SelectedTransform.Right.Position.X, MySpline.SelectedTransform.Right.Position.Y - MySpline.SelectedTransform.Right.Size.Height), Color.White);
                        }
                    }
                }

                Editor.spriteBatch.End();

                Editor.EndAntialising();
                Editor.DrawDisplay();
            }
        }
    }
}
