using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// A file download that finished during this call, reported with the same `download_id`
/// as its `download_started` — or without a prior `download_started`, when the download
/// finished during the call that started it (at most one state change per `download_id`
/// per result).
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaBrowserStateChangeDownloadCompleted,
        BetaBrowserStateChangeDownloadCompletedFromRaw
    >)
)]
public sealed record class BetaBrowserStateChangeDownloadCompleted : JsonModel
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
    /// Where the executor saved the file, on the executor's filesystem. Only included
    /// when another tool in the same environment can read the file at that path.
    /// </summary>
    public string? Path
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("path");
        }
        init { this._rawData.Set("path", value); }
    }

    /// <summary>
    /// The completed download's size.
    /// </summary>
    public long? SizeBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("size_bytes");
        }
        init { this._rawData.Set("size_bytes", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DownloadID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("download_completed")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Url;
        _ = this.Path;
        _ = this.SizeBytes;
    }

    public BetaBrowserStateChangeDownloadCompleted()
    {
        this.Type = JsonSerializer.SerializeToElement("download_completed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserStateChangeDownloadCompleted(
        BetaBrowserStateChangeDownloadCompleted betaBrowserStateChangeDownloadCompleted
    )
        : base(betaBrowserStateChangeDownloadCompleted) { }
#pragma warning restore CS8618

    public BetaBrowserStateChangeDownloadCompleted(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("download_completed");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserStateChangeDownloadCompleted(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserStateChangeDownloadCompletedFromRaw.FromRawUnchecked"/>
    public static BetaBrowserStateChangeDownloadCompleted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaBrowserStateChangeDownloadCompletedFromRaw
    : IFromRawJson<BetaBrowserStateChangeDownloadCompleted>
{
    /// <inheritdoc/>
    public BetaBrowserStateChangeDownloadCompleted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserStateChangeDownloadCompleted.FromRawUnchecked(rawData);
}
