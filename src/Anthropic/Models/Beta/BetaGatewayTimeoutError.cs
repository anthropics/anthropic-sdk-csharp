using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta;

[JsonConverter(typeof(ModelConverter<BetaGatewayTimeoutError, BetaGatewayTimeoutErrorFromRaw>))]
public sealed record class BetaGatewayTimeoutError : ModelBase
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

    public BetaGatewayTimeoutError()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"timeout_error\"");
    }

    public BetaGatewayTimeoutError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"timeout_error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaGatewayTimeoutError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaGatewayTimeoutErrorFromRaw.FromRawUnchecked"/>
    public static BetaGatewayTimeoutError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaGatewayTimeoutError(string message)
        : this()
    {
        this.Message = message;
    }
}

class BetaGatewayTimeoutErrorFromRaw : IFromRaw<BetaGatewayTimeoutError>
{
    /// <inheritdoc/>
    public BetaGatewayTimeoutError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGatewayTimeoutError.FromRawUnchecked(rawData);
}
