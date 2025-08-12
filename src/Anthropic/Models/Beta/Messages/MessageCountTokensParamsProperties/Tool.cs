using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Messages = Anthropic.Models.Beta.Messages;
using ToolVariants = Anthropic.Models.Beta.Messages.MessageCountTokensParamsProperties.ToolVariants;

namespace Anthropic.Models.Beta.Messages.MessageCountTokensParamsProperties;

[JsonConverter(typeof(ToolConverter))]
public abstract record class Tool
{
    internal Tool() { }

    public static implicit operator Tool(Messages::BetaTool value) =>
        new ToolVariants::BetaToolVariant(value);

    public static implicit operator Tool(Messages::BetaToolBash20241022 value) =>
        new ToolVariants::BetaToolBash20241022Variant(value);

    public static implicit operator Tool(Messages::BetaToolBash20250124 value) =>
        new ToolVariants::BetaToolBash20250124Variant(value);

    public static implicit operator Tool(Messages::BetaCodeExecutionTool20250522 value) =>
        new ToolVariants::BetaCodeExecutionTool20250522Variant(value);

    public static implicit operator Tool(Messages::BetaToolComputerUse20241022 value) =>
        new ToolVariants::BetaToolComputerUse20241022Variant(value);

    public static implicit operator Tool(Messages::BetaToolComputerUse20250124 value) =>
        new ToolVariants::BetaToolComputerUse20250124Variant(value);

    public static implicit operator Tool(Messages::BetaToolTextEditor20241022 value) =>
        new ToolVariants::BetaToolTextEditor20241022Variant(value);

    public static implicit operator Tool(Messages::BetaToolTextEditor20250124 value) =>
        new ToolVariants::BetaToolTextEditor20250124Variant(value);

    public static implicit operator Tool(Messages::BetaToolTextEditor20250429 value) =>
        new ToolVariants::BetaToolTextEditor20250429Variant(value);

    public static implicit operator Tool(Messages::BetaToolTextEditor20250728 value) =>
        new ToolVariants::BetaToolTextEditor20250728Variant(value);

    public static implicit operator Tool(Messages::BetaWebSearchTool20250305 value) =>
        new ToolVariants::BetaWebSearchTool20250305Variant(value);

    public abstract void Validate();
}

sealed class ToolConverter : JsonConverter<Tool>
{
    public override Tool? Read(
        ref Utf8JsonReader reader,
        global::System.Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<Messages::BetaTool>(ref reader, options);
            if (deserialized != null)
            {
                return new ToolVariants::BetaToolVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Messages::BetaToolBash20241022>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new ToolVariants::BetaToolBash20241022Variant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Messages::BetaToolBash20250124>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new ToolVariants::BetaToolBash20250124Variant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Messages::BetaCodeExecutionTool20250522>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new ToolVariants::BetaCodeExecutionTool20250522Variant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Messages::BetaToolComputerUse20241022>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new ToolVariants::BetaToolComputerUse20241022Variant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Messages::BetaToolComputerUse20250124>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new ToolVariants::BetaToolComputerUse20250124Variant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Messages::BetaToolTextEditor20241022>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new ToolVariants::BetaToolTextEditor20241022Variant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Messages::BetaToolTextEditor20250124>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new ToolVariants::BetaToolTextEditor20250124Variant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Messages::BetaToolTextEditor20250429>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new ToolVariants::BetaToolTextEditor20250429Variant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Messages::BetaToolTextEditor20250728>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new ToolVariants::BetaToolTextEditor20250728Variant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Messages::BetaWebSearchTool20250305>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new ToolVariants::BetaWebSearchTool20250305Variant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new global::System.AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Tool value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            ToolVariants::BetaToolVariant(var betaTool) => betaTool,
            ToolVariants::BetaToolBash20241022Variant(var betaToolBash20241022) =>
                betaToolBash20241022,
            ToolVariants::BetaToolBash20250124Variant(var betaToolBash20250124) =>
                betaToolBash20250124,
            ToolVariants::BetaCodeExecutionTool20250522Variant(var betaCodeExecutionTool20250522) =>
                betaCodeExecutionTool20250522,
            ToolVariants::BetaToolComputerUse20241022Variant(var betaToolComputerUse20241022) =>
                betaToolComputerUse20241022,
            ToolVariants::BetaToolComputerUse20250124Variant(var betaToolComputerUse20250124) =>
                betaToolComputerUse20250124,
            ToolVariants::BetaToolTextEditor20241022Variant(var betaToolTextEditor20241022) =>
                betaToolTextEditor20241022,
            ToolVariants::BetaToolTextEditor20250124Variant(var betaToolTextEditor20250124) =>
                betaToolTextEditor20250124,
            ToolVariants::BetaToolTextEditor20250429Variant(var betaToolTextEditor20250429) =>
                betaToolTextEditor20250429,
            ToolVariants::BetaToolTextEditor20250728Variant(var betaToolTextEditor20250728) =>
                betaToolTextEditor20250728,
            ToolVariants::BetaWebSearchTool20250305Variant(var betaWebSearchTool20250305) =>
                betaWebSearchTool20250305,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
