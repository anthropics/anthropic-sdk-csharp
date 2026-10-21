using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaMessageParamConverter))]
public record class BetaMessageParam : ModelBase
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

    public BetaMessageContentParam? Content
    {
        get
        {
            return this.Value switch
            {
                BetaUserMessageParam x => x.Content,
                BetaAssistantMessageParam x => x.Content,
                BetaSystemMessageParam x => x.Content is { } value
                    ? value switch
                    {
                        { Value: string value1 } => new BetaMessageContentParam(value1),
                        { Value: IReadOnlyList<SystemMessageContentBlock> value1 } =>
                            new BetaMessageContentParam(
                                ImmutableArray.ToImmutableArray(
                                    Enumerable.Select(
                                        value1,
                                        (item) =>
                                            item switch
                                            {
                                                { Value: BetaTextBlockParam value2 } =>
                                                    new BetaContentBlockParam(value2),
                                                { Value: BetaRequestToolAdditionBlock value2 } =>
                                                    new BetaContentBlockParam(value2),
                                                { Value: BetaRequestToolRemovalBlock value2 } =>
                                                    new BetaContentBlockParam(value2),
                                                var unknown =>
                                                    WrappedJsonSerializer.GetNotNullClass<BetaContentBlockParam>(
                                                        unknown.Json,
                                                        nameof(SystemMessageContentBlock)
                                                    ),
                                            }
                                    )
                                )
                            ),
                        var unknown =>
                            WrappedJsonSerializer.GetNotNullClass<BetaMessageContentParam>(
                                unknown.Json,
                                nameof(BetaSystemMessageParamContent)
                            ),
                    }
                    : null,
                _ => WrappedJsonSerializer.GetNullableClassProperty<BetaMessageContentParam>(
                    this.Json,
                    "content"
                ),
            };
        }
    }

    public ApiEnum<string, BetaMessageParamRole> Role
    {
        get
        {
            return this.Value switch
            {
                BetaUserMessageParam _ => BetaMessageParamRole.User,
                BetaAssistantMessageParam _ => BetaMessageParamRole.Assistant,
                BetaSystemMessageParam _ => BetaMessageParamRole.System,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaMessageParamRole>
                >(this.Json, "role"),
            };
        }
    }

    public BetaMessageParam(BetaUserMessageParam value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaMessageParam(BetaAssistantMessageParam value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaMessageParam(BetaSystemMessageParam value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaMessageParam(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaUserMessageParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUser(out var value)) {
    ///     // `value` is of type `BetaUserMessageParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUser([NotNullWhen(true)] out BetaUserMessageParam? value)
    {
        value = this.Value as BetaUserMessageParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaAssistantMessageParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAssistant(out var value)) {
    ///     // `value` is of type `BetaAssistantMessageParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAssistant([NotNullWhen(true)] out BetaAssistantMessageParam? value)
    {
        value = this.Value as BetaAssistantMessageParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaSystemMessageParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSystem(out var value)) {
    ///     // `value` is of type `BetaSystemMessageParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSystem([NotNullWhen(true)] out BetaSystemMessageParam? value)
    {
        value = this.Value as BetaSystemMessageParam;
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
    ///     (BetaUserMessageParam value) =&gt; {...},
    ///     (BetaAssistantMessageParam value) =&gt; {...},
    ///     (BetaSystemMessageParam value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaUserMessageParam> user,
        System::Action<BetaAssistantMessageParam> assistant,
        System::Action<BetaSystemMessageParam> system
    )
    {
        switch (this.Value)
        {
            case BetaUserMessageParam value:
                user(value);
                break;
            case BetaAssistantMessageParam value:
                assistant(value);
                break;
            case BetaSystemMessageParam value:
                system(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaMessageParam"
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
    ///     (BetaUserMessageParam value) =&gt; {...},
    ///     (BetaAssistantMessageParam value) =&gt; {...},
    ///     (BetaSystemMessageParam value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaUserMessageParam, T> user,
        System::Func<BetaAssistantMessageParam, T> assistant,
        System::Func<BetaSystemMessageParam, T> system
    )
    {
        return this.Value switch
        {
            BetaUserMessageParam value => user(value),
            BetaAssistantMessageParam value => assistant(value),
            BetaSystemMessageParam value => system(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaMessageParam"
            ),
        };
    }

    public static implicit operator BetaMessageParam(BetaUserMessageParam value) => new(value);

    public static implicit operator BetaMessageParam(BetaAssistantMessageParam value) => new(value);

    public static implicit operator BetaMessageParam(BetaSystemMessageParam value) => new(value);

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
                "Data did not match any variant of BetaMessageParam"
            );
        }
        this.Switch(
            (user) => user.Validate(),
            (assistant) => assistant.Validate(),
            (system) => system.Validate()
        );
    }

    public virtual bool Equals(BetaMessageParam? other) =>
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
            BetaUserMessageParam _ => 0,
            BetaAssistantMessageParam _ => 1,
            BetaSystemMessageParam _ => 2,
            _ => -1,
        };
    }
}

sealed class BetaMessageParamConverter : JsonConverter<BetaMessageParam>
{
    public override BetaMessageParam? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? role;
        try
        {
            role = element.GetProperty("role").GetString();
        }
        catch
        {
            role = null;
        }

        switch (role)
        {
            case "user":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaUserMessageParam>(
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
            case "assistant":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaAssistantMessageParam>(
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
            case "system":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaSystemMessageParam>(
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
                return new BetaMessageParam(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaMessageParam value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaMessageParamRoleConverter))]
public enum BetaMessageParamRole
{
    User,
    Assistant,
    System,
}

sealed class BetaMessageParamRoleConverter : JsonConverter<BetaMessageParamRole>
{
    public override BetaMessageParamRole Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user" => BetaMessageParamRole.User,
            "assistant" => BetaMessageParamRole.Assistant,
            "system" => BetaMessageParamRole.System,
            _ => (BetaMessageParamRole)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaMessageParamRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaMessageParamRole.User => "user",
                BetaMessageParamRole.Assistant => "assistant",
                BetaMessageParamRole.System => "system",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
