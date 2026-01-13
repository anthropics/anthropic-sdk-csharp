using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(
    typeof(JsonModelConverter<WebSearchToolResultError, WebSearchToolResultErrorFromRaw>)
)]
public sealed record class WebSearchToolResultError : JsonModel
{
    public required ApiEnum<string, WebSearchToolResultErrorErrorCode> ErrorCode
    {
        get
        {
            return this._rawData.GetNotNullClass<
                ApiEnum<string, WebSearchToolResultErrorErrorCode>
            >("error_code");
        }
        init { this._rawData.Set("error_code", value); }
    }

    public JsonElement Type
    {
        get { return this._rawData.GetNotNullStruct<JsonElement>("type"); }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ErrorCode.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"web_search_tool_result_error\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public WebSearchToolResultError()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_tool_result_error\"");
    }

    public WebSearchToolResultError(WebSearchToolResultError webSearchToolResultError)
        : base(webSearchToolResultError) { }

    public WebSearchToolResultError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_tool_result_error\"");
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
    public WebSearchToolResultError(ApiEnum<string, WebSearchToolResultErrorErrorCode> errorCode)
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

[JsonConverter(typeof(WebSearchToolResultErrorErrorCodeConverter))]
public enum WebSearchToolResultErrorErrorCode
{
    InvalidToolInput,
    Unavailable,
    MaxUsesExceeded,
    TooManyRequests,
    QueryTooLong,
}

sealed class WebSearchToolResultErrorErrorCodeConverter
    : JsonConverter<WebSearchToolResultErrorErrorCode>
{
    public override WebSearchToolResultErrorErrorCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "invalid_tool_input" => WebSearchToolResultErrorErrorCode.InvalidToolInput,
            "unavailable" => WebSearchToolResultErrorErrorCode.Unavailable,
            "max_uses_exceeded" => WebSearchToolResultErrorErrorCode.MaxUsesExceeded,
            "too_many_requests" => WebSearchToolResultErrorErrorCode.TooManyRequests,
            "query_too_long" => WebSearchToolResultErrorErrorCode.QueryTooLong,
            _ => (WebSearchToolResultErrorErrorCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebSearchToolResultErrorErrorCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WebSearchToolResultErrorErrorCode.InvalidToolInput => "invalid_tool_input",
                WebSearchToolResultErrorErrorCode.Unavailable => "unavailable",
                WebSearchToolResultErrorErrorCode.MaxUsesExceeded => "max_uses_exceeded",
                WebSearchToolResultErrorErrorCode.TooManyRequests => "too_many_requests",
                WebSearchToolResultErrorErrorCode.QueryTooLong => "query_too_long",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
