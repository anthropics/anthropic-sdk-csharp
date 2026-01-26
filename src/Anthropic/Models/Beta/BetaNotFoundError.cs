using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta;

[JsonConverter(typeof(JsonModelConverter<BetaNotFoundError, BetaNotFoundErrorFromRaw>))]
public sealed record class BetaNotFoundError : JsonModel
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
            !JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("not_found_error"))
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaNotFoundError()
    {
        this.Type = JsonSerializer.SerializeToElement("not_found_error");
    }

    public BetaNotFoundError(BetaNotFoundError betaNotFoundError)
        : base(betaNotFoundError) { }

    public BetaNotFoundError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("not_found_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaNotFoundError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaNotFoundErrorFromRaw.FromRawUnchecked"/>
    public static BetaNotFoundError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaNotFoundError(string message)
        : this()
    {
        this.Message = message;
    }
}

class BetaNotFoundErrorFromRaw : IFromRawJson<BetaNotFoundError>
{
    /// <inheritdoc/>
    public BetaNotFoundError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaNotFoundError.FromRawUnchecked(rawData);
}
