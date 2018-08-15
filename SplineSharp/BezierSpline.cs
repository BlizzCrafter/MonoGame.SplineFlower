using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;

namespace SplineSharp
{
    public class BezierSpline
    {
        public enum BezierControlPointMode
        {
            Free,
            Aligned,
            Mirrored
        }
        private BezierControlPointMode[] modes;

        private static Color[] modeColors = {
            Setup.PointColor,
            Color.Yellow,
            Color.Cyan
        };

        private const int LineSteps = 20;

        private Transform[] points;

        public bool Loop
        {
            get { return _Loop; }
            set
            {
                _Loop = value;
                if (value)
                {
                    modes[modes.Length - 1] = modes[0];
                    SetControlPoint(points.Length -1, points[0]);
                }
            }
        }
        private bool _Loop;

        private int CurveCount
        {
            get { return (points.Length - 1) / 3; }
        }

        public int ControlPointCount
        {
            get { return points.Length; }
        }

        public Transform GetControlPoint(int index)
        {
            return points[index];
        }

        public void SetControlPoint(int index, Transform point)
        {
            points[index] = point;
            EnforceMode(index);
        }

        public BezierControlPointMode GetControlPointMode(int index)
        {
            return modes[(index + 1) / 3];
        }

        public void SetControlPointMode(int index, BezierControlPointMode mode)
        {
            int modeIndex = (index + 1) / 3;
            modes[modeIndex] = mode;
            if (_Loop)
            {
                if (modeIndex == 0)
                {
                    modes[modes.Length - 1] = mode;
                }
                else if (modeIndex == modes.Length - 1)
                {
                    modes[0] = mode;
                }
            }
            EnforceMode(index);
        }

        public void MoveAxis(int index, Vector2 diff)
        {
            if (Setup.MovePointAxis)
            {
                if (index % 3 == 0)
                {
                    if (_Loop)
                    {
                        if (index == 0)
                        {
                            points[1].Translate(diff);
                            points[points.Length - 2].Translate(diff);
                            points[points.Length - 1] = points[0];
                        }
                        else if (index == points.Length - 1)
                        {
                            points[0] = points[points.Length - 1];
                            points[1].Translate(diff);
                            points[index - 1].Translate(diff);
                        }
                        else
                        {
                            points[index - 1].Translate(diff);
                            points[index + 1].Translate(diff);
                        }
                    }
                    else
                    {
                        if (index > 0)
                        {
                            points[index - 1].Translate(diff);
                        }
                        if (index + 1 < points.Length)
                        {
                            points[index + 1].Translate(diff);
                        }
                    }
                }
            }
        }

        public void EnforceMode(int index)
        {
            int modeIndex = (index + 1) / 3;
            BezierControlPointMode mode = modes[modeIndex];
            if (mode == BezierControlPointMode.Free || !Loop && (modeIndex == 0 || modeIndex == modes.Length - 1))
            {
                return;
            }

            int middleIndex = modeIndex * 3;
            int fixedIndex, enforcedIndex;
            if (index <= middleIndex)
            {
                fixedIndex = middleIndex - 1;
                if (fixedIndex < 0)
                {
                    fixedIndex = points.Length - 2;
                }
                enforcedIndex = middleIndex + 1;
                if (enforcedIndex >= points.Length)
                {
                    enforcedIndex = 1;
                }
            }
            else
            {
                fixedIndex = middleIndex + 1;
                if (fixedIndex >= points.Length)
                {
                    fixedIndex = 1;
                }
                enforcedIndex = middleIndex - 1;
                if (enforcedIndex < 0)
                {
                    enforcedIndex = points.Length - 2;
                }
            }

            Transform middle = points[middleIndex];
            Vector2 enforcedTangent = middle.Position - points[fixedIndex].Position;
            if (mode == BezierControlPointMode.Aligned)
            {
                enforcedTangent.Normalize();
                enforcedTangent *= Vector2.Distance(middle.Position, points[enforcedIndex].Position);
            }
            points[enforcedIndex].SetPosition(middle.Position + enforcedTangent);
        }

        public Transform TryGetTransformFromPosition(Vector2 position)
        {
            if (points.Any(x => x.TryGetPosition(position))) return points.First(x => x.TryGetPosition(position));

            return null;
        }

        public Vector2 GetPoint(float t, int curveIndex)
        {
            return Bezier.GetPoint(
                points[0 + (curveIndex * 3)].Position, 
                points[1 + (curveIndex * 3)].Position, 
                points[2 + (curveIndex * 3)].Position, 
                points[3 + (curveIndex * 3)].Position, t);
        }

        public Vector2 GetPointWalker(float t)
        {
            int i;
            if (t >= 1f)
            {
                t = 1f;
                i = points.Length - 4;
            }
            else
            {
                t = MathHelper.Clamp(t, 0f, 1f) * CurveCount;
                i = (int)t;
                t -= i;
                i *= 3;
            }
            return Bezier.GetPoint(points[i].Position, points[i + 1].Position, points[i + 2].Position, points[i + 3].Position, t);
        }

        public Vector2 GetVelocity(float t)
        {
            Vector2 Velocity = Vector2.Zero;

            Velocity = Bezier.GetFirstDerivative(points[0].Position, points[1].Position, points[2].Position, points[3].Position, t);
            Velocity.Normalize();
            return Velocity;
        }

        public Vector2 GetVelocityWalker(float t)
        {
            int i;
            if (t >= 1f)
            {
                t = 1f;
                i = points.Length - 4;
            }
            else
            {
                t = MathHelper.Clamp(t, 0f, 1f) * CurveCount;
                i = (int)t;
                t -= i;
                i *= 3;
            }
            return Bezier.GetFirstDerivative(points[i].Position, points[i + 1].Position, points[i + 2].Position, points[i + 3].Position, t);
        }

        public void AddCurveLeft()
        {
            Transform point = points[points.Length - 1];
            Array.Resize(ref points, points.Length + 3);
            
            points[points.Length - 3] = new Transform(new Vector2(point.Position.X + 40f, point.Position.Y - 0f));            
            points[points.Length - 2] = new Transform(new Vector2(point.Position.X + 40f, point.Position.Y - 80f));            
            points[points.Length - 1] = new Transform(new Vector2(point.Position.X + 0f, point.Position.Y - 80f));

            Array.Resize(ref modes, modes.Length + 1);
            modes[modes.Length - 1] = modes[modes.Length - 2];
            EnforceMode(points.Length - 4);

            if (_Loop)
            {
                points[points.Length - 1] = points[0];
                modes[modes.Length - 1] = modes[0];
                EnforceMode(0);
            }
        }

        public void AddCurveRight()
        {
            Transform point = points[points.Length - 1];
            Array.Resize(ref points, points.Length + 3);

            points[points.Length - 3] = new Transform(new Vector2(point.Position.X - 40f, point.Position.Y - 0f));
            points[points.Length - 2] = new Transform(new Vector2(point.Position.X - 40f, point.Position.Y - 80f));
            points[points.Length - 1] = new Transform(new Vector2(point.Position.X - 0f, point.Position.Y - 80f));

            Array.Resize(ref modes, modes.Length + 1);
            modes[modes.Length - 1] = modes[modes.Length - 2];
            EnforceMode(points.Length - 4);

            if (_Loop)
            {
                points[points.Length - 1] = points[0];
                modes[modes.Length - 1] = modes[0];
                EnforceMode(0);
            }
        }

        public void DrawSpline(SpriteBatch spriteBatch)
        {
            if (Setup.Pixel == null)
            {
                throw new Exception("You need to initialize the SplineSharp library first by calling 'SplineSharp.Setup.Initialize();'");
            }

            if (points.Length <= 1 || points.ToList().TrueForAll(x => x.Equals(Vector2.Zero))) return;

            float distance = 0, angle = 0;
            for (int i = 0; i < points.Length; i++)
            {
                points[i].Index = i;

                if (i + 1 > points.Length - 1)
                {
                    DrawPoint(spriteBatch, i, angle);
                    break;
                }

                distance = Vector2.Distance(points[i].Position, points[i + 1].Position);
                angle = (float)Math.Atan2(points[i + 1].Position.Y - points[i].Position.Y, points[i + 1].Position.X - points[i].Position.X);

                DrawLine(spriteBatch, points[i].Position, angle, distance, Setup.BaseLineColor, Setup.BaseLineThickness);
                DrawPoint(spriteBatch, i, angle);
            }

            Vector2 lineStart = GetPoint(0f, 0);
            for (int j = 0; j < CurveCount; j++)
            {
                for (int i = 1; i <= LineSteps; i++)
                {
                    Vector2 lineEnd = GetPoint(i / (float)LineSteps, j);

                    float distanceStep = Vector2.Distance(lineStart, lineEnd);
                    float angleStep = (float)Math.Atan2(lineEnd.Y - lineStart.Y, lineEnd.X - lineStart.X);

                    DrawLine(spriteBatch, lineStart, angleStep, distanceStep, Setup.CurveLineColor, Setup.CurveLineThickness);

                    if (Setup.ShowVelocityVectors)
                    {
                        DrawLine(spriteBatch, lineEnd + GetVelocity(i / (float)LineSteps), angleStep,
                            Setup.VelocityLineLength, Setup.VelocityLineColor, Setup.VelocityLineThickness);
                    }

                    lineStart = lineEnd;
                }
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

        private void DrawPoint(SpriteBatch spriteBatch, int index, float angle)
        {
            spriteBatch.Draw(Setup.Pixel,
                             points[index].Position,
                             null,
                             (index == 0 ? Setup.StartPointColor : modeColors[(int)GetControlPointMode(index)]),
                             angle,
                             new Vector2(0.5f),
                             Setup.PointThickness * (index == 0 ? Setup.StartPointThickness : 1f),
                             SpriteEffects.None,
                             0f);
        }


        public void Reset()
        {
            points = new Transform[]
            {
                new Transform(new Vector2(50, 50)),
                new Transform(new Vector2(300, 50)),
                new Transform(new Vector2(50, 300)),
                new Transform(new Vector2(300, 300))
            };

            modes = new BezierControlPointMode[] {
                BezierControlPointMode.Free,
                BezierControlPointMode.Free
            };
        }
    }
}
