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
        TextEditorCodeExecutionStrReplaceResultBlockParam,
        TextEditorCodeExecutionStrReplaceResultBlockParamFromRaw
    >)
)]
public sealed record class TextEditorCodeExecutionStrReplaceResultBlockParam : JsonModel
{
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public IReadOnlyList<string>? Lines
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

    public long? NewLines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("new_lines");
        }
        init { this._rawData.Set("new_lines", value); }
    }

    public long? NewStart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("new_start");
        }
        init { this._rawData.Set("new_start", value); }
    }

    public long? OldLines
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("old_lines");
        }
        init { this._rawData.Set("old_lines", value); }
    }

    public long? OldStart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("old_start");
        }
        init { this._rawData.Set("old_start", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("text_editor_code_execution_str_replace_result")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Lines;
        _ = this.NewLines;
        _ = this.NewStart;
        _ = this.OldLines;
        _ = this.OldStart;
    }

    public TextEditorCodeExecutionStrReplaceResultBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement(
            "text_editor_code_execution_str_replace_result"
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TextEditorCodeExecutionStrReplaceResultBlockParam(
        TextEditorCodeExecutionStrReplaceResultBlockParam textEditorCodeExecutionStrReplaceResultBlockParam
    )
        : base(textEditorCodeExecutionStrReplaceResultBlockParam) { }
#pragma warning restore CS8618

    public TextEditorCodeExecutionStrReplaceResultBlockParam(
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
    TextEditorCodeExecutionStrReplaceResultBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TextEditorCodeExecutionStrReplaceResultBlockParamFromRaw.FromRawUnchecked"/>
    public static TextEditorCodeExecutionStrReplaceResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TextEditorCodeExecutionStrReplaceResultBlockParamFromRaw
    : IFromRawJson<TextEditorCodeExecutionStrReplaceResultBlockParam>
{
    /// <inheritdoc/>
    public TextEditorCodeExecutionStrReplaceResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TextEditorCodeExecutionStrReplaceResultBlockParam.FromRawUnchecked(rawData);
}
