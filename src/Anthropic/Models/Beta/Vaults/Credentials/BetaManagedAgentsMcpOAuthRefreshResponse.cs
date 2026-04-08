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
/// OAuth refresh token configuration returned in credential responses.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMcpOAuthRefreshResponse,
        BetaManagedAgentsMcpOAuthRefreshResponseFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMcpOAuthRefreshResponse : JsonModel
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
    public required BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth TokenEndpointAuth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth>(
                "token_endpoint_auth"
            );
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
        _ = this.TokenEndpoint;
        this.TokenEndpointAuth.Validate();
        _ = this.Resource;
        _ = this.Scope;
    }

    public BetaManagedAgentsMcpOAuthRefreshResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMcpOAuthRefreshResponse(
        BetaManagedAgentsMcpOAuthRefreshResponse betaManagedAgentsMcpOAuthRefreshResponse
    )
        : base(betaManagedAgentsMcpOAuthRefreshResponse) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMcpOAuthRefreshResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMcpOAuthRefreshResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMcpOAuthRefreshResponseFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMcpOAuthRefreshResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMcpOAuthRefreshResponseFromRaw
    : IFromRawJson<BetaManagedAgentsMcpOAuthRefreshResponse>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMcpOAuthRefreshResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMcpOAuthRefreshResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Token endpoint requires no client authentication.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuthConverter))]
public record class BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth : ModelBase
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

    public BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth(
        BetaManagedAgentsTokenEndpointAuthNoneResponse value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth(
        BetaManagedAgentsTokenEndpointAuthBasicResponse value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth(
        BetaManagedAgentsTokenEndpointAuthPostResponse value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsTokenEndpointAuthNoneResponse"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsTokenEndpointAuthNoneResponse(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsTokenEndpointAuthNoneResponse`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsTokenEndpointAuthNoneResponse(
        [NotNullWhen(true)] out BetaManagedAgentsTokenEndpointAuthNoneResponse? value
    )
    {
        value = this.Value as BetaManagedAgentsTokenEndpointAuthNoneResponse;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsTokenEndpointAuthBasicResponse"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsTokenEndpointAuthBasicResponse(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsTokenEndpointAuthBasicResponse`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsTokenEndpointAuthBasicResponse(
        [NotNullWhen(true)] out BetaManagedAgentsTokenEndpointAuthBasicResponse? value
    )
    {
        value = this.Value as BetaManagedAgentsTokenEndpointAuthBasicResponse;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsTokenEndpointAuthPostResponse"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsTokenEndpointAuthPostResponse(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsTokenEndpointAuthPostResponse`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsTokenEndpointAuthPostResponse(
        [NotNullWhen(true)] out BetaManagedAgentsTokenEndpointAuthPostResponse? value
    )
    {
        value = this.Value as BetaManagedAgentsTokenEndpointAuthPostResponse;
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
    ///     (BetaManagedAgentsTokenEndpointAuthNoneResponse value) =&gt; {...},
    ///     (BetaManagedAgentsTokenEndpointAuthBasicResponse value) =&gt; {...},
    ///     (BetaManagedAgentsTokenEndpointAuthPostResponse value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsTokenEndpointAuthNoneResponse> betaManagedAgentsTokenEndpointAuthNoneResponse,
        System::Action<BetaManagedAgentsTokenEndpointAuthBasicResponse> betaManagedAgentsTokenEndpointAuthBasicResponse,
        System::Action<BetaManagedAgentsTokenEndpointAuthPostResponse> betaManagedAgentsTokenEndpointAuthPostResponse
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsTokenEndpointAuthNoneResponse value:
                betaManagedAgentsTokenEndpointAuthNoneResponse(value);
                break;
            case BetaManagedAgentsTokenEndpointAuthBasicResponse value:
                betaManagedAgentsTokenEndpointAuthBasicResponse(value);
                break;
            case BetaManagedAgentsTokenEndpointAuthPostResponse value:
                betaManagedAgentsTokenEndpointAuthPostResponse(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth"
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
    ///     (BetaManagedAgentsTokenEndpointAuthNoneResponse value) =&gt; {...},
    ///     (BetaManagedAgentsTokenEndpointAuthBasicResponse value) =&gt; {...},
    ///     (BetaManagedAgentsTokenEndpointAuthPostResponse value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<
            BetaManagedAgentsTokenEndpointAuthNoneResponse,
            T
        > betaManagedAgentsTokenEndpointAuthNoneResponse,
        System::Func<
            BetaManagedAgentsTokenEndpointAuthBasicResponse,
            T
        > betaManagedAgentsTokenEndpointAuthBasicResponse,
        System::Func<
            BetaManagedAgentsTokenEndpointAuthPostResponse,
            T
        > betaManagedAgentsTokenEndpointAuthPostResponse
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsTokenEndpointAuthNoneResponse value =>
                betaManagedAgentsTokenEndpointAuthNoneResponse(value),
            BetaManagedAgentsTokenEndpointAuthBasicResponse value =>
                betaManagedAgentsTokenEndpointAuthBasicResponse(value),
            BetaManagedAgentsTokenEndpointAuthPostResponse value =>
                betaManagedAgentsTokenEndpointAuthPostResponse(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth(
        BetaManagedAgentsTokenEndpointAuthNoneResponse value
    ) => new(value);

    public static implicit operator BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth(
        BetaManagedAgentsTokenEndpointAuthBasicResponse value
    ) => new(value);

    public static implicit operator BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth(
        BetaManagedAgentsTokenEndpointAuthPostResponse value
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
                "Data did not match any variant of BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth"
            );
        }
        this.Switch(
            (betaManagedAgentsTokenEndpointAuthNoneResponse) =>
                betaManagedAgentsTokenEndpointAuthNoneResponse.Validate(),
            (betaManagedAgentsTokenEndpointAuthBasicResponse) =>
                betaManagedAgentsTokenEndpointAuthBasicResponse.Validate(),
            (betaManagedAgentsTokenEndpointAuthPostResponse) =>
                betaManagedAgentsTokenEndpointAuthPostResponse.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth? other) =>
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
            BetaManagedAgentsTokenEndpointAuthNoneResponse _ => 0,
            BetaManagedAgentsTokenEndpointAuthBasicResponse _ => 1,
            BetaManagedAgentsTokenEndpointAuthPostResponse _ => 2,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuthConverter
    : JsonConverter<BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth>
{
    public override BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth? Read(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsTokenEndpointAuthNoneResponse>(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsTokenEndpointAuthBasicResponse>(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsTokenEndpointAuthPostResponse>(
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
                return new BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
