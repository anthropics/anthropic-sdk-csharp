using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaTextEditorCodeExecutionToolResultBlockParam>))]
public sealed record class BetaTextEditorCodeExecutionToolResultBlockParam
    : ModelBase,
        IFromRaw<BetaTextEditorCodeExecutionToolResultBlockParam>
{
    public required Content6 Content
    {
        get
        {
            if (!this._properties.TryGetValue("content", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'content' cannot be null",
                    new System::ArgumentOutOfRangeException("content", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Content6>(element, ModelBase.SerializerOptions)
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

    public required string ToolUseID
    {
        get
        {
            if (!this._properties.TryGetValue("tool_use_id", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'tool_use_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "tool_use_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'tool_use_id' cannot be null",
                    new System::ArgumentNullException("tool_use_id")
                );
        }
        init
        {
            this._properties["tool_use_id"] = JsonSerializer.SerializeToElement(
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

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            if (!this._properties.TryGetValue("cache_control", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaCacheControlEphemeral?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["cache_control"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Content.Validate();
        _ = this.ToolUseID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>(
                    "\"text_editor_code_execution_tool_result\""
                )
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
    }

    public BetaTextEditorCodeExecutionToolResultBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_tool_result\""
        );
    }

    public BetaTextEditorCodeExecutionToolResultBlockParam(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_tool_result\""
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTextEditorCodeExecutionToolResultBlockParam(
        FrozenDictionary<string, JsonElement> properties
    )
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaTextEditorCodeExecutionToolResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(Content6Converter))]
public record class Content6
{
    public object Value { get; private init; }

    public JsonElement Type
    {
        get
        {
            return Match(
                betaTextEditorCodeExecutionToolResultErrorParam: (x) => x.Type,
                betaTextEditorCodeExecutionViewResultBlockParam: (x) => x.Type,
                betaTextEditorCodeExecutionCreateResultBlockParam: (x) => x.Type,
                betaTextEditorCodeExecutionStrReplaceResultBlockParam: (x) => x.Type
            );
        }
    }

    public Content6(BetaTextEditorCodeExecutionToolResultErrorParam value)
    {
        Value = value;
    }

    public Content6(BetaTextEditorCodeExecutionViewResultBlockParam value)
    {
        Value = value;
    }

    public Content6(BetaTextEditorCodeExecutionCreateResultBlockParam value)
    {
        Value = value;
    }

    public Content6(BetaTextEditorCodeExecutionStrReplaceResultBlockParam value)
    {
        Value = value;
    }

    Content6(UnknownVariant value)
    {
        Value = value;
    }

    public static Content6 CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickBetaTextEditorCodeExecutionToolResultErrorParam(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionToolResultErrorParam? value
    )
    {
        value = this.Value as BetaTextEditorCodeExecutionToolResultErrorParam;
        return value != null;
    }

    public bool TryPickBetaTextEditorCodeExecutionViewResultBlockParam(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionViewResultBlockParam? value
    )
    {
        value = this.Value as BetaTextEditorCodeExecutionViewResultBlockParam;
        return value != null;
    }

    public bool TryPickBetaTextEditorCodeExecutionCreateResultBlockParam(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionCreateResultBlockParam? value
    )
    {
        value = this.Value as BetaTextEditorCodeExecutionCreateResultBlockParam;
        return value != null;
    }

    public bool TryPickBetaTextEditorCodeExecutionStrReplaceResultBlockParam(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionStrReplaceResultBlockParam? value
    )
    {
        value = this.Value as BetaTextEditorCodeExecutionStrReplaceResultBlockParam;
        return value != null;
    }

    public void Switch(
        System::Action<BetaTextEditorCodeExecutionToolResultErrorParam> betaTextEditorCodeExecutionToolResultErrorParam,
        System::Action<BetaTextEditorCodeExecutionViewResultBlockParam> betaTextEditorCodeExecutionViewResultBlockParam,
        System::Action<BetaTextEditorCodeExecutionCreateResultBlockParam> betaTextEditorCodeExecutionCreateResultBlockParam,
        System::Action<BetaTextEditorCodeExecutionStrReplaceResultBlockParam> betaTextEditorCodeExecutionStrReplaceResultBlockParam
    )
    {
        switch (this.Value)
        {
            case BetaTextEditorCodeExecutionToolResultErrorParam value:
                betaTextEditorCodeExecutionToolResultErrorParam(value);
                break;
            case BetaTextEditorCodeExecutionViewResultBlockParam value:
                betaTextEditorCodeExecutionViewResultBlockParam(value);
                break;
            case BetaTextEditorCodeExecutionCreateResultBlockParam value:
                betaTextEditorCodeExecutionCreateResultBlockParam(value);
                break;
            case BetaTextEditorCodeExecutionStrReplaceResultBlockParam value:
                betaTextEditorCodeExecutionStrReplaceResultBlockParam(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Content6"
                );
        }
    }

    public T Match<T>(
        System::Func<
            BetaTextEditorCodeExecutionToolResultErrorParam,
            T
        > betaTextEditorCodeExecutionToolResultErrorParam,
        System::Func<
            BetaTextEditorCodeExecutionViewResultBlockParam,
            T
        > betaTextEditorCodeExecutionViewResultBlockParam,
        System::Func<
            BetaTextEditorCodeExecutionCreateResultBlockParam,
            T
        > betaTextEditorCodeExecutionCreateResultBlockParam,
        System::Func<
            BetaTextEditorCodeExecutionStrReplaceResultBlockParam,
            T
        > betaTextEditorCodeExecutionStrReplaceResultBlockParam
    )
    {
        return this.Value switch
        {
            BetaTextEditorCodeExecutionToolResultErrorParam value =>
                betaTextEditorCodeExecutionToolResultErrorParam(value),
            BetaTextEditorCodeExecutionViewResultBlockParam value =>
                betaTextEditorCodeExecutionViewResultBlockParam(value),
            BetaTextEditorCodeExecutionCreateResultBlockParam value =>
                betaTextEditorCodeExecutionCreateResultBlockParam(value),
            BetaTextEditorCodeExecutionStrReplaceResultBlockParam value =>
                betaTextEditorCodeExecutionStrReplaceResultBlockParam(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Content6"
            ),
        };
    }

    public static implicit operator Content6(
        BetaTextEditorCodeExecutionToolResultErrorParam value
    ) => new(value);

    public static implicit operator Content6(
        BetaTextEditorCodeExecutionViewResultBlockParam value
    ) => new(value);

    public static implicit operator Content6(
        BetaTextEditorCodeExecutionCreateResultBlockParam value
    ) => new(value);

    public static implicit operator Content6(
        BetaTextEditorCodeExecutionStrReplaceResultBlockParam value
    ) => new(value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Content6");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class Content6Converter : JsonConverter<Content6>
{
    public override Content6? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<AnthropicInvalidDataException> exceptions = [];

        try
        {
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultErrorParam>(
                    ref reader,
                    options
                );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Content6(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaTextEditorCodeExecutionToolResultErrorParam'",
                    e
                )
            );
        }

        try
        {
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionViewResultBlockParam>(
                    ref reader,
                    options
                );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Content6(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaTextEditorCodeExecutionViewResultBlockParam'",
                    e
                )
            );
        }

        try
        {
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionCreateResultBlockParam>(
                    ref reader,
                    options
                );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Content6(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaTextEditorCodeExecutionCreateResultBlockParam'",
                    e
                )
            );
        }

        try
        {
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionStrReplaceResultBlockParam>(
                    ref reader,
                    options
                );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Content6(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaTextEditorCodeExecutionStrReplaceResultBlockParam'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Content6 value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
