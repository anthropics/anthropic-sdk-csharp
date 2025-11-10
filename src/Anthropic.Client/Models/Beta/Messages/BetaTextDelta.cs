using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaTextDelta>))]
public sealed record class BetaTextDelta : ModelBase, IFromRaw<BetaTextDelta>
{
    public required string Text
    {
        get
        {
            if (!this._properties.TryGetValue("text", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'text' cannot be null",
                    new ArgumentOutOfRangeException("text", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'text' cannot be null",
                    new ArgumentNullException("text")
                );
        }
        init
        {
            this._properties["text"] = JsonSerializer.SerializeToElement(
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
        _ = this.Text;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"text_delta\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaTextDelta()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"text_delta\"");
    }

    public BetaTextDelta(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"text_delta\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTextDelta(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaTextDelta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public BetaTextDelta(string text)
        : this()
    {
        this.Text = text;
    }
}
