using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Messages;

[JsonConverter(typeof(ModelConverter<MessageParam>))]
public sealed record class MessageParam : ModelBase, IFromRaw<MessageParam>
{
    public required ContentModel Content
    {
        get
        {
            if (!this._properties.TryGetValue("content", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'content' cannot be null",
                    new System::ArgumentOutOfRangeException("content", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ContentModel>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'content' cannot be null",
                    new System::ArgumentNullException("content")
                );
        }
        init
        {
            this._properties["content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, Role> Role
    {
        get
        {
            if (!this._properties.TryGetValue("role", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'role' cannot be null",
                    new System::ArgumentOutOfRangeException("role", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, Role>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["role"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Content.Validate();
        this.Role.Validate();
    }

    public MessageParam() { }

    public MessageParam(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageParam(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static MessageParam FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(ContentModelConverter))]
public record class ContentModel
{
    public object Value { get; private init; }

    public ContentModel(string value)
    {
        Value = value;
    }

    public ContentModel(IReadOnlyList<ContentBlockParam> value)
    {
        Value = ImmutableArray.ToImmutableArray(value);
    }

    ContentModel(UnknownVariant value)
    {
        Value = value;
    }

    public static ContentModel CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickContentBlockParams(
        [NotNullWhen(true)] out IReadOnlyList<ContentBlockParam>? value
    )
    {
        value = this.Value as IReadOnlyList<ContentBlockParam>;
        return value != null;
    }

    public void Switch(
        System::Action<string> @string,
        System::Action<IReadOnlyList<ContentBlockParam>> contentBlockParams
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case List<ContentBlockParam> value:
                contentBlockParams(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ContentModel"
                );
        }
    }

    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<IReadOnlyList<ContentBlockParam>, T> contentBlockParams
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            IReadOnlyList<ContentBlockParam> value => contentBlockParams(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ContentModel"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of ContentModel"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ContentModelConverter : JsonConverter<ContentModel>
{
    public override ContentModel? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<AnthropicInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new ContentModel(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException("Data does not match union variant 'string'", e)
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<ContentBlockParam>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new ContentModel(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'List<ContentBlockParam>'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContentModel value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}

[JsonConverter(typeof(RoleConverter))]
public enum Role
{
    User,
    Assistant,
}

sealed class RoleConverter : JsonConverter<Role>
{
    public override Role Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user" => Role.User,
            "assistant" => Role.Assistant,
            _ => (Role)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Role value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Role.User => "user",
                Role.Assistant => "assistant",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
