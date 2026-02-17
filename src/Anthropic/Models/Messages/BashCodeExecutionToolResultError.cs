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
        BashCodeExecutionToolResultError,
        BashCodeExecutionToolResultErrorFromRaw
    >)
)]
public sealed record class BashCodeExecutionToolResultError : JsonModel
{
    public required ApiEnum<string, BashCodeExecutionToolResultErrorCode> ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BashCodeExecutionToolResultErrorCode>
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

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ErrorCode.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("bash_code_execution_tool_result_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BashCodeExecutionToolResultError()
    {
        this.Type = JsonSerializer.SerializeToElement("bash_code_execution_tool_result_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BashCodeExecutionToolResultError(
        BashCodeExecutionToolResultError bashCodeExecutionToolResultError
    )
        : base(bashCodeExecutionToolResultError) { }
#pragma warning restore CS8618

    public BashCodeExecutionToolResultError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("bash_code_execution_tool_result_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BashCodeExecutionToolResultError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BashCodeExecutionToolResultErrorFromRaw.FromRawUnchecked"/>
    public static BashCodeExecutionToolResultError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BashCodeExecutionToolResultError(
        ApiEnum<string, BashCodeExecutionToolResultErrorCode> errorCode
    )
        : this()
    {
        this.ErrorCode = errorCode;
    }
}

class BashCodeExecutionToolResultErrorFromRaw : IFromRawJson<BashCodeExecutionToolResultError>
{
    /// <inheritdoc/>
    public BashCodeExecutionToolResultError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BashCodeExecutionToolResultError.FromRawUnchecked(rawData);
}
