using Microsoft.Xna.Framework.Content.Pipeline;

namespace Content.Importers
{
    [ContentImporter(".json", DisplayName = "JSON Importer", DefaultProcessor = "PassThroughProcessor")]
    public class JSONImporter : ContentImporter<string>
    {
        public override string Import(string filename, ContentImporterContext context)
        {
            try
            {
                string content = File.ReadAllText(filename);
                return content;
            }
            catch (Exception ex)
            {
                context.Logger.LogMessage("Fehler beim Importieren von {0}: {1}", filename, ex.Message);
                throw;
            }
        }
    }
}
