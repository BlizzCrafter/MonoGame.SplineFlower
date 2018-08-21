using Microsoft.Xna.Framework;

namespace MonoGame.SplineFlower.Editor
{
    public class JsonHandling
    {
        public class BezierSplineData
        {
            public float SplineMarkerResolution;

            public TransformDummy[] PointData;
            public BezierControlPointModeDummy[] PointModeData;
            public TriggerDummy[] TriggerData;
        }

        public class TransformDummy
        {
            public Vector2 Position { get; set; } = Vector2.Zero;
            public int Index { get; set; } = -1;

            public TransformDummy(int index, Vector2 position)
            {
                Index = index;
                Position = position;
            }
            protected TransformDummy() { }
        }

        public class BezierControlPointModeDummy
        {
            public string Mode { get; set; }

            public BezierControlPointModeDummy(string mode)
            {
                Mode = mode;
            }
            protected BezierControlPointModeDummy() { }
        }

        public class TriggerDummy
        {
            public string Name { get; set; } = "";
            public string ID { get; set; }
            public float Progress { get; set; } = -999;
            public float TriggerRange { get; set; } = 3;

            public TriggerDummy(string name, string id, float progress, float triggerRange)
            {
                Name = name;
                ID = id;
                Progress = progress;
                TriggerRange = triggerRange;
            }
            protected TriggerDummy() { }
        }

        public BezierSplineData GetBezierSplineData;

        public JsonHandling()
        {
        }
    }
}
