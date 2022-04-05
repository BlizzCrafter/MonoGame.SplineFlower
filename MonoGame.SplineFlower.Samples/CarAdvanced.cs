using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.SplineFlower.Spline;

namespace MonoGame.SplineFlower.Samples
{
    public class CarAdvanced : SplineWalker
    {
        private Texture2D _Car;
        private Texture2D _BeamRed, _BeamGreen;

        public void LoadContent(ContentManager Content)
        {
            _Car = Content.Load<Texture2D>(@"car");
            _BeamRed = Content.Load<Texture2D>(@"Beam_Red");
            _BeamGreen = Content.Load<Texture2D>(@"Beam_Green");
        }

        public override void CreateSplineWalker(SplineBase spline, SplineWalkerMode mode, int duration, bool canTriggerEvents = true, SplineWalkerTriggerDirection triggerDirection = SplineWalkerTriggerDirection.Forward, bool autoStart = true)
        {
            base.CreateSplineWalker(spline, mode, duration, canTriggerEvents, triggerDirection, autoStart);
        }

        protected override void EventTriggered(Trigger obj)
        {
            if (CanTrigger(obj))
            {
                if (obj.Name == "Open")
                {
                    if (!(obj.Custom is bool))
                    {
                        obj.Custom = new bool();
                        obj.Custom = true;
                    }
                    obj.Custom = !(bool)obj.Custom;
                }
                else if (obj.Name == "Close")
                {
                    if (!(obj.Custom is bool))
                    {
                        obj.Custom = new bool();
                        obj.Custom = false;
                    }
                    obj.Custom = !(bool)obj.Custom;
                }
            }

            // Calling the base action afterwards. 
            // Otherwise the EventTrigger action here won't work or would be called mutliple times
            // if there is only one TriggerEvent on the Spline.
            base.EventTriggered(obj);
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

            foreach (Trigger trigger in GetTriggers()) DrawTrigger(spriteBatch, trigger);
        }
        private void DrawTrigger(SpriteBatch spriteBatch, Trigger trigger)
        {
            if (trigger.Custom != null && trigger.Custom is bool)
            {
                Texture2D currentTexture = _BeamRed;

                if ((bool)trigger.Custom == false) currentTexture = _BeamRed;
                else currentTexture = _BeamGreen;

                DrawTriggerFunction(spriteBatch, trigger, currentTexture);
            }
            else if (trigger.Name == "Open") DrawTriggerFunction(spriteBatch, trigger, _BeamGreen);
            else if (trigger.Name == "Close") DrawTriggerFunction(spriteBatch, trigger, _BeamRed);
        }
        private void DrawTriggerFunction(SpriteBatch spriteBatch, Trigger trigger, Texture2D texture)
        {
            spriteBatch.Draw(texture,
                         GetPositionOnCurve(trigger.Progress),
                         null,
                         Color.White,
                         trigger.Rotation - MathHelper.ToRadians(90f),
                         new Vector2(texture.Width / 2, (texture.Height / 2)),
                         1f,
                         SpriteEffects.None,
                         0f);
        }
    }
}
