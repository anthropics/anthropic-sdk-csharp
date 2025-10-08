using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaTextEditorCodeExecutionStrReplaceResultBlock>))]
public sealed record class BetaTextEditorCodeExecutionStrReplaceResultBlock
    : ModelBase,
        IFromRaw<BetaTextEditorCodeExecutionStrReplaceResultBlock>
{
    public required List<string>? Lines
    {
        get
        {
            if (!this.Properties.TryGetValue("lines", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["lines"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long? NewLines
    {
        get
        {
            if (!this.Properties.TryGetValue("new_lines", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["new_lines"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long? NewStart
    {
        get
        {
            if (!this.Properties.TryGetValue("new_start", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["new_start"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long? OldLines
    {
        get
        {
            if (!this.Properties.TryGetValue("old_lines", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["old_lines"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long? OldStart
    {
        get
        {
            if (!this.Properties.TryGetValue("old_start", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["old_start"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Lines ?? [])
        {
            _ = item;
        }
        _ = this.NewLines;
        _ = this.NewStart;
        _ = this.OldLines;
        _ = this.OldStart;
    }

    public BetaTextEditorCodeExecutionStrReplaceResultBlock()
    {
        this.Type = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTextEditorCodeExecutionStrReplaceResultBlock(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaTextEditorCodeExecutionStrReplaceResultBlock FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
