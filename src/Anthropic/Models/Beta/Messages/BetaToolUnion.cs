using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BetaToolUnionVariants = Anthropic.Models.Beta.Messages.BetaToolUnionVariants;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaToolUnionConverter))]
public abstract record class BetaToolUnion
{
    internal BetaToolUnion() { }

    public static implicit operator BetaToolUnion(BetaTool value) =>
        new BetaToolUnionVariants::BetaToolVariant(value);

    public static implicit operator BetaToolUnion(BetaToolBash20241022 value) =>
        new BetaToolUnionVariants::BetaToolBash20241022Variant(value);

    public static implicit operator BetaToolUnion(BetaToolBash20250124 value) =>
        new BetaToolUnionVariants::BetaToolBash20250124Variant(value);

    public static implicit operator BetaToolUnion(BetaCodeExecutionTool20250522 value) =>
        new BetaToolUnionVariants::BetaCodeExecutionTool20250522Variant(value);

    public static implicit operator BetaToolUnion(BetaToolComputerUse20241022 value) =>
        new BetaToolUnionVariants::BetaToolComputerUse20241022Variant(value);

    public static implicit operator BetaToolUnion(BetaToolComputerUse20250124 value) =>
        new BetaToolUnionVariants::BetaToolComputerUse20250124Variant(value);

    public static implicit operator BetaToolUnion(BetaToolTextEditor20241022 value) =>
        new BetaToolUnionVariants::BetaToolTextEditor20241022Variant(value);

    public static implicit operator BetaToolUnion(BetaToolTextEditor20250124 value) =>
        new BetaToolUnionVariants::BetaToolTextEditor20250124Variant(value);

    public static implicit operator BetaToolUnion(BetaToolTextEditor20250429 value) =>
        new BetaToolUnionVariants::BetaToolTextEditor20250429Variant(value);

    public static implicit operator BetaToolUnion(BetaToolTextEditor20250728 value) =>
        new BetaToolUnionVariants::BetaToolTextEditor20250728Variant(value);

    public static implicit operator BetaToolUnion(BetaWebSearchTool20250305 value) =>
        new BetaToolUnionVariants::BetaWebSearchTool20250305Variant(value);

    public abstract void Validate();
}

sealed class BetaToolUnionConverter : JsonConverter<BetaToolUnion>
{
    public override BetaToolUnion? Read(
        ref Utf8JsonReader reader,
        global::System.Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaTool>(ref reader, options);
            if (deserialized != null)
            {
                return new BetaToolUnionVariants::BetaToolVariant(deserialized);
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
                return new BetaToolUnionVariants::BetaToolBash20241022Variant(deserialized);
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
                return new BetaToolUnionVariants::BetaToolBash20250124Variant(deserialized);
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
                return new BetaToolUnionVariants::BetaCodeExecutionTool20250522Variant(
                    deserialized
                );
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
                return new BetaToolUnionVariants::BetaToolComputerUse20241022Variant(deserialized);
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
                return new BetaToolUnionVariants::BetaToolComputerUse20250124Variant(deserialized);
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
                return new BetaToolUnionVariants::BetaToolTextEditor20241022Variant(deserialized);
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
                return new BetaToolUnionVariants::BetaToolTextEditor20250124Variant(deserialized);
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
                return new BetaToolUnionVariants::BetaToolTextEditor20250429Variant(deserialized);
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
                return new BetaToolUnionVariants::BetaToolTextEditor20250728Variant(deserialized);
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
                return new BetaToolUnionVariants::BetaWebSearchTool20250305Variant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new global::System.AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaToolUnion value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            BetaToolUnionVariants::BetaToolVariant(var betaTool) => betaTool,
            BetaToolUnionVariants::BetaToolBash20241022Variant(var betaToolBash20241022) =>
                betaToolBash20241022,
            BetaToolUnionVariants::BetaToolBash20250124Variant(var betaToolBash20250124) =>
                betaToolBash20250124,
            BetaToolUnionVariants::BetaCodeExecutionTool20250522Variant(
                var betaCodeExecutionTool20250522
            ) => betaCodeExecutionTool20250522,
            BetaToolUnionVariants::BetaToolComputerUse20241022Variant(
                var betaToolComputerUse20241022
            ) => betaToolComputerUse20241022,
            BetaToolUnionVariants::BetaToolComputerUse20250124Variant(
                var betaToolComputerUse20250124
            ) => betaToolComputerUse20250124,
            BetaToolUnionVariants::BetaToolTextEditor20241022Variant(
                var betaToolTextEditor20241022
            ) => betaToolTextEditor20241022,
            BetaToolUnionVariants::BetaToolTextEditor20250124Variant(
                var betaToolTextEditor20250124
            ) => betaToolTextEditor20250124,
            BetaToolUnionVariants::BetaToolTextEditor20250429Variant(
                var betaToolTextEditor20250429
            ) => betaToolTextEditor20250429,
            BetaToolUnionVariants::BetaToolTextEditor20250728Variant(
                var betaToolTextEditor20250728
            ) => betaToolTextEditor20250728,
            BetaToolUnionVariants::BetaWebSearchTool20250305Variant(
                var betaWebSearchTool20250305
            ) => betaWebSearchTool20250305,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
