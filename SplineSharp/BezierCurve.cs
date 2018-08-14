using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;

namespace SplineSharp
{
    public class BezierCurve
    {
        public enum Type
        {
            Quadratic,
            Cubic
        }
        private Type BezierType = Type.Quadratic;

        private const int lineSteps = 10;

        public Transform[] points;

        public Transform TryGetTransformFromPosition(Vector2 position)
        {
            if (points.Any(x => x.TryGetPosition(position))) return points.First(x => x.TryGetPosition(position));

            return null;
        }

        public Vector2 GetPoint(float t)
        {
            return BezierType == Type.Cubic ?
                Bezier.GetPoint(points[0].Position, points[1].Position, points[2].Position, points[3].Position, t) :
                Bezier.GetPoint(points[0].Position, points[1].Position, points[2].Position, t);
        }

        public Vector2 GetVelocity(float t)
        {
            Vector2 Velocity = Vector2.Zero;

            if (BezierType == Type.Cubic) Velocity = Bezier.GetFirstDerivative(points[0].Position, points[1].Position, points[2].Position, points[3].Position, t);
            else Velocity = Bezier.GetFirstDerivative(points[0].Position, points[1].Position, points[2].Position, t);

            Velocity.Normalize();
            return Velocity;
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

                DrawLine(spriteBatch, points[i].Position, angle, distance, Setup.BaseLineColor, Setup.BaseLineThickness);
                DrawPoint(spriteBatch, points[i].Position, angle);
            }

            Vector2 lineStart = GetPoint(0f);
            for (int i = 1; i <= lineSteps; i++)
            {
                Vector2 lineEnd = GetPoint(i / (float)lineSteps);

                float distanceStep = Vector2.Distance(lineStart, lineEnd);
                float angleStep = (float)Math.Atan2(lineEnd.Y - lineStart.Y, lineEnd.X - lineStart.X);

                DrawLine(spriteBatch, lineStart, angleStep, distanceStep, Setup.CurveLineColor, Setup.CurveLineThickness);

                if (Setup.ShowVelocityVectors)
                {
                    DrawLine(spriteBatch, lineEnd + GetVelocity(i / (float)lineSteps), angleStep,
                        Setup.VelocityLineLength, Setup.VelocityLineColor, Setup.VelocityLineThickness);
                }

                lineStart = lineEnd;
            }
        }

        private void DrawLine(SpriteBatch spriteBatch, Vector2 position, float angle, float distance, Color color, float thickness)
        {
            spriteBatch.Draw(Setup.Pixel,
                             position,
                             null,
                             color,
                             angle,
                             Vector2.Zero,
                             new Vector2(distance, thickness),
                             SpriteEffects.None,
                             0);
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

        public void CreateQuadratic()
        {
            BezierType = Type.Quadratic;

            points = new Transform[]
            {
                new Transform(new Vector2(100, 100)),
                new Transform(new Vector2(200, 100)),
                new Transform(new Vector2(200, 300))
            };
        }

        public void CreateCubic()
        {
            BezierType = Type.Cubic;

            points = new Transform[]
            {
                new Transform(new Vector2(50, 50)),
                new Transform(new Vector2(300, 50)),
                new Transform(new Vector2(50, 300)),
                new Transform(new Vector2(300, 300))
            };
        }
    }
}
