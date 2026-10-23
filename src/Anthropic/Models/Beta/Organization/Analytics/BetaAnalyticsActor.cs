using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics;

[JsonConverter(typeof(BetaAnalyticsActorConverter))]
public record class BetaAnalyticsActor : ModelBase
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

    public ApiEnum<string, BetaAnalyticsActorTypeValue> Type
    {
        get
        {
            return this.Value switch
            {
                BetaAnalyticsReportUserActor _ => BetaAnalyticsActorTypeValue.UserActor,
                BetaAnalyticsServiceAccountActor _ =>
                    BetaAnalyticsActorTypeValue.ServiceAccountActor,
                BetaAnalyticsFederatedActor _ => BetaAnalyticsActorTypeValue.FederatedActor,
                BetaAnalyticsApiActor _ => BetaAnalyticsActorTypeValue.ApiActor,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaAnalyticsActorTypeValue>
                >(this.Json, "type"),
            };
        }
    }

    public BetaAnalyticsActor(BetaAnalyticsReportUserActor value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaAnalyticsActor(BetaAnalyticsServiceAccountActor value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaAnalyticsActor(BetaAnalyticsFederatedActor value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaAnalyticsActor(BetaAnalyticsApiActor value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaAnalyticsActor(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaAnalyticsReportUserActor"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickReportUser(out var value)) {
    ///     // `value` is of type `BetaAnalyticsReportUserActor`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickReportUser([NotNullWhen(true)] out BetaAnalyticsReportUserActor? value)
    {
        value = this.Value as BetaAnalyticsReportUserActor;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaAnalyticsServiceAccountActor"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickServiceAccount(out var value)) {
    ///     // `value` is of type `BetaAnalyticsServiceAccountActor`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickServiceAccount(
        [NotNullWhen(true)] out BetaAnalyticsServiceAccountActor? value
    )
    {
        value = this.Value as BetaAnalyticsServiceAccountActor;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaAnalyticsFederatedActor"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFederated(out var value)) {
    ///     // `value` is of type `BetaAnalyticsFederatedActor`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFederated([NotNullWhen(true)] out BetaAnalyticsFederatedActor? value)
    {
        value = this.Value as BetaAnalyticsFederatedActor;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaAnalyticsApiActor"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickApi(out var value)) {
    ///     // `value` is of type `BetaAnalyticsApiActor`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickApi([NotNullWhen(true)] out BetaAnalyticsApiActor? value)
    {
        value = this.Value as BetaAnalyticsApiActor;
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
    ///     (BetaAnalyticsReportUserActor value) =&gt; {...},
    ///     (BetaAnalyticsServiceAccountActor value) =&gt; {...},
    ///     (BetaAnalyticsFederatedActor value) =&gt; {...},
    ///     (BetaAnalyticsApiActor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaAnalyticsReportUserActor> reportUser,
        Action<BetaAnalyticsServiceAccountActor> serviceAccount,
        Action<BetaAnalyticsFederatedActor> federated,
        Action<BetaAnalyticsApiActor> api
    )
    {
        switch (this.Value)
        {
            case BetaAnalyticsReportUserActor value:
                reportUser(value);
                break;
            case BetaAnalyticsServiceAccountActor value:
                serviceAccount(value);
                break;
            case BetaAnalyticsFederatedActor value:
                federated(value);
                break;
            case BetaAnalyticsApiActor value:
                api(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaAnalyticsActor"
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
    ///     (BetaAnalyticsReportUserActor value) =&gt; {...},
    ///     (BetaAnalyticsServiceAccountActor value) =&gt; {...},
    ///     (BetaAnalyticsFederatedActor value) =&gt; {...},
    ///     (BetaAnalyticsApiActor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaAnalyticsReportUserActor, T> reportUser,
        Func<BetaAnalyticsServiceAccountActor, T> serviceAccount,
        Func<BetaAnalyticsFederatedActor, T> federated,
        Func<BetaAnalyticsApiActor, T> api
    )
    {
        return this.Value switch
        {
            BetaAnalyticsReportUserActor value => reportUser(value),
            BetaAnalyticsServiceAccountActor value => serviceAccount(value),
            BetaAnalyticsFederatedActor value => federated(value),
            BetaAnalyticsApiActor value => api(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaAnalyticsActor"
            ),
        };
    }

    public static implicit operator BetaAnalyticsActor(BetaAnalyticsReportUserActor value) =>
        new(value);

    public static implicit operator BetaAnalyticsActor(BetaAnalyticsServiceAccountActor value) =>
        new(value);

    public static implicit operator BetaAnalyticsActor(BetaAnalyticsFederatedActor value) =>
        new(value);

    public static implicit operator BetaAnalyticsActor(BetaAnalyticsApiActor value) => new(value);

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
                "Data did not match any variant of BetaAnalyticsActor"
            );
        }
        this.Switch(
            (reportUser) => reportUser.Validate(),
            (serviceAccount) => serviceAccount.Validate(),
            (federated) => federated.Validate(),
            (api) => api.Validate()
        );
    }

    public virtual bool Equals(BetaAnalyticsActor? other) =>
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
            BetaAnalyticsReportUserActor _ => 0,
            BetaAnalyticsServiceAccountActor _ => 1,
            BetaAnalyticsFederatedActor _ => 2,
            BetaAnalyticsApiActor _ => 3,
            _ => -1,
        };
    }
}

sealed class BetaAnalyticsActorConverter : JsonConverter<BetaAnalyticsActor>
{
    public override BetaAnalyticsActor? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaAnalyticsReportUserActor>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaAnalyticsServiceAccountActor>(
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
            case "federated_actor":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaAnalyticsFederatedActor>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaAnalyticsApiActor>(
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
                return new BetaAnalyticsActor(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsActor value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaAnalyticsActorTypeValueConverter))]
public enum BetaAnalyticsActorTypeValue
{
    UserActor,
    ServiceAccountActor,
    FederatedActor,
    ApiActor,
}

sealed class BetaAnalyticsActorTypeValueConverter : JsonConverter<BetaAnalyticsActorTypeValue>
{
    public override BetaAnalyticsActorTypeValue Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user_actor" => BetaAnalyticsActorTypeValue.UserActor,
            "service_account_actor" => BetaAnalyticsActorTypeValue.ServiceAccountActor,
            "federated_actor" => BetaAnalyticsActorTypeValue.FederatedActor,
            "api_actor" => BetaAnalyticsActorTypeValue.ApiActor,
            _ => (BetaAnalyticsActorTypeValue)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsActorTypeValue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAnalyticsActorTypeValue.UserActor => "user_actor",
                BetaAnalyticsActorTypeValue.ServiceAccountActor => "service_account_actor",
                BetaAnalyticsActorTypeValue.FederatedActor => "federated_actor",
                BetaAnalyticsActorTypeValue.ApiActor => "api_actor",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
