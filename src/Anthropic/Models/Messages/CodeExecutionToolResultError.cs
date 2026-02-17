using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(
    typeof(JsonModelConverter<CodeExecutionToolResultError, CodeExecutionToolResultErrorFromRaw>)
)]
public sealed record class CodeExecutionToolResultError : JsonModel
{
    public required ApiEnum<string, CodeExecutionToolResultErrorCode> ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CodeExecutionToolResultErrorCode>>(
                "error_code"
            );
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ErrorCode.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("code_execution_tool_result_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public CodeExecutionToolResultError()
    {
        this.Type = JsonSerializer.SerializeToElement("code_execution_tool_result_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CodeExecutionToolResultError(CodeExecutionToolResultError codeExecutionToolResultError)
        : base(codeExecutionToolResultError) { }
#pragma warning restore CS8618

    public CodeExecutionToolResultError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("code_execution_tool_result_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CodeExecutionToolResultError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CodeExecutionToolResultErrorFromRaw.FromRawUnchecked"/>
    public static CodeExecutionToolResultError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CodeExecutionToolResultError(ApiEnum<string, CodeExecutionToolResultErrorCode> errorCode)
        : this()
    {
        this.ErrorCode = errorCode;
    }
}

class CodeExecutionToolResultErrorFromRaw : IFromRawJson<CodeExecutionToolResultError>
{
    /// <inheritdoc/>
    public CodeExecutionToolResultError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CodeExecutionToolResultError.FromRawUnchecked(rawData);
}
