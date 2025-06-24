using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.SplineFlower.Spline.Types.Basics
{
    public class Line : PointBase
    {
        public Transform FirstPoint
        {
            get { return p0; }
            private set { p0 = value; }
        }
        public Transform SecondPoint
        {
            get { return p1; }
            private set { p1 = value; }
        }
        private Transform p0, p1;

        public Transform[] GetAllPoints()
        {
            return new Transform[] { FirstPoint, SecondPoint };
        }

        public Line()
        {
            FirstPoint = new Transform();
            SecondPoint = new Transform();
        }

        public Transform TryGetTransformFromPosition(Vector2 position)
        {
            if (FirstPoint != null && FirstPoint.TryGetPosition(position)) return FirstPoint;
            else if (SecondPoint != null && SecondPoint.TryGetPosition(position)) return SecondPoint;

            else return null;
        }

        public void DrawLine(SpriteBatch spriteBatch)
        {
            if (!Setup.Initialized)
            {
                throw new Exception("You need to initialize the  MonoGame.SplineFlower library first by calling ' MonoGame.SplineFlower.Setup.Initialize();'");
            }

            if (p0.Position == Vector2.Zero && p1.Position == Vector2.Zero) return;

            float distance = Vector2.Distance(p0.Position, p1.Position);
            float angle = (float)Math.Atan2(p1.Position.Y - p0.Position.Y, p1.Position.X - p0.Position.X);

            spriteBatch.Draw(Setup.Pixel,
                             p0.Position,
                             null,
                             Setup.BaseLineColor,
                             angle,
                             Vector2.Zero,
                             new Vector2(distance, Setup.BaseLineThickness),
                             SpriteEffects.None,
                             0);

            DrawPoint(spriteBatch, p0.Position, angle);
            DrawPoint(spriteBatch, p1.Position, angle);
        }

        private void DrawPoint(SpriteBatch spriteBatch, Vector2 point, float angle)
        {
            spriteBatch.Draw(Setup.Pixel,
                             point,
                             null,
                             Setup.PointColor,
                             angle,
                             new Vector2(0.5f),
                             Setup.PointThickness,
                             SpriteEffects.None,
                             0f);
        }

        public void Reset()
        {
            FirstPoint.SetPosition(new Vector2(0, 0));
            SecondPoint.SetPosition(new Vector2(200, 0));

            CalculateSplineCenter(new Transform[] { FirstPoint, SecondPoint });
        }
    }
}
