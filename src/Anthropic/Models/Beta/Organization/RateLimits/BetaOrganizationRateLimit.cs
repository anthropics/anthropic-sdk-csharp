using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.RateLimits;

[JsonConverter(
    typeof(JsonModelConverter<BetaOrganizationRateLimit, BetaOrganizationRateLimitFromRaw>)
)]
public sealed record class BetaOrganizationRateLimit : JsonModel
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
    /// Deprecated: use `group.type` instead. The kind of rate-limit group this entry
    /// represents. `model_group` entries apply to a family of models (listed in
    /// `models`); other values apply to an API-surface category and have `models`
    /// set to `null`. Always equal to `group.type`.
    /// </summary>
    [Obsolete(
        "Use `group.type` instead. `group_type` is still returned and always equals `group.type`."
    )]
    public required ApiEnum<string, BetaOrganizationRateLimitGroupType> GroupType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaOrganizationRateLimitGroupType>
            >("group_type");
        }
        init { this._rawData.Set("group_type", value); }
    }

    /// <summary>
    /// The limiter values that apply to this group.
    /// </summary>
    public required IReadOnlyList<BetaOrganizationRateLimitValue> Limits
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaOrganizationRateLimitValue>>(
                "limits"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaOrganizationRateLimitValue>>(
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
        this.GroupType.Validate();
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

    [Obsolete("Required properties are deprecated: group_type")]
    public BetaOrganizationRateLimit()
    {
        this.Type = JsonSerializer.SerializeToElement("rate_limit");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    [Obsolete("Required properties are deprecated: group_type")]
    public BetaOrganizationRateLimit(BetaOrganizationRateLimit betaOrganizationRateLimit)
        : base(betaOrganizationRateLimit) { }
#pragma warning restore CS8618

    [Obsolete("Required properties are deprecated: group_type")]
    public BetaOrganizationRateLimit(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("rate_limit");
    }

#pragma warning disable CS8618
    [Obsolete("Required properties are deprecated: group_type")]
    [SetsRequiredMembers]
    BetaOrganizationRateLimit(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaOrganizationRateLimitFromRaw.FromRawUnchecked"/>
    public static BetaOrganizationRateLimit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaOrganizationRateLimitFromRaw : IFromRawJson<BetaOrganizationRateLimit>
{
    /// <inheritdoc/>
    public BetaOrganizationRateLimit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaOrganizationRateLimit.FromRawUnchecked(rawData);
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
                BetaOrganizationRateLimitModelGroup x => x.ID,
                BetaOrganizationRateLimitBatchGroup x => x.ID,
                BetaOrganizationRateLimitTokenCountGroup x => x.ID,
                BetaOrganizationRateLimitFilesGroup x => x.ID,
                BetaOrganizationRateLimitSkillsGroup x => x.ID,
                BetaOrganizationRateLimitWebSearchGroup x => x.ID,
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
                BetaOrganizationRateLimitModelGroup x => x.Type,
                BetaOrganizationRateLimitBatchGroup x => x.Type,
                BetaOrganizationRateLimitTokenCountGroup x => x.Type,
                BetaOrganizationRateLimitFilesGroup x => x.Type,
                BetaOrganizationRateLimitSkillsGroup x => x.Type,
                BetaOrganizationRateLimitWebSearchGroup x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public Group(BetaOrganizationRateLimitModelGroup value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Group(BetaOrganizationRateLimitBatchGroup value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Group(BetaOrganizationRateLimitTokenCountGroup value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Group(BetaOrganizationRateLimitFilesGroup value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Group(BetaOrganizationRateLimitSkillsGroup value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Group(BetaOrganizationRateLimitWebSearchGroup value, JsonElement? element = null)
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
    /// type <see cref="BetaOrganizationRateLimitModelGroup"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaOrganizationRateLimitModel(out var value)) {
    ///     // `value` is of type `BetaOrganizationRateLimitModelGroup`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaOrganizationRateLimitModel(
        [NotNullWhen(true)] out BetaOrganizationRateLimitModelGroup? value
    )
    {
        value = this.Value as BetaOrganizationRateLimitModelGroup;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaOrganizationRateLimitBatchGroup"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaOrganizationRateLimitBatch(out var value)) {
    ///     // `value` is of type `BetaOrganizationRateLimitBatchGroup`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaOrganizationRateLimitBatch(
        [NotNullWhen(true)] out BetaOrganizationRateLimitBatchGroup? value
    )
    {
        value = this.Value as BetaOrganizationRateLimitBatchGroup;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaOrganizationRateLimitTokenCountGroup"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaOrganizationRateLimitTokenCount(out var value)) {
    ///     // `value` is of type `BetaOrganizationRateLimitTokenCountGroup`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaOrganizationRateLimitTokenCount(
        [NotNullWhen(true)] out BetaOrganizationRateLimitTokenCountGroup? value
    )
    {
        value = this.Value as BetaOrganizationRateLimitTokenCountGroup;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaOrganizationRateLimitFilesGroup"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaOrganizationRateLimitFiles(out var value)) {
    ///     // `value` is of type `BetaOrganizationRateLimitFilesGroup`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaOrganizationRateLimitFiles(
        [NotNullWhen(true)] out BetaOrganizationRateLimitFilesGroup? value
    )
    {
        value = this.Value as BetaOrganizationRateLimitFilesGroup;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaOrganizationRateLimitSkillsGroup"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaOrganizationRateLimitSkills(out var value)) {
    ///     // `value` is of type `BetaOrganizationRateLimitSkillsGroup`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaOrganizationRateLimitSkills(
        [NotNullWhen(true)] out BetaOrganizationRateLimitSkillsGroup? value
    )
    {
        value = this.Value as BetaOrganizationRateLimitSkillsGroup;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaOrganizationRateLimitWebSearchGroup"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaOrganizationRateLimitWebSearch(out var value)) {
    ///     // `value` is of type `BetaOrganizationRateLimitWebSearchGroup`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaOrganizationRateLimitWebSearch(
        [NotNullWhen(true)] out BetaOrganizationRateLimitWebSearchGroup? value
    )
    {
        value = this.Value as BetaOrganizationRateLimitWebSearchGroup;
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
    ///     (BetaOrganizationRateLimitModelGroup value) =&gt; {...},
    ///     (BetaOrganizationRateLimitBatchGroup value) =&gt; {...},
    ///     (BetaOrganizationRateLimitTokenCountGroup value) =&gt; {...},
    ///     (BetaOrganizationRateLimitFilesGroup value) =&gt; {...},
    ///     (BetaOrganizationRateLimitSkillsGroup value) =&gt; {...},
    ///     (BetaOrganizationRateLimitWebSearchGroup value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaOrganizationRateLimitModelGroup> betaOrganizationRateLimitModel,
        Action<BetaOrganizationRateLimitBatchGroup> betaOrganizationRateLimitBatch,
        Action<BetaOrganizationRateLimitTokenCountGroup> betaOrganizationRateLimitTokenCount,
        Action<BetaOrganizationRateLimitFilesGroup> betaOrganizationRateLimitFiles,
        Action<BetaOrganizationRateLimitSkillsGroup> betaOrganizationRateLimitSkills,
        Action<BetaOrganizationRateLimitWebSearchGroup> betaOrganizationRateLimitWebSearch
    )
    {
        switch (this.Value)
        {
            case BetaOrganizationRateLimitModelGroup value:
                betaOrganizationRateLimitModel(value);
                break;
            case BetaOrganizationRateLimitBatchGroup value:
                betaOrganizationRateLimitBatch(value);
                break;
            case BetaOrganizationRateLimitTokenCountGroup value:
                betaOrganizationRateLimitTokenCount(value);
                break;
            case BetaOrganizationRateLimitFilesGroup value:
                betaOrganizationRateLimitFiles(value);
                break;
            case BetaOrganizationRateLimitSkillsGroup value:
                betaOrganizationRateLimitSkills(value);
                break;
            case BetaOrganizationRateLimitWebSearchGroup value:
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
    ///     (BetaOrganizationRateLimitModelGroup value) =&gt; {...},
    ///     (BetaOrganizationRateLimitBatchGroup value) =&gt; {...},
    ///     (BetaOrganizationRateLimitTokenCountGroup value) =&gt; {...},
    ///     (BetaOrganizationRateLimitFilesGroup value) =&gt; {...},
    ///     (BetaOrganizationRateLimitSkillsGroup value) =&gt; {...},
    ///     (BetaOrganizationRateLimitWebSearchGroup value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaOrganizationRateLimitModelGroup, T> betaOrganizationRateLimitModel,
        Func<BetaOrganizationRateLimitBatchGroup, T> betaOrganizationRateLimitBatch,
        Func<BetaOrganizationRateLimitTokenCountGroup, T> betaOrganizationRateLimitTokenCount,
        Func<BetaOrganizationRateLimitFilesGroup, T> betaOrganizationRateLimitFiles,
        Func<BetaOrganizationRateLimitSkillsGroup, T> betaOrganizationRateLimitSkills,
        Func<BetaOrganizationRateLimitWebSearchGroup, T> betaOrganizationRateLimitWebSearch
    )
    {
        return this.Value switch
        {
            BetaOrganizationRateLimitModelGroup value => betaOrganizationRateLimitModel(value),
            BetaOrganizationRateLimitBatchGroup value => betaOrganizationRateLimitBatch(value),
            BetaOrganizationRateLimitTokenCountGroup value => betaOrganizationRateLimitTokenCount(
                value
            ),
            BetaOrganizationRateLimitFilesGroup value => betaOrganizationRateLimitFiles(value),
            BetaOrganizationRateLimitSkillsGroup value => betaOrganizationRateLimitSkills(value),
            BetaOrganizationRateLimitWebSearchGroup value => betaOrganizationRateLimitWebSearch(
                value
            ),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Group"),
        };
    }

    public static implicit operator Group(BetaOrganizationRateLimitModelGroup value) => new(value);

    public static implicit operator Group(BetaOrganizationRateLimitBatchGroup value) => new(value);

    public static implicit operator Group(BetaOrganizationRateLimitTokenCountGroup value) =>
        new(value);

    public static implicit operator Group(BetaOrganizationRateLimitFilesGroup value) => new(value);

    public static implicit operator Group(BetaOrganizationRateLimitSkillsGroup value) => new(value);

    public static implicit operator Group(BetaOrganizationRateLimitWebSearchGroup value) =>
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
            BetaOrganizationRateLimitModelGroup _ => 0,
            BetaOrganizationRateLimitBatchGroup _ => 1,
            BetaOrganizationRateLimitTokenCountGroup _ => 2,
            BetaOrganizationRateLimitFilesGroup _ => 3,
            BetaOrganizationRateLimitSkillsGroup _ => 4,
            BetaOrganizationRateLimitWebSearchGroup _ => 5,
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
                        JsonSerializer.Deserialize<BetaOrganizationRateLimitModelGroup>(
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
                        JsonSerializer.Deserialize<BetaOrganizationRateLimitBatchGroup>(
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
                        JsonSerializer.Deserialize<BetaOrganizationRateLimitTokenCountGroup>(
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
                        JsonSerializer.Deserialize<BetaOrganizationRateLimitFilesGroup>(
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
                        JsonSerializer.Deserialize<BetaOrganizationRateLimitSkillsGroup>(
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
                        JsonSerializer.Deserialize<BetaOrganizationRateLimitWebSearchGroup>(
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
[JsonConverter(typeof(BetaOrganizationRateLimitGroupTypeConverter))]
public enum BetaOrganizationRateLimitGroupType
{
    Batch,
    Files,
    ModelGroup,
    Skills,
    TokenCount,
    WebSearch,
}

sealed class BetaOrganizationRateLimitGroupTypeConverter
    : JsonConverter<BetaOrganizationRateLimitGroupType>
{
    public override BetaOrganizationRateLimitGroupType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "batch" => BetaOrganizationRateLimitGroupType.Batch,
            "files" => BetaOrganizationRateLimitGroupType.Files,
            "model_group" => BetaOrganizationRateLimitGroupType.ModelGroup,
            "skills" => BetaOrganizationRateLimitGroupType.Skills,
            "token_count" => BetaOrganizationRateLimitGroupType.TokenCount,
            "web_search" => BetaOrganizationRateLimitGroupType.WebSearch,
            _ => (BetaOrganizationRateLimitGroupType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaOrganizationRateLimitGroupType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaOrganizationRateLimitGroupType.Batch => "batch",
                BetaOrganizationRateLimitGroupType.Files => "files",
                BetaOrganizationRateLimitGroupType.ModelGroup => "model_group",
                BetaOrganizationRateLimitGroupType.Skills => "skills",
                BetaOrganizationRateLimitGroupType.TokenCount => "token_count",
                BetaOrganizationRateLimitGroupType.WebSearch => "web_search",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
