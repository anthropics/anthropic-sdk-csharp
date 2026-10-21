using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using RateLimits = Anthropic.Models.Organization.RateLimits;

namespace Anthropic.Models.Organization.Workspaces.RateLimits;

[JsonConverter(typeof(JsonModelConverter<WorkspaceRateLimit, WorkspaceRateLimitFromRaw>))]
public sealed record class WorkspaceRateLimit : JsonModel
{
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
    /// The workspace's limiter values for this group. By default only the limiter
    /// types with a workspace-level override are listed. With `include_inherited`
    /// set to `true`, the limiter types the workspace inherits from the organization
    /// are listed too, each marked by `source`.
    /// </summary>
    public required IReadOnlyList<WorkspaceRateLimitValue> Limits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<WorkspaceRateLimitValue>>(
                "limits"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<WorkspaceRateLimitValue>>(
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
    /// The `id` of the organization's RateLimit entry this entry applies to.
    /// </summary>
    public required string RateLimitID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("rate_limit_id");
        }
        init { this._rawData.Set("rate_limit_id", value); }
    }

    /// <summary>
    /// Object type. Always `workspace_rate_limit` for workspace rate-limit entries.
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

    /// <summary>
    /// ID of the Workspace this entry applies to.
    /// </summary>
    public required string WorkspaceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("workspace_id");
        }
        init { this._rawData.Set("workspace_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Group.Validate();
        foreach (var item in this.Limits)
        {
            item.Validate();
        }
        _ = this.Models;
        _ = this.RateLimitID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("workspace_rate_limit")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.WorkspaceID;
    }

    public WorkspaceRateLimit()
    {
        this.Type = JsonSerializer.SerializeToElement("workspace_rate_limit");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WorkspaceRateLimit(WorkspaceRateLimit workspaceRateLimit)
        : base(workspaceRateLimit) { }
#pragma warning restore CS8618

    public WorkspaceRateLimit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("workspace_rate_limit");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WorkspaceRateLimit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WorkspaceRateLimitFromRaw.FromRawUnchecked"/>
    public static WorkspaceRateLimit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WorkspaceRateLimitFromRaw : IFromRawJson<WorkspaceRateLimit>
{
    /// <inheritdoc/>
    public WorkspaceRateLimit FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        WorkspaceRateLimit.FromRawUnchecked(rawData);
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
                RateLimits::OrganizationRateLimitModelGroup x => x.ID,
                RateLimits::OrganizationRateLimitBatchGroup x => x.ID,
                RateLimits::OrganizationRateLimitTokenCountGroup x => x.ID,
                RateLimits::OrganizationRateLimitFilesGroup x => x.ID,
                RateLimits::OrganizationRateLimitSkillsGroup x => x.ID,
                RateLimits::OrganizationRateLimitWebSearchGroup x => x.ID,
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
                RateLimits::OrganizationRateLimitModelGroup x => x.Type,
                RateLimits::OrganizationRateLimitBatchGroup x => x.Type,
                RateLimits::OrganizationRateLimitTokenCountGroup x => x.Type,
                RateLimits::OrganizationRateLimitFilesGroup x => x.Type,
                RateLimits::OrganizationRateLimitSkillsGroup x => x.Type,
                RateLimits::OrganizationRateLimitWebSearchGroup x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public Group(RateLimits::OrganizationRateLimitModelGroup value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Group(RateLimits::OrganizationRateLimitBatchGroup value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Group(
        RateLimits::OrganizationRateLimitTokenCountGroup value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Group(RateLimits::OrganizationRateLimitFilesGroup value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Group(RateLimits::OrganizationRateLimitSkillsGroup value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Group(RateLimits::OrganizationRateLimitWebSearchGroup value, JsonElement? element = null)
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
    /// type <see cref="RateLimits::OrganizationRateLimitModelGroup"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickOrganizationRateLimitModel(out var value)) {
    ///     // `value` is of type `RateLimits::OrganizationRateLimitModelGroup`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickOrganizationRateLimitModel(
        [NotNullWhen(true)] out RateLimits::OrganizationRateLimitModelGroup? value
    )
    {
        value = this.Value as RateLimits::OrganizationRateLimitModelGroup;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RateLimits::OrganizationRateLimitBatchGroup"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickOrganizationRateLimitBatch(out var value)) {
    ///     // `value` is of type `RateLimits::OrganizationRateLimitBatchGroup`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickOrganizationRateLimitBatch(
        [NotNullWhen(true)] out RateLimits::OrganizationRateLimitBatchGroup? value
    )
    {
        value = this.Value as RateLimits::OrganizationRateLimitBatchGroup;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RateLimits::OrganizationRateLimitTokenCountGroup"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickOrganizationRateLimitTokenCount(out var value)) {
    ///     // `value` is of type `RateLimits::OrganizationRateLimitTokenCountGroup`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickOrganizationRateLimitTokenCount(
        [NotNullWhen(true)] out RateLimits::OrganizationRateLimitTokenCountGroup? value
    )
    {
        value = this.Value as RateLimits::OrganizationRateLimitTokenCountGroup;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RateLimits::OrganizationRateLimitFilesGroup"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickOrganizationRateLimitFiles(out var value)) {
    ///     // `value` is of type `RateLimits::OrganizationRateLimitFilesGroup`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickOrganizationRateLimitFiles(
        [NotNullWhen(true)] out RateLimits::OrganizationRateLimitFilesGroup? value
    )
    {
        value = this.Value as RateLimits::OrganizationRateLimitFilesGroup;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RateLimits::OrganizationRateLimitSkillsGroup"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickOrganizationRateLimitSkills(out var value)) {
    ///     // `value` is of type `RateLimits::OrganizationRateLimitSkillsGroup`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickOrganizationRateLimitSkills(
        [NotNullWhen(true)] out RateLimits::OrganizationRateLimitSkillsGroup? value
    )
    {
        value = this.Value as RateLimits::OrganizationRateLimitSkillsGroup;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RateLimits::OrganizationRateLimitWebSearchGroup"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickOrganizationRateLimitWebSearch(out var value)) {
    ///     // `value` is of type `RateLimits::OrganizationRateLimitWebSearchGroup`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickOrganizationRateLimitWebSearch(
        [NotNullWhen(true)] out RateLimits::OrganizationRateLimitWebSearchGroup? value
    )
    {
        value = this.Value as RateLimits::OrganizationRateLimitWebSearchGroup;
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
    ///     (RateLimits::OrganizationRateLimitModelGroup value) =&gt; {...},
    ///     (RateLimits::OrganizationRateLimitBatchGroup value) =&gt; {...},
    ///     (RateLimits::OrganizationRateLimitTokenCountGroup value) =&gt; {...},
    ///     (RateLimits::OrganizationRateLimitFilesGroup value) =&gt; {...},
    ///     (RateLimits::OrganizationRateLimitSkillsGroup value) =&gt; {...},
    ///     (RateLimits::OrganizationRateLimitWebSearchGroup value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<RateLimits::OrganizationRateLimitModelGroup> organizationRateLimitModel,
        Action<RateLimits::OrganizationRateLimitBatchGroup> organizationRateLimitBatch,
        Action<RateLimits::OrganizationRateLimitTokenCountGroup> organizationRateLimitTokenCount,
        Action<RateLimits::OrganizationRateLimitFilesGroup> organizationRateLimitFiles,
        Action<RateLimits::OrganizationRateLimitSkillsGroup> organizationRateLimitSkills,
        Action<RateLimits::OrganizationRateLimitWebSearchGroup> organizationRateLimitWebSearch
    )
    {
        switch (this.Value)
        {
            case RateLimits::OrganizationRateLimitModelGroup value:
                organizationRateLimitModel(value);
                break;
            case RateLimits::OrganizationRateLimitBatchGroup value:
                organizationRateLimitBatch(value);
                break;
            case RateLimits::OrganizationRateLimitTokenCountGroup value:
                organizationRateLimitTokenCount(value);
                break;
            case RateLimits::OrganizationRateLimitFilesGroup value:
                organizationRateLimitFiles(value);
                break;
            case RateLimits::OrganizationRateLimitSkillsGroup value:
                organizationRateLimitSkills(value);
                break;
            case RateLimits::OrganizationRateLimitWebSearchGroup value:
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
    ///     (RateLimits::OrganizationRateLimitModelGroup value) =&gt; {...},
    ///     (RateLimits::OrganizationRateLimitBatchGroup value) =&gt; {...},
    ///     (RateLimits::OrganizationRateLimitTokenCountGroup value) =&gt; {...},
    ///     (RateLimits::OrganizationRateLimitFilesGroup value) =&gt; {...},
    ///     (RateLimits::OrganizationRateLimitSkillsGroup value) =&gt; {...},
    ///     (RateLimits::OrganizationRateLimitWebSearchGroup value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<RateLimits::OrganizationRateLimitModelGroup, T> organizationRateLimitModel,
        Func<RateLimits::OrganizationRateLimitBatchGroup, T> organizationRateLimitBatch,
        Func<RateLimits::OrganizationRateLimitTokenCountGroup, T> organizationRateLimitTokenCount,
        Func<RateLimits::OrganizationRateLimitFilesGroup, T> organizationRateLimitFiles,
        Func<RateLimits::OrganizationRateLimitSkillsGroup, T> organizationRateLimitSkills,
        Func<RateLimits::OrganizationRateLimitWebSearchGroup, T> organizationRateLimitWebSearch
    )
    {
        return this.Value switch
        {
            RateLimits::OrganizationRateLimitModelGroup value => organizationRateLimitModel(value),
            RateLimits::OrganizationRateLimitBatchGroup value => organizationRateLimitBatch(value),
            RateLimits::OrganizationRateLimitTokenCountGroup value =>
                organizationRateLimitTokenCount(value),
            RateLimits::OrganizationRateLimitFilesGroup value => organizationRateLimitFiles(value),
            RateLimits::OrganizationRateLimitSkillsGroup value => organizationRateLimitSkills(
                value
            ),
            RateLimits::OrganizationRateLimitWebSearchGroup value => organizationRateLimitWebSearch(
                value
            ),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Group"),
        };
    }

    public static implicit operator Group(RateLimits::OrganizationRateLimitModelGroup value) =>
        new(value);

    public static implicit operator Group(RateLimits::OrganizationRateLimitBatchGroup value) =>
        new(value);

    public static implicit operator Group(RateLimits::OrganizationRateLimitTokenCountGroup value) =>
        new(value);

    public static implicit operator Group(RateLimits::OrganizationRateLimitFilesGroup value) =>
        new(value);

    public static implicit operator Group(RateLimits::OrganizationRateLimitSkillsGroup value) =>
        new(value);

    public static implicit operator Group(RateLimits::OrganizationRateLimitWebSearchGroup value) =>
        new(value);

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
            RateLimits::OrganizationRateLimitModelGroup _ => 0,
            RateLimits::OrganizationRateLimitBatchGroup _ => 1,
            RateLimits::OrganizationRateLimitTokenCountGroup _ => 2,
            RateLimits::OrganizationRateLimitFilesGroup _ => 3,
            RateLimits::OrganizationRateLimitSkillsGroup _ => 4,
            RateLimits::OrganizationRateLimitWebSearchGroup _ => 5,
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
                    var deserialized =
                        JsonSerializer.Deserialize<RateLimits::OrganizationRateLimitModelGroup>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<RateLimits::OrganizationRateLimitBatchGroup>(
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
                        JsonSerializer.Deserialize<RateLimits::OrganizationRateLimitTokenCountGroup>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<RateLimits::OrganizationRateLimitFilesGroup>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<RateLimits::OrganizationRateLimitSkillsGroup>(
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
                        JsonSerializer.Deserialize<RateLimits::OrganizationRateLimitWebSearchGroup>(
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
