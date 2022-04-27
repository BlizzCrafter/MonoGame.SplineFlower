using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.SplineFlower.Utils;
using System;

namespace MonoGame.SplineFlower.Content
{
    public static class Setup
    {
        public static void SetSplineMarkerResolution(float resolution)
        {
            SplineMarkerResolution = resolution;
            SplineStepDistance = SplineMarkerResolution / (float)Math.Pow(SplineMarkerResolution, 2) * 3f;
        }
        public static float SplineMarkerResolution { get; private set; } = 1000f;
        public static float SplineStepDistance { get; private set; }
        public static int LineSteps { get; set; } = 20;

        public static bool ShowSpline { get; set; } = true;
        public static bool ShowSplineWalker { get; set; } = true;

        public static bool ShowPolygonStripe { get; set; } = true;

        public static Color BaseLineColor { get; set; } = Color.White;
        public static float BaseLineThickness { get; set; } = 1f;
        public static bool ShowBaseLine { get; set; } = true;
        public static bool ShowLines { get; set; } = true;
        public static bool ShowPoints { get; set; } = true;

        public static Color CurveLineColor { get; set; } = Color.Yellow;
        public static float CurveLineThickness { get; set; } = 1.5f;
        public static bool ShowCurves { get; set; } = true;

        public static Color DirectionLineColor { get; set; } = Color.LightGreen;
        public static float DirectionLineThickness { get; set; } = 1f;
        public static float DirectionLineLength { get; set; } = 50f;
        public static bool ShowDirectionVectors { get; set; } = true;

        public static Color PointColor { get; set; } = Color.Red;
        public static int PointThickness { get; set; } = 10;
        public static Color StartPointColor { get; set; } = Color.White;
        public static int StartPointThickness { get; set; } = 14;
        public static Color EndPointColor { get; set; } = Color.Black;
        public static int EndPointThickness { get; set; } = 14;

        public static Color TriggerEventColor { get; set; } = Color.Magenta;
        public static float TriggerEventThickness { get; set; } = 1f;
        public static bool ShowTriggers { get; set; } = true;

        public static bool ShowTangents { get; set; } = true;

        public static Color CenterSplineColor { get; set; } = new Color(237, 188, 100, 225);
        public static int CenterSplineIndex { get; } = -999999;
        public static bool ShowCenterSpline { get; set; } = true;

        public static bool MovePointAxis { get; set; } = true;

        public static Texture2D Pixel { get; set; }
        public static Texture2D Circle { get; set; }

        public static bool Initialized { get; private set; } = false;
        public static void CheckInitialization()
        {
            if (!Initialized)
            {
                throw new Exception("You need to initialize the MonoGame.SplineFlower library first by calling ' MonoGame.SplineFlower.Setup.Initialize();'");
            }
        }

        public static void Initialize(GraphicsDevice graphicsDevice, float splineMarkerResolution = 1000f)
        {
            Functions.graphics = graphicsDevice;
            Functions.GetBasicEffect = new BasicEffect(graphicsDevice);
            Functions.GetBasicEffect.TextureEnabled = true;
            Functions.GetBasicEffect.VertexColorEnabled = true;

            Functions.RasterizerState = new RasterizerState
            {
                FillMode = FillMode.Solid,
                CullMode = CullMode.None
            };

            Functions.DisplayToWorldUnit = 256f;

            if (Pixel == null)
            {
                Pixel = new Texture2D(graphicsDevice, 1, 1);
                Pixel.SetData(new[] { Color.White });
            }

            if (Circle == null)
            {
                Circle = CreateCircleTexture(graphicsDevice, 8);
            }

            SetSplineMarkerResolution(splineMarkerResolution);

            Initialized = true;
        }

        private static Texture2D CreateCircleTexture(GraphicsDevice device, int radius)
        {
            Texture2D texture = new Texture2D(device, radius, radius);
            Color[] colorData = new Color[radius * radius];

            float diam = radius / 2f;
            float diamsq = diam * diam;

            for (int x = 0; x < radius; x++)
            {
                for (int y = 0; y < radius; y++)
                {
                    int index = x * radius + y;
                    Vector2 pos = new Vector2(x - diam, y - diam);
                    if (pos.LengthSquared() <= diamsq)
                    {
                        colorData[index] = Color.White;
                    }
                    else
                    {
                        colorData[index] = Color.Transparent;
                    }
                }
            }

            texture.SetData(colorData);
            return texture;
        }
    }
}
