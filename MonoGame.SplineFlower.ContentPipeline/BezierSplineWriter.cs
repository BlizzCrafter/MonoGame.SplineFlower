using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

namespace MonoGame.SplineFlower.ContentPipeline
{
    [ContentTypeWriter]
    public class BezierSplineWriter : ContentTypeWriter<BezierSplineData>
    {
        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return typeof(BezierSplineReader).AssemblyQualifiedName;
        }

        protected override void Write(ContentWriter writer, BezierSplineData input)
        {
            writer.Write(input.SplineMarkerResolution);
            writer.Write(input.SplineWalkerDuration);
            writer.Write(input.Loop);

            writer.WriteObject(input.PointData);
            writer.WriteObject(input.PointModeData);
            writer.WriteObject(input.TriggerData);
            writer.WriteObject(input.TriggerNames);
        }
    }
}
