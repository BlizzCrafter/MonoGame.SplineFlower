using Microsoft.Xna.Framework;
using System.Text.Json.Serialization;

namespace MonoGame.SplineFlower
{
    public class TransformDummy
    {
        [JsonPropertyOrder(1)]
        public Vector2 Position { get; set; } = Vector2.Zero;
        [JsonPropertyOrder(0)]
        public int Index { get; set; } = -1;
        [JsonPropertyOrder(2)]
        public object UserData { get; set; }

        public TransformDummy(int index, Vector2 position)
        {
            Index = index;
            Position = position;
        }
        protected TransformDummy() { }
    }
}
