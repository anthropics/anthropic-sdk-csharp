using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(
    typeof(JsonModelConverter<ComputerZoomToolUseBlock, ComputerZoomToolUseBlockFromRaw>)
)]
public sealed record class ComputerZoomToolUseBlock : JsonModel
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
    /// Take a screenshot of a rectangular region. Region coordinates are in the
    /// full-screenshot space (not physical display pixels). The crop is scaled up
    /// to fill the image budget so fine details become legible.
    /// </summary>
    public required ComputerZoomInput Input
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ComputerZoomInput>("input");
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
        if (!JsonElement.DeepEquals(this.Name, JsonSerializer.SerializeToElement("zoom")))
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

    public ComputerZoomToolUseBlock()
    {
        this.Name = JsonSerializer.SerializeToElement("zoom");
        this.ToolsetName = JsonSerializer.SerializeToElement("computer");
        this.Type = JsonSerializer.SerializeToElement("tool_use");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComputerZoomToolUseBlock(ComputerZoomToolUseBlock computerZoomToolUseBlock)
        : base(computerZoomToolUseBlock) { }
#pragma warning restore CS8618

    public ComputerZoomToolUseBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Name = JsonSerializer.SerializeToElement("zoom");
        this.ToolsetName = JsonSerializer.SerializeToElement("computer");
        this.Type = JsonSerializer.SerializeToElement("tool_use");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComputerZoomToolUseBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComputerZoomToolUseBlockFromRaw.FromRawUnchecked"/>
    public static ComputerZoomToolUseBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComputerZoomToolUseBlockFromRaw : IFromRawJson<ComputerZoomToolUseBlock>
{
    /// <inheritdoc/>
    public ComputerZoomToolUseBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ComputerZoomToolUseBlock.FromRawUnchecked(rawData);
}
