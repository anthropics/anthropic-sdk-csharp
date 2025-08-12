using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;
using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Models.Beta.Messages.BetaRawMessageDeltaEventProperties;

[JsonConverter(typeof(Anthropic::ModelConverter<Delta>))]
public sealed record class Delta : Anthropic::ModelBase, Anthropic::IFromRaw<Delta>
{
    /// <summary>
    /// Information about the container used in the request (for the code execution tool)
    /// </summary>
    public required Messages::BetaContainer? Container
    {
        get
        {
            if (!this.Properties.TryGetValue("container", out JsonElement element))
                throw new ArgumentOutOfRangeException("container", "Missing required argument");

            return JsonSerializer.Deserialize<Messages::BetaContainer?>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["container"] = JsonSerializer.SerializeToElement(value); }
    }

    public required Messages::BetaStopReason? StopReason
    {
        get
        {
            if (!this.Properties.TryGetValue("stop_reason", out JsonElement element))
                throw new ArgumentOutOfRangeException("stop_reason", "Missing required argument");

            return JsonSerializer.Deserialize<Messages::BetaStopReason?>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["stop_reason"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string? StopSequence
    {
        get
        {
            if (!this.Properties.TryGetValue("stop_sequence", out JsonElement element))
                throw new ArgumentOutOfRangeException("stop_sequence", "Missing required argument");

            return JsonSerializer.Deserialize<string?>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["stop_sequence"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.Container?.Validate();
        this.StopReason?.Validate();
        _ = this.StopSequence;
    }

    public Delta() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Delta(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Delta FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
