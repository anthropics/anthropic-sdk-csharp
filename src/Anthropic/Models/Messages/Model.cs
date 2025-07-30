using System.Text.Json.Serialization;

namespace Anthropic.Models.Messages;

/// <summary>
/// The model that will complete your prompt.\n\nSee [models](https://docs.anthropic.com/en/docs/models-overview)
/// for additional details and options.
/// </summary>
[JsonConverter(typeof(EnumConverter<Model, string>))]
public sealed record class Model(string value) : IEnum<Model, string>
{
    /// <summary>
    /// High-performance model with early extended thinking
    /// </summary>
    public static readonly Model Claude3_7SonnetLatest = new("claude-3-7-sonnet-latest");

    /// <summary>
    /// High-performance model with early extended thinking
    /// </summary>
    public static readonly Model Claude3_7Sonnet20250219 = new("claude-3-7-sonnet-20250219");

    /// <summary>
    /// Fastest and most compact model for near-instant responsiveness
    /// </summary>
    public static readonly Model Claude3_5HaikuLatest = new("claude-3-5-haiku-latest");

    /// <summary>
    /// Our fastest model
    /// </summary>
    public static readonly Model Claude3_5Haiku20241022 = new("claude-3-5-haiku-20241022");

    /// <summary>
    /// High-performance model with extended thinking
    /// </summary>
    public static readonly Model ClaudeSonnet4_20250514 = new("claude-sonnet-4-20250514");

    /// <summary>
    /// High-performance model with extended thinking
    /// </summary>
    public static readonly Model ClaudeSonnet4_0 = new("claude-sonnet-4-0");

    /// <summary>
    /// High-performance model with extended thinking
    /// </summary>
    public static readonly Model Claude4Sonnet20250514 = new("claude-4-sonnet-20250514");

    /// <summary>
    /// Our previous most intelligent model
    /// </summary>
    public static readonly Model Claude3_5SonnetLatest = new("claude-3-5-sonnet-latest");

    /// <summary>
    /// Our previous most intelligent model
    /// </summary>
    public static readonly Model Claude3_5Sonnet20241022 = new("claude-3-5-sonnet-20241022");

    public static readonly Model Claude_3_5_Sonnet_20240620 = new("claude-3-5-sonnet-20240620");

    /// <summary>
    /// Our most capable model
    /// </summary>
    public static readonly Model ClaudeOpus4_0 = new("claude-opus-4-0");

    /// <summary>
    /// Our most capable model
    /// </summary>
    public static readonly Model ClaudeOpus4_20250514 = new("claude-opus-4-20250514");

    /// <summary>
    /// Our most capable model
    /// </summary>
    public static readonly Model Claude4Opus20250514 = new("claude-4-opus-20250514");

    /// <summary>
    /// Excels at writing and complex tasks
    /// </summary>
    public static readonly Model Claude3OpusLatest = new("claude-3-opus-latest");

    /// <summary>
    /// Excels at writing and complex tasks
    /// </summary>
    public static readonly Model Claude_3_Opus_20240229 = new("claude-3-opus-20240229");

    /// <summary>
    /// Our previous most fast and cost-effective
    /// </summary>
    public static readonly Model Claude_3_Haiku_20240307 = new("claude-3-haiku-20240307");

    readonly string _value = value;

    public enum Value
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
        /// Our previous most intelligent model
        /// </summary>
        Claude3_5SonnetLatest,

        /// <summary>
        /// Our previous most intelligent model
        /// </summary>
        Claude3_5Sonnet20241022,
        Claude_3_5_Sonnet_20240620,

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

    public Value Known() =>
        _value switch
        {
            "claude-3-7-sonnet-latest" => Value.Claude3_7SonnetLatest,
            "claude-3-7-sonnet-20250219" => Value.Claude3_7Sonnet20250219,
            "claude-3-5-haiku-latest" => Value.Claude3_5HaikuLatest,
            "claude-3-5-haiku-20241022" => Value.Claude3_5Haiku20241022,
            "claude-sonnet-4-20250514" => Value.ClaudeSonnet4_20250514,
            "claude-sonnet-4-0" => Value.ClaudeSonnet4_0,
            "claude-4-sonnet-20250514" => Value.Claude4Sonnet20250514,
            "claude-3-5-sonnet-latest" => Value.Claude3_5SonnetLatest,
            "claude-3-5-sonnet-20241022" => Value.Claude3_5Sonnet20241022,
            "claude-3-5-sonnet-20240620" => Value.Claude_3_5_Sonnet_20240620,
            "claude-opus-4-0" => Value.ClaudeOpus4_0,
            "claude-opus-4-20250514" => Value.ClaudeOpus4_20250514,
            "claude-4-opus-20250514" => Value.Claude4Opus20250514,
            "claude-3-opus-latest" => Value.Claude3OpusLatest,
            "claude-3-opus-20240229" => Value.Claude_3_Opus_20240229,
            "claude-3-haiku-20240307" => Value.Claude_3_Haiku_20240307,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(_value)),
        };

    public string Raw()
    {
        return _value;
    }

    public void Validate()
    {
        Known();
    }

    public static Model FromRaw(string value)
    {
        return new(value);
    }
}
