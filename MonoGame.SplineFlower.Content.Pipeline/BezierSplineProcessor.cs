using Microsoft.Xna.Framework.Content.Pipeline;

namespace MonoGame.SplineFlower.Content.Pipeline
{
    [ContentProcessor(DisplayName = "Bezier Spline Processor - MonoGame.SplineFlower")]
    public class BezierSplineProcessor : ContentProcessor<BezierSplineData, BezierSpline>
    {
        public override BezierSpline Process(BezierSplineData input, ContentProcessorContext context)
        {
            BezierSpline bezierSpline = new BezierSpline();

            bezierSpline.LoadJsonBezierSplineData(
                input.PointData,
                input.PointModeData,
                input.TriggerData);

            bezierSpline.Loop = input.Loop;

            return bezierSpline;
        }
    }
}
