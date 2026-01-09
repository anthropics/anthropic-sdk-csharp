using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta;

[JsonConverter(typeof(JsonModelConverter<BetaInvalidRequestError, BetaInvalidRequestErrorFromRaw>))]
public sealed record class BetaInvalidRequestError : JsonModel
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
                JsonSerializer.Deserialize<JsonElement>("\"invalid_request_error\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaInvalidRequestError()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"invalid_request_error\"");
    }

    public BetaInvalidRequestError(BetaInvalidRequestError betaInvalidRequestError)
        : base(betaInvalidRequestError) { }

    public BetaInvalidRequestError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"invalid_request_error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaInvalidRequestError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaInvalidRequestErrorFromRaw.FromRawUnchecked"/>
    public static BetaInvalidRequestError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaInvalidRequestError(string message)
        : this()
    {
        this.Message = message;
    }
}

class BetaInvalidRequestErrorFromRaw : IFromRawJson<BetaInvalidRequestError>
{
    /// <inheritdoc/>
    public BetaInvalidRequestError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaInvalidRequestError.FromRawUnchecked(rawData);
}
