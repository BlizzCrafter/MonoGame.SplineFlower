using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SplineSharp
{
    public class SplineWalker
    {
        private BezierSpline Spline;

        public Transform GetTransform { get; set; }

        public float Duration { get; set; }
        private float _Progress;

        public bool Initialized { get; private set; } = false;

        public virtual void CreateSplineWalker(BezierSpline spline, float duration)
        {
            Spline = spline;
            Duration = duration;

            GetTransform = new Transform(spline.GetPointWalker(0));

            Initialized = true;
        }

        public void Reset()
        {
            _Progress = 0;
        }

        public virtual void Update(GameTime gameTime)
        {
            _Progress += (float)gameTime.ElapsedGameTime.TotalSeconds / Duration;
            if (_Progress > 1f)
            {
                _Progress = 1f;
            }
            GetTransform.SetPosition(Spline.GetPointWalker(_Progress));
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Setup.Pixel,
                             GetTransform.Size,
                             null,
                             Color.White,
                             0f,
                             new Vector2(0f),
                             SpriteEffects.None,
                             0f);
        }
    }
}
