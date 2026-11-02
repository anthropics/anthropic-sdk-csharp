using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.SpendLimits.IncreaseRequests;

/// <summary>
/// Who submitted the increase request.
/// </summary>
[JsonConverter(typeof(BetaSpendLimitIncreaseRequestActorConverter))]
public record class BetaSpendLimitIncreaseRequestActor : ModelBase
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

    public ApiEnum<string, BetaSpendLimitIncreaseRequestActorType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaSpendLimitUserActor _ => BetaSpendLimitIncreaseRequestActorType.UserActor,
                BetaSpendLimitScopedApiKeyActor _ =>
                    BetaSpendLimitIncreaseRequestActorType.ScopedApiKeyActor,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaSpendLimitIncreaseRequestActorType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaSpendLimitIncreaseRequestActor(
        BetaSpendLimitUserActor value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaSpendLimitIncreaseRequestActor(
        BetaSpendLimitScopedApiKeyActor value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaSpendLimitIncreaseRequestActor(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaSpendLimitUserActor"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUser(out var value)) {
    ///     // `value` is of type `BetaSpendLimitUserActor`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUser([NotNullWhen(true)] out BetaSpendLimitUserActor? value)
    {
        value = this.Value as BetaSpendLimitUserActor;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaSpendLimitScopedApiKeyActor"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickScopedApiKey(out var value)) {
    ///     // `value` is of type `BetaSpendLimitScopedApiKeyActor`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickScopedApiKey([NotNullWhen(true)] out BetaSpendLimitScopedApiKeyActor? value)
    {
        value = this.Value as BetaSpendLimitScopedApiKeyActor;
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
    ///     (BetaSpendLimitUserActor value) =&gt; {...},
    ///     (BetaSpendLimitScopedApiKeyActor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaSpendLimitUserActor> user,
        Action<BetaSpendLimitScopedApiKeyActor> scopedApiKey
    )
    {
        switch (this.Value)
        {
            case BetaSpendLimitUserActor value:
                user(value);
                break;
            case BetaSpendLimitScopedApiKeyActor value:
                scopedApiKey(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaSpendLimitIncreaseRequestActor"
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
    ///     (BetaSpendLimitUserActor value) =&gt; {...},
    ///     (BetaSpendLimitScopedApiKeyActor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaSpendLimitUserActor, T> user,
        Func<BetaSpendLimitScopedApiKeyActor, T> scopedApiKey
    )
    {
        return this.Value switch
        {
            BetaSpendLimitUserActor value => user(value),
            BetaSpendLimitScopedApiKeyActor value => scopedApiKey(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaSpendLimitIncreaseRequestActor"
            ),
        };
    }

    public static implicit operator BetaSpendLimitIncreaseRequestActor(
        BetaSpendLimitUserActor value
    ) => new(value);

    public static implicit operator BetaSpendLimitIncreaseRequestActor(
        BetaSpendLimitScopedApiKeyActor value
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
                "Data did not match any variant of BetaSpendLimitIncreaseRequestActor"
            );
        }
        this.Switch((user) => user.Validate(), (scopedApiKey) => scopedApiKey.Validate());
    }

    public virtual bool Equals(BetaSpendLimitIncreaseRequestActor? other) =>
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
            BetaSpendLimitUserActor _ => 0,
            BetaSpendLimitScopedApiKeyActor _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaSpendLimitIncreaseRequestActorConverter
    : JsonConverter<BetaSpendLimitIncreaseRequestActor>
{
    public override BetaSpendLimitIncreaseRequestActor? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaSpendLimitUserActor>(
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
            case "scoped_api_key_actor":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaSpendLimitScopedApiKeyActor>(
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
                return new BetaSpendLimitIncreaseRequestActor(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaSpendLimitIncreaseRequestActor value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaSpendLimitIncreaseRequestActorTypeConverter))]
public enum BetaSpendLimitIncreaseRequestActorType
{
    UserActor,
    ScopedApiKeyActor,
}

sealed class BetaSpendLimitIncreaseRequestActorTypeConverter
    : JsonConverter<BetaSpendLimitIncreaseRequestActorType>
{
    public override BetaSpendLimitIncreaseRequestActorType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user_actor" => BetaSpendLimitIncreaseRequestActorType.UserActor,
            "scoped_api_key_actor" => BetaSpendLimitIncreaseRequestActorType.ScopedApiKeyActor,
            _ => (BetaSpendLimitIncreaseRequestActorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaSpendLimitIncreaseRequestActorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaSpendLimitIncreaseRequestActorType.UserActor => "user_actor",
                BetaSpendLimitIncreaseRequestActorType.ScopedApiKeyActor => "scoped_api_key_actor",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
