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
        this._rawData = new(rawData);

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"invalid_request_error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaInvalidRequestError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
