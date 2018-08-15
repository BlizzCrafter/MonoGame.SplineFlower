using Microsoft.Xna.Framework;

namespace SplineSharp
{
    public class Transform
    {
        public Rectangle Size = Rectangle.Empty;
        public Vector2 Position { get; private set; } = Vector2.Zero;
        public float Rotation { get; set; } = 0f;
        public int Index { get; set; } = -1;

        public Transform() { }
        public Transform(Vector2 position) : this()
        {
            SetPosition(position);
        }
        public Transform(ref Vector2 position) : this(position)
        {
            
        }
        public Transform(ref Vector2 position, ref float rotation) : this(ref position)
        {
            Rotation = rotation;
        }

        public void SetPosition(Vector2 position)
        {
            Position = new Vector2(position.X, position.Y);
            Size = new Rectangle(
                (int)position.X - (Setup.PointThickness / 2), 
                (int)position.Y - (Setup.PointThickness / 2), 
                Setup.PointThickness, 
                Setup.PointThickness);
        }

        public void Translate(Vector2 position)
        {
            Position += position;
            Size.X += (int)position.X;
            Size.Y += (int)position.Y;
        }

        internal bool TryGetPosition(Vector2 position)
        {
            if (Size.Contains(position)) return true;

            return false;
        }
    }
}
