using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SplineSharp.Samples
{
    public class Car : SplineWalker
    {
        private Texture2D _Car;
        private SoundEffect _Horn, _HandBrake, _CarDrive;

        private bool _HandBrakeTriggered = false;
        private int _HandBrakeTimeout = 60, _HandBrakeTimeoutMax = 60;

        public void LoadContent(ContentManager Content)
        {
            _Car = Content.Load<Texture2D>(@"car");

            _Horn = Content.Load<SoundEffect>(@"Audio/horn");
            _HandBrake = Content.Load<SoundEffect>(@"Audio/handbrake");
            _CarDrive = Content.Load<SoundEffect>(@"Audio/cardrive");
        }

        public override void CreateSplineWalker(BezierSpline spline, SplineWalkerMode mode, float duration, bool canTriggerEvents = true, bool autoStart = true)
        {
            base.CreateSplineWalker(spline, mode, duration, canTriggerEvents, autoStart);

            _Spline.EventTriggered += _Spline_EventTriggered;
        }
        private void _Spline_EventTriggered(string obj)
        {
            if (obj == "Horn") _Horn.CreateInstance().Play();
            else if (obj == "Brakes")
            {
                _HandBrakeTriggered = true;
                _HandBrake.CreateInstance().Play();
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (_HandBrakeTriggered)
            {
                _HandBrakeTimeout--;
                if (_HandBrakeTimeout <= 0)
                {
                    _HandBrakeTriggered = false;
                    _CarDrive.CreateInstance().Play();
                    _HandBrakeTimeout = _HandBrakeTimeoutMax;
                }
            }
            else base.Update(gameTime);
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
