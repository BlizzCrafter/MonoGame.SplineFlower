﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SplineSharp
{
    public static class Setup
    {
        public static Color LineColor { get; set; } = Color.White;
        public static float LineThickness { get; set; } = 1f;

        public static Color PointColor { get; set; } = Color.Red;
        public static int PointThickness { get; set; } = 10;

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
