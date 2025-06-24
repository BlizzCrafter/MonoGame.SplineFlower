using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame.SplineFlower.Rendering
{
    public static class Functions
    {
        public static GraphicsDevice Graphics;
        public static BasicEffect GetBasicEffect;
        public static RasterizerState RasterizerState;
        public static Matrix Projection, View;

        private static Vector2 _lower, _upper;

        public static void UpdateProjectionViewMatrix(Vector2 camAbsolutePosition, float camZoom)
        {
            _lower = -new Vector2(DisplayToWorldUnit * Graphics.Viewport.AspectRatio, DisplayToWorldUnit) / camZoom;
            _upper = new Vector2(DisplayToWorldUnit * Graphics.Viewport.AspectRatio, DisplayToWorldUnit) / camZoom;

            Projection = Matrix.CreateOrthographicOffCenter(_lower.X, _upper.X, _lower.Y, _upper.Y, 0f, 2f);

            View =
                Matrix.CreateTranslation(new Vector3(
                    -ConvertUnits.ToSimUnits(Graphics.Viewport.Width / 2f),
                    -ConvertUnits.ToSimUnits(Graphics.Viewport.Height / 2f), 0)) *
                Matrix.CreateLookAt(
                    new Vector3(camAbsolutePosition, 1),
                    new Vector3(camAbsolutePosition, 0),
                    Vector3.Up);

            GetBasicEffect.Projection = Projection;
            GetBasicEffect.View = View;
            GetBasicEffect.World = Matrix.CreateScale(1f, -1f, 0f);
            GetBasicEffect.CurrentTechnique.Passes[0].Apply();
        }

        public static float DisplayToWorldUnit
        {
            get { return _DisplayToWorldUnit; }
            set
            {
                _DisplayToWorldUnit = value;
                ConvertUnits.SetDisplayUnitToSimUnitRatio(value);
            }
        }
        private static float _DisplayToWorldUnit;

        public static Vector2 ConvertScreenToWorld(int x, int y, bool flipVertical = false)
        {
            Vector3 temp = Graphics.Viewport.Unproject(new Vector3(x, y, 0), Projection, View, flipVertical ? Matrix.CreateScale(new Vector3(1, -1, 1)) : Matrix.Identity);
            return new Vector2(temp.X, temp.Y);
        }
        public static Vector2 ConvertScreenToWorld(float x, float y, bool flipVertical = false)
        {
            Vector3 temp = Graphics.Viewport.Unproject(new Vector3(x, y, 0), Projection, View, flipVertical ? Matrix.CreateScale(new Vector3(1, -1, 1)) : Matrix.Identity);
            return new Vector2(temp.X, temp.Y);
        }
        public static Vector2 ConvertScreenToWorld(Vector2 position, bool flipVertical = false)
        {
            Vector3 temp = Graphics.Viewport.Unproject(new Vector3(position, 0), Projection, View, flipVertical ? Matrix.CreateScale(new Vector3(1, -1, 1)) : Matrix.Identity);
            return new Vector2(temp.X, temp.Y);
        }
        public static Vector2 ConvertWorldToScreen(Vector2 position, bool flipVertical = false)
        {
            Vector3 temp = Graphics.Viewport.Project(new Vector3(position, 0), Projection, View, flipVertical ? Matrix.CreateScale(new Vector3(1, -1, 1)) : Matrix.Identity);
            return new Vector2(temp.X, temp.Y);
        }

        public static Vector2 Rotate(float angle, float distance, Vector2 centre)
        {
            return new Vector2((float)(distance * Math.Cos(angle)), (float)(distance * Math.Sin(angle))) + centre;
        }

        public static float GetRotation(Vector2 Origin, Vector2 LookAt, ref Vector2 Direction, bool invertDirection = false)
        {
            Direction = LookAt - Origin;
            Direction.Normalize();
            if (invertDirection == true) Direction *= -1;
            return (float)Math.Atan2(Direction.X, -(double)Direction.Y);
        }

        public static Vector2 RotateToPosition(Vector2 Origin, Vector2 Destination, float distance, float degreeCorrection)
        {
            Vector2 Rotation = Vector2.Zero;

            return Rotate(
                MathHelper.ToRadians(180f) + MathHelper.ToRadians(degreeCorrection) + GetRotation(Origin, Destination, ref Rotation), -distance, Origin);
        }
    }
}
