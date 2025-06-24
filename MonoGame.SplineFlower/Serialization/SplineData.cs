using System.Text.Json;

namespace MonoGame.SplineFlower
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

        public string Serialize()
        {
            return JsonSerializer.Serialize(this, Setup.JsonSerializerOptions);
        }

        public SplineData Deserialize(string jsonContent)
        {
            var data = JsonSerializer.Deserialize<SplineData>(jsonContent, Setup.JsonSerializerOptions);

            if (data.TangentData != null)
            {
                foreach (var tangent in data.TangentData)
                {
                    if (tangent.UserData is JsonElement element)
                    {
                        var tangentData = element.Deserialize<TangentData>();
                        tangent.UserData = tangentData;
                    }
                }
            }

            SplineType = data.SplineType;

            SplineMarkerResolution = data.SplineMarkerResolution;
            SplineWalkerDuration = data.SplineWalkerDuration;
            Loop = data.Loop;

            PointData = data.PointData;
            TangentData = data.TangentData;
            PointModeData = data.PointModeData;
            TriggerData = data.TriggerData;
            TriggerNames = data.TriggerNames;

            return data;
        }
    }
}
