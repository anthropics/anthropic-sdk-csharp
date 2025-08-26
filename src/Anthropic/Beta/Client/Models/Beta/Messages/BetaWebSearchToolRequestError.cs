using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Beta.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaWebSearchToolRequestError>))]
public sealed record class BetaWebSearchToolRequestError
    : ModelBase,
        IFromRaw<BetaWebSearchToolRequestError>
{
    public required ApiEnum<string, BetaWebSearchToolResultErrorCode> ErrorCode
    {
        get
        {
            if (!this.Properties.TryGetValue("error_code", out JsonElement element))
                throw new ArgumentOutOfRangeException("error_code", "Missing required argument");

            return JsonSerializer.Deserialize<ApiEnum<string, BetaWebSearchToolResultErrorCode>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["error_code"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new ArgumentOutOfRangeException("type", "Missing required argument");

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.ErrorCode.Validate();
    }

    public BetaWebSearchToolRequestError()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_tool_result_error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebSearchToolRequestError(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaWebSearchToolRequestError FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public BetaWebSearchToolRequestError(
        ApiEnum<string, BetaWebSearchToolResultErrorCode> errorCode
    )
        : this()
    {
        this.ErrorCode = errorCode;
    }
}
