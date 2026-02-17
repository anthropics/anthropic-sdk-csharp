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
        TextEditorCodeExecutionToolResultError,
        TextEditorCodeExecutionToolResultErrorFromRaw
    >)
)]
public sealed record class TextEditorCodeExecutionToolResultError : JsonModel
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

    public required string? ErrorMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error_message");
        }
        init { this._rawData.Set("error_message", value); }
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
        this.ErrorCode.Validate();
        _ = this.ErrorMessage;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("text_editor_code_execution_tool_result_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public TextEditorCodeExecutionToolResultError()
    {
        this.Type = JsonSerializer.SerializeToElement(
            "text_editor_code_execution_tool_result_error"
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TextEditorCodeExecutionToolResultError(
        TextEditorCodeExecutionToolResultError textEditorCodeExecutionToolResultError
    )
        : base(textEditorCodeExecutionToolResultError) { }
#pragma warning restore CS8618

    public TextEditorCodeExecutionToolResultError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement(
            "text_editor_code_execution_tool_result_error"
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TextEditorCodeExecutionToolResultError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TextEditorCodeExecutionToolResultErrorFromRaw.FromRawUnchecked"/>
    public static TextEditorCodeExecutionToolResultError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TextEditorCodeExecutionToolResultErrorFromRaw
    : IFromRawJson<TextEditorCodeExecutionToolResultError>
{
    /// <inheritdoc/>
    public TextEditorCodeExecutionToolResultError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TextEditorCodeExecutionToolResultError.FromRawUnchecked(rawData);
}
