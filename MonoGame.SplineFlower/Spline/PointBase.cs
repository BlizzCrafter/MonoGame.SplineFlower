using Microsoft.Xna.Framework;
using MonoGame.SplineFlower.Content;
using System.Linq;

namespace MonoGame.SplineFlower.Spline
{
    public abstract class PointBase
    {
        public Transform CenterSpline { get; private set; }

        public void CalculateSplineCenter(Transform[] allPoints)
        {
            float maxX = (float)allPoints.Sum(x => x.Position.X);
            float maxY = (float)allPoints.Sum(x => x.Position.Y);

            float centerX = maxX / allPoints.Count();
            float centerY = maxY / allPoints.Count();

            CenterSpline = new Transform(new Vector2(centerX, centerY));
            CenterSpline.Index = Setup.CenterSplineIndex;
            CenterSpline.GetTransformType = Transform.TransformType.Center;
        }
    }
}
