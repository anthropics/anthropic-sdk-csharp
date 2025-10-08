using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using Anthropic.Client.Models.Beta.Messages.BetaClearToolUses20250919EditProperties;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaClearToolUses20250919Edit>))]
public sealed record class BetaClearToolUses20250919Edit
    : ModelBase,
        IFromRaw<BetaClearToolUses20250919Edit>
{
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

    /// <summary>
    /// Minimum number of tokens that must be cleared when triggered. Context will
    /// only be modified if at least this many tokens can be removed.
    /// </summary>
    public BetaInputTokensClearAtLeast? ClearAtLeast
    {
        get
        {
            if (!this.Properties.TryGetValue("clear_at_least", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaInputTokensClearAtLeast?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["clear_at_least"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Whether to clear all tool inputs (bool) or specific tool inputs to clear (list)
    /// </summary>
    public ClearToolInputs? ClearToolInputs
    {
        get
        {
            if (!this.Properties.TryGetValue("clear_tool_inputs", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ClearToolInputs?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["clear_tool_inputs"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Tool names whose uses are preserved from clearing
    /// </summary>
    public List<string>? ExcludeTools
    {
        get
        {
            if (!this.Properties.TryGetValue("exclude_tools", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["exclude_tools"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Number of tool uses to retain in the conversation
    /// </summary>
    public BetaToolUsesKeep? Keep
    {
        get
        {
            if (!this.Properties.TryGetValue("keep", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaToolUsesKeep?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["keep"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Condition that triggers the context management strategy
    /// </summary>
    public Trigger? Trigger
    {
        get
        {
            if (!this.Properties.TryGetValue("trigger", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Trigger?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["trigger"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.ClearAtLeast?.Validate();
        this.ClearToolInputs?.Validate();
        foreach (var item in this.ExcludeTools ?? [])
        {
            _ = item;
        }
        this.Keep?.Validate();
        this.Trigger?.Validate();
    }

    public BetaClearToolUses20250919Edit()
    {
        this.Type = new();
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClearToolUses20250919Edit(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaClearToolUses20250919Edit FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
