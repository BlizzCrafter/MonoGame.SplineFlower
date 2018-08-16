using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SplineSharp.Samples
{
    public class SpriteMan : SplineWalker
    {
        public override void CreateSplineWalker(BezierSpline spline, SplineWalkerMode mode, float duration)
        {
            base.CreateSplineWalker(spline, mode, duration);
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
