using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaCodeExecutionToolResultBlock,
        BetaCodeExecutionToolResultBlockFromRaw
    >)
)]
public sealed record class BetaCodeExecutionToolResultBlock : JsonModel
{
    public required BetaCodeExecutionToolResultBlockContent Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaCodeExecutionToolResultBlockContent>(
                "content"
            );
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

    public BetaCodeExecutionToolResultBlock()
    {
        this.Type = JsonSerializer.SerializeToElement("code_execution_tool_result");
    }

    public BetaCodeExecutionToolResultBlock(
        BetaCodeExecutionToolResultBlock betaCodeExecutionToolResultBlock
    )
        : base(betaCodeExecutionToolResultBlock) { }

    public BetaCodeExecutionToolResultBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("code_execution_tool_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCodeExecutionToolResultBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCodeExecutionToolResultBlockFromRaw.FromRawUnchecked"/>
    public static BetaCodeExecutionToolResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaCodeExecutionToolResultBlockFromRaw : IFromRawJson<BetaCodeExecutionToolResultBlock>
{
    /// <inheritdoc/>
    public BetaCodeExecutionToolResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCodeExecutionToolResultBlock.FromRawUnchecked(rawData);
}
