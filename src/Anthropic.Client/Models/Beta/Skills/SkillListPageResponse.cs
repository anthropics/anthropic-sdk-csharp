using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Skills;

[JsonConverter(typeof(ModelConverter<SkillListPageResponse>))]
public sealed record class SkillListPageResponse : ModelBase, IFromRaw<SkillListPageResponse>
{
    /// <summary>
    /// List of skills.
    /// </summary>
    public required List<Data> Data
    {
        get
        {
            if (!this._properties.TryGetValue("data", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'data' cannot be null",
                    new ArgumentOutOfRangeException("data", "Missing required argument")
                );

            return JsonSerializer.Deserialize<List<Data>>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'data' cannot be null",
                    new ArgumentNullException("data")
                );
        }
        init
        {
            this._properties["data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Whether there are more results available.
    ///
    /// If `true`, there are additional results that can be fetched using the `next_page` token.
    /// </summary>
    public required bool HasMore
    {
        get
        {
            if (!this._properties.TryGetValue("has_more", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'has_more' cannot be null",
                    new ArgumentOutOfRangeException("has_more", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["has_more"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Token for fetching the next page of results.
    ///
    /// If `null`, there are no more results available. Pass this value to the `page_token`
    /// parameter in the next request to get the next page.
    /// </summary>
    public required string? NextPage
    {
        get
        {
            if (!this._properties.TryGetValue("next_page", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["next_page"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        _ = this.HasMore;
        _ = this.NextPage;
    }

    public SkillListPageResponse() { }

    public SkillListPageResponse(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SkillListPageResponse(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static SkillListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(ModelConverter<Data>))]
public sealed record class Data : ModelBase, IFromRaw<Data>
{
    /// <summary>
    /// Unique identifier for the skill.
    ///
    /// The format and length of IDs may change over time.
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this._properties.TryGetValue("id", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentNullException("id")
                );
        }
        init
        {
            this._properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// ISO 8601 timestamp of when the skill was created.
    /// </summary>
    public required string CreatedAt
    {
        get
        {
            if (!this._properties.TryGetValue("created_at", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'created_at' cannot be null",
                    new ArgumentOutOfRangeException("created_at", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'created_at' cannot be null",
                    new ArgumentNullException("created_at")
                );
        }
        init
        {
            this._properties["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Display title for the skill.
    ///
    /// This is a human-readable label that is not included in the prompt sent to
    /// the model.
    /// </summary>
    public required string? DisplayTitle
    {
        get
        {
            if (!this._properties.TryGetValue("display_title", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["display_title"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The latest version identifier for the skill.
    ///
    /// This represents the most recent version of the skill that has been created.
    /// </summary>
    public required string? LatestVersion
    {
        get
        {
            if (!this._properties.TryGetValue("latest_version", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["latest_version"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Source of the skill.
    ///
    /// This may be one of the following values: * `"custom"`: the skill was created
    /// by a user * `"anthropic"`: the skill was created by Anthropic
    /// </summary>
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

    /// <summary>
    /// Object type.
    ///
    /// For Skills, this is always `"skill"`.
    /// </summary>
    public required string Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentNullException("type")
                );
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
    /// ISO 8601 timestamp of when the skill was last updated.
    /// </summary>
    public required string UpdatedAt
    {
        get
        {
            if (!this._properties.TryGetValue("updated_at", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'updated_at' cannot be null",
                    new ArgumentOutOfRangeException("updated_at", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'updated_at' cannot be null",
                    new ArgumentNullException("updated_at")
                );
        }
        init
        {
            this._properties["updated_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.DisplayTitle;
        _ = this.LatestVersion;
        _ = this.Source;
        _ = this.Type;
        _ = this.UpdatedAt;
    }

    public Data() { }

    public Data(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
