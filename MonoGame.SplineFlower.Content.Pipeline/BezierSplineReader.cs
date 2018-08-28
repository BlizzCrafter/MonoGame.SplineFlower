using Microsoft.Xna.Framework.Content;
using System;

namespace MonoGame.SplineFlower.Content.Pipeline
{
    public class BezierSplineReader : ContentTypeReader<BezierSpline>
    {
        protected override BezierSpline Read(ContentReader input, BezierSpline existingInstance)
        {
            BezierSpline bezierSpline = new BezierSpline();

            Setup.SplineMarkerResolution = input.ReadSingle();

            int pointLength = input.ReadInt32();
            Transform[] points = new Transform[pointLength];
            for (int i = 0; i < pointLength; i++)
            {
                points[i] = new Transform(input.ReadVector2());
            }

            int pointModeLength = input.ReadInt32();
            BezierSpline.BezierControlPointMode[] pointModes = new BezierSpline.BezierControlPointMode[pointModeLength];
            for (int i = 0; i < pointModeLength; i++)
            {
                pointModes[i] = (BezierSpline.BezierControlPointMode)Enum.Parse(typeof(BezierSpline.BezierControlPointMode), input.ReadString());
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

            bezierSpline.LoadBezierSplineData(
                points,
                pointModes,
                trigger);

            bezierSpline.Loop = input.ReadBoolean();

            return bezierSpline;
        }
    }
}
