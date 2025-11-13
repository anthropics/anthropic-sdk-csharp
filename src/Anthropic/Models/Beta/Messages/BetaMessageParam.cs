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

[JsonConverter(typeof(ModelConverter<BetaMessageParam>))]
public sealed record class BetaMessageParam : ModelBase, IFromRaw<BetaMessageParam>
{
    public required BetaMessageParamContent Content
    {
        get
        {
            if (!this._properties.TryGetValue("content", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'content' cannot be null",
                    new System::ArgumentOutOfRangeException("content", "Missing required argument")
                );

            return JsonSerializer.Deserialize<BetaMessageParamContent>(
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

    public BetaMessageParam() { }

    public BetaMessageParam(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMessageParam(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaMessageParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(BetaMessageParamContentConverter))]
public record class BetaMessageParamContent
{
    public object Value { get; private init; }

    public BetaMessageParamContent(string value)
    {
        Value = value;
    }

    public BetaMessageParamContent(IReadOnlyList<BetaContentBlockParam> value)
    {
        Value = ImmutableArray.ToImmutableArray(value);
    }

    BetaMessageParamContent(UnknownVariant value)
    {
        Value = value;
    }

    public static BetaMessageParamContent CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickBetaContentBlockParams(
        [NotNullWhen(true)] out IReadOnlyList<BetaContentBlockParam>? value
    )
    {
        value = this.Value as IReadOnlyList<BetaContentBlockParam>;
        return value != null;
    }

    public void Switch(
        System::Action<string> @string,
        System::Action<IReadOnlyList<BetaContentBlockParam>> betaContentBlockParams
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case List<BetaContentBlockParam> value:
                betaContentBlockParams(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaMessageParamContent"
                );
        }
    }

    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<IReadOnlyList<BetaContentBlockParam>, T> betaContentBlockParams
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            IReadOnlyList<BetaContentBlockParam> value => betaContentBlockParams(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaMessageParamContent"
            ),
        };
    }

    public static implicit operator BetaMessageParamContent(string value) => new(value);

    public static implicit operator BetaMessageParamContent(List<BetaContentBlockParam> value) =>
        new((IReadOnlyList<BetaContentBlockParam>)value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaMessageParamContent"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class BetaMessageParamContentConverter : JsonConverter<BetaMessageParamContent>
{
    public override BetaMessageParamContent? Read(
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
                return new BetaMessageParamContent(deserialized);
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
            var deserialized = JsonSerializer.Deserialize<List<BetaContentBlockParam>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaMessageParamContent(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'List<BetaContentBlockParam>'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaMessageParamContent value,
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
