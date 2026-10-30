using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// A dimension to group connector activity by.
/// </summary>
[JsonConverter(typeof(BetaAnalyticsConnectorGroupByConverter))]
public enum BetaAnalyticsConnectorGroupBy
{
    Product,
    RbacGroupID,
    UserID,
}

sealed class BetaAnalyticsConnectorGroupByConverter : JsonConverter<BetaAnalyticsConnectorGroupBy>
{
    public override BetaAnalyticsConnectorGroupBy Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "product" => BetaAnalyticsConnectorGroupBy.Product,
            "rbac_group_id" => BetaAnalyticsConnectorGroupBy.RbacGroupID,
            "user_id" => BetaAnalyticsConnectorGroupBy.UserID,
            _ => (BetaAnalyticsConnectorGroupBy)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsConnectorGroupBy value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAnalyticsConnectorGroupBy.Product => "product",
                BetaAnalyticsConnectorGroupBy.RbacGroupID => "rbac_group_id",
                BetaAnalyticsConnectorGroupBy.UserID => "user_id",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
