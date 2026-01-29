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
        BetaCodeExecutionToolResultError,
        BetaCodeExecutionToolResultErrorFromRaw
    >)
)]
public sealed record class BetaCodeExecutionToolResultError : JsonModel
{
    public required ApiEnum<string, BetaCodeExecutionToolResultErrorCode> ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaCodeExecutionToolResultErrorCode>
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
                JsonSerializer.SerializeToElement("code_execution_tool_result_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaCodeExecutionToolResultError()
    {
        this.Type = JsonSerializer.SerializeToElement("code_execution_tool_result_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaCodeExecutionToolResultError(
        BetaCodeExecutionToolResultError betaCodeExecutionToolResultError
    )
        : base(betaCodeExecutionToolResultError) { }
#pragma warning restore CS8618

    public BetaCodeExecutionToolResultError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("code_execution_tool_result_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCodeExecutionToolResultError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCodeExecutionToolResultErrorFromRaw.FromRawUnchecked"/>
    public static BetaCodeExecutionToolResultError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaCodeExecutionToolResultError(
        ApiEnum<string, BetaCodeExecutionToolResultErrorCode> errorCode
    )
        : this()
    {
        this.ErrorCode = errorCode;
    }
}

class BetaCodeExecutionToolResultErrorFromRaw : IFromRawJson<BetaCodeExecutionToolResultError>
{
    /// <inheritdoc/>
    public BetaCodeExecutionToolResultError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCodeExecutionToolResultError.FromRawUnchecked(rawData);
}
