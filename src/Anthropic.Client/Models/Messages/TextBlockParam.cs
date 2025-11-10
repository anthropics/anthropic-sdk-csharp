using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Messages;

[JsonConverter(typeof(ModelConverter<TextBlockParam>))]
public sealed record class TextBlockParam : ModelBase, IFromRaw<TextBlockParam>
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

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public CacheControlEphemeral? CacheControl
    {
        get
        {
            if (!this._properties.TryGetValue("cache_control", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<CacheControlEphemeral?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["cache_control"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public List<TextCitationParam>? Citations
    {
        get
        {
            if (!this._properties.TryGetValue("citations", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<TextCitationParam>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["citations"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Text;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.Deserialize<JsonElement>("\"text\"")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
        foreach (var item in this.Citations ?? [])
        {
            item.Validate();
        }
    }

    public TextBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"text\"");
    }

    public TextBlockParam(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"text\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TextBlockParam(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static TextBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public TextBlockParam(string text)
        : this()
    {
        this.Text = text;
    }
}
