using Microsoft.Xna.Framework;
using MonoGame.SplineFlower.Content;
using System.Collections.Generic;

namespace MonoGame.SplineFlower
{
    public class Transform : IEqualityComparer<Transform>
    {
        public Rectangle Size { get { return _Size; } }
        private Rectangle _Size = Rectangle.Empty;

        public Vector2 Position { get; private set; } = Vector2.Zero;
        public int Index { get; internal set; } = -1;
        public bool IsCenterSpline { get { return Index == Setup.CenterSplineIndex ? true : false; } }

        public Transform() { }
        public Transform(Vector2 position) : this()
        {
            SetPosition(position);
        }
        public Transform(ref Vector2 position) : this(position)
        {
            
        }

        public void SetPosition(Vector2 position)
        {
            Position = new Vector2(position.X, position.Y);
            _Size = new Rectangle(
                (int)position.X - (Setup.PointThickness / 2), 
                (int)position.Y - (Setup.PointThickness / 2), 
                Setup.PointThickness, 
                Setup.PointThickness);
        }

        public void Translate(Vector2 position)
        {
            Position += position;
            _Size.X += (int)position.X;
            _Size.Y += (int)position.Y;
        }

        internal bool TryGetPosition(Vector2 position)
        {
            if (_Size.Contains(position)) return true;

            return false;
        }

        public bool Equals(Transform x, Transform y)
        {
            if (x.Position == y.Position) return true;
            else return false;
        }

        public int GetHashCode(Transform obj)
        {
            return obj.Position.GetHashCode();
        }
    }
}
