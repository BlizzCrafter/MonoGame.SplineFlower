using Microsoft.Xna.Framework;

namespace MonoGame.SplineFlower.Spline.Types
{
    public class BezierSpline : SplineBase
    {
        public BezierSpline() : base()
        {
            Reset();
        }
        public BezierSpline(Transform[] points) : base(points) { }

        public override Vector2 GetPoint(float t)
        {
            int i;
            if (t >= 1f)
            {
                t = 1f;
                i = GetAllPoints.Length - 4;
            }
            else
            {
                t = MathHelper.Clamp(t, 0f, 1f) * CurveCount;
                i = (int)t;
                t -= i;
                i *= 3;
            }

            return Spline.GetCubicPoint(
                GetAllPoints[i].Position, 
                GetAllPoints[i + 1].Position, 
                GetAllPoints[i + 2].Position, 
                GetAllPoints[i + 3].Position, 
                t);
        }

        public override Vector2 GetDirection(float t)
        {
            int i;
            if (t >= 1f)
            {
                t = 1f;
                i = GetAllPoints.Length - 4;
            }
            else
            {
                t = MathHelper.Clamp(t, 0f, 1f) * CurveCount;
                i = (int)t;
                t -= i;
                i *= 3;
            }

            return Spline.GetCubicTangent(
                GetAllPoints[i].Position, 
                GetAllPoints[i + 1].Position, 
                GetAllPoints[i + 2].Position, 
                GetAllPoints[i + 3].Position, 
                t);
        }
    }
}
