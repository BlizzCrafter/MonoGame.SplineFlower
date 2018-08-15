using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace SplineSharp
{
    public abstract class SplineWalker
    {
        private BezierSpline Spline;

        protected Transform GetTransform { get; set; }
        protected float Duration { get; set; }

        public bool Initialized { get; private set; } = false;
        public bool LookForward { get; private set; } = true;

        private float _Progress;
        public Vector2 _Velocity;

        public virtual void CreateSplineWalker(BezierSpline spline, float duration)
        {
            Spline = spline;
            Duration = 10f;

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

            //Vector2 position = Spline.GetPointWalker(_Progress);
            //GetTransform.SetPosition(position);
            if (LookForward)
            {
                _Velocity = Spline.GetVelocityWalker(_Progress);
                _Velocity.Normalize();
                GetTransform.Rotation = MathHelper.ToRadians(45f) + (float)Math.Atan2(_Velocity.X, -_Velocity.Y);
            }

            GetTransform.SetPosition(Spline.GetPointWalker(_Progress));
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Setup.Pixel,
                             GetTransform.Size,
                             null,
                             Color.White,
                             GetTransform.Rotation,
                             new Vector2(_Velocity.Y, _Velocity.X),
                             SpriteEffects.None,
                             0f);
        }
    }
}
