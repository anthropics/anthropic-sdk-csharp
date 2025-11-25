using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<MessageParam, MessageParamFromRaw>))]
public sealed record class MessageParam : ModelBase
{
    public required MessageParamContent Content
    {
        get
        {
            if (!this._rawData.TryGetValue("content", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'content' cannot be null",
                    new System::ArgumentOutOfRangeException("content", "Missing required argument")
                );

            return JsonSerializer.Deserialize<MessageParamContent>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new AnthropicInvalidDataException(
                    "'content' cannot be null",
                    new System::ArgumentNullException("content")
                );
        }
        init
        {
            this._rawData["content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, Role> Role
    {
        get
        {
            if (!this._rawData.TryGetValue("role", out JsonElement element))
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
            this._rawData["role"] = JsonSerializer.SerializeToElement(
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

    public MessageParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static MessageParam FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageParamFromRaw : IFromRaw<MessageParam>
{
    public MessageParam FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MessageParam.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(MessageParamContentConverter))]
public record class MessageParamContent
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public MessageParamContent(string value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public MessageParamContent(IReadOnlyList<ContentBlockParam> value, JsonElement? json = null)
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._json = json;
    }

    public MessageParamContent(JsonElement json)
    {
        this._json = json;
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
                    "Data did not match any variant of MessageParamContent"
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
                "Data did not match any variant of MessageParamContent"
            ),
        };
    }

    public static implicit operator MessageParamContent(string value) => new(value);

    public static implicit operator MessageParamContent(List<ContentBlockParam> value) =>
        new((IReadOnlyList<ContentBlockParam>)value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of MessageParamContent"
            );
        }
    }
}

sealed class MessageParamContentConverter : JsonConverter<MessageParamContent>
{
    public override MessageParamContent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(json, options);
            if (deserialized != null)
            {
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<ContentBlockParam>>(json, options);
            if (deserialized != null)
            {
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessageParamContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
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
