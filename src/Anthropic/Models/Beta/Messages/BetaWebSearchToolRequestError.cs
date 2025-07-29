using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<BetaWebSearchToolRequestError>))]
public sealed record class BetaWebSearchToolRequestError
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaWebSearchToolRequestError>
{
    public required BetaWebSearchToolResultErrorCode ErrorCode
    {
        get
        {
            if (!this.Properties.TryGetValue("error_code", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "error_code",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<BetaWebSearchToolResultErrorCode>(element)
                ?? throw new System::ArgumentNullException("error_code");
        }
        set { this.Properties["error_code"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public Json::JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("type", "Missing required argument");

            return Json::JsonSerializer.Deserialize<Json::JsonElement>(element);
        }
        set { this.Properties["type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.ErrorCode.Validate();
    }

    public BetaWebSearchToolRequestError()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>(
            "\"web_search_tool_result_error\""
        );
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BetaWebSearchToolRequestError(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaWebSearchToolRequestError FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
