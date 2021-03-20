using Microsoft.Xna.Framework;
using MonoGame.Forms.Controls;
using MonoGame.SplineFlower.Spline;
using MonoGame.SplineFlower.Utils;
using System.ComponentModel;
using System.Windows.Forms;

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
        public SplineBase GetSpline { get; set; }

        private bool _ClickedOnTestTransform = false;
        protected bool ScalePointClick = false;
        protected bool RotatePointClick = false;
        protected bool TranslatePointClick = false;
        protected bool TranslateAllPointsClick = false;
        protected bool UseWorldUnits = false;        
        protected System.Drawing.Point TranslatePointFirstClick;
        protected Transform TestTransform;

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            _ClickedOnTestTransform = false;
            ScalePointClick = false;
            RotatePointClick = false;
            TranslatePointClick = false;
            TranslateAllPointsClick = false;

            GetSpline.CalculateSplineCenter(GetSpline.GetAllPoints);
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
                    if (GetSpline.SelectTransform(mouseLocation) != null)
                    {
                        if (GetSpline.SelectedTransform != null && GetSpline.SelectedTransform.IsCenter)
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
                        GetSpline.SelectTrigger(mouseLocation);

                        if (TestTransform != null)
                        {
                            if (TestTransform.Size.Contains(mouseLocation))
                            {
                                GetSpline.SelectedTransform = TestTransform;
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

            int xDiff = TranslatePointFirstClick.X - (int)mouseLocation.X;
            int yDiff = TranslatePointFirstClick.Y - (int)mouseLocation.Y;

            if (TranslatePointClick || TranslateAllPointsClick)
            {
                if (TranslatePointClick)
                {
                    GetSpline.TranslateSelectedTransform(new Vector2(-xDiff, -yDiff));
                    if (!_ClickedOnTestTransform)
                    {
                        if (GetSpline.SelectedTransform != null)
                        {
                            GetSpline.MoveAxis(GetSpline.SelectedTransform.Index, new Vector2(-xDiff, -yDiff));
                        }
                        GetSpline.UpdateTriggerRotation();
                        GetSpline.CalculateSplineCenter(GetSpline.GetAllPoints);
                    }
                }
                else if (TranslateAllPointsClick) GetSpline.TranslateAll(new Vector2(-xDiff, -yDiff));
            }
            else if (RotatePointClick && !ScalePointClick) GetSpline.Rotate(yDiff);
            else if (ScalePointClick && !RotatePointClick) GetSpline.Scale(yDiff);
            else if (ScalePointClick && RotatePointClick) GetSpline.ScaleRotate(yDiff);

            TranslatePointFirstClick.X = (int)mouseLocation.X;
            TranslatePointFirstClick.Y = (int)mouseLocation.Y;
        }

        public void CenterSpline()
        {
            if (UseWorldUnits)
            {
                GetSpline.Position(ConvertUnits.ToSimUnits(Editor.graphics.Viewport.Width / 2, Editor.graphics.Viewport.Height / 2));
                GetSpline.PolygonStripeCreated = false;
            }
            else if (GetSpline != null) GetSpline.Position(new Vector2(Editor.graphics.Viewport.Width / 2, Editor.graphics.Viewport.Height / 2));
        }
    }
}
