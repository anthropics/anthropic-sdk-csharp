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
    typeof(ModelConverter<BetaToolSearchToolResultError, BetaToolSearchToolResultErrorFromRaw>)
)]
public sealed record class BetaToolSearchToolResultError : ModelBase
{
    public required ApiEnum<string, BetaToolSearchToolResultErrorErrorCode> ErrorCode
    {
        get
        {
            if (!this._rawData.TryGetValue("error_code", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'error_code' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "error_code",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<
                ApiEnum<string, BetaToolSearchToolResultErrorErrorCode>
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["error_code"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string? ErrorMessage
    {
        get
        {
            if (!this._rawData.TryGetValue("error_message", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["error_message"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.ErrorCode.Validate();
        _ = this.ErrorMessage;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"tool_search_tool_result_error\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaToolSearchToolResultError()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_search_tool_result_error\"");
    }

    public BetaToolSearchToolResultError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_search_tool_result_error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolSearchToolResultError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BetaToolSearchToolResultError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaToolSearchToolResultErrorFromRaw : IFromRaw<BetaToolSearchToolResultError>
{
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
