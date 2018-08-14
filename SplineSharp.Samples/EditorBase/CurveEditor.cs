using Microsoft.Xna.Framework;
using MonoGame.Forms.Controls;

namespace SplineSharp.Samples.EditorBase
{
    public abstract class CurveEditor : TransformControl
    {
        public BezierCurve MyCurve;

        protected override void Initialize()
        {
            base.Initialize();

            Setup.Initialize(Editor.graphics);
            MyCurve = new BezierCurve();
            MyCurve.CreateCubic();
            TryGetTransformFromPosition = MyCurve.TryGetTransformFromPosition;
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw()
        {
            base.Draw();

            Editor.spriteBatch.Begin();

            if (MyCurve != null) MyCurve.DrawCurve(Editor.spriteBatch);

            Editor.spriteBatch.End();
        }
    }
}
