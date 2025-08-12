using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;
using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Models.Beta.Messages.Batches;

[JsonConverter(typeof(Anthropic::ModelConverter<BetaMessageBatchSucceededResult>))]
public sealed record class BetaMessageBatchSucceededResult
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaMessageBatchSucceededResult>
{
    public required Messages::BetaMessage Message
    {
        get
        {
            if (!this.Properties.TryGetValue("message", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "message",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<Messages::BetaMessage>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("message");
        }
        set { this.Properties["message"] = JsonSerializer.SerializeToElement(value); }
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

    public override void Validate()
    {
        this.Message.Validate();
    }

    public BetaMessageBatchSucceededResult()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"succeeded\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMessageBatchSucceededResult(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaMessageBatchSucceededResult FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public BetaMessageBatchSucceededResult(Messages::BetaMessage message)
        : this()
    {
        this.Message = message;
    }
}
