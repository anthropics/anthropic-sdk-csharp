using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaSignatureDelta, BetaSignatureDeltaFromRaw>))]
public sealed record class BetaSignatureDelta : JsonModel
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

    public BetaSignatureDelta()
    {
        this.Type = JsonSerializer.SerializeToElement("signature_delta");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaSignatureDelta(BetaSignatureDelta betaSignatureDelta)
        : base(betaSignatureDelta) { }
#pragma warning restore CS8618

    public BetaSignatureDelta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("signature_delta");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSignatureDelta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaSignatureDeltaFromRaw.FromRawUnchecked"/>
    public static BetaSignatureDelta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaSignatureDelta(string signature)
        : this()
    {
        this.Signature = signature;
    }
}

class BetaSignatureDeltaFromRaw : IFromRawJson<BetaSignatureDelta>
{
    /// <inheritdoc/>
    public BetaSignatureDelta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaSignatureDelta.FromRawUnchecked(rawData);
}
