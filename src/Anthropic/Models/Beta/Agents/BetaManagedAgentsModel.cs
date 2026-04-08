using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// The model that will power your agent.\n\nSee [models](https://docs.anthropic.com/en/docs/models-overview)
/// for additional details and options.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsModelConverter))]
public enum BetaManagedAgentsModel
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
}

sealed class BetaManagedAgentsModelConverter : JsonConverter<BetaManagedAgentsModel>
{
    public override BetaManagedAgentsModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "claude-opus-4-6" => BetaManagedAgentsModel.ClaudeOpus4_6,
            "claude-sonnet-4-6" => BetaManagedAgentsModel.ClaudeSonnet4_6,
            "claude-haiku-4-5" => BetaManagedAgentsModel.ClaudeHaiku4_5,
            "claude-haiku-4-5-20251001" => BetaManagedAgentsModel.ClaudeHaiku4_5_20251001,
            "claude-opus-4-5" => BetaManagedAgentsModel.ClaudeOpus4_5,
            "claude-opus-4-5-20251101" => BetaManagedAgentsModel.ClaudeOpus4_5_20251101,
            "claude-sonnet-4-5" => BetaManagedAgentsModel.ClaudeSonnet4_5,
            "claude-sonnet-4-5-20250929" => BetaManagedAgentsModel.ClaudeSonnet4_5_20250929,
            _ => (BetaManagedAgentsModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsModel.ClaudeOpus4_6 => "claude-opus-4-6",
                BetaManagedAgentsModel.ClaudeSonnet4_6 => "claude-sonnet-4-6",
                BetaManagedAgentsModel.ClaudeHaiku4_5 => "claude-haiku-4-5",
                BetaManagedAgentsModel.ClaudeHaiku4_5_20251001 => "claude-haiku-4-5-20251001",
                BetaManagedAgentsModel.ClaudeOpus4_5 => "claude-opus-4-5",
                BetaManagedAgentsModel.ClaudeOpus4_5_20251101 => "claude-opus-4-5-20251101",
                BetaManagedAgentsModel.ClaudeSonnet4_5 => "claude-sonnet-4-5",
                BetaManagedAgentsModel.ClaudeSonnet4_5_20250929 => "claude-sonnet-4-5-20250929",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
