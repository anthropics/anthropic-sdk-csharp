using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<SignatureDelta>))]
public sealed record class SignatureDelta : ModelBase, IFromRaw<SignatureDelta>
{
    public required string Signature
    {
        get
        {
            if (!this._properties.TryGetValue("signature", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'signature' cannot be null",
                    new ArgumentOutOfRangeException("signature", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'signature' cannot be null",
                    new ArgumentNullException("signature")
                );
        }
        init
        {
            this._properties["signature"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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

    public SignatureDelta(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"signature_delta\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SignatureDelta(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static SignatureDelta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public SignatureDelta(string signature)
        : this()
    {
        this.Signature = signature;
    }
}
