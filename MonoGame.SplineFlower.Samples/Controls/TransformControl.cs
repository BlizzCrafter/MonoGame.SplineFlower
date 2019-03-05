using Microsoft.Xna.Framework;
using MonoGame.Forms.Controls;
using System.ComponentModel;
using System.Windows.Forms;

namespace MonoGame.SplineFlower.Samples.Controls
{
    public abstract class TransformControl : UpdateWindow
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
        public Trigger SelectedTrigger { get; set; }

        [Browsable(false)]
        public BezierSpline GetSpline { get; set; }
        
        protected bool ScalePointClick = false;
        protected bool RotatePointClick = false;
        protected bool TranslatePointClick = false;
        protected bool TranslateAllPointsClick = false;
        protected System.Drawing.Point TranslatePointFirstClick;
        protected Transform SelectedTransform;

        private Vector2 _BezierPosition;
        private Vector2 _OldBezierDistance;

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            ScalePointClick = false;
            RotatePointClick = false;
            TranslatePointClick = false;
            TranslateAllPointsClick = false;
            SelectedTransform = null;

            GetSpline.CalculateSplineCenter(GetSpline.GetAllPoints());
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (Editor.IsMouseInsideControl)
            {
                TranslatePointFirstClick = e.Location;

                if (e.Button == MouseButtons.Left)
                {
                    SelectedTransform = GetSpline.TryGetTransformFromPosition(new Vector2(e.X, e.Y));
                    if (SelectedTransform != null)
                    {
                        if (SelectedTransform.IsCenterSpline)
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
                    else SelectedTrigger = GetSpline.TryGetTriggerFromPosition(new Vector2(e.X, e.Y));
                }
                else if (e.Button == MouseButtons.Middle) TranslateAllPointsClick = true;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            int xDiff = TranslatePointFirstClick.X - e.Location.X;
            int yDiff = TranslatePointFirstClick.Y - e.Location.Y;

            if (TranslatePointClick || TranslateAllPointsClick)
            {
                if (SelectedTransform != null && TranslatePointClick)
                {
                    SelectedTransform.Translate(new Vector2(-xDiff, -yDiff));
                    GetSpline.MoveAxis(SelectedTransform.Index, new Vector2(-xDiff, -yDiff));
                    GetSpline.GetAllTrigger().ForEach(x => x.UpdateTriggerRotation());
                    GetSpline.CalculateSplineCenter(GetSpline.GetAllPoints());
                }
                else if (TranslateAllPointsClick) GetSpline.Translate(new Vector2(-xDiff, -yDiff));
            }
            else if (RotatePointClick && !ScalePointClick) GetSpline.Rotate(yDiff);
            else if (ScalePointClick && !RotatePointClick) GetSpline.Scale(yDiff);
            else if (ScalePointClick && RotatePointClick) GetSpline.ScaleRotate(yDiff);

            TranslatePointFirstClick.X = e.Location.X;
            TranslatePointFirstClick.Y = e.Location.Y;
        }

        protected void TranslateAllPointsToScreenCenter(Vector2 bezierCenter)
        {
            Vector2 centerScreen = new Vector2(ClientSize.Width / 2, ClientSize.Height / 2);
            Vector2 distance = centerScreen - bezierCenter;

            if (_OldBezierDistance != distance) GetSpline.Translate(distance);

            _OldBezierDistance = distance;
        }
    }
}
