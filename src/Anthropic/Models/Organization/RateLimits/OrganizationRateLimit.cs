using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.RateLimits;

[JsonConverter(typeof(JsonModelConverter<OrganizationRateLimit, OrganizationRateLimitFromRaw>))]
public sealed record class OrganizationRateLimit : JsonModel
{
    /// <summary>
    /// Identifier of this rate-limit entry. It is stable within the organization
    /// and differs between organizations; the group's own identifier is `group.id`.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// The rate-limit group this entry's limits apply to. Its `type` equals `group_type`.
    /// </summary>
    public required Group Group
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Group>("group");
        }
        init { this._rawData.Set("group", value); }
    }

    /// <summary>
    /// The limiter values that apply to this group.
    /// </summary>
    public required IReadOnlyList<OrganizationRateLimitValue> Limits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<OrganizationRateLimitValue>>(
                "limits"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<OrganizationRateLimitValue>>(
                "limits",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Model names this entry's limits apply to, including aliases. `null` when `group_type`
    /// is not `"model_group"`.
    /// </summary>
    public required IReadOnlyList<string>? Models
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("models");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "models",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Object type. Always `rate_limit` for organization rate-limit entries.
    /// </summary>
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
        _ = this.ID;
        this.Group.Validate();
        foreach (var item in this.Limits)
        {
            item.Validate();
        }
        _ = this.Models;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("rate_limit")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public OrganizationRateLimit()
    {
        this.Type = JsonSerializer.SerializeToElement("rate_limit");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OrganizationRateLimit(OrganizationRateLimit organizationRateLimit)
        : base(organizationRateLimit) { }
#pragma warning restore CS8618

    public OrganizationRateLimit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("rate_limit");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OrganizationRateLimit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OrganizationRateLimitFromRaw.FromRawUnchecked"/>
    public static OrganizationRateLimit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OrganizationRateLimitFromRaw : IFromRawJson<OrganizationRateLimit>
{
    /// <inheritdoc/>
    public OrganizationRateLimit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OrganizationRateLimit.FromRawUnchecked(rawData);
}

/// <summary>
/// The rate-limit group this entry's limits apply to. Its `type` equals `group_type`.
/// </summary>
[JsonConverter(typeof(GroupConverter))]
public record class Group : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string ID
    {
        get
        {
            return this.Value switch
            {
                OrganizationRateLimitModelGroup x => x.ID,
                OrganizationRateLimitBatchGroup x => x.ID,
                OrganizationRateLimitTokenCountGroup x => x.ID,
                OrganizationRateLimitFilesGroup x => x.ID,
                OrganizationRateLimitSkillsGroup x => x.ID,
                OrganizationRateLimitWebSearchGroup x => x.ID,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<string>(this.Json, "id"),
            };
        }
    }

    public JsonElement Type
    {
        get
        {
            return this.Value switch
            {
                OrganizationRateLimitModelGroup x => x.Type,
                OrganizationRateLimitBatchGroup x => x.Type,
                OrganizationRateLimitTokenCountGroup x => x.Type,
                OrganizationRateLimitFilesGroup x => x.Type,
                OrganizationRateLimitSkillsGroup x => x.Type,
                OrganizationRateLimitWebSearchGroup x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public Group(OrganizationRateLimitModelGroup value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Group(OrganizationRateLimitBatchGroup value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Group(OrganizationRateLimitTokenCountGroup value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Group(OrganizationRateLimitFilesGroup value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Group(OrganizationRateLimitSkillsGroup value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Group(OrganizationRateLimitWebSearchGroup value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Group(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OrganizationRateLimitModelGroup"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickOrganizationRateLimitModel(out var value)) {
    ///     // `value` is of type `OrganizationRateLimitModelGroup`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickOrganizationRateLimitModel(
        [NotNullWhen(true)] out OrganizationRateLimitModelGroup? value
    )
    {
        value = this.Value as OrganizationRateLimitModelGroup;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OrganizationRateLimitBatchGroup"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickOrganizationRateLimitBatch(out var value)) {
    ///     // `value` is of type `OrganizationRateLimitBatchGroup`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickOrganizationRateLimitBatch(
        [NotNullWhen(true)] out OrganizationRateLimitBatchGroup? value
    )
    {
        value = this.Value as OrganizationRateLimitBatchGroup;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OrganizationRateLimitTokenCountGroup"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickOrganizationRateLimitTokenCount(out var value)) {
    ///     // `value` is of type `OrganizationRateLimitTokenCountGroup`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickOrganizationRateLimitTokenCount(
        [NotNullWhen(true)] out OrganizationRateLimitTokenCountGroup? value
    )
    {
        value = this.Value as OrganizationRateLimitTokenCountGroup;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OrganizationRateLimitFilesGroup"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickOrganizationRateLimitFiles(out var value)) {
    ///     // `value` is of type `OrganizationRateLimitFilesGroup`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickOrganizationRateLimitFiles(
        [NotNullWhen(true)] out OrganizationRateLimitFilesGroup? value
    )
    {
        value = this.Value as OrganizationRateLimitFilesGroup;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OrganizationRateLimitSkillsGroup"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickOrganizationRateLimitSkills(out var value)) {
    ///     // `value` is of type `OrganizationRateLimitSkillsGroup`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickOrganizationRateLimitSkills(
        [NotNullWhen(true)] out OrganizationRateLimitSkillsGroup? value
    )
    {
        value = this.Value as OrganizationRateLimitSkillsGroup;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="OrganizationRateLimitWebSearchGroup"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickOrganizationRateLimitWebSearch(out var value)) {
    ///     // `value` is of type `OrganizationRateLimitWebSearchGroup`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickOrganizationRateLimitWebSearch(
        [NotNullWhen(true)] out OrganizationRateLimitWebSearchGroup? value
    )
    {
        value = this.Value as OrganizationRateLimitWebSearchGroup;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (OrganizationRateLimitModelGroup value) =&gt; {...},
    ///     (OrganizationRateLimitBatchGroup value) =&gt; {...},
    ///     (OrganizationRateLimitTokenCountGroup value) =&gt; {...},
    ///     (OrganizationRateLimitFilesGroup value) =&gt; {...},
    ///     (OrganizationRateLimitSkillsGroup value) =&gt; {...},
    ///     (OrganizationRateLimitWebSearchGroup value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<OrganizationRateLimitModelGroup> organizationRateLimitModel,
        Action<OrganizationRateLimitBatchGroup> organizationRateLimitBatch,
        Action<OrganizationRateLimitTokenCountGroup> organizationRateLimitTokenCount,
        Action<OrganizationRateLimitFilesGroup> organizationRateLimitFiles,
        Action<OrganizationRateLimitSkillsGroup> organizationRateLimitSkills,
        Action<OrganizationRateLimitWebSearchGroup> organizationRateLimitWebSearch
    )
    {
        switch (this.Value)
        {
            case OrganizationRateLimitModelGroup value:
                organizationRateLimitModel(value);
                break;
            case OrganizationRateLimitBatchGroup value:
                organizationRateLimitBatch(value);
                break;
            case OrganizationRateLimitTokenCountGroup value:
                organizationRateLimitTokenCount(value);
                break;
            case OrganizationRateLimitFilesGroup value:
                organizationRateLimitFiles(value);
                break;
            case OrganizationRateLimitSkillsGroup value:
                organizationRateLimitSkills(value);
                break;
            case OrganizationRateLimitWebSearchGroup value:
                organizationRateLimitWebSearch(value);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Group");
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (OrganizationRateLimitModelGroup value) =&gt; {...},
    ///     (OrganizationRateLimitBatchGroup value) =&gt; {...},
    ///     (OrganizationRateLimitTokenCountGroup value) =&gt; {...},
    ///     (OrganizationRateLimitFilesGroup value) =&gt; {...},
    ///     (OrganizationRateLimitSkillsGroup value) =&gt; {...},
    ///     (OrganizationRateLimitWebSearchGroup value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<OrganizationRateLimitModelGroup, T> organizationRateLimitModel,
        Func<OrganizationRateLimitBatchGroup, T> organizationRateLimitBatch,
        Func<OrganizationRateLimitTokenCountGroup, T> organizationRateLimitTokenCount,
        Func<OrganizationRateLimitFilesGroup, T> organizationRateLimitFiles,
        Func<OrganizationRateLimitSkillsGroup, T> organizationRateLimitSkills,
        Func<OrganizationRateLimitWebSearchGroup, T> organizationRateLimitWebSearch
    )
    {
        return this.Value switch
        {
            OrganizationRateLimitModelGroup value => organizationRateLimitModel(value),
            OrganizationRateLimitBatchGroup value => organizationRateLimitBatch(value),
            OrganizationRateLimitTokenCountGroup value => organizationRateLimitTokenCount(value),
            OrganizationRateLimitFilesGroup value => organizationRateLimitFiles(value),
            OrganizationRateLimitSkillsGroup value => organizationRateLimitSkills(value),
            OrganizationRateLimitWebSearchGroup value => organizationRateLimitWebSearch(value),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Group"),
        };
    }

    public static implicit operator Group(OrganizationRateLimitModelGroup value) => new(value);

    public static implicit operator Group(OrganizationRateLimitBatchGroup value) => new(value);

    public static implicit operator Group(OrganizationRateLimitTokenCountGroup value) => new(value);

    public static implicit operator Group(OrganizationRateLimitFilesGroup value) => new(value);

    public static implicit operator Group(OrganizationRateLimitSkillsGroup value) => new(value);

    public static implicit operator Group(OrganizationRateLimitWebSearchGroup value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Group");
        }
        this.Switch(
            (organizationRateLimitModel) => organizationRateLimitModel.Validate(),
            (organizationRateLimitBatch) => organizationRateLimitBatch.Validate(),
            (organizationRateLimitTokenCount) => organizationRateLimitTokenCount.Validate(),
            (organizationRateLimitFiles) => organizationRateLimitFiles.Validate(),
            (organizationRateLimitSkills) => organizationRateLimitSkills.Validate(),
            (organizationRateLimitWebSearch) => organizationRateLimitWebSearch.Validate()
        );
    }

    public virtual bool Equals(Group? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            OrganizationRateLimitModelGroup _ => 0,
            OrganizationRateLimitBatchGroup _ => 1,
            OrganizationRateLimitTokenCountGroup _ => 2,
            OrganizationRateLimitFilesGroup _ => 3,
            OrganizationRateLimitSkillsGroup _ => 4,
            OrganizationRateLimitWebSearchGroup _ => 5,
            _ => -1,
        };
    }
}

sealed class GroupConverter : JsonConverter<Group>
{
    public override Group? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "model_group":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<OrganizationRateLimitModelGroup>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "batch":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<OrganizationRateLimitBatchGroup>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "token_count":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<OrganizationRateLimitTokenCountGroup>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "files":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<OrganizationRateLimitFilesGroup>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "skills":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<OrganizationRateLimitSkillsGroup>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "web_search":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<OrganizationRateLimitWebSearchGroup>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new Group(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Group value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
