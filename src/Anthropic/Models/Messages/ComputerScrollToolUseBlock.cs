using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(
    typeof(JsonModelConverter<ComputerScrollToolUseBlock, ComputerScrollToolUseBlockFromRaw>)
)]
public sealed record class ComputerScrollToolUseBlock : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Which party invoked the tool call: the model directly, or a server tool on
    /// its behalf.
    /// </summary>
    public required ToolUseCaller Caller
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ToolUseCaller>("caller");
        }
        init { this._rawData.Set("caller", value); }
    }

    /// <summary>
    /// Scroll the screen at the specified (x, y) pixel coordinate, or the current
    /// cursor position if `coordinate` is omitted. Do NOT use PageUp/PageDown to scroll.
    /// </summary>
    public required ComputerScrollInput Input
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ComputerScrollInput>("input");
        }
        init { this._rawData.Set("input", value); }
    }

    public JsonElement Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public JsonElement ToolsetName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("toolset_name");
        }
        init { this._rawData.Set("toolset_name", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Caller.Validate();
        this.Input.Validate();
        if (!JsonElement.DeepEquals(this.Name, JsonSerializer.SerializeToElement("scroll")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        if (
            !JsonElement.DeepEquals(this.ToolsetName, JsonSerializer.SerializeToElement("computer"))
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("tool_use")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ComputerScrollToolUseBlock()
    {
        this.Name = JsonSerializer.SerializeToElement("scroll");
        this.ToolsetName = JsonSerializer.SerializeToElement("computer");
        this.Type = JsonSerializer.SerializeToElement("tool_use");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComputerScrollToolUseBlock(ComputerScrollToolUseBlock computerScrollToolUseBlock)
        : base(computerScrollToolUseBlock) { }
#pragma warning restore CS8618

    public ComputerScrollToolUseBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Name = JsonSerializer.SerializeToElement("scroll");
        this.ToolsetName = JsonSerializer.SerializeToElement("computer");
        this.Type = JsonSerializer.SerializeToElement("tool_use");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComputerScrollToolUseBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComputerScrollToolUseBlockFromRaw.FromRawUnchecked"/>
    public static ComputerScrollToolUseBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComputerScrollToolUseBlockFromRaw : IFromRawJson<ComputerScrollToolUseBlock>
{
    /// <inheritdoc/>
    public ComputerScrollToolUseBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ComputerScrollToolUseBlock.FromRawUnchecked(rawData);
}
