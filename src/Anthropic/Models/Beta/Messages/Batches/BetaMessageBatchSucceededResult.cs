using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Messages = Anthropic.Models.Beta.Messages;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Beta.Messages.Batches;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<BetaMessageBatchSucceededResult>))]
public sealed record class BetaMessageBatchSucceededResult
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaMessageBatchSucceededResult>
{
    public required Messages::BetaMessage Message
    {
        get
        {
            if (!this.Properties.TryGetValue("message", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "message",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<Messages::BetaMessage>(element)
                ?? throw new System::ArgumentNullException("message");
        }
        set { this.Properties["message"] = Json::JsonSerializer.SerializeToElement(value); }
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

    public override void Validate()
    {
        this.Message.Validate();
    }

    public BetaMessageBatchSucceededResult()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"succeeded\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BetaMessageBatchSucceededResult(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaMessageBatchSucceededResult FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
