using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

/// <summary>
/// The model that will complete your prompt.\n\nSee [models](https://docs.anthropic.com/en/docs/models-overview)
/// for additional details and options.
/// </summary>
[JsonConverter(typeof(ModelConverter))]
public enum Model
{
    /// <summary>
    /// Most intelligent model for building agents and coding
    /// </summary>
    ClaudeOpus4_6,

    /// <summary>
    /// Best combination of speed and intelligence
    /// </summary>
    ClaudeSonnet4_6,

    /// <summary>
    /// Fastest model with near-frontier intelligence
    /// </summary>
    ClaudeHaiku4_5,

    /// <summary>
    /// Fastest model with near-frontier intelligence
    /// </summary>
    ClaudeHaiku4_5_20251001,

    /// <summary>
    /// Premium model combining maximum intelligence with practical performance
    /// </summary>
    ClaudeOpus4_5,

    /// <summary>
    /// Premium model combining maximum intelligence with practical performance
    /// </summary>
    ClaudeOpus4_5_20251101,

    /// <summary>
    /// High-performance model for agents and coding
    /// </summary>
    ClaudeSonnet4_5,

    /// <summary>
    /// High-performance model for agents and coding
    /// </summary>
    ClaudeSonnet4_5_20250929,

    /// <summary>
    /// Exceptional model for specialized complex tasks
    /// </summary>
    ClaudeOpus4_1,

    /// <summary>
    /// Exceptional model for specialized complex tasks
    /// </summary>
    ClaudeOpus4_1_20250805,

    /// <summary>
    /// Powerful model for complex tasks
    /// </summary>
    ClaudeOpus4_0,

    /// <summary>
    /// Powerful model for complex tasks
    /// </summary>
    ClaudeOpus4_20250514,

    /// <summary>
    /// High-performance model with extended thinking
    /// </summary>
    ClaudeSonnet4_0,

    /// <summary>
    /// High-performance model with extended thinking
    /// </summary>
    ClaudeSonnet4_20250514,

    /// <summary>
    /// Fast and cost-effective model
    /// </summary>
    [System::Obsolete(
        "Will reach end-of-life on April 20th, 2026. Please migrate to claude-haiku-4-5. Visit https://docs.anthropic.com/en/docs/resources/model-deprecations for more information."
    )]
    Claude_3_Haiku_20240307,
}

sealed class ModelConverter : JsonConverter<Model>
{
    public override Model Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "claude-opus-4-6" => Model.ClaudeOpus4_6,
            "claude-sonnet-4-6" => Model.ClaudeSonnet4_6,
            "claude-haiku-4-5" => Model.ClaudeHaiku4_5,
            "claude-haiku-4-5-20251001" => Model.ClaudeHaiku4_5_20251001,
            "claude-opus-4-5" => Model.ClaudeOpus4_5,
            "claude-opus-4-5-20251101" => Model.ClaudeOpus4_5_20251101,
            "claude-sonnet-4-5" => Model.ClaudeSonnet4_5,
            "claude-sonnet-4-5-20250929" => Model.ClaudeSonnet4_5_20250929,
            "claude-opus-4-1" => Model.ClaudeOpus4_1,
            "claude-opus-4-1-20250805" => Model.ClaudeOpus4_1_20250805,
            "claude-opus-4-0" => Model.ClaudeOpus4_0,
            "claude-opus-4-20250514" => Model.ClaudeOpus4_20250514,
            "claude-sonnet-4-0" => Model.ClaudeSonnet4_0,
            "claude-sonnet-4-20250514" => Model.ClaudeSonnet4_20250514,
            "claude-3-haiku-20240307" => Model.Claude_3_Haiku_20240307,
            _ => (Model)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Model value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Model.ClaudeOpus4_6 => "claude-opus-4-6",
                Model.ClaudeSonnet4_6 => "claude-sonnet-4-6",
                Model.ClaudeHaiku4_5 => "claude-haiku-4-5",
                Model.ClaudeHaiku4_5_20251001 => "claude-haiku-4-5-20251001",
                Model.ClaudeOpus4_5 => "claude-opus-4-5",
                Model.ClaudeOpus4_5_20251101 => "claude-opus-4-5-20251101",
                Model.ClaudeSonnet4_5 => "claude-sonnet-4-5",
                Model.ClaudeSonnet4_5_20250929 => "claude-sonnet-4-5-20250929",
                Model.ClaudeOpus4_1 => "claude-opus-4-1",
                Model.ClaudeOpus4_1_20250805 => "claude-opus-4-1-20250805",
                Model.ClaudeOpus4_0 => "claude-opus-4-0",
                Model.ClaudeOpus4_20250514 => "claude-opus-4-20250514",
                Model.ClaudeSonnet4_0 => "claude-sonnet-4-0",
                Model.ClaudeSonnet4_20250514 => "claude-sonnet-4-20250514",
                Model.Claude_3_Haiku_20240307 => "claude-3-haiku-20240307",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
