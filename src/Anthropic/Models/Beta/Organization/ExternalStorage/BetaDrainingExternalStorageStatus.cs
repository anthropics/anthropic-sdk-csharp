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
/// No Workspace has the storage attached. A Workspace can attach it again, unless
/// `removal_started` is true.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaDrainingExternalStorageStatus,
        BetaDrainingExternalStorageStatusFromRaw
    >)
)]
public sealed record class BetaDrainingExternalStorageStatus : JsonModel
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

    /// <summary>
    /// True once a delete has started removing this storage, which can't be undone.
    /// It then can't be attached, and another delete finishes the removal.
    /// </summary>
    public required bool RemovalStarted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("removal_started");
        }
        init { this._rawData.Set("removal_started", value); }
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
        _ = this.RemovalStarted;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("draining")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaDrainingExternalStorageStatus()
    {
        this.Type = JsonSerializer.SerializeToElement("draining");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaDrainingExternalStorageStatus(
        BetaDrainingExternalStorageStatus betaDrainingExternalStorageStatus
    )
        : base(betaDrainingExternalStorageStatus) { }
#pragma warning restore CS8618

    public BetaDrainingExternalStorageStatus(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("draining");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaDrainingExternalStorageStatus(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaDrainingExternalStorageStatusFromRaw.FromRawUnchecked"/>
    public static BetaDrainingExternalStorageStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaDrainingExternalStorageStatusFromRaw : IFromRawJson<BetaDrainingExternalStorageStatus>
{
    /// <inheritdoc/>
    public BetaDrainingExternalStorageStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaDrainingExternalStorageStatus.FromRawUnchecked(rawData);
}
