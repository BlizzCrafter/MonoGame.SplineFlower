using Microsoft.Xna.Framework;
using MonoGame.Forms.Controls;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace SplineSharp.Samples.Controls
{
    public abstract class TransformControl : UpdateWindow
    {
        protected bool TranslatePointClick = false;
        protected bool TranslateAllPointsClick = false;
        protected System.Drawing.Point TranslatePointFirstClick;
        protected Transform SelectedTransform;

        [Browsable(false)]
        public Func<Vector2, Transform> TryGetTransformFromPosition { get; set; }

        [Browsable(false)]
        public Func<Transform[]> GetAllPoints { get; set; }

        [Browsable(false)]
        public event Action<Vector2> MovePointDiff = delegate { };

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            TranslatePointClick = false;
            TranslateAllPointsClick = false;
            SelectedTransform = null;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (Editor.IsMouseInsideControl)
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
                else if (e.Button == MouseButtons.Middle)
                {
                    TranslatePointFirstClick = e.Location;
                    TranslateAllPointsClick = true;
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (TranslatePointClick || TranslateAllPointsClick)
            {
                int xDiff = TranslatePointFirstClick.X - e.Location.X;
                int yDiff = TranslatePointFirstClick.Y - e.Location.Y;

                if (SelectedTransform != null && TranslatePointClick)
                {
                    SelectedTransform.Translate(new Vector2(-xDiff, -yDiff));
                    MovePointDiff.Invoke(new Vector2(-xDiff, -yDiff));
                }
                else if (TranslateAllPointsClick)
                {
                    Transform[] allPoints = GetAllPoints().Distinct().ToArray();
                    for (int i = 0; i < allPoints.Length; i++)
                    {
                        allPoints[i].Translate(new Vector2(-xDiff, -yDiff));
                    }
                }

                TranslatePointFirstClick.X = e.Location.X;
                TranslatePointFirstClick.Y = e.Location.Y;
            }
        }
    }
}
