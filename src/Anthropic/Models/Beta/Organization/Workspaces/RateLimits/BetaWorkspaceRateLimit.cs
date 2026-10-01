using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using RateLimits = Anthropic.Models.Beta.Organization.RateLimits;

namespace Anthropic.Models.Beta.Organization.Workspaces.RateLimits;

[JsonConverter(typeof(JsonModelConverter<BetaWorkspaceRateLimit, BetaWorkspaceRateLimitFromRaw>))]
public sealed record class BetaWorkspaceRateLimit : JsonModel
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
    /// Deprecated: use `group.type` instead. The kind of rate-limit group this entry
    /// represents. `model_group` entries apply to a family of models (listed in
    /// `models`); other values apply to an API-surface category and have `models`
    /// set to `null`. Always equal to `group.type`.
    /// </summary>
    [Obsolete(
        "Use `group.type` instead. `group_type` is still returned and always equals `group.type`."
    )]
    public required ApiEnum<string, BetaWorkspaceRateLimitGroupType> GroupType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaWorkspaceRateLimitGroupType>>(
                "group_type"
            );
        }
        init { this._rawData.Set("group_type", value); }
    }

    /// <summary>
    /// The workspace's limiter values for this group. By default only the limiter
    /// types with a workspace-level override are listed. With `include_inherited`
    /// set to `true`, the limiter types the workspace inherits from the organization
    /// are listed too, each marked by `source`.
    /// </summary>
    public required IReadOnlyList<BetaWorkspaceRateLimitValue> Limits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaWorkspaceRateLimitValue>>(
                "limits"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaWorkspaceRateLimitValue>>(
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
        this.GroupType.Validate();
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

    [Obsolete("Required properties are deprecated: group_type")]
    public BetaWorkspaceRateLimit()
    {
        this.Type = JsonSerializer.SerializeToElement("workspace_rate_limit");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    [Obsolete("Required properties are deprecated: group_type")]
    public BetaWorkspaceRateLimit(BetaWorkspaceRateLimit betaWorkspaceRateLimit)
        : base(betaWorkspaceRateLimit) { }
#pragma warning restore CS8618

    [Obsolete("Required properties are deprecated: group_type")]
    public BetaWorkspaceRateLimit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("workspace_rate_limit");
    }

#pragma warning disable CS8618
    [Obsolete("Required properties are deprecated: group_type")]
    [SetsRequiredMembers]
    BetaWorkspaceRateLimit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWorkspaceRateLimitFromRaw.FromRawUnchecked"/>
    public static BetaWorkspaceRateLimit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWorkspaceRateLimitFromRaw : IFromRawJson<BetaWorkspaceRateLimit>
{
    /// <inheritdoc/>
    public BetaWorkspaceRateLimit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWorkspaceRateLimit.FromRawUnchecked(rawData);
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
                RateLimits::BetaOrganizationRateLimitModelGroup x => x.ID,
                RateLimits::BetaOrganizationRateLimitBatchGroup x => x.ID,
                RateLimits::BetaOrganizationRateLimitTokenCountGroup x => x.ID,
                RateLimits::BetaOrganizationRateLimitFilesGroup x => x.ID,
                RateLimits::BetaOrganizationRateLimitSkillsGroup x => x.ID,
                RateLimits::BetaOrganizationRateLimitWebSearchGroup x => x.ID,
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
                RateLimits::BetaOrganizationRateLimitModelGroup x => x.Type,
                RateLimits::BetaOrganizationRateLimitBatchGroup x => x.Type,
                RateLimits::BetaOrganizationRateLimitTokenCountGroup x => x.Type,
                RateLimits::BetaOrganizationRateLimitFilesGroup x => x.Type,
                RateLimits::BetaOrganizationRateLimitSkillsGroup x => x.Type,
                RateLimits::BetaOrganizationRateLimitWebSearchGroup x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public Group(RateLimits::BetaOrganizationRateLimitModelGroup value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Group(RateLimits::BetaOrganizationRateLimitBatchGroup value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Group(
        RateLimits::BetaOrganizationRateLimitTokenCountGroup value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Group(RateLimits::BetaOrganizationRateLimitFilesGroup value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Group(
        RateLimits::BetaOrganizationRateLimitSkillsGroup value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Group(
        RateLimits::BetaOrganizationRateLimitWebSearchGroup value,
        JsonElement? element = null
    )
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
    /// type <see cref="RateLimits::BetaOrganizationRateLimitModelGroup"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaOrganizationRateLimitModel(out var value)) {
    ///     // `value` is of type `RateLimits::BetaOrganizationRateLimitModelGroup`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaOrganizationRateLimitModel(
        [NotNullWhen(true)] out RateLimits::BetaOrganizationRateLimitModelGroup? value
    )
    {
        value = this.Value as RateLimits::BetaOrganizationRateLimitModelGroup;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RateLimits::BetaOrganizationRateLimitBatchGroup"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaOrganizationRateLimitBatch(out var value)) {
    ///     // `value` is of type `RateLimits::BetaOrganizationRateLimitBatchGroup`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaOrganizationRateLimitBatch(
        [NotNullWhen(true)] out RateLimits::BetaOrganizationRateLimitBatchGroup? value
    )
    {
        value = this.Value as RateLimits::BetaOrganizationRateLimitBatchGroup;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RateLimits::BetaOrganizationRateLimitTokenCountGroup"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaOrganizationRateLimitTokenCount(out var value)) {
    ///     // `value` is of type `RateLimits::BetaOrganizationRateLimitTokenCountGroup`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaOrganizationRateLimitTokenCount(
        [NotNullWhen(true)] out RateLimits::BetaOrganizationRateLimitTokenCountGroup? value
    )
    {
        value = this.Value as RateLimits::BetaOrganizationRateLimitTokenCountGroup;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RateLimits::BetaOrganizationRateLimitFilesGroup"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaOrganizationRateLimitFiles(out var value)) {
    ///     // `value` is of type `RateLimits::BetaOrganizationRateLimitFilesGroup`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaOrganizationRateLimitFiles(
        [NotNullWhen(true)] out RateLimits::BetaOrganizationRateLimitFilesGroup? value
    )
    {
        value = this.Value as RateLimits::BetaOrganizationRateLimitFilesGroup;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RateLimits::BetaOrganizationRateLimitSkillsGroup"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaOrganizationRateLimitSkills(out var value)) {
    ///     // `value` is of type `RateLimits::BetaOrganizationRateLimitSkillsGroup`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaOrganizationRateLimitSkills(
        [NotNullWhen(true)] out RateLimits::BetaOrganizationRateLimitSkillsGroup? value
    )
    {
        value = this.Value as RateLimits::BetaOrganizationRateLimitSkillsGroup;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RateLimits::BetaOrganizationRateLimitWebSearchGroup"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaOrganizationRateLimitWebSearch(out var value)) {
    ///     // `value` is of type `RateLimits::BetaOrganizationRateLimitWebSearchGroup`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaOrganizationRateLimitWebSearch(
        [NotNullWhen(true)] out RateLimits::BetaOrganizationRateLimitWebSearchGroup? value
    )
    {
        value = this.Value as RateLimits::BetaOrganizationRateLimitWebSearchGroup;
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
    ///     (RateLimits::BetaOrganizationRateLimitModelGroup value) =&gt; {...},
    ///     (RateLimits::BetaOrganizationRateLimitBatchGroup value) =&gt; {...},
    ///     (RateLimits::BetaOrganizationRateLimitTokenCountGroup value) =&gt; {...},
    ///     (RateLimits::BetaOrganizationRateLimitFilesGroup value) =&gt; {...},
    ///     (RateLimits::BetaOrganizationRateLimitSkillsGroup value) =&gt; {...},
    ///     (RateLimits::BetaOrganizationRateLimitWebSearchGroup value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<RateLimits::BetaOrganizationRateLimitModelGroup> betaOrganizationRateLimitModel,
        Action<RateLimits::BetaOrganizationRateLimitBatchGroup> betaOrganizationRateLimitBatch,
        Action<RateLimits::BetaOrganizationRateLimitTokenCountGroup> betaOrganizationRateLimitTokenCount,
        Action<RateLimits::BetaOrganizationRateLimitFilesGroup> betaOrganizationRateLimitFiles,
        Action<RateLimits::BetaOrganizationRateLimitSkillsGroup> betaOrganizationRateLimitSkills,
        Action<RateLimits::BetaOrganizationRateLimitWebSearchGroup> betaOrganizationRateLimitWebSearch
    )
    {
        switch (this.Value)
        {
            case RateLimits::BetaOrganizationRateLimitModelGroup value:
                betaOrganizationRateLimitModel(value);
                break;
            case RateLimits::BetaOrganizationRateLimitBatchGroup value:
                betaOrganizationRateLimitBatch(value);
                break;
            case RateLimits::BetaOrganizationRateLimitTokenCountGroup value:
                betaOrganizationRateLimitTokenCount(value);
                break;
            case RateLimits::BetaOrganizationRateLimitFilesGroup value:
                betaOrganizationRateLimitFiles(value);
                break;
            case RateLimits::BetaOrganizationRateLimitSkillsGroup value:
                betaOrganizationRateLimitSkills(value);
                break;
            case RateLimits::BetaOrganizationRateLimitWebSearchGroup value:
                betaOrganizationRateLimitWebSearch(value);
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
    ///     (RateLimits::BetaOrganizationRateLimitModelGroup value) =&gt; {...},
    ///     (RateLimits::BetaOrganizationRateLimitBatchGroup value) =&gt; {...},
    ///     (RateLimits::BetaOrganizationRateLimitTokenCountGroup value) =&gt; {...},
    ///     (RateLimits::BetaOrganizationRateLimitFilesGroup value) =&gt; {...},
    ///     (RateLimits::BetaOrganizationRateLimitSkillsGroup value) =&gt; {...},
    ///     (RateLimits::BetaOrganizationRateLimitWebSearchGroup value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<RateLimits::BetaOrganizationRateLimitModelGroup, T> betaOrganizationRateLimitModel,
        Func<RateLimits::BetaOrganizationRateLimitBatchGroup, T> betaOrganizationRateLimitBatch,
        Func<
            RateLimits::BetaOrganizationRateLimitTokenCountGroup,
            T
        > betaOrganizationRateLimitTokenCount,
        Func<RateLimits::BetaOrganizationRateLimitFilesGroup, T> betaOrganizationRateLimitFiles,
        Func<RateLimits::BetaOrganizationRateLimitSkillsGroup, T> betaOrganizationRateLimitSkills,
        Func<
            RateLimits::BetaOrganizationRateLimitWebSearchGroup,
            T
        > betaOrganizationRateLimitWebSearch
    )
    {
        return this.Value switch
        {
            RateLimits::BetaOrganizationRateLimitModelGroup value => betaOrganizationRateLimitModel(
                value
            ),
            RateLimits::BetaOrganizationRateLimitBatchGroup value => betaOrganizationRateLimitBatch(
                value
            ),
            RateLimits::BetaOrganizationRateLimitTokenCountGroup value =>
                betaOrganizationRateLimitTokenCount(value),
            RateLimits::BetaOrganizationRateLimitFilesGroup value => betaOrganizationRateLimitFiles(
                value
            ),
            RateLimits::BetaOrganizationRateLimitSkillsGroup value =>
                betaOrganizationRateLimitSkills(value),
            RateLimits::BetaOrganizationRateLimitWebSearchGroup value =>
                betaOrganizationRateLimitWebSearch(value),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Group"),
        };
    }

    public static implicit operator Group(RateLimits::BetaOrganizationRateLimitModelGroup value) =>
        new(value);

    public static implicit operator Group(RateLimits::BetaOrganizationRateLimitBatchGroup value) =>
        new(value);

    public static implicit operator Group(
        RateLimits::BetaOrganizationRateLimitTokenCountGroup value
    ) => new(value);

    public static implicit operator Group(RateLimits::BetaOrganizationRateLimitFilesGroup value) =>
        new(value);

    public static implicit operator Group(RateLimits::BetaOrganizationRateLimitSkillsGroup value) =>
        new(value);

    public static implicit operator Group(
        RateLimits::BetaOrganizationRateLimitWebSearchGroup value
    ) => new(value);

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
            (betaOrganizationRateLimitModel) => betaOrganizationRateLimitModel.Validate(),
            (betaOrganizationRateLimitBatch) => betaOrganizationRateLimitBatch.Validate(),
            (betaOrganizationRateLimitTokenCount) => betaOrganizationRateLimitTokenCount.Validate(),
            (betaOrganizationRateLimitFiles) => betaOrganizationRateLimitFiles.Validate(),
            (betaOrganizationRateLimitSkills) => betaOrganizationRateLimitSkills.Validate(),
            (betaOrganizationRateLimitWebSearch) => betaOrganizationRateLimitWebSearch.Validate()
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
            RateLimits::BetaOrganizationRateLimitModelGroup _ => 0,
            RateLimits::BetaOrganizationRateLimitBatchGroup _ => 1,
            RateLimits::BetaOrganizationRateLimitTokenCountGroup _ => 2,
            RateLimits::BetaOrganizationRateLimitFilesGroup _ => 3,
            RateLimits::BetaOrganizationRateLimitSkillsGroup _ => 4,
            RateLimits::BetaOrganizationRateLimitWebSearchGroup _ => 5,
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
                        JsonSerializer.Deserialize<RateLimits::BetaOrganizationRateLimitModelGroup>(
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
                        JsonSerializer.Deserialize<RateLimits::BetaOrganizationRateLimitBatchGroup>(
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
                        JsonSerializer.Deserialize<RateLimits::BetaOrganizationRateLimitTokenCountGroup>(
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
                        JsonSerializer.Deserialize<RateLimits::BetaOrganizationRateLimitFilesGroup>(
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
                        JsonSerializer.Deserialize<RateLimits::BetaOrganizationRateLimitSkillsGroup>(
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
                        JsonSerializer.Deserialize<RateLimits::BetaOrganizationRateLimitWebSearchGroup>(
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

/// <summary>
/// Deprecated: use `group.type` instead. The kind of rate-limit group this entry
/// represents. `model_group` entries apply to a family of models (listed in `models`);
/// other values apply to an API-surface category and have `models` set to `null`.
/// Always equal to `group.type`.
/// </summary>
[Obsolete(
    "Use `group.type` instead. `group_type` is still returned and always equals `group.type`."
)]
[JsonConverter(typeof(BetaWorkspaceRateLimitGroupTypeConverter))]
public enum BetaWorkspaceRateLimitGroupType
{
    Batch,
    Files,
    ModelGroup,
    Skills,
    TokenCount,
    WebSearch,
}

sealed class BetaWorkspaceRateLimitGroupTypeConverter
    : JsonConverter<BetaWorkspaceRateLimitGroupType>
{
    public override BetaWorkspaceRateLimitGroupType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "batch" => BetaWorkspaceRateLimitGroupType.Batch,
            "files" => BetaWorkspaceRateLimitGroupType.Files,
            "model_group" => BetaWorkspaceRateLimitGroupType.ModelGroup,
            "skills" => BetaWorkspaceRateLimitGroupType.Skills,
            "token_count" => BetaWorkspaceRateLimitGroupType.TokenCount,
            "web_search" => BetaWorkspaceRateLimitGroupType.WebSearch,
            _ => (BetaWorkspaceRateLimitGroupType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaWorkspaceRateLimitGroupType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaWorkspaceRateLimitGroupType.Batch => "batch",
                BetaWorkspaceRateLimitGroupType.Files => "files",
                BetaWorkspaceRateLimitGroupType.ModelGroup => "model_group",
                BetaWorkspaceRateLimitGroupType.Skills => "skills",
                BetaWorkspaceRateLimitGroupType.TokenCount => "token_count",
                BetaWorkspaceRateLimitGroupType.WebSearch => "web_search",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
