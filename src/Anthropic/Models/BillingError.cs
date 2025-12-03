using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

[JsonConverter(typeof(ModelConverter<BillingError, BillingErrorFromRaw>))]
public sealed record class BillingError : ModelBase
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
                JsonSerializer.Deserialize<JsonElement>("\"billing_error\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BillingError()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"billing_error\"");
    }

    public BillingError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"billing_error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BillingError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BillingErrorFromRaw.FromRawUnchecked"/>
    public static BillingError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BillingError(string message)
        : this()
    {
        this.Message = message;
    }
}

class BillingErrorFromRaw : IFromRaw<BillingError>
{
    /// <inheritdoc/>
    public BillingError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BillingError.FromRawUnchecked(rawData);
}
