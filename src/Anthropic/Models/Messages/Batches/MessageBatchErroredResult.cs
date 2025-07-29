using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Models = Anthropic.Models;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Messages.Batches;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<MessageBatchErroredResult>))]
public sealed record class MessageBatchErroredResult
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<MessageBatchErroredResult>
{
    public required Models::ErrorResponse Error
    {
        get
        {
            if (!this.Properties.TryGetValue("error", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("error", "Missing required argument");

            return Json::JsonSerializer.Deserialize<Models::ErrorResponse>(element)
                ?? throw new System::ArgumentNullException("error");
        }
        set { this.Properties["error"] = Json::JsonSerializer.SerializeToElement(value); }
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
        this.Error.Validate();
    }

    public MessageBatchErroredResult()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"errored\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    MessageBatchErroredResult(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static MessageBatchErroredResult FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
