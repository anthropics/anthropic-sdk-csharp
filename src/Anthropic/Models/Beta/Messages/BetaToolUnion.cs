using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using BetaToolUnionVariants = Anthropic.Models.Beta.Messages.BetaToolUnionVariants;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaToolUnionConverter))]
public abstract record class BetaToolUnion
{
    internal BetaToolUnion() { }

    public static implicit operator BetaToolUnion(BetaTool value) =>
        new BetaToolUnionVariants::BetaTool(value);

    public static implicit operator BetaToolUnion(BetaToolBash20241022 value) =>
        new BetaToolUnionVariants::BetaToolBash20241022(value);

    public static implicit operator BetaToolUnion(BetaToolBash20250124 value) =>
        new BetaToolUnionVariants::BetaToolBash20250124(value);

    public static implicit operator BetaToolUnion(BetaCodeExecutionTool20250522 value) =>
        new BetaToolUnionVariants::BetaCodeExecutionTool20250522(value);

    public static implicit operator BetaToolUnion(BetaToolComputerUse20241022 value) =>
        new BetaToolUnionVariants::BetaToolComputerUse20241022(value);

    public static implicit operator BetaToolUnion(BetaToolComputerUse20250124 value) =>
        new BetaToolUnionVariants::BetaToolComputerUse20250124(value);

    public static implicit operator BetaToolUnion(BetaToolTextEditor20241022 value) =>
        new BetaToolUnionVariants::BetaToolTextEditor20241022(value);

    public static implicit operator BetaToolUnion(BetaToolTextEditor20250124 value) =>
        new BetaToolUnionVariants::BetaToolTextEditor20250124(value);

    public static implicit operator BetaToolUnion(BetaToolTextEditor20250429 value) =>
        new BetaToolUnionVariants::BetaToolTextEditor20250429(value);

    public static implicit operator BetaToolUnion(BetaToolTextEditor20250728 value) =>
        new BetaToolUnionVariants::BetaToolTextEditor20250728(value);

    public static implicit operator BetaToolUnion(BetaWebSearchTool20250305 value) =>
        new BetaToolUnionVariants::BetaWebSearchTool20250305(value);

    public bool TryPickBetaTool([NotNullWhen(true)] out BetaTool? value)
    {
        value = (this as BetaToolUnionVariants::BetaTool)?.Value;
        return value != null;
    }

    public bool TryPickBash20241022([NotNullWhen(true)] out BetaToolBash20241022? value)
    {
        value = (this as BetaToolUnionVariants::BetaToolBash20241022)?.Value;
        return value != null;
    }

    public bool TryPickBash20250124([NotNullWhen(true)] out BetaToolBash20250124? value)
    {
        value = (this as BetaToolUnionVariants::BetaToolBash20250124)?.Value;
        return value != null;
    }

    public bool TryPickCodeExecutionTool20250522(
        [NotNullWhen(true)] out BetaCodeExecutionTool20250522? value
    )
    {
        value = (this as BetaToolUnionVariants::BetaCodeExecutionTool20250522)?.Value;
        return value != null;
    }

    public bool TryPickComputerUse20241022(
        [NotNullWhen(true)] out BetaToolComputerUse20241022? value
    )
    {
        value = (this as BetaToolUnionVariants::BetaToolComputerUse20241022)?.Value;
        return value != null;
    }

    public bool TryPickComputerUse20250124(
        [NotNullWhen(true)] out BetaToolComputerUse20250124? value
    )
    {
        value = (this as BetaToolUnionVariants::BetaToolComputerUse20250124)?.Value;
        return value != null;
    }

    public bool TryPickTextEditor20241022([NotNullWhen(true)] out BetaToolTextEditor20241022? value)
    {
        value = (this as BetaToolUnionVariants::BetaToolTextEditor20241022)?.Value;
        return value != null;
    }

    public bool TryPickTextEditor20250124([NotNullWhen(true)] out BetaToolTextEditor20250124? value)
    {
        value = (this as BetaToolUnionVariants::BetaToolTextEditor20250124)?.Value;
        return value != null;
    }

    public bool TryPickTextEditor20250429([NotNullWhen(true)] out BetaToolTextEditor20250429? value)
    {
        value = (this as BetaToolUnionVariants::BetaToolTextEditor20250429)?.Value;
        return value != null;
    }

    public bool TryPickTextEditor20250728([NotNullWhen(true)] out BetaToolTextEditor20250728? value)
    {
        value = (this as BetaToolUnionVariants::BetaToolTextEditor20250728)?.Value;
        return value != null;
    }

    public bool TryPickWebSearchTool20250305(
        [NotNullWhen(true)] out BetaWebSearchTool20250305? value
    )
    {
        value = (this as BetaToolUnionVariants::BetaWebSearchTool20250305)?.Value;
        return value != null;
    }

    public void Switch(
        Action<BetaToolUnionVariants::BetaTool> betaTool,
        Action<BetaToolUnionVariants::BetaToolBash20241022> bash20241022,
        Action<BetaToolUnionVariants::BetaToolBash20250124> bash20250124,
        Action<BetaToolUnionVariants::BetaCodeExecutionTool20250522> codeExecutionTool20250522,
        Action<BetaToolUnionVariants::BetaToolComputerUse20241022> computerUse20241022,
        Action<BetaToolUnionVariants::BetaToolComputerUse20250124> computerUse20250124,
        Action<BetaToolUnionVariants::BetaToolTextEditor20241022> textEditor20241022,
        Action<BetaToolUnionVariants::BetaToolTextEditor20250124> textEditor20250124,
        Action<BetaToolUnionVariants::BetaToolTextEditor20250429> textEditor20250429,
        Action<BetaToolUnionVariants::BetaToolTextEditor20250728> textEditor20250728,
        Action<BetaToolUnionVariants::BetaWebSearchTool20250305> webSearchTool20250305
    )
    {
        switch (this)
        {
            case BetaToolUnionVariants::BetaTool inner:
                betaTool(inner);
                break;
            case BetaToolUnionVariants::BetaToolBash20241022 inner:
                bash20241022(inner);
                break;
            case BetaToolUnionVariants::BetaToolBash20250124 inner:
                bash20250124(inner);
                break;
            case BetaToolUnionVariants::BetaCodeExecutionTool20250522 inner:
                codeExecutionTool20250522(inner);
                break;
            case BetaToolUnionVariants::BetaToolComputerUse20241022 inner:
                computerUse20241022(inner);
                break;
            case BetaToolUnionVariants::BetaToolComputerUse20250124 inner:
                computerUse20250124(inner);
                break;
            case BetaToolUnionVariants::BetaToolTextEditor20241022 inner:
                textEditor20241022(inner);
                break;
            case BetaToolUnionVariants::BetaToolTextEditor20250124 inner:
                textEditor20250124(inner);
                break;
            case BetaToolUnionVariants::BetaToolTextEditor20250429 inner:
                textEditor20250429(inner);
                break;
            case BetaToolUnionVariants::BetaToolTextEditor20250728 inner:
                textEditor20250728(inner);
                break;
            case BetaToolUnionVariants::BetaWebSearchTool20250305 inner:
                webSearchTool20250305(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<BetaToolUnionVariants::BetaTool, T> betaTool,
        Func<BetaToolUnionVariants::BetaToolBash20241022, T> bash20241022,
        Func<BetaToolUnionVariants::BetaToolBash20250124, T> bash20250124,
        Func<BetaToolUnionVariants::BetaCodeExecutionTool20250522, T> codeExecutionTool20250522,
        Func<BetaToolUnionVariants::BetaToolComputerUse20241022, T> computerUse20241022,
        Func<BetaToolUnionVariants::BetaToolComputerUse20250124, T> computerUse20250124,
        Func<BetaToolUnionVariants::BetaToolTextEditor20241022, T> textEditor20241022,
        Func<BetaToolUnionVariants::BetaToolTextEditor20250124, T> textEditor20250124,
        Func<BetaToolUnionVariants::BetaToolTextEditor20250429, T> textEditor20250429,
        Func<BetaToolUnionVariants::BetaToolTextEditor20250728, T> textEditor20250728,
        Func<BetaToolUnionVariants::BetaWebSearchTool20250305, T> webSearchTool20250305
    )
    {
        return this switch
        {
            BetaToolUnionVariants::BetaTool inner => betaTool(inner),
            BetaToolUnionVariants::BetaToolBash20241022 inner => bash20241022(inner),
            BetaToolUnionVariants::BetaToolBash20250124 inner => bash20250124(inner),
            BetaToolUnionVariants::BetaCodeExecutionTool20250522 inner => codeExecutionTool20250522(
                inner
            ),
            BetaToolUnionVariants::BetaToolComputerUse20241022 inner => computerUse20241022(inner),
            BetaToolUnionVariants::BetaToolComputerUse20250124 inner => computerUse20250124(inner),
            BetaToolUnionVariants::BetaToolTextEditor20241022 inner => textEditor20241022(inner),
            BetaToolUnionVariants::BetaToolTextEditor20250124 inner => textEditor20250124(inner),
            BetaToolUnionVariants::BetaToolTextEditor20250429 inner => textEditor20250429(inner),
            BetaToolUnionVariants::BetaToolTextEditor20250728 inner => textEditor20250728(inner),
            BetaToolUnionVariants::BetaWebSearchTool20250305 inner => webSearchTool20250305(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class BetaToolUnionConverter : JsonConverter<BetaToolUnion>
{
    public override BetaToolUnion? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaTool>(ref reader, options);
            if (deserialized != null)
            {
                return new BetaToolUnionVariants::BetaTool(deserialized);
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
                return new BetaToolUnionVariants::BetaToolBash20241022(deserialized);
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
                return new BetaToolUnionVariants::BetaToolBash20250124(deserialized);
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
                return new BetaToolUnionVariants::BetaCodeExecutionTool20250522(deserialized);
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
                return new BetaToolUnionVariants::BetaToolComputerUse20241022(deserialized);
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
                return new BetaToolUnionVariants::BetaToolComputerUse20250124(deserialized);
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
                return new BetaToolUnionVariants::BetaToolTextEditor20241022(deserialized);
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
                return new BetaToolUnionVariants::BetaToolTextEditor20250124(deserialized);
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
                return new BetaToolUnionVariants::BetaToolTextEditor20250429(deserialized);
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
                return new BetaToolUnionVariants::BetaToolTextEditor20250728(deserialized);
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
                return new BetaToolUnionVariants::BetaWebSearchTool20250305(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaToolUnion value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            BetaToolUnionVariants::BetaTool(var betaTool) => betaTool,
            BetaToolUnionVariants::BetaToolBash20241022(var bash20241022) => bash20241022,
            BetaToolUnionVariants::BetaToolBash20250124(var bash20250124) => bash20250124,
            BetaToolUnionVariants::BetaCodeExecutionTool20250522(var codeExecutionTool20250522) =>
                codeExecutionTool20250522,
            BetaToolUnionVariants::BetaToolComputerUse20241022(var computerUse20241022) =>
                computerUse20241022,
            BetaToolUnionVariants::BetaToolComputerUse20250124(var computerUse20250124) =>
                computerUse20250124,
            BetaToolUnionVariants::BetaToolTextEditor20241022(var textEditor20241022) =>
                textEditor20241022,
            BetaToolUnionVariants::BetaToolTextEditor20250124(var textEditor20250124) =>
                textEditor20250124,
            BetaToolUnionVariants::BetaToolTextEditor20250429(var textEditor20250429) =>
                textEditor20250429,
            BetaToolUnionVariants::BetaToolTextEditor20250728(var textEditor20250728) =>
                textEditor20250728,
            BetaToolUnionVariants::BetaWebSearchTool20250305(var webSearchTool20250305) =>
                webSearchTool20250305,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
