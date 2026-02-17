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
        ToolSearchToolResultErrorParam,
        ToolSearchToolResultErrorParamFromRaw
    >)
)]
public sealed record class ToolSearchToolResultErrorParam : JsonModel
{
    public required ApiEnum<string, ToolSearchToolResultErrorCode> ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ToolSearchToolResultErrorCode>>(
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
                JsonSerializer.SerializeToElement("tool_search_tool_result_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ToolSearchToolResultErrorParam()
    {
        this.Type = JsonSerializer.SerializeToElement("tool_search_tool_result_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ToolSearchToolResultErrorParam(
        ToolSearchToolResultErrorParam toolSearchToolResultErrorParam
    )
        : base(toolSearchToolResultErrorParam) { }
#pragma warning restore CS8618

    public ToolSearchToolResultErrorParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("tool_search_tool_result_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolSearchToolResultErrorParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolSearchToolResultErrorParamFromRaw.FromRawUnchecked"/>
    public static ToolSearchToolResultErrorParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ToolSearchToolResultErrorParam(ApiEnum<string, ToolSearchToolResultErrorCode> errorCode)
        : this()
    {
        this.ErrorCode = errorCode;
    }
}

class ToolSearchToolResultErrorParamFromRaw : IFromRawJson<ToolSearchToolResultErrorParam>
{
    /// <inheritdoc/>
    public ToolSearchToolResultErrorParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ToolSearchToolResultErrorParam.FromRawUnchecked(rawData);
}
