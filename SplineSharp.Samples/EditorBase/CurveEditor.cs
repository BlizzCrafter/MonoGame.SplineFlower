using Microsoft.Xna.Framework;
using System.ComponentModel;

namespace SplineSharp.Samples.EditorBase
{
    public abstract class CurveEditor : TransformControl
    {
        public enum BezierType
        {
            Quadratic,
            Cubic
        }
        [DisplayName("BezierType")]
        [DefaultValue(BezierType.Quadratic)]
        public BezierType GetBezierType { get; set; } = BezierType.Quadratic;

        public BezierCurve MyCurve;

        protected override void Initialize()
        {
            base.Initialize();
            Setup.Initialize(Editor.graphics);

            MyCurve = new BezierCurve();

            if (GetBezierType == BezierType.Cubic) MyCurve.CreateCubic();
            else MyCurve.CreateQuadratic();

            TryGetTransformFromPosition = MyCurve.TryGetTransformFromPosition;
            GetAllPoints = MyCurve.GetAllPoints;
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw()
        {
            base.Draw();

            Editor.spriteBatch.Begin();

            if (MyCurve != null) MyCurve.DrawCurve(Editor.spriteBatch);

            Editor.spriteBatch.End();
        }
    }
}
