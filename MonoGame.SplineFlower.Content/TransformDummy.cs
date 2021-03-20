using Microsoft.Xna.Framework;

namespace MonoGame.SplineFlower.Content
{
    public class TransformDummy
    {
        public Vector2 Position { get; set; } = Vector2.Zero;
        public int Index { get; set; } = -1;
        public object UserData { get; set; }

        public TransformDummy(int index, Vector2 position)
        {
            Index = index;
            Position = position;
        }
        protected TransformDummy() { }
    }
}
