using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.PluginMarketplaces;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaPluginMarketplaceValidationPluginError,
        BetaPluginMarketplaceValidationPluginErrorFromRaw
    >)
)]
public sealed record class BetaPluginMarketplaceValidationPluginError : JsonModel
{
    /// <summary>
    /// Why the plugin would be skipped by a synchronization.
    /// </summary>
    public required string Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// A stable identifier for the reason — the value to branch on.
    /// </summary>
    public required string ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("error_code");
        }
        init { this._rawData.Set("error_code", value); }
    }

    /// <summary>
    /// The plugin's name, as its entry in marketplace.json declares it.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Error;
        _ = this.ErrorCode;
        _ = this.Name;
    }

    public BetaPluginMarketplaceValidationPluginError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaPluginMarketplaceValidationPluginError(
        BetaPluginMarketplaceValidationPluginError betaPluginMarketplaceValidationPluginError
    )
        : base(betaPluginMarketplaceValidationPluginError) { }
#pragma warning restore CS8618

    public BetaPluginMarketplaceValidationPluginError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaPluginMarketplaceValidationPluginError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaPluginMarketplaceValidationPluginErrorFromRaw.FromRawUnchecked"/>
    public static BetaPluginMarketplaceValidationPluginError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaPluginMarketplaceValidationPluginErrorFromRaw
    : IFromRawJson<BetaPluginMarketplaceValidationPluginError>
{
    /// <inheritdoc/>
    public BetaPluginMarketplaceValidationPluginError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaPluginMarketplaceValidationPluginError.FromRawUnchecked(rawData);
}
