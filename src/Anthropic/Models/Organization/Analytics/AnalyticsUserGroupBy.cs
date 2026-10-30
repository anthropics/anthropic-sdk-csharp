using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Analytics;

/// <summary>
/// A dimension to group user activity by.
/// </summary>
[JsonConverter(typeof(AnalyticsUserGroupByConverter))]
public enum AnalyticsUserGroupBy
{
    RbacGroupID,
}

sealed class AnalyticsUserGroupByConverter : JsonConverter<AnalyticsUserGroupBy>
{
    public override AnalyticsUserGroupBy Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "rbac_group_id" => AnalyticsUserGroupBy.RbacGroupID,
            _ => (AnalyticsUserGroupBy)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AnalyticsUserGroupBy value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AnalyticsUserGroupBy.RbacGroupID => "rbac_group_id",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
