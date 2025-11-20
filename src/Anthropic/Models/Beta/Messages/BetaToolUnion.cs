using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaToolUnionConverter))]
public record class BetaToolUnion
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            return Match<BetaCacheControlEphemeral?>(
                betaTool: (x) => x.CacheControl,
                bash20241022: (x) => x.CacheControl,
                bash20250124: (x) => x.CacheControl,
                codeExecutionTool20250522: (x) => x.CacheControl,
                codeExecutionTool20250825: (x) => x.CacheControl,
                computerUse20241022: (x) => x.CacheControl,
                memoryTool20250818: (x) => x.CacheControl,
                computerUse20250124: (x) => x.CacheControl,
                textEditor20241022: (x) => x.CacheControl,
                textEditor20250124: (x) => x.CacheControl,
                textEditor20250429: (x) => x.CacheControl,
                textEditor20250728: (x) => x.CacheControl,
                webSearchTool20250305: (x) => x.CacheControl,
                webFetchTool20250910: (x) => x.CacheControl
            );
        }
    }

    public bool? Strict
    {
        get
        {
            return Match<bool?>(
                betaTool: (x) => x.Strict,
                bash20241022: (x) => x.Strict,
                bash20250124: (x) => x.Strict,
                codeExecutionTool20250522: (x) => x.Strict,
                codeExecutionTool20250825: (x) => x.Strict,
                computerUse20241022: (x) => x.Strict,
                memoryTool20250818: (x) => x.Strict,
                computerUse20250124: (x) => x.Strict,
                textEditor20241022: (x) => x.Strict,
                textEditor20250124: (x) => x.Strict,
                textEditor20250429: (x) => x.Strict,
                textEditor20250728: (x) => x.Strict,
                webSearchTool20250305: (x) => x.Strict,
                webFetchTool20250910: (x) => x.Strict
            );
        }
    }

    public long? DisplayHeightPx
    {
        get
        {
            return Match<long?>(
                betaTool: (_) => null,
                bash20241022: (_) => null,
                bash20250124: (_) => null,
                codeExecutionTool20250522: (_) => null,
                codeExecutionTool20250825: (_) => null,
                computerUse20241022: (x) => x.DisplayHeightPx,
                memoryTool20250818: (_) => null,
                computerUse20250124: (x) => x.DisplayHeightPx,
                textEditor20241022: (_) => null,
                textEditor20250124: (_) => null,
                textEditor20250429: (_) => null,
                textEditor20250728: (_) => null,
                webSearchTool20250305: (_) => null,
                webFetchTool20250910: (_) => null
            );
        }
    }

    public long? DisplayWidthPx
    {
        get
        {
            return Match<long?>(
                betaTool: (_) => null,
                bash20241022: (_) => null,
                bash20250124: (_) => null,
                codeExecutionTool20250522: (_) => null,
                codeExecutionTool20250825: (_) => null,
                computerUse20241022: (x) => x.DisplayWidthPx,
                memoryTool20250818: (_) => null,
                computerUse20250124: (x) => x.DisplayWidthPx,
                textEditor20241022: (_) => null,
                textEditor20250124: (_) => null,
                textEditor20250429: (_) => null,
                textEditor20250728: (_) => null,
                webSearchTool20250305: (_) => null,
                webFetchTool20250910: (_) => null
            );
        }
    }

    public long? DisplayNumber
    {
        get
        {
            return Match<long?>(
                betaTool: (_) => null,
                bash20241022: (_) => null,
                bash20250124: (_) => null,
                codeExecutionTool20250522: (_) => null,
                codeExecutionTool20250825: (_) => null,
                computerUse20241022: (x) => x.DisplayNumber,
                memoryTool20250818: (_) => null,
                computerUse20250124: (x) => x.DisplayNumber,
                textEditor20241022: (_) => null,
                textEditor20250124: (_) => null,
                textEditor20250429: (_) => null,
                textEditor20250728: (_) => null,
                webSearchTool20250305: (_) => null,
                webFetchTool20250910: (_) => null
            );
        }
    }

    public long? MaxUses
    {
        get
        {
            return Match<long?>(
                betaTool: (_) => null,
                bash20241022: (_) => null,
                bash20250124: (_) => null,
                codeExecutionTool20250522: (_) => null,
                codeExecutionTool20250825: (_) => null,
                computerUse20241022: (_) => null,
                memoryTool20250818: (_) => null,
                computerUse20250124: (_) => null,
                textEditor20241022: (_) => null,
                textEditor20250124: (_) => null,
                textEditor20250429: (_) => null,
                textEditor20250728: (_) => null,
                webSearchTool20250305: (x) => x.MaxUses,
                webFetchTool20250910: (x) => x.MaxUses
            );
        }
    }

    public BetaToolUnion(BetaTool value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaToolUnion(BetaToolBash20241022 value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaToolUnion(BetaToolBash20250124 value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaToolUnion(BetaCodeExecutionTool20250522 value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaToolUnion(BetaCodeExecutionTool20250825 value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaToolUnion(BetaToolComputerUse20241022 value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaToolUnion(BetaMemoryTool20250818 value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaToolUnion(BetaToolComputerUse20250124 value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaToolUnion(BetaToolTextEditor20241022 value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaToolUnion(BetaToolTextEditor20250124 value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaToolUnion(BetaToolTextEditor20250429 value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaToolUnion(BetaToolTextEditor20250728 value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaToolUnion(BetaWebSearchTool20250305 value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaToolUnion(BetaWebFetchTool20250910 value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaToolUnion(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickBetaTool([NotNullWhen(true)] out BetaTool? value)
    {
        value = this.Value as BetaTool;
        return value != null;
    }

    public bool TryPickBash20241022([NotNullWhen(true)] out BetaToolBash20241022? value)
    {
        value = this.Value as BetaToolBash20241022;
        return value != null;
    }

    public bool TryPickBash20250124([NotNullWhen(true)] out BetaToolBash20250124? value)
    {
        value = this.Value as BetaToolBash20250124;
        return value != null;
    }

    public bool TryPickCodeExecutionTool20250522(
        [NotNullWhen(true)] out BetaCodeExecutionTool20250522? value
    )
    {
        value = this.Value as BetaCodeExecutionTool20250522;
        return value != null;
    }

    public bool TryPickCodeExecutionTool20250825(
        [NotNullWhen(true)] out BetaCodeExecutionTool20250825? value
    )
    {
        value = this.Value as BetaCodeExecutionTool20250825;
        return value != null;
    }

    public bool TryPickComputerUse20241022(
        [NotNullWhen(true)] out BetaToolComputerUse20241022? value
    )
    {
        value = this.Value as BetaToolComputerUse20241022;
        return value != null;
    }

    public bool TryPickMemoryTool20250818([NotNullWhen(true)] out BetaMemoryTool20250818? value)
    {
        value = this.Value as BetaMemoryTool20250818;
        return value != null;
    }

    public bool TryPickComputerUse20250124(
        [NotNullWhen(true)] out BetaToolComputerUse20250124? value
    )
    {
        value = this.Value as BetaToolComputerUse20250124;
        return value != null;
    }

    public bool TryPickTextEditor20241022([NotNullWhen(true)] out BetaToolTextEditor20241022? value)
    {
        value = this.Value as BetaToolTextEditor20241022;
        return value != null;
    }

    public bool TryPickTextEditor20250124([NotNullWhen(true)] out BetaToolTextEditor20250124? value)
    {
        value = this.Value as BetaToolTextEditor20250124;
        return value != null;
    }

    public bool TryPickTextEditor20250429([NotNullWhen(true)] out BetaToolTextEditor20250429? value)
    {
        value = this.Value as BetaToolTextEditor20250429;
        return value != null;
    }

    public bool TryPickTextEditor20250728([NotNullWhen(true)] out BetaToolTextEditor20250728? value)
    {
        value = this.Value as BetaToolTextEditor20250728;
        return value != null;
    }

    public bool TryPickWebSearchTool20250305(
        [NotNullWhen(true)] out BetaWebSearchTool20250305? value
    )
    {
        value = this.Value as BetaWebSearchTool20250305;
        return value != null;
    }

    public bool TryPickWebFetchTool20250910([NotNullWhen(true)] out BetaWebFetchTool20250910? value)
    {
        value = this.Value as BetaWebFetchTool20250910;
        return value != null;
    }

    public void Switch(
        System::Action<BetaTool> betaTool,
        System::Action<BetaToolBash20241022> bash20241022,
        System::Action<BetaToolBash20250124> bash20250124,
        System::Action<BetaCodeExecutionTool20250522> codeExecutionTool20250522,
        System::Action<BetaCodeExecutionTool20250825> codeExecutionTool20250825,
        System::Action<BetaToolComputerUse20241022> computerUse20241022,
        System::Action<BetaMemoryTool20250818> memoryTool20250818,
        System::Action<BetaToolComputerUse20250124> computerUse20250124,
        System::Action<BetaToolTextEditor20241022> textEditor20241022,
        System::Action<BetaToolTextEditor20250124> textEditor20250124,
        System::Action<BetaToolTextEditor20250429> textEditor20250429,
        System::Action<BetaToolTextEditor20250728> textEditor20250728,
        System::Action<BetaWebSearchTool20250305> webSearchTool20250305,
        System::Action<BetaWebFetchTool20250910> webFetchTool20250910
    )
    {
        switch (this.Value)
        {
            case BetaTool value:
                betaTool(value);
                break;
            case BetaToolBash20241022 value:
                bash20241022(value);
                break;
            case BetaToolBash20250124 value:
                bash20250124(value);
                break;
            case BetaCodeExecutionTool20250522 value:
                codeExecutionTool20250522(value);
                break;
            case BetaCodeExecutionTool20250825 value:
                codeExecutionTool20250825(value);
                break;
            case BetaToolComputerUse20241022 value:
                computerUse20241022(value);
                break;
            case BetaMemoryTool20250818 value:
                memoryTool20250818(value);
                break;
            case BetaToolComputerUse20250124 value:
                computerUse20250124(value);
                break;
            case BetaToolTextEditor20241022 value:
                textEditor20241022(value);
                break;
            case BetaToolTextEditor20250124 value:
                textEditor20250124(value);
                break;
            case BetaToolTextEditor20250429 value:
                textEditor20250429(value);
                break;
            case BetaToolTextEditor20250728 value:
                textEditor20250728(value);
                break;
            case BetaWebSearchTool20250305 value:
                webSearchTool20250305(value);
                break;
            case BetaWebFetchTool20250910 value:
                webFetchTool20250910(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaToolUnion"
                );
        }
    }

    public T Match<T>(
        System::Func<BetaTool, T> betaTool,
        System::Func<BetaToolBash20241022, T> bash20241022,
        System::Func<BetaToolBash20250124, T> bash20250124,
        System::Func<BetaCodeExecutionTool20250522, T> codeExecutionTool20250522,
        System::Func<BetaCodeExecutionTool20250825, T> codeExecutionTool20250825,
        System::Func<BetaToolComputerUse20241022, T> computerUse20241022,
        System::Func<BetaMemoryTool20250818, T> memoryTool20250818,
        System::Func<BetaToolComputerUse20250124, T> computerUse20250124,
        System::Func<BetaToolTextEditor20241022, T> textEditor20241022,
        System::Func<BetaToolTextEditor20250124, T> textEditor20250124,
        System::Func<BetaToolTextEditor20250429, T> textEditor20250429,
        System::Func<BetaToolTextEditor20250728, T> textEditor20250728,
        System::Func<BetaWebSearchTool20250305, T> webSearchTool20250305,
        System::Func<BetaWebFetchTool20250910, T> webFetchTool20250910
    )
    {
        return this.Value switch
        {
            BetaTool value => betaTool(value),
            BetaToolBash20241022 value => bash20241022(value),
            BetaToolBash20250124 value => bash20250124(value),
            BetaCodeExecutionTool20250522 value => codeExecutionTool20250522(value),
            BetaCodeExecutionTool20250825 value => codeExecutionTool20250825(value),
            BetaToolComputerUse20241022 value => computerUse20241022(value),
            BetaMemoryTool20250818 value => memoryTool20250818(value),
            BetaToolComputerUse20250124 value => computerUse20250124(value),
            BetaToolTextEditor20241022 value => textEditor20241022(value),
            BetaToolTextEditor20250124 value => textEditor20250124(value),
            BetaToolTextEditor20250429 value => textEditor20250429(value),
            BetaToolTextEditor20250728 value => textEditor20250728(value),
            BetaWebSearchTool20250305 value => webSearchTool20250305(value),
            BetaWebFetchTool20250910 value => webFetchTool20250910(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaToolUnion"
            ),
        };
    }

    public static implicit operator BetaToolUnion(BetaTool value) => new(value);

    public static implicit operator BetaToolUnion(BetaToolBash20241022 value) => new(value);

    public static implicit operator BetaToolUnion(BetaToolBash20250124 value) => new(value);

    public static implicit operator BetaToolUnion(BetaCodeExecutionTool20250522 value) =>
        new(value);

    public static implicit operator BetaToolUnion(BetaCodeExecutionTool20250825 value) =>
        new(value);

    public static implicit operator BetaToolUnion(BetaToolComputerUse20241022 value) => new(value);

    public static implicit operator BetaToolUnion(BetaMemoryTool20250818 value) => new(value);

    public static implicit operator BetaToolUnion(BetaToolComputerUse20250124 value) => new(value);

    public static implicit operator BetaToolUnion(BetaToolTextEditor20241022 value) => new(value);

    public static implicit operator BetaToolUnion(BetaToolTextEditor20250124 value) => new(value);

    public static implicit operator BetaToolUnion(BetaToolTextEditor20250429 value) => new(value);

    public static implicit operator BetaToolUnion(BetaToolTextEditor20250728 value) => new(value);

    public static implicit operator BetaToolUnion(BetaWebSearchTool20250305 value) => new(value);

    public static implicit operator BetaToolUnion(BetaWebFetchTool20250910 value) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaToolUnion"
            );
        }
    }
}

sealed class BetaToolUnionConverter : JsonConverter<BetaToolUnion>
{
    public override BetaToolUnion? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaTool>(json, options);
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
            var deserialized = JsonSerializer.Deserialize<BetaToolBash20241022>(json, options);
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
            var deserialized = JsonSerializer.Deserialize<BetaToolBash20250124>(json, options);
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
            var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionTool20250522>(
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
            var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionTool20250825>(
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
            var deserialized = JsonSerializer.Deserialize<BetaToolComputerUse20241022>(
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
            var deserialized = JsonSerializer.Deserialize<BetaMemoryTool20250818>(json, options);
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
            var deserialized = JsonSerializer.Deserialize<BetaToolComputerUse20250124>(
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
            var deserialized = JsonSerializer.Deserialize<BetaToolTextEditor20241022>(
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
            var deserialized = JsonSerializer.Deserialize<BetaToolTextEditor20250124>(
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
            var deserialized = JsonSerializer.Deserialize<BetaToolTextEditor20250429>(
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
            var deserialized = JsonSerializer.Deserialize<BetaToolTextEditor20250728>(
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
            var deserialized = JsonSerializer.Deserialize<BetaWebSearchTool20250305>(json, options);
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
            var deserialized = JsonSerializer.Deserialize<BetaWebFetchTool20250910>(json, options);
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
        BetaToolUnion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
