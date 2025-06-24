using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.SplineFlower
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

        public static T Next<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argumnent {0} is not an Enum", typeof(T).FullName));

            T[] Arr = (T[])Enum.GetValues(src.GetType());
            int j = Array.IndexOf<T>(Arr, src) + 1;
            return (Arr.Length == j) ? Arr[0] : Arr[j];
        }

        public static Vector2 Normal(this Vector2 value)
        {
            value.Normalize();
            return value;
        }
    }
}
