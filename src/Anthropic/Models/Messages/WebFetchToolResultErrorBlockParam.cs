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
        WebFetchToolResultErrorBlockParam,
        WebFetchToolResultErrorBlockParamFromRaw
    >)
)]
public sealed record class WebFetchToolResultErrorBlockParam : JsonModel
{
    public required ApiEnum<string, WebFetchToolResultErrorCode> ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, WebFetchToolResultErrorCode>>(
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
                JsonSerializer.SerializeToElement("web_fetch_tool_result_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public WebFetchToolResultErrorBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("web_fetch_tool_result_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebFetchToolResultErrorBlockParam(
        WebFetchToolResultErrorBlockParam webFetchToolResultErrorBlockParam
    )
        : base(webFetchToolResultErrorBlockParam) { }
#pragma warning restore CS8618

    public WebFetchToolResultErrorBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("web_fetch_tool_result_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebFetchToolResultErrorBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebFetchToolResultErrorBlockParamFromRaw.FromRawUnchecked"/>
    public static WebFetchToolResultErrorBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WebFetchToolResultErrorBlockParam(ApiEnum<string, WebFetchToolResultErrorCode> errorCode)
        : this()
    {
        this.ErrorCode = errorCode;
    }
}

class WebFetchToolResultErrorBlockParamFromRaw : IFromRawJson<WebFetchToolResultErrorBlockParam>
{
    /// <inheritdoc/>
    public WebFetchToolResultErrorBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebFetchToolResultErrorBlockParam.FromRawUnchecked(rawData);
}
