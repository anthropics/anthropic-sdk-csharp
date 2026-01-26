using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta;

[JsonConverter(typeof(JsonModelConverter<BetaRateLimitError, BetaRateLimitErrorFromRaw>))]
public sealed record class BetaRateLimitError : JsonModel
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
                JsonSerializer.SerializeToElement("rate_limit_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaRateLimitError()
    {
        this.Type = JsonSerializer.SerializeToElement("rate_limit_error");
    }

    public BetaRateLimitError(BetaRateLimitError betaRateLimitError)
        : base(betaRateLimitError) { }

    public BetaRateLimitError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("rate_limit_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRateLimitError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaRateLimitErrorFromRaw.FromRawUnchecked"/>
    public static BetaRateLimitError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaRateLimitError(string message)
        : this()
    {
        this.Message = message;
    }
}

class BetaRateLimitErrorFromRaw : IFromRawJson<BetaRateLimitError>
{
    /// <inheritdoc/>
    public BetaRateLimitError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaRateLimitError.FromRawUnchecked(rawData);
}
