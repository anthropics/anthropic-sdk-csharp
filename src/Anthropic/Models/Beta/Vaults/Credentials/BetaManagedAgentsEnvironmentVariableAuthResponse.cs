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
/// Environment variable credential details. The secret value is never returned.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsEnvironmentVariableAuthResponse,
        BetaManagedAgentsEnvironmentVariableAuthResponseFromRaw
    >)
)]
public sealed record class BetaManagedAgentsEnvironmentVariableAuthResponse : JsonModel
{
    /// <summary>
    /// Outbound hosts the secret value is substituted on.
    /// </summary>
    public required Networking Networking
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Networking>("networking");
        }
        init { this._rawData.Set("networking", value); }
    }

    /// <summary>
    /// Name of the environment variable.
    /// </summary>
    public required string SecretName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("secret_name");
        }
        init { this._rawData.Set("secret_name", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsEnvironmentVariableAuthResponseType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsEnvironmentVariableAuthResponseType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Networking.Validate();
        _ = this.SecretName;
        this.Type.Validate();
    }

    public BetaManagedAgentsEnvironmentVariableAuthResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsEnvironmentVariableAuthResponse(
        BetaManagedAgentsEnvironmentVariableAuthResponse betaManagedAgentsEnvironmentVariableAuthResponse
    )
        : base(betaManagedAgentsEnvironmentVariableAuthResponse) { }
#pragma warning restore CS8618

    public BetaManagedAgentsEnvironmentVariableAuthResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsEnvironmentVariableAuthResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsEnvironmentVariableAuthResponseFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsEnvironmentVariableAuthResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsEnvironmentVariableAuthResponseFromRaw
    : IFromRawJson<BetaManagedAgentsEnvironmentVariableAuthResponse>
{
    /// <inheritdoc/>
    public BetaManagedAgentsEnvironmentVariableAuthResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsEnvironmentVariableAuthResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Outbound hosts the secret value is substituted on.
/// </summary>
[JsonConverter(typeof(NetworkingConverter))]
public record class Networking : ModelBase
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

    public Networking(
        BetaManagedAgentsUnrestrictedCredentialNetworkingResponse value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Networking(
        BetaManagedAgentsLimitedCredentialNetworkingResponse value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Networking(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsUnrestrictedCredentialNetworkingResponse"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsUnrestrictedCredentialNetworkingResponse(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsUnrestrictedCredentialNetworkingResponse`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsUnrestrictedCredentialNetworkingResponse(
        [NotNullWhen(true)] out BetaManagedAgentsUnrestrictedCredentialNetworkingResponse? value
    )
    {
        value = this.Value as BetaManagedAgentsUnrestrictedCredentialNetworkingResponse;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsLimitedCredentialNetworkingResponse"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsLimitedCredentialNetworkingResponse(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsLimitedCredentialNetworkingResponse`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsLimitedCredentialNetworkingResponse(
        [NotNullWhen(true)] out BetaManagedAgentsLimitedCredentialNetworkingResponse? value
    )
    {
        value = this.Value as BetaManagedAgentsLimitedCredentialNetworkingResponse;
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
    ///     (BetaManagedAgentsUnrestrictedCredentialNetworkingResponse value) =&gt; {...},
    ///     (BetaManagedAgentsLimitedCredentialNetworkingResponse value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsUnrestrictedCredentialNetworkingResponse> betaManagedAgentsUnrestrictedCredentialNetworkingResponse,
        System::Action<BetaManagedAgentsLimitedCredentialNetworkingResponse> betaManagedAgentsLimitedCredentialNetworkingResponse
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsUnrestrictedCredentialNetworkingResponse value:
                betaManagedAgentsUnrestrictedCredentialNetworkingResponse(value);
                break;
            case BetaManagedAgentsLimitedCredentialNetworkingResponse value:
                betaManagedAgentsLimitedCredentialNetworkingResponse(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Networking"
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
    ///     (BetaManagedAgentsUnrestrictedCredentialNetworkingResponse value) =&gt; {...},
    ///     (BetaManagedAgentsLimitedCredentialNetworkingResponse value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<
            BetaManagedAgentsUnrestrictedCredentialNetworkingResponse,
            T
        > betaManagedAgentsUnrestrictedCredentialNetworkingResponse,
        System::Func<
            BetaManagedAgentsLimitedCredentialNetworkingResponse,
            T
        > betaManagedAgentsLimitedCredentialNetworkingResponse
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsUnrestrictedCredentialNetworkingResponse value =>
                betaManagedAgentsUnrestrictedCredentialNetworkingResponse(value),
            BetaManagedAgentsLimitedCredentialNetworkingResponse value =>
                betaManagedAgentsLimitedCredentialNetworkingResponse(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Networking"
            ),
        };
    }

    public static implicit operator Networking(
        BetaManagedAgentsUnrestrictedCredentialNetworkingResponse value
    ) => new(value);

    public static implicit operator Networking(
        BetaManagedAgentsLimitedCredentialNetworkingResponse value
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
            throw new AnthropicInvalidDataException("Data did not match any variant of Networking");
        }
        this.Switch(
            (betaManagedAgentsUnrestrictedCredentialNetworkingResponse) =>
                betaManagedAgentsUnrestrictedCredentialNetworkingResponse.Validate(),
            (betaManagedAgentsLimitedCredentialNetworkingResponse) =>
                betaManagedAgentsLimitedCredentialNetworkingResponse.Validate()
        );
    }

    public virtual bool Equals(Networking? other) =>
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
            BetaManagedAgentsUnrestrictedCredentialNetworkingResponse _ => 0,
            BetaManagedAgentsLimitedCredentialNetworkingResponse _ => 1,
            _ => -1,
        };
    }
}

sealed class NetworkingConverter : JsonConverter<Networking>
{
    public override Networking? Read(
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
            case "unrestricted":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsUnrestrictedCredentialNetworkingResponse>(
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
            case "limited":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsLimitedCredentialNetworkingResponse>(
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
                return new Networking(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        Networking value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaManagedAgentsEnvironmentVariableAuthResponseTypeConverter))]
public enum BetaManagedAgentsEnvironmentVariableAuthResponseType
{
    EnvironmentVariable,
}

sealed class BetaManagedAgentsEnvironmentVariableAuthResponseTypeConverter
    : JsonConverter<BetaManagedAgentsEnvironmentVariableAuthResponseType>
{
    public override BetaManagedAgentsEnvironmentVariableAuthResponseType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "environment_variable" =>
                BetaManagedAgentsEnvironmentVariableAuthResponseType.EnvironmentVariable,
            _ => (BetaManagedAgentsEnvironmentVariableAuthResponseType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsEnvironmentVariableAuthResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsEnvironmentVariableAuthResponseType.EnvironmentVariable =>
                    "environment_variable",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
