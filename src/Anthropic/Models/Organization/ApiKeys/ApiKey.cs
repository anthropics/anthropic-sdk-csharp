using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Organization.ApiKeys;

[JsonConverter(typeof(JsonModelConverter<ApiKey, ApiKeyFromRaw>))]
public sealed record class ApiKey : JsonModel
{
    /// <summary>
    /// ID of the API key.
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
    /// RFC 3339 datetime string indicating when the API Key was created.
    /// </summary>
    public required System::DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// The ID and type of the actor that created the API key, or `null` when the
    /// creator is not recorded (legacy, workload-identity-federated, or system-created keys).
    /// </summary>
    public required ApiKeyCreatedBy? CreatedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiKeyCreatedBy>("created_by");
        }
        init { this._rawData.Set("created_by", value); }
    }

    /// <summary>
    /// RFC 3339 datetime string indicating when the API Key expires, or `null` if
    /// it never expires.
    /// </summary>
    public required System::DateTimeOffset? ExpiresAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("expires_at");
        }
        init { this._rawData.Set("expires_at", value); }
    }

    /// <summary>
    /// Name of the API key.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Partially redacted hint for the API key.
    /// </summary>
    public required string? PartialKeyHint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("partial_key_hint");
        }
        init { this._rawData.Set("partial_key_hint", value); }
    }

    /// <summary>
    /// The principal the API key acts as (a User or a Service Account), or `null`
    /// if the API key is not bound to a principal.
    /// </summary>
    public required Principal? Principal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Principal>("principal");
        }
        init { this._rawData.Set("principal", value); }
    }

    /// <summary>
    /// Where the API key belongs: its Workspace (`{"type": "workspace", "workspace_id":
    /// "wrkspc_..."}`, with the Workspace's real ID even when it is the organization's
    /// default Workspace), or the organization (`{"type": "organization"}`) for
    /// a principal-bound API key that has no Workspace.
    /// </summary>
    public required Scope Scope
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Scope>("scope");
        }
        init { this._rawData.Set("scope", value); }
    }

    /// <summary>
    /// Status of the API key.
    /// </summary>
    public required ApiEnum<string, ApiKeyStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ApiKeyStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Object type.
    ///
    /// <para>For API Keys, this is always `"api_key"`.</para>
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
        _ = this.CreatedAt;
        this.CreatedBy?.Validate();
        _ = this.ExpiresAt;
        _ = this.Name;
        _ = this.PartialKeyHint;
        this.Principal?.Validate();
        this.Scope.Validate();
        this.Status.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("api_key")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ApiKey()
    {
        this.Type = JsonSerializer.SerializeToElement("api_key");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiKey(ApiKey apiKey)
        : base(apiKey) { }
#pragma warning restore CS8618

    public ApiKey(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("api_key");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiKey(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiKeyFromRaw.FromRawUnchecked"/>
    public static ApiKey FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApiKeyFromRaw : IFromRawJson<ApiKey>
{
    /// <inheritdoc/>
    public ApiKey FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ApiKey.FromRawUnchecked(rawData);
}

/// <summary>
/// The principal the API key acts as (a User or a Service Account), or `null` if
/// the API key is not bound to a principal.
/// </summary>
[JsonConverter(typeof(PrincipalConverter))]
public record class Principal : ModelBase
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
                ApiKeyUserActor x => x.Type,
                ApiKeyServiceAccountActor x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public Principal(ApiKeyUserActor value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Principal(ApiKeyServiceAccountActor value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Principal(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ApiKeyUserActor"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickApiKeyUserActor(out var value)) {
    ///     // `value` is of type `ApiKeyUserActor`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickApiKeyUserActor([NotNullWhen(true)] out ApiKeyUserActor? value)
    {
        value = this.Value as ApiKeyUserActor;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ApiKeyServiceAccountActor"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickApiKeyServiceAccountActor(out var value)) {
    ///     // `value` is of type `ApiKeyServiceAccountActor`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickApiKeyServiceAccountActor(
        [NotNullWhen(true)] out ApiKeyServiceAccountActor? value
    )
    {
        value = this.Value as ApiKeyServiceAccountActor;
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
    ///     (ApiKeyUserActor value) =&gt; {...},
    ///     (ApiKeyServiceAccountActor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<ApiKeyUserActor> apiKeyUserActor,
        System::Action<ApiKeyServiceAccountActor> apiKeyServiceAccountActor
    )
    {
        switch (this.Value)
        {
            case ApiKeyUserActor value:
                apiKeyUserActor(value);
                break;
            case ApiKeyServiceAccountActor value:
                apiKeyServiceAccountActor(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Principal"
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
    ///     (ApiKeyUserActor value) =&gt; {...},
    ///     (ApiKeyServiceAccountActor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<ApiKeyUserActor, T> apiKeyUserActor,
        System::Func<ApiKeyServiceAccountActor, T> apiKeyServiceAccountActor
    )
    {
        return this.Value switch
        {
            ApiKeyUserActor value => apiKeyUserActor(value),
            ApiKeyServiceAccountActor value => apiKeyServiceAccountActor(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Principal"
            ),
        };
    }

    public static implicit operator Principal(ApiKeyUserActor value) => new(value);

    public static implicit operator Principal(ApiKeyServiceAccountActor value) => new(value);

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
            throw new AnthropicInvalidDataException("Data did not match any variant of Principal");
        }
        this.Switch(
            (apiKeyUserActor) => apiKeyUserActor.Validate(),
            (apiKeyServiceAccountActor) => apiKeyServiceAccountActor.Validate()
        );
    }

    public virtual bool Equals(Principal? other) =>
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
            ApiKeyUserActor _ => 0,
            ApiKeyServiceAccountActor _ => 1,
            _ => -1,
        };
    }
}

sealed class PrincipalConverter : JsonConverter<Principal?>
{
    public override Principal? Read(
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
            case "user_actor":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ApiKeyUserActor>(
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
            case "service_account_actor":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ApiKeyServiceAccountActor>(
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
                return new Principal(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        Principal? value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value?.Json, options);
    }
}

/// <summary>
/// Where the API key belongs: its Workspace (`{"type": "workspace", "workspace_id":
/// "wrkspc_..."}`, with the Workspace's real ID even when it is the organization's
/// default Workspace), or the organization (`{"type": "organization"}`) for a principal-bound
/// API key that has no Workspace.
/// </summary>
[JsonConverter(typeof(ScopeConverter))]
public record class Scope : ModelBase
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
                ApiKeyOrganizationScope x => x.Type,
                ApiKeyWorkspaceScope x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public Scope(ApiKeyOrganizationScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Scope(ApiKeyWorkspaceScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Scope(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ApiKeyOrganizationScope"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickApiKeyOrganization(out var value)) {
    ///     // `value` is of type `ApiKeyOrganizationScope`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickApiKeyOrganization([NotNullWhen(true)] out ApiKeyOrganizationScope? value)
    {
        value = this.Value as ApiKeyOrganizationScope;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ApiKeyWorkspaceScope"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickApiKeyWorkspace(out var value)) {
    ///     // `value` is of type `ApiKeyWorkspaceScope`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickApiKeyWorkspace([NotNullWhen(true)] out ApiKeyWorkspaceScope? value)
    {
        value = this.Value as ApiKeyWorkspaceScope;
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
    ///     (ApiKeyOrganizationScope value) =&gt; {...},
    ///     (ApiKeyWorkspaceScope value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<ApiKeyOrganizationScope> apiKeyOrganization,
        System::Action<ApiKeyWorkspaceScope> apiKeyWorkspace
    )
    {
        switch (this.Value)
        {
            case ApiKeyOrganizationScope value:
                apiKeyOrganization(value);
                break;
            case ApiKeyWorkspaceScope value:
                apiKeyWorkspace(value);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Scope");
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
    ///     (ApiKeyOrganizationScope value) =&gt; {...},
    ///     (ApiKeyWorkspaceScope value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<ApiKeyOrganizationScope, T> apiKeyOrganization,
        System::Func<ApiKeyWorkspaceScope, T> apiKeyWorkspace
    )
    {
        return this.Value switch
        {
            ApiKeyOrganizationScope value => apiKeyOrganization(value),
            ApiKeyWorkspaceScope value => apiKeyWorkspace(value),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Scope"),
        };
    }

    public static implicit operator Scope(ApiKeyOrganizationScope value) => new(value);

    public static implicit operator Scope(ApiKeyWorkspaceScope value) => new(value);

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
            throw new AnthropicInvalidDataException("Data did not match any variant of Scope");
        }
        this.Switch(
            (apiKeyOrganization) => apiKeyOrganization.Validate(),
            (apiKeyWorkspace) => apiKeyWorkspace.Validate()
        );
    }

    public virtual bool Equals(Scope? other) =>
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
            ApiKeyOrganizationScope _ => 0,
            ApiKeyWorkspaceScope _ => 1,
            _ => -1,
        };
    }
}

sealed class ScopeConverter : JsonConverter<Scope>
{
    public override Scope? Read(
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
                    var deserialized = JsonSerializer.Deserialize<ApiKeyOrganizationScope>(
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
            case "workspace":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ApiKeyWorkspaceScope>(
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
                return new Scope(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Scope value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Status of the API key.
/// </summary>
[JsonConverter(typeof(ApiKeyStatusConverter))]
public enum ApiKeyStatus
{
    Active,
    Archived,
    Expired,
    Inactive,
}

sealed class ApiKeyStatusConverter : JsonConverter<ApiKeyStatus>
{
    public override ApiKeyStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => ApiKeyStatus.Active,
            "archived" => ApiKeyStatus.Archived,
            "expired" => ApiKeyStatus.Expired,
            "inactive" => ApiKeyStatus.Inactive,
            _ => (ApiKeyStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ApiKeyStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ApiKeyStatus.Active => "active",
                ApiKeyStatus.Archived => "archived",
                ApiKeyStatus.Expired => "expired",
                ApiKeyStatus.Inactive => "inactive",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
