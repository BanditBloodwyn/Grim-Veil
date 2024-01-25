using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using Microsoft.Xna.Framework.Content.Pipeline;
using TInput = ContentPipelineExtension.Json.JsonContentProcessorResult;

namespace ContentPipelineExtension.Json;

[ContentTypeWriter]
internal class JsonContentTypeWriter : ContentTypeWriter<TInput>
{
    protected override void Write(ContentWriter output, TInput value)
    {
        output.Write(value.Json);
    }

    public override string GetRuntimeReader(TargetPlatform targetPlatform)
    {
        return "ContentPipeline.Json.JsonContentReader, ContentPipeline.Json";
    }
}