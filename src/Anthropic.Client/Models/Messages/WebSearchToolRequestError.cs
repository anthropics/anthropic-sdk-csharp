using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using Anthropic.Client.Models.Messages.WebSearchToolRequestErrorProperties;

namespace Anthropic.Client.Models.Messages;

[JsonConverter(typeof(ModelConverter<WebSearchToolRequestError>))]
public sealed record class WebSearchToolRequestError
    : ModelBase,
        IFromRaw<WebSearchToolRequestError>
{
    public required ApiEnum<string, ErrorCode> ErrorCode
    {
        get
        {
            if (!this.Properties.TryGetValue("error_code", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'error_code' cannot be null",
                    new ArgumentOutOfRangeException("error_code", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, ErrorCode>>(
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
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

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

    public WebSearchToolRequestError()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_search_tool_result_error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebSearchToolRequestError(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static WebSearchToolRequestError FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public WebSearchToolRequestError(ApiEnum<string, ErrorCode> errorCode)
        : this()
    {
        this.ErrorCode = errorCode;
    }
}
