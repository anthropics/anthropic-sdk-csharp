using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(
    typeof(JsonModelConverter<
        TextEditorCodeExecutionStrReplaceResultBlock,
        TextEditorCodeExecutionStrReplaceResultBlockFromRaw
    >)
)]
public sealed record class TextEditorCodeExecutionStrReplaceResultBlock : JsonModel
{
    public required IReadOnlyList<string>? Lines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("lines");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "lines",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required long? NewLines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("new_lines");
        }
        init { this._rawData.Set("new_lines", value); }
    }

    public required long? NewStart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("new_start");
        }
        init { this._rawData.Set("new_start", value); }
    }

    public required long? OldLines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("old_lines");
        }
        init { this._rawData.Set("old_lines", value); }
    }

    public required long? OldStart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("old_start");
        }
        init { this._rawData.Set("old_start", value); }
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
        _ = this.Lines;
        _ = this.NewLines;
        _ = this.NewStart;
        _ = this.OldLines;
        _ = this.OldStart;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("text_editor_code_execution_str_replace_result")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public TextEditorCodeExecutionStrReplaceResultBlock()
    {
        this.Type = JsonSerializer.SerializeToElement(
            "text_editor_code_execution_str_replace_result"
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TextEditorCodeExecutionStrReplaceResultBlock(
        TextEditorCodeExecutionStrReplaceResultBlock textEditorCodeExecutionStrReplaceResultBlock
    )
        : base(textEditorCodeExecutionStrReplaceResultBlock) { }
#pragma warning restore CS8618

    public TextEditorCodeExecutionStrReplaceResultBlock(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement(
            "text_editor_code_execution_str_replace_result"
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TextEditorCodeExecutionStrReplaceResultBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TextEditorCodeExecutionStrReplaceResultBlockFromRaw.FromRawUnchecked"/>
    public static TextEditorCodeExecutionStrReplaceResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TextEditorCodeExecutionStrReplaceResultBlockFromRaw
    : IFromRawJson<TextEditorCodeExecutionStrReplaceResultBlock>
{
    /// <inheritdoc/>
    public TextEditorCodeExecutionStrReplaceResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TextEditorCodeExecutionStrReplaceResultBlock.FromRawUnchecked(rawData);
}
