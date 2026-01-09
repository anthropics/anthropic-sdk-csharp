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
        BetaTextEditorCodeExecutionCreateResultBlock,
        BetaTextEditorCodeExecutionCreateResultBlockFromRaw
    >)
)]
public sealed record class BetaTextEditorCodeExecutionCreateResultBlock : JsonModel
{
    public required bool IsFileUpdate
    {
        get { return JsonModel.GetNotNullStruct<bool>(this.RawData, "is_file_update"); }
        init { JsonModel.Set(this._rawData, "is_file_update", value); }
    }

    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.IsFileUpdate;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>(
                    "\"text_editor_code_execution_create_result\""
                )
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaTextEditorCodeExecutionCreateResultBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_create_result\""
        );
    }

    public BetaTextEditorCodeExecutionCreateResultBlock(
        BetaTextEditorCodeExecutionCreateResultBlock betaTextEditorCodeExecutionCreateResultBlock
    )
        : base(betaTextEditorCodeExecutionCreateResultBlock) { }

    public BetaTextEditorCodeExecutionCreateResultBlock(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_create_result\""
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTextEditorCodeExecutionCreateResultBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTextEditorCodeExecutionCreateResultBlockFromRaw.FromRawUnchecked"/>
    public static BetaTextEditorCodeExecutionCreateResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaTextEditorCodeExecutionCreateResultBlock(bool isFileUpdate)
        : this()
    {
        this.IsFileUpdate = isFileUpdate;
    }
}

class BetaTextEditorCodeExecutionCreateResultBlockFromRaw
    : IFromRawJson<BetaTextEditorCodeExecutionCreateResultBlock>
{
    /// <inheritdoc/>
    public BetaTextEditorCodeExecutionCreateResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaTextEditorCodeExecutionCreateResultBlock.FromRawUnchecked(rawData);
}
