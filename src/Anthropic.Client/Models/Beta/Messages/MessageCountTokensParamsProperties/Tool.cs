using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;
using ToolVariants = Anthropic.Client.Models.Beta.Messages.MessageCountTokensParamsProperties.ToolVariants;

namespace Anthropic.Client.Models.Beta.Messages.MessageCountTokensParamsProperties;

[JsonConverter(typeof(ToolConverter))]
public abstract record class Tool
{
    internal Tool() { }

    public static implicit operator Tool(BetaTool value) => new ToolVariants::BetaTool(value);

    public static implicit operator Tool(BetaToolBash20241022 value) =>
        new ToolVariants::BetaToolBash20241022(value);

    public static implicit operator Tool(BetaToolBash20250124 value) =>
        new ToolVariants::BetaToolBash20250124(value);

    public static implicit operator Tool(BetaCodeExecutionTool20250522 value) =>
        new ToolVariants::BetaCodeExecutionTool20250522(value);

    public static implicit operator Tool(BetaCodeExecutionTool20250825 value) =>
        new ToolVariants::BetaCodeExecutionTool20250825(value);

    public static implicit operator Tool(BetaToolComputerUse20241022 value) =>
        new ToolVariants::BetaToolComputerUse20241022(value);

    public static implicit operator Tool(BetaMemoryTool20250818 value) =>
        new ToolVariants::BetaMemoryTool20250818(value);

    public static implicit operator Tool(BetaToolComputerUse20250124 value) =>
        new ToolVariants::BetaToolComputerUse20250124(value);

    public static implicit operator Tool(BetaToolTextEditor20241022 value) =>
        new ToolVariants::BetaToolTextEditor20241022(value);

    public static implicit operator Tool(BetaToolTextEditor20250124 value) =>
        new ToolVariants::BetaToolTextEditor20250124(value);

    public static implicit operator Tool(BetaToolTextEditor20250429 value) =>
        new ToolVariants::BetaToolTextEditor20250429(value);

    public static implicit operator Tool(BetaToolTextEditor20250728 value) =>
        new ToolVariants::BetaToolTextEditor20250728(value);

    public static implicit operator Tool(BetaWebSearchTool20250305 value) =>
        new ToolVariants::BetaWebSearchTool20250305(value);

    public static implicit operator Tool(BetaWebFetchTool20250910 value) =>
        new ToolVariants::BetaWebFetchTool20250910(value);

    public bool TryPickBeta([NotNullWhen(true)] out BetaTool? value)
    {
        value = (this as ToolVariants::BetaTool)?.Value;
        return value != null;
    }

    public bool TryPickBetaToolBash20241022([NotNullWhen(true)] out BetaToolBash20241022? value)
    {
        value = (this as ToolVariants::BetaToolBash20241022)?.Value;
        return value != null;
    }

    public bool TryPickBetaToolBash20250124([NotNullWhen(true)] out BetaToolBash20250124? value)
    {
        value = (this as ToolVariants::BetaToolBash20250124)?.Value;
        return value != null;
    }

    public bool TryPickBetaCodeExecutionTool20250522(
        [NotNullWhen(true)] out BetaCodeExecutionTool20250522? value
    )
    {
        value = (this as ToolVariants::BetaCodeExecutionTool20250522)?.Value;
        return value != null;
    }

    public bool TryPickBetaCodeExecutionTool20250825(
        [NotNullWhen(true)] out BetaCodeExecutionTool20250825? value
    )
    {
        value = (this as ToolVariants::BetaCodeExecutionTool20250825)?.Value;
        return value != null;
    }

    public bool TryPickBetaToolComputerUse20241022(
        [NotNullWhen(true)] out BetaToolComputerUse20241022? value
    )
    {
        value = (this as ToolVariants::BetaToolComputerUse20241022)?.Value;
        return value != null;
    }

    public bool TryPickBetaMemoryTool20250818([NotNullWhen(true)] out BetaMemoryTool20250818? value)
    {
        value = (this as ToolVariants::BetaMemoryTool20250818)?.Value;
        return value != null;
    }

    public bool TryPickBetaToolComputerUse20250124(
        [NotNullWhen(true)] out BetaToolComputerUse20250124? value
    )
    {
        value = (this as ToolVariants::BetaToolComputerUse20250124)?.Value;
        return value != null;
    }

    public bool TryPickBetaToolTextEditor20241022(
        [NotNullWhen(true)] out BetaToolTextEditor20241022? value
    )
    {
        value = (this as ToolVariants::BetaToolTextEditor20241022)?.Value;
        return value != null;
    }

    public bool TryPickBetaToolTextEditor20250124(
        [NotNullWhen(true)] out BetaToolTextEditor20250124? value
    )
    {
        value = (this as ToolVariants::BetaToolTextEditor20250124)?.Value;
        return value != null;
    }

    public bool TryPickBetaToolTextEditor20250429(
        [NotNullWhen(true)] out BetaToolTextEditor20250429? value
    )
    {
        value = (this as ToolVariants::BetaToolTextEditor20250429)?.Value;
        return value != null;
    }

    public bool TryPickBetaToolTextEditor20250728(
        [NotNullWhen(true)] out BetaToolTextEditor20250728? value
    )
    {
        value = (this as ToolVariants::BetaToolTextEditor20250728)?.Value;
        return value != null;
    }

    public bool TryPickBetaWebSearchTool20250305(
        [NotNullWhen(true)] out BetaWebSearchTool20250305? value
    )
    {
        value = (this as ToolVariants::BetaWebSearchTool20250305)?.Value;
        return value != null;
    }

    public bool TryPickBetaWebFetchTool20250910(
        [NotNullWhen(true)] out BetaWebFetchTool20250910? value
    )
    {
        value = (this as ToolVariants::BetaWebFetchTool20250910)?.Value;
        return value != null;
    }

    public void Switch(
        Action<ToolVariants::BetaTool> beta,
        Action<ToolVariants::BetaToolBash20241022> betaToolBash20241022,
        Action<ToolVariants::BetaToolBash20250124> betaToolBash20250124,
        Action<ToolVariants::BetaCodeExecutionTool20250522> betaCodeExecutionTool20250522,
        Action<ToolVariants::BetaCodeExecutionTool20250825> betaCodeExecutionTool20250825,
        Action<ToolVariants::BetaToolComputerUse20241022> betaToolComputerUse20241022,
        Action<ToolVariants::BetaMemoryTool20250818> betaMemoryTool20250818,
        Action<ToolVariants::BetaToolComputerUse20250124> betaToolComputerUse20250124,
        Action<ToolVariants::BetaToolTextEditor20241022> betaToolTextEditor20241022,
        Action<ToolVariants::BetaToolTextEditor20250124> betaToolTextEditor20250124,
        Action<ToolVariants::BetaToolTextEditor20250429> betaToolTextEditor20250429,
        Action<ToolVariants::BetaToolTextEditor20250728> betaToolTextEditor20250728,
        Action<ToolVariants::BetaWebSearchTool20250305> betaWebSearchTool20250305,
        Action<ToolVariants::BetaWebFetchTool20250910> betaWebFetchTool20250910
    )
    {
        switch (this)
        {
            case ToolVariants::BetaTool inner:
                beta(inner);
                break;
            case ToolVariants::BetaToolBash20241022 inner:
                betaToolBash20241022(inner);
                break;
            case ToolVariants::BetaToolBash20250124 inner:
                betaToolBash20250124(inner);
                break;
            case ToolVariants::BetaCodeExecutionTool20250522 inner:
                betaCodeExecutionTool20250522(inner);
                break;
            case ToolVariants::BetaCodeExecutionTool20250825 inner:
                betaCodeExecutionTool20250825(inner);
                break;
            case ToolVariants::BetaToolComputerUse20241022 inner:
                betaToolComputerUse20241022(inner);
                break;
            case ToolVariants::BetaMemoryTool20250818 inner:
                betaMemoryTool20250818(inner);
                break;
            case ToolVariants::BetaToolComputerUse20250124 inner:
                betaToolComputerUse20250124(inner);
                break;
            case ToolVariants::BetaToolTextEditor20241022 inner:
                betaToolTextEditor20241022(inner);
                break;
            case ToolVariants::BetaToolTextEditor20250124 inner:
                betaToolTextEditor20250124(inner);
                break;
            case ToolVariants::BetaToolTextEditor20250429 inner:
                betaToolTextEditor20250429(inner);
                break;
            case ToolVariants::BetaToolTextEditor20250728 inner:
                betaToolTextEditor20250728(inner);
                break;
            case ToolVariants::BetaWebSearchTool20250305 inner:
                betaWebSearchTool20250305(inner);
                break;
            case ToolVariants::BetaWebFetchTool20250910 inner:
                betaWebFetchTool20250910(inner);
                break;
            default:
                throw new AnthropicInvalidDataException("Data did not match any variant of Tool");
        }
    }

    public T Match<T>(
        Func<ToolVariants::BetaTool, T> beta,
        Func<ToolVariants::BetaToolBash20241022, T> betaToolBash20241022,
        Func<ToolVariants::BetaToolBash20250124, T> betaToolBash20250124,
        Func<ToolVariants::BetaCodeExecutionTool20250522, T> betaCodeExecutionTool20250522,
        Func<ToolVariants::BetaCodeExecutionTool20250825, T> betaCodeExecutionTool20250825,
        Func<ToolVariants::BetaToolComputerUse20241022, T> betaToolComputerUse20241022,
        Func<ToolVariants::BetaMemoryTool20250818, T> betaMemoryTool20250818,
        Func<ToolVariants::BetaToolComputerUse20250124, T> betaToolComputerUse20250124,
        Func<ToolVariants::BetaToolTextEditor20241022, T> betaToolTextEditor20241022,
        Func<ToolVariants::BetaToolTextEditor20250124, T> betaToolTextEditor20250124,
        Func<ToolVariants::BetaToolTextEditor20250429, T> betaToolTextEditor20250429,
        Func<ToolVariants::BetaToolTextEditor20250728, T> betaToolTextEditor20250728,
        Func<ToolVariants::BetaWebSearchTool20250305, T> betaWebSearchTool20250305,
        Func<ToolVariants::BetaWebFetchTool20250910, T> betaWebFetchTool20250910
    )
    {
        return this switch
        {
            ToolVariants::BetaTool inner => beta(inner),
            ToolVariants::BetaToolBash20241022 inner => betaToolBash20241022(inner),
            ToolVariants::BetaToolBash20250124 inner => betaToolBash20250124(inner),
            ToolVariants::BetaCodeExecutionTool20250522 inner => betaCodeExecutionTool20250522(
                inner
            ),
            ToolVariants::BetaCodeExecutionTool20250825 inner => betaCodeExecutionTool20250825(
                inner
            ),
            ToolVariants::BetaToolComputerUse20241022 inner => betaToolComputerUse20241022(inner),
            ToolVariants::BetaMemoryTool20250818 inner => betaMemoryTool20250818(inner),
            ToolVariants::BetaToolComputerUse20250124 inner => betaToolComputerUse20250124(inner),
            ToolVariants::BetaToolTextEditor20241022 inner => betaToolTextEditor20241022(inner),
            ToolVariants::BetaToolTextEditor20250124 inner => betaToolTextEditor20250124(inner),
            ToolVariants::BetaToolTextEditor20250429 inner => betaToolTextEditor20250429(inner),
            ToolVariants::BetaToolTextEditor20250728 inner => betaToolTextEditor20250728(inner),
            ToolVariants::BetaWebSearchTool20250305 inner => betaWebSearchTool20250305(inner),
            ToolVariants::BetaWebFetchTool20250910 inner => betaWebFetchTool20250910(inner),
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Tool"),
        };
    }

    public abstract void Validate();
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
                return new ToolVariants::BetaTool(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant ToolVariants::BetaTool",
                    e
                )
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
                return new ToolVariants::BetaToolBash20241022(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant ToolVariants::BetaToolBash20241022",
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
                return new ToolVariants::BetaToolBash20250124(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant ToolVariants::BetaToolBash20250124",
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
                return new ToolVariants::BetaCodeExecutionTool20250522(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant ToolVariants::BetaCodeExecutionTool20250522",
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
                return new ToolVariants::BetaCodeExecutionTool20250825(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant ToolVariants::BetaCodeExecutionTool20250825",
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
                return new ToolVariants::BetaToolComputerUse20241022(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant ToolVariants::BetaToolComputerUse20241022",
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
                return new ToolVariants::BetaMemoryTool20250818(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant ToolVariants::BetaMemoryTool20250818",
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
                return new ToolVariants::BetaToolComputerUse20250124(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant ToolVariants::BetaToolComputerUse20250124",
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
                return new ToolVariants::BetaToolTextEditor20241022(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant ToolVariants::BetaToolTextEditor20241022",
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
                return new ToolVariants::BetaToolTextEditor20250124(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant ToolVariants::BetaToolTextEditor20250124",
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
                return new ToolVariants::BetaToolTextEditor20250429(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant ToolVariants::BetaToolTextEditor20250429",
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
                return new ToolVariants::BetaToolTextEditor20250728(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant ToolVariants::BetaToolTextEditor20250728",
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
                return new ToolVariants::BetaWebSearchTool20250305(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant ToolVariants::BetaWebSearchTool20250305",
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
                return new ToolVariants::BetaWebFetchTool20250910(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant ToolVariants::BetaWebFetchTool20250910",
                    e
                )
            );
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Tool value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            ToolVariants::BetaTool(var beta) => beta,
            ToolVariants::BetaToolBash20241022(var betaToolBash20241022) => betaToolBash20241022,
            ToolVariants::BetaToolBash20250124(var betaToolBash20250124) => betaToolBash20250124,
            ToolVariants::BetaCodeExecutionTool20250522(var betaCodeExecutionTool20250522) =>
                betaCodeExecutionTool20250522,
            ToolVariants::BetaCodeExecutionTool20250825(var betaCodeExecutionTool20250825) =>
                betaCodeExecutionTool20250825,
            ToolVariants::BetaToolComputerUse20241022(var betaToolComputerUse20241022) =>
                betaToolComputerUse20241022,
            ToolVariants::BetaMemoryTool20250818(var betaMemoryTool20250818) =>
                betaMemoryTool20250818,
            ToolVariants::BetaToolComputerUse20250124(var betaToolComputerUse20250124) =>
                betaToolComputerUse20250124,
            ToolVariants::BetaToolTextEditor20241022(var betaToolTextEditor20241022) =>
                betaToolTextEditor20241022,
            ToolVariants::BetaToolTextEditor20250124(var betaToolTextEditor20250124) =>
                betaToolTextEditor20250124,
            ToolVariants::BetaToolTextEditor20250429(var betaToolTextEditor20250429) =>
                betaToolTextEditor20250429,
            ToolVariants::BetaToolTextEditor20250728(var betaToolTextEditor20250728) =>
                betaToolTextEditor20250728,
            ToolVariants::BetaWebSearchTool20250305(var betaWebSearchTool20250305) =>
                betaWebSearchTool20250305,
            ToolVariants::BetaWebFetchTool20250910(var betaWebFetchTool20250910) =>
                betaWebFetchTool20250910,
            _ => throw new AnthropicInvalidDataException("Data did not match any variant of Tool"),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
