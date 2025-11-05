using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Skills.Versions;

[JsonConverter(typeof(ModelConverter<VersionListPageResponse>))]
public sealed record class VersionListPageResponse : ModelBase, IFromRaw<VersionListPageResponse>
{
    /// <summary>
    /// List of skill versions.
    /// </summary>
    public required List<global::Anthropic.Client.Models.Beta.Skills.Versions.Data> Data
    {
        get
        {
            if (!this._properties.TryGetValue("data", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'data' cannot be null",
                    new ArgumentOutOfRangeException("data", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
                    List<global::Anthropic.Client.Models.Beta.Skills.Versions.Data>
                >(element, ModelBase.SerializerOptions)
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
    /// Indicates if there are more results in the requested page direction.
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
    /// Token to provide in as `page` in the subsequent request to retrieve the next
    /// page of data.
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

    public VersionListPageResponse() { }

    public VersionListPageResponse(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VersionListPageResponse(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static VersionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(ModelConverter<global::Anthropic.Client.Models.Beta.Skills.Versions.Data>))]
public sealed record class Data
    : ModelBase,
        IFromRaw<global::Anthropic.Client.Models.Beta.Skills.Versions.Data>
{
    /// <summary>
    /// Unique identifier for the skill version.
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
    /// ISO 8601 timestamp of when the skill version was created.
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
    /// Description of the skill version.
    ///
    /// This is extracted from the SKILL.md file in the skill upload.
    /// </summary>
    public required string Description
    {
        get
        {
            if (!this._properties.TryGetValue("description", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'description' cannot be null",
                    new ArgumentOutOfRangeException("description", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'description' cannot be null",
                    new ArgumentNullException("description")
                );
        }
        init
        {
            this._properties["description"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Directory name of the skill version.
    ///
    /// This is the top-level directory name that was extracted from the uploaded files.
    /// </summary>
    public required string Directory
    {
        get
        {
            if (!this._properties.TryGetValue("directory", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'directory' cannot be null",
                    new ArgumentOutOfRangeException("directory", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'directory' cannot be null",
                    new ArgumentNullException("directory")
                );
        }
        init
        {
            this._properties["directory"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Human-readable name of the skill version.
    ///
    /// This is extracted from the SKILL.md file in the skill upload.
    /// </summary>
    public required string Name
    {
        get
        {
            if (!this._properties.TryGetValue("name", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'name' cannot be null",
                    new ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'name' cannot be null",
                    new ArgumentNullException("name")
                );
        }
        init
        {
            this._properties["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Identifier for the skill that this version belongs to.
    /// </summary>
    public required string SkillID
    {
        get
        {
            if (!this._properties.TryGetValue("skill_id", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'skill_id' cannot be null",
                    new ArgumentOutOfRangeException("skill_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'skill_id' cannot be null",
                    new ArgumentNullException("skill_id")
                );
        }
        init
        {
            this._properties["skill_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Object type.
    ///
    /// For Skill Versions, this is always `"skill_version"`.
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
    /// Version identifier for the skill.
    ///
    /// Each version is identified by a Unix epoch timestamp (e.g., "1759178010641129").
    /// </summary>
    public required string Version
    {
        get
        {
            if (!this._properties.TryGetValue("version", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'version' cannot be null",
                    new ArgumentOutOfRangeException("version", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'version' cannot be null",
                    new ArgumentNullException("version")
                );
        }
        init
        {
            this._properties["version"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.Directory;
        _ = this.Name;
        _ = this.SkillID;
        _ = this.Type;
        _ = this.Version;
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

    public static global::Anthropic.Client.Models.Beta.Skills.Versions.Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
