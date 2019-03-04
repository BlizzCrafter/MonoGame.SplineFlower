using Microsoft.Xna.Framework;
using System.Linq;

namespace MonoGame.SplineFlower
{
    public abstract class PointBase
    {
        public Transform GetSplineCenter { get; private set; }

        public void CalculateSplineCenter(Transform[] allPoints)
        {
            float maxX = (float)allPoints.Sum(x => x.Position.X);
            float maxY = (float)allPoints.Sum(x => x.Position.Y);

            float centerX = maxX / allPoints.Count();
            float centerY = maxY / allPoints.Count();

            GetSplineCenter = new Transform(new Vector2(centerX, centerY));
            GetSplineCenter.Index = -999;
        }
    }
}
