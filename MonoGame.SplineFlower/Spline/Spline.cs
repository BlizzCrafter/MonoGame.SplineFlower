using Microsoft.Xna.Framework;

namespace MonoGame.SplineFlower.Spline
{
    internal static class Spline
    {
        #region Quadratic Bezier

        internal static Vector2 GetQuadraticPoint(Vector2 p0, Vector2 p1, Vector2 p2, float t)
        {
            t = MathHelper.Clamp(t, 0f, 1f);
            float oneMinusT = 1f - t;

            return
                oneMinusT * oneMinusT * p0 +
                2f * oneMinusT * t * p1 +
                t * t * p2;
        }

        internal static Vector2 GetQuadraticTangent(Vector2 p0, Vector2 p1, Vector2 p2, float t)
        {
            return
                2f * (1f - t) * (p1 - p0) +
                2f * t * (p2 - p1);
        }

        #endregion

        #region Cubic Bezier

        internal static Vector2 GetCubicPoint(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, float t)
        {
            t = MathHelper.Clamp(t, 0f, 1f);
            float oneMinusT = 1f - t;
            return
                oneMinusT * oneMinusT * oneMinusT * p0 +
                3f * oneMinusT * oneMinusT * t * p1 +
                3f * oneMinusT * t * t * p2 +
                t * t * t * p3;
        }

        internal static Vector2 GetCubicTangent(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, float t)
        {
            t = MathHelper.Clamp(t, 0f, 1f);
            float oneMinusT = 1f - t;
            return
                3f * oneMinusT * oneMinusT * (p1 - p0) +
                6f * oneMinusT * t * (p2 - p1) +
                3f * t * t * (p3 - p2);
        }

        #endregion

        #region CatMulRom Spline
        
        internal static Vector2 GetCatMulRomPoint(Transform[] points, float t, bool loop = false)
        {
            int p0, p1, p2, p3;
            if (!loop)
            {
                p1 = (int)t + 1;
                p2 = p1 + 1;
                p3 = p2 + 1;
                p0 = p1 - 1;
            }
            else
            {
                p1 = (int)t;
                p2 = (p1 + 1) % points.Length;
                p3 = (p2 + 1) % points.Length;
                p0 = p1 >= 1 ? p1 - 1 : points.Length - 1;
            }

            if (p1 >= points.Length) p1 = 0;
            if (p2 >= points.Length) p2 = 0;
            if (p3 >= points.Length) p3 = 0;
            if (p0 >= points.Length) p0 = 0;

            t = t - (int)t;

            float tt = t * t;
            float ttt = tt * t;

            float q1 = -ttt + 2.0f * tt - t;
            float q2 = 3.0f * ttt - 5.0f * tt + 2.0f;
            float q3 = -3.0f * ttt + 4.0f * tt + t;
            float q4 = ttt - tt;

            float tx = 0.5f * (points[p0].Position.X * q1 + points[p1].Position.X * q2 + points[p2].Position.X * q3 + points[p3].Position.X * q4);
            float ty = 0.5f * (points[p0].Position.Y * q1 + points[p1].Position.Y * q2 + points[p2].Position.Y * q3 + points[p3].Position.Y * q4);

            return new Vector2(tx, ty);
        }

        internal static Vector2 GetCatMulRomTangent(Transform[] points, float t, bool loop = false)
        {
            int p0, p1, p2, p3;
            if (!loop)
            {
                p1 = (int)t + 1;
                p2 = p1 + 1;
                p3 = p2 + 1;
                p0 = p1 - 1;
            }
            else
            {
                p1 = (int)t;
                p2 = (p1 + 1) % points.Length;
                p3 = (p2 + 1) % points.Length;
                p0 = p1 >= 1 ? p1 - 1 : points.Length - 1;
            }

            if (p1 >= points.Length) p1 = 0;
            if (p2 >= points.Length) p2 = 0;
            if (p3 >= points.Length) p3 = 0;
            if (p0 >= points.Length) p0 = 0;

            t = t - (int)t;

            float tt = t * t;
            float ttt = tt * t;

            float q1 = -3.0f * tt + 4.0f * t - 1;
            float q2 = 9.0f * tt - 10.0f * t;
            float q3 = -9.0f * tt + 8.0f * t + 1.0f;
            float q4 = 3.0f * tt - 2.0f * t;
            
            float tx = 0.5f * (points[p0].Position.X * q1 + points[p1].Position.X * q2 + points[p2].Position.X * q3 + points[p3].Position.X * q4);
            float ty = 0.5f * (points[p0].Position.Y * q1 + points[p1].Position.Y * q2 + points[p2].Position.Y * q3 + points[p3].Position.Y * q4);

            return new Vector2(tx, ty);
        }

        #endregion

        #region Hermite Spline

        public static Vector2 GetHermitePoint(
            Vector2 m0, Vector2 m1, Vector2 p0, Vector2 p1, 
            float bias, float tension,
            float t)
        {
            float t2 = t * t;
            float t3 = t2 * t;

            return (p0 * ((2.0f * t3) - (3.0f * t2) + 1.0f))
                + ((m0 - p0) * (1f + bias) * (1f - tension) * (t3 + (-2.0f * t2) + t))
                + (p1 * ((-2.0f * t3) + (3.0f * t2)))
                + ((m1 - p1) * (1f - bias) * (1f - tension) * (t3 - t2));
        }

        public static Vector2 GetHermiteTangent(
            Vector2 m0, Vector2 m1, Vector2 p0, Vector2 p1, 
            float bias, float tension, 
            float t)
        {
            var t2 = t * t;

            return
                (6f * t2 - 6 * t) * p0 +
                (-6f * t2 + 6 * t) * p1 +
                (3f * t2 - 4f * t + 1) * (1f + bias) * (1f - tension) * (m0 - p0) +
                (3f * t2 - 2f * t) * (1f - bias) * (1f - tension) * (m1 - p1);
        }

        #endregion
    }
}
