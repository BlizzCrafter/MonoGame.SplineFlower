using Microsoft.Xna.Framework.Content.Pipeline;
using MonoGame.SplineFlower.Spline;
using MonoGame.SplineFlower.Spline.Types;

namespace MonoGame.SplineFlower.Content.Pipeline
{
    [ContentProcessor(DisplayName = "Spline Processor - MonoGame.SplineFlower")]
    public class SplineProcessor : ContentProcessor<SplineData, SplineBase>
    {
        public override SplineBase Process(SplineData input, ContentProcessorContext context)
        {
            SplineBase spline = null;

            if (input.SplineType == SplineData.SplineTypeDummy.Bezier) spline = new BezierSpline();
            else if (input.SplineType == SplineData.SplineTypeDummy.CatMulRom) spline = new CatMulRomSpline();
            else if (input.SplineType == SplineData.SplineTypeDummy.Hermite) spline = new HermiteSpline();
            
            spline.Loop = input.Loop;

            spline.LoadJsonSplineData(
                input.PointData,
                input.PointModeData,
                input.TriggerData,
                input.TangentData);

            return spline;
        }
    }
}
