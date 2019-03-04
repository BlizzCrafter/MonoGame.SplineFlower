using Microsoft.Xna.Framework;
using System.Linq;

namespace MonoGame.SplineFlower
{
    public abstract class PointBase
    {
        public Transform GetBezierCenter { get; private set; }

        public void CalculateBezierCenter(Transform[] allPoints)
        {
            float maxX = (float)allPoints.Sum(x => x.Position.X);
            float maxY = (float)allPoints.Sum(x => x.Position.Y);

            float centerX = maxX / allPoints.Count();
            float centerY = maxY / allPoints.Count();

            GetBezierCenter = new Transform(new Vector2(centerX, centerY));
        }
    }
}
