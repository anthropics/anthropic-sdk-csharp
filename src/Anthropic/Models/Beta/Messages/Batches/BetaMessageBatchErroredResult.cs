using Anthropic = Anthropic;
using Beta = Anthropic.Models.Beta;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Beta.Messages.Batches;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<BetaMessageBatchErroredResult>))]
public sealed record class BetaMessageBatchErroredResult
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaMessageBatchErroredResult>
{
    public required Beta::BetaErrorResponse Error
    {
        get
        {
            if (!this.Properties.TryGetValue("error", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("error", "Missing required argument");

            return Json::JsonSerializer.Deserialize<Beta::BetaErrorResponse>(element)
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

    public BetaMessageBatchErroredResult()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"errored\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BetaMessageBatchErroredResult(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaMessageBatchErroredResult FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
