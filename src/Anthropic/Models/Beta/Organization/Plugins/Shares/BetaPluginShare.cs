using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Organization.Plugins.Shares;

/// <summary>
/// One share the owner of a member-owned Plugin has given. Shares are read-only in
/// this API and have no ID of their own; who gave a share is recorded on the Compliance
/// API activity feed, not here.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaPluginShare, BetaPluginShareFromRaw>))]
public sealed record class BetaPluginShare : JsonModel
{
    /// <summary>
    /// When the share was given; a share whose role is later changed in claude.ai
    /// is re-granted and carries the time of that change.
    /// </summary>
    public required System::DateTimeOffset GrantedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("granted_at");
        }
        init { this._rawData.Set("granted_at", value); }
    }

    /// <summary>
    /// The Plugin's ID.
    /// </summary>
    public required string PluginID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("plugin_id");
        }
        init { this._rawData.Set("plugin_id", value); }
    }

    /// <summary>
    /// Who the Plugin is shared with: `organization` (every member), `rbac_group`
    /// (one RBAC Group), or `organization_member` (one member).
    /// </summary>
    public required Target Target
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Target>("target");
        }
        init { this._rawData.Set("target", value); }
    }

    /// <summary>
    /// Always `plugin_share`.
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
        _ = this.GrantedAt;
        _ = this.PluginID;
        this.Target.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("plugin_share")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaPluginShare()
    {
        this.Type = JsonSerializer.SerializeToElement("plugin_share");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaPluginShare(BetaPluginShare betaPluginShare)
        : base(betaPluginShare) { }
#pragma warning restore CS8618

    public BetaPluginShare(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("plugin_share");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaPluginShare(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaPluginShareFromRaw.FromRawUnchecked"/>
    public static BetaPluginShare FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaPluginShareFromRaw : IFromRawJson<BetaPluginShare>
{
    /// <inheritdoc/>
    public BetaPluginShare FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaPluginShare.FromRawUnchecked(rawData);
}

/// <summary>
/// Who the Plugin is shared with: `organization` (every member), `rbac_group` (one
/// RBAC Group), or `organization_member` (one member).
/// </summary>
[JsonConverter(typeof(TargetConverter))]
public record class Target : ModelBase
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
                BetaPluginTargetOrganization x => x.Type,
                BetaPluginTargetRbacGroup x => x.Type,
                BetaPluginTargetOrganizationMember x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public Target(BetaPluginTargetOrganization value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Target(BetaPluginTargetRbacGroup value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Target(BetaPluginTargetOrganizationMember value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Target(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaPluginTargetOrganization"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaPluginTargetOrganization(out var value)) {
    ///     // `value` is of type `BetaPluginTargetOrganization`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaPluginTargetOrganization(
        [NotNullWhen(true)] out BetaPluginTargetOrganization? value
    )
    {
        value = this.Value as BetaPluginTargetOrganization;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaPluginTargetRbacGroup"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaPluginTargetRbacGroup(out var value)) {
    ///     // `value` is of type `BetaPluginTargetRbacGroup`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaPluginTargetRbacGroup(
        [NotNullWhen(true)] out BetaPluginTargetRbacGroup? value
    )
    {
        value = this.Value as BetaPluginTargetRbacGroup;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaPluginTargetOrganizationMember"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaPluginTargetOrganizationMember(out var value)) {
    ///     // `value` is of type `BetaPluginTargetOrganizationMember`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaPluginTargetOrganizationMember(
        [NotNullWhen(true)] out BetaPluginTargetOrganizationMember? value
    )
    {
        value = this.Value as BetaPluginTargetOrganizationMember;
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
    ///     (BetaPluginTargetOrganization value) =&gt; {...},
    ///     (BetaPluginTargetRbacGroup value) =&gt; {...},
    ///     (BetaPluginTargetOrganizationMember value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaPluginTargetOrganization> betaPluginTargetOrganization,
        System::Action<BetaPluginTargetRbacGroup> betaPluginTargetRbacGroup,
        System::Action<BetaPluginTargetOrganizationMember> betaPluginTargetOrganizationMember
    )
    {
        switch (this.Value)
        {
            case BetaPluginTargetOrganization value:
                betaPluginTargetOrganization(value);
                break;
            case BetaPluginTargetRbacGroup value:
                betaPluginTargetRbacGroup(value);
                break;
            case BetaPluginTargetOrganizationMember value:
                betaPluginTargetOrganizationMember(value);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Target");
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
    ///     (BetaPluginTargetOrganization value) =&gt; {...},
    ///     (BetaPluginTargetRbacGroup value) =&gt; {...},
    ///     (BetaPluginTargetOrganizationMember value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaPluginTargetOrganization, T> betaPluginTargetOrganization,
        System::Func<BetaPluginTargetRbacGroup, T> betaPluginTargetRbacGroup,
        System::Func<BetaPluginTargetOrganizationMember, T> betaPluginTargetOrganizationMember
    )
    {
        return this.Value switch
        {
            BetaPluginTargetOrganization value => betaPluginTargetOrganization(value),
            BetaPluginTargetRbacGroup value => betaPluginTargetRbacGroup(value),
            BetaPluginTargetOrganizationMember value => betaPluginTargetOrganizationMember(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Target"
            ),
        };
    }

    public static implicit operator Target(BetaPluginTargetOrganization value) => new(value);

    public static implicit operator Target(BetaPluginTargetRbacGroup value) => new(value);

    public static implicit operator Target(BetaPluginTargetOrganizationMember value) => new(value);

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
            throw new AnthropicInvalidDataException("Data did not match any variant of Target");
        }
        this.Switch(
            (betaPluginTargetOrganization) => betaPluginTargetOrganization.Validate(),
            (betaPluginTargetRbacGroup) => betaPluginTargetRbacGroup.Validate(),
            (betaPluginTargetOrganizationMember) => betaPluginTargetOrganizationMember.Validate()
        );
    }

    public virtual bool Equals(Target? other) =>
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
            BetaPluginTargetOrganization _ => 0,
            BetaPluginTargetRbacGroup _ => 1,
            BetaPluginTargetOrganizationMember _ => 2,
            _ => -1,
        };
    }
}

sealed class TargetConverter : JsonConverter<Target>
{
    public override Target? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
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
            case "organization":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaPluginTargetOrganization>(
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
            case "rbac_group":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaPluginTargetRbacGroup>(
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
            case "organization_member":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaPluginTargetOrganizationMember>(
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
                return new Target(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Target value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
