using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta;

[JsonConverter(typeof(JsonModelConverter<BetaOverloadedError, BetaOverloadedErrorFromRaw>))]
public sealed record class BetaOverloadedError : JsonModel
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
                JsonSerializer.Deserialize<JsonElement>("\"overloaded_error\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaOverloadedError()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"overloaded_error\"");
    }

    public BetaOverloadedError(BetaOverloadedError betaOverloadedError)
        : base(betaOverloadedError) { }

    public BetaOverloadedError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"overloaded_error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaOverloadedError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaOverloadedErrorFromRaw.FromRawUnchecked"/>
    public static BetaOverloadedError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaOverloadedError(string message)
        : this()
    {
        this.Message = message;
    }
}

class BetaOverloadedErrorFromRaw : IFromRawJson<BetaOverloadedError>
{
    /// <inheritdoc/>
    public BetaOverloadedError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaOverloadedError.FromRawUnchecked(rawData);
}
