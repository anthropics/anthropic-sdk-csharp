using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaContentBlockSource>))]
public sealed record class BetaContentBlockSource : ModelBase, IFromRaw<BetaContentBlockSource>
{
    public required Content1 Content
    {
        get
        {
            if (!this._properties.TryGetValue("content", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'content' cannot be null",
                    new System::ArgumentOutOfRangeException("content", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Content1>(element, ModelBase.SerializerOptions)
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
        _ = this.Type;
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
    public BetaContentBlockSource(Content1 content)
        : this()
    {
        this.Content = content;
    }
}

[JsonConverter(typeof(Content1Converter))]
public record class Content1
{
    public object Value { get; private init; }

    public Content1(string value)
    {
        Value = value;
    }

    public Content1(IReadOnlyList<BetaContentBlockSourceContent> value)
    {
        Value = ImmutableArray.ToImmutableArray(value);
    }

    Content1(UnknownVariant value)
    {
        Value = value;
    }

    public static Content1 CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickBetaContentBlockSource(
        [NotNullWhen(true)] out IReadOnlyList<BetaContentBlockSourceContent>? value
    )
    {
        value = this.Value as IReadOnlyList<BetaContentBlockSourceContent>;
        return value != null;
    }

    public void Switch(
        System::Action<string> @string,
        System::Action<IReadOnlyList<BetaContentBlockSourceContent>> betaContentBlockSourceContent
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case List<BetaContentBlockSourceContent> value:
                betaContentBlockSourceContent(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Content1"
                );
        }
    }

    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<IReadOnlyList<BetaContentBlockSourceContent>, T> betaContentBlockSourceContent
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            IReadOnlyList<BetaContentBlockSourceContent> value => betaContentBlockSourceContent(
                value
            ),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Content1"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Content1");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class Content1Converter : JsonConverter<Content1>
{
    public override Content1? Read(
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
                return new Content1(deserialized);
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
            var deserialized = JsonSerializer.Deserialize<List<BetaContentBlockSourceContent>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new Content1(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'List<BetaContentBlockSourceContent>'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Content1 value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
