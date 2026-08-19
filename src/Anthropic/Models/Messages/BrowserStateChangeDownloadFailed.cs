using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// A file download that failed — or was cancelled — during this call.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BrowserStateChangeDownloadFailed,
        BrowserStateChangeDownloadFailedFromRaw
    >)
)]
public sealed record class BrowserStateChangeDownloadFailed : JsonModel
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

    /// <summary>
    /// The failure or cancellation detail, when known.
    /// </summary>
    public string? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DownloadID;
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("download_failed"))
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Url;
        _ = this.Error;
    }

    public BrowserStateChangeDownloadFailed()
    {
        this.Type = JsonSerializer.SerializeToElement("download_failed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserStateChangeDownloadFailed(
        BrowserStateChangeDownloadFailed browserStateChangeDownloadFailed
    )
        : base(browserStateChangeDownloadFailed) { }
#pragma warning restore CS8618

    public BrowserStateChangeDownloadFailed(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("download_failed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserStateChangeDownloadFailed(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserStateChangeDownloadFailedFromRaw.FromRawUnchecked"/>
    public static BrowserStateChangeDownloadFailed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrowserStateChangeDownloadFailedFromRaw : IFromRawJson<BrowserStateChangeDownloadFailed>
{
    /// <inheritdoc/>
    public BrowserStateChangeDownloadFailed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrowserStateChangeDownloadFailed.FromRawUnchecked(rawData);
}
