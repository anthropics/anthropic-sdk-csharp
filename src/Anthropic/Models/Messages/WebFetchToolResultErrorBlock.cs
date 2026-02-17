using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(
    typeof(JsonModelConverter<WebFetchToolResultErrorBlock, WebFetchToolResultErrorBlockFromRaw>)
)]
public sealed record class WebFetchToolResultErrorBlock : JsonModel
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

    public WebFetchToolResultErrorBlock()
    {
        this.Type = JsonSerializer.SerializeToElement("web_fetch_tool_result_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebFetchToolResultErrorBlock(WebFetchToolResultErrorBlock webFetchToolResultErrorBlock)
        : base(webFetchToolResultErrorBlock) { }
#pragma warning restore CS8618

    public WebFetchToolResultErrorBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("web_fetch_tool_result_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebFetchToolResultErrorBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebFetchToolResultErrorBlockFromRaw.FromRawUnchecked"/>
    public static WebFetchToolResultErrorBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WebFetchToolResultErrorBlock(ApiEnum<string, WebFetchToolResultErrorCode> errorCode)
        : this()
    {
        this.ErrorCode = errorCode;
    }
}

class WebFetchToolResultErrorBlockFromRaw : IFromRawJson<WebFetchToolResultErrorBlock>
{
    /// <inheritdoc/>
    public WebFetchToolResultErrorBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebFetchToolResultErrorBlock.FromRawUnchecked(rawData);
}
