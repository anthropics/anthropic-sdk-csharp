using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Analytics;

/// <summary>
/// A dimension to group chat project activity by.
/// </summary>
[JsonConverter(typeof(AnalyticsProjectGroupByConverter))]
public enum AnalyticsProjectGroupBy
{
    RbacGroupID,
    UserID,
}

sealed class AnalyticsProjectGroupByConverter : JsonConverter<AnalyticsProjectGroupBy>
{
    public override AnalyticsProjectGroupBy Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "rbac_group_id" => AnalyticsProjectGroupBy.RbacGroupID,
            "user_id" => AnalyticsProjectGroupBy.UserID,
            _ => (AnalyticsProjectGroupBy)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AnalyticsProjectGroupBy value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AnalyticsProjectGroupBy.RbacGroupID => "rbac_group_id",
                AnalyticsProjectGroupBy.UserID => "user_id",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
