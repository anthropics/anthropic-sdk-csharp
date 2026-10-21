using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(MessageParamConverter))]
public record class MessageParam : ModelBase
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

    public MessageContentParam Content
    {
        get
        {
            return this.Value switch
            {
                UserMessageParam x => x.Content,
                AssistantMessageParam x => x.Content,
                SystemMessageParam x => x.Content switch
                {
                    { Value: string value } => new MessageContentParam(value),
                    { Value: IReadOnlyList<TextBlockParam> value } => new MessageContentParam(
                        ImmutableArray.ToImmutableArray(
                            Enumerable.Select(value, (item) => new ContentBlockParam(item))
                        )
                    ),
                    var unknown => WrappedJsonSerializer.GetNotNullClass<MessageContentParam>(
                        unknown.Json,
                        nameof(SystemMessageParamContent)
                    ),
                },
                _ => WrappedJsonSerializer.GetNotNullClassProperty<MessageContentParam>(
                    this.Json,
                    "content"
                ),
            };
        }
    }

    public ApiEnum<string, MessageParamRole> Role
    {
        get
        {
            return this.Value switch
            {
                UserMessageParam _ => MessageParamRole.User,
                AssistantMessageParam _ => MessageParamRole.Assistant,
                SystemMessageParam _ => MessageParamRole.System,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, MessageParamRole>
                >(this.Json, "role"),
            };
        }
    }

    public MessageParam(UserMessageParam value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public MessageParam(AssistantMessageParam value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public MessageParam(SystemMessageParam value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public MessageParam(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="UserMessageParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickUser(out var value)) {
    ///     // `value` is of type `UserMessageParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickUser([NotNullWhen(true)] out UserMessageParam? value)
    {
        value = this.Value as UserMessageParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="AssistantMessageParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickAssistant(out var value)) {
    ///     // `value` is of type `AssistantMessageParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickAssistant([NotNullWhen(true)] out AssistantMessageParam? value)
    {
        value = this.Value as AssistantMessageParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="SystemMessageParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSystem(out var value)) {
    ///     // `value` is of type `SystemMessageParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSystem([NotNullWhen(true)] out SystemMessageParam? value)
    {
        value = this.Value as SystemMessageParam;
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
    ///     (UserMessageParam value) =&gt; {...},
    ///     (AssistantMessageParam value) =&gt; {...},
    ///     (SystemMessageParam value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<UserMessageParam> user,
        System::Action<AssistantMessageParam> assistant,
        System::Action<SystemMessageParam> system
    )
    {
        switch (this.Value)
        {
            case UserMessageParam value:
                user(value);
                break;
            case AssistantMessageParam value:
                assistant(value);
                break;
            case SystemMessageParam value:
                system(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of MessageParam"
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
    ///     (UserMessageParam value) =&gt; {...},
    ///     (AssistantMessageParam value) =&gt; {...},
    ///     (SystemMessageParam value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<UserMessageParam, T> user,
        System::Func<AssistantMessageParam, T> assistant,
        System::Func<SystemMessageParam, T> system
    )
    {
        return this.Value switch
        {
            UserMessageParam value => user(value),
            AssistantMessageParam value => assistant(value),
            SystemMessageParam value => system(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of MessageParam"
            ),
        };
    }

    public static implicit operator MessageParam(UserMessageParam value) => new(value);

    public static implicit operator MessageParam(AssistantMessageParam value) => new(value);

    public static implicit operator MessageParam(SystemMessageParam value) => new(value);

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
                "Data did not match any variant of MessageParam"
            );
        }
        this.Switch(
            (user) => user.Validate(),
            (assistant) => assistant.Validate(),
            (system) => system.Validate()
        );
    }

    public virtual bool Equals(MessageParam? other) =>
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
            UserMessageParam _ => 0,
            AssistantMessageParam _ => 1,
            SystemMessageParam _ => 2,
            _ => -1,
        };
    }
}

sealed class MessageParamConverter : JsonConverter<MessageParam>
{
    public override MessageParam? Read(
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
                    var deserialized = JsonSerializer.Deserialize<UserMessageParam>(
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
                    var deserialized = JsonSerializer.Deserialize<AssistantMessageParam>(
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
                    var deserialized = JsonSerializer.Deserialize<SystemMessageParam>(
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
                return new MessageParam(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessageParam value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(MessageParamRoleConverter))]
public enum MessageParamRole
{
    User,
    Assistant,
    System,
}

sealed class MessageParamRoleConverter : JsonConverter<MessageParamRole>
{
    public override MessageParamRole Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user" => MessageParamRole.User,
            "assistant" => MessageParamRole.Assistant,
            "system" => MessageParamRole.System,
            _ => (MessageParamRole)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessageParamRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MessageParamRole.User => "user",
                MessageParamRole.Assistant => "assistant",
                MessageParamRole.System => "system",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
