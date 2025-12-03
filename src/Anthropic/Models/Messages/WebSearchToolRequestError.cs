using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<WebSearchToolRequestError, WebSearchToolRequestErrorFromRaw>))]
public sealed record class WebSearchToolRequestError : ModelBase
{
    public required ApiEnum<string, ErrorCode> ErrorCode
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, ErrorCode>>(
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
                JsonSerializer.Deserialize<JsonElement>("\"web_search_tool_result_error\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public WebSearchToolRequestError()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_tool_result_error\"");
    }

    public WebSearchToolRequestError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_tool_result_error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebSearchToolRequestError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
    public WebSearchToolRequestError(ApiEnum<string, ErrorCode> errorCode)
        : this()
    {
        this.ErrorCode = errorCode;
    }
}

class WebSearchToolRequestErrorFromRaw : IFromRaw<WebSearchToolRequestError>
{
    /// <inheritdoc/>
    public WebSearchToolRequestError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebSearchToolRequestError.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ErrorCodeConverter))]
public enum ErrorCode
{
    InvalidToolInput,
    Unavailable,
    MaxUsesExceeded,
    TooManyRequests,
    QueryTooLong,
}

sealed class ErrorCodeConverter : JsonConverter<ErrorCode>
{
    public override ErrorCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "invalid_tool_input" => ErrorCode.InvalidToolInput,
            "unavailable" => ErrorCode.Unavailable,
            "max_uses_exceeded" => ErrorCode.MaxUsesExceeded,
            "too_many_requests" => ErrorCode.TooManyRequests,
            "query_too_long" => ErrorCode.QueryTooLong,
            _ => (ErrorCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ErrorCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ErrorCode.InvalidToolInput => "invalid_tool_input",
                ErrorCode.Unavailable => "unavailable",
                ErrorCode.MaxUsesExceeded => "max_uses_exceeded",
                ErrorCode.TooManyRequests => "too_many_requests",
                ErrorCode.QueryTooLong => "query_too_long",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
