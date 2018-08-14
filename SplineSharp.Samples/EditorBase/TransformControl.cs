using Microsoft.Xna.Framework;
using MonoGame.Forms.Controls;
using System;
using System.Windows.Forms;

namespace SplineSharp.Samples.EditorBase
{
    public abstract class TransformControl : UpdateWindow
    {
        public bool AddPointsMode { get; set; } = true;
        public bool TranslatePointClick = false;
        public System.Drawing.Point TranslatePointFirstClick;
        public Transform SelectedTransform;

        public Func<Vector2, Transform> TryGetTransformFromPosition { get; set; }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            TranslatePointClick = false;
            SelectedTransform = null;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (!AddPointsMode && Editor.IsMouseInsideControl)
            {
                if (e.Button == MouseButtons.Left)
                {
                    SelectedTransform = TryGetTransformFromPosition(new Vector2(e.X, e.Y));
                    if (SelectedTransform != null)
                    {
                        TranslatePointFirstClick = e.Location;
                        TranslatePointClick = true;
                    }
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (SelectedTransform != null && TranslatePointClick)
            {
                int xDiff = TranslatePointFirstClick.X - e.Location.X;
                int yDiff = TranslatePointFirstClick.Y - e.Location.Y;

                SelectedTransform.Translate(new Vector2(-xDiff, -yDiff));

                TranslatePointFirstClick.X = e.Location.X;
                TranslatePointFirstClick.Y = e.Location.Y;
            }
        }
    }
}
