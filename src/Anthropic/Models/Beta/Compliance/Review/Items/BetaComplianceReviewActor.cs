using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Compliance.Review.Items;

/// <summary>
/// Who sent a message.
/// </summary>
[JsonConverter(typeof(BetaComplianceReviewActorConverter))]
public record class BetaComplianceReviewActor : ModelBase
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

    public ApiEnum<string, BetaComplianceReviewActorType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaComplianceReviewUserActor _ => BetaComplianceReviewActorType.UserActor,
                BetaComplianceReviewApiActor _ => BetaComplianceReviewActorType.ApiActor,
                BetaComplianceReviewServiceAccountActor _ =>
                    BetaComplianceReviewActorType.ServiceAccountActor,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaComplianceReviewActorType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaComplianceReviewActor(
        BetaComplianceReviewUserActor value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaComplianceReviewActor(
        BetaComplianceReviewApiActor value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaComplianceReviewActor(
        BetaComplianceReviewServiceAccountActor value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaComplianceReviewActor(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaComplianceReviewUserActor"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUser(out var value)) {
    ///     // `value` is of type `BetaComplianceReviewUserActor`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUser([NotNullWhen(true)] out BetaComplianceReviewUserActor? value)
    {
        value = this.Value as BetaComplianceReviewUserActor;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaComplianceReviewApiActor"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickApi(out var value)) {
    ///     // `value` is of type `BetaComplianceReviewApiActor`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickApi([NotNullWhen(true)] out BetaComplianceReviewApiActor? value)
    {
        value = this.Value as BetaComplianceReviewApiActor;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaComplianceReviewServiceAccountActor"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickServiceAccount(out var value)) {
    ///     // `value` is of type `BetaComplianceReviewServiceAccountActor`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickServiceAccount(
        [NotNullWhen(true)] out BetaComplianceReviewServiceAccountActor? value
    )
    {
        value = this.Value as BetaComplianceReviewServiceAccountActor;
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
    ///     (BetaComplianceReviewUserActor value) =&gt; {...},
    ///     (BetaComplianceReviewApiActor value) =&gt; {...},
    ///     (BetaComplianceReviewServiceAccountActor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaComplianceReviewUserActor> user,
        Action<BetaComplianceReviewApiActor> api,
        Action<BetaComplianceReviewServiceAccountActor> serviceAccount
    )
    {
        switch (this.Value)
        {
            case BetaComplianceReviewUserActor value:
                user(value);
                break;
            case BetaComplianceReviewApiActor value:
                api(value);
                break;
            case BetaComplianceReviewServiceAccountActor value:
                serviceAccount(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaComplianceReviewActor"
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
    ///     (BetaComplianceReviewUserActor value) =&gt; {...},
    ///     (BetaComplianceReviewApiActor value) =&gt; {...},
    ///     (BetaComplianceReviewServiceAccountActor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaComplianceReviewUserActor, T> user,
        Func<BetaComplianceReviewApiActor, T> api,
        Func<BetaComplianceReviewServiceAccountActor, T> serviceAccount
    )
    {
        return this.Value switch
        {
            BetaComplianceReviewUserActor value => user(value),
            BetaComplianceReviewApiActor value => api(value),
            BetaComplianceReviewServiceAccountActor value => serviceAccount(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaComplianceReviewActor"
            ),
        };
    }

    public static implicit operator BetaComplianceReviewActor(
        BetaComplianceReviewUserActor value
    ) => new(value);

    public static implicit operator BetaComplianceReviewActor(BetaComplianceReviewApiActor value) =>
        new(value);

    public static implicit operator BetaComplianceReviewActor(
        BetaComplianceReviewServiceAccountActor value
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
                "Data did not match any variant of BetaComplianceReviewActor"
            );
        }
        this.Switch(
            (user) => user.Validate(),
            (api) => api.Validate(),
            (serviceAccount) => serviceAccount.Validate()
        );
    }

    public virtual bool Equals(BetaComplianceReviewActor? other) =>
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
            BetaComplianceReviewUserActor _ => 0,
            BetaComplianceReviewApiActor _ => 1,
            BetaComplianceReviewServiceAccountActor _ => 2,
            _ => -1,
        };
    }
}

sealed class BetaComplianceReviewActorConverter : JsonConverter<BetaComplianceReviewActor>
{
    public override BetaComplianceReviewActor? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
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
            case "user_actor":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaComplianceReviewUserActor>(
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
            case "api_actor":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaComplianceReviewApiActor>(
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
            case "service_account_actor":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaComplianceReviewServiceAccountActor>(
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
                return new BetaComplianceReviewActor(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaComplianceReviewActor value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaComplianceReviewActorTypeConverter))]
public enum BetaComplianceReviewActorType
{
    UserActor = 339255143,
    ApiActor = 42160694,
    ServiceAccountActor = 1364373501,
}

sealed class BetaComplianceReviewActorTypeConverter : JsonConverter<BetaComplianceReviewActorType>
{
    public override BetaComplianceReviewActorType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user_actor" => BetaComplianceReviewActorType.UserActor,
            "api_actor" => BetaComplianceReviewActorType.ApiActor,
            "service_account_actor" => BetaComplianceReviewActorType.ServiceAccountActor,
            _ => (BetaComplianceReviewActorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaComplianceReviewActorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaComplianceReviewActorType.UserActor => "user_actor",
                BetaComplianceReviewActorType.ApiActor => "api_actor",
                BetaComplianceReviewActorType.ServiceAccountActor => "service_account_actor",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
