using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<SignatureDelta, SignatureDeltaFromRaw>))]
public sealed record class SignatureDelta : JsonModel
{
    public required string Signature
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("signature");
        }
        init { this._rawData.Set("signature", value); }
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
        _ = this.Signature;
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("signature_delta"))
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public SignatureDelta()
    {
        this.Type = JsonSerializer.SerializeToElement("signature_delta");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SignatureDelta(SignatureDelta signatureDelta)
        : base(signatureDelta) { }
#pragma warning restore CS8618

    public SignatureDelta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("signature_delta");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SignatureDelta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SignatureDeltaFromRaw.FromRawUnchecked"/>
    public static SignatureDelta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SignatureDelta(string signature)
        : this()
    {
        this.Signature = signature;
    }
}

class SignatureDeltaFromRaw : IFromRawJson<SignatureDelta>
{
    /// <inheritdoc/>
    public SignatureDelta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SignatureDelta.FromRawUnchecked(rawData);
}
