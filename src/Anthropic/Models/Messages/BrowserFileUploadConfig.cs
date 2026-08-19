using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// ``file_upload``'s config overrides.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BrowserFileUploadConfig, BrowserFileUploadConfigFromRaw>))]
public sealed record class BrowserFileUploadConfig : JsonModel
{
    /// <summary>
    /// Defer loading for this member. Must resolve to the same value on every enabled
    /// member of the toolset.
    /// </summary>
    public bool? DeferLoading
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("defer_loading");
        }
        init { this._rawData.Set("defer_loading", value); }
    }

    /// <summary>
    /// Whether this member is offered to the model. Default is per member, per the
    /// toolset's documentation. A member whose enabled resolves false is withheld
    /// from the served schema.
    /// </summary>
    public bool? Enabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("enabled");
        }
        init { this._rawData.Set("enabled", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DeferLoading;
        _ = this.Enabled;
    }

    public BrowserFileUploadConfig() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserFileUploadConfig(BrowserFileUploadConfig browserFileUploadConfig)
        : base(browserFileUploadConfig) { }
#pragma warning restore CS8618

    public BrowserFileUploadConfig(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserFileUploadConfig(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserFileUploadConfigFromRaw.FromRawUnchecked"/>
    public static BrowserFileUploadConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrowserFileUploadConfigFromRaw : IFromRawJson<BrowserFileUploadConfig>
{
    /// <inheritdoc/>
    public BrowserFileUploadConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrowserFileUploadConfig.FromRawUnchecked(rawData);
}
