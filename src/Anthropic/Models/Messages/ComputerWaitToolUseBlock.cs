using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(
    typeof(JsonModelConverter<ComputerWaitToolUseBlock, ComputerWaitToolUseBlockFromRaw>)
)]
public sealed record class ComputerWaitToolUseBlock : JsonModel
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
    /// Wait for a specified duration.
    /// </summary>
    public required ComputerWaitInput Input
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ComputerWaitInput>("input");
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
        if (!JsonElement.DeepEquals(this.Name, JsonSerializer.SerializeToElement("wait")))
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

    public ComputerWaitToolUseBlock()
    {
        this.Name = JsonSerializer.SerializeToElement("wait");
        this.ToolsetName = JsonSerializer.SerializeToElement("computer");
        this.Type = JsonSerializer.SerializeToElement("tool_use");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComputerWaitToolUseBlock(ComputerWaitToolUseBlock computerWaitToolUseBlock)
        : base(computerWaitToolUseBlock) { }
#pragma warning restore CS8618

    public ComputerWaitToolUseBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Name = JsonSerializer.SerializeToElement("wait");
        this.ToolsetName = JsonSerializer.SerializeToElement("computer");
        this.Type = JsonSerializer.SerializeToElement("tool_use");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComputerWaitToolUseBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComputerWaitToolUseBlockFromRaw.FromRawUnchecked"/>
    public static ComputerWaitToolUseBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComputerWaitToolUseBlockFromRaw : IFromRawJson<ComputerWaitToolUseBlock>
{
    /// <inheritdoc/>
    public ComputerWaitToolUseBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ComputerWaitToolUseBlock.FromRawUnchecked(rawData);
}
