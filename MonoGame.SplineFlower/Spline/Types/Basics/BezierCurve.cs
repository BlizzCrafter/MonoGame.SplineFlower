using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.SplineFlower.Spline.Types.Basics
{
    public class BezierCurve : PointBase
    {
        internal enum Type
        {
            Quadratic,
            Cubic
        }
        private Type BezierType = Type.Quadratic;

        public Transform[] GetAllPoints()
        {
            return _Points;
        }
        private Transform[] _Points;

        public Transform TryGetTransformFromPosition(Vector2 position)
        {
            if (_Points.Any(x => x.TryGetPosition(position))) return _Points.First(x => x.TryGetPosition(position));

            return null;
        }

        public Vector2 GetPoint(float t)
        {
            return BezierType == Type.Cubic ?
                Spline.GetCubicPoint(_Points[0].Position, _Points[1].Position, _Points[2].Position, _Points[3].Position, t) :
                Spline.GetQuadraticPoint(_Points[0].Position, _Points[1].Position, _Points[2].Position, t);
        }

        public Vector2 GetDirection(float t)
        {
            Vector2 direction = Vector2.Zero;

            if (BezierType == Type.Cubic) direction = Spline.GetCubicTangent(_Points[0].Position, _Points[1].Position, _Points[2].Position, _Points[3].Position, t);
            else direction = Spline.GetQuadraticTangent(_Points[0].Position, _Points[1].Position, _Points[2].Position, t);

            direction.Normalize();
            return direction;
        }

        public void DrawCurve(SpriteBatch spriteBatch)
        {
            if (!Setup.Initialized)
            {
                throw new Exception("You need to initialize the MonoGame.SplineFlower library first by calling ' MonoGame.SplineFlower.Setup.Initialize();'");
            }

            if (_Points.Length <= 1 || _Points.ToList().TrueForAll(x => x.Equals(Vector2.Zero))) return;

            float distance = 0, angle = 0;
            for (int i = 0; i < _Points.Length; i++)
            {
                if (i + 1 > _Points.Length - 1)
                {
                    DrawPoint(spriteBatch, _Points[i].Position, angle);
                    break;
                }

                distance = Vector2.Distance(_Points[i].Position, _Points[i + 1].Position);
                angle = (float)Math.Atan2(_Points[i + 1].Position.Y - _Points[i].Position.Y, _Points[i + 1].Position.X - _Points[i].Position.X);

                DrawLine(spriteBatch, _Points[i].Position, angle, distance, Setup.BaseLineColor, Setup.BaseLineThickness);
                DrawPoint(spriteBatch, _Points[i].Position, angle);
            }

            Vector2 lineStart = GetPoint(0f);
            for (int i = 1; i <= Setup.LineSteps; i++)
            {
                Vector2 lineEnd = GetPoint(i / (float)Setup.LineSteps);

                float distanceStep = Vector2.Distance(lineStart, lineEnd);
                float angleStep = (float)Math.Atan2(lineEnd.Y - lineStart.Y, lineEnd.X - lineStart.X);

                DrawLine(spriteBatch, lineStart, angleStep, distanceStep, Setup.CurveLineColor, Setup.CurveLineThickness);

                if (Setup.ShowDirectionVectors)
                {
                    DrawLine(spriteBatch, lineEnd + GetDirection(i / (float)Setup.LineSteps), angleStep,
                        Setup.DirectionLineLength, Setup.DirectionLineColor, Setup.DirectionLineThickness);
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

            _Points = new Transform[]
            {
                new Transform(new Vector2(0, 0)),
                new Transform(new Vector2(200, 0)),
                new Transform(new Vector2(200, 200))
            };

            CalculateSplineCenter(_Points);
        }

        public void CreateCubic()
        {
            BezierType = Type.Cubic;

            _Points = new Transform[]
            {
                new Transform(new Vector2(50, 50)),
                new Transform(new Vector2(300, 50)),
                new Transform(new Vector2(50, 300)),
                new Transform(new Vector2(300, 300))
            };

            CalculateSplineCenter(_Points);
        }
    }
}
