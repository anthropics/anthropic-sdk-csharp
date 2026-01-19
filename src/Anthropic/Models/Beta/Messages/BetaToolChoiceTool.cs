using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// The model will use the specified tool with `tool_choice.name`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaToolChoiceTool, BetaToolChoiceToolFromRaw>))]
public sealed record class BetaToolChoiceTool : JsonModel
{
    /// <summary>
    /// The name of the tool to use.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Whether to disable parallel tool use.
    ///
    /// <para>Defaults to `false`. If set to `true`, the model will output exactly
    /// one tool use.</para>
    /// </summary>
    public bool? DisableParallelToolUse
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("disable_parallel_tool_use");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("disable_parallel_tool_use", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("tool")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.DisableParallelToolUse;
    }

    public BetaToolChoiceTool()
    {
        this.Type = JsonSerializer.SerializeToElement("tool");
    }

    public BetaToolChoiceTool(BetaToolChoiceTool betaToolChoiceTool)
        : base(betaToolChoiceTool) { }

    public BetaToolChoiceTool(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("tool");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolChoiceTool(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaToolChoiceToolFromRaw.FromRawUnchecked"/>
    public static BetaToolChoiceTool FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaToolChoiceTool(string name)
        : this()
    {
        this.Name = name;
    }
}

class BetaToolChoiceToolFromRaw : IFromRawJson<BetaToolChoiceTool>
{
    /// <inheritdoc/>
    public BetaToolChoiceTool FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaToolChoiceTool.FromRawUnchecked(rawData);
}
