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
/// OAuth refresh token parameters for creating a credential with refresh support.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMcpOAuthRefreshParams,
        BetaManagedAgentsMcpOAuthRefreshParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMcpOAuthRefreshParams : JsonModel
{
    /// <summary>
    /// OAuth client ID.
    /// </summary>
    public required string ClientID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("client_id");
        }
        init { this._rawData.Set("client_id", value); }
    }

    /// <summary>
    /// OAuth refresh token.
    /// </summary>
    public required string RefreshToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("refresh_token");
        }
        init { this._rawData.Set("refresh_token", value); }
    }

    /// <summary>
    /// Token endpoint URL used to refresh the access token.
    /// </summary>
    public required string TokenEndpoint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("token_endpoint");
        }
        init { this._rawData.Set("token_endpoint", value); }
    }

    /// <summary>
    /// Token endpoint requires no client authentication.
    /// </summary>
    public required TokenEndpointAuth TokenEndpointAuth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TokenEndpointAuth>("token_endpoint_auth");
        }
        init { this._rawData.Set("token_endpoint_auth", value); }
    }

    /// <summary>
    /// OAuth resource indicator.
    /// </summary>
    public string? Resource
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("resource");
        }
        init { this._rawData.Set("resource", value); }
    }

    /// <summary>
    /// OAuth scope for the refresh request.
    /// </summary>
    public string? Scope
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("scope");
        }
        init { this._rawData.Set("scope", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ClientID;
        _ = this.RefreshToken;
        _ = this.TokenEndpoint;
        this.TokenEndpointAuth.Validate();
        _ = this.Resource;
        _ = this.Scope;
    }

    public BetaManagedAgentsMcpOAuthRefreshParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMcpOAuthRefreshParams(
        BetaManagedAgentsMcpOAuthRefreshParams betaManagedAgentsMcpOAuthRefreshParams
    )
        : base(betaManagedAgentsMcpOAuthRefreshParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMcpOAuthRefreshParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMcpOAuthRefreshParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMcpOAuthRefreshParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMcpOAuthRefreshParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMcpOAuthRefreshParamsFromRaw
    : IFromRawJson<BetaManagedAgentsMcpOAuthRefreshParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMcpOAuthRefreshParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMcpOAuthRefreshParams.FromRawUnchecked(rawData);
}

/// <summary>
/// Token endpoint requires no client authentication.
/// </summary>
[JsonConverter(typeof(TokenEndpointAuthConverter))]
public record class TokenEndpointAuth : ModelBase
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

    public string? ClientSecret
    {
        get
        {
            return Match<string?>(
                betaManagedAgentsTokenEndpointAuthNoneParam: (_) => null,
                betaManagedAgentsTokenEndpointAuthBasicParam: (x) => x.ClientSecret,
                betaManagedAgentsTokenEndpointAuthPostParam: (x) => x.ClientSecret
            );
        }
    }

    public TokenEndpointAuth(
        BetaManagedAgentsTokenEndpointAuthNoneParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TokenEndpointAuth(
        BetaManagedAgentsTokenEndpointAuthBasicParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TokenEndpointAuth(
        BetaManagedAgentsTokenEndpointAuthPostParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TokenEndpointAuth(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsTokenEndpointAuthNoneParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsTokenEndpointAuthNoneParam(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsTokenEndpointAuthNoneParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsTokenEndpointAuthNoneParam(
        [NotNullWhen(true)] out BetaManagedAgentsTokenEndpointAuthNoneParam? value
    )
    {
        value = this.Value as BetaManagedAgentsTokenEndpointAuthNoneParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsTokenEndpointAuthBasicParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsTokenEndpointAuthBasicParam(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsTokenEndpointAuthBasicParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsTokenEndpointAuthBasicParam(
        [NotNullWhen(true)] out BetaManagedAgentsTokenEndpointAuthBasicParam? value
    )
    {
        value = this.Value as BetaManagedAgentsTokenEndpointAuthBasicParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsTokenEndpointAuthPostParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsTokenEndpointAuthPostParam(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsTokenEndpointAuthPostParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsTokenEndpointAuthPostParam(
        [NotNullWhen(true)] out BetaManagedAgentsTokenEndpointAuthPostParam? value
    )
    {
        value = this.Value as BetaManagedAgentsTokenEndpointAuthPostParam;
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
    ///     (BetaManagedAgentsTokenEndpointAuthNoneParam value) =&gt; {...},
    ///     (BetaManagedAgentsTokenEndpointAuthBasicParam value) =&gt; {...},
    ///     (BetaManagedAgentsTokenEndpointAuthPostParam value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsTokenEndpointAuthNoneParam> betaManagedAgentsTokenEndpointAuthNoneParam,
        System::Action<BetaManagedAgentsTokenEndpointAuthBasicParam> betaManagedAgentsTokenEndpointAuthBasicParam,
        System::Action<BetaManagedAgentsTokenEndpointAuthPostParam> betaManagedAgentsTokenEndpointAuthPostParam
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsTokenEndpointAuthNoneParam value:
                betaManagedAgentsTokenEndpointAuthNoneParam(value);
                break;
            case BetaManagedAgentsTokenEndpointAuthBasicParam value:
                betaManagedAgentsTokenEndpointAuthBasicParam(value);
                break;
            case BetaManagedAgentsTokenEndpointAuthPostParam value:
                betaManagedAgentsTokenEndpointAuthPostParam(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of TokenEndpointAuth"
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
    ///     (BetaManagedAgentsTokenEndpointAuthNoneParam value) =&gt; {...},
    ///     (BetaManagedAgentsTokenEndpointAuthBasicParam value) =&gt; {...},
    ///     (BetaManagedAgentsTokenEndpointAuthPostParam value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<
            BetaManagedAgentsTokenEndpointAuthNoneParam,
            T
        > betaManagedAgentsTokenEndpointAuthNoneParam,
        System::Func<
            BetaManagedAgentsTokenEndpointAuthBasicParam,
            T
        > betaManagedAgentsTokenEndpointAuthBasicParam,
        System::Func<
            BetaManagedAgentsTokenEndpointAuthPostParam,
            T
        > betaManagedAgentsTokenEndpointAuthPostParam
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsTokenEndpointAuthNoneParam value =>
                betaManagedAgentsTokenEndpointAuthNoneParam(value),
            BetaManagedAgentsTokenEndpointAuthBasicParam value =>
                betaManagedAgentsTokenEndpointAuthBasicParam(value),
            BetaManagedAgentsTokenEndpointAuthPostParam value =>
                betaManagedAgentsTokenEndpointAuthPostParam(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of TokenEndpointAuth"
            ),
        };
    }

    public static implicit operator TokenEndpointAuth(
        BetaManagedAgentsTokenEndpointAuthNoneParam value
    ) => new(value);

    public static implicit operator TokenEndpointAuth(
        BetaManagedAgentsTokenEndpointAuthBasicParam value
    ) => new(value);

    public static implicit operator TokenEndpointAuth(
        BetaManagedAgentsTokenEndpointAuthPostParam value
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
                "Data did not match any variant of TokenEndpointAuth"
            );
        }
        this.Switch(
            (betaManagedAgentsTokenEndpointAuthNoneParam) =>
                betaManagedAgentsTokenEndpointAuthNoneParam.Validate(),
            (betaManagedAgentsTokenEndpointAuthBasicParam) =>
                betaManagedAgentsTokenEndpointAuthBasicParam.Validate(),
            (betaManagedAgentsTokenEndpointAuthPostParam) =>
                betaManagedAgentsTokenEndpointAuthPostParam.Validate()
        );
    }

    public virtual bool Equals(TokenEndpointAuth? other) =>
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
            BetaManagedAgentsTokenEndpointAuthNoneParam _ => 0,
            BetaManagedAgentsTokenEndpointAuthBasicParam _ => 1,
            BetaManagedAgentsTokenEndpointAuthPostParam _ => 2,
            _ => -1,
        };
    }
}

sealed class TokenEndpointAuthConverter : JsonConverter<TokenEndpointAuth>
{
    public override TokenEndpointAuth? Read(
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
            case "none":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsTokenEndpointAuthNoneParam>(
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
            case "client_secret_basic":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsTokenEndpointAuthBasicParam>(
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
            case "client_secret_post":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsTokenEndpointAuthPostParam>(
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
                return new TokenEndpointAuth(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        TokenEndpointAuth value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
