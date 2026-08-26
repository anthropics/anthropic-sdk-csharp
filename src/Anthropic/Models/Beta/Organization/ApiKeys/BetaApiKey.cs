using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Organization.ApiKeys;

[JsonConverter(typeof(JsonModelConverter<BetaApiKey, BetaApiKeyFromRaw>))]
public sealed record class BetaApiKey : JsonModel
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
    public required BetaApiKeyCreatedBy? CreatedBy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaApiKeyCreatedBy>("created_by");
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
    public required ApiEnum<string, BetaApiKeyStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaApiKeyStatus>>("status");
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

    /// <summary>
    /// Deprecated: use `scope` instead. ID of the Workspace associated with the API
    /// key, or `null` if the API key belongs to the default Workspace. Also `null`
    /// for a principal-bound API key that has no Workspace; `scope` tells the two apart.
    /// </summary>
    [System::Obsolete(
        "Use `scope` instead. `workspace_id` is `null` both for an API key in the default Workspace and for a principal-bound API key that has no Workspace."
    )]
    public required string? WorkspaceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("workspace_id");
        }
        init { this._rawData.Set("workspace_id", value); }
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
        _ = this.WorkspaceID;
    }

    [System::Obsolete("Required properties are deprecated: workspace_id")]
    public BetaApiKey()
    {
        this.Type = JsonSerializer.SerializeToElement("api_key");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    [System::Obsolete("Required properties are deprecated: workspace_id")]
    public BetaApiKey(BetaApiKey betaApiKey)
        : base(betaApiKey) { }
#pragma warning restore CS8618

    [System::Obsolete("Required properties are deprecated: workspace_id")]
    public BetaApiKey(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("api_key");
    }

#pragma warning disable CS8618
    [System::Obsolete("Required properties are deprecated: workspace_id")]
    [SetsRequiredMembers]
    BetaApiKey(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaApiKeyFromRaw.FromRawUnchecked"/>
    public static BetaApiKey FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaApiKeyFromRaw : IFromRawJson<BetaApiKey>
{
    /// <inheritdoc/>
    public BetaApiKey FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaApiKey.FromRawUnchecked(rawData);
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
            return Match(
                betaApiKeyUserActor: (x) => x.Type,
                betaApiKeyServiceAccountActor: (x) => x.Type
            );
        }
    }

    public Principal(BetaApiKeyUserActor value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Principal(BetaApiKeyServiceAccountActor value, JsonElement? element = null)
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
    /// type <see cref="BetaApiKeyUserActor"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaApiKeyUserActor(out var value)) {
    ///     // `value` is of type `BetaApiKeyUserActor`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaApiKeyUserActor([NotNullWhen(true)] out BetaApiKeyUserActor? value)
    {
        value = this.Value as BetaApiKeyUserActor;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaApiKeyServiceAccountActor"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaApiKeyServiceAccountActor(out var value)) {
    ///     // `value` is of type `BetaApiKeyServiceAccountActor`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaApiKeyServiceAccountActor(
        [NotNullWhen(true)] out BetaApiKeyServiceAccountActor? value
    )
    {
        value = this.Value as BetaApiKeyServiceAccountActor;
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
    ///     (BetaApiKeyUserActor value) =&gt; {...},
    ///     (BetaApiKeyServiceAccountActor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaApiKeyUserActor> betaApiKeyUserActor,
        System::Action<BetaApiKeyServiceAccountActor> betaApiKeyServiceAccountActor
    )
    {
        switch (this.Value)
        {
            case BetaApiKeyUserActor value:
                betaApiKeyUserActor(value);
                break;
            case BetaApiKeyServiceAccountActor value:
                betaApiKeyServiceAccountActor(value);
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
    ///     (BetaApiKeyUserActor value) =&gt; {...},
    ///     (BetaApiKeyServiceAccountActor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaApiKeyUserActor, T> betaApiKeyUserActor,
        System::Func<BetaApiKeyServiceAccountActor, T> betaApiKeyServiceAccountActor
    )
    {
        return this.Value switch
        {
            BetaApiKeyUserActor value => betaApiKeyUserActor(value),
            BetaApiKeyServiceAccountActor value => betaApiKeyServiceAccountActor(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Principal"
            ),
        };
    }

    public static implicit operator Principal(BetaApiKeyUserActor value) => new(value);

    public static implicit operator Principal(BetaApiKeyServiceAccountActor value) => new(value);

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
            (betaApiKeyUserActor) => betaApiKeyUserActor.Validate(),
            (betaApiKeyServiceAccountActor) => betaApiKeyServiceAccountActor.Validate()
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
            BetaApiKeyUserActor _ => 0,
            BetaApiKeyServiceAccountActor _ => 1,
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
                    var deserialized = JsonSerializer.Deserialize<BetaApiKeyUserActor>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaApiKeyServiceAccountActor>(
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
            return Match(betaApiKeyOrganization: (x) => x.Type, betaApiKeyWorkspace: (x) => x.Type);
        }
    }

    public Scope(BetaApiKeyOrganizationScope value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Scope(BetaApiKeyWorkspaceScope value, JsonElement? element = null)
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
    /// type <see cref="BetaApiKeyOrganizationScope"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaApiKeyOrganization(out var value)) {
    ///     // `value` is of type `BetaApiKeyOrganizationScope`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaApiKeyOrganization(
        [NotNullWhen(true)] out BetaApiKeyOrganizationScope? value
    )
    {
        value = this.Value as BetaApiKeyOrganizationScope;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaApiKeyWorkspaceScope"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaApiKeyWorkspace(out var value)) {
    ///     // `value` is of type `BetaApiKeyWorkspaceScope`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaApiKeyWorkspace([NotNullWhen(true)] out BetaApiKeyWorkspaceScope? value)
    {
        value = this.Value as BetaApiKeyWorkspaceScope;
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
    ///     (BetaApiKeyOrganizationScope value) =&gt; {...},
    ///     (BetaApiKeyWorkspaceScope value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaApiKeyOrganizationScope> betaApiKeyOrganization,
        System::Action<BetaApiKeyWorkspaceScope> betaApiKeyWorkspace
    )
    {
        switch (this.Value)
        {
            case BetaApiKeyOrganizationScope value:
                betaApiKeyOrganization(value);
                break;
            case BetaApiKeyWorkspaceScope value:
                betaApiKeyWorkspace(value);
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
    ///     (BetaApiKeyOrganizationScope value) =&gt; {...},
    ///     (BetaApiKeyWorkspaceScope value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaApiKeyOrganizationScope, T> betaApiKeyOrganization,
        System::Func<BetaApiKeyWorkspaceScope, T> betaApiKeyWorkspace
    )
    {
        return this.Value switch
        {
            BetaApiKeyOrganizationScope value => betaApiKeyOrganization(value),
            BetaApiKeyWorkspaceScope value => betaApiKeyWorkspace(value),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Scope"),
        };
    }

    public static implicit operator Scope(BetaApiKeyOrganizationScope value) => new(value);

    public static implicit operator Scope(BetaApiKeyWorkspaceScope value) => new(value);

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
            (betaApiKeyOrganization) => betaApiKeyOrganization.Validate(),
            (betaApiKeyWorkspace) => betaApiKeyWorkspace.Validate()
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
            BetaApiKeyOrganizationScope _ => 0,
            BetaApiKeyWorkspaceScope _ => 1,
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
                    var deserialized = JsonSerializer.Deserialize<BetaApiKeyOrganizationScope>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaApiKeyWorkspaceScope>(
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
[JsonConverter(typeof(BetaApiKeyStatusConverter))]
public enum BetaApiKeyStatus
{
    Active,
    Archived,
    Expired,
    Inactive,
}

sealed class BetaApiKeyStatusConverter : JsonConverter<BetaApiKeyStatus>
{
    public override BetaApiKeyStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => BetaApiKeyStatus.Active,
            "archived" => BetaApiKeyStatus.Archived,
            "expired" => BetaApiKeyStatus.Expired,
            "inactive" => BetaApiKeyStatus.Inactive,
            _ => (BetaApiKeyStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaApiKeyStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaApiKeyStatus.Active => "active",
                BetaApiKeyStatus.Archived => "archived",
                BetaApiKeyStatus.Expired => "expired",
                BetaApiKeyStatus.Inactive => "inactive",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
