using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta;

[JsonConverter(typeof(JsonModelConverter<BetaBillingError, BetaBillingErrorFromRaw>))]
public sealed record class BetaBillingError : JsonModel
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
                JsonSerializer.Deserialize<JsonElement>("\"billing_error\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaBillingError()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"billing_error\"");
    }

    public BetaBillingError(BetaBillingError betaBillingError)
        : base(betaBillingError) { }

    public BetaBillingError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"billing_error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBillingError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBillingErrorFromRaw.FromRawUnchecked"/>
    public static BetaBillingError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaBillingError(string message)
        : this()
    {
        this.Message = message;
    }
}

class BetaBillingErrorFromRaw : IFromRawJson<BetaBillingError>
{
    /// <inheritdoc/>
    public BetaBillingError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaBillingError.FromRawUnchecked(rawData);
}
