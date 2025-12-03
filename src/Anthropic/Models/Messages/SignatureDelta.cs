using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<SignatureDelta, SignatureDeltaFromRaw>))]
public sealed record class SignatureDelta : ModelBase
{
    public required string Signature
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "signature"); }
        init { ModelBase.Set(this._rawData, "signature", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Signature;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"signature_delta\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public SignatureDelta()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"signature_delta\"");
    }

    public SignatureDelta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"signature_delta\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SignatureDelta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class SignatureDeltaFromRaw : IFromRaw<SignatureDelta>
{
    /// <inheritdoc/>
    public SignatureDelta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SignatureDelta.FromRawUnchecked(rawData);
}
