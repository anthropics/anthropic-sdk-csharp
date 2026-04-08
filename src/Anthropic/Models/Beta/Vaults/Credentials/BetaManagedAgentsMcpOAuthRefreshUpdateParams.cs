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
/// Parameters for updating OAuth refresh token configuration.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMcpOAuthRefreshUpdateParams,
        BetaManagedAgentsMcpOAuthRefreshUpdateParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMcpOAuthRefreshUpdateParams : JsonModel
{
    /// <summary>
    /// Updated OAuth refresh token.
    /// </summary>
    public string? RefreshToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("refresh_token");
        }
        init { this._rawData.Set("refresh_token", value); }
    }

    /// <summary>
    /// Updated OAuth scope for the refresh request.
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

    /// <summary>
    /// Updated HTTP Basic authentication parameters for the token endpoint.
    /// </summary>
    public BetaManagedAgentsMcpOAuthRefreshUpdateParamsTokenEndpointAuth? TokenEndpointAuth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaManagedAgentsMcpOAuthRefreshUpdateParamsTokenEndpointAuth>(
                "token_endpoint_auth"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("token_endpoint_auth", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.RefreshToken;
        _ = this.Scope;
        this.TokenEndpointAuth?.Validate();
    }

    public BetaManagedAgentsMcpOAuthRefreshUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMcpOAuthRefreshUpdateParams(
        BetaManagedAgentsMcpOAuthRefreshUpdateParams betaManagedAgentsMcpOAuthRefreshUpdateParams
    )
        : base(betaManagedAgentsMcpOAuthRefreshUpdateParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMcpOAuthRefreshUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMcpOAuthRefreshUpdateParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMcpOAuthRefreshUpdateParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMcpOAuthRefreshUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsMcpOAuthRefreshUpdateParamsFromRaw
    : IFromRawJson<BetaManagedAgentsMcpOAuthRefreshUpdateParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMcpOAuthRefreshUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMcpOAuthRefreshUpdateParams.FromRawUnchecked(rawData);
}

/// <summary>
/// Updated HTTP Basic authentication parameters for the token endpoint.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsMcpOAuthRefreshUpdateParamsTokenEndpointAuthConverter))]
public record class BetaManagedAgentsMcpOAuthRefreshUpdateParamsTokenEndpointAuth : ModelBase
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
                betaManagedAgentsTokenEndpointAuthBasicUpdateParam: (x) => x.ClientSecret,
                betaManagedAgentsTokenEndpointAuthPostUpdateParam: (x) => x.ClientSecret
            );
        }
    }

    public BetaManagedAgentsMcpOAuthRefreshUpdateParamsTokenEndpointAuth(
        BetaManagedAgentsTokenEndpointAuthBasicUpdateParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsMcpOAuthRefreshUpdateParamsTokenEndpointAuth(
        BetaManagedAgentsTokenEndpointAuthPostUpdateParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsMcpOAuthRefreshUpdateParamsTokenEndpointAuth(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsTokenEndpointAuthBasicUpdateParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsTokenEndpointAuthBasicUpdateParam(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsTokenEndpointAuthBasicUpdateParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsTokenEndpointAuthBasicUpdateParam(
        [NotNullWhen(true)] out BetaManagedAgentsTokenEndpointAuthBasicUpdateParam? value
    )
    {
        value = this.Value as BetaManagedAgentsTokenEndpointAuthBasicUpdateParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsTokenEndpointAuthPostUpdateParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsTokenEndpointAuthPostUpdateParam(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsTokenEndpointAuthPostUpdateParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsTokenEndpointAuthPostUpdateParam(
        [NotNullWhen(true)] out BetaManagedAgentsTokenEndpointAuthPostUpdateParam? value
    )
    {
        value = this.Value as BetaManagedAgentsTokenEndpointAuthPostUpdateParam;
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
    ///     (BetaManagedAgentsTokenEndpointAuthBasicUpdateParam value) =&gt; {...},
    ///     (BetaManagedAgentsTokenEndpointAuthPostUpdateParam value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsTokenEndpointAuthBasicUpdateParam> betaManagedAgentsTokenEndpointAuthBasicUpdateParam,
        System::Action<BetaManagedAgentsTokenEndpointAuthPostUpdateParam> betaManagedAgentsTokenEndpointAuthPostUpdateParam
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsTokenEndpointAuthBasicUpdateParam value:
                betaManagedAgentsTokenEndpointAuthBasicUpdateParam(value);
                break;
            case BetaManagedAgentsTokenEndpointAuthPostUpdateParam value:
                betaManagedAgentsTokenEndpointAuthPostUpdateParam(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsMcpOAuthRefreshUpdateParamsTokenEndpointAuth"
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
    ///     (BetaManagedAgentsTokenEndpointAuthBasicUpdateParam value) =&gt; {...},
    ///     (BetaManagedAgentsTokenEndpointAuthPostUpdateParam value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<
            BetaManagedAgentsTokenEndpointAuthBasicUpdateParam,
            T
        > betaManagedAgentsTokenEndpointAuthBasicUpdateParam,
        System::Func<
            BetaManagedAgentsTokenEndpointAuthPostUpdateParam,
            T
        > betaManagedAgentsTokenEndpointAuthPostUpdateParam
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsTokenEndpointAuthBasicUpdateParam value =>
                betaManagedAgentsTokenEndpointAuthBasicUpdateParam(value),
            BetaManagedAgentsTokenEndpointAuthPostUpdateParam value =>
                betaManagedAgentsTokenEndpointAuthPostUpdateParam(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsMcpOAuthRefreshUpdateParamsTokenEndpointAuth"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsMcpOAuthRefreshUpdateParamsTokenEndpointAuth(
        BetaManagedAgentsTokenEndpointAuthBasicUpdateParam value
    ) => new(value);

    public static implicit operator BetaManagedAgentsMcpOAuthRefreshUpdateParamsTokenEndpointAuth(
        BetaManagedAgentsTokenEndpointAuthPostUpdateParam value
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
                "Data did not match any variant of BetaManagedAgentsMcpOAuthRefreshUpdateParamsTokenEndpointAuth"
            );
        }
        this.Switch(
            (betaManagedAgentsTokenEndpointAuthBasicUpdateParam) =>
                betaManagedAgentsTokenEndpointAuthBasicUpdateParam.Validate(),
            (betaManagedAgentsTokenEndpointAuthPostUpdateParam) =>
                betaManagedAgentsTokenEndpointAuthPostUpdateParam.Validate()
        );
    }

    public virtual bool Equals(
        BetaManagedAgentsMcpOAuthRefreshUpdateParamsTokenEndpointAuth? other
    ) =>
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
            BetaManagedAgentsTokenEndpointAuthBasicUpdateParam _ => 0,
            BetaManagedAgentsTokenEndpointAuthPostUpdateParam _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsMcpOAuthRefreshUpdateParamsTokenEndpointAuthConverter
    : JsonConverter<BetaManagedAgentsMcpOAuthRefreshUpdateParamsTokenEndpointAuth>
{
    public override BetaManagedAgentsMcpOAuthRefreshUpdateParamsTokenEndpointAuth? Read(
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
            case "client_secret_basic":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsTokenEndpointAuthBasicUpdateParam>(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsTokenEndpointAuthPostUpdateParam>(
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
                return new BetaManagedAgentsMcpOAuthRefreshUpdateParamsTokenEndpointAuth(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsMcpOAuthRefreshUpdateParamsTokenEndpointAuth value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
