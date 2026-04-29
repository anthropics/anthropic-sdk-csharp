using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.MemoryStores.MemoryVersions;

/// <summary>
/// Identifies who performed a write or redact operation. Captured at write time
/// on the `memory_version` row. The API key that created a session is not recorded
/// on agent writes; attribution answers who made the write, not who is ultimately
/// responsible. Look up session provenance separately via the [Sessions API](/en/api/sessions-retrieve).
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsActorConverter))]
public record class BetaManagedAgentsActor : ModelBase
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

    public BetaManagedAgentsActor(BetaManagedAgentsSessionActor value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsActor(BetaManagedAgentsApiActor value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsActor(BetaManagedAgentsUserActor value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsActor(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsSessionActor"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSession(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsSessionActor`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSession([NotNullWhen(true)] out BetaManagedAgentsSessionActor? value)
    {
        value = this.Value as BetaManagedAgentsSessionActor;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsApiActor"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickApi(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsApiActor`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickApi([NotNullWhen(true)] out BetaManagedAgentsApiActor? value)
    {
        value = this.Value as BetaManagedAgentsApiActor;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsUserActor"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUser(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsUserActor`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUser([NotNullWhen(true)] out BetaManagedAgentsUserActor? value)
    {
        value = this.Value as BetaManagedAgentsUserActor;
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
    ///     (BetaManagedAgentsSessionActor value) =&gt; {...},
    ///     (BetaManagedAgentsApiActor value) =&gt; {...},
    ///     (BetaManagedAgentsUserActor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaManagedAgentsSessionActor> session,
        System::Action<BetaManagedAgentsApiActor> api,
        System::Action<BetaManagedAgentsUserActor> user
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsSessionActor value:
                session(value);
                break;
            case BetaManagedAgentsApiActor value:
                api(value);
                break;
            case BetaManagedAgentsUserActor value:
                user(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsActor"
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
    ///     (BetaManagedAgentsSessionActor value) =&gt; {...},
    ///     (BetaManagedAgentsApiActor value) =&gt; {...},
    ///     (BetaManagedAgentsUserActor value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaManagedAgentsSessionActor, T> session,
        System::Func<BetaManagedAgentsApiActor, T> api,
        System::Func<BetaManagedAgentsUserActor, T> user
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsSessionActor value => session(value),
            BetaManagedAgentsApiActor value => api(value),
            BetaManagedAgentsUserActor value => user(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsActor"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsActor(BetaManagedAgentsSessionActor value) =>
        new(value);

    public static implicit operator BetaManagedAgentsActor(BetaManagedAgentsApiActor value) =>
        new(value);

    public static implicit operator BetaManagedAgentsActor(BetaManagedAgentsUserActor value) =>
        new(value);

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
                "Data did not match any variant of BetaManagedAgentsActor"
            );
        }
        this.Switch(
            (session) => session.Validate(),
            (api) => api.Validate(),
            (user) => user.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsActor? other) =>
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
            BetaManagedAgentsSessionActor _ => 0,
            BetaManagedAgentsApiActor _ => 1,
            BetaManagedAgentsUserActor _ => 2,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsActorConverter : JsonConverter<BetaManagedAgentsActor>
{
    public override BetaManagedAgentsActor? Read(
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
            case "session_actor":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionActor>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsApiActor>(
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
            case "user_actor":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsUserActor>(
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
                return new BetaManagedAgentsActor(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsActor value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
