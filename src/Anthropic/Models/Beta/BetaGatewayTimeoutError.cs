using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta;

[JsonConverter(typeof(JsonModelConverter<BetaGatewayTimeoutError, BetaGatewayTimeoutErrorFromRaw>))]
public sealed record class BetaGatewayTimeoutError : JsonModel
{
    public required string Message
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "message"); }
        init { JsonModel.Set(this._rawData, "message", value); }
    }

    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
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

    public BetaGatewayTimeoutError(BetaGatewayTimeoutError betaGatewayTimeoutError)
        : base(betaGatewayTimeoutError) { }

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

class BetaGatewayTimeoutErrorFromRaw : IFromRawJson<BetaGatewayTimeoutError>
{
    /// <inheritdoc/>
    public BetaGatewayTimeoutError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaGatewayTimeoutError.FromRawUnchecked(rawData);
}
