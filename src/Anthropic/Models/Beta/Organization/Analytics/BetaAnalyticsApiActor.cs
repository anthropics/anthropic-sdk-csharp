using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics;

[JsonConverter(typeof(JsonModelConverter<BetaAnalyticsApiActor, BetaAnalyticsApiActorFromRaw>))]
public sealed record class BetaAnalyticsApiActor : JsonModel
{
    /// <summary>
    /// Tagged API key ID.
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

    public BetaAnalyticsApiActor()
    {
        this.Type = JsonSerializer.SerializeToElement("api_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsApiActor(BetaAnalyticsApiActor betaAnalyticsApiActor)
        : base(betaAnalyticsApiActor) { }
#pragma warning restore CS8618

    public BetaAnalyticsApiActor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("api_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsApiActor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsApiActorFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsApiActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaAnalyticsApiActor(string apiKeyID)
        : this()
    {
        this.ApiKeyID = apiKeyID;
    }
}

class BetaAnalyticsApiActorFromRaw : IFromRawJson<BetaAnalyticsApiActor>
{
    /// <inheritdoc/>
    public BetaAnalyticsApiActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsApiActor.FromRawUnchecked(rawData);
}
