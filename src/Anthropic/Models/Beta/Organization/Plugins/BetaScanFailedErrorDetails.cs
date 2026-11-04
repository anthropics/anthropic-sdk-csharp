using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Plugins;

/// <summary>
/// The version in `plugin_version_id` did not pass its content scan, so it cannot
/// be served.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaScanFailedErrorDetails, BetaScanFailedErrorDetailsFromRaw>)
)]
public sealed record class BetaScanFailedErrorDetails : JsonModel
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
                JsonSerializer.SerializeToElement("scan_failed")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.PluginVersionID;
    }

    public BetaScanFailedErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("scan_failed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaScanFailedErrorDetails(BetaScanFailedErrorDetails betaScanFailedErrorDetails)
        : base(betaScanFailedErrorDetails) { }
#pragma warning restore CS8618

    public BetaScanFailedErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("scan_failed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaScanFailedErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaScanFailedErrorDetailsFromRaw.FromRawUnchecked"/>
    public static BetaScanFailedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaScanFailedErrorDetails(string pluginVersionID)
        : this()
    {
        this.PluginVersionID = pluginVersionID;
    }
}

class BetaScanFailedErrorDetailsFromRaw : IFromRawJson<BetaScanFailedErrorDetails>
{
    /// <inheritdoc/>
    public BetaScanFailedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaScanFailedErrorDetails.FromRawUnchecked(rawData);
}
