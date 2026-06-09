using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Vaults.Credentials;

/// <summary>
/// Substitute the secret on any host the session's Environment network policy permits
/// egress to. The Environment's network policy is the only boundary on where the
/// secret can reach.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsCredentialNetworkingParamsConverter))]
public record class BetaManagedAgentsCredentialNetworkingParams : ModelBase
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

    public BetaManagedAgentsCredentialNetworkingParams(
        BetaManagedAgentsUnrestrictedCredentialNetworkingParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsCredentialNetworkingParams(
        BetaManagedAgentsLimitedCredentialNetworkingParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsCredentialNetworkingParams(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsUnrestrictedCredentialNetworkingParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUnrestricted(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsUnrestrictedCredentialNetworkingParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUnrestricted(
        [NotNullWhen(true)] out BetaManagedAgentsUnrestrictedCredentialNetworkingParams? value
    )
    {
        value = this.Value as BetaManagedAgentsUnrestrictedCredentialNetworkingParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsLimitedCredentialNetworkingParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLimited(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsLimitedCredentialNetworkingParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLimited(
        [NotNullWhen(true)] out BetaManagedAgentsLimitedCredentialNetworkingParams? value
    )
    {
        value = this.Value as BetaManagedAgentsLimitedCredentialNetworkingParams;
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
    ///     (BetaManagedAgentsUnrestrictedCredentialNetworkingParams value) =&gt; {...},
    ///     (BetaManagedAgentsLimitedCredentialNetworkingParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsUnrestrictedCredentialNetworkingParams> unrestricted,
        System::Action<BetaManagedAgentsLimitedCredentialNetworkingParams> limited
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsUnrestrictedCredentialNetworkingParams value:
                unrestricted(value);
                break;
            case BetaManagedAgentsLimitedCredentialNetworkingParams value:
                limited(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsCredentialNetworkingParams"
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
    ///     (BetaManagedAgentsUnrestrictedCredentialNetworkingParams value) =&gt; {...},
    ///     (BetaManagedAgentsLimitedCredentialNetworkingParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsUnrestrictedCredentialNetworkingParams, T> unrestricted,
        System::Func<BetaManagedAgentsLimitedCredentialNetworkingParams, T> limited
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsUnrestrictedCredentialNetworkingParams value => unrestricted(value),
            BetaManagedAgentsLimitedCredentialNetworkingParams value => limited(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsCredentialNetworkingParams"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsCredentialNetworkingParams(
        BetaManagedAgentsUnrestrictedCredentialNetworkingParams value
    ) => new(value);

    public static implicit operator BetaManagedAgentsCredentialNetworkingParams(
        BetaManagedAgentsLimitedCredentialNetworkingParams value
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
                "Data did not match any variant of BetaManagedAgentsCredentialNetworkingParams"
            );
        }
        this.Switch((unrestricted) => unrestricted.Validate(), (limited) => limited.Validate());
    }

    public virtual bool Equals(BetaManagedAgentsCredentialNetworkingParams? other) =>
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
            BetaManagedAgentsUnrestrictedCredentialNetworkingParams _ => 0,
            BetaManagedAgentsLimitedCredentialNetworkingParams _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsCredentialNetworkingParamsConverter
    : JsonConverter<BetaManagedAgentsCredentialNetworkingParams>
{
    public override BetaManagedAgentsCredentialNetworkingParams? Read(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsUnrestrictedCredentialNetworkingParams>(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsLimitedCredentialNetworkingParams>(
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
                return new BetaManagedAgentsCredentialNetworkingParams(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsCredentialNetworkingParams value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
