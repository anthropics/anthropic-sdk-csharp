using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaContentBlockSource>))]
public sealed record class BetaContentBlockSource : ModelBase, IFromRaw<BetaContentBlockSource>
{
    public required BetaContentBlockSourceContent Content
    {
        get
        {
            if (!this._properties.TryGetValue("content", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'content' cannot be null",
                    new System::ArgumentOutOfRangeException("content", "Missing required argument")
                );

            return JsonSerializer.Deserialize<BetaContentBlockSourceContent>(
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
            this._properties["content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Content.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"content\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaContentBlockSource()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"content\"");
    }

    public BetaContentBlockSource(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"content\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaContentBlockSource(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaContentBlockSource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public BetaContentBlockSource(BetaContentBlockSourceContent content)
        : this()
    {
        this.Content = content;
    }
}

[JsonConverter(typeof(BetaContentBlockSourceContentConverter))]
public record class BetaContentBlockSourceContent
{
    public object Value { get; private init; }

    public BetaContentBlockSourceContent(string value)
    {
        Value = value;
    }

    public BetaContentBlockSourceContent(IReadOnlyList<MessageBetaContentBlockSourceContent> value)
    {
        Value = ImmutableArray.ToImmutableArray(value);
    }

    BetaContentBlockSourceContent(UnknownVariant value)
    {
        Value = value;
    }

    public static BetaContentBlockSourceContent CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickBetaContentBlockSource(
        [NotNullWhen(true)] out IReadOnlyList<MessageBetaContentBlockSourceContent>? value
    )
    {
        value = this.Value as IReadOnlyList<MessageBetaContentBlockSourceContent>;
        return value != null;
    }

    public void Switch(
        System::Action<string> @string,
        System::Action<
            IReadOnlyList<MessageBetaContentBlockSourceContent>
        > betaContentBlockSourceContent
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case List<MessageBetaContentBlockSourceContent> value:
                betaContentBlockSourceContent(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaContentBlockSourceContent"
                );
        }
    }

    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<
            IReadOnlyList<MessageBetaContentBlockSourceContent>,
            T
        > betaContentBlockSourceContent
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            IReadOnlyList<MessageBetaContentBlockSourceContent> value =>
                betaContentBlockSourceContent(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaContentBlockSourceContent"
            ),
        };
    }

    public static implicit operator BetaContentBlockSourceContent(string value) => new(value);

    public static implicit operator BetaContentBlockSourceContent(
        List<MessageBetaContentBlockSourceContent> value
    ) => new((IReadOnlyList<MessageBetaContentBlockSourceContent>)value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaContentBlockSourceContent"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class BetaContentBlockSourceContentConverter : JsonConverter<BetaContentBlockSourceContent>
{
    public override BetaContentBlockSourceContent? Read(
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
                return new BetaContentBlockSourceContent(deserialized);
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
            var deserialized = JsonSerializer.Deserialize<
                List<MessageBetaContentBlockSourceContent>
            >(ref reader, options);
            if (deserialized != null)
            {
                return new BetaContentBlockSourceContent(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'List<MessageBetaContentBlockSourceContent>'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaContentBlockSourceContent value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
