using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using RawMessageDeltaEventProperties = Anthropic.Models.Messages.RawMessageDeltaEventProperties;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<RawMessageDeltaEvent>))]
public sealed record class RawMessageDeltaEvent
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<RawMessageDeltaEvent>
{
    public required RawMessageDeltaEventProperties::Delta Delta
    {
        get
        {
            if (!this.Properties.TryGetValue("delta", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("delta", "Missing required argument");

            return Json::JsonSerializer.Deserialize<RawMessageDeltaEventProperties::Delta>(element)
                ?? throw new System::ArgumentNullException("delta");
        }
        set { this.Properties["delta"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public Json::JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("type", "Missing required argument");

            return Json::JsonSerializer.Deserialize<Json::JsonElement>(element);
        }
        set { this.Properties["type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Billing and rate-limit usage.
    ///
    /// Anthropic's API bills and rate-limits by token counts, as tokens represent
    /// the underlying cost to our systems.
    ///
    /// Under the hood, the API transforms requests into a format suitable for the
    /// model. The model's output then goes through a parsing stage before becoming
    /// an API response. As a result, the token counts in `usage` will not match one-to-one
    /// with the exact visible content of an API request or response.
    ///
    /// For example, `output_tokens` will be non-zero, even for an empty string response
    /// from Claude.
    ///
    /// Total input tokens in a request is the summation of `input_tokens`, `cache_creation_input_tokens`,
    /// and `cache_read_input_tokens`.
    /// </summary>
    public required MessageDeltaUsage Usage
    {
        get
        {
            if (!this.Properties.TryGetValue("usage", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("usage", "Missing required argument");

            return Json::JsonSerializer.Deserialize<MessageDeltaUsage>(element)
                ?? throw new System::ArgumentNullException("usage");
        }
        set { this.Properties["usage"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.Delta.Validate();
        this.Usage.Validate();
    }

    public RawMessageDeltaEvent()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"message_delta\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    RawMessageDeltaEvent(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static RawMessageDeltaEvent FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
