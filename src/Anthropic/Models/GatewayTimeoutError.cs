using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

[JsonConverter(typeof(ModelConverter<GatewayTimeoutError, GatewayTimeoutErrorFromRaw>))]
public sealed record class GatewayTimeoutError : ModelBase
{
    public required string Message
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "message"); }
        init { ModelBase.Set(this._rawData, "message", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"timeout_error\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public GatewayTimeoutError()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"timeout_error\"");
    }

    public GatewayTimeoutError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"timeout_error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GatewayTimeoutError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class GatewayTimeoutErrorFromRaw : IFromRaw<GatewayTimeoutError>
{
    /// <inheritdoc/>
    public GatewayTimeoutError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GatewayTimeoutError.FromRawUnchecked(rawData);
}
