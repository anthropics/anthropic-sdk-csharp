using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Federation.Rules;

/// <summary>
/// Bind to a fixed service account by ID.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaServiceAccountTarget, BetaServiceAccountTargetFromRaw>)
)]
public sealed record class BetaServiceAccountTarget : JsonModel
{
    /// <summary>
    /// Tagged ID of the service account to mint tokens for.
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

    /// <summary>
    /// Service account's display name at read time. Ignored on writes.
    /// </summary>
    public string? ServiceAccountName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("service_account_name");
        }
        init { this._rawData.Set("service_account_name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ServiceAccountID;
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("service_account"))
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.ServiceAccountName;
    }

    public BetaServiceAccountTarget()
    {
        this.Type = JsonSerializer.SerializeToElement("service_account");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaServiceAccountTarget(BetaServiceAccountTarget betaServiceAccountTarget)
        : base(betaServiceAccountTarget) { }
#pragma warning restore CS8618

    public BetaServiceAccountTarget(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("service_account");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaServiceAccountTarget(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaServiceAccountTargetFromRaw.FromRawUnchecked"/>
    public static BetaServiceAccountTarget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaServiceAccountTarget(string serviceAccountID)
        : this()
    {
        this.ServiceAccountID = serviceAccountID;
    }
}

class BetaServiceAccountTargetFromRaw : IFromRawJson<BetaServiceAccountTarget>
{
    /// <inheritdoc/>
    public BetaServiceAccountTarget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaServiceAccountTarget.FromRawUnchecked(rawData);
}
