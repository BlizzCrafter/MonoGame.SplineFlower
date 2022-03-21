using Microsoft.Xna.Framework;
using MonoGame.SplineFlower.Content;
using MonoGame.SplineFlower.Spline.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            MySpline.Loop = false;
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

                if (MySpline != null) MySpline.DrawSpline(Editor.spriteBatch);
                Editor.spriteBatch.End();

                Editor.EndAntialising();
                Editor.DrawDisplay();
            }
        }
    }
}
