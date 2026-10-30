using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Analytics;

/// <summary>
/// A dimension to group connector activity by.
/// </summary>
[JsonConverter(typeof(AnalyticsConnectorGroupByConverter))]
public enum AnalyticsConnectorGroupBy
{
    Product,
    RbacGroupID,
    UserID,
}

sealed class AnalyticsConnectorGroupByConverter : JsonConverter<AnalyticsConnectorGroupBy>
{
    public override AnalyticsConnectorGroupBy Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "product" => AnalyticsConnectorGroupBy.Product,
            "rbac_group_id" => AnalyticsConnectorGroupBy.RbacGroupID,
            "user_id" => AnalyticsConnectorGroupBy.UserID,
            _ => (AnalyticsConnectorGroupBy)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AnalyticsConnectorGroupBy value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AnalyticsConnectorGroupBy.Product => "product",
                AnalyticsConnectorGroupBy.RbacGroupID => "rbac_group_id",
                AnalyticsConnectorGroupBy.UserID => "user_id",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
