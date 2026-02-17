using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(
    typeof(JsonModelConverter<CodeExecutionOutputBlock, CodeExecutionOutputBlockFromRaw>)
)]
public sealed record class CodeExecutionOutputBlock : JsonModel
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
                JsonSerializer.SerializeToElement("code_execution_output")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public CodeExecutionOutputBlock()
    {
        this.Type = JsonSerializer.SerializeToElement("code_execution_output");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CodeExecutionOutputBlock(CodeExecutionOutputBlock codeExecutionOutputBlock)
        : base(codeExecutionOutputBlock) { }
#pragma warning restore CS8618

    public CodeExecutionOutputBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("code_execution_output");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CodeExecutionOutputBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CodeExecutionOutputBlockFromRaw.FromRawUnchecked"/>
    public static CodeExecutionOutputBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CodeExecutionOutputBlock(string fileID)
        : this()
    {
        this.FileID = fileID;
    }
}

class CodeExecutionOutputBlockFromRaw : IFromRawJson<CodeExecutionOutputBlock>
{
    /// <inheritdoc/>
    public CodeExecutionOutputBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CodeExecutionOutputBlock.FromRawUnchecked(rawData);
}
