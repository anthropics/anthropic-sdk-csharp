using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Analytics;

/// <summary>
/// A dimension to group plugin activity by.
/// </summary>
[JsonConverter(typeof(AnalyticsPluginGroupByConverter))]
public enum AnalyticsPluginGroupBy
{
    Product,
    RbacGroupID,
    UserID,
}

sealed class AnalyticsPluginGroupByConverter : JsonConverter<AnalyticsPluginGroupBy>
{
    public override AnalyticsPluginGroupBy Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "product" => AnalyticsPluginGroupBy.Product,
            "rbac_group_id" => AnalyticsPluginGroupBy.RbacGroupID,
            "user_id" => AnalyticsPluginGroupBy.UserID,
            _ => (AnalyticsPluginGroupBy)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AnalyticsPluginGroupBy value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AnalyticsPluginGroupBy.Product => "product",
                AnalyticsPluginGroupBy.RbacGroupID => "rbac_group_id",
                AnalyticsPluginGroupBy.UserID => "user_id",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
