using Microsoft.Xna.Framework;

namespace SplineSharp
{
    public static class Bezier
    {
        public static Vector2 GetPoint(Vector2 p0, Vector2 p1, Vector2 p2, float t)
        {
            t = MathHelper.Clamp(t, 0f, 1f);
            float oneMinusT = 1f - t;

            return
                oneMinusT * oneMinusT * p0 +
                2f * oneMinusT * t * p1 +
                t * t * p2;
        }
    }
}
