using Microsoft.Xna.Framework.Content.Pipeline;

namespace MonoGame.SplineFlower.ContentPipeline
{
    [ContentProcessor(DisplayName = "Bezier Spline Processor - MonoGame.SplineFlower")]
    public class BezierSplineProcessor : ContentProcessor<BezierSplineData, BezierSplineData>
    {
        public override BezierSplineData Process(BezierSplineData input, ContentProcessorContext context)
        {
            return input;
        }
    }
}
