using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SplineSharp.Samples
{
    public class Car : SplineWalker
    {
        private Texture2D _Car;

        public void LoadContent(ContentManager Content)
        {
            _Car = Content.Load<Texture2D>(@"Car");
        }

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

            spriteBatch.Draw(_Car,
                             Position,
                             null,
                             Color.White,
                             Rotation,
                             new Vector2(_Car.Width / 2, _Car.Height / 2),
                             0.1f,
                             SpriteEffects.None,
                             0f);
        }
    }
}
