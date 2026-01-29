using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

[JsonConverter(typeof(JsonModelConverter<GatewayTimeoutError, GatewayTimeoutErrorFromRaw>))]
public sealed record class GatewayTimeoutError : JsonModel
{
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("timeout_error")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public GatewayTimeoutError()
    {
        this.Type = JsonSerializer.SerializeToElement("timeout_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GatewayTimeoutError(GatewayTimeoutError gatewayTimeoutError)
        : base(gatewayTimeoutError) { }
#pragma warning restore CS8618

    public GatewayTimeoutError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("timeout_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GatewayTimeoutError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GatewayTimeoutErrorFromRaw.FromRawUnchecked"/>
    public static GatewayTimeoutError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public GatewayTimeoutError(string message)
        : this()
    {
        this.Message = message;
    }
}

class GatewayTimeoutErrorFromRaw : IFromRawJson<GatewayTimeoutError>
{
    /// <inheritdoc/>
    public GatewayTimeoutError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GatewayTimeoutError.FromRawUnchecked(rawData);
}
