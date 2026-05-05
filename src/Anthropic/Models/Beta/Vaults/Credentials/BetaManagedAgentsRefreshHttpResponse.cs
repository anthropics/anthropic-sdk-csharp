using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Vaults.Credentials;

/// <summary>
/// An HTTP response captured during a credential validation probe.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsRefreshHttpResponse,
        BetaManagedAgentsRefreshHttpResponseFromRaw
    >)
)]
public sealed record class BetaManagedAgentsRefreshHttpResponse : JsonModel
{
    /// <summary>
    /// Response body. May be truncated and has sensitive values scrubbed.
    /// </summary>
    public required string Body
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("body");
        }
        init { this._rawData.Set("body", value); }
    }

    /// <summary>
    /// Whether `body` was truncated.
    /// </summary>
    public required bool BodyTruncated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("body_truncated");
        }
        init { this._rawData.Set("body_truncated", value); }
    }

    /// <summary>
    /// Value of the `Content-Type` response header.
    /// </summary>
    public required string ContentType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("content_type");
        }
        init { this._rawData.Set("content_type", value); }
    }

    /// <summary>
    /// HTTP status code.
    /// </summary>
    public required int StatusCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<int>("status_code");
        }
        init { this._rawData.Set("status_code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Body;
        _ = this.BodyTruncated;
        _ = this.ContentType;
        _ = this.StatusCode;
    }

    public BetaManagedAgentsRefreshHttpResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsRefreshHttpResponse(
        BetaManagedAgentsRefreshHttpResponse betaManagedAgentsRefreshHttpResponse
    )
        : base(betaManagedAgentsRefreshHttpResponse) { }
#pragma warning restore CS8618

    public BetaManagedAgentsRefreshHttpResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsRefreshHttpResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsRefreshHttpResponseFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsRefreshHttpResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsRefreshHttpResponseFromRaw
    : IFromRawJson<BetaManagedAgentsRefreshHttpResponse>
{
    /// <inheritdoc/>
    public BetaManagedAgentsRefreshHttpResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsRefreshHttpResponse.FromRawUnchecked(rawData);
}
