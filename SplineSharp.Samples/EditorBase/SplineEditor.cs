using System.Windows.Forms;
using Microsoft.Xna.Framework;

namespace SplineSharp.Samples.EditorBase
{
    public abstract class SplineEditor : TransformControl
    {
        public BezierSpline MySpline;

        protected override void Initialize()
        {
            base.Initialize();

            Setup.Initialize(Editor.graphics);
            MySpline = new BezierSpline();
            MySpline.Reset();
            TryGetTransformFromPosition = MySpline.TryGetTransformFromPosition;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            
            if (e.Button == MouseButtons.Right)
            {
                SelectedTransform = TryGetTransformFromPosition(new Vector2(e.X, e.Y));
                if (SelectedTransform != null)
                {
                    BezierSpline.BezierControlPointMode nextMode = MySpline.GetControlPointMode(SelectedTransform.Index).Next();
                    MySpline.SetControlPointMode(SelectedTransform.Index, nextMode);
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (SelectedTransform != null) MySpline.EnforceMode(SelectedTransform.Index);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw()
        {
            base.Draw();

            Editor.spriteBatch.Begin();

            if (MySpline != null) MySpline.DrawSpline(Editor.spriteBatch);

            Editor.spriteBatch.End();
        }
    }
}
