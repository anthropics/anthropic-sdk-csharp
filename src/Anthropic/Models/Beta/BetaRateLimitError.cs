using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta;

[JsonConverter(typeof(ModelConverter<BetaRateLimitError, BetaRateLimitErrorFromRaw>))]
public sealed record class BetaRateLimitError : ModelBase
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
                JsonSerializer.Deserialize<JsonElement>("\"rate_limit_error\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaRateLimitError()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"rate_limit_error\"");
    }

    public BetaRateLimitError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"rate_limit_error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRateLimitError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class BetaRateLimitErrorFromRaw : IFromRaw<BetaRateLimitError>
{
    /// <inheritdoc/>
    public BetaRateLimitError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaRateLimitError.FromRawUnchecked(rawData);
}
