using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaBashCodeExecutionToolResultErrorParam>))]
public sealed record class BetaBashCodeExecutionToolResultErrorParam
    : ModelBase,
        IFromRaw<BetaBashCodeExecutionToolResultErrorParam>
{
    public required ApiEnum<string, ErrorCodeModel> ErrorCode
    {
        get
        {
            if (!this._properties.TryGetValue("error_code", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'error_code' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "error_code",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<ApiEnum<string, ErrorCodeModel>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["error_code"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
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
                JsonSerializer.Deserialize<JsonElement>("\"bash_code_execution_tool_result_error\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaBashCodeExecutionToolResultErrorParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>(
            "\"bash_code_execution_tool_result_error\""
        );
    }

    public BetaBashCodeExecutionToolResultErrorParam(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>(
            "\"bash_code_execution_tool_result_error\""
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBashCodeExecutionToolResultErrorParam(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaBashCodeExecutionToolResultErrorParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public BetaBashCodeExecutionToolResultErrorParam(ApiEnum<string, ErrorCodeModel> errorCode)
        : this()
    {
        this.ErrorCode = errorCode;
    }
}

[JsonConverter(typeof(ErrorCodeModelConverter))]
public enum ErrorCodeModel
{
    InvalidToolInput,
    Unavailable,
    TooManyRequests,
    ExecutionTimeExceeded,
    OutputFileTooLarge,
}

sealed class ErrorCodeModelConverter : JsonConverter<ErrorCodeModel>
{
    public override ErrorCodeModel Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "invalid_tool_input" => ErrorCodeModel.InvalidToolInput,
            "unavailable" => ErrorCodeModel.Unavailable,
            "too_many_requests" => ErrorCodeModel.TooManyRequests,
            "execution_time_exceeded" => ErrorCodeModel.ExecutionTimeExceeded,
            "output_file_too_large" => ErrorCodeModel.OutputFileTooLarge,
            _ => (ErrorCodeModel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ErrorCodeModel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ErrorCodeModel.InvalidToolInput => "invalid_tool_input",
                ErrorCodeModel.Unavailable => "unavailable",
                ErrorCodeModel.TooManyRequests => "too_many_requests",
                ErrorCodeModel.ExecutionTimeExceeded => "execution_time_exceeded",
                ErrorCodeModel.OutputFileTooLarge => "output_file_too_large",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
