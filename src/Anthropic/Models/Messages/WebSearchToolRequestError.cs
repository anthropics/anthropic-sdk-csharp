using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(
    typeof(JsonModelConverter<WebSearchToolRequestError, WebSearchToolRequestErrorFromRaw>)
)]
public sealed record class WebSearchToolRequestError : JsonModel
{
    public required ApiEnum<string, WebSearchToolResultErrorCode> ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, WebSearchToolResultErrorCode>>(
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
                JsonSerializer.SerializeToElement("web_search_tool_result_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public WebSearchToolRequestError()
    {
        this.Type = JsonSerializer.SerializeToElement("web_search_tool_result_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebSearchToolRequestError(WebSearchToolRequestError webSearchToolRequestError)
        : base(webSearchToolRequestError) { }
#pragma warning restore CS8618

    public WebSearchToolRequestError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("web_search_tool_result_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebSearchToolRequestError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebSearchToolRequestErrorFromRaw.FromRawUnchecked"/>
    public static WebSearchToolRequestError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WebSearchToolRequestError(ApiEnum<string, WebSearchToolResultErrorCode> errorCode)
        : this()
    {
        this.ErrorCode = errorCode;
    }
}

class WebSearchToolRequestErrorFromRaw : IFromRawJson<WebSearchToolRequestError>
{
    /// <inheritdoc/>
    public WebSearchToolRequestError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebSearchToolRequestError.FromRawUnchecked(rawData);
}
