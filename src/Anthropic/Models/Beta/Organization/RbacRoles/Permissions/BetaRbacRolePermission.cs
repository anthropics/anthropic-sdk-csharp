using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.RbacRoles.Permissions;

[JsonConverter(typeof(JsonModelConverter<BetaRbacRolePermission, BetaRbacRolePermissionFromRaw>))]
public sealed record class BetaRbacRolePermission : JsonModel
{
    /// <summary>
    /// Action the permission grants on the resource.
    ///
    /// <para>The vocabulary follows the resource: an `organization` grant carries
    /// a product-feature entitlement (for example `chat`), an admin-panel permission
    /// entitlement (`permission_*`), or a blanket capability-access mode — `capability_access_all`
    /// grants every product-feature entitlement, and `capability_access_all_ga` grants
    /// the generally-available subset as it stands at permission-check time; neither
    /// mode grants model-access entitlements. A consumer enumerating a role's per-feature
    /// grants should treat a blanket row as granting every product-feature entitlement
    /// it covers, or it will under-report the role's effective access. A `connector_tool`
    /// grant carries a tool-access action (`use` or `always_allow`); a `connector_scope`
    /// grant carries the scope action `grant` (the role may receive the named OAuth
    /// scope when tokens are minted for the connector); `connector` and `all_connectors`
    /// grants carry a tool-access action, the scope action, or an authentication-method
    /// action (`interactive` or `managed`).</para>
    /// </summary>
    public required string Action
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("action");
        }
        init { this._rawData.Set("action", value); }
    }

    /// <summary>
    /// What the permission applies to.
    ///
    /// <para>A tagged union: `type` names the kind of resource and determines which
    /// identifier fields are present.</para>
    /// </summary>
    public required Resource Resource
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Resource>("resource");
        }
        init { this._rawData.Set("resource", value); }
    }

    /// <summary>
    /// Object type.
    ///
    /// <para>For RBAC Role Permissions, this is always `"rbac_role_permission"`.</para>
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
        _ = this.Action;
        this.Resource.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("rbac_role_permission")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaRbacRolePermission()
    {
        this.Type = JsonSerializer.SerializeToElement("rbac_role_permission");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaRbacRolePermission(BetaRbacRolePermission betaRbacRolePermission)
        : base(betaRbacRolePermission) { }
#pragma warning restore CS8618

    public BetaRbacRolePermission(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("rbac_role_permission");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRbacRolePermission(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaRbacRolePermissionFromRaw.FromRawUnchecked"/>
    public static BetaRbacRolePermission FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaRbacRolePermissionFromRaw : IFromRawJson<BetaRbacRolePermission>
{
    /// <inheritdoc/>
    public BetaRbacRolePermission FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaRbacRolePermission.FromRawUnchecked(rawData);
}

/// <summary>
/// What the permission applies to.
///
/// <para>A tagged union: `type` names the kind of resource and determines which
/// identifier fields are present.</para>
/// </summary>
[JsonConverter(typeof(ResourceConverter))]
public record class Resource : ModelBase
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
                BetaRbacOrganizationPermissionResource x => x.Type,
                BetaRbacConnectorToolPermissionResource x => x.Type,
                BetaRbacConnectorScopePermissionResource x => x.Type,
                BetaRbacConnectorPermissionResource x => x.Type,
                BetaRbacAllConnectorsPermissionResource x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public string? ConnectorID
    {
        get
        {
            return this.Value switch
            {
                BetaRbacOrganizationPermissionResource _ => null,
                BetaRbacConnectorToolPermissionResource x => x.ConnectorID,
                BetaRbacConnectorScopePermissionResource x => x.ConnectorID,
                BetaRbacConnectorPermissionResource x => x.ConnectorID,
                BetaRbacAllConnectorsPermissionResource _ => null,
                _ => WrappedJsonSerializer.GetNullableClassProperty<string>(
                    this.Json,
                    "connector_id"
                ),
            };
        }
    }

    public Resource(BetaRbacOrganizationPermissionResource value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Resource(BetaRbacConnectorToolPermissionResource value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Resource(BetaRbacConnectorScopePermissionResource value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Resource(BetaRbacConnectorPermissionResource value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Resource(BetaRbacAllConnectorsPermissionResource value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Resource(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaRbacOrganizationPermissionResource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaRbacOrganizationPermission(out var value)) {
    ///     // `value` is of type `BetaRbacOrganizationPermissionResource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaRbacOrganizationPermission(
        [NotNullWhen(true)] out BetaRbacOrganizationPermissionResource? value
    )
    {
        value = this.Value as BetaRbacOrganizationPermissionResource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaRbacConnectorToolPermissionResource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaRbacConnectorToolPermission(out var value)) {
    ///     // `value` is of type `BetaRbacConnectorToolPermissionResource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaRbacConnectorToolPermission(
        [NotNullWhen(true)] out BetaRbacConnectorToolPermissionResource? value
    )
    {
        value = this.Value as BetaRbacConnectorToolPermissionResource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaRbacConnectorScopePermissionResource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaRbacConnectorScopePermission(out var value)) {
    ///     // `value` is of type `BetaRbacConnectorScopePermissionResource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaRbacConnectorScopePermission(
        [NotNullWhen(true)] out BetaRbacConnectorScopePermissionResource? value
    )
    {
        value = this.Value as BetaRbacConnectorScopePermissionResource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaRbacConnectorPermissionResource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaRbacConnectorPermission(out var value)) {
    ///     // `value` is of type `BetaRbacConnectorPermissionResource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaRbacConnectorPermission(
        [NotNullWhen(true)] out BetaRbacConnectorPermissionResource? value
    )
    {
        value = this.Value as BetaRbacConnectorPermissionResource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaRbacAllConnectorsPermissionResource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaRbacAllConnectorsPermission(out var value)) {
    ///     // `value` is of type `BetaRbacAllConnectorsPermissionResource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaRbacAllConnectorsPermission(
        [NotNullWhen(true)] out BetaRbacAllConnectorsPermissionResource? value
    )
    {
        value = this.Value as BetaRbacAllConnectorsPermissionResource;
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
    ///     (BetaRbacOrganizationPermissionResource value) =&gt; {...},
    ///     (BetaRbacConnectorToolPermissionResource value) =&gt; {...},
    ///     (BetaRbacConnectorScopePermissionResource value) =&gt; {...},
    ///     (BetaRbacConnectorPermissionResource value) =&gt; {...},
    ///     (BetaRbacAllConnectorsPermissionResource value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaRbacOrganizationPermissionResource> betaRbacOrganizationPermission,
        Action<BetaRbacConnectorToolPermissionResource> betaRbacConnectorToolPermission,
        Action<BetaRbacConnectorScopePermissionResource> betaRbacConnectorScopePermission,
        Action<BetaRbacConnectorPermissionResource> betaRbacConnectorPermission,
        Action<BetaRbacAllConnectorsPermissionResource> betaRbacAllConnectorsPermission
    )
    {
        switch (this.Value)
        {
            case BetaRbacOrganizationPermissionResource value:
                betaRbacOrganizationPermission(value);
                break;
            case BetaRbacConnectorToolPermissionResource value:
                betaRbacConnectorToolPermission(value);
                break;
            case BetaRbacConnectorScopePermissionResource value:
                betaRbacConnectorScopePermission(value);
                break;
            case BetaRbacConnectorPermissionResource value:
                betaRbacConnectorPermission(value);
                break;
            case BetaRbacAllConnectorsPermissionResource value:
                betaRbacAllConnectorsPermission(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Resource"
                );
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
    ///     (BetaRbacOrganizationPermissionResource value) =&gt; {...},
    ///     (BetaRbacConnectorToolPermissionResource value) =&gt; {...},
    ///     (BetaRbacConnectorScopePermissionResource value) =&gt; {...},
    ///     (BetaRbacConnectorPermissionResource value) =&gt; {...},
    ///     (BetaRbacAllConnectorsPermissionResource value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaRbacOrganizationPermissionResource, T> betaRbacOrganizationPermission,
        Func<BetaRbacConnectorToolPermissionResource, T> betaRbacConnectorToolPermission,
        Func<BetaRbacConnectorScopePermissionResource, T> betaRbacConnectorScopePermission,
        Func<BetaRbacConnectorPermissionResource, T> betaRbacConnectorPermission,
        Func<BetaRbacAllConnectorsPermissionResource, T> betaRbacAllConnectorsPermission
    )
    {
        return this.Value switch
        {
            BetaRbacOrganizationPermissionResource value => betaRbacOrganizationPermission(value),
            BetaRbacConnectorToolPermissionResource value => betaRbacConnectorToolPermission(value),
            BetaRbacConnectorScopePermissionResource value => betaRbacConnectorScopePermission(
                value
            ),
            BetaRbacConnectorPermissionResource value => betaRbacConnectorPermission(value),
            BetaRbacAllConnectorsPermissionResource value => betaRbacAllConnectorsPermission(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Resource"
            ),
        };
    }

    public static implicit operator Resource(BetaRbacOrganizationPermissionResource value) =>
        new(value);

    public static implicit operator Resource(BetaRbacConnectorToolPermissionResource value) =>
        new(value);

    public static implicit operator Resource(BetaRbacConnectorScopePermissionResource value) =>
        new(value);

    public static implicit operator Resource(BetaRbacConnectorPermissionResource value) =>
        new(value);

    public static implicit operator Resource(BetaRbacAllConnectorsPermissionResource value) =>
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
            throw new AnthropicInvalidDataException("Data did not match any variant of Resource");
        }
        this.Switch(
            (betaRbacOrganizationPermission) => betaRbacOrganizationPermission.Validate(),
            (betaRbacConnectorToolPermission) => betaRbacConnectorToolPermission.Validate(),
            (betaRbacConnectorScopePermission) => betaRbacConnectorScopePermission.Validate(),
            (betaRbacConnectorPermission) => betaRbacConnectorPermission.Validate(),
            (betaRbacAllConnectorsPermission) => betaRbacAllConnectorsPermission.Validate()
        );
    }

    public virtual bool Equals(Resource? other) =>
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
            BetaRbacOrganizationPermissionResource _ => 0,
            BetaRbacConnectorToolPermissionResource _ => 1,
            BetaRbacConnectorScopePermissionResource _ => 2,
            BetaRbacConnectorPermissionResource _ => 3,
            BetaRbacAllConnectorsPermissionResource _ => 4,
            _ => -1,
        };
    }
}

sealed class ResourceConverter : JsonConverter<Resource>
{
    public override Resource? Read(
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
            case "organization":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaRbacOrganizationPermissionResource>(
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
            case "connector_tool":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaRbacConnectorToolPermissionResource>(
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
            case "connector_scope":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaRbacConnectorScopePermissionResource>(
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
            case "connector":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaRbacConnectorPermissionResource>(
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
            case "all_connectors":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaRbacAllConnectorsPermissionResource>(
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
                return new Resource(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Resource value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
