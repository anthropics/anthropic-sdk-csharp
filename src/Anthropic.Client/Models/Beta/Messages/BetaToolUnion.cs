using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(BetaToolUnionConverter))]
public record class BetaToolUnion
{
    public object Value { get; private init; }

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

    public BetaToolUnion(BetaTool value)
    {
        Value = value;
    }

    public BetaToolUnion(BetaToolBash20241022 value)
    {
        Value = value;
    }

    public BetaToolUnion(BetaToolBash20250124 value)
    {
        Value = value;
    }

    public BetaToolUnion(BetaCodeExecutionTool20250522 value)
    {
        Value = value;
    }

    public BetaToolUnion(BetaCodeExecutionTool20250825 value)
    {
        Value = value;
    }

    public BetaToolUnion(BetaToolComputerUse20241022 value)
    {
        Value = value;
    }

    public BetaToolUnion(BetaMemoryTool20250818 value)
    {
        Value = value;
    }

    public BetaToolUnion(BetaToolComputerUse20250124 value)
    {
        Value = value;
    }

    public BetaToolUnion(BetaToolTextEditor20241022 value)
    {
        Value = value;
    }

    public BetaToolUnion(BetaToolTextEditor20250124 value)
    {
        Value = value;
    }

    public BetaToolUnion(BetaToolTextEditor20250429 value)
    {
        Value = value;
    }

    public BetaToolUnion(BetaToolTextEditor20250728 value)
    {
        Value = value;
    }

    public BetaToolUnion(BetaWebSearchTool20250305 value)
    {
        Value = value;
    }

    public BetaToolUnion(BetaWebFetchTool20250910 value)
    {
        Value = value;
    }

    BetaToolUnion(UnknownVariant value)
    {
        Value = value;
    }

    public static BetaToolUnion CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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
        Action<BetaTool> betaTool,
        Action<BetaToolBash20241022> bash20241022,
        Action<BetaToolBash20250124> bash20250124,
        Action<BetaCodeExecutionTool20250522> codeExecutionTool20250522,
        Action<BetaCodeExecutionTool20250825> codeExecutionTool20250825,
        Action<BetaToolComputerUse20241022> computerUse20241022,
        Action<BetaMemoryTool20250818> memoryTool20250818,
        Action<BetaToolComputerUse20250124> computerUse20250124,
        Action<BetaToolTextEditor20241022> textEditor20241022,
        Action<BetaToolTextEditor20250124> textEditor20250124,
        Action<BetaToolTextEditor20250429> textEditor20250429,
        Action<BetaToolTextEditor20250728> textEditor20250728,
        Action<BetaWebSearchTool20250305> webSearchTool20250305,
        Action<BetaWebFetchTool20250910> webFetchTool20250910
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
        Func<BetaTool, T> betaTool,
        Func<BetaToolBash20241022, T> bash20241022,
        Func<BetaToolBash20250124, T> bash20250124,
        Func<BetaCodeExecutionTool20250522, T> codeExecutionTool20250522,
        Func<BetaCodeExecutionTool20250825, T> codeExecutionTool20250825,
        Func<BetaToolComputerUse20241022, T> computerUse20241022,
        Func<BetaMemoryTool20250818, T> memoryTool20250818,
        Func<BetaToolComputerUse20250124, T> computerUse20250124,
        Func<BetaToolTextEditor20241022, T> textEditor20241022,
        Func<BetaToolTextEditor20250124, T> textEditor20250124,
        Func<BetaToolTextEditor20250429, T> textEditor20250429,
        Func<BetaToolTextEditor20250728, T> textEditor20250728,
        Func<BetaWebSearchTool20250305, T> webSearchTool20250305,
        Func<BetaWebFetchTool20250910, T> webFetchTool20250910
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

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaToolUnion"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class BetaToolUnionConverter : JsonConverter<BetaToolUnion>
{
    public override BetaToolUnion? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<AnthropicInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaTool>(ref reader, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new BetaToolUnion(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException("Data does not match union variant 'BetaTool'", e)
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolBash20241022>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new BetaToolUnion(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaToolBash20241022'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolBash20250124>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new BetaToolUnion(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaToolBash20250124'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionTool20250522>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new BetaToolUnion(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaCodeExecutionTool20250522'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionTool20250825>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new BetaToolUnion(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaCodeExecutionTool20250825'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolComputerUse20241022>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new BetaToolUnion(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaToolComputerUse20241022'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaMemoryTool20250818>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new BetaToolUnion(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaMemoryTool20250818'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolComputerUse20250124>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new BetaToolUnion(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaToolComputerUse20250124'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolTextEditor20241022>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new BetaToolUnion(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaToolTextEditor20241022'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolTextEditor20250124>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new BetaToolUnion(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaToolTextEditor20250124'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolTextEditor20250429>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new BetaToolUnion(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaToolTextEditor20250429'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolTextEditor20250728>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new BetaToolUnion(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaToolTextEditor20250728'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaWebSearchTool20250305>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new BetaToolUnion(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaWebSearchTool20250305'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaWebFetchTool20250910>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new BetaToolUnion(deserialized);
            }
        }
        catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaWebFetchTool20250910'",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaToolUnion value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
