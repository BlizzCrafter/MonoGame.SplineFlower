using Microsoft.Xna.Framework;

namespace MonoGame.SplineFlower.Spline.Types
{
    public class CatMulRomSpline : SplineBase
    {
        public CatMulRomSpline() : base()
        {
            Reset();
        }
        public CatMulRomSpline(Transform[] points) : base(points) { }

        public override Vector2 GetPoint(float t)
        {
            return Spline.GetCatMulRomPoint(GetAllPoints, t, Loop);
        }

        public override Vector2 GetDirection(float t)
        {
            return Spline.GetCatMulRomTangent(GetAllPoints, t, Loop);
        }          
    }
}
