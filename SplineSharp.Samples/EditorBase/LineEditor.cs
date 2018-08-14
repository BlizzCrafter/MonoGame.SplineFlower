using Microsoft.Xna.Framework;
using System.Windows.Forms;

namespace SplineSharp.Samples.EditorBase
{
    public abstract class LineEditor : TransformControl
    {
        public Line MyLine { get; set; }
        private bool FirstPointSet = false;
        private bool SecondPointSet = false;

        protected override void Initialize()
        {
            base.Initialize();
            Setup.Initialize(Editor.graphics);

            MyLine = new Line();
            TryGetTransformFromPosition = MyLine.TryGetTransformFromPosition;
        }

        protected override void Draw()
        {
            base.Draw();

            Editor.spriteBatch.Begin();

            if (MyLine != null) MyLine.DrawLine(Editor.spriteBatch);

            Editor.spriteBatch.End();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (AddPointsMode)
            {
                if (Editor.IsMouseInsideControl)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        if (!FirstPointSet)
                        {
                            FirstPointSet = true;
                            MyLine.FirstPoint.SetPosition(new Vector2(e.X, e.Y));
                        }
                        else if (!SecondPointSet)
                        {
                            SecondPointSet = true;
                            MyLine.SecondPoint.SetPosition(new Vector2(e.X, e.Y));
                        }
                    }
                }
            }
        }
    }
}
