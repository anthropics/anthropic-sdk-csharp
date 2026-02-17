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
        TextEditorCodeExecutionToolResultErrorParam,
        TextEditorCodeExecutionToolResultErrorParamFromRaw
    >)
)]
public sealed record class TextEditorCodeExecutionToolResultErrorParam : JsonModel
{
    public required ApiEnum<string, TextEditorCodeExecutionToolResultErrorCode> ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, TextEditorCodeExecutionToolResultErrorCode>
            >("error_code");
        }
        init { this._rawData.Set("error_code", value); }
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

    public string? ErrorMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error_message");
        }
        init { this._rawData.Set("error_message", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ErrorCode.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("text_editor_code_execution_tool_result_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.ErrorMessage;
    }

    public TextEditorCodeExecutionToolResultErrorParam()
    {
        this.Type = JsonSerializer.SerializeToElement(
            "text_editor_code_execution_tool_result_error"
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TextEditorCodeExecutionToolResultErrorParam(
        TextEditorCodeExecutionToolResultErrorParam textEditorCodeExecutionToolResultErrorParam
    )
        : base(textEditorCodeExecutionToolResultErrorParam) { }
#pragma warning restore CS8618

    public TextEditorCodeExecutionToolResultErrorParam(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement(
            "text_editor_code_execution_tool_result_error"
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TextEditorCodeExecutionToolResultErrorParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TextEditorCodeExecutionToolResultErrorParamFromRaw.FromRawUnchecked"/>
    public static TextEditorCodeExecutionToolResultErrorParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TextEditorCodeExecutionToolResultErrorParam(
        ApiEnum<string, TextEditorCodeExecutionToolResultErrorCode> errorCode
    )
        : this()
    {
        this.ErrorCode = errorCode;
    }
}

class TextEditorCodeExecutionToolResultErrorParamFromRaw
    : IFromRawJson<TextEditorCodeExecutionToolResultErrorParam>
{
    /// <inheritdoc/>
    public TextEditorCodeExecutionToolResultErrorParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TextEditorCodeExecutionToolResultErrorParam.FromRawUnchecked(rawData);
}
