using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.SplineFlower
{
    public class Functions
    {
        public static Vector2 Rotate(float angle, float distance, Vector2 centre)
        {
            return new Vector2((float)(distance * Math.Cos(angle)), (float)(distance * Math.Sin(angle))) + centre;
        }

        public static float GetRotation(Vector2 Origin, Vector2 LookAt, ref Vector2 Direction, bool invertDirection = false)
        {
            Direction = LookAt - Origin;
            Direction.Normalize();
            if (invertDirection == true) Direction *= -1;
            return (float)Math.Atan2((double)Direction.X, -(double)Direction.Y);
        }

        public static Vector2 RotateToPosition(Vector2 Origin, Vector2 Destination, float distance)
        {
            Vector2 Rotation = Vector2.Zero;

            return Rotate(MathHelper.ToRadians(90f) + GetRotation(Origin, Destination, ref Rotation), -distance, Origin);
        }
    }
}
