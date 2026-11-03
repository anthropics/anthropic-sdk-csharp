using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Plugins;

/// <summary>
/// The content scan of the version in `plugin_version_id` is still running. Retry
/// once the scan finishes.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaScanPendingErrorDetails, BetaScanPendingErrorDetailsFromRaw>)
)]
public sealed record class BetaScanPendingErrorDetails : JsonModel
{
    public JsonElement ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("error_code");
        }
        init { this._rawData.Set("error_code", value); }
    }

    public required string PluginVersionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("plugin_version_id");
        }
        init { this._rawData.Set("plugin_version_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.ErrorCode,
                JsonSerializer.SerializeToElement("scan_pending")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.PluginVersionID;
    }

    public BetaScanPendingErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("scan_pending");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaScanPendingErrorDetails(BetaScanPendingErrorDetails betaScanPendingErrorDetails)
        : base(betaScanPendingErrorDetails) { }
#pragma warning restore CS8618

    public BetaScanPendingErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("scan_pending");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaScanPendingErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaScanPendingErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaScanPendingErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaScanPendingErrorDetails(string pluginVersionID)
        : this()
    {
        this.PluginVersionID = pluginVersionID;
    }
}

class BetaScanPendingErrorDetailsFromRaw : IFromRawJson<BetaScanPendingErrorDetails>
{
    /// <inheritdoc/>
    public BetaScanPendingErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaScanPendingErrorDetails.FromRawUnchecked(rawData);
}
