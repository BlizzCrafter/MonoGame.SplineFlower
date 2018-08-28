using Microsoft.Xna.Framework.Content.Pipeline;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;

namespace MonoGame.SplineFlower.Content.Pipeline
{
    [ContentImporter(".json", DisplayName = "Bezier Spline Importer - MonoGame.SplineFlower", DefaultProcessor = "BezierSplineProcessor")]
    public class BezierSplineImporter : ContentImporter<BezierSplineData>
    {
        public override BezierSplineData Import(string filename, ContentImporterContext context)
        {
            using (var streamReader = new StreamReader(filename))
            {
                using (var jsonReader = new JsonTextReader(streamReader))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor;
                    serializer.NullValueHandling = NullValueHandling.Ignore;
                    serializer.DefaultValueHandling = DefaultValueHandling.Include;
                    serializer.TypeNameHandling = TypeNameHandling.Auto;
                    serializer.Converters.Add(new StringEnumConverter());

                    return serializer.Deserialize<BezierSplineData>(jsonReader);
                }
            }
        }
    }
}
