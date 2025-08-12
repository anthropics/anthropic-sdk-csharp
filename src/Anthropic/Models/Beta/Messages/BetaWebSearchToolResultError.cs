using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic = Anthropic;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(Anthropic::ModelConverter<BetaWebSearchToolResultError>))]
public sealed record class BetaWebSearchToolResultError
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaWebSearchToolResultError>
{
    public required BetaWebSearchToolResultErrorCode ErrorCode
    {
        get
        {
            if (!this.Properties.TryGetValue("error_code", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "error_code",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<BetaWebSearchToolResultErrorCode>(
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

    public BetaWebSearchToolResultError()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_tool_result_error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebSearchToolResultError(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaWebSearchToolResultError FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public BetaWebSearchToolResultError(BetaWebSearchToolResultErrorCode errorCode)
        : this()
    {
        this.ErrorCode = errorCode;
    }
}
