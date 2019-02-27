namespace MonoGame.SplineFlower.Content
{
    public class BezierSplineData
    {
        public float SplineMarkerResolution;
        public int SplineWalkerDuration;
        public bool Loop;
        public bool CatMulRom;

        public TransformDummy[] PointData;
        public BezierControlPointModeDummy[] PointModeData;
        public TriggerDummy[] TriggerData;
        public string[] TriggerNames;
    }
}
