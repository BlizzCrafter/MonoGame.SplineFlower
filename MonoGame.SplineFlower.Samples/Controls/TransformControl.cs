using Microsoft.Xna.Framework;
using MonoGame.Forms.NET.Controls;
using MonoGame.SplineFlower.Rendering;
using MonoGame.SplineFlower.Spline;
using System.ComponentModel;

namespace MonoGame.SplineFlower.Samples.Controls
{
    public abstract class TransformControl : MonoGameControl
    {
        public enum CenterTransformMode
        {
            None,
            Rotate,
            Scale,
            ScaleRotate
        }
        [Browsable(false)]
        public CenterTransformMode SetCenterTransformMode { get; set; } = CenterTransformMode.ScaleRotate;

        [Browsable(false)]
        public SplineBase MySpline { get; set; }

        private bool _ClickedOnTestTransform = false;
        protected bool ScalePointClick = false;
        protected bool RotatePointClick = false;
        protected bool TranslatePointClick = false;
        protected bool TranslateAllPointsClick = false;
        protected bool UseWorldUnits = false;        
        protected System.Drawing.Point TranslatePointFirstClick;
        protected Transform TestTransform;

        public abstract void InitializeSplineControlSample();

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            _ClickedOnTestTransform = false;
            ScalePointClick = false;
            RotatePointClick = false;
            TranslatePointClick = false;
            TranslateAllPointsClick = false;

            MySpline.CalculateSplineCenter(MySpline.GetAllPoints);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (IsMouseInsideControl)
            {
                Vector2 mouseLocation;
                if (UseWorldUnits)
                {
                    mouseLocation = Functions.ConvertScreenToWorld(new Vector2(Editor.GetRelativeMousePosition.X, Editor.GetRelativeMousePosition.Y), true);
                }
                else mouseLocation = new Vector2(Editor.GetRelativeMousePosition.X, Editor.GetRelativeMousePosition.Y);

                TranslatePointFirstClick = new System.Drawing.Point((int)mouseLocation.X, (int)mouseLocation.Y);

                if (e.Button == MouseButtons.Left)
                {
                    if (MySpline.SelectTransform(mouseLocation) != null)
                    {
                        if (MySpline.SelectedTransform != null && MySpline.SelectedTransform.IsCenter)
                        {
                            if (SetCenterTransformMode == CenterTransformMode.Rotate) RotatePointClick = true;
                            else if (SetCenterTransformMode == CenterTransformMode.Scale) ScalePointClick = true;
                            else if (SetCenterTransformMode == CenterTransformMode.ScaleRotate)
                            {
                                RotatePointClick = true;
                                ScalePointClick = true;
                            }
                            else TranslateAllPointsClick = true;
                        }
                        else TranslatePointClick = true;
                    }
                    else
                    {
                        MySpline.SelectTrigger(mouseLocation);

                        if (TestTransform != null)
                        {
                            if (TestTransform.Size.Contains(mouseLocation))
                            {
                                MySpline.SelectedTransform = TestTransform;
                                _ClickedOnTestTransform = true;
                                TranslatePointClick = true;
                            }
                        }
                    }
                }
                else if (e.Button == MouseButtons.Middle) TranslateAllPointsClick = true;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            Vector2 mouseLocation;

            if (UseWorldUnits)
            {
                mouseLocation = Functions.ConvertScreenToWorld(new Vector2(e.Location.X, e.Location.Y), true);
            }
            else mouseLocation = new Vector2(e.Location.X, e.Location.Y);

            MySpline.Acceleration = new Vector2(
                TranslatePointFirstClick.X - (int)mouseLocation.X,
                TranslatePointFirstClick.Y - (int)mouseLocation.Y);

            if (TranslatePointClick || TranslateAllPointsClick)
            {
                if (TranslatePointClick)
                {
                    MySpline.TranslateSelectedTransform(new Vector2(-MySpline.Acceleration.X, -MySpline.Acceleration.Y));
                    if (!_ClickedOnTestTransform)
                    {
                        if (MySpline.SelectedTransform != null)
                        {
                            MySpline.MoveAxis(MySpline.SelectedTransform.Index, new Vector2(-MySpline.Acceleration.X, -MySpline.Acceleration.Y));
                        }
                        MySpline.UpdateTriggerRotation();
                        MySpline.CalculateSplineCenter(MySpline.GetAllPoints);
                    }
                }
                else if (TranslateAllPointsClick) MySpline.TranslateAll(new Vector2(-MySpline.Acceleration.X, -MySpline.Acceleration.Y));
            }
            else if (RotatePointClick && !ScalePointClick) MySpline.Rotate(MySpline.Acceleration.Y);
            else if (ScalePointClick && !RotatePointClick) MySpline.Scale(MySpline.Acceleration.Y);
            else if (ScalePointClick && RotatePointClick) MySpline.ScaleRotate(MySpline.Acceleration.Y);

            TranslatePointFirstClick.X = (int)mouseLocation.X;
            TranslatePointFirstClick.Y = (int)mouseLocation.Y;
        }

        public void CenterSpline()
        {
            if (MySpline == null) return;

            if (UseWorldUnits)
            {
                var center = ConvertUnits.ToSimUnits(new Vector2(
                        Editor.GraphicsDevice.Viewport.Width,
                        Editor.GraphicsDevice.Viewport.Height * -1));
                MySpline.Position(ConvertUnits.ToDisplayUnits(center));
                MySpline.PolygonStripeCreated = false;
            }
            else MySpline.Position(new Vector2(Editor.GraphicsDevice.Viewport.Width / 2, Editor.GraphicsDevice.Viewport.Height / 2));
        }

        protected override void Update(GameTime gameTime)
        {
            if (MySpline != null) MySpline.Update(gameTime);
        }
    }
}
