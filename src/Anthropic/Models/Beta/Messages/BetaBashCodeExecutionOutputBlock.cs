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
        BetaBashCodeExecutionOutputBlock,
        BetaBashCodeExecutionOutputBlockFromRaw
    >)
)]
public sealed record class BetaBashCodeExecutionOutputBlock : JsonModel
{
    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
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
        _ = this.FileID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("bash_code_execution_output")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaBashCodeExecutionOutputBlock()
    {
        this.Type = JsonSerializer.SerializeToElement("bash_code_execution_output");
    }

    public BetaBashCodeExecutionOutputBlock(
        BetaBashCodeExecutionOutputBlock betaBashCodeExecutionOutputBlock
    )
        : base(betaBashCodeExecutionOutputBlock) { }

    public BetaBashCodeExecutionOutputBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("bash_code_execution_output");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBashCodeExecutionOutputBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBashCodeExecutionOutputBlockFromRaw.FromRawUnchecked"/>
    public static BetaBashCodeExecutionOutputBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaBashCodeExecutionOutputBlock(string fileID)
        : this()
    {
        this.FileID = fileID;
    }
}

class BetaBashCodeExecutionOutputBlockFromRaw : IFromRawJson<BetaBashCodeExecutionOutputBlock>
{
    /// <inheritdoc/>
    public BetaBashCodeExecutionOutputBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBashCodeExecutionOutputBlock.FromRawUnchecked(rawData);
}
