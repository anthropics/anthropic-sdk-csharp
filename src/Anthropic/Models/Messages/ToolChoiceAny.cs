using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// The model will use any available tools.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ToolChoiceAny, ToolChoiceAnyFromRaw>))]
public sealed record class ToolChoiceAny : JsonModel
{
    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// Whether to disable parallel tool use.
    ///
    /// <para>Defaults to `false`. If set to `true`, the model will output exactly
    /// one tool use.</para>
    /// </summary>
    public bool? DisableParallelToolUse
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "disable_parallel_tool_use"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "disable_parallel_tool_use", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.Deserialize<JsonElement>("\"any\"")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.DisableParallelToolUse;
    }

    public ToolChoiceAny()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"any\"");
    }

    public ToolChoiceAny(ToolChoiceAny toolChoiceAny)
        : base(toolChoiceAny) { }

    public ToolChoiceAny(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"any\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolChoiceAny(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolChoiceAnyFromRaw.FromRawUnchecked"/>
    public static ToolChoiceAny FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ToolChoiceAnyFromRaw : IFromRawJson<ToolChoiceAny>
{
    /// <inheritdoc/>
    public ToolChoiceAny FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ToolChoiceAny.FromRawUnchecked(rawData);
}
