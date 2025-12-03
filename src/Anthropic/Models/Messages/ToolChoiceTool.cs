using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// The model will use the specified tool with `tool_choice.name`.
/// </summary>
[JsonConverter(typeof(ModelConverter<ToolChoiceTool, ToolChoiceToolFromRaw>))]
public sealed record class ToolChoiceTool : ModelBase
{
    /// <summary>
    /// The name of the tool to use.
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// Whether to disable parallel tool use.
    ///
    /// <para>Defaults to `false`. If set to `true`, the model will output exactly
    /// one tool use.</para>
    /// </summary>
    public bool? DisableParallelToolUse
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "disable_parallel_tool_use"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "disable_parallel_tool_use", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.Deserialize<JsonElement>("\"tool\"")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.DisableParallelToolUse;
    }

    public ToolChoiceTool()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool\"");
    }

    public ToolChoiceTool(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolChoiceTool(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolChoiceToolFromRaw.FromRawUnchecked"/>
    public static ToolChoiceTool FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ToolChoiceTool(string name)
        : this()
    {
        this.Name = name;
    }
}

class ToolChoiceToolFromRaw : IFromRaw<ToolChoiceTool>
{
    /// <inheritdoc/>
    public ToolChoiceTool FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ToolChoiceTool.FromRawUnchecked(rawData);
}
