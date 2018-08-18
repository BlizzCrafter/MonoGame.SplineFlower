using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SplineSharp.Samples
{
    public class Marker : SplineWalker
    {
        private Texture2D _Arrow;

        public void LoadContent(ContentManager Content)
        {
            _Arrow = Content.Load<Texture2D>(@"arrow");
        }

        public override void CreateSplineWalker(BezierSpline spline, SplineWalkerMode mode, float duration, bool autoStart = true)
        {
            base.CreateSplineWalker(spline, mode, duration, autoStart);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_Arrow,
                             Position,
                             null,
                             Setup.StartPointColor,
                             Rotation,
                             new Vector2(_Arrow.Width / 2, _Arrow.Height / 2),
                             1f,
                             SpriteEffects.None,
                             0f);
        }
    }
}
