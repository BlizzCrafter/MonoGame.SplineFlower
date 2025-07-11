﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.SplineFlower.Spline;

namespace MonoGame.SplineFlower.Samples
{
    public class Marker : SplineWalker
    {
        public static bool ShowSplineMarker { get; set; } = true;

        public string SelectedTrigger { get; set; }
        public bool MarkerSelected { get; set; } = true;

        private Texture2D _Arrow;

        public override Trigger GetTrigger(string triggerID = "SelectedTrigger")
        {
            return base.GetTrigger(SelectedTrigger);
        }

        public void LoadContent(ContentManager Content)
        {
            _Arrow = Content.Load<Texture2D>(@"arrow");
        }

        public override void SetPosition(float progress)
        {
            base.SetPosition(progress);

            if (!MarkerSelected) SetTriggerPosition(SelectedTrigger, progress);
        }

        public override void CreateSplineWalker(SplineBase spline, SplineWalkerMode mode, int duration, bool canTriggerEvents = true, SplineWalkerTriggerDirection triggerDirection = SplineWalkerTriggerDirection.Forward, bool autoStart = true)
        {
            base.CreateSplineWalker(spline, mode, duration, canTriggerEvents, triggerDirection, autoStart);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Setup.ShowSpline && ShowSplineMarker)
            {
                spriteBatch.Draw(_Arrow,
                                 Position,
                                 null,
                                 Setup.TriggerEventColor,
                                 Rotation,
                                 new Vector2(_Arrow.Width / 2, _Arrow.Height / 2),
                                 Setup.TriggerEventThickness,
                                 SpriteEffects.None,
                                 0f);
            }
        }
    }
}
