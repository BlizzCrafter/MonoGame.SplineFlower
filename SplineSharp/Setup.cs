using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SplineSharp
{
    public static class Setup
    {
        public static Color BaseLineColor { get; set; } = Color.White;
        public static float BaseLineThickness { get; set; } = 1f;

        public static Color CurveLineColor { get; set; } = Color.Yellow;
        public static float CurveLineThickness { get; set; } = 1.5f;

        public static Color DirectionLineColor { get; set; } = Color.LightGreen;
        public static float DirectionLineThickness { get; set; } = 1f;
        public static float DirectionLineLength { get; set; } = 50f;
        public static bool ShowDirectionVectors { get; set; } = true;

        public static Color StartPointColor { get; set; } = Color.Magenta;
        public static float StartPointThickness { get; set; } = 1.3f;

        public static Color PointColor { get; set; } = Color.Red;
        public static int PointThickness { get; set; } = 10;

        public static bool MovePointAxis { get; set; } = true;

        internal static Texture2D Pixel { get; set; }

        public static void Initialize(GraphicsDevice graphicsDevice)
        {
            if (Pixel == null)
            {
                Pixel = new Texture2D(graphicsDevice, 1, 1);
                Pixel.SetData(new[] { Color.White });
            }
        }
    }
}
