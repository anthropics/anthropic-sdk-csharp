using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<BetaToolSearchToolResultError, BetaToolSearchToolResultErrorFromRaw>)
)]
public sealed record class BetaToolSearchToolResultError : JsonModel
{
    public required ApiEnum<string, BetaToolSearchToolResultErrorErrorCode> ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaToolSearchToolResultErrorErrorCode>
            >("error_code");
        }
        init { this._rawData.Set("error_code", value); }
    }

    public required string? ErrorMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error_message");
        }
        init { this._rawData.Set("error_message", value); }
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
        _ = this.ErrorMessage;
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

    public BetaToolSearchToolResultError()
    {
        this.Type = JsonSerializer.SerializeToElement("tool_search_tool_result_error");
    }

    public BetaToolSearchToolResultError(
        BetaToolSearchToolResultError betaToolSearchToolResultError
    )
        : base(betaToolSearchToolResultError) { }

    public BetaToolSearchToolResultError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("tool_search_tool_result_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolSearchToolResultError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaToolSearchToolResultErrorFromRaw.FromRawUnchecked"/>
    public static BetaToolSearchToolResultError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaToolSearchToolResultErrorFromRaw : IFromRawJson<BetaToolSearchToolResultError>
{
    /// <inheritdoc/>
    public BetaToolSearchToolResultError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaToolSearchToolResultError.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaToolSearchToolResultErrorErrorCodeConverter))]
public enum BetaToolSearchToolResultErrorErrorCode
{
    InvalidToolInput,
    Unavailable,
    TooManyRequests,
    ExecutionTimeExceeded,
}

sealed class BetaToolSearchToolResultErrorErrorCodeConverter
    : JsonConverter<BetaToolSearchToolResultErrorErrorCode>
{
    public override BetaToolSearchToolResultErrorErrorCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "invalid_tool_input" => BetaToolSearchToolResultErrorErrorCode.InvalidToolInput,
            "unavailable" => BetaToolSearchToolResultErrorErrorCode.Unavailable,
            "too_many_requests" => BetaToolSearchToolResultErrorErrorCode.TooManyRequests,
            "execution_time_exceeded" =>
                BetaToolSearchToolResultErrorErrorCode.ExecutionTimeExceeded,
            _ => (BetaToolSearchToolResultErrorErrorCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaToolSearchToolResultErrorErrorCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaToolSearchToolResultErrorErrorCode.InvalidToolInput => "invalid_tool_input",
                BetaToolSearchToolResultErrorErrorCode.Unavailable => "unavailable",
                BetaToolSearchToolResultErrorErrorCode.TooManyRequests => "too_many_requests",
                BetaToolSearchToolResultErrorErrorCode.ExecutionTimeExceeded =>
                    "execution_time_exceeded",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
