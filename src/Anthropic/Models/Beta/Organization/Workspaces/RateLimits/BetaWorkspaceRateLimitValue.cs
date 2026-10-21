using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Workspaces.RateLimits;

[JsonConverter(
    typeof(JsonModelConverter<BetaWorkspaceRateLimitValue, BetaWorkspaceRateLimitValueFromRaw>)
)]
public sealed record class BetaWorkspaceRateLimitValue : JsonModel
{
    /// <summary>
    /// The organization-level value for the same limiter type, for reference. `null`
    /// when the organization has no limit configured for this limiter type.
    /// </summary>
    public required long? OrgLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("org_limit");
        }
        init { this._rawData.Set("org_limit", value); }
    }

    /// <summary>
    /// Where `value` comes from. `organization` values are listed only when `include_inherited`
    /// is `true`, and then `value` equals `org_limit`.
    /// </summary>
    public required Source Source
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Source>("source");
        }
        init { this._rawData.Set("source", value); }
    }

    /// <summary>
    /// The limiter type (for example, `requests_per_minute` or `input_tokens_per_minute`).
    /// </summary>
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The workspace's value for this limiter type: the workspace-level override
    /// when `source.type` is `workspace`, otherwise the organization's value.
    /// </summary>
    public required long Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.OrgLimit;
        this.Source.Validate();
        _ = this.Type;
        _ = this.Value;
    }

    public BetaWorkspaceRateLimitValue() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWorkspaceRateLimitValue(BetaWorkspaceRateLimitValue betaWorkspaceRateLimitValue)
        : base(betaWorkspaceRateLimitValue) { }
#pragma warning restore CS8618

    public BetaWorkspaceRateLimitValue(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWorkspaceRateLimitValue(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWorkspaceRateLimitValueFromRaw.FromRawUnchecked"/>
    public static BetaWorkspaceRateLimitValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWorkspaceRateLimitValueFromRaw : IFromRawJson<BetaWorkspaceRateLimitValue>
{
    /// <inheritdoc/>
    public BetaWorkspaceRateLimitValue FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWorkspaceRateLimitValue.FromRawUnchecked(rawData);
}

/// <summary>
/// Where `value` comes from. `organization` values are listed only when `include_inherited`
/// is `true`, and then `value` equals `org_limit`.
/// </summary>
[JsonConverter(typeof(SourceConverter))]
public record class Source : ModelBase
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

    public JsonElement Type
    {
        get
        {
            return this.Value switch
            {
                BetaWorkspaceRateLimitWorkspaceSource x => x.Type,
                BetaWorkspaceRateLimitOrganizationSource x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public Source(BetaWorkspaceRateLimitWorkspaceSource value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Source(BetaWorkspaceRateLimitOrganizationSource value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Source(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWorkspaceRateLimitWorkspaceSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaWorkspaceRateLimitWorkspace(out var value)) {
    ///     // `value` is of type `BetaWorkspaceRateLimitWorkspaceSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaWorkspaceRateLimitWorkspace(
        [NotNullWhen(true)] out BetaWorkspaceRateLimitWorkspaceSource? value
    )
    {
        value = this.Value as BetaWorkspaceRateLimitWorkspaceSource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWorkspaceRateLimitOrganizationSource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaWorkspaceRateLimitOrganization(out var value)) {
    ///     // `value` is of type `BetaWorkspaceRateLimitOrganizationSource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaWorkspaceRateLimitOrganization(
        [NotNullWhen(true)] out BetaWorkspaceRateLimitOrganizationSource? value
    )
    {
        value = this.Value as BetaWorkspaceRateLimitOrganizationSource;
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
    ///     (BetaWorkspaceRateLimitWorkspaceSource value) =&gt; {...},
    ///     (BetaWorkspaceRateLimitOrganizationSource value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaWorkspaceRateLimitWorkspaceSource> betaWorkspaceRateLimitWorkspace,
        Action<BetaWorkspaceRateLimitOrganizationSource> betaWorkspaceRateLimitOrganization
    )
    {
        switch (this.Value)
        {
            case BetaWorkspaceRateLimitWorkspaceSource value:
                betaWorkspaceRateLimitWorkspace(value);
                break;
            case BetaWorkspaceRateLimitOrganizationSource value:
                betaWorkspaceRateLimitOrganization(value);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Source");
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
    ///     (BetaWorkspaceRateLimitWorkspaceSource value) =&gt; {...},
    ///     (BetaWorkspaceRateLimitOrganizationSource value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaWorkspaceRateLimitWorkspaceSource, T> betaWorkspaceRateLimitWorkspace,
        Func<BetaWorkspaceRateLimitOrganizationSource, T> betaWorkspaceRateLimitOrganization
    )
    {
        return this.Value switch
        {
            BetaWorkspaceRateLimitWorkspaceSource value => betaWorkspaceRateLimitWorkspace(value),
            BetaWorkspaceRateLimitOrganizationSource value => betaWorkspaceRateLimitOrganization(
                value
            ),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Source"
            ),
        };
    }

    public static implicit operator Source(BetaWorkspaceRateLimitWorkspaceSource value) =>
        new(value);

    public static implicit operator Source(BetaWorkspaceRateLimitOrganizationSource value) =>
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
            throw new AnthropicInvalidDataException("Data did not match any variant of Source");
        }
        this.Switch(
            (betaWorkspaceRateLimitWorkspace) => betaWorkspaceRateLimitWorkspace.Validate(),
            (betaWorkspaceRateLimitOrganization) => betaWorkspaceRateLimitOrganization.Validate()
        );
    }

    public virtual bool Equals(Source? other) =>
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
            BetaWorkspaceRateLimitWorkspaceSource _ => 0,
            BetaWorkspaceRateLimitOrganizationSource _ => 1,
            _ => -1,
        };
    }
}

sealed class SourceConverter : JsonConverter<Source>
{
    public override Source? Read(
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
            case "workspace":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaWorkspaceRateLimitWorkspaceSource>(
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
            case "organization":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaWorkspaceRateLimitOrganizationSource>(
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
                return new Source(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Source value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
