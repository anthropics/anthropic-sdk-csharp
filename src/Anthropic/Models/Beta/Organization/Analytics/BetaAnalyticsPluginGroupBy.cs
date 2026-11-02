using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// A dimension to group plugin activity by.
/// </summary>
[JsonConverter(typeof(BetaAnalyticsPluginGroupByConverter))]
public enum BetaAnalyticsPluginGroupBy
{
    Product,
    RbacGroupID,
    UserID,
}

sealed class BetaAnalyticsPluginGroupByConverter : JsonConverter<BetaAnalyticsPluginGroupBy>
{
    public override BetaAnalyticsPluginGroupBy Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "product" => BetaAnalyticsPluginGroupBy.Product,
            "rbac_group_id" => BetaAnalyticsPluginGroupBy.RbacGroupID,
            "user_id" => BetaAnalyticsPluginGroupBy.UserID,
            _ => (BetaAnalyticsPluginGroupBy)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsPluginGroupBy value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAnalyticsPluginGroupBy.Product => "product",
                BetaAnalyticsPluginGroupBy.RbacGroupID => "rbac_group_id",
                BetaAnalyticsPluginGroupBy.UserID => "user_id",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
