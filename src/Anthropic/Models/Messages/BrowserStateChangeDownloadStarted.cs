using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// A file download that started during this call.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BrowserStateChangeDownloadStarted,
        BrowserStateChangeDownloadStartedFromRaw
    >)
)]
public sealed record class BrowserStateChangeDownloadStarted : JsonModel
{
    /// <summary>
    /// The caller-assigned identifier for this download, stable across the state
    /// changes reporting it.
    /// </summary>
    public required string DownloadID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("download_id");
        }
        init { this._rawData.Set("download_id", value); }
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
    /// The final post-redirect URL the download was served from.
    /// </summary>
    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DownloadID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("download_started")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Url;
    }

    public BrowserStateChangeDownloadStarted()
    {
        this.Type = JsonSerializer.SerializeToElement("download_started");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserStateChangeDownloadStarted(
        BrowserStateChangeDownloadStarted browserStateChangeDownloadStarted
    )
        : base(browserStateChangeDownloadStarted) { }
#pragma warning restore CS8618

    public BrowserStateChangeDownloadStarted(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("download_started");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserStateChangeDownloadStarted(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserStateChangeDownloadStartedFromRaw.FromRawUnchecked"/>
    public static BrowserStateChangeDownloadStarted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrowserStateChangeDownloadStartedFromRaw : IFromRawJson<BrowserStateChangeDownloadStarted>
{
    /// <inheritdoc/>
    public BrowserStateChangeDownloadStarted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrowserStateChangeDownloadStarted.FromRawUnchecked(rawData);
}
