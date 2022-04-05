using Microsoft.Xna.Framework;
using MonoGame.SplineFlower.Content;
using System.Collections.Generic;

namespace MonoGame.SplineFlower
{
    public class Transform : IEqualityComparer<Transform>
    {
        internal enum TransformType
        {
            Point,
            Tangent,
            Center
        }
        internal TransformType GetTransformType { get; set; }

        /// <summary>
        /// Reference of the Transform which is left from this Transform.
        /// </summary>
        public Transform Left { get; set; }
        /// <summary>
        /// Reference of the Transform which is right from this Transform.
        /// </summary>
        public Transform Right { get; set; }

        public Rectangle Size { get { return _Size; } }
        private Rectangle _Size = Rectangle.Empty;

        public Vector2 Position { get; private set; } = Vector2.Zero;
        public int Index { get; internal set; } = -1;
        public bool IsSelected { get; set; }
        public bool IsPoint { get { return GetTransformType == TransformType.Point; } }
        public bool IsTangent { get { return GetTransformType == TransformType.Tangent; } }
        public bool IsCenter { get { return GetTransformType == TransformType.Center; } }

        public object UserData { get; set; }

        public Transform() { }
        public Transform(Vector2 position) : this()
        {
            SetPosition(position);
        }
        public Transform(ref Vector2 position) : this(position) { }

        public void SetPosition(Vector2 position)
        {
            Position = new Vector2(position.X, position.Y);
            _Size = new Rectangle(
                (int)position.X - (Setup.PointThickness / 2), 
                (int)position.Y - (Setup.PointThickness / 2), 
                Setup.PointThickness, 
                Setup.PointThickness);
        }

        public void Translate(Vector2 value)
        {
            Position += value;
            _Size.X = (int)Position.X - (Setup.PointThickness / 2);
            _Size.Y = (int)Position.Y - (Setup.PointThickness / 2);
        }

        internal bool TryGetPosition(Vector2 position)
        {
            if (_Size.Contains(position))
            {
                IsSelected = true;
                return true;
            }
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
