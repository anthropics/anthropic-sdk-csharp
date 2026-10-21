using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(
    typeof(JsonModelConverter<BrowserNavigateToolUseBlock, BrowserNavigateToolUseBlockFromRaw>)
)]
public sealed record class BrowserNavigateToolUseBlock : JsonModel
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
    /// Navigate to a URL, or go back/forward/reload in history. The protocol may
    /// be omitted (defaults to https://).
    /// </summary>
    public required BrowserNavigateInput Input
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BrowserNavigateInput>("input");
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
        if (!JsonElement.DeepEquals(this.Name, JsonSerializer.SerializeToElement("navigate")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        if (!JsonElement.DeepEquals(this.ToolsetName, JsonSerializer.SerializeToElement("browser")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("tool_use")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BrowserNavigateToolUseBlock()
    {
        this.Name = JsonSerializer.SerializeToElement("navigate");
        this.ToolsetName = JsonSerializer.SerializeToElement("browser");
        this.Type = JsonSerializer.SerializeToElement("tool_use");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserNavigateToolUseBlock(BrowserNavigateToolUseBlock browserNavigateToolUseBlock)
        : base(browserNavigateToolUseBlock) { }
#pragma warning restore CS8618

    public BrowserNavigateToolUseBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Name = JsonSerializer.SerializeToElement("navigate");
        this.ToolsetName = JsonSerializer.SerializeToElement("browser");
        this.Type = JsonSerializer.SerializeToElement("tool_use");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserNavigateToolUseBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserNavigateToolUseBlockFromRaw.FromRawUnchecked"/>
    public static BrowserNavigateToolUseBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrowserNavigateToolUseBlockFromRaw : IFromRawJson<BrowserNavigateToolUseBlock>
{
    /// <inheritdoc/>
    public BrowserNavigateToolUseBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrowserNavigateToolUseBlock.FromRawUnchecked(rawData);
}
