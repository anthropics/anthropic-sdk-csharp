using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;

namespace Anthropic.Models.Messages.Batches;

/// <summary>
/// List all Message Batches within a Workspace. Most recently created batches are
/// returned first.
///
/// <para>Learn more about the Message Batches API in our [user guide](https://docs.claude.com/en/docs/build-with-claude/batch-processing)</para>
/// </summary>
public sealed record class BatchListParams : ParamsBase
{
    /// <summary>
    /// ID of the object to use as a cursor for pagination. When provided, returns
    /// the page of results immediately after this object.
    /// </summary>
    public string? AfterID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("after_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("after_id", value);
        }
    }

    /// <summary>
    /// ID of the object to use as a cursor for pagination. When provided, returns
    /// the page of results immediately before this object.
    /// </summary>
    public string? BeforeID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("before_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("before_id", value);
        }
    }

    /// <summary>
    /// Number of items to return per page.
    ///
    /// <para>Defaults to `20`. Ranges from `1` to `1000`.</para>
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    public BatchListParams() { }

    public BatchListParams(BatchListParams batchListParams)
        : base(batchListParams) { }

    public BatchListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BatchListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static BatchListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/messages/batches")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
