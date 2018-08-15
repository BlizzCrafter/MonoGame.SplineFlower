using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SplineSharp.Samples
{
    public class SpriteMan : SplineWalker
    {
        public override void CreateSplineWalker(BezierSpline spline, float duration)
        {
            base.CreateSplineWalker(spline, duration);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
