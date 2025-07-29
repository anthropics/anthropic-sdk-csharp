using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Beta.Messages.Batches;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<BetaMessageBatchCanceledResult>))]
public sealed record class BetaMessageBatchCanceledResult
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaMessageBatchCanceledResult>
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

    public BetaMessageBatchCanceledResult()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"canceled\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BetaMessageBatchCanceledResult(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaMessageBatchCanceledResult FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
