using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// The server's per-invocation judgement under the auto permission policy. Its type
/// always equals the event's top-level evaluated_permission. Open union: clients
/// must tolerate unknown variants.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsAgentAutoEvaluatedPermissionConverter))]
public record class BetaManagedAgentsAgentAutoEvaluatedPermission : ModelBase
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

    public ApiEnum<string, BetaManagedAgentsAgentAutoEvaluatedPermissionType> Type
    {
        get
        {
            return this.Value switch
            {
                BetaManagedAgentsAgentAutoEvaluatedPermissionAllow _ =>
                    BetaManagedAgentsAgentAutoEvaluatedPermissionType.Allow,
                BetaManagedAgentsAgentAutoEvaluatedPermissionAsk _ =>
                    BetaManagedAgentsAgentAutoEvaluatedPermissionType.Ask,
                BetaManagedAgentsAgentAutoEvaluatedPermissionDeny _ =>
                    BetaManagedAgentsAgentAutoEvaluatedPermissionType.Deny,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaManagedAgentsAgentAutoEvaluatedPermissionType>
                >(this.Json, "type"),
            };
        }
    }

    public string? ReasonCode
    {
        get
        {
            return this.Value switch
            {
                BetaManagedAgentsAgentAutoEvaluatedPermissionAllow _ => null,
                BetaManagedAgentsAgentAutoEvaluatedPermissionAsk x => x.ReasonCode,
                BetaManagedAgentsAgentAutoEvaluatedPermissionDeny x => x.ReasonCode,
                _ => WrappedJsonSerializer.GetNullableClassProperty<string>(
                    this.Json,
                    "reason_code"
                ),
            };
        }
    }

    public BetaManagedAgentsAgentAutoEvaluatedPermission(
        BetaManagedAgentsAgentAutoEvaluatedPermissionAllow value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsAgentAutoEvaluatedPermission(
        BetaManagedAgentsAgentAutoEvaluatedPermissionAsk value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsAgentAutoEvaluatedPermission(
        BetaManagedAgentsAgentAutoEvaluatedPermissionDeny value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsAgentAutoEvaluatedPermission(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsAgentAutoEvaluatedPermissionAllow"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAllow(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAgentAutoEvaluatedPermissionAllow`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAllow(
        [NotNullWhen(true)] out BetaManagedAgentsAgentAutoEvaluatedPermissionAllow? value
    )
    {
        value = this.Value as BetaManagedAgentsAgentAutoEvaluatedPermissionAllow;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsAgentAutoEvaluatedPermissionAsk"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAsk(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAgentAutoEvaluatedPermissionAsk`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAsk(
        [NotNullWhen(true)] out BetaManagedAgentsAgentAutoEvaluatedPermissionAsk? value
    )
    {
        value = this.Value as BetaManagedAgentsAgentAutoEvaluatedPermissionAsk;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaManagedAgentsAgentAutoEvaluatedPermissionDeny"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDeny(out var value)) {
    ///     // `value` is of type `BetaManagedAgentsAgentAutoEvaluatedPermissionDeny`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDeny(
        [NotNullWhen(true)] out BetaManagedAgentsAgentAutoEvaluatedPermissionDeny? value
    )
    {
        value = this.Value as BetaManagedAgentsAgentAutoEvaluatedPermissionDeny;
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
    ///     (BetaManagedAgentsAgentAutoEvaluatedPermissionAllow value) =&gt; {...},
    ///     (BetaManagedAgentsAgentAutoEvaluatedPermissionAsk value) =&gt; {...},
    ///     (BetaManagedAgentsAgentAutoEvaluatedPermissionDeny value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<BetaManagedAgentsAgentAutoEvaluatedPermissionAllow> allow,
        Action<BetaManagedAgentsAgentAutoEvaluatedPermissionAsk> ask,
        Action<BetaManagedAgentsAgentAutoEvaluatedPermissionDeny> deny
    )
    {
        switch (this.Value)
        {
            case BetaManagedAgentsAgentAutoEvaluatedPermissionAllow value:
                allow(value);
                break;
            case BetaManagedAgentsAgentAutoEvaluatedPermissionAsk value:
                ask(value);
                break;
            case BetaManagedAgentsAgentAutoEvaluatedPermissionDeny value:
                deny(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsAgentAutoEvaluatedPermission"
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
    ///     (BetaManagedAgentsAgentAutoEvaluatedPermissionAllow value) =&gt; {...},
    ///     (BetaManagedAgentsAgentAutoEvaluatedPermissionAsk value) =&gt; {...},
    ///     (BetaManagedAgentsAgentAutoEvaluatedPermissionDeny value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<BetaManagedAgentsAgentAutoEvaluatedPermissionAllow, T> allow,
        Func<BetaManagedAgentsAgentAutoEvaluatedPermissionAsk, T> ask,
        Func<BetaManagedAgentsAgentAutoEvaluatedPermissionDeny, T> deny
    )
    {
        return this.Value switch
        {
            BetaManagedAgentsAgentAutoEvaluatedPermissionAllow value => allow(value),
            BetaManagedAgentsAgentAutoEvaluatedPermissionAsk value => ask(value),
            BetaManagedAgentsAgentAutoEvaluatedPermissionDeny value => deny(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsAgentAutoEvaluatedPermission"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsAgentAutoEvaluatedPermission(
        BetaManagedAgentsAgentAutoEvaluatedPermissionAllow value
    ) => new(value);

    public static implicit operator BetaManagedAgentsAgentAutoEvaluatedPermission(
        BetaManagedAgentsAgentAutoEvaluatedPermissionAsk value
    ) => new(value);

    public static implicit operator BetaManagedAgentsAgentAutoEvaluatedPermission(
        BetaManagedAgentsAgentAutoEvaluatedPermissionDeny value
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
                "Data did not match any variant of BetaManagedAgentsAgentAutoEvaluatedPermission"
            );
        }
        this.Switch(
            (allow) => allow.Validate(),
            (ask) => ask.Validate(),
            (deny) => deny.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsAgentAutoEvaluatedPermission? other) =>
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
            BetaManagedAgentsAgentAutoEvaluatedPermissionAllow _ => 0,
            BetaManagedAgentsAgentAutoEvaluatedPermissionAsk _ => 1,
            BetaManagedAgentsAgentAutoEvaluatedPermissionDeny _ => 2,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsAgentAutoEvaluatedPermissionConverter
    : JsonConverter<BetaManagedAgentsAgentAutoEvaluatedPermission>
{
    public override BetaManagedAgentsAgentAutoEvaluatedPermission? Read(
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
            case "allow":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsAgentAutoEvaluatedPermissionAllow>(
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
            case "ask":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsAgentAutoEvaluatedPermissionAsk>(
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
            case "deny":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaManagedAgentsAgentAutoEvaluatedPermissionDeny>(
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
                return new BetaManagedAgentsAgentAutoEvaluatedPermission(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsAgentAutoEvaluatedPermission value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaManagedAgentsAgentAutoEvaluatedPermissionTypeConverter))]
public enum BetaManagedAgentsAgentAutoEvaluatedPermissionType
{
    Allow,
    Ask,
    Deny,
}

sealed class BetaManagedAgentsAgentAutoEvaluatedPermissionTypeConverter
    : JsonConverter<BetaManagedAgentsAgentAutoEvaluatedPermissionType>
{
    public override BetaManagedAgentsAgentAutoEvaluatedPermissionType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "allow" => BetaManagedAgentsAgentAutoEvaluatedPermissionType.Allow,
            "ask" => BetaManagedAgentsAgentAutoEvaluatedPermissionType.Ask,
            "deny" => BetaManagedAgentsAgentAutoEvaluatedPermissionType.Deny,
            _ => (BetaManagedAgentsAgentAutoEvaluatedPermissionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsAgentAutoEvaluatedPermissionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsAgentAutoEvaluatedPermissionType.Allow => "allow",
                BetaManagedAgentsAgentAutoEvaluatedPermissionType.Ask => "ask",
                BetaManagedAgentsAgentAutoEvaluatedPermissionType.Deny => "deny",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
