using Microsoft.Xna.Framework;
using System.Linq;

namespace SplineSharp
{
    public abstract class PointBase
    {
        public Vector2 GetBezierCenter { get; private set; }

        public void CalculateBezierCenter(Transform[] allPoints)
        {
            float maxX = (float)allPoints.Sum(x => x.Position.X);
            float maxY = (float)allPoints.Sum(x => x.Position.Y);

            float centerX = maxX / allPoints.Count();
            float centerY = maxY / allPoints.Count();

            GetBezierCenter = new Vector2(centerX, centerY);
        }
    }
}
