using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages.MessageCountTokensParamsProperties;

[JsonConverter(typeof(ToolConverter))]
public record class Tool
{
    public object Value { get; private init; }

    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            return Match<BetaCacheControlEphemeral?>(
                beta: (x) => x.CacheControl,
                betaToolBash20241022: (x) => x.CacheControl,
                betaToolBash20250124: (x) => x.CacheControl,
                betaCodeExecutionTool20250522: (x) => x.CacheControl,
                betaCodeExecutionTool20250825: (x) => x.CacheControl,
                betaToolComputerUse20241022: (x) => x.CacheControl,
                betaMemoryTool20250818: (x) => x.CacheControl,
                betaToolComputerUse20250124: (x) => x.CacheControl,
                betaToolTextEditor20241022: (x) => x.CacheControl,
                betaToolTextEditor20250124: (x) => x.CacheControl,
                betaToolTextEditor20250429: (x) => x.CacheControl,
                betaToolTextEditor20250728: (x) => x.CacheControl,
                betaWebSearchTool20250305: (x) => x.CacheControl,
                betaWebFetchTool20250910: (x) => x.CacheControl
            );
        }
    }

    public long? DisplayHeightPx
    {
        get
        {
            return Match<long?>(
                beta: (_) => null,
                betaToolBash20241022: (_) => null,
                betaToolBash20250124: (_) => null,
                betaCodeExecutionTool20250522: (_) => null,
                betaCodeExecutionTool20250825: (_) => null,
                betaToolComputerUse20241022: (x) => x.DisplayHeightPx,
                betaMemoryTool20250818: (_) => null,
                betaToolComputerUse20250124: (x) => x.DisplayHeightPx,
                betaToolTextEditor20241022: (_) => null,
                betaToolTextEditor20250124: (_) => null,
                betaToolTextEditor20250429: (_) => null,
                betaToolTextEditor20250728: (_) => null,
                betaWebSearchTool20250305: (_) => null,
                betaWebFetchTool20250910: (_) => null
            );
        }
    }

    public long? DisplayWidthPx
    {
        get
        {
            return Match<long?>(
                beta: (_) => null,
                betaToolBash20241022: (_) => null,
                betaToolBash20250124: (_) => null,
                betaCodeExecutionTool20250522: (_) => null,
                betaCodeExecutionTool20250825: (_) => null,
                betaToolComputerUse20241022: (x) => x.DisplayWidthPx,
                betaMemoryTool20250818: (_) => null,
                betaToolComputerUse20250124: (x) => x.DisplayWidthPx,
                betaToolTextEditor20241022: (_) => null,
                betaToolTextEditor20250124: (_) => null,
                betaToolTextEditor20250429: (_) => null,
                betaToolTextEditor20250728: (_) => null,
                betaWebSearchTool20250305: (_) => null,
                betaWebFetchTool20250910: (_) => null
            );
        }
    }

    public long? DisplayNumber
    {
        get
        {
            return Match<long?>(
                beta: (_) => null,
                betaToolBash20241022: (_) => null,
                betaToolBash20250124: (_) => null,
                betaCodeExecutionTool20250522: (_) => null,
                betaCodeExecutionTool20250825: (_) => null,
                betaToolComputerUse20241022: (x) => x.DisplayNumber,
                betaMemoryTool20250818: (_) => null,
                betaToolComputerUse20250124: (x) => x.DisplayNumber,
                betaToolTextEditor20241022: (_) => null,
                betaToolTextEditor20250124: (_) => null,
                betaToolTextEditor20250429: (_) => null,
                betaToolTextEditor20250728: (_) => null,
                betaWebSearchTool20250305: (_) => null,
                betaWebFetchTool20250910: (_) => null
            );
        }
    }

    public long? MaxUses
    {
        get
        {
            return Match<long?>(
                beta: (_) => null,
                betaToolBash20241022: (_) => null,
                betaToolBash20250124: (_) => null,
                betaCodeExecutionTool20250522: (_) => null,
                betaCodeExecutionTool20250825: (_) => null,
                betaToolComputerUse20241022: (_) => null,
                betaMemoryTool20250818: (_) => null,
                betaToolComputerUse20250124: (_) => null,
                betaToolTextEditor20241022: (_) => null,
                betaToolTextEditor20250124: (_) => null,
                betaToolTextEditor20250429: (_) => null,
                betaToolTextEditor20250728: (_) => null,
                betaWebSearchTool20250305: (x) => x.MaxUses,
                betaWebFetchTool20250910: (x) => x.MaxUses
            );
        }
    }

    public Tool(BetaTool value)
    {
        Value = value;
    }

    public Tool(BetaToolBash20241022 value)
    {
        Value = value;
    }

    public Tool(BetaToolBash20250124 value)
    {
        Value = value;
    }

    public Tool(BetaCodeExecutionTool20250522 value)
    {
        Value = value;
    }

    public Tool(BetaCodeExecutionTool20250825 value)
    {
        Value = value;
    }

    public Tool(BetaToolComputerUse20241022 value)
    {
        Value = value;
    }

    public Tool(BetaMemoryTool20250818 value)
    {
        Value = value;
    }

    public Tool(BetaToolComputerUse20250124 value)
    {
        Value = value;
    }

    public Tool(BetaToolTextEditor20241022 value)
    {
        Value = value;
    }

    public Tool(BetaToolTextEditor20250124 value)
    {
        Value = value;
    }

    public Tool(BetaToolTextEditor20250429 value)
    {
        Value = value;
    }

    public Tool(BetaToolTextEditor20250728 value)
    {
        Value = value;
    }

    public Tool(BetaWebSearchTool20250305 value)
    {
        Value = value;
    }

    public Tool(BetaWebFetchTool20250910 value)
    {
        Value = value;
    }

    Tool(UnknownVariant value)
    {
        Value = value;
    }

    public static Tool CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickBeta([NotNullWhen(true)] out BetaTool? value)
    {
        value = this.Value as BetaTool;
        return value != null;
    }

    public bool TryPickBetaToolBash20241022([NotNullWhen(true)] out BetaToolBash20241022? value)
    {
        value = this.Value as BetaToolBash20241022;
        return value != null;
    }

    public bool TryPickBetaToolBash20250124([NotNullWhen(true)] out BetaToolBash20250124? value)
    {
        value = this.Value as BetaToolBash20250124;
        return value != null;
    }

    public bool TryPickBetaCodeExecutionTool20250522(
        [NotNullWhen(true)] out BetaCodeExecutionTool20250522? value
    )
    {
        value = this.Value as BetaCodeExecutionTool20250522;
        return value != null;
    }

    public bool TryPickBetaCodeExecutionTool20250825(
        [NotNullWhen(true)] out BetaCodeExecutionTool20250825? value
    )
    {
        value = this.Value as BetaCodeExecutionTool20250825;
        return value != null;
    }

    public bool TryPickBetaToolComputerUse20241022(
        [NotNullWhen(true)] out BetaToolComputerUse20241022? value
    )
    {
        value = this.Value as BetaToolComputerUse20241022;
        return value != null;
    }

    public bool TryPickBetaMemoryTool20250818([NotNullWhen(true)] out BetaMemoryTool20250818? value)
    {
        value = this.Value as BetaMemoryTool20250818;
        return value != null;
    }

    public bool TryPickBetaToolComputerUse20250124(
        [NotNullWhen(true)] out BetaToolComputerUse20250124? value
    )
    {
        value = this.Value as BetaToolComputerUse20250124;
        return value != null;
    }

    public bool TryPickBetaToolTextEditor20241022(
        [NotNullWhen(true)] out BetaToolTextEditor20241022? value
    )
    {
        value = this.Value as BetaToolTextEditor20241022;
        return value != null;
    }

    public bool TryPickBetaToolTextEditor20250124(
        [NotNullWhen(true)] out BetaToolTextEditor20250124? value
    )
    {
        value = this.Value as BetaToolTextEditor20250124;
        return value != null;
    }

    public bool TryPickBetaToolTextEditor20250429(
        [NotNullWhen(true)] out BetaToolTextEditor20250429? value
    )
    {
        value = this.Value as BetaToolTextEditor20250429;
        return value != null;
    }

    public bool TryPickBetaToolTextEditor20250728(
        [NotNullWhen(true)] out BetaToolTextEditor20250728? value
    )
    {
        value = this.Value as BetaToolTextEditor20250728;
        return value != null;
    }

    public bool TryPickBetaWebSearchTool20250305(
        [NotNullWhen(true)] out BetaWebSearchTool20250305? value
    )
    {
        value = this.Value as BetaWebSearchTool20250305;
        return value != null;
    }

    public bool TryPickBetaWebFetchTool20250910(
        [NotNullWhen(true)] out BetaWebFetchTool20250910? value
    )
    {
        value = this.Value as BetaWebFetchTool20250910;
        return value != null;
    }

    public void Switch(
        Action<BetaTool> beta,
        Action<BetaToolBash20241022> betaToolBash20241022,
        Action<BetaToolBash20250124> betaToolBash20250124,
        Action<BetaCodeExecutionTool20250522> betaCodeExecutionTool20250522,
        Action<BetaCodeExecutionTool20250825> betaCodeExecutionTool20250825,
        Action<BetaToolComputerUse20241022> betaToolComputerUse20241022,
        Action<BetaMemoryTool20250818> betaMemoryTool20250818,
        Action<BetaToolComputerUse20250124> betaToolComputerUse20250124,
        Action<BetaToolTextEditor20241022> betaToolTextEditor20241022,
        Action<BetaToolTextEditor20250124> betaToolTextEditor20250124,
        Action<BetaToolTextEditor20250429> betaToolTextEditor20250429,
        Action<BetaToolTextEditor20250728> betaToolTextEditor20250728,
        Action<BetaWebSearchTool20250305> betaWebSearchTool20250305,
        Action<BetaWebFetchTool20250910> betaWebFetchTool20250910
    )
    {
        switch (this.Value)
        {
            case BetaTool value:
                beta(value);
                break;
            case BetaToolBash20241022 value:
                betaToolBash20241022(value);
                break;
            case BetaToolBash20250124 value:
                betaToolBash20250124(value);
                break;
            case BetaCodeExecutionTool20250522 value:
                betaCodeExecutionTool20250522(value);
                break;
            case BetaCodeExecutionTool20250825 value:
                betaCodeExecutionTool20250825(value);
                break;
            case BetaToolComputerUse20241022 value:
                betaToolComputerUse20241022(value);
                break;
            case BetaMemoryTool20250818 value:
                betaMemoryTool20250818(value);
                break;
            case BetaToolComputerUse20250124 value:
                betaToolComputerUse20250124(value);
                break;
            case BetaToolTextEditor20241022 value:
                betaToolTextEditor20241022(value);
                break;
            case BetaToolTextEditor20250124 value:
                betaToolTextEditor20250124(value);
                break;
            case BetaToolTextEditor20250429 value:
                betaToolTextEditor20250429(value);
                break;
            case BetaToolTextEditor20250728 value:
                betaToolTextEditor20250728(value);
                break;
            case BetaWebSearchTool20250305 value:
                betaWebSearchTool20250305(value);
                break;
            case BetaWebFetchTool20250910 value:
                betaWebFetchTool20250910(value);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Tool");
        }
    }

    public T Match<T>(
        Func<BetaTool, T> beta,
        Func<BetaToolBash20241022, T> betaToolBash20241022,
        Func<BetaToolBash20250124, T> betaToolBash20250124,
        Func<BetaCodeExecutionTool20250522, T> betaCodeExecutionTool20250522,
        Func<BetaCodeExecutionTool20250825, T> betaCodeExecutionTool20250825,
        Func<BetaToolComputerUse20241022, T> betaToolComputerUse20241022,
        Func<BetaMemoryTool20250818, T> betaMemoryTool20250818,
        Func<BetaToolComputerUse20250124, T> betaToolComputerUse20250124,
        Func<BetaToolTextEditor20241022, T> betaToolTextEditor20241022,
        Func<BetaToolTextEditor20250124, T> betaToolTextEditor20250124,
        Func<BetaToolTextEditor20250429, T> betaToolTextEditor20250429,
        Func<BetaToolTextEditor20250728, T> betaToolTextEditor20250728,
        Func<BetaWebSearchTool20250305, T> betaWebSearchTool20250305,
        Func<BetaWebFetchTool20250910, T> betaWebFetchTool20250910
    )
    {
        return this.Value switch
        {
            BetaTool value => beta(value),
            BetaToolBash20241022 value => betaToolBash20241022(value),
            BetaToolBash20250124 value => betaToolBash20250124(value),
            BetaCodeExecutionTool20250522 value => betaCodeExecutionTool20250522(value),
            BetaCodeExecutionTool20250825 value => betaCodeExecutionTool20250825(value),
            BetaToolComputerUse20241022 value => betaToolComputerUse20241022(value),
            BetaMemoryTool20250818 value => betaMemoryTool20250818(value),
            BetaToolComputerUse20250124 value => betaToolComputerUse20250124(value),
            BetaToolTextEditor20241022 value => betaToolTextEditor20241022(value),
            BetaToolTextEditor20250124 value => betaToolTextEditor20250124(value),
            BetaToolTextEditor20250429 value => betaToolTextEditor20250429(value),
            BetaToolTextEditor20250728 value => betaToolTextEditor20250728(value),
            BetaWebSearchTool20250305 value => betaWebSearchTool20250305(value),
            BetaWebFetchTool20250910 value => betaWebFetchTool20250910(value),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Tool"),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Tool");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ToolConverter : JsonConverter<Tool>
{
    public override Tool? Read(
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
                return new Tool(deserialized);
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
                return new Tool(deserialized);
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
                return new Tool(deserialized);
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
                return new Tool(deserialized);
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
                return new Tool(deserialized);
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
                return new Tool(deserialized);
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
                return new Tool(deserialized);
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
                return new Tool(deserialized);
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
                return new Tool(deserialized);
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
                return new Tool(deserialized);
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
                return new Tool(deserialized);
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
                return new Tool(deserialized);
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
                return new Tool(deserialized);
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
                return new Tool(deserialized);
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

    public override void Write(Utf8JsonWriter writer, Tool value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
