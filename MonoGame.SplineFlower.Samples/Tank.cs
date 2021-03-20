using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.SplineFlower.Spline;
using System;

namespace MonoGame.SplineFlower.Samples
{
    public class Tank : SplineWalker
    {
        private Texture2D _BeamRed, _BeamGreen;
        private Texture2D _TankBottom, _Tank_Middle, _TankTop;

        private float GunRotation = 0f, CurrentRotation = 0f;

        public void LoadContent(ContentManager Content)
        {
            _BeamRed = Content.Load<Texture2D>(@"Beam_Red");
            _BeamGreen = Content.Load<Texture2D>(@"Beam_Green");

            _TankBottom = Content.Load<Texture2D>(@"Tank_Bottom");
            _Tank_Middle = Content.Load<Texture2D>(@"Tank_Middle");
            _TankTop = Content.Load<Texture2D>(@"Tank_Top");
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

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Vector2 angleVector = new Vector2(
                GamePad.GetState(PlayerIndex.One, GamePadDeadZone.Circular).ThumbSticks.Right.X,
                -GamePad.GetState(PlayerIndex.One, GamePadDeadZone.Circular).ThumbSticks.Right.Y);

            GunRotation = (float)Math.Atan2(angleVector.X, -angleVector.Y);

            if (Math.Abs(GunRotation) > 0)
            {
                CurrentRotation = GunRotation;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            spriteBatch.Draw(_TankBottom,
                                 Position,
                                 null,
                                 Color.White,
                                 Rotation,
                                 new Vector2(_TankBottom.Width / 2, _TankBottom.Height / 2),
                                 0.1f,
                                 SpriteEffects.None,
                                 0f);

            spriteBatch.Draw(_Tank_Middle,
                                 Position,
                                 null,
                                 Color.White,
                                 Rotation,
                                 new Vector2(_Tank_Middle.Width / 2, _Tank_Middle.Height / 2),
                                 0.1f,
                                 SpriteEffects.None,
                                 0f);

            spriteBatch.Draw(_TankTop,
                                 Position,
                                 null,
                                 Color.White,
                                 CurrentRotation,
                                 new Vector2(_TankTop.Width / 2, (_TankTop.Height / 2) + 100),
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
