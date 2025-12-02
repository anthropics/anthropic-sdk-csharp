using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaCodeExecutionToolResultBlockParamContentConverter))]
public record class BetaCodeExecutionToolResultBlockParamContent
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public JsonElement Type
    {
        get { return Match(errorParam: (x) => x.Type, resultBlockParam: (x) => x.Type); }
    }

    public BetaCodeExecutionToolResultBlockParamContent(
        BetaCodeExecutionToolResultErrorParam value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public BetaCodeExecutionToolResultBlockParamContent(
        BetaCodeExecutionResultBlockParam value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public BetaCodeExecutionToolResultBlockParamContent(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickErrorParam(
        [NotNullWhen(true)] out BetaCodeExecutionToolResultErrorParam? value
    )
    {
        value = this.Value as BetaCodeExecutionToolResultErrorParam;
        return value != null;
    }

    public bool TryPickResultBlockParam(
        [NotNullWhen(true)] out BetaCodeExecutionResultBlockParam? value
    )
    {
        value = this.Value as BetaCodeExecutionResultBlockParam;
        return value != null;
    }

    public void Switch(
        System::Action<BetaCodeExecutionToolResultErrorParam> errorParam,
        System::Action<BetaCodeExecutionResultBlockParam> resultBlockParam
    )
    {
        switch (this.Value)
        {
            case BetaCodeExecutionToolResultErrorParam value:
                errorParam(value);
                break;
            case BetaCodeExecutionResultBlockParam value:
                resultBlockParam(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaCodeExecutionToolResultBlockParamContent"
                );
        }
    }

    public T Match<T>(
        System::Func<BetaCodeExecutionToolResultErrorParam, T> errorParam,
        System::Func<BetaCodeExecutionResultBlockParam, T> resultBlockParam
    )
    {
        return this.Value switch
        {
            BetaCodeExecutionToolResultErrorParam value => errorParam(value),
            BetaCodeExecutionResultBlockParam value => resultBlockParam(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaCodeExecutionToolResultBlockParamContent"
            ),
        };
    }

    public static implicit operator BetaCodeExecutionToolResultBlockParamContent(
        BetaCodeExecutionToolResultErrorParam value
    ) => new(value);

    public static implicit operator BetaCodeExecutionToolResultBlockParamContent(
        BetaCodeExecutionResultBlockParam value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaCodeExecutionToolResultBlockParamContent"
            );
        }
    }

    public virtual bool Equals(BetaCodeExecutionToolResultBlockParamContent? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class BetaCodeExecutionToolResultBlockParamContentConverter
    : JsonConverter<BetaCodeExecutionToolResultBlockParamContent>
{
    public override BetaCodeExecutionToolResultBlockParamContent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionToolResultErrorParam>(
                json,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionResultBlockParam>(
                json,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
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
        BetaCodeExecutionToolResultBlockParamContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
