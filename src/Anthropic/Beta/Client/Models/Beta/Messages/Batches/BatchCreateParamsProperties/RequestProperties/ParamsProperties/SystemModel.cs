using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using SystemVariants = Anthropic.Beta.Client.Models.Beta.Messages.Batches.BatchCreateParamsProperties.RequestProperties.ParamsProperties.SystemVariants;

namespace Anthropic.Beta.Client.Models.Beta.Messages.Batches.BatchCreateParamsProperties.RequestProperties.ParamsProperties;

/// <summary>
/// System prompt.
///
/// A system prompt is a way of providing context and instructions to Claude, such
/// as specifying a particular goal or role. See our [guide to system prompts](https://docs.anthropic.com/en/docs/system-prompts).
/// </summary>
[JsonConverter(typeof(SystemModelConverter))]
public abstract record class SystemModel
{
    internal SystemModel() { }

    public static implicit operator SystemModel(string value) => new SystemVariants::String(value);

    public static implicit operator SystemModel(List<BetaTextBlockParam> value) =>
        new SystemVariants::BetaTextBlockParams(value);

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = (this as SystemVariants::String)?.Value;
        return value != null;
    }

    public bool TryPickBetaTextBlockParams([NotNullWhen(true)] out List<BetaTextBlockParam>? value)
    {
        value = (this as SystemVariants::BetaTextBlockParams)?.Value;
        return value != null;
    }

    public void Switch(
        Action<SystemVariants::String> @string,
        Action<SystemVariants::BetaTextBlockParams> betaTextBlockParams
    )
    {
        switch (this)
        {
            case SystemVariants::String inner:
                @string(inner);
                break;
            case SystemVariants::BetaTextBlockParams inner:
                betaTextBlockParams(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<SystemVariants::String, T> @string,
        Func<SystemVariants::BetaTextBlockParams, T> betaTextBlockParams
    )
    {
        return this switch
        {
            SystemVariants::String inner => @string(inner),
            SystemVariants::BetaTextBlockParams inner => betaTextBlockParams(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class SystemModelConverter : JsonConverter<SystemModel>
{
    public override SystemModel? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new SystemVariants::String(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<BetaTextBlockParam>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new SystemVariants::BetaTextBlockParams(deserialized);
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
        SystemModel value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            SystemVariants::String(var @string) => @string,
            SystemVariants::BetaTextBlockParams(var betaTextBlockParams) => betaTextBlockParams,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
