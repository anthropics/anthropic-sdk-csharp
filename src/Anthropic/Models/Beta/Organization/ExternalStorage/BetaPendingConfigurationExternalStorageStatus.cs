using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalStorage;

/// <summary>
/// The storage isn't verified yet.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaPendingConfigurationExternalStorageStatus,
        BetaPendingConfigurationExternalStorageStatusFromRaw
    >)
)]
public sealed record class BetaPendingConfigurationExternalStorageStatus : JsonModel
{
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
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("pending_configuration")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaPendingConfigurationExternalStorageStatus()
    {
        this.Type = JsonSerializer.SerializeToElement("pending_configuration");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaPendingConfigurationExternalStorageStatus(
        BetaPendingConfigurationExternalStorageStatus betaPendingConfigurationExternalStorageStatus
    )
        : base(betaPendingConfigurationExternalStorageStatus) { }
#pragma warning restore CS8618

    public BetaPendingConfigurationExternalStorageStatus(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("pending_configuration");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaPendingConfigurationExternalStorageStatus(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaPendingConfigurationExternalStorageStatusFromRaw.FromRawUnchecked"/>
    public static BetaPendingConfigurationExternalStorageStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaPendingConfigurationExternalStorageStatusFromRaw
    : IFromRawJson<BetaPendingConfigurationExternalStorageStatus>
{
    /// <inheritdoc/>
    public BetaPendingConfigurationExternalStorageStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaPendingConfigurationExternalStorageStatus.FromRawUnchecked(rawData);
}
