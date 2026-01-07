using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta;

[JsonConverter(typeof(JsonModelConverter<BetaApiError, BetaApiErrorFromRaw>))]
public sealed record class BetaApiError : JsonModel
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
                JsonSerializer.Deserialize<JsonElement>("\"api_error\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaApiError()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"api_error\"");
    }

    public BetaApiError(BetaApiError betaApiError)
        : base(betaApiError) { }

    public BetaApiError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"api_error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaApiError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaApiErrorFromRaw.FromRawUnchecked"/>
    public static BetaApiError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaApiError(string message)
        : this()
    {
        this.Message = message;
    }
}

class BetaApiErrorFromRaw : IFromRawJson<BetaApiError>
{
    /// <inheritdoc/>
    public BetaApiError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaApiError.FromRawUnchecked(rawData);
}
