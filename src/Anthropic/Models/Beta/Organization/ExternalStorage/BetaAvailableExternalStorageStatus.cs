using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalStorage;

/// <summary>
/// The storage is verified, no Workspace has it attached, and Anthropic doesn't
/// use the bucket.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaAvailableExternalStorageStatus,
        BetaAvailableExternalStorageStatusFromRaw
    >)
)]
public sealed record class BetaAvailableExternalStorageStatus : JsonModel
{
    /// <summary>
    /// Whether the bucket passed its latest recorded check. It can stay `true` after
    /// the bucket stops working, so don't use it for monitoring.
    /// </summary>
    public required bool Healthy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("healthy");
        }
        init { this._rawData.Set("healthy", value); }
    }

    /// <summary>
    /// When the bucket's latest recorded check ran, in RFC 3339.
    /// </summary>
    public required DateTimeOffset LastCheckedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("last_checked_at");
        }
        init { this._rawData.Set("last_checked_at", value); }
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
        _ = this.Healthy;
        _ = this.LastCheckedAt;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("available")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaAvailableExternalStorageStatus()
    {
        this.Type = JsonSerializer.SerializeToElement("available");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAvailableExternalStorageStatus(
        BetaAvailableExternalStorageStatus betaAvailableExternalStorageStatus
    )
        : base(betaAvailableExternalStorageStatus) { }
#pragma warning restore CS8618

    public BetaAvailableExternalStorageStatus(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("available");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAvailableExternalStorageStatus(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAvailableExternalStorageStatusFromRaw.FromRawUnchecked"/>
    public static BetaAvailableExternalStorageStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAvailableExternalStorageStatusFromRaw : IFromRawJson<BetaAvailableExternalStorageStatus>
{
    /// <inheritdoc/>
    public BetaAvailableExternalStorageStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAvailableExternalStorageStatus.FromRawUnchecked(rawData);
}
