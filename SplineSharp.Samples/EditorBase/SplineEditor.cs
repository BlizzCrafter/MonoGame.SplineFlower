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
