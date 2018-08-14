using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;

namespace SplineSharp
{
    public class BezierCurve
    {
        public Transform[] points;

        public Transform TryGetTransformFromPosition(Vector2 position)
        {
            if (points.Any(x => x.TryGetPosition(position))) return points.First(x => x.TryGetPosition(position));

            return null;
        }

        public void DrawCurve(SpriteBatch spriteBatch)
        {
            if (Setup.Pixel == null)
            {
                throw new Exception("You need to initialize the SplineSharp library first by calling 'SplineSharp.Setup.Initialize();'");
            }

            if (points.Length <= 1 || points.ToList().TrueForAll(x => x.Equals(Vector2.Zero))) return;

            float distance = 0, angle = 0;
            for (int i = 0; i < points.Length; i++)
            {
                if (i + 1 > points.Length - 1)
                {
                    DrawPoint(spriteBatch, points[i].Position, angle);
                    break;
                }

                distance = Vector2.Distance(points[i].Position, points[i + 1].Position);
                angle = (float)Math.Atan2(points[i + 1].Position.Y - points[i].Position.Y, points[i + 1].Position.X - points[i].Position.X);

                spriteBatch.Draw(Setup.Pixel,
                                 points[i].Position,
                                 null,
                                 Setup.LineColor,
                                 angle,
                                 Vector2.Zero,
                                 new Vector2(distance, Setup.LineThickness),
                                 SpriteEffects.None,
                                 0);

                DrawPoint(spriteBatch, points[i].Position, angle);
            }
        }

        private void DrawPoint(SpriteBatch spriteBatch, Vector2 point, float angle)
        {
            spriteBatch.Draw(Setup.Pixel,
                             point,
                             null,
                             Setup.PointColor,
                             angle,
                             new Vector2(0.5f),
                             Setup.PointThickness,
                             SpriteEffects.None,
                             0f);
        }

        public void Reset()
        {
            points = new Transform[]
            {
                new Transform(new Vector2(100, 100)),
                new Transform(new Vector2(200, 100)),
                new Transform(new Vector2(300, 100))
            };
        }
    }
}
