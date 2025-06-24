using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using MonoGame.SplineFlower.Spline;
using MonoGame.SplineFlower.Spline.Types;
using static MonoGame.SplineFlower.Spline.SplineBase;

namespace MonoGame.SplineFlower.Content.Pipeline
{
    [ContentTypeWriter]
    public class SplineWriter : ContentTypeWriter<SplineBase>
    {
        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return typeof(SplineReader).AssemblyQualifiedName;
        }

        protected override void Write(ContentWriter writer, SplineBase input)
        {
            writer.Write(Setup.SplineMarkerResolution);

            Transform[] points = input.GetAllPoints;
            writer.Write(points.Length);
            for (int i = 0; i < points.Length; i++)
            {
                writer.Write(points[i].Position);
            }

            ControlPointMode[] pointModes = input.GetAllPointModes;
            writer.Write(pointModes.Length);
            for (int i = 0; i < pointModes.Length; i++)
            {
                writer.Write(pointModes[i].ToString());
            }

            Trigger[] trigger = input.GetAllTrigger.ToArray();
            writer.Write(trigger.Length);
            for (int i = 0; i < trigger.Length; i++)
            {
                writer.Write(trigger[i].Name);
                writer.Write(trigger[i].GetPlainProgress);
                writer.Write(trigger[i].TriggerRange);
                writer.Write(trigger[i].ID.ToString());
            }
                        
            if (input.IsHermite)
            {
                Transform[] tangents = ((HermiteSpline)input).GetAllTangents;
                writer.Write(tangents.Length);
                for (int i = 0; i < tangents.Length; i++)
                {
                    writer.Write(tangents[i].Position);
                    writer.WriteObject(tangents[i].UserData as TangentData);
                }
            }

            writer.Write(input.Loop);
        }
    }
}
