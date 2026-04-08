using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Vaults.Credentials;

/// <summary>
/// A credential stored in a vault. Sensitive fields are never returned in responses.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsCredential, BetaManagedAgentsCredentialFromRaw>)
)]
public sealed record class BetaManagedAgentsCredential : JsonModel
{
    /// <summary>
    /// Unique identifier for the credential.
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
    /// A timestamp in RFC 3339 format
    /// </summary>
    public required System::DateTimeOffset? ArchivedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("archived_at");
        }
        init { this._rawData.Set("archived_at", value); }
    }

    /// <summary>
    /// Authentication details for a credential.
    /// </summary>
    public required BetaManagedAgentsCredentialAuth Auth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsCredentialAuth>("auth");
        }
        init { this._rawData.Set("auth", value); }
    }

    /// <summary>
    /// A timestamp in RFC 3339 format
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
    /// Arbitrary key-value metadata attached to the credential.
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public required ApiEnum<string, global::Anthropic.Models.Beta.Vaults.Credentials.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Anthropic.Models.Beta.Vaults.Credentials.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// A timestamp in RFC 3339 format
    /// </summary>
    public required System::DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// Identifier of the vault this credential belongs to.
    /// </summary>
    public required string VaultID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("vault_id");
        }
        init { this._rawData.Set("vault_id", value); }
    }

    /// <summary>
    /// Human-readable name for the credential.
    /// </summary>
    public string? DisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("display_name");
        }
        init { this._rawData.Set("display_name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ArchivedAt;
        this.Auth.Validate();
        _ = this.CreatedAt;
        _ = this.Metadata;
        this.Type.Validate();
        _ = this.UpdatedAt;
        _ = this.VaultID;
        _ = this.DisplayName;
    }

    public BetaManagedAgentsCredential() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsCredential(BetaManagedAgentsCredential betaManagedAgentsCredential)
        : base(betaManagedAgentsCredential) { }
#pragma warning restore CS8618

    public BetaManagedAgentsCredential(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsCredential(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsCredentialFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsCredential FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsCredentialFromRaw : IFromRawJson<BetaManagedAgentsCredential>
{
    /// <inheritdoc/>
    public BetaManagedAgentsCredential FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsCredential.FromRawUnchecked(rawData);
}

/// <summary>
/// Authentication details for a credential.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsCredentialAuthConverter))]
public record class BetaManagedAgentsCredentialAuth : ModelBase
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

    public string McpServerUrl
    {
        get
        {
            return Match(
                betaManagedAgentsMcpOAuthAuthResponse: (x) => x.McpServerUrl,
                betaManagedAgentsStaticBearerAuthResponse: (x) => x.McpServerUrl
            );
        }
    }

    public BetaManagedAgentsCredentialAuth(
        BetaManagedAgentsMcpOAuthAuthResponse value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsCredentialAuth(
        BetaManagedAgentsStaticBearerAuthResponse value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsCredentialAuth(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsMcpOAuthAuthResponse"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsMcpOAuthAuthResponse(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsMcpOAuthAuthResponse`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsMcpOAuthAuthResponse(
        [NotNullWhen(true)] out BetaManagedAgentsMcpOAuthAuthResponse? value
    )
    {
        value = this.Value as BetaManagedAgentsMcpOAuthAuthResponse;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsStaticBearerAuthResponse"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsStaticBearerAuthResponse(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsStaticBearerAuthResponse`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsStaticBearerAuthResponse(
        [NotNullWhen(true)] out BetaManagedAgentsStaticBearerAuthResponse? value
    )
    {
        value = this.Value as BetaManagedAgentsStaticBearerAuthResponse;
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
    ///     (BetaManagedAgentsMcpOAuthAuthResponse value) =&gt; {...},
    ///     (BetaManagedAgentsStaticBearerAuthResponse value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsMcpOAuthAuthResponse> betaManagedAgentsMcpOAuthAuthResponse,
        System::Action<BetaManagedAgentsStaticBearerAuthResponse> betaManagedAgentsStaticBearerAuthResponse
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsMcpOAuthAuthResponse value:
                betaManagedAgentsMcpOAuthAuthResponse(value);
                break;
            case BetaManagedAgentsStaticBearerAuthResponse value:
                betaManagedAgentsStaticBearerAuthResponse(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsCredentialAuth"
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
    ///     (BetaManagedAgentsMcpOAuthAuthResponse value) =&gt; {...},
    ///     (BetaManagedAgentsStaticBearerAuthResponse value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<
            BetaManagedAgentsMcpOAuthAuthResponse,
            T
        > betaManagedAgentsMcpOAuthAuthResponse,
        System::Func<
            BetaManagedAgentsStaticBearerAuthResponse,
            T
        > betaManagedAgentsStaticBearerAuthResponse
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsMcpOAuthAuthResponse value => betaManagedAgentsMcpOAuthAuthResponse(
                value
            ),
            BetaManagedAgentsStaticBearerAuthResponse value =>
                betaManagedAgentsStaticBearerAuthResponse(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsCredentialAuth"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsCredentialAuth(
        BetaManagedAgentsMcpOAuthAuthResponse value
    ) => new(value);

    public static implicit operator BetaManagedAgentsCredentialAuth(
        BetaManagedAgentsStaticBearerAuthResponse value
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
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsCredentialAuth"
            );
        }
        this.Switch(
            (betaManagedAgentsMcpOAuthAuthResponse) =>
                betaManagedAgentsMcpOAuthAuthResponse.Validate(),
            (betaManagedAgentsStaticBearerAuthResponse) =>
                betaManagedAgentsStaticBearerAuthResponse.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsCredentialAuth? other) =>
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
            BetaManagedAgentsMcpOAuthAuthResponse _ => 0,
            BetaManagedAgentsStaticBearerAuthResponse _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsCredentialAuthConverter
    : JsonConverter<BetaManagedAgentsCredentialAuth>
{
    public override BetaManagedAgentsCredentialAuth? Read(
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
            case "mcp_oauth":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsMcpOAuthAuthResponse>(
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
            case "static_bearer":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsStaticBearerAuthResponse>(
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
                return new BetaManagedAgentsCredentialAuth(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsCredentialAuth value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    VaultCredential,
}

sealed class TypeConverter : JsonConverter<global::Anthropic.Models.Beta.Vaults.Credentials.Type>
{
    public override global::Anthropic.Models.Beta.Vaults.Credentials.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "vault_credential" => global::Anthropic
                .Models
                .Beta
                .Vaults
                .Credentials
                .Type
                .VaultCredential,
            _ => (global::Anthropic.Models.Beta.Vaults.Credentials.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Models.Beta.Vaults.Credentials.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Anthropic.Models.Beta.Vaults.Credentials.Type.VaultCredential =>
                    "vault_credential",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
