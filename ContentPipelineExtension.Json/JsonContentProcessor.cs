using Microsoft.Xna.Framework.Content.Pipeline;
using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using TInput = System.String;
using TOutput = ContentPipelineExtension.Json.JsonContentProcessorResult;

namespace ContentPipelineExtension.Json
{
    [ContentProcessor(DisplayName = "Json Processor")]
    internal class JsonContentProcessor : ContentProcessor<TInput, TOutput>
    {
        [DisplayName("Minify JSON")]
        public bool Minify { get; set; } = true;

        [DisplayName("Runtime Type")]
        public string RuntimeType { get; set; } = string.Empty;
       
        public override TOutput Process(TInput input, ContentProcessorContext context)
        {
            if (string.IsNullOrEmpty(RuntimeType))
                throw new Exception("No Runtime Type was specified for this content.");

            if (Minify) 
                input = MinifyJson(input);

            JsonContentProcessorResult result = new();
            result.Json = input;
            result.RuntimeType = RuntimeType;

            return result;
        }

        private static TInput MinifyJson(TInput input)
        {
            JsonWriterOptions options = new()
            {
                Indented = false,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            JsonDocument doc = JsonDocument.Parse(input);

            using MemoryStream stream = new();
            
            using (Utf8JsonWriter writer = new(stream, options))
            {
                doc.WriteTo(writer);
                writer.Flush();
            }

            return Encoding.UTF8.GetString(stream.ToArray());
        }
    }
}
