using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BetaToolChoiceVariants = Anthropic.Models.Beta.Messages.BetaToolChoiceVariants;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// How the model should use the provided tools. The model can use a specific tool,
/// any available tool, decide by itself, or not use tools at all.
/// </summary>
[JsonConverter(typeof(BetaToolChoiceConverter))]
public abstract record class BetaToolChoice
{
    internal BetaToolChoice() { }

    public static implicit operator BetaToolChoice(BetaToolChoiceAuto value) =>
        new BetaToolChoiceVariants::BetaToolChoiceAutoVariant(value);

    public static implicit operator BetaToolChoice(BetaToolChoiceAny value) =>
        new BetaToolChoiceVariants::BetaToolChoiceAnyVariant(value);

    public static implicit operator BetaToolChoice(BetaToolChoiceTool value) =>
        new BetaToolChoiceVariants::BetaToolChoiceToolVariant(value);

    public static implicit operator BetaToolChoice(BetaToolChoiceNone value) =>
        new BetaToolChoiceVariants::BetaToolChoiceNoneVariant(value);

    public abstract void Validate();
}

sealed class BetaToolChoiceConverter : JsonConverter<BetaToolChoice>
{
    public override BetaToolChoice? Read(
        ref Utf8JsonReader reader,
        global::System.Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = json.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "auto":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaToolChoiceAuto>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaToolChoiceVariants::BetaToolChoiceAutoVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
            }
            case "any":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaToolChoiceAny>(json, options);
                    if (deserialized != null)
                    {
                        return new BetaToolChoiceVariants::BetaToolChoiceAnyVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
            }
            case "tool":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaToolChoiceTool>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaToolChoiceVariants::BetaToolChoiceToolVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
            }
            case "none":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaToolChoiceNone>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaToolChoiceVariants::BetaToolChoiceNoneVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
            }
            default:
            {
                throw new global::System.Exception();
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaToolChoice value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            BetaToolChoiceVariants::BetaToolChoiceAutoVariant(var betaToolChoiceAuto) =>
                betaToolChoiceAuto,
            BetaToolChoiceVariants::BetaToolChoiceAnyVariant(var betaToolChoiceAny) =>
                betaToolChoiceAny,
            BetaToolChoiceVariants::BetaToolChoiceToolVariant(var betaToolChoiceTool) =>
                betaToolChoiceTool,
            BetaToolChoiceVariants::BetaToolChoiceNoneVariant(var betaToolChoiceNone) =>
                betaToolChoiceNone,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
