using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Execution principal for runs of this agent as returned in API responses.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsExecutionIdentityConverter))]
public record class BetaManagedAgentsExecutionIdentity : ModelBase
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

    public ApiEnum<string, BetaManagedAgentsExecutionIdentityType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaManagedAgentsAwsRoleExecutionIdentity _ =>
                    BetaManagedAgentsExecutionIdentityType.AwsRole,
                BetaManagedAgentsServiceAccountExecutionIdentity _ =>
                    BetaManagedAgentsExecutionIdentityType.ServiceAccount,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaManagedAgentsExecutionIdentityType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaManagedAgentsExecutionIdentity(
        BetaManagedAgentsAwsRoleExecutionIdentity value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsExecutionIdentity(
        BetaManagedAgentsServiceAccountExecutionIdentity value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsExecutionIdentity(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsAwsRoleExecutionIdentity"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAwsRole(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAwsRoleExecutionIdentity`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAwsRole(
        [NotNullWhen(true)] out BetaManagedAgentsAwsRoleExecutionIdentity? value
    )
    {
        value = this.Value as BetaManagedAgentsAwsRoleExecutionIdentity;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsServiceAccountExecutionIdentity"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickServiceAccount(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsServiceAccountExecutionIdentity`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickServiceAccount(
        [NotNullWhen(true)] out BetaManagedAgentsServiceAccountExecutionIdentity? value
    )
    {
        value = this.Value as BetaManagedAgentsServiceAccountExecutionIdentity;
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
    ///     (BetaManagedAgentsAwsRoleExecutionIdentity value) =&gt; {...},
    ///     (BetaManagedAgentsServiceAccountExecutionIdentity value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsAwsRoleExecutionIdentity> awsRole,
        System::Action<BetaManagedAgentsServiceAccountExecutionIdentity> serviceAccount
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsAwsRoleExecutionIdentity value:
                awsRole(value);
                break;
            case BetaManagedAgentsServiceAccountExecutionIdentity value:
                serviceAccount(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsExecutionIdentity"
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
    ///     (BetaManagedAgentsAwsRoleExecutionIdentity value) =&gt; {...},
    ///     (BetaManagedAgentsServiceAccountExecutionIdentity value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsAwsRoleExecutionIdentity, T> awsRole,
        System::Func<BetaManagedAgentsServiceAccountExecutionIdentity, T> serviceAccount
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsAwsRoleExecutionIdentity value => awsRole(value),
            BetaManagedAgentsServiceAccountExecutionIdentity value => serviceAccount(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsExecutionIdentity"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsExecutionIdentity(
        BetaManagedAgentsAwsRoleExecutionIdentity value
    ) => new(value);

    public static implicit operator BetaManagedAgentsExecutionIdentity(
        BetaManagedAgentsServiceAccountExecutionIdentity value
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
                "Data did not match any variant of BetaManagedAgentsExecutionIdentity"
            );
        }
        this.Switch((awsRole) => awsRole.Validate(), (serviceAccount) => serviceAccount.Validate());
    }

    public virtual bool Equals(BetaManagedAgentsExecutionIdentity? other) =>
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
            BetaManagedAgentsAwsRoleExecutionIdentity _ => 0,
            BetaManagedAgentsServiceAccountExecutionIdentity _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsExecutionIdentityConverter
    : JsonConverter<BetaManagedAgentsExecutionIdentity>
{
    public override BetaManagedAgentsExecutionIdentity? Read(
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
            case "aws_role":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsAwsRoleExecutionIdentity>(
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
            case "service_account":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsServiceAccountExecutionIdentity>(
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
                return new BetaManagedAgentsExecutionIdentity(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsExecutionIdentity value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaManagedAgentsExecutionIdentityTypeConverter))]
public enum BetaManagedAgentsExecutionIdentityType
{
    AwsRole,
    ServiceAccount,
}

sealed class BetaManagedAgentsExecutionIdentityTypeConverter
    : JsonConverter<BetaManagedAgentsExecutionIdentityType>
{
    public override BetaManagedAgentsExecutionIdentityType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "aws_role" => BetaManagedAgentsExecutionIdentityType.AwsRole,
            "service_account" => BetaManagedAgentsExecutionIdentityType.ServiceAccount,
            _ => (BetaManagedAgentsExecutionIdentityType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsExecutionIdentityType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsExecutionIdentityType.AwsRole => "aws_role",
                BetaManagedAgentsExecutionIdentityType.ServiceAccount => "service_account",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
