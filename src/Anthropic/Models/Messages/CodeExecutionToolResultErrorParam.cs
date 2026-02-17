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
        CodeExecutionToolResultErrorParam,
        CodeExecutionToolResultErrorParamFromRaw
    >)
)]
public sealed record class CodeExecutionToolResultErrorParam : JsonModel
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

    public CodeExecutionToolResultErrorParam()
    {
        this.Type = JsonSerializer.SerializeToElement("code_execution_tool_result_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CodeExecutionToolResultErrorParam(
        CodeExecutionToolResultErrorParam codeExecutionToolResultErrorParam
    )
        : base(codeExecutionToolResultErrorParam) { }
#pragma warning restore CS8618

    public CodeExecutionToolResultErrorParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("code_execution_tool_result_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CodeExecutionToolResultErrorParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CodeExecutionToolResultErrorParamFromRaw.FromRawUnchecked"/>
    public static CodeExecutionToolResultErrorParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CodeExecutionToolResultErrorParam(
        ApiEnum<string, CodeExecutionToolResultErrorCode> errorCode
    )
        : this()
    {
        this.ErrorCode = errorCode;
    }
}

class CodeExecutionToolResultErrorParamFromRaw : IFromRawJson<CodeExecutionToolResultErrorParam>
{
    /// <inheritdoc/>
    public CodeExecutionToolResultErrorParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CodeExecutionToolResultErrorParam.FromRawUnchecked(rawData);
}
