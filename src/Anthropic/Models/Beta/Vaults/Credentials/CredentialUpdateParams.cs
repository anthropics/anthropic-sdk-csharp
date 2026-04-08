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
/// Update Credential
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CredentialUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string VaultID { get; init; }

    public string? CredentialID { get; init; }

    /// <summary>
    /// Updated authentication details for a credential.
    /// </summary>
    public CredentialUpdateParamsAuth? Auth
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<CredentialUpdateParamsAuth>("auth");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("auth", value);
        }
    }

    /// <summary>
    /// Updated human-readable name for the credential. 1-255 characters.
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
    /// Metadata patch. Set a key to a string to upsert it, or to null to delete
    /// it. Omitted keys are preserved.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? Metadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string?>>(
                "metadata"
            );
        }
        init
        {
            this._rawBodyData.Set<FrozenDictionary<string, string?>?>(
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

    public CredentialUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CredentialUpdateParams(CredentialUpdateParams credentialUpdateParams)
        : base(credentialUpdateParams)
    {
        this.VaultID = credentialUpdateParams.VaultID;
        this.CredentialID = credentialUpdateParams.CredentialID;

        this._rawBodyData = new(credentialUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public CredentialUpdateParams(
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
    CredentialUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string vaultID,
        string credentialID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.VaultID = vaultID;
        this.CredentialID = credentialID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CredentialUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string vaultID,
        string credentialID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            vaultID,
            credentialID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["VaultID"] = JsonSerializer.SerializeToElement(this.VaultID),
                    ["CredentialID"] = JsonSerializer.SerializeToElement(this.CredentialID),
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

    public virtual bool Equals(CredentialUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.VaultID.Equals(other.VaultID)
            && (this.CredentialID?.Equals(other.CredentialID) ?? other.CredentialID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        var queryString = this.QueryString(options);
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/vaults/{0}/credentials/{1}", this.VaultID, this.CredentialID)
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
/// Updated authentication details for a credential.
/// </summary>
[JsonConverter(typeof(CredentialUpdateParamsAuthConverter))]
public record class CredentialUpdateParamsAuth : ModelBase
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

    public CredentialUpdateParamsAuth(
        BetaManagedAgentsMcpOAuthUpdateParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CredentialUpdateParamsAuth(
        BetaManagedAgentsStaticBearerUpdateParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public CredentialUpdateParamsAuth(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsMcpOAuthUpdateParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsMcpOAuthUpdateParams(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsMcpOAuthUpdateParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsMcpOAuthUpdateParams(
        [NotNullWhen(true)] out BetaManagedAgentsMcpOAuthUpdateParams? value
    )
    {
        value = this.Value as BetaManagedAgentsMcpOAuthUpdateParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsStaticBearerUpdateParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsStaticBearerUpdateParams(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsStaticBearerUpdateParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsStaticBearerUpdateParams(
        [NotNullWhen(true)] out BetaManagedAgentsStaticBearerUpdateParams? value
    )
    {
        value = this.Value as BetaManagedAgentsStaticBearerUpdateParams;
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
    ///     (BetaManagedAgentsMcpOAuthUpdateParams value) =&gt; {...},
    ///     (BetaManagedAgentsStaticBearerUpdateParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsMcpOAuthUpdateParams> betaManagedAgentsMcpOAuthUpdateParams,
        System::Action<BetaManagedAgentsStaticBearerUpdateParams> betaManagedAgentsStaticBearerUpdateParams
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsMcpOAuthUpdateParams value:
                betaManagedAgentsMcpOAuthUpdateParams(value);
                break;
            case BetaManagedAgentsStaticBearerUpdateParams value:
                betaManagedAgentsStaticBearerUpdateParams(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of CredentialUpdateParamsAuth"
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
    ///     (BetaManagedAgentsMcpOAuthUpdateParams value) =&gt; {...},
    ///     (BetaManagedAgentsStaticBearerUpdateParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<
            BetaManagedAgentsMcpOAuthUpdateParams,
            T
        > betaManagedAgentsMcpOAuthUpdateParams,
        System::Func<
            BetaManagedAgentsStaticBearerUpdateParams,
            T
        > betaManagedAgentsStaticBearerUpdateParams
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsMcpOAuthUpdateParams value => betaManagedAgentsMcpOAuthUpdateParams(
                value
            ),
            BetaManagedAgentsStaticBearerUpdateParams value =>
                betaManagedAgentsStaticBearerUpdateParams(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of CredentialUpdateParamsAuth"
            ),
        };
    }

    public static implicit operator CredentialUpdateParamsAuth(
        BetaManagedAgentsMcpOAuthUpdateParams value
    ) => new(value);

    public static implicit operator CredentialUpdateParamsAuth(
        BetaManagedAgentsStaticBearerUpdateParams value
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
                "Data did not match any variant of CredentialUpdateParamsAuth"
            );
        }
        this.Switch(
            (betaManagedAgentsMcpOAuthUpdateParams) =>
                betaManagedAgentsMcpOAuthUpdateParams.Validate(),
            (betaManagedAgentsStaticBearerUpdateParams) =>
                betaManagedAgentsStaticBearerUpdateParams.Validate()
        );
    }

    public virtual bool Equals(CredentialUpdateParamsAuth? other) =>
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
            BetaManagedAgentsMcpOAuthUpdateParams _ => 0,
            BetaManagedAgentsStaticBearerUpdateParams _ => 1,
            _ => -1,
        };
    }
}

sealed class CredentialUpdateParamsAuthConverter : JsonConverter<CredentialUpdateParamsAuth>
{
    public override CredentialUpdateParamsAuth? Read(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsMcpOAuthUpdateParams>(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsStaticBearerUpdateParams>(
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
                return new CredentialUpdateParamsAuth(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        CredentialUpdateParamsAuth value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
