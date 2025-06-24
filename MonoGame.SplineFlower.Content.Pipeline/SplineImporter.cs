using Microsoft.Xna.Framework.Content.Pipeline;
using System.Text.Json;

namespace MonoGame.SplineFlower.Content.Pipeline
{
    [ContentImporter(".json", DisplayName = "Spline Importer - MonoGame.SplineFlower", DefaultProcessor = "SplineProcessor")]
    public class SplineImporter : ContentImporter<SplineData>
    {
        public override SplineData Import(string filename, ContentImporterContext context)
        {
            Setup.CreateJsonSerializerOptions();

            string jsonString = File.ReadAllText(filename);
            return new SplineData().Deserialize(jsonString);
        }
    }
}
