using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

[JsonConverter(typeof(JsonModelConverter<RateLimitError, RateLimitErrorFromRaw>))]
public sealed record class RateLimitError : JsonModel
{
    public required string Message
    {
        get { return this._rawData.GetNotNullClass<string>("message"); }
        init { this._rawData.Set("message", value); }
    }

    public JsonElement Type
    {
        get { return this._rawData.GetNotNullStruct<JsonElement>("type"); }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"rate_limit_error\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public RateLimitError()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"rate_limit_error\"");
    }

    public RateLimitError(RateLimitError rateLimitError)
        : base(rateLimitError) { }

    public RateLimitError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"rate_limit_error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RateLimitError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RateLimitErrorFromRaw.FromRawUnchecked"/>
    public static RateLimitError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RateLimitError(string message)
        : this()
    {
        this.Message = message;
    }
}

class RateLimitErrorFromRaw : IFromRawJson<RateLimitError>
{
    /// <inheritdoc/>
    public RateLimitError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RateLimitError.FromRawUnchecked(rawData);
}
