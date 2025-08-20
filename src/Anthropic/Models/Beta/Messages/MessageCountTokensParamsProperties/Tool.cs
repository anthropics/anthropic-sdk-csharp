using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Models.Beta.Messages.MessageCountTokensParamsProperties.ToolVariants;

namespace Anthropic.Models.Beta.Messages.MessageCountTokensParamsProperties;

[JsonConverter(typeof(ToolConverter))]
public abstract record class Tool
{
    internal Tool() { }

    public static implicit operator Tool(BetaTool value) => new BetaToolVariant(value);

    public static implicit operator Tool(BetaToolBash20241022 value) =>
        new BetaToolBash20241022Variant(value);

    public static implicit operator Tool(BetaToolBash20250124 value) =>
        new BetaToolBash20250124Variant(value);

    public static implicit operator Tool(BetaCodeExecutionTool20250522 value) =>
        new BetaCodeExecutionTool20250522Variant(value);

    public static implicit operator Tool(BetaToolComputerUse20241022 value) =>
        new BetaToolComputerUse20241022Variant(value);

    public static implicit operator Tool(BetaToolComputerUse20250124 value) =>
        new BetaToolComputerUse20250124Variant(value);

    public static implicit operator Tool(BetaToolTextEditor20241022 value) =>
        new BetaToolTextEditor20241022Variant(value);

    public static implicit operator Tool(BetaToolTextEditor20250124 value) =>
        new BetaToolTextEditor20250124Variant(value);

    public static implicit operator Tool(BetaToolTextEditor20250429 value) =>
        new BetaToolTextEditor20250429Variant(value);

    public static implicit operator Tool(BetaToolTextEditor20250728 value) =>
        new BetaToolTextEditor20250728Variant(value);

    public static implicit operator Tool(BetaWebSearchTool20250305 value) =>
        new BetaWebSearchTool20250305Variant(value);

    public bool TryPickBetaToolVariant([NotNullWhen(true)] out BetaTool? value)
    {
        value = (this as BetaToolVariant)?.Value;
        return value != null;
    }

    public bool TryPickBetaToolBash20241022Variant(
        [NotNullWhen(true)] out BetaToolBash20241022? value
    )
    {
        value = (this as BetaToolBash20241022Variant)?.Value;
        return value != null;
    }

    public bool TryPickBetaToolBash20250124Variant(
        [NotNullWhen(true)] out BetaToolBash20250124? value
    )
    {
        value = (this as BetaToolBash20250124Variant)?.Value;
        return value != null;
    }

    public bool TryPickBetaCodeExecutionTool20250522Variant(
        [NotNullWhen(true)] out BetaCodeExecutionTool20250522? value
    )
    {
        value = (this as BetaCodeExecutionTool20250522Variant)?.Value;
        return value != null;
    }

    public bool TryPickBetaToolComputerUse20241022Variant(
        [NotNullWhen(true)] out BetaToolComputerUse20241022? value
    )
    {
        value = (this as BetaToolComputerUse20241022Variant)?.Value;
        return value != null;
    }

    public bool TryPickBetaToolComputerUse20250124Variant(
        [NotNullWhen(true)] out BetaToolComputerUse20250124? value
    )
    {
        value = (this as BetaToolComputerUse20250124Variant)?.Value;
        return value != null;
    }

    public bool TryPickBetaToolTextEditor20241022Variant(
        [NotNullWhen(true)] out BetaToolTextEditor20241022? value
    )
    {
        value = (this as BetaToolTextEditor20241022Variant)?.Value;
        return value != null;
    }

    public bool TryPickBetaToolTextEditor20250124Variant(
        [NotNullWhen(true)] out BetaToolTextEditor20250124? value
    )
    {
        value = (this as BetaToolTextEditor20250124Variant)?.Value;
        return value != null;
    }

    public bool TryPickBetaToolTextEditor20250429Variant(
        [NotNullWhen(true)] out BetaToolTextEditor20250429? value
    )
    {
        value = (this as BetaToolTextEditor20250429Variant)?.Value;
        return value != null;
    }

    public bool TryPickBetaToolTextEditor20250728Variant(
        [NotNullWhen(true)] out BetaToolTextEditor20250728? value
    )
    {
        value = (this as BetaToolTextEditor20250728Variant)?.Value;
        return value != null;
    }

    public bool TryPickBetaWebSearchTool20250305Variant(
        [NotNullWhen(true)] out BetaWebSearchTool20250305? value
    )
    {
        value = (this as BetaWebSearchTool20250305Variant)?.Value;
        return value != null;
    }

    public void Switch(
        Action<BetaToolVariant> betaTool,
        Action<BetaToolBash20241022Variant> betaToolBash20241022,
        Action<BetaToolBash20250124Variant> betaToolBash20250124,
        Action<BetaCodeExecutionTool20250522Variant> betaCodeExecutionTool20250522,
        Action<BetaToolComputerUse20241022Variant> betaToolComputerUse20241022,
        Action<BetaToolComputerUse20250124Variant> betaToolComputerUse20250124,
        Action<BetaToolTextEditor20241022Variant> betaToolTextEditor20241022,
        Action<BetaToolTextEditor20250124Variant> betaToolTextEditor20250124,
        Action<BetaToolTextEditor20250429Variant> betaToolTextEditor20250429,
        Action<BetaToolTextEditor20250728Variant> betaToolTextEditor20250728,
        Action<BetaWebSearchTool20250305Variant> betaWebSearchTool20250305
    )
    {
        switch (this)
        {
            case BetaToolVariant inner:
                betaTool(inner);
                break;
            case BetaToolBash20241022Variant inner:
                betaToolBash20241022(inner);
                break;
            case BetaToolBash20250124Variant inner:
                betaToolBash20250124(inner);
                break;
            case BetaCodeExecutionTool20250522Variant inner:
                betaCodeExecutionTool20250522(inner);
                break;
            case BetaToolComputerUse20241022Variant inner:
                betaToolComputerUse20241022(inner);
                break;
            case BetaToolComputerUse20250124Variant inner:
                betaToolComputerUse20250124(inner);
                break;
            case BetaToolTextEditor20241022Variant inner:
                betaToolTextEditor20241022(inner);
                break;
            case BetaToolTextEditor20250124Variant inner:
                betaToolTextEditor20250124(inner);
                break;
            case BetaToolTextEditor20250429Variant inner:
                betaToolTextEditor20250429(inner);
                break;
            case BetaToolTextEditor20250728Variant inner:
                betaToolTextEditor20250728(inner);
                break;
            case BetaWebSearchTool20250305Variant inner:
                betaWebSearchTool20250305(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<BetaToolVariant, T> betaTool,
        Func<BetaToolBash20241022Variant, T> betaToolBash20241022,
        Func<BetaToolBash20250124Variant, T> betaToolBash20250124,
        Func<BetaCodeExecutionTool20250522Variant, T> betaCodeExecutionTool20250522,
        Func<BetaToolComputerUse20241022Variant, T> betaToolComputerUse20241022,
        Func<BetaToolComputerUse20250124Variant, T> betaToolComputerUse20250124,
        Func<BetaToolTextEditor20241022Variant, T> betaToolTextEditor20241022,
        Func<BetaToolTextEditor20250124Variant, T> betaToolTextEditor20250124,
        Func<BetaToolTextEditor20250429Variant, T> betaToolTextEditor20250429,
        Func<BetaToolTextEditor20250728Variant, T> betaToolTextEditor20250728,
        Func<BetaWebSearchTool20250305Variant, T> betaWebSearchTool20250305
    )
    {
        return this switch
        {
            BetaToolVariant inner => betaTool(inner),
            BetaToolBash20241022Variant inner => betaToolBash20241022(inner),
            BetaToolBash20250124Variant inner => betaToolBash20250124(inner),
            BetaCodeExecutionTool20250522Variant inner => betaCodeExecutionTool20250522(inner),
            BetaToolComputerUse20241022Variant inner => betaToolComputerUse20241022(inner),
            BetaToolComputerUse20250124Variant inner => betaToolComputerUse20250124(inner),
            BetaToolTextEditor20241022Variant inner => betaToolTextEditor20241022(inner),
            BetaToolTextEditor20250124Variant inner => betaToolTextEditor20250124(inner),
            BetaToolTextEditor20250429Variant inner => betaToolTextEditor20250429(inner),
            BetaToolTextEditor20250728Variant inner => betaToolTextEditor20250728(inner),
            BetaWebSearchTool20250305Variant inner => betaWebSearchTool20250305(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class ToolConverter : JsonConverter<Tool>
{
    public override Tool? Read(
        ref Utf8JsonReader reader,
        Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaTool>(ref reader, options);
            if (deserialized != null)
            {
                return new BetaToolVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolBash20241022>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaToolBash20241022Variant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolBash20250124>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaToolBash20250124Variant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionTool20250522>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaCodeExecutionTool20250522Variant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolComputerUse20241022>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaToolComputerUse20241022Variant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolComputerUse20250124>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaToolComputerUse20250124Variant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolTextEditor20241022>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaToolTextEditor20241022Variant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolTextEditor20250124>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaToolTextEditor20250124Variant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolTextEditor20250429>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaToolTextEditor20250429Variant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolTextEditor20250728>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaToolTextEditor20250728Variant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaWebSearchTool20250305>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaWebSearchTool20250305Variant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Tool value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            BetaToolVariant(var betaTool) => betaTool,
            BetaToolBash20241022Variant(var betaToolBash20241022) => betaToolBash20241022,
            BetaToolBash20250124Variant(var betaToolBash20250124) => betaToolBash20250124,
            BetaCodeExecutionTool20250522Variant(var betaCodeExecutionTool20250522) =>
                betaCodeExecutionTool20250522,
            BetaToolComputerUse20241022Variant(var betaToolComputerUse20241022) =>
                betaToolComputerUse20241022,
            BetaToolComputerUse20250124Variant(var betaToolComputerUse20250124) =>
                betaToolComputerUse20250124,
            BetaToolTextEditor20241022Variant(var betaToolTextEditor20241022) =>
                betaToolTextEditor20241022,
            BetaToolTextEditor20250124Variant(var betaToolTextEditor20250124) =>
                betaToolTextEditor20250124,
            BetaToolTextEditor20250429Variant(var betaToolTextEditor20250429) =>
                betaToolTextEditor20250429,
            BetaToolTextEditor20250728Variant(var betaToolTextEditor20250728) =>
                betaToolTextEditor20250728,
            BetaWebSearchTool20250305Variant(var betaWebSearchTool20250305) =>
                betaWebSearchTool20250305,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
