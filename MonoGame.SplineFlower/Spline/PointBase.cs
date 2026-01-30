using Microsoft.Xna.Framework;

namespace MonoGame.SplineFlower.Spline
{
    public abstract class PointBase
    {
        public Transform CenterSpline { get; private set; }
        public Rectangle BoundingBox { get; private set; }

        public void CalculateSplineCenter(Transform[] allPoints)
        {
            float minX = (float)allPoints.Min(x => x.Position.X);
            float minY = (float)allPoints.Min(x => x.Position.Y);
            float maxX = (float)allPoints.Max(x => x.Position.X);
            float maxY = (float)allPoints.Max(x => x.Position.Y);

            BoundingBox = new Rectangle((int)minX, (int)minY, (int)(maxX - minX), (int)(maxY - minY));

            float centerX = allPoints.Sum(x => x.Position.X) / allPoints.Length;
            float centerY = allPoints.Sum(x => x.Position.Y) / allPoints.Length;

            CenterSpline = new Transform(new Vector2(centerX, centerY));
            CenterSpline.Index = Setup.CenterSplineIndex;
            CenterSpline.GetTransformType = Transform.TransformType.Center;
        }
    }
}
