using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(
    typeof(JsonModelConverter<WebSearchToolResultError, WebSearchToolResultErrorFromRaw>)
)]
public sealed record class WebSearchToolResultError : JsonModel
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

    public WebSearchToolResultError()
    {
        this.Type = JsonSerializer.SerializeToElement("web_search_tool_result_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebSearchToolResultError(WebSearchToolResultError webSearchToolResultError)
        : base(webSearchToolResultError) { }
#pragma warning restore CS8618

    public WebSearchToolResultError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("web_search_tool_result_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebSearchToolResultError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebSearchToolResultErrorFromRaw.FromRawUnchecked"/>
    public static WebSearchToolResultError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WebSearchToolResultError(ApiEnum<string, WebSearchToolResultErrorCode> errorCode)
        : this()
    {
        this.ErrorCode = errorCode;
    }
}

class WebSearchToolResultErrorFromRaw : IFromRawJson<WebSearchToolResultError>
{
    /// <inheritdoc/>
    public WebSearchToolResultError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebSearchToolResultError.FromRawUnchecked(rawData);
}
