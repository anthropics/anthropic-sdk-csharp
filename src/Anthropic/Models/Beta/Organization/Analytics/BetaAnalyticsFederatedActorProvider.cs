using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics;

[JsonConverter(typeof(BetaAnalyticsFederatedActorProviderConverter))]
public record class BetaAnalyticsFederatedActorProvider : ModelBase
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

    public ApiEnum<string, BetaAnalyticsFederatedActorProviderType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaAnalyticsFederatedActorAwsProvider _ =>
                    BetaAnalyticsFederatedActorProviderType.Aws,
                BetaAnalyticsFederatedActorAzureProvider _ =>
                    BetaAnalyticsFederatedActorProviderType.Azure,
                BetaAnalyticsFederatedActorGcpProvider _ =>
                    BetaAnalyticsFederatedActorProviderType.Gcp,
                BetaAnalyticsFederatedActorOidcProvider _ =>
                    BetaAnalyticsFederatedActorProviderType.Oidc,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaAnalyticsFederatedActorProviderType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaAnalyticsFederatedActorProvider(
        BetaAnalyticsFederatedActorAwsProvider value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaAnalyticsFederatedActorProvider(
        BetaAnalyticsFederatedActorAzureProvider value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaAnalyticsFederatedActorProvider(
        BetaAnalyticsFederatedActorGcpProvider value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaAnalyticsFederatedActorProvider(
        BetaAnalyticsFederatedActorOidcProvider value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaAnalyticsFederatedActorProvider(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaAnalyticsFederatedActorAwsProvider"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAws(out var value)) {
    ///     // `value` is of type `BetaAnalyticsFederatedActorAwsProvider`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAws([NotNullWhen(true)] out BetaAnalyticsFederatedActorAwsProvider? value)
    {
        value = this.Value as BetaAnalyticsFederatedActorAwsProvider;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaAnalyticsFederatedActorAzureProvider"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAzure(out var value)) {
    ///     // `value` is of type `BetaAnalyticsFederatedActorAzureProvider`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAzure(
        [NotNullWhen(true)] out BetaAnalyticsFederatedActorAzureProvider? value
    )
    {
        value = this.Value as BetaAnalyticsFederatedActorAzureProvider;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaAnalyticsFederatedActorGcpProvider"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGcp(out var value)) {
    ///     // `value` is of type `BetaAnalyticsFederatedActorGcpProvider`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGcp([NotNullWhen(true)] out BetaAnalyticsFederatedActorGcpProvider? value)
    {
        value = this.Value as BetaAnalyticsFederatedActorGcpProvider;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaAnalyticsFederatedActorOidcProvider"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickOidc(out var value)) {
    ///     // `value` is of type `BetaAnalyticsFederatedActorOidcProvider`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickOidc([NotNullWhen(true)] out BetaAnalyticsFederatedActorOidcProvider? value)
    {
        value = this.Value as BetaAnalyticsFederatedActorOidcProvider;
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
    ///     (BetaAnalyticsFederatedActorAwsProvider value) =&gt; {...},
    ///     (BetaAnalyticsFederatedActorAzureProvider value) =&gt; {...},
    ///     (BetaAnalyticsFederatedActorGcpProvider value) =&gt; {...},
    ///     (BetaAnalyticsFederatedActorOidcProvider value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaAnalyticsFederatedActorAwsProvider> aws,
        Action<BetaAnalyticsFederatedActorAzureProvider> azure,
        Action<BetaAnalyticsFederatedActorGcpProvider> gcp,
        Action<BetaAnalyticsFederatedActorOidcProvider> oidc
    )
    {
        switch (this.Value)
        {
            case BetaAnalyticsFederatedActorAwsProvider value:
                aws(value);
                break;
            case BetaAnalyticsFederatedActorAzureProvider value:
                azure(value);
                break;
            case BetaAnalyticsFederatedActorGcpProvider value:
                gcp(value);
                break;
            case BetaAnalyticsFederatedActorOidcProvider value:
                oidc(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaAnalyticsFederatedActorProvider"
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
    ///     (BetaAnalyticsFederatedActorAwsProvider value) =&gt; {...},
    ///     (BetaAnalyticsFederatedActorAzureProvider value) =&gt; {...},
    ///     (BetaAnalyticsFederatedActorGcpProvider value) =&gt; {...},
    ///     (BetaAnalyticsFederatedActorOidcProvider value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaAnalyticsFederatedActorAwsProvider, T> aws,
        Func<BetaAnalyticsFederatedActorAzureProvider, T> azure,
        Func<BetaAnalyticsFederatedActorGcpProvider, T> gcp,
        Func<BetaAnalyticsFederatedActorOidcProvider, T> oidc
    )
    {
        return this.Value switch
        {
            BetaAnalyticsFederatedActorAwsProvider value => aws(value),
            BetaAnalyticsFederatedActorAzureProvider value => azure(value),
            BetaAnalyticsFederatedActorGcpProvider value => gcp(value),
            BetaAnalyticsFederatedActorOidcProvider value => oidc(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaAnalyticsFederatedActorProvider"
            ),
        };
    }

    public static implicit operator BetaAnalyticsFederatedActorProvider(
        BetaAnalyticsFederatedActorAwsProvider value
    ) => new(value);

    public static implicit operator BetaAnalyticsFederatedActorProvider(
        BetaAnalyticsFederatedActorAzureProvider value
    ) => new(value);

    public static implicit operator BetaAnalyticsFederatedActorProvider(
        BetaAnalyticsFederatedActorGcpProvider value
    ) => new(value);

    public static implicit operator BetaAnalyticsFederatedActorProvider(
        BetaAnalyticsFederatedActorOidcProvider value
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
                "Data did not match any variant of BetaAnalyticsFederatedActorProvider"
            );
        }
        this.Switch(
            (aws) => aws.Validate(),
            (azure) => azure.Validate(),
            (gcp) => gcp.Validate(),
            (oidc) => oidc.Validate()
        );
    }

    public virtual bool Equals(BetaAnalyticsFederatedActorProvider? other) =>
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
            BetaAnalyticsFederatedActorAwsProvider _ => 0,
            BetaAnalyticsFederatedActorAzureProvider _ => 1,
            BetaAnalyticsFederatedActorGcpProvider _ => 2,
            BetaAnalyticsFederatedActorOidcProvider _ => 3,
            _ => -1,
        };
    }
}

sealed class BetaAnalyticsFederatedActorProviderConverter
    : JsonConverter<BetaAnalyticsFederatedActorProvider>
{
    public override BetaAnalyticsFederatedActorProvider? Read(
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
            case "aws":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaAnalyticsFederatedActorAwsProvider>(
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
            case "azure":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaAnalyticsFederatedActorAzureProvider>(
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
            case "gcp":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaAnalyticsFederatedActorGcpProvider>(
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
            case "oidc":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaAnalyticsFederatedActorOidcProvider>(
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
                return new BetaAnalyticsFederatedActorProvider(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsFederatedActorProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaAnalyticsFederatedActorProviderTypeConverter))]
public enum BetaAnalyticsFederatedActorProviderType
{
    Aws,
    Azure,
    Gcp,
    Oidc,
}

sealed class BetaAnalyticsFederatedActorProviderTypeConverter
    : JsonConverter<BetaAnalyticsFederatedActorProviderType>
{
    public override BetaAnalyticsFederatedActorProviderType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "aws" => BetaAnalyticsFederatedActorProviderType.Aws,
            "azure" => BetaAnalyticsFederatedActorProviderType.Azure,
            "gcp" => BetaAnalyticsFederatedActorProviderType.Gcp,
            "oidc" => BetaAnalyticsFederatedActorProviderType.Oidc,
            _ => (BetaAnalyticsFederatedActorProviderType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsFederatedActorProviderType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAnalyticsFederatedActorProviderType.Aws => "aws",
                BetaAnalyticsFederatedActorProviderType.Azure => "azure",
                BetaAnalyticsFederatedActorProviderType.Gcp => "gcp",
                BetaAnalyticsFederatedActorProviderType.Oidc => "oidc",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
