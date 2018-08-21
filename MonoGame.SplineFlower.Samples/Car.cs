using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.SplineFlower.Samples
{
    public class Car : SplineWalker
    {
        public bool Stop { get; set; }

        private Texture2D _Car;
        private SoundEffect _Horn, _HandBrake, _CarDrive;

        private bool _HandBrakeTriggered = false;
        private int _HandBrakeTimeout = 60, _HandBrakeTimeoutMax = 60;

        private SpriteFont Font;

        public void LoadContent(ContentManager Content, SpriteFont font)
        {
            Font = font;

            _Car = Content.Load<Texture2D>(@"car");

            _Horn = Content.Load<SoundEffect>(@"Audio/horn");
            _HandBrake = Content.Load<SoundEffect>(@"Audio/handbrake");
            _CarDrive = Content.Load<SoundEffect>(@"Audio/cardrive");
        }

        public override void CreateSplineWalker(BezierSpline spline, SplineWalkerMode mode, float duration, bool canTriggerEvents = true, bool autoStart = true)
        {
            base.CreateSplineWalker(spline, mode, duration, canTriggerEvents, autoStart);
        }

        protected override void EventTriggered(Trigger obj)
        {
            if (!AlreadyTriggered(obj))
            {
                if (obj.Name == "Horn") _Horn.CreateInstance().Play();
                else if (obj.Name == "Brakes")
                {
                    _HandBrakeTriggered = true;
                    _HandBrake.CreateInstance().Play();
                }
                else if (obj.Name == "Counter")
                {
                    if (!(obj.Custom is int)) obj.Custom = new int();
                    obj.Custom = ((int)obj.Custom) + 1;
                }
            }

            // Calling the base action afterwards. 
            // Otherwise the EventTrigger action here won't work or would be called mutliple times
            // if there is only one TriggerEvent on the Spline.
            base.EventTriggered(obj);
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
            else if (!Stop) base.Update(gameTime);
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

            foreach (Trigger trigger in GetTriggers("Counter"))
            {
                if (trigger.Custom != null) spriteBatch.DrawString(Font, trigger.Custom.ToString(), GetPositionOnCurve(trigger.Progress), Color.White);
            }
        }
    }
}
