using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaAnalyticsServiceAccountActor,
        BetaAnalyticsServiceAccountActorFromRaw
    >)
)]
public sealed record class BetaAnalyticsServiceAccountActor : JsonModel
{
    /// <summary>
    /// Tagged service account ID.
    /// </summary>
    public required string ServiceAccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("service_account_id");
        }
        init { this._rawData.Set("service_account_id", value); }
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
        _ = this.ServiceAccountID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("service_account_actor")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaAnalyticsServiceAccountActor()
    {
        this.Type = JsonSerializer.SerializeToElement("service_account_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsServiceAccountActor(
        BetaAnalyticsServiceAccountActor betaAnalyticsServiceAccountActor
    )
        : base(betaAnalyticsServiceAccountActor) { }
#pragma warning restore CS8618

    public BetaAnalyticsServiceAccountActor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("service_account_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsServiceAccountActor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsServiceAccountActorFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsServiceAccountActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaAnalyticsServiceAccountActor(string serviceAccountID)
        : this()
    {
        this.ServiceAccountID = serviceAccountID;
    }
}

class BetaAnalyticsServiceAccountActorFromRaw : IFromRawJson<BetaAnalyticsServiceAccountActor>
{
    /// <inheritdoc/>
    public BetaAnalyticsServiceAccountActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsServiceAccountActor.FromRawUnchecked(rawData);
}
