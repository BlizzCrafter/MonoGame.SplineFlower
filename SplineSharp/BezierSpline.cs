using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SplineSharp
{
    public class BezierSpline : PointBase
    {
        public enum BezierControlPointMode
        {
            Free,
            Aligned,
            Mirrored
        }
        private BezierControlPointMode[] _Modes;

        private static Color[] _ModeColors = {
            Setup.PointColor,
            Color.Yellow,
            Color.Cyan
        };

        private const int LineSteps = 20;
                
        public Transform[] GetAllPoints()
        {
            return _Points;
        }
        private Transform[] _Points;

        internal List<Trigger> GetAllTrigger()
        {
            return _Trigger;
        }
        private List<Trigger> _Trigger = new List<Trigger>();

        public event Action<string> EventTriggered = delegate { };

        public Guid AddTrigger(string name, float progress)
        {
            _Trigger.Add(new Trigger(name, progress));
            _Trigger.Last().TriggerEvent += BezierSpline_TriggerEvent;
            _Trigger.OrderBy(x => x.Progress);

            return _Trigger.Last().ID;
        }
        private void BezierSpline_TriggerEvent(string obj)
        {
            EventTriggered?.Invoke(obj);
        }

        public bool Loop
        {
            get { return _Loop; }
            set
            {
                _Loop = value;
                if (value)
                {
                    _Modes[_Modes.Length - 1] = _Modes[0];
                    SetControlPoint(_Points.Length -1, _Points[0]);
                }
            }
        }
        private bool _Loop;

        public int CurveCount
        {
            get { return (_Points.Length - 1) / 3; }
        }

        public int ControlPointCount
        {
            get { return _Points.Length; }
        }

        public Transform GetControlPoint(int index)
        {
            return _Points[index];
        }

        public void SetControlPoint(int index, Transform point)
        {
            _Points[index] = point;
            EnforceMode(index);
        }

        public BezierControlPointMode GetControlPointMode(int index)
        {
            return _Modes[(index + 1) / 3];
        }

        public void SetControlPointMode(int index, BezierControlPointMode mode)
        {
            int modeIndex = (index + 1) / 3;
            _Modes[modeIndex] = mode;
            if (_Loop)
            {
                if (modeIndex == 0)
                {
                    _Modes[_Modes.Length - 1] = mode;
                }
                else if (modeIndex == _Modes.Length - 1)
                {
                    _Modes[0] = mode;
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
                            _Points[1].Translate(diff);
                            _Points[_Points.Length - 2].Translate(diff);
                            _Points[_Points.Length - 1] = _Points[0];
                        }
                        else if (index == _Points.Length - 1)
                        {
                            _Points[0] = _Points[_Points.Length - 1];
                            _Points[1].Translate(diff);
                            _Points[index - 1].Translate(diff);
                        }
                        else
                        {
                            _Points[index - 1].Translate(diff);
                            _Points[index + 1].Translate(diff);
                        }
                    }
                    else
                    {
                        if (index > 0)
                        {
                            _Points[index - 1].Translate(diff);
                        }
                        if (index + 1 < _Points.Length)
                        {
                            _Points[index + 1].Translate(diff);
                        }
                    }
                }
            }
        }

        public void EnforceMode(int index)
        {
            int modeIndex = (index + 1) / 3;
            BezierControlPointMode mode = _Modes[modeIndex];
            if (mode == BezierControlPointMode.Free || !Loop && (modeIndex == 0 || modeIndex == _Modes.Length - 1))
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
                    fixedIndex = _Points.Length - 2;
                }
                enforcedIndex = middleIndex + 1;
                if (enforcedIndex >= _Points.Length)
                {
                    enforcedIndex = 1;
                }
            }
            else
            {
                fixedIndex = middleIndex + 1;
                if (fixedIndex >= _Points.Length)
                {
                    fixedIndex = 1;
                }
                enforcedIndex = middleIndex - 1;
                if (enforcedIndex < 0)
                {
                    enforcedIndex = _Points.Length - 2;
                }
            }

            Transform middle = _Points[middleIndex];
            Vector2 enforcedTangent = middle.Position - _Points[fixedIndex].Position;
            if (mode == BezierControlPointMode.Aligned)
            {
                enforcedTangent.Normalize();
                enforcedTangent *= Vector2.Distance(middle.Position, _Points[enforcedIndex].Position);
            }
            _Points[enforcedIndex].SetPosition(middle.Position + enforcedTangent);
        }

        public Transform TryGetTransformFromPosition(Vector2 position)
        {
            if (_Points.Any(x => x.TryGetPosition(position))) return _Points.First(x => x.TryGetPosition(position));

            return null;
        }        

        public Vector2 GetPoint(float t)
        {
            int i;
            if (t >= 1f)
            {
                t = 1f;
                i = _Points.Length - 4;
            }
            else
            {
                t = MathHelper.Clamp(t, 0f, 1f) * CurveCount;
                i = (int)t;
                t -= i;
                i *= 3;
            }
            return Bezier.GetPoint(_Points[i].Position, _Points[i + 1].Position, _Points[i + 2].Position, _Points[i + 3].Position, t);
        }
        private Vector2 GetPointIntern(float t, int curveIndex)
        {
            return Bezier.GetPoint(
                _Points[0 + (curveIndex * 3)].Position,
                _Points[1 + (curveIndex * 3)].Position,
                _Points[2 + (curveIndex * 3)].Position,
                _Points[3 + (curveIndex * 3)].Position, t);
        }

        public Vector2 GetDirection(float t)
        {
            int i;
            if (t >= 1f)
            {
                t = 1f;
                i = _Points.Length - 4;
            }
            else
            {
                t = MathHelper.Clamp(t, 0f, 1f) * CurveCount;
                i = (int)t;
                t -= i;
                i *= 3;
            }
            return Bezier.GetFirstDerivative(_Points[i].Position, _Points[i + 1].Position, _Points[i + 2].Position, _Points[i + 3].Position, t);
        }
        private Vector2 GetDirectionIntern(float t)
        {
            Vector2 direction = Vector2.Zero;

            direction = Bezier.GetFirstDerivative(_Points[0].Position, _Points[1].Position, _Points[2].Position, _Points[3].Position, t);
            direction.Normalize();
            return direction;
        }

        public void AddCurveLeft()
        {
            Transform point = _Points[_Points.Length - 1];
            Array.Resize(ref _Points, _Points.Length + 3);
            
            _Points[_Points.Length - 3] = new Transform(new Vector2(point.Position.X + 40f, point.Position.Y - 0f));            
            _Points[_Points.Length - 2] = new Transform(new Vector2(point.Position.X + 40f, point.Position.Y - 80f));            
            _Points[_Points.Length - 1] = new Transform(new Vector2(point.Position.X + 0f, point.Position.Y - 80f));

            Array.Resize(ref _Modes, _Modes.Length + 1);
            _Modes[_Modes.Length - 1] = _Modes[_Modes.Length - 2];
            EnforceMode(_Points.Length - 4);

            if (_Loop)
            {
                _Points[_Points.Length - 1] = _Points[0];
                _Modes[_Modes.Length - 1] = _Modes[0];
                EnforceMode(0);
            }

            CalculateBezierCenter(_Points);
        }

        public void AddCurveRight()
        {
            Transform point = _Points[_Points.Length - 1];
            Array.Resize(ref _Points, _Points.Length + 3);

            _Points[_Points.Length - 3] = new Transform(new Vector2(point.Position.X - 40f, point.Position.Y - 0f));
            _Points[_Points.Length - 2] = new Transform(new Vector2(point.Position.X - 40f, point.Position.Y - 80f));
            _Points[_Points.Length - 1] = new Transform(new Vector2(point.Position.X - 0f, point.Position.Y - 80f));

            Array.Resize(ref _Modes, _Modes.Length + 1);
            _Modes[_Modes.Length - 1] = _Modes[_Modes.Length - 2];
            EnforceMode(_Points.Length - 4);

            if (_Loop)
            {
                _Points[_Points.Length - 1] = _Points[0];
                _Modes[_Modes.Length - 1] = _Modes[0];
                EnforceMode(0);
            }

            CalculateBezierCenter(_Points);
        }

        public void DrawSpline(SpriteBatch spriteBatch)
        {
            if (Setup.Pixel == null)
            {
                throw new Exception("You need to initialize the SplineSharp library first by calling 'SplineSharp.Setup.Initialize();'");
            }

            if (_Points.Length <= 1 || _Points.ToList().TrueForAll(x => x.Equals(Vector2.Zero))) return;

            float distance = 0, angle = 0;
            for (int i = 0; i < _Points.Length; i++)
            {
                _Points[i].Index = i;

                if (i + 1 > _Points.Length - 1)
                {
                    DrawPoint(spriteBatch, i, angle);
                    break;
                }

                distance = Vector2.Distance(_Points[i].Position, _Points[i + 1].Position);
                angle = (float)Math.Atan2(_Points[i + 1].Position.Y - _Points[i].Position.Y, _Points[i + 1].Position.X - _Points[i].Position.X);

                DrawLine(spriteBatch, _Points[i].Position, angle, distance, Setup.BaseLineColor, Setup.BaseLineThickness);
                DrawPoint(spriteBatch, i, angle);
            }

            Vector2 lineStart = GetPointIntern(0f, 0);
            for (int j = 0; j < CurveCount; j++)
            {
                for (int i = 1; i <= LineSteps; i++)
                {
                    Vector2 lineEnd = GetPointIntern(i / (float)LineSteps, j);

                    float distanceStep = Vector2.Distance(lineStart, lineEnd);
                    float angleStep = (float)Math.Atan2(lineEnd.Y - lineStart.Y, lineEnd.X - lineStart.X);

                    DrawLine(spriteBatch, lineStart, angleStep, distanceStep, Setup.CurveLineColor, Setup.CurveLineThickness);

                    if (Setup.ShowDirectionVectors)
                    {
                        DrawLine(spriteBatch, lineEnd + GetDirectionIntern(i / (float)LineSteps), angleStep,
                            Setup.DirectionLineLength, Setup.DirectionLineColor, Setup.DirectionLineThickness);
                    }

                    lineStart = lineEnd;
                }
            }

            for (int i = 0; i < _Trigger.Count; i++)
            {
                DrawCircle(spriteBatch, _Trigger[i].Progress);
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
                             _Points[index].Position,
                             null,
                             (index == 0 ? Setup.StartPointColor : _ModeColors[(int)GetControlPointMode(index)]),
                             angle,
                             new Vector2(0.5f),
                             Setup.PointThickness * (index == 0 ? Setup.StartPointThickness : 1f),
                             SpriteEffects.None,
                             0f);
        }

        private void DrawCircle(SpriteBatch spriteBatch, float position)
        {
            spriteBatch.Draw(Setup.Circle,
                             GetPoint(position),
                             null,
                             Color.Magenta,
                             0,
                             new Vector2(Setup.Circle.Width / 2, Setup.Circle.Height / 2),
                             1f,
                             SpriteEffects.None,
                             0f);
        }


        public void Reset()
        {
            _Points = new Transform[]
            {
                new Transform(new Vector2(0, 0)),
                new Transform(new Vector2(250, 0)),
                new Transform(new Vector2(0, 250)),
                new Transform(new Vector2(250, 250))
            };

            CalculateBezierCenter(_Points);

            _Modes = new BezierControlPointMode[] {
                BezierControlPointMode.Free,
                BezierControlPointMode.Free
            };
        }
    }
}
