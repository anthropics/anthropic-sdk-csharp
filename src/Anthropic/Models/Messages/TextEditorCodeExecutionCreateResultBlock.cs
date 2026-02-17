using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(
    typeof(JsonModelConverter<
        TextEditorCodeExecutionCreateResultBlock,
        TextEditorCodeExecutionCreateResultBlockFromRaw
    >)
)]
public sealed record class TextEditorCodeExecutionCreateResultBlock : JsonModel
{
    public required bool IsFileUpdate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("is_file_update");
        }
        init { this._rawData.Set("is_file_update", value); }
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
        _ = this.IsFileUpdate;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("text_editor_code_execution_create_result")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public TextEditorCodeExecutionCreateResultBlock()
    {
        this.Type = JsonSerializer.SerializeToElement("text_editor_code_execution_create_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TextEditorCodeExecutionCreateResultBlock(
        TextEditorCodeExecutionCreateResultBlock textEditorCodeExecutionCreateResultBlock
    )
        : base(textEditorCodeExecutionCreateResultBlock) { }
#pragma warning restore CS8618

    public TextEditorCodeExecutionCreateResultBlock(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("text_editor_code_execution_create_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TextEditorCodeExecutionCreateResultBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TextEditorCodeExecutionCreateResultBlockFromRaw.FromRawUnchecked"/>
    public static TextEditorCodeExecutionCreateResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TextEditorCodeExecutionCreateResultBlock(bool isFileUpdate)
        : this()
    {
        this.IsFileUpdate = isFileUpdate;
    }
}

class TextEditorCodeExecutionCreateResultBlockFromRaw
    : IFromRawJson<TextEditorCodeExecutionCreateResultBlock>
{
    /// <inheritdoc/>
    public TextEditorCodeExecutionCreateResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TextEditorCodeExecutionCreateResultBlock.FromRawUnchecked(rawData);
}
