using System.Windows.Forms;
using Microsoft.Xna.Framework;

namespace SplineSharp.Samples.EditorBase
{
    public abstract class SplineEditor : TransformControl
    {
        public BezierSpline MySpline;
        public SpriteMan MySplineWalker;

        protected override void Initialize()
        {
            base.Initialize();
            Setup.Initialize(Editor.graphics);

            MySpline = new BezierSpline();
            MySpline.Reset();
            TryGetTransformFromPosition = MySpline.TryGetTransformFromPosition;
            MovePointDiff += SplineEditor_MovePointDiff;

            MySplineWalker = new SpriteMan();
            MySplineWalker.CreateSplineWalker(MySpline, 7f);
        }

        private void SplineEditor_MovePointDiff(Vector2 obj)
        {
            MySpline.MoveAxis(SelectedTransform.Index, obj);
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

            if (MySplineWalker != null && MySplineWalker.Initialized) MySplineWalker.Update(gameTime);
        }

        protected override void Draw()
        {
            base.Draw();

            Editor.spriteBatch.Begin();

            if (MySpline != null) MySpline.DrawSpline(Editor.spriteBatch);
            if (MySplineWalker != null && MySplineWalker.Initialized)
            {
                MySplineWalker.Draw(Editor.spriteBatch);

                Editor.spriteBatch.DrawString(Editor.Font, MySplineWalker._Velocity.ToString(), new Vector2(100, 100), Color.White);
            }
            Editor.spriteBatch.End();
        }
    }
}
