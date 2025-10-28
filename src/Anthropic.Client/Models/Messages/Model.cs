using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Messages;

/// <summary>
/// The model that will complete your prompt.\n\nSee [models](https://docs.anthropic.com/en/docs/models-overview)
/// for additional details and options.
/// </summary>
[JsonConverter(typeof(ModelConverter1))]
public enum Model
{
    /// <summary>
    /// High-performance model with early extended thinking
    /// </summary>
    Claude3_7SonnetLatest,

    /// <summary>
    /// High-performance model with early extended thinking
    /// </summary>
    Claude3_7Sonnet20250219,

    /// <summary>
    /// Fastest and most compact model for near-instant responsiveness
    /// </summary>
    Claude3_5HaikuLatest,

    /// <summary>
    /// Our fastest model
    /// </summary>
    Claude3_5Haiku20241022,

    /// <summary>
    /// Hybrid model, capable of near-instant responses and extended thinking
    /// </summary>
    ClaudeHaiku4_5,

    /// <summary>
    /// Hybrid model, capable of near-instant responses and extended thinking
    /// </summary>
    ClaudeHaiku4_5_20251001,

    /// <summary>
    /// High-performance model with extended thinking
    /// </summary>
    ClaudeSonnet4_20250514,

    /// <summary>
    /// High-performance model with extended thinking
    /// </summary>
    ClaudeSonnet4_0,

    /// <summary>
    /// High-performance model with extended thinking
    /// </summary>
    Claude4Sonnet20250514,

    /// <summary>
    /// Our best model for real-world agents and coding
    /// </summary>
    ClaudeSonnet4_5,

    /// <summary>
    /// Our best model for real-world agents and coding
    /// </summary>
    ClaudeSonnet4_5_20250929,

    /// <summary>
    /// Our most capable model
    /// </summary>
    ClaudeOpus4_0,

    /// <summary>
    /// Our most capable model
    /// </summary>
    ClaudeOpus4_20250514,

    /// <summary>
    /// Our most capable model
    /// </summary>
    Claude4Opus20250514,

    /// <summary>
    /// Our most capable model
    /// </summary>
    ClaudeOpus4_1_20250805,

    /// <summary>
    /// Excels at writing and complex tasks
    /// </summary>
    Claude3OpusLatest,

    /// <summary>
    /// Excels at writing and complex tasks
    /// </summary>
    Claude_3_Opus_20240229,

    /// <summary>
    /// Our previous most fast and cost-effective
    /// </summary>
    Claude_3_Haiku_20240307,
}

sealed class ModelConverter1 : JsonConverter<Model>
{
    public override Model Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "claude-3-7-sonnet-latest" => Model.Claude3_7SonnetLatest,
            "claude-3-7-sonnet-20250219" => Model.Claude3_7Sonnet20250219,
            "claude-3-5-haiku-latest" => Model.Claude3_5HaikuLatest,
            "claude-3-5-haiku-20241022" => Model.Claude3_5Haiku20241022,
            "claude-haiku-4-5" => Model.ClaudeHaiku4_5,
            "claude-haiku-4-5-20251001" => Model.ClaudeHaiku4_5_20251001,
            "claude-sonnet-4-20250514" => Model.ClaudeSonnet4_20250514,
            "claude-sonnet-4-0" => Model.ClaudeSonnet4_0,
            "claude-4-sonnet-20250514" => Model.Claude4Sonnet20250514,
            "claude-sonnet-4-5" => Model.ClaudeSonnet4_5,
            "claude-sonnet-4-5-20250929" => Model.ClaudeSonnet4_5_20250929,
            "claude-opus-4-0" => Model.ClaudeOpus4_0,
            "claude-opus-4-20250514" => Model.ClaudeOpus4_20250514,
            "claude-4-opus-20250514" => Model.Claude4Opus20250514,
            "claude-opus-4-1-20250805" => Model.ClaudeOpus4_1_20250805,
            "claude-3-opus-latest" => Model.Claude3OpusLatest,
            "claude-3-opus-20240229" => Model.Claude_3_Opus_20240229,
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
                Model.Claude3_7SonnetLatest => "claude-3-7-sonnet-latest",
                Model.Claude3_7Sonnet20250219 => "claude-3-7-sonnet-20250219",
                Model.Claude3_5HaikuLatest => "claude-3-5-haiku-latest",
                Model.Claude3_5Haiku20241022 => "claude-3-5-haiku-20241022",
                Model.ClaudeHaiku4_5 => "claude-haiku-4-5",
                Model.ClaudeHaiku4_5_20251001 => "claude-haiku-4-5-20251001",
                Model.ClaudeSonnet4_20250514 => "claude-sonnet-4-20250514",
                Model.ClaudeSonnet4_0 => "claude-sonnet-4-0",
                Model.Claude4Sonnet20250514 => "claude-4-sonnet-20250514",
                Model.ClaudeSonnet4_5 => "claude-sonnet-4-5",
                Model.ClaudeSonnet4_5_20250929 => "claude-sonnet-4-5-20250929",
                Model.ClaudeOpus4_0 => "claude-opus-4-0",
                Model.ClaudeOpus4_20250514 => "claude-opus-4-20250514",
                Model.Claude4Opus20250514 => "claude-4-opus-20250514",
                Model.ClaudeOpus4_1_20250805 => "claude-opus-4-1-20250805",
                Model.Claude3OpusLatest => "claude-3-opus-latest",
                Model.Claude_3_Opus_20240229 => "claude-3-opus-20240229",
                Model.Claude_3_Haiku_20240307 => "claude-3-haiku-20240307",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
