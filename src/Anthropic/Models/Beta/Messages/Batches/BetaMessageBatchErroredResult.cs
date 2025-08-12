using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;
using Beta = Anthropic.Models.Beta;

namespace Anthropic.Models.Beta.Messages.Batches;

[JsonConverter(typeof(Anthropic::ModelConverter<BetaMessageBatchErroredResult>))]
public sealed record class BetaMessageBatchErroredResult
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaMessageBatchErroredResult>
{
    public required Beta::BetaErrorResponse Error
    {
        get
        {
            if (!this.Properties.TryGetValue("error", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "error",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<Beta::BetaErrorResponse>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("error");
        }
        set { this.Properties["error"] = JsonSerializer.SerializeToElement(value); }
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
        this.Error.Validate();
    }

    public BetaMessageBatchErroredResult()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"errored\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMessageBatchErroredResult(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaMessageBatchErroredResult FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public BetaMessageBatchErroredResult(Beta::BetaErrorResponse error)
        : this()
    {
        this.Error = error;
    }
}
