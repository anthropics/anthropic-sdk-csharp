using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ThreadUnsupportedFeatureNameConverter))]
public enum ThreadUnsupportedFeatureName
{
    CacheControl = 0,
    ContextManagement = 1,
    Fallbacks = 2,
    Hipaa = 3,
    InferenceHooks = 4,
    Thinking = 5,
}

sealed class ThreadUnsupportedFeatureNameConverter : JsonConverter<ThreadUnsupportedFeatureName>
{
    public override ThreadUnsupportedFeatureName Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cache_control" => ThreadUnsupportedFeatureName.CacheControl,
            "context_management" => ThreadUnsupportedFeatureName.ContextManagement,
            "fallbacks" => ThreadUnsupportedFeatureName.Fallbacks,
            "hipaa" => ThreadUnsupportedFeatureName.Hipaa,
            "inference_hooks" => ThreadUnsupportedFeatureName.InferenceHooks,
            "thinking" => ThreadUnsupportedFeatureName.Thinking,
            _ => (ThreadUnsupportedFeatureName)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ThreadUnsupportedFeatureName value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ThreadUnsupportedFeatureName.CacheControl => "cache_control",
                ThreadUnsupportedFeatureName.ContextManagement => "context_management",
                ThreadUnsupportedFeatureName.Fallbacks => "fallbacks",
                ThreadUnsupportedFeatureName.Hipaa => "hipaa",
                ThreadUnsupportedFeatureName.InferenceHooks => "inference_hooks",
                ThreadUnsupportedFeatureName.Thinking => "thinking",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
