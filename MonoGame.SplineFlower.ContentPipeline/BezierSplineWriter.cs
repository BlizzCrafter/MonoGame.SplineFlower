using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using MonoGame.SplineFlower.Content;

namespace MonoGame.SplineFlower.ContentPipeline
{
    [ContentTypeWriter]
    public class BezierSplineWriter : ContentTypeWriter<BezierSpline>
    {
        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return typeof(BezierSplineReader).AssemblyQualifiedName;
        }

        protected override void Write(ContentWriter writer, BezierSpline input)
        {
            writer.Write(Setup.SplineMarkerResolution);

            Transform[] points = input.GetAllPoints();
            writer.Write(points.Length);
            for (int i = 0; i < points.Length; i++)
            {
                writer.Write(points[i].Position);
            }

            BezierSpline.BezierControlPointMode[] pointModes = input.GetAllPointModes();
            writer.Write(pointModes.Length);
            for (int i = 0; i < pointModes.Length; i++)
            {
                writer.Write(pointModes[i].ToString());
            }

            Trigger[] trigger = input.GetAllTrigger().ToArray();
            writer.Write(trigger.Length);
            for (int i = 0; i < trigger.Length; i++)
            {
                writer.Write(trigger[i].Name);
                writer.Write(trigger[i].Progress);
                writer.Write(trigger[i].TriggerRange);
                writer.Write(trigger[i].ID.ToString());
            }

            writer.Write(input.Loop);
        }
    }
}
