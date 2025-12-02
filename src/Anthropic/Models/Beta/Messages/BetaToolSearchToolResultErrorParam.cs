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
    typeof(ModelConverter<
        BetaToolSearchToolResultErrorParam,
        BetaToolSearchToolResultErrorParamFromRaw
    >)
)]
public sealed record class BetaToolSearchToolResultErrorParam : ModelBase
{
    public required ApiEnum<string, BetaToolSearchToolResultErrorParamErrorCode> ErrorCode
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
                    ApiEnum<string, BetaToolSearchToolResultErrorParamErrorCode>
                >(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'error_code' cannot be null",
                    new System::ArgumentNullException("error_code")
                );
        }
        init
        {
            this._rawData["error_code"] = JsonSerializer.SerializeToElement(
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

    public BetaToolSearchToolResultErrorParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_search_tool_result_error\"");
    }

    public BetaToolSearchToolResultErrorParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_search_tool_result_error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolSearchToolResultErrorParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BetaToolSearchToolResultErrorParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaToolSearchToolResultErrorParam(
        ApiEnum<string, BetaToolSearchToolResultErrorParamErrorCode> errorCode
    )
        : this()
    {
        this.ErrorCode = errorCode;
    }
}

class BetaToolSearchToolResultErrorParamFromRaw : IFromRaw<BetaToolSearchToolResultErrorParam>
{
    public BetaToolSearchToolResultErrorParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaToolSearchToolResultErrorParam.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaToolSearchToolResultErrorParamErrorCodeConverter))]
public enum BetaToolSearchToolResultErrorParamErrorCode
{
    InvalidToolInput,
    Unavailable,
    TooManyRequests,
    ExecutionTimeExceeded,
}

sealed class BetaToolSearchToolResultErrorParamErrorCodeConverter
    : JsonConverter<BetaToolSearchToolResultErrorParamErrorCode>
{
    public override BetaToolSearchToolResultErrorParamErrorCode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "invalid_tool_input" => BetaToolSearchToolResultErrorParamErrorCode.InvalidToolInput,
            "unavailable" => BetaToolSearchToolResultErrorParamErrorCode.Unavailable,
            "too_many_requests" => BetaToolSearchToolResultErrorParamErrorCode.TooManyRequests,
            "execution_time_exceeded" =>
                BetaToolSearchToolResultErrorParamErrorCode.ExecutionTimeExceeded,
            _ => (BetaToolSearchToolResultErrorParamErrorCode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaToolSearchToolResultErrorParamErrorCode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaToolSearchToolResultErrorParamErrorCode.InvalidToolInput =>
                    "invalid_tool_input",
                BetaToolSearchToolResultErrorParamErrorCode.Unavailable => "unavailable",
                BetaToolSearchToolResultErrorParamErrorCode.TooManyRequests => "too_many_requests",
                BetaToolSearchToolResultErrorParamErrorCode.ExecutionTimeExceeded =>
                    "execution_time_exceeded",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
