using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(Anthropic::ModelConverter<BetaCodeExecutionToolResultErrorParam>))]
public sealed record class BetaCodeExecutionToolResultErrorParam
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaCodeExecutionToolResultErrorParam>
{
    public required BetaCodeExecutionToolResultErrorCode ErrorCode
    {
        get
        {
            if (!this.Properties.TryGetValue("error_code", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "error_code",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<BetaCodeExecutionToolResultErrorCode>(
                    element,
                    Anthropic::ModelBase.SerializerOptions
                ) ?? throw new global::System.ArgumentNullException("error_code");
        }
        set { this.Properties["error_code"] = JsonSerializer.SerializeToElement(value); }
    }

    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "type",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<JsonElement>(
                element,
                Anthropic::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["type"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.ErrorCode.Validate();
    }

    public BetaCodeExecutionToolResultErrorParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"code_execution_tool_result_error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCodeExecutionToolResultErrorParam(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaCodeExecutionToolResultErrorParam FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public BetaCodeExecutionToolResultErrorParam(BetaCodeExecutionToolResultErrorCode errorCode)
        : this()
    {
        this.ErrorCode = errorCode;
    }
}
