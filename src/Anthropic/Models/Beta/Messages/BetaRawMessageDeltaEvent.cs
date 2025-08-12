using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;
using BetaRawMessageDeltaEventProperties = Anthropic.Models.Beta.Messages.BetaRawMessageDeltaEventProperties;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(Anthropic::ModelConverter<BetaRawMessageDeltaEvent>))]
public sealed record class BetaRawMessageDeltaEvent
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaRawMessageDeltaEvent>
{
    public required BetaRawMessageDeltaEventProperties::Delta Delta
    {
        get
        {
            if (!this.Properties.TryGetValue("delta", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "delta",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<BetaRawMessageDeltaEventProperties::Delta>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("delta");
        }
        set { this.Properties["delta"] = JsonSerializer.SerializeToElement(value); }
    }

    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "type",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<JsonElement>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["type"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Billing and rate-limit usage.
    ///
    /// Anthropic's API bills and rate-limits by token counts, as tokens represent
    /// the underlying cost to our systems.
    ///
    /// Under the hood, the API transforms requests into a format suitable for the
    /// model. The model's output then goes through a parsing stage before becoming
    /// an API response. As a result, the token counts in `usage` will not match
    /// one-to-one with the exact visible content of an API request or response.
    ///
    /// For example, `output_tokens` will be non-zero, even for an empty string response
    /// from Claude.
    ///
    /// Total input tokens in a request is the summation of `input_tokens`, `cache_creation_input_tokens`,
    /// and `cache_read_input_tokens`.
    /// </summary>
    public required BetaMessageDeltaUsage Usage
    {
        get
        {
            if (!this.Properties.TryGetValue("usage", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "usage",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<BetaMessageDeltaUsage>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("usage");
        }
        set { this.Properties["usage"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.Delta.Validate();
        this.Usage.Validate();
    }

    public BetaRawMessageDeltaEvent()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"message_delta\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRawMessageDeltaEvent(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaRawMessageDeltaEvent FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
