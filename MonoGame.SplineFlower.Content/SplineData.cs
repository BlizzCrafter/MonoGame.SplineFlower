namespace MonoGame.SplineFlower.Content
{
    public class SplineData
    {
        public enum SplineTypeDummy
        {
            Bezier,
            CatMulRom,
            Hermite
        }
        public SplineTypeDummy SplineType;

        public float SplineMarkerResolution;
        public int SplineWalkerDuration;
        public bool Loop;

        public TransformDummy[] PointData;
        public TransformDummy[] TangentData;
        public ControlPointModeDummy[] PointModeData;
        public TriggerDummy[] TriggerData;
        public string[] TriggerNames;
    }
}
