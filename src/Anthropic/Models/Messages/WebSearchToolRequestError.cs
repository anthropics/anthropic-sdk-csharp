using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebSearchToolRequestErrorProperties = Anthropic.Models.Messages.WebSearchToolRequestErrorProperties;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<WebSearchToolRequestError>))]
public sealed record class WebSearchToolRequestError
    : ModelBase,
        IFromRaw<WebSearchToolRequestError>
{
    public required WebSearchToolRequestErrorProperties::ErrorCode ErrorCode
    {
        get
        {
            if (!this.Properties.TryGetValue("error_code", out JsonElement element))
                throw new global::System.ArgumentOutOfRangeException(
                    "error_code",
                    "Missing required argument"
                );

            return JsonSerializer.Deserialize<WebSearchToolRequestErrorProperties::ErrorCode>(
                    element,
                    ModelBase.SerializerOptions
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

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["type"] = JsonSerializer.SerializeToElement(value); }
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
    public WebSearchToolRequestError(WebSearchToolRequestErrorProperties::ErrorCode errorCode)
        : this()
    {
        this.ErrorCode = errorCode;
    }
}
