using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.RbacRoles.Permissions;

[JsonConverter(typeof(JsonModelConverter<RbacRolePermission, RbacRolePermissionFromRaw>))]
public sealed record class RbacRolePermission : JsonModel
{
    /// <summary>
    /// Action the permission grants on the resource.
    ///
    /// <para>The vocabulary follows the resource: an `organization` grant carries
    /// a product-feature entitlement (for example `chat`), an admin-panel permission
    /// entitlement (`permission_*`), or a blanket capability-access mode — `capability_access_all`
    /// grants every product-feature entitlement except `inference_hooks_inspection`,
    /// which a role holds only through its own row, and `capability_access_all_ga`
    /// grants the generally-available subset of those as it stands at permission-check
    /// time; neither mode grants model-access entitlements. A consumer enumerating
    /// a role's per-feature grants should treat a blanket row as granting every
    /// product-feature entitlement it covers, or it will under-report the role's
    /// effective access. A `connector_tool` grant carries a tool-access action (`use`
    /// or `always_allow`); a `connector_scope` grant carries the scope action `grant`
    /// (the role may receive the named OAuth scope when tokens are minted for the
    /// connector); `connector` and `all_connectors` grants carry a tool-access action,
    /// the scope action, or an authentication-method action (`interactive` or `managed`).</para>
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

    public RbacRolePermission()
    {
        this.Type = JsonSerializer.SerializeToElement("rbac_role_permission");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RbacRolePermission(RbacRolePermission rbacRolePermission)
        : base(rbacRolePermission) { }
#pragma warning restore CS8618

    public RbacRolePermission(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("rbac_role_permission");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RbacRolePermission(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RbacRolePermissionFromRaw.FromRawUnchecked"/>
    public static RbacRolePermission FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RbacRolePermissionFromRaw : IFromRawJson<RbacRolePermission>
{
    /// <inheritdoc/>
    public RbacRolePermission FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RbacRolePermission.FromRawUnchecked(rawData);
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

    public ApiEnum<string, ResourceType> Type
    {
        get
        {
            return this.Value switch
            {
                RbacOrganizationPermissionResource _ => ResourceType.Organization,
                RbacConnectorToolPermissionResource _ => ResourceType.ConnectorTool,
                RbacConnectorScopePermissionResource _ => ResourceType.ConnectorScope,
                RbacConnectorPermissionResource _ => ResourceType.Connector,
                RbacAllConnectorsPermissionResource _ => ResourceType.AllConnectors,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<ApiEnum<string, ResourceType>>(
                    this.Json,
                    "type"
                ),
            };
        }
    }

    public string? ConnectorID
    {
        get
        {
            return this.Value switch
            {
                RbacOrganizationPermissionResource _ => null,
                RbacConnectorToolPermissionResource x => x.ConnectorID,
                RbacConnectorScopePermissionResource x => x.ConnectorID,
                RbacConnectorPermissionResource x => x.ConnectorID,
                RbacAllConnectorsPermissionResource _ => null,
                _ => WrappedJsonSerializer.GetNullableClassProperty<string>(
                    this.Json,
                    "connector_id"
                ),
            };
        }
    }

    public Resource(RbacOrganizationPermissionResource value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Resource(RbacConnectorToolPermissionResource value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Resource(RbacConnectorScopePermissionResource value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Resource(RbacConnectorPermissionResource value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Resource(RbacAllConnectorsPermissionResource value, JsonElement? element = null)
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
    /// type <see cref="RbacOrganizationPermissionResource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRbacOrganizationPermission(out var value)) {
    ///     // `value` is of type `RbacOrganizationPermissionResource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRbacOrganizationPermission(
        [NotNullWhen(true)] out RbacOrganizationPermissionResource? value
    )
    {
        value = this.Value as RbacOrganizationPermissionResource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RbacConnectorToolPermissionResource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRbacConnectorToolPermission(out var value)) {
    ///     // `value` is of type `RbacConnectorToolPermissionResource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRbacConnectorToolPermission(
        [NotNullWhen(true)] out RbacConnectorToolPermissionResource? value
    )
    {
        value = this.Value as RbacConnectorToolPermissionResource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RbacConnectorScopePermissionResource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRbacConnectorScopePermission(out var value)) {
    ///     // `value` is of type `RbacConnectorScopePermissionResource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRbacConnectorScopePermission(
        [NotNullWhen(true)] out RbacConnectorScopePermissionResource? value
    )
    {
        value = this.Value as RbacConnectorScopePermissionResource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RbacConnectorPermissionResource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRbacConnectorPermission(out var value)) {
    ///     // `value` is of type `RbacConnectorPermissionResource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRbacConnectorPermission(
        [NotNullWhen(true)] out RbacConnectorPermissionResource? value
    )
    {
        value = this.Value as RbacConnectorPermissionResource;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RbacAllConnectorsPermissionResource"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRbacAllConnectorsPermission(out var value)) {
    ///     // `value` is of type `RbacAllConnectorsPermissionResource`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRbacAllConnectorsPermission(
        [NotNullWhen(true)] out RbacAllConnectorsPermissionResource? value
    )
    {
        value = this.Value as RbacAllConnectorsPermissionResource;
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
    ///     (RbacOrganizationPermissionResource value) =&gt; {...},
    ///     (RbacConnectorToolPermissionResource value) =&gt; {...},
    ///     (RbacConnectorScopePermissionResource value) =&gt; {...},
    ///     (RbacConnectorPermissionResource value) =&gt; {...},
    ///     (RbacAllConnectorsPermissionResource value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<RbacOrganizationPermissionResource> rbacOrganizationPermission,
        Action<RbacConnectorToolPermissionResource> rbacConnectorToolPermission,
        Action<RbacConnectorScopePermissionResource> rbacConnectorScopePermission,
        Action<RbacConnectorPermissionResource> rbacConnectorPermission,
        Action<RbacAllConnectorsPermissionResource> rbacAllConnectorsPermission
    )
    {
        switch (this.Value)
        {
            case RbacOrganizationPermissionResource value:
                rbacOrganizationPermission(value);
                break;
            case RbacConnectorToolPermissionResource value:
                rbacConnectorToolPermission(value);
                break;
            case RbacConnectorScopePermissionResource value:
                rbacConnectorScopePermission(value);
                break;
            case RbacConnectorPermissionResource value:
                rbacConnectorPermission(value);
                break;
            case RbacAllConnectorsPermissionResource value:
                rbacAllConnectorsPermission(value);
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
    ///     (RbacOrganizationPermissionResource value) =&gt; {...},
    ///     (RbacConnectorToolPermissionResource value) =&gt; {...},
    ///     (RbacConnectorScopePermissionResource value) =&gt; {...},
    ///     (RbacConnectorPermissionResource value) =&gt; {...},
    ///     (RbacAllConnectorsPermissionResource value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<RbacOrganizationPermissionResource, T> rbacOrganizationPermission,
        Func<RbacConnectorToolPermissionResource, T> rbacConnectorToolPermission,
        Func<RbacConnectorScopePermissionResource, T> rbacConnectorScopePermission,
        Func<RbacConnectorPermissionResource, T> rbacConnectorPermission,
        Func<RbacAllConnectorsPermissionResource, T> rbacAllConnectorsPermission
    )
    {
        return this.Value switch
        {
            RbacOrganizationPermissionResource value => rbacOrganizationPermission(value),
            RbacConnectorToolPermissionResource value => rbacConnectorToolPermission(value),
            RbacConnectorScopePermissionResource value => rbacConnectorScopePermission(value),
            RbacConnectorPermissionResource value => rbacConnectorPermission(value),
            RbacAllConnectorsPermissionResource value => rbacAllConnectorsPermission(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Resource"
            ),
        };
    }

    public static implicit operator Resource(RbacOrganizationPermissionResource value) =>
        new(value);

    public static implicit operator Resource(RbacConnectorToolPermissionResource value) =>
        new(value);

    public static implicit operator Resource(RbacConnectorScopePermissionResource value) =>
        new(value);

    public static implicit operator Resource(RbacConnectorPermissionResource value) => new(value);

    public static implicit operator Resource(RbacAllConnectorsPermissionResource value) =>
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
            (rbacOrganizationPermission) => rbacOrganizationPermission.Validate(),
            (rbacConnectorToolPermission) => rbacConnectorToolPermission.Validate(),
            (rbacConnectorScopePermission) => rbacConnectorScopePermission.Validate(),
            (rbacConnectorPermission) => rbacConnectorPermission.Validate(),
            (rbacAllConnectorsPermission) => rbacAllConnectorsPermission.Validate()
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
            RbacOrganizationPermissionResource _ => 0,
            RbacConnectorToolPermissionResource _ => 1,
            RbacConnectorScopePermissionResource _ => 2,
            RbacConnectorPermissionResource _ => 3,
            RbacAllConnectorsPermissionResource _ => 4,
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
                        JsonSerializer.Deserialize<RbacOrganizationPermissionResource>(
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
                        JsonSerializer.Deserialize<RbacConnectorToolPermissionResource>(
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
                        JsonSerializer.Deserialize<RbacConnectorScopePermissionResource>(
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
                    var deserialized = JsonSerializer.Deserialize<RbacConnectorPermissionResource>(
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
                        JsonSerializer.Deserialize<RbacAllConnectorsPermissionResource>(
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

[JsonConverter(typeof(ResourceTypeConverter))]
public enum ResourceType
{
    Organization,
    ConnectorTool,
    ConnectorScope,
    Connector,
    AllConnectors,
}

sealed class ResourceTypeConverter : JsonConverter<ResourceType>
{
    public override ResourceType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "organization" => ResourceType.Organization,
            "connector_tool" => ResourceType.ConnectorTool,
            "connector_scope" => ResourceType.ConnectorScope,
            "connector" => ResourceType.Connector,
            "all_connectors" => ResourceType.AllConnectors,
            _ => (ResourceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ResourceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ResourceType.Organization => "organization",
                ResourceType.ConnectorTool => "connector_tool",
                ResourceType.ConnectorScope => "connector_scope",
                ResourceType.Connector => "connector",
                ResourceType.AllConnectors => "all_connectors",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
