using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Messages;

/// <summary>
/// The model will use any available tools.
/// </summary>
[JsonConverter(typeof(ModelConverter<ToolChoiceAny>))]
public sealed record class ToolChoiceAny : ModelBase, IFromRaw<ToolChoiceAny>
{
    public JsonElement Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Whether to disable parallel tool use.
    ///
    /// Defaults to `false`. If set to `true`, the model will output exactly one
    /// tool use.
    /// </summary>
    public bool? DisableParallelToolUse
    {
        get
        {
            if (!this._properties.TryGetValue("disable_parallel_tool_use", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["disable_parallel_tool_use"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Type;
        _ = this.DisableParallelToolUse;
    }

    public ToolChoiceAny()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"any\"");
    }

    public ToolChoiceAny(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"any\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolChoiceAny(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ToolChoiceAny FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
