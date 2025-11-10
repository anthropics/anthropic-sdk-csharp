using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaCitationSearchResultLocation>))]
public sealed record class BetaCitationSearchResultLocation
    : ModelBase,
        IFromRaw<BetaCitationSearchResultLocation>
{
    public required string CitedText
    {
        get
        {
            if (!this._properties.TryGetValue("cited_text", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'cited_text' cannot be null",
                    new ArgumentOutOfRangeException("cited_text", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'cited_text' cannot be null",
                    new ArgumentNullException("cited_text")
                );
        }
        init
        {
            this._properties["cited_text"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long EndBlockIndex
    {
        get
        {
            if (!this._properties.TryGetValue("end_block_index", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'end_block_index' cannot be null",
                    new ArgumentOutOfRangeException("end_block_index", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["end_block_index"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long SearchResultIndex
    {
        get
        {
            if (!this._properties.TryGetValue("search_result_index", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'search_result_index' cannot be null",
                    new ArgumentOutOfRangeException(
                        "search_result_index",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["search_result_index"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Source
    {
        get
        {
            if (!this._properties.TryGetValue("source", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'source' cannot be null",
                    new ArgumentOutOfRangeException("source", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'source' cannot be null",
                    new ArgumentNullException("source")
                );
        }
        init
        {
            this._properties["source"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long StartBlockIndex
    {
        get
        {
            if (!this._properties.TryGetValue("start_block_index", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'start_block_index' cannot be null",
                    new ArgumentOutOfRangeException(
                        "start_block_index",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["start_block_index"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string? Title
    {
        get
        {
            if (!this._properties.TryGetValue("title", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["title"] = JsonSerializer.SerializeToElement(
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
        _ = this.CitedText;
        _ = this.EndBlockIndex;
        _ = this.SearchResultIndex;
        _ = this.Source;
        _ = this.StartBlockIndex;
        _ = this.Title;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"search_result_location\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaCitationSearchResultLocation()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"search_result_location\"");
    }

    public BetaCitationSearchResultLocation(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"search_result_location\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCitationSearchResultLocation(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaCitationSearchResultLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
