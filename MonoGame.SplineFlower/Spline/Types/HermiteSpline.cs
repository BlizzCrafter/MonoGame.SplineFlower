using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.SplineFlower.Content;
using System;
using System.Linq;

namespace MonoGame.SplineFlower.Spline.Types
{
    public class HermiteSpline : SplineBase
    {
        public class TangentData
        {
            public float Bias { get; set; }
            public float Tension { get; set; }
        }

        public HermiteSpline() : base()
        {
            Reset();
        }
        public HermiteSpline(Transform[] points) : base(points) 
        {
            CreateTangents();
        }

        public Transform[] GetAllTangents
        {
            get { return _Tangents; }
            internal set { _Tangents = value; }
        }
        private Transform[] _Tangents;

        public event Action<int> TangentSelected = delegate { };
        public event Action TangentDeselected = delegate { };

        private void CreateTangents()
        {
            Array.Resize(ref _Tangents, GetAllPoints.Length);

            for (int i = 0; i < _Tangents.Length; i++)
            {
                if (_Tangents[i] == null)
                {
                    _Tangents[i] = new Transform(new Vector2(GetAllPoints[i].Position.X, GetAllPoints[i].Position.Y - 100f))
                    {
                        Index = GetAllPoints[i].Index,
                        GetTransformType = Transform.TransformType.Tangent,
                        UserData = new TangentData()
                    };
                }
            }
        }

        public void AddTension()
        {
            if (SelectedTransform != null && SelectedTransform.IsTangent) ((TangentData)SelectedTransform.UserData).Tension += 0.1f;
            else GetAllTangents.ToList().ForEach(x => ((TangentData)x.UserData).Tension += 0.1f);
        }

        public void SubstractTension()
        {
            if (SelectedTransform != null && SelectedTransform.IsTangent) ((TangentData)SelectedTransform.UserData).Tension -= 0.1f;
            else GetAllTangents.ToList().ForEach(x => ((TangentData)x.UserData).Tension -= 0.1f);
        }

        public void AddBias()
        {
            if (SelectedTransform != null && SelectedTransform.IsTangent) ((TangentData)SelectedTransform.UserData).Bias += 0.1f;
            else GetAllTangents.ToList().ForEach(x => ((TangentData)x.UserData).Bias += 0.1f);
        }

        public void SubstractBias()
        {
            if (SelectedTransform != null && SelectedTransform.IsTangent) ((TangentData)SelectedTransform.UserData).Bias -= 0.1f;
            else GetAllTangents.ToList().ForEach(x => ((TangentData)x.UserData).Bias -= 0.1f);
        }

        public override Vector2 GetPoint(float t)
        {
            int i;
            t = MathHelper.Clamp(t, 0f, 1f) * CurveCount;
            i = (int)t;
            t -= i;

            if (i >= GetAllPoints.Length - 1) i = 0;

            return Spline.GetHermitePoint(
                GetAllTangents[i].Position,
                GetAllTangents[i + 1].Position, 
                GetAllPoints[i].Position, 
                GetAllPoints[i + 1].Position,
                ((TangentData)GetAllTangents[i].UserData).Bias,
                ((TangentData)GetAllTangents[i].UserData).Tension, t);
        }

        public override Vector2 GetDirection(float t)
        {
            int i;
            t = MathHelper.Clamp(t, 0f, 1f) * CurveCount;
            i = (int)t;
            t -= i;

            if (i >= GetAllPoints.Length - 1) i = 0;

            return Spline.GetHermiteTangent(
                GetAllTangents[i].Position,
                GetAllTangents[i + 1].Position,
                GetAllPoints[i].Position,
                GetAllPoints[i + 1].Position,
                ((TangentData)GetAllTangents[i].UserData).Bias,
                ((TangentData)GetAllTangents[i].UserData).Tension, t);
        }

        public override void TranslateTransform(Transform point, Vector2 value)
        {
            base.TranslateTransform(point, value);

            if (point != null && point.IsPoint)
            {
                GetAllTangents.ToList().Find(x => x.Index == point.Index).Translate(value);
            }
        }

        public override void TranslateSelectedTransform(Vector2 value)
        {
            base.TranslateSelectedTransform(value);

            if (SelectedTransform != null && SelectedTransform.IsPoint)
            {
                GetAllTangents.ToList().Find(x => x.Index == SelectedTransform.Index).Translate(value);
            }
        }

        public override void TranslateAll(Vector2 amount)
        {
            base.TranslateAll(amount);

            if (GetAllTangents != null) GetAllTangents.Distinct().ToList().ForEach(x => x.Translate(amount));
        }

        public override Transform SelectTransform(Vector2 position)
        {
            GetAllTangents.ToList().ForEach(x => x.IsSelected = false);
            SelectedTransform = null;
            TangentDeselected.Invoke();

            if (GetAllTangents.Any(x => x.TryGetPosition(position)))
            {
                SelectedTransform = GetAllTangents.First(x => x.TryGetPosition(position));
                TangentSelected.Invoke(SelectedTransform.Index);
                return SelectedTransform;
            }
            else return base.SelectTransform(position);
        }

        public override void AddCurveLeft()
        {
            base.AddCurveLeft();

            CreateTangents();
        }

        public override void AddCurveRight()
        {
            base.AddCurveRight();

            CreateTangents();
        }

        public override void Reset()
        {
            base.Reset();

            CreateTangents();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            if (Setup.ShowTangents)
            {
                for (int i = 0; i < GetAllTangents.Length; i++)
                {
                    float distance = Vector2.Distance(GetAllTangents[i].Position, GetAllPoints[i].Position);
                    float angle = (float)Math.Atan2(GetAllPoints[i].Position.Y - GetAllTangents[i].Position.Y, GetAllPoints[i].Position.X - GetAllTangents[i].Position.X);

                    DrawLine(spriteBatch, GetAllTangents[i].Position, angle, distance, GetAllTangents[i].IsSelected ? Setup.BaseLineColor : Setup.CenterSplineColor, Setup.BaseLineThickness);
                    DrawPoint(spriteBatch, GetAllTangents[i].Position, i, angle, GetAllTangents[i].IsSelected ? Setup.BaseLineColor : Setup.CenterSplineColor);
                }
            }
        }

        public override void LoadSplineData(Transform[] points, ControlPointMode[] modes, Trigger[] trigger, Transform[] tangents = null)
        {
            _Tangents = null;
            Array.Resize(ref _Tangents, tangents.Length);
            tangents.CopyTo(_Tangents, 0);

            for (int i = 0; i < _Tangents.Length; i++) _Tangents[i].GetTransformType = Transform.TransformType.Tangent;

            base.LoadSplineData(points, modes, trigger, tangents);
        }
    }
}
