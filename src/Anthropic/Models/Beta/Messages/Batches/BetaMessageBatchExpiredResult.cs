using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;

namespace Anthropic.Models.Beta.Messages.Batches;

[JsonConverter(typeof(Anthropic::ModelConverter<BetaMessageBatchExpiredResult>))]
public sealed record class BetaMessageBatchExpiredResult
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaMessageBatchExpiredResult>
{
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

    public override void Validate() { }

    public BetaMessageBatchExpiredResult()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"expired\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMessageBatchExpiredResult(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaMessageBatchExpiredResult FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
