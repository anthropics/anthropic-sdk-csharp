using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Messages.Batches;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<MessageBatchExpiredResult>))]
public sealed record class MessageBatchExpiredResult
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<MessageBatchExpiredResult>
{
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

    public override void Validate() { }

    public MessageBatchExpiredResult()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"expired\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    MessageBatchExpiredResult(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MessageBatchExpiredResult FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
