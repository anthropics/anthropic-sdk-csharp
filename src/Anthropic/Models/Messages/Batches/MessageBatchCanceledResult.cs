using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Messages.Batches;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<MessageBatchCanceledResult>))]
public sealed record class MessageBatchCanceledResult
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<MessageBatchCanceledResult>
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

    public MessageBatchCanceledResult()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"canceled\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    MessageBatchCanceledResult(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MessageBatchCanceledResult FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
