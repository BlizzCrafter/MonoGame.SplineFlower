using Microsoft.Xna.Framework.Content;
using MonoGame.SplineFlower.Spline;
using MonoGame.SplineFlower.Spline.Types;
using System;
using static MonoGame.SplineFlower.Spline.SplineBase;

namespace MonoGame.SplineFlower.Content.Pipeline
{
    public class SplineReader : ContentTypeReader<SplineBase>
    {
        protected override SplineBase Read(ContentReader input, SplineBase existingInstance)
        {
            SplineBase spline = existingInstance;

            Setup.SetSplineMarkerResolution(input.ReadSingle());

            int pointLength = input.ReadInt32();
            Transform[] points = new Transform[pointLength];
            for (int i = 0; i < pointLength; i++)
            {
                points[i] = new Transform(input.ReadVector2());
            }

            int pointModeLength = input.ReadInt32();
            ControlPointMode[] pointModes = new ControlPointMode[pointModeLength];
            for (int i = 0; i < pointModeLength; i++)
            {
                pointModes[i] = (ControlPointMode)Enum.Parse(typeof(ControlPointMode), input.ReadString());
            }

            int triggerLength = input.ReadInt32();
            Trigger[] trigger = new Trigger[triggerLength];
            for (int i = 0; i < triggerLength; i++)
            {
                trigger[i] = new Trigger(
                    input.ReadString(),
                    input.ReadSingle(),
                    input.ReadSingle() * Setup.SplineMarkerResolution,
                    input.ReadString());
            }

            Transform[] tangents = null;
            if (spline.IsHermite)
            {
                int tangentLength = input.ReadInt32();
                tangents = new Transform[tangentLength];
                for (int i = 0; i < tangentLength; i++)
                {
                    tangents[i] = new Transform(input.ReadVector2())
                    {
                        UserData = input.ReadObject<HermiteSpline.TangentData>()
                    };
                }
            }

            spline.LoadSplineData(
                points,
                pointModes,
                trigger,
                tangents);
            
            spline.Loop = input.ReadBoolean();

            return spline;
        }
    }
}
