using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Compliance.Review.Items;

/// <summary>
/// An API key.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaComplianceReviewApiActor, BetaComplianceReviewApiActorFromRaw>)
)]
public sealed record class BetaComplianceReviewApiActor : JsonModel
{
    /// <summary>
    /// The ID of the API key (`apikey_...`).
    /// </summary>
    public required string ApiKeyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("api_key_id");
        }
        init { this._rawData.Set("api_key_id", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ApiKeyID;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("api_actor")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaComplianceReviewApiActor()
    {
        this.Type = JsonSerializer.SerializeToElement("api_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComplianceReviewApiActor(BetaComplianceReviewApiActor betaComplianceReviewApiActor)
        : base(betaComplianceReviewApiActor) { }
#pragma warning restore CS8618

    public BetaComplianceReviewApiActor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("api_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComplianceReviewApiActor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComplianceReviewApiActorFromRaw.FromRawUnchecked"/>
    public static BetaComplianceReviewApiActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaComplianceReviewApiActor(string apiKeyID)
        : this()
    {
        this.ApiKeyID = apiKeyID;
    }
}

class BetaComplianceReviewApiActorFromRaw : IFromRawJson<BetaComplianceReviewApiActor>
{
    /// <inheritdoc/>
    public BetaComplianceReviewApiActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComplianceReviewApiActor.FromRawUnchecked(rawData);
}
