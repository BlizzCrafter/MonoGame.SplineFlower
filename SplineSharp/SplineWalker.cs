using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace SplineSharp
{
    public abstract class SplineWalker
    {
        public enum SplineWalkerMode
        {
            Once = 0,
            Loop = 1,
            PingPong = 2
        }
        public SplineWalkerMode Mode { get; set; }

        private BezierSpline _Spline;

        protected Vector2 Position { get; private set; }
        protected Vector2 Direction { get; private set; }
        protected float Rotation { get; private set; }
        protected float Duration { get; set; }
        private Rectangle _Size = new Rectangle(0, 0, 10, 10);
        private void SetPosition(Vector2 position)
        {
            Position = position;
            _Size.X = (int)position.X;
            _Size.Y = (int)position.Y;
        }

        public bool Initialized { get; private set; } = false;

        private float _Progress;
        private bool _GoingForward = true;
        private bool _LookForward = true;

        public void CreateSplineWalker(BezierSpline spline, SplineWalkerMode mode, float duration)
        {
            _Spline = spline;
            Duration = duration;
            Mode = SplineWalkerMode.Once;

            SetPosition(spline.GetPoint(0));

            Initialized = true;
        }

        public void Reset()
        {
            _Progress = 0;
        }

        public void Update(GameTime gameTime)
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
            
            if (_LookForward)
            {
                Direction = _Spline.GetDirection(_Progress);
                Direction.Normalize();
                Rotation = (float)Math.Atan2(Direction.X, -Direction.Y);
            }

            SetPosition(_Spline.GetPoint(_Progress));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Setup.Pixel,
                             _Size,
                             null,
                             Color.White,
                             Rotation,
                             new Vector2(0.5f),
                             SpriteEffects.None,
                             0f);
        }
    }
}
