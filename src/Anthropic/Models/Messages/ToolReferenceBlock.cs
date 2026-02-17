using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<ToolReferenceBlock, ToolReferenceBlockFromRaw>))]
public sealed record class ToolReferenceBlock : JsonModel
{
    public required string ToolName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tool_name");
        }
        init { this._rawData.Set("tool_name", value); }
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
        _ = this.ToolName;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("tool_reference")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ToolReferenceBlock()
    {
        this.Type = JsonSerializer.SerializeToElement("tool_reference");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ToolReferenceBlock(ToolReferenceBlock toolReferenceBlock)
        : base(toolReferenceBlock) { }
#pragma warning restore CS8618

    public ToolReferenceBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("tool_reference");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolReferenceBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolReferenceBlockFromRaw.FromRawUnchecked"/>
    public static ToolReferenceBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ToolReferenceBlock(string toolName)
        : this()
    {
        this.ToolName = toolName;
    }
}

class ToolReferenceBlockFromRaw : IFromRawJson<ToolReferenceBlock>
{
    /// <inheritdoc/>
    public ToolReferenceBlock FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ToolReferenceBlock.FromRawUnchecked(rawData);
}
