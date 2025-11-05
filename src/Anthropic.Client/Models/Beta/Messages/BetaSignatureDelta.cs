using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaSignatureDelta>))]
public sealed record class BetaSignatureDelta : ModelBase, IFromRaw<BetaSignatureDelta>
{
    public required string Signature
    {
        get
        {
            if (!this._properties.TryGetValue("signature", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'signature' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "signature",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'signature' cannot be null",
                    new System::ArgumentNullException("signature")
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
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
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
        _ = this.Type;
    }

    public BetaSignatureDelta()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"signature_delta\"");
    }

    public BetaSignatureDelta(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"signature_delta\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaSignatureDelta(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaSignatureDelta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public BetaSignatureDelta(string signature)
        : this()
    {
        this.Signature = signature;
    }
}
