using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

[JsonConverter(typeof(JsonModelConverter<BillingError, BillingErrorFromRaw>))]
public sealed record class BillingError : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("billing_error")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BillingError()
    {
        this.Type = JsonSerializer.SerializeToElement("billing_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BillingError(BillingError billingError)
        : base(billingError) { }
#pragma warning restore CS8618

    public BillingError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("billing_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BillingError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class BillingErrorFromRaw : IFromRawJson<BillingError>
{
    /// <inheritdoc/>
    public BillingError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BillingError.FromRawUnchecked(rawData);
}
