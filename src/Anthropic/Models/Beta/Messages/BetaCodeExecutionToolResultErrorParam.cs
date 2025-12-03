using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(ModelConverter<
        BetaCodeExecutionToolResultErrorParam,
        BetaCodeExecutionToolResultErrorParamFromRaw
    >)
)]
public sealed record class BetaCodeExecutionToolResultErrorParam : ModelBase
{
    public required ApiEnum<string, BetaCodeExecutionToolResultErrorCode> ErrorCode
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, BetaCodeExecutionToolResultErrorCode>>(
                this.RawData,
                "error_code"
            );
        }
        init { ModelBase.Set(this._rawData, "error_code", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ErrorCode.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"code_execution_tool_result_error\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaCodeExecutionToolResultErrorParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"code_execution_tool_result_error\"");
    }

    public BetaCodeExecutionToolResultErrorParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"code_execution_tool_result_error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCodeExecutionToolResultErrorParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCodeExecutionToolResultErrorParamFromRaw.FromRawUnchecked"/>
    public static BetaCodeExecutionToolResultErrorParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaCodeExecutionToolResultErrorParam(
        ApiEnum<string, BetaCodeExecutionToolResultErrorCode> errorCode
    )
        : this()
    {
        this.ErrorCode = errorCode;
    }
}

class BetaCodeExecutionToolResultErrorParamFromRaw : IFromRaw<BetaCodeExecutionToolResultErrorParam>
{
    /// <inheritdoc/>
    public BetaCodeExecutionToolResultErrorParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCodeExecutionToolResultErrorParam.FromRawUnchecked(rawData);
}
