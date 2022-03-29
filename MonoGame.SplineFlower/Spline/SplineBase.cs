using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.SplineFlower.Content;
using MonoGame.SplineFlower.Spline.Types;
using MonoGame.SplineFlower.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonoGame.SplineFlower.Spline
{
    public abstract class SplineBase : PointBase
    {
        public SplineBase() { }
        public SplineBase(Transform[] points) : this()
        {
            if (this is BezierSpline && points.Length < 4) throw new Exception("You need at least 4 points to successfully create a Bezier-Spline.'");
            else if (this is CatMulRomSpline && points.Length < 4) throw new Exception("You need at least 4 points to successfully create a CatMulRom-Spline.'");
            else if (this is HermiteSpline && points.Length < 2) throw new Exception("You need at least 2 points to successfully create a Hermite-Spline.'");

            Array.Resize(ref _Points, points.Length);
            Array.Copy(points, _Points, _Points.Length);

            _Trigger = new List<Trigger>();

            RecalculateSpline();
        }

        private void RecalculateSpline()
        {
            CalculateIndex();
            CalculatePointModes();
            CalculateTransformNeighbours();
            CalculateSplineCenter(_Points);
        }

        private void CalculateIndex()
        {
            for (int i = 0; i < _Points.Length; i++)
            {
                _Points[i].Index = i;
            }
        }

        private void CalculatePointModes()
        {
            int modCounter = 0, modCount = 1;
            for (int i = 0; i < _Points.Length; i++)
            {
                if (modCounter < 2) modCounter++;
                else
                {
                    modCount++;
                    modCounter = 0;
                }
            }
            Array.Resize(ref _Modes, modCount);
        }

        private void CalculateTransformNeighbours()
        {
            for (int i = 0; i < _Points.Length; i++)
            {
                if (_Points[i].IsPoint)
                {
                    if (i - 1 < 0)
                    {
                        if (Loop)
                        {
                            _Points[i].Left = _Points[_Points.Length - 2];
                        }
                    }
                    else _Points[i].Left = _Points[i - 1];

                    if (i + 1 > _Points.Length - 1)
                    {
                        if (Loop)
                        {
                            _Points[i].Right = _Points[1];
                        }
                    }
                    else _Points[i].Right = _Points[i + 1];
                }
            }
        }

        public enum ControlPointMode
        {
            Free,
            Aligned,
            Mirrored
        }
        public ControlPointMode[] GetAllPointModes
        {
            get { return _Modes; }
            internal set { _Modes = value; }
        }
        private ControlPointMode[] _Modes;

        private static Color[] _ModeColors = {
            Setup.PointColor,
            Color.Yellow,
            Color.Cyan
        };

        public float MaxProgress()
        {
            float maxProgress = 0;

            if (IsHermite) maxProgress = 1f;
            else if (IsCatMulRom)
            {
                maxProgress = 1 + (_Points.Length - 4);
                if (_Loop) maxProgress += 3f;
            }
            else maxProgress = 1f;

            return maxProgress;
        }

        public bool Loop
        {
            get { return _Loop; }
            set
            {
                _Loop = value;
                if (value && !IsCatMulRom && _Modes != null)
                {
                    _Modes[_Modes.Length - 1] = _Modes[0];
                    SetControlPoint(_Points.Length - 1, _Points[0]);
                }
                CalculateTransformNeighbours();
            }
        }
        private bool _Loop;

        public bool IsBezier
        {
            get { return this is BezierSpline; }
        }

        public bool IsCatMulRom
        {
            get { return this is CatMulRomSpline; }
        }

        public bool IsHermite
        {
            get { return this is HermiteSpline; }
        }

        public bool IsChain { get; private set; }

        public int CurveCount
        {
            get
            {
                if (_Points != null)
                {
                    if (IsHermite) return _Points.Length - 1;
                    else if (IsCatMulRom) return Loop ? _Points.Length : _Points.Length - 3;
                    else return (_Points.Length - 1) / 3;
                }
                else return 0;
            }
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

        public ControlPointMode GetControlPointMode(int index)
        {
            return _Modes[(index + 1) / 3];
        }

        public void SetControlPointMode(int index, ControlPointMode mode)
        {
            if (index == Setup.CenterSplineIndex) return;

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

        public virtual void TranslateTransform(Transform point, Vector2 value)
        {
            if (point != null) point.Translate(value);
        }

        public virtual void TranslateSelectedTransform(Vector2 value)
        {
            if (SelectedTransform != null) SelectedTransform.Translate(value);
        }

        public virtual void TranslateAll(Vector2 amount)
        {
            // When the BezierSpline is a loop, we need to make sure
            // that we don't translate the Start and the End point (which are the same then) twice.
            // We do that by using the 'Distinct()' command.
            _Points.Distinct().ToList().ForEach(x => x.Translate(amount));

            CalculateSplineCenter(_Points);
        }

        public void Rotate(float amount)
        {
            _Points.Distinct().ToList().ForEach(
                    x =>
                    {
                        if (!x.Position.Equals(CenterSpline.Position))
                        {
                            x.SetPosition(Functions.RotateToPosition(
                            x.Position,
                        new Vector2(
                            CenterSpline.Position.X,
                            CenterSpline.Position.Y),
                        amount, 1f));
                        }
                    });
        }

        public void Scale(float amount)
        {
            _Points.Distinct().ToList().ForEach(
                    x =>
                    {
                        if (!x.Position.Equals(CenterSpline.Position))
                        {
                            x.SetPosition(Functions.RotateToPosition(
                            x.Position,
                        new Vector2(
                            CenterSpline.Position.X,
                            CenterSpline.Position.Y),
                        amount, 90f));
                        }
                    });
        }

        public void ScaleRotate(float amount)
        {
            _Points.Distinct().ToList().ForEach(
                    x =>
                    {
                        if (!x.Position.Equals(CenterSpline.Position))
                        {
                            x.SetPosition(Functions.RotateToPosition(
                                x.Position,
                            new Vector2(
                                CenterSpline.Position.X,
                                CenterSpline.Position.Y),
                            amount, 45f));
                        }
                    });
        }

        public void Position(Vector2 position)
        {
            Vector2 diff = CenterSpline.Position - position;
            TranslateAll(-diff);
        }

        public void MoveAxis(int index, Vector2 diff)
        {
            if (index == Setup.CenterSplineIndex) return;

            if (!IsCatMulRom && !IsHermite)
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
        }

        public void EnforceMode(int index)
        {
            if (index == Setup.CenterSplineIndex) return;

            int modeIndex = (index + 1) / 3;
            ControlPointMode mode = _Modes[modeIndex];
            if (mode == ControlPointMode.Free || !Loop && (modeIndex == 0 || modeIndex == _Modes.Length - 1))
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
            if (mode == ControlPointMode.Aligned)
            {
                enforcedTangent.Normalize();
                enforcedTangent *= Vector2.Distance(middle.Position, _Points[enforcedIndex].Position);
            }
            _Points[enforcedIndex].SetPosition(middle.Position + enforcedTangent);
        }

        public virtual Transform SelectTransform(Vector2 position)
        {
            CenterSpline.IsSelected = false;
            _Points.ToList().ForEach(x => x.IsSelected = false);
            if (SelectedTransform != null) SelectedTransform = null;

            if (CenterSpline.TryGetPosition(position)) SelectedTransform = CenterSpline;
            else if (_Points.Any(x => x.TryGetPosition(position))) SelectedTransform = _Points.First(x => x.TryGetPosition(position));

            if (SelectedTransform != null) SelectedTransform.IsSelected = true;

            return SelectedTransform;
        }

        public virtual Trigger SelectTrigger(Vector2 position)
        {
            Rectangle size = new Rectangle((int)position.X - 5, (int)position.Y - 5, 10, 10);
            if (_Trigger.Any(x => size.Contains(GetPoint(x.Progress))))
            {
                SelectedTrigger = _Trigger.First(x => size.Contains(GetPoint(x.Progress)));
            }
            return SelectedTrigger;
        }

        public void UpdateTriggerRotation()
        {
            GetAllTrigger.ForEach(x => x.UpdateTriggerRotation());
        }

        public Transform[] GetAllPoints
        {
            get { return _Points; }
            internal set { _Points = value; }
        }
        private Transform[] _Points;

        public List<Trigger> GetAllTrigger
        {
            get { return _Trigger; }
        }
        private List<Trigger> _Trigger = new List<Trigger>();

        internal event Action<Trigger> EventTriggered = delegate { };

        public Trigger SelectedTrigger { get; set; }
        public Transform SelectedTransform { get; set; }

        public abstract Vector2 GetPoint(float t);
        public abstract Vector2 GetDirection(float t);

        public Guid AddTrigger(string name, float progress, float triggerRange)
        {
            Guid triggerID = new Guid();
            _Trigger.Add(new Trigger(name, progress, triggerRange, out triggerID));
            _Trigger.Last().TriggerEvent += SplineBase_TriggerEvent;
            _Trigger.Last().GetDirectionOnSpline = GetDirection;
            _Trigger.Last().GetMaxProgress = MaxProgress;
            _Trigger.Last().UpdateTriggerRotation();

            ReorderTriggerList();

            return triggerID;
        }

        private void AddTrigger(string name, float progress, float triggerRange, string triggerID)
        {
            _Trigger.Add(new Trigger(name, progress, triggerRange, triggerID));
            _Trigger.Last().TriggerEvent += SplineBase_TriggerEvent;
            _Trigger.Last().GetDirectionOnSpline = GetDirection;
            _Trigger.Last().GetMaxProgress = MaxProgress;
            _Trigger.Last().UpdateTriggerRotation();
        }

        private void SplineBase_TriggerEvent(Trigger obj)
        {
            EventTriggered?.Invoke(obj);
        }

        public void ReorderTriggerList()
        {
            List<Trigger> ordered = _Trigger.OrderBy(x => x.GetPlainProgress).ToList();
            _Trigger = ordered;
        }

        public Vector2 Acceleration { get; set; }
        public Vector2 AccelerationMin { get; set; } = new Vector2(0.8f);
        public Vector2 AccelerationMax { get; set; } = new Vector2(1f);
        public float AccelerationDamping { get; set; } = 10f;
        public float PointDistance { get; set; }

        public void CreateChain(float pointDistance = 50, float pointSpeed = 1f)
        {
            IsChain = true;
            PointDistance = pointDistance;
            AccelerationMax = new Vector2(pointSpeed);

            SelectedTransform = _Points[0];
            UpdateChain();
        }

        private void UpdateChain(GameTime gameTime = null)
        {
            Transform middlePoint;

            if (SelectedTransform != null)
            {
                if (SelectedTransform.IsPoint) middlePoint = SelectedTransform;
                else middlePoint = _Points[0];

                if (middlePoint != null && middlePoint.Left != null) UpdateNeighbourRecursiveLeft(middlePoint, middlePoint.Left, gameTime);
                if (middlePoint != null && middlePoint.Right != null) UpdateNeighbourRecursiveRight(middlePoint, middlePoint.Right, gameTime);
            }
        }
        private void UpdateNeighbourRecursiveLeft(Transform middlePoint, Transform neighbour, GameTime gameTime)
        {
            if (neighbour != null)
            {
                if (neighbour.Left != null) UpdateNeighbourRecursiveLeft(neighbour, neighbour.Left, gameTime);

                UpdateNeighbour(middlePoint, neighbour, gameTime);
            }
        }
        private void UpdateNeighbourRecursiveRight(Transform middlePoint, Transform neighbour, GameTime gameTime)
        {
            if (neighbour != null)
            {
                if (neighbour.Right != null) UpdateNeighbourRecursiveRight(neighbour, neighbour.Right, gameTime);

                UpdateNeighbour(middlePoint, neighbour, gameTime);
            }
        }
        private void UpdateNeighbour(Transform middlePoint, Transform neighbour, GameTime gameTime)
        {
            float distance = Vector2.Distance(middlePoint.Position, neighbour.Position);

            if (distance > PointDistance)
            {
                DoTranslation(middlePoint, neighbour, gameTime, false);
            }
            else if (distance < PointDistance / 2f)
            {
                DoTranslation(middlePoint, neighbour, gameTime, true);
            }
        }
        private void DoTranslation(Transform middlePoint, Transform neighbour, GameTime gameTime, bool inverseDirection)
        {
            Vector2 direction = Vector2.Zero;
            Functions.GetRotation(neighbour.Position, middlePoint.Position, ref direction, inverseDirection);

            Vector2 absoluteAccerleration = new Vector2(Math.Abs(Acceleration.X), Math.Abs(Acceleration.Y));
            Vector2 acceleration = Vector2.Clamp(absoluteAccerleration / AccelerationDamping, AccelerationMin, AccelerationMax);

            if (gameTime != null) TranslateTransform(neighbour, direction * acceleration * gameTime.ElapsedGameTime.Milliseconds);
            else TranslateTransform(neighbour, direction * acceleration);
        }

        public Vector2 FindNearestPoint(Vector2 worldPos, float accuracy = 100f)
        {
            return FindNearestPoint(worldPos, out _, accuracy);
        }
        public Vector2 FindNearestPoint(Vector2 worldPos, out float normalizedT, float accuracy = 100f)
        {
            Vector2 result = Vector2.Zero;
            normalizedT = -1f;

            float step = AccuracyToStepSize(accuracy);

            float minDistance = float.PositiveInfinity;
            for (float i = 0f; i < MaxProgress(); i += step)
            {
                Vector2 thisPoint = GetPoint(i);
                float thisDistance = (worldPos - thisPoint).LengthSquared();
                if (thisDistance < minDistance)
                {
                    minDistance = thisDistance;
                    result = thisPoint;
                    normalizedT = i / MaxProgress();
                }
            }

            return result;
        }
        private float AccuracyToStepSize(float accuracy)
        {
            if (accuracy <= 0f) return 0.2f;

            return MathHelper.Clamp(1f / accuracy, 0.001f, 0.2f);
        }

        public virtual void AddCurveLeft() 
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

            RecalculateSpline();
        }
        public virtual void AddCurveRight() 
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

            RecalculateSpline();
        }

        public virtual void Reset()
        {
            if (_Points == null)
            {
                _Points = new Transform[]
                {
                    new Transform(new Vector2(0, 0)),
                    new Transform(new Vector2(250, 0)),
                    new Transform(new Vector2(0, 250)),
                    new Transform(new Vector2(250, 250))
                };
            }

            _Trigger = new List<Trigger>();

            RecalculateSpline();
        }

        public Texture2D PolygonStripeTexture
        {
            get { return _PolygonStripeTexture; }
            set
            {
                _PolygonStripeTexture = value;
                Functions.GetBasicEffect.Texture = value;
            }
        }
        private Texture2D _PolygonStripeTexture;
        private VertexBuffer _VertexBuffer;
        private IndexBuffer _IndexBuffer;
        private Vector3[] _Vertices;
        private short[] _Triangles;
        private VertexPositionColorTexture[] _PolygonStripe;

        public void RefreshPolygonStripe() => PolygonStripeCreated = false;
        public bool PolygonStripeCreated { get; set; } = false;
        public float PolygonStripeWidth { get; set; } = 64f;

        public void CreatePolygonStripe()
        {
            Setup.CheckInitialization();

            Transform[] points = new Transform[0];
            int pointCount;

            if (IsCatMulRom) pointCount = (Setup.LineSteps * CurveCount) + 1;
            else pointCount = Setup.LineSteps + 1;

            Array.Resize(ref points, pointCount);

            for (int i = 0; i <= pointCount - 1; i++)
            {
                points[i] = new Transform(GetPoint(i / (float)Setup.LineSteps));
            }

            _Vertices = new Vector3[points.Length * 2];
            Vector2[] UVS = new Vector2[_Vertices.Length];
            int numTris = 2 * (points.Length - 1) + (Loop ? 2 : 0);
            _Triangles = new short[numTris * 3];
            short verticesIndex = 0;
            int trianglesIndex = 0;

            for (int i = 0; i < points.Length; i++)
            {
                Vector2 forward = Vector2.Zero;
                if (i < points.Length - 1 || Loop)
                {
                    forward += points[(i + 1) % points.Length].Position - points[i].Position;
                }
                if (i > 0 || Loop)
                {
                    forward += points[i].Position - points[(i - 1 + points.Length) % points.Length].Position;
                }
                forward.Normalize();

                Vector2 left = new Vector2(-forward.Y, forward.X); //Swap X(default) & Y(inverse) to get the left side of the forward direction

                _Vertices[verticesIndex] = new Vector3(points[i].Position + left * PolygonStripeWidth * 0.5f, 0);
                _Vertices[verticesIndex + 1] = new Vector3(points[i].Position - left * PolygonStripeWidth * 0.5f, 0);

                float completionPercent = i / (float)(points.Length - 1);
                float v = 1 - Math.Abs(2 * completionPercent - 1);
                UVS[verticesIndex] = new Vector2(0, v);
                UVS[verticesIndex + 1] = new Vector2(1, v);

                if (i < points.Length - 1 || Loop)
                {
                    _Triangles[trianglesIndex] = verticesIndex;
                    _Triangles[trianglesIndex + 1] = (short)((verticesIndex + 2) % _Vertices.Length);
                    _Triangles[trianglesIndex + 2] = (short)(verticesIndex + 1);
                    _Triangles[trianglesIndex + 3] = (short)(verticesIndex + 1);
                    _Triangles[trianglesIndex + 4] = (short)((verticesIndex + 2) % _Vertices.Length);
                    _Triangles[trianglesIndex + 5] = (short)((verticesIndex + 3) % _Vertices.Length);
                }

                verticesIndex += 2;
                trianglesIndex += 6;
            }

            _PolygonStripe = new VertexPositionColorTexture[_Vertices.Length];
            for (int i = 0; i < _Vertices.Length; i++)
            {
                _PolygonStripe[i].Position = new Vector3(_Vertices[i].X, _Vertices[i].Y, 0);
                _PolygonStripe[i].TextureCoordinate = UVS[i];
                _PolygonStripe[i].Color = Color.White;
            }

            _VertexBuffer = new VertexBuffer(Functions.graphics, typeof(VertexPositionColorTexture), _PolygonStripe.Length, BufferUsage.WriteOnly);
            _VertexBuffer.SetData(_PolygonStripe);

            _IndexBuffer = new IndexBuffer(Functions.graphics, typeof(short), _Triangles.Length, BufferUsage.WriteOnly);
            _IndexBuffer.SetData(_Triangles);

            PolygonStripeCreated = true;
        }

        public void DrawPolygonStripe()
        {
            if (Setup.ShowPolygonStripe)
            {
                Setup.CheckInitialization();

                if (PolygonStripeCreated && _PolygonStripe != null && _PolygonStripe.Length > 0)
                {
                    Functions.graphics.BlendState = BlendState.Opaque;
                    Functions.graphics.DepthStencilState = DepthStencilState.Default;
                    Functions.graphics.RasterizerState = Functions.RasterizerState;

                    foreach (var pass in Functions.GetBasicEffect.CurrentTechnique.Passes)
                    {
                        pass.Apply();

                        Functions.graphics.SetVertexBuffer(_VertexBuffer);
                        Functions.graphics.Indices = _IndexBuffer;

                        Functions.graphics.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, _Vertices.Length);
                    }
                }
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            if (IsChain) UpdateChain(gameTime);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (Setup.ShowSpline)
            {
                Setup.CheckInitialization();

                if (_Points.Length <= 1 || _Points.ToList().TrueForAll(x => x.Equals(Vector2.Zero))) return;

                if (Setup.ShowBaseLine)
                {
                    float distance = 0, angle = 0;
                    for (int i = 0; i < _Points.Length; i++)
                    {
                        if (i + 1 > _Points.Length - 1)
                        {
                            if (Setup.ShowPoints) DrawPoint(spriteBatch, _Points[i].Position, i, angle, null);
                            break;
                        }

                        distance = Vector2.Distance(_Points[i].Position, _Points[i + 1].Position);
                        angle = (float)Math.Atan2(_Points[i + 1].Position.Y - _Points[i].Position.Y, _Points[i + 1].Position.X - _Points[i].Position.X);

                        if (Setup.ShowLines) DrawLine(spriteBatch, _Points[i].Position, angle, distance, Setup.BaseLineColor, Setup.BaseLineThickness);
                        if (Setup.ShowPoints)
                        {
                            DrawPoint(spriteBatch, _Points[i].Position, i, angle, null);

                            #region DEBUG
                            //Transform.Size (clickable center)
                            //DrawPoint(spriteBatch, _Points[i].Size.Center.ToVector2(), i, angle, Color.GreenYellow, Setup.PointThickness / 2f);

                            //angle between points
                            //DrawLine(spriteBatch, _Points[i].Position, angle, 20, Color.GreenYellow, 2f);
                            #endregion
                        }
                    }
                }

                if (Setup.ShowCurves)
                {
                    Vector2 lastPos = GetPoint(0);

                    if (IsHermite)
                    {
                        for (float t = 0f; t < 1f; t += Setup.SplineStepDistance)
                        {
                            Vector2 pos = GetPoint(t);

                            float distanceStep = Vector2.Distance(pos, lastPos);
                            float angleStep = (float)Math.Atan2(lastPos.Y - pos.Y, lastPos.X - pos.X);

                            DrawLine(spriteBatch, lastPos, angleStep, distanceStep, Setup.CurveLineColor, Setup.CurveLineThickness);

                            if (Setup.ShowDirectionVectors)
                            {
                                if ((int)Math.Round(t * Setup.SplineMarkerResolution, 0) % (Setup.LineSteps / 4f) == 0)
                                {
                                    DrawLine(spriteBatch, lastPos + GetDirection(t).Normal(), angleStep + MathHelper.ToRadians(180),
                                        Setup.DirectionLineLength, Setup.DirectionLineColor, Setup.DirectionLineThickness);
                                }
                            }

                            lastPos = pos;
                        }
                    }
                    else if (IsCatMulRom)
                    {
                        for (float t = 0; t < _Points.Length - (_Loop ? 0 : 3f); t += Setup.SplineStepDistance)
                        {
                            Vector2 pos = GetPoint(t);

                            float distanceStep = Vector2.Distance(pos, lastPos);
                            float angleStep = (float)Math.Atan2(lastPos.Y - pos.Y, lastPos.X - pos.X);

                            DrawLine(spriteBatch, lastPos, angleStep, distanceStep, Setup.CurveLineColor, Setup.CurveLineThickness);

                            if (Setup.ShowDirectionVectors)
                            {
                                if ((int)Math.Round(t * Setup.SplineMarkerResolution, 0) % Setup.LineSteps == 0)
                                {
                                    DrawLine(spriteBatch, lastPos + GetDirection(t).Normal(), angleStep + MathHelper.ToRadians(180),
                                        Setup.DirectionLineLength, Setup.DirectionLineColor, Setup.DirectionLineThickness);
                                }
                            }

                            lastPos = pos;
                        }
                    }
                    else
                    {
                        Vector2 lineStart = GetPoint(0f);
                        for (int j = 0; j < CurveCount; j++)
                        {
                            for (int i = 1; i <= Setup.LineSteps; i++)
                            {
                                Vector2 lineEnd = GetPoint(i / (float)Setup.LineSteps);

                                float distanceStep = Vector2.Distance(lineStart, lineEnd);
                                float angleStep = (float)Math.Atan2(lineEnd.Y - lineStart.Y, lineEnd.X - lineStart.X);

                                DrawLine(spriteBatch, lineStart, angleStep, distanceStep, Setup.CurveLineColor, Setup.CurveLineThickness);

                                if (Setup.ShowDirectionVectors)
                                {
                                    DrawLine(spriteBatch, lineEnd + GetDirection(i / (float)Setup.LineSteps).Normal(), angleStep,
                                        Setup.DirectionLineLength, Setup.DirectionLineColor, Setup.DirectionLineThickness);
                                }

                                lineStart = lineEnd;
                            }
                        }
                    }
                }

                if (Setup.ShowTriggers)
                {
                    for (int i = 0; i < _Trigger.Count; i++)
                    {
                        float drawDistanceBack = _Trigger[i].Progress - _Trigger[i].TriggerRange;
                        for (float x = drawDistanceBack; x < _Trigger[i].Progress; x += 1 / Setup.SplineMarkerResolution)
                        {
                            DrawPointOnCurve(spriteBatch, x);
                        }

                        float drawDistanceForth = _Trigger[i].Progress + _Trigger[i].TriggerRange;
                        for (float x = drawDistanceForth; x > _Trigger[i].Progress; x -= 1 / Setup.SplineMarkerResolution)
                        {
                            DrawPointOnCurve(spriteBatch, x);
                        }

                        DrawCircle(spriteBatch, _Trigger[i].Progress);
                    }
                }
                if (Setup.ShowCenterSpline) DrawCircle(spriteBatch, CenterSpline.Position, Setup.CenterSplineColor);
            }
        }

        protected void DrawLine(SpriteBatch spriteBatch, Vector2 position, float angle, float distance, Color color, float thickness)
        {
            spriteBatch.Draw(Setup.Pixel,
                             position,
                             null,
                             color,
                             angle,
                             Vector2.Zero,
                             new Vector2(distance, thickness),
                             SpriteEffects.None,
                             0f);
        }

        protected void DrawPoint(SpriteBatch spriteBatch, Vector2 position, int index, float angle, Color? color, float thickness = -1f)
        {
            spriteBatch.Draw(Setup.Pixel,
                             position,
                             null,
                             color ?? (index == 0 ? Setup.StartPointColor : _ModeColors[(int)GetControlPointMode(index)]),
                             angle,
                             new Vector2(0.5f),
                             thickness > 0f ? thickness : Setup.PointThickness * (index == 0 ? Setup.StartPointThickness : 1f),
                             SpriteEffects.None,
                             0f);
        }

        protected void DrawPointOnCurve(SpriteBatch spriteBatch, float position)
        {
            spriteBatch.Draw(Setup.Pixel,
                             GetPoint(position),
                             null,
                             Setup.TriggerEventColor,
                             0f,
                             new Vector2(0.5f),
                             1f,
                             SpriteEffects.None,
                             0f);
        }

        protected void DrawCircle(SpriteBatch spriteBatch, float position)
        {
            spriteBatch.Draw(Setup.Circle,
                             GetPoint(position),
                             null,
                             Setup.TriggerEventColor,
                             0,
                             new Vector2(Setup.Circle.Width / 2, Setup.Circle.Height / 2),
                             Setup.TriggerEventThickness,
                             SpriteEffects.None,
                             0f);
        }

        protected void DrawCircle(SpriteBatch spriteBatch, Vector2 position, Color color)
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

        public void LoadJsonSplineData(
            TransformDummy[] pointData,
            ControlPointModeDummy[] pointModeData,
            TriggerDummy[] triggerData,
            TransformDummy[] tangentData,
            out Trigger[] loadedTrigger)
        {
            LoadSplineData(
                LoadJsonPointData(pointData), 
                LoadJsonPointModeData(pointModeData), 
                LoadJsonTriggerData(triggerData), 
                LoadJsonTangentData(tangentData));

            loadedTrigger = _Trigger.ToArray();
        }
        public void LoadJsonSplineData(
            TransformDummy[] pointData,
            ControlPointModeDummy[] pointModeData,
            TriggerDummy[] triggerData,
            TransformDummy[] tangentData)
        {
            LoadSplineData(
                LoadJsonPointData(pointData),
                LoadJsonPointModeData(pointModeData),
                LoadJsonTriggerData(triggerData),
                LoadJsonTangentData(tangentData));
        }
        public virtual void LoadSplineData(
            Transform[] points,
            ControlPointMode[] modes,
            Trigger[] trigger,
            Transform[] tangents = null)
        {
            _Points = null;
            Array.Resize(ref _Points, points.Length);
            points.CopyTo(_Points, 0);

            _Modes = null;
            Array.Resize(ref _Modes, modes.Length);
            modes.CopyTo(_Modes, 0);

            _Trigger = null;
            _Trigger = new List<Trigger>();
            for (int i = 0; i < trigger.Length; i++)
            {
                AddTrigger(trigger[i].Name, trigger[i].GetPlainProgress, trigger[i].TriggerRange * Setup.SplineMarkerResolution, trigger[i].ID.ToString());
            }

            CalculateSplineCenter(_Points);
        }
        private Transform[] LoadJsonPointData(TransformDummy[] pointData)
        {
            Transform[] points = new Transform[pointData.Length];

            for (int i = 0; i < pointData.Length; i++)
            {
                points[i] = new Transform(pointData[i].Position);
            }

            CalculateIndex();

            return points;
        }
        private ControlPointMode[] LoadJsonPointModeData(ControlPointModeDummy[] pointModeData)
        {
            ControlPointMode[] modePoints = new ControlPointMode[pointModeData.Length];

            for (int i = 0; i < pointModeData.Length; i++)
            {
                modePoints[i] = (ControlPointMode)Enum.Parse(typeof(ControlPointMode), pointModeData[i].Mode);
            }

            return modePoints;
        }
        private Trigger[] LoadJsonTriggerData(TriggerDummy[] triggerData)
        {
            Trigger[] trigger = new Trigger[triggerData.Length];

            for (int i = 0; i < triggerData.Length; i++)
            {
                trigger[i] = new Trigger(
                    triggerData[i].Name,
                    triggerData[i].Progress,
                    triggerData[i].TriggerRange,
                    triggerData[i].ID);
            }

            return trigger;
        }
        private Transform[] LoadJsonTangentData(TransformDummy[] tangentData)
        {
            if (tangentData != null)
            {
                Transform[] tangents = new Transform[tangentData.Length];

                for (int i = 0; i < tangentData.Length; i++)
                {
                    tangents[i] = new Transform(tangentData[i].Position)
                    {
                        Index = tangentData[i].Index,
                        GetTransformType = Transform.TransformType.Tangent,
                        UserData = tangentData[i].UserData as HermiteSpline.TangentData
                    };
                }

                return tangents;
            }
            else return null;
        }
    }
}
