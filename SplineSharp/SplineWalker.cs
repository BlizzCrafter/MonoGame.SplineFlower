using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace SplineSharp
{
    public abstract class SplineWalker
    {
        public enum SplineWalkerMode
        {
            Once,
            Loop,
            PingPong
        }
        public SplineWalkerMode Mode { get; set; }


        private BezierSpline Spline;

        protected Vector2 Position { get; private set; }
        protected Vector2 Direction { get; private set; }
        protected float Rotation { get; private set; }
        protected float Duration { get; set; }
        private Rectangle Size = new Rectangle(0, 0, 10, 10);
        private void SetPosition(Vector2 position)
        {
            Position = position;
            Size.X = (int)position.X;
            Size.Y = (int)position.Y;
        }

        public bool Initialized { get; private set; } = false;
        public bool LookForward { get; private set; } = true;

        private float _Progress;
        private bool _GoingForward = true;

        public virtual void CreateSplineWalker(BezierSpline spline, SplineWalkerMode mode, float duration)
        {
            Spline = spline;
            Duration = 12f;
            Mode = SplineWalkerMode.Once;

            SetPosition(spline.GetPointWalker(0));

            Initialized = true;
        }

        public void Reset()
        {
            _Progress = 0;
        }

        public virtual void Update(GameTime gameTime)
        {
            if (_GoingForward)
            {
                _Progress += (float)gameTime.ElapsedGameTime.TotalSeconds / Duration;
                if (_Progress > 1f)
                {
                    if (Mode == SplineWalkerMode.Once)
                    {
                        _Progress = 1f;
                    }
                    else if (Mode == SplineWalkerMode.Loop)
                    {
                        _Progress -= 1f;
                    }
                    else
                    {
                        _Progress = 2f - _Progress;
                        _GoingForward = false;
                    }
                }
            }
            else
            {
                _Progress -= (float)gameTime.ElapsedGameTime.TotalSeconds / Duration;
                if (_Progress < 0f)
                {
                    _Progress = -_Progress;
                    _GoingForward = true;
                }
            }
            
            if (LookForward)
            {
                Direction = Spline.GetVelocityWalker(_Progress);
                Direction.Normalize();
                Rotation = (float)Math.Atan2(Direction.X, -Direction.Y);
            }

            SetPosition(Spline.GetPointWalker(_Progress));
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Setup.Pixel,
                             Size,
                             null,
                             Color.White,
                             Rotation,
                             new Vector2(0.5f),
                             SpriteEffects.None,
                             0f);
        }
    }
}
