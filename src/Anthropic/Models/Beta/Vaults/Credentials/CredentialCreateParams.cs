using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Services.Beta.Vaults;
using System = System;

namespace Anthropic.Models.Beta.Vaults.Credentials;

/// <summary>
/// Create Credential
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CredentialCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? VaultID { get; init; }

    /// <summary>
    /// Authentication details for creating a credential.
    /// </summary>
    public required Auth Auth
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<Auth>("auth");
        }
        init { this._rawBodyData.Set("auth", value); }
    }

    /// <summary>
    /// Human-readable name for the credential. Up to 255 characters.
    /// </summary>
    public string? DisplayName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("display_name");
        }
        init { this._rawBodyData.Set("display_name", value); }
    }

    /// <summary>
    /// Arbitrary key-value metadata to attach to the credential. Maximum 16 pairs,
    /// keys up to 64 chars, values up to 512 chars.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Optional header to specify the beta version(s) you want to use.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, AnthropicBeta>>? Betas
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, AnthropicBeta>>
            >("anthropic-beta");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set<ImmutableArray<ApiEnum<string, AnthropicBeta>>?>(
                "anthropic-beta",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public CredentialCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CredentialCreateParams(CredentialCreateParams credentialCreateParams)
        : base(credentialCreateParams)
    {
        this.VaultID = credentialCreateParams.VaultID;

        this._rawBodyData = new(credentialCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public CredentialCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CredentialCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string vaultID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.VaultID = vaultID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CredentialCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string vaultID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            vaultID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["VaultID"] = JsonSerializer.SerializeToElement(this.VaultID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(CredentialCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.VaultID?.Equals(other.VaultID) ?? other.VaultID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        var queryString = this.QueryString(options);
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/vaults/{0}/credentials", this.VaultID)
        )
        {
            Query = string.IsNullOrEmpty(queryString) ? "beta=true" : ("beta=true&" + queryString),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        CredentialService.AddDefaultHeaders(request);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// Authentication details for creating a credential.
/// </summary>
[JsonConverter(typeof(AuthConverter))]
public record class Auth : ModelBase
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
                betaManagedAgentsMcpOAuthCreateParams: (x) => x.McpServerUrl,
                betaManagedAgentsStaticBearerCreateParams: (x) => x.McpServerUrl
            );
        }
    }

    public Auth(BetaManagedAgentsMcpOAuthCreateParams value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Auth(BetaManagedAgentsStaticBearerCreateParams value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Auth(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsMcpOAuthCreateParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsMcpOAuthCreateParams(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsMcpOAuthCreateParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsMcpOAuthCreateParams(
        [NotNullWhen(true)] out BetaManagedAgentsMcpOAuthCreateParams? value
    )
    {
        value = this.Value as BetaManagedAgentsMcpOAuthCreateParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsStaticBearerCreateParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsStaticBearerCreateParams(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsStaticBearerCreateParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsStaticBearerCreateParams(
        [NotNullWhen(true)] out BetaManagedAgentsStaticBearerCreateParams? value
    )
    {
        value = this.Value as BetaManagedAgentsStaticBearerCreateParams;
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
    ///     (BetaManagedAgentsMcpOAuthCreateParams value) =&gt; {...},
    ///     (BetaManagedAgentsStaticBearerCreateParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsMcpOAuthCreateParams> betaManagedAgentsMcpOAuthCreateParams,
        System::Action<BetaManagedAgentsStaticBearerCreateParams> betaManagedAgentsStaticBearerCreateParams
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsMcpOAuthCreateParams value:
                betaManagedAgentsMcpOAuthCreateParams(value);
                break;
            case BetaManagedAgentsStaticBearerCreateParams value:
                betaManagedAgentsStaticBearerCreateParams(value);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Auth");
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
    ///     (BetaManagedAgentsMcpOAuthCreateParams value) =&gt; {...},
    ///     (BetaManagedAgentsStaticBearerCreateParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<
            BetaManagedAgentsMcpOAuthCreateParams,
            T
        > betaManagedAgentsMcpOAuthCreateParams,
        System::Func<
            BetaManagedAgentsStaticBearerCreateParams,
            T
        > betaManagedAgentsStaticBearerCreateParams
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsMcpOAuthCreateParams value => betaManagedAgentsMcpOAuthCreateParams(
                value
            ),
            BetaManagedAgentsStaticBearerCreateParams value =>
                betaManagedAgentsStaticBearerCreateParams(value),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Auth"),
        };
    }

    public static implicit operator Auth(BetaManagedAgentsMcpOAuthCreateParams value) => new(value);

    public static implicit operator Auth(BetaManagedAgentsStaticBearerCreateParams value) =>
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
            throw new AnthropicInvalidDataException("Data did not match any variant of Auth");
        }
        this.Switch(
            (betaManagedAgentsMcpOAuthCreateParams) =>
                betaManagedAgentsMcpOAuthCreateParams.Validate(),
            (betaManagedAgentsStaticBearerCreateParams) =>
                betaManagedAgentsStaticBearerCreateParams.Validate()
        );
    }

    public virtual bool Equals(Auth? other) =>
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
            BetaManagedAgentsMcpOAuthCreateParams _ => 0,
            BetaManagedAgentsStaticBearerCreateParams _ => 1,
            _ => -1,
        };
    }
}

sealed class AuthConverter : JsonConverter<Auth>
{
    public override Auth? Read(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsMcpOAuthCreateParams>(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsStaticBearerCreateParams>(
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
                return new Auth(element);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Auth value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
