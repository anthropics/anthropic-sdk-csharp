using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// A dimension to group chat project activity by.
/// </summary>
[JsonConverter(typeof(BetaAnalyticsProjectGroupByConverter))]
public enum BetaAnalyticsProjectGroupBy
{
    RbacGroupID,
    UserID,
}

sealed class BetaAnalyticsProjectGroupByConverter : JsonConverter<BetaAnalyticsProjectGroupBy>
{
    public override BetaAnalyticsProjectGroupBy Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "rbac_group_id" => BetaAnalyticsProjectGroupBy.RbacGroupID,
            "user_id" => BetaAnalyticsProjectGroupBy.UserID,
            _ => (BetaAnalyticsProjectGroupBy)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsProjectGroupBy value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAnalyticsProjectGroupBy.RbacGroupID => "rbac_group_id",
                BetaAnalyticsProjectGroupBy.UserID => "user_id",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
