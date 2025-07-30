using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Messages = Anthropic.Models.Messages;

namespace Anthropic.Models.Messages.RawMessageDeltaEventProperties;

[JsonConverter(typeof(ModelConverter<Delta>))]
public sealed record class Delta : ModelBase, IFromRaw<Delta>
{
    public required Messages::StopReason? StopReason
    {
        get
        {
            if (!this.Properties.TryGetValue("stop_reason", out JsonElement element))
                throw new ArgumentOutOfRangeException("stop_reason", "Missing required argument");

            return JsonSerializer.Deserialize<Messages::StopReason?>(element);
        }
        set { this.Properties["stop_reason"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string? StopSequence
    {
        get
        {
            if (!this.Properties.TryGetValue("stop_sequence", out JsonElement element))
                throw new ArgumentOutOfRangeException("stop_sequence", "Missing required argument");

            return JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["stop_sequence"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
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
