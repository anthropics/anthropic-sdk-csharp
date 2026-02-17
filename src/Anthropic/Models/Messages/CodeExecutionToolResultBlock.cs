using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(
    typeof(JsonModelConverter<CodeExecutionToolResultBlock, CodeExecutionToolResultBlockFromRaw>)
)]
public sealed record class CodeExecutionToolResultBlock : JsonModel
{
    /// <summary>
    /// Code execution result with encrypted stdout for PFC + web_search results.
    /// </summary>
    public required CodeExecutionToolResultBlockContent Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CodeExecutionToolResultBlockContent>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    public required string ToolUseID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tool_use_id");
        }
        init { this._rawData.Set("tool_use_id", value); }
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
        this.Content.Validate();
        _ = this.ToolUseID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("code_execution_tool_result")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public CodeExecutionToolResultBlock()
    {
        this.Type = JsonSerializer.SerializeToElement("code_execution_tool_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CodeExecutionToolResultBlock(CodeExecutionToolResultBlock codeExecutionToolResultBlock)
        : base(codeExecutionToolResultBlock) { }
#pragma warning restore CS8618

    public CodeExecutionToolResultBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("code_execution_tool_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CodeExecutionToolResultBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CodeExecutionToolResultBlockFromRaw.FromRawUnchecked"/>
    public static CodeExecutionToolResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CodeExecutionToolResultBlockFromRaw : IFromRawJson<CodeExecutionToolResultBlock>
{
    /// <inheritdoc/>
    public CodeExecutionToolResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CodeExecutionToolResultBlock.FromRawUnchecked(rawData);
}
