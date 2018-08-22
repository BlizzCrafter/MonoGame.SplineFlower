using Microsoft.Xna.Framework.Content;

namespace MonoGame.SplineFlower.ContentPipeline
{
    public class BezierSplineReader : ContentTypeReader<BezierSplineData>
    {
        protected override BezierSplineData Read(ContentReader input, BezierSplineData existingInstance)
        {
            BezierSplineData bezierSpline = new BezierSplineData();

            bezierSpline.SplineMarkerResolution = input.ReadSingle();
            bezierSpline.SplineWalkerDuration = input.ReadInt32();
            bezierSpline.Loop = input.ReadBoolean();

            bezierSpline.PointData = input.ReadObject<TransformDummy[]>();
            bezierSpline.PointModeData = input.ReadObject<BezierControlPointModeDummy[]>();
            bezierSpline.TriggerData = input.ReadObject<TriggerDummy[]>();
            bezierSpline.TriggerNames = input.ReadObject<string[]>();

            return bezierSpline;
        }
    }
}
