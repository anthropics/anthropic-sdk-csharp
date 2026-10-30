using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// A dimension to group user activity by.
/// </summary>
[JsonConverter(typeof(BetaAnalyticsUserGroupByConverter))]
public enum BetaAnalyticsUserGroupBy
{
    RbacGroupID,
}

sealed class BetaAnalyticsUserGroupByConverter : JsonConverter<BetaAnalyticsUserGroupBy>
{
    public override BetaAnalyticsUserGroupBy Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "rbac_group_id" => BetaAnalyticsUserGroupBy.RbacGroupID,
            _ => (BetaAnalyticsUserGroupBy)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsUserGroupBy value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAnalyticsUserGroupBy.RbacGroupID => "rbac_group_id",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
