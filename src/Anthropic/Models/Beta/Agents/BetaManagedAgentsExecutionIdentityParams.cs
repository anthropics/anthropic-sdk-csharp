using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Execution principal for runs of this agent: `service_account` (the default) or `aws_role`.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsExecutionIdentityParamsConverter))]
public record class BetaManagedAgentsExecutionIdentityParams : ModelBase
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

    public ApiEnum<string, BetaManagedAgentsExecutionIdentityParamsType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaManagedAgentsAwsRoleExecutionIdentityParams _ =>
                    BetaManagedAgentsExecutionIdentityParamsType.AwsRole,
                BetaManagedAgentsServiceAccountExecutionIdentityParams _ =>
                    BetaManagedAgentsExecutionIdentityParamsType.ServiceAccount,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaManagedAgentsExecutionIdentityParamsType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaManagedAgentsExecutionIdentityParams(
        BetaManagedAgentsAwsRoleExecutionIdentityParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsExecutionIdentityParams(
        BetaManagedAgentsServiceAccountExecutionIdentityParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsExecutionIdentityParams(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsAwsRoleExecutionIdentityParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAwsRole(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAwsRoleExecutionIdentityParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAwsRole(
        [NotNullWhen(true)] out BetaManagedAgentsAwsRoleExecutionIdentityParams? value
    )
    {
        value = this.Value as BetaManagedAgentsAwsRoleExecutionIdentityParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsServiceAccountExecutionIdentityParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickServiceAccount(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsServiceAccountExecutionIdentityParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickServiceAccount(
        [NotNullWhen(true)] out BetaManagedAgentsServiceAccountExecutionIdentityParams? value
    )
    {
        value = this.Value as BetaManagedAgentsServiceAccountExecutionIdentityParams;
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
    ///     (BetaManagedAgentsAwsRoleExecutionIdentityParams value) =&gt; {...},
    ///     (BetaManagedAgentsServiceAccountExecutionIdentityParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsAwsRoleExecutionIdentityParams> awsRole,
        System::Action<BetaManagedAgentsServiceAccountExecutionIdentityParams> serviceAccount
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsAwsRoleExecutionIdentityParams value:
                awsRole(value);
                break;
            case BetaManagedAgentsServiceAccountExecutionIdentityParams value:
                serviceAccount(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsExecutionIdentityParams"
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
    ///     (BetaManagedAgentsAwsRoleExecutionIdentityParams value) =&gt; {...},
    ///     (BetaManagedAgentsServiceAccountExecutionIdentityParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsAwsRoleExecutionIdentityParams, T> awsRole,
        System::Func<BetaManagedAgentsServiceAccountExecutionIdentityParams, T> serviceAccount
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsAwsRoleExecutionIdentityParams value => awsRole(value),
            BetaManagedAgentsServiceAccountExecutionIdentityParams value => serviceAccount(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsExecutionIdentityParams"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsExecutionIdentityParams(
        BetaManagedAgentsAwsRoleExecutionIdentityParams value
    ) => new(value);

    public static implicit operator BetaManagedAgentsExecutionIdentityParams(
        BetaManagedAgentsServiceAccountExecutionIdentityParams value
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
                "Data did not match any variant of BetaManagedAgentsExecutionIdentityParams"
            );
        }
        this.Switch((awsRole) => awsRole.Validate(), (serviceAccount) => serviceAccount.Validate());
    }

    public virtual bool Equals(BetaManagedAgentsExecutionIdentityParams? other) =>
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
            BetaManagedAgentsAwsRoleExecutionIdentityParams _ => 0,
            BetaManagedAgentsServiceAccountExecutionIdentityParams _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsExecutionIdentityParamsConverter
    : JsonConverter<BetaManagedAgentsExecutionIdentityParams>
{
    public override BetaManagedAgentsExecutionIdentityParams? Read(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsAwsRoleExecutionIdentityParams>(
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
                        JsonSerializer.Deserialize<BetaManagedAgentsServiceAccountExecutionIdentityParams>(
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
                return new BetaManagedAgentsExecutionIdentityParams(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsExecutionIdentityParams value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaManagedAgentsExecutionIdentityParamsTypeConverter))]
public enum BetaManagedAgentsExecutionIdentityParamsType
{
    AwsRole,
    ServiceAccount,
}

sealed class BetaManagedAgentsExecutionIdentityParamsTypeConverter
    : JsonConverter<BetaManagedAgentsExecutionIdentityParamsType>
{
    public override BetaManagedAgentsExecutionIdentityParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "aws_role" => BetaManagedAgentsExecutionIdentityParamsType.AwsRole,
            "service_account" => BetaManagedAgentsExecutionIdentityParamsType.ServiceAccount,
            _ => (BetaManagedAgentsExecutionIdentityParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsExecutionIdentityParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsExecutionIdentityParamsType.AwsRole => "aws_role",
                BetaManagedAgentsExecutionIdentityParamsType.ServiceAccount => "service_account",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
