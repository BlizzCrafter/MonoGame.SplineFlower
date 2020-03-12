using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.SplineFlower.Content
{
    public static class Extensions
    {
        public static void DrawCircle(this SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            spriteBatch.Draw(Setup.Circle,
                             position,
                             null,
                             color,
                             0,
                             new Vector2(Setup.Circle.Width / 2, Setup.Circle.Height / 2),
                             Setup.TriggerEventThickness,
                             SpriteEffects.None,
                             0f);
        }

        public static void DrawPoint(this SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            spriteBatch.Draw(Setup.Pixel,
                             position,
                             null,
                             color,
                             0,
                             new Vector2(0.5f),
                             Setup.PointThickness,
                             SpriteEffects.None,
                             0f);
        }
    }
}
