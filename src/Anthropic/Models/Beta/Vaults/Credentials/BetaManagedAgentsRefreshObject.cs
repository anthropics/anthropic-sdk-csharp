using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Vaults.Credentials;

/// <summary>
/// Outcome of a refresh-token exchange attempted during credential validation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsRefreshObject,
        BetaManagedAgentsRefreshObjectFromRaw
    >)
)]
public sealed record class BetaManagedAgentsRefreshObject : JsonModel
{
    /// <summary>
    /// An HTTP response captured during a credential validation probe.
    /// </summary>
    public required BetaManagedAgentsRefreshHttpResponse? HttpResponse
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsRefreshHttpResponse>(
                "http_response"
            );
        }
        init { this._rawData.Set("http_response", value); }
    }

    /// <summary>
    /// Outcome of a refresh-token exchange attempted during credential validation.
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.HttpResponse?.Validate();
        this.Status.Validate();
    }

    public BetaManagedAgentsRefreshObject() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsRefreshObject(
        BetaManagedAgentsRefreshObject betaManagedAgentsRefreshObject
    )
        : base(betaManagedAgentsRefreshObject) { }
#pragma warning restore CS8618

    public BetaManagedAgentsRefreshObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsRefreshObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsRefreshObjectFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsRefreshObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsRefreshObjectFromRaw : IFromRawJson<BetaManagedAgentsRefreshObject>
{
    /// <inheritdoc/>
    public BetaManagedAgentsRefreshObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsRefreshObject.FromRawUnchecked(rawData);
}

/// <summary>
/// Outcome of a refresh-token exchange attempted during credential validation.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Succeeded,
    Failed,
    ConnectError,
    NoRefreshToken,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "succeeded" => Status.Succeeded,
            "failed" => Status.Failed,
            "connect_error" => Status.ConnectError,
            "no_refresh_token" => Status.NoRefreshToken,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Succeeded => "succeeded",
                Status.Failed => "failed",
                Status.ConnectError => "connect_error",
                Status.NoRefreshToken => "no_refresh_token",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
