using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.SpendLimits.IncreaseRequests;

/// <summary>
/// Who submitted the increase request.
/// </summary>
[JsonConverter(typeof(SpendLimitIncreaseRequestActorConverter))]
public record class SpendLimitIncreaseRequestActor : ModelBase
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

    public ApiEnum<string, SpendLimitIncreaseRequestActorType> Type
    {
        get
        {
            return this.Value switch
            {
                SpendLimitUserActor _ => SpendLimitIncreaseRequestActorType.UserActor,
                SpendLimitScopedApiKeyActor _ =>
                    SpendLimitIncreaseRequestActorType.ScopedApiKeyActor,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, SpendLimitIncreaseRequestActorType>
                >(this.Json, "type"),
            };
        }
    }

    public SpendLimitIncreaseRequestActor(SpendLimitUserActor value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public SpendLimitIncreaseRequestActor(
        SpendLimitScopedApiKeyActor value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public SpendLimitIncreaseRequestActor(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SpendLimitUserActor"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUser(out var value)) {
    ///     // `value` is of type `SpendLimitUserActor`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUser([NotNullWhen(true)] out SpendLimitUserActor? value)
    {
        value = this.Value as SpendLimitUserActor;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SpendLimitScopedApiKeyActor"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickScopedApiKey(out var value)) {
    ///     // `value` is of type `SpendLimitScopedApiKeyActor`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickScopedApiKey([NotNullWhen(true)] out SpendLimitScopedApiKeyActor? value)
    {
        value = this.Value as SpendLimitScopedApiKeyActor;
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
    ///     (SpendLimitUserActor value) =&gt; {...},
    ///     (SpendLimitScopedApiKeyActor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<SpendLimitUserActor> user,
        Action<SpendLimitScopedApiKeyActor> scopedApiKey
    )
    {
        switch (this.Value)
        {
            case SpendLimitUserActor value:
                user(value);
                break;
            case SpendLimitScopedApiKeyActor value:
                scopedApiKey(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of SpendLimitIncreaseRequestActor"
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
    ///     (SpendLimitUserActor value) =&gt; {...},
    ///     (SpendLimitScopedApiKeyActor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<SpendLimitUserActor, T> user,
        Func<SpendLimitScopedApiKeyActor, T> scopedApiKey
    )
    {
        return this.Value switch
        {
            SpendLimitUserActor value => user(value),
            SpendLimitScopedApiKeyActor value => scopedApiKey(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of SpendLimitIncreaseRequestActor"
            ),
        };
    }

    public static implicit operator SpendLimitIncreaseRequestActor(SpendLimitUserActor value) =>
        new(value);

    public static implicit operator SpendLimitIncreaseRequestActor(
        SpendLimitScopedApiKeyActor value
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
                "Data did not match any variant of SpendLimitIncreaseRequestActor"
            );
        }
        this.Switch((user) => user.Validate(), (scopedApiKey) => scopedApiKey.Validate());
    }

    public virtual bool Equals(SpendLimitIncreaseRequestActor? other) =>
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
            SpendLimitUserActor _ => 0,
            SpendLimitScopedApiKeyActor _ => 1,
            _ => -1,
        };
    }
}

sealed class SpendLimitIncreaseRequestActorConverter : JsonConverter<SpendLimitIncreaseRequestActor>
{
    public override SpendLimitIncreaseRequestActor? Read(
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
                    var deserialized = JsonSerializer.Deserialize<SpendLimitUserActor>(
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
                    var deserialized = JsonSerializer.Deserialize<SpendLimitScopedApiKeyActor>(
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
                return new SpendLimitIncreaseRequestActor(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        SpendLimitIncreaseRequestActor value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(SpendLimitIncreaseRequestActorTypeConverter))]
public enum SpendLimitIncreaseRequestActorType
{
    UserActor,
    ScopedApiKeyActor,
}

sealed class SpendLimitIncreaseRequestActorTypeConverter
    : JsonConverter<SpendLimitIncreaseRequestActorType>
{
    public override SpendLimitIncreaseRequestActorType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user_actor" => SpendLimitIncreaseRequestActorType.UserActor,
            "scoped_api_key_actor" => SpendLimitIncreaseRequestActorType.ScopedApiKeyActor,
            _ => (SpendLimitIncreaseRequestActorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SpendLimitIncreaseRequestActorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SpendLimitIncreaseRequestActorType.UserActor => "user_actor",
                SpendLimitIncreaseRequestActorType.ScopedApiKeyActor => "scoped_api_key_actor",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
