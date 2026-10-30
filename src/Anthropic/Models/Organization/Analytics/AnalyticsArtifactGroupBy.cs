using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Analytics;

/// <summary>
/// A dimension to group artifact activity by.
/// </summary>
[JsonConverter(typeof(AnalyticsArtifactGroupByConverter))]
public enum AnalyticsArtifactGroupBy
{
    Product,
    RbacGroupID,
    UserID,
}

sealed class AnalyticsArtifactGroupByConverter : JsonConverter<AnalyticsArtifactGroupBy>
{
    public override AnalyticsArtifactGroupBy Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "product" => AnalyticsArtifactGroupBy.Product,
            "rbac_group_id" => AnalyticsArtifactGroupBy.RbacGroupID,
            "user_id" => AnalyticsArtifactGroupBy.UserID,
            _ => (AnalyticsArtifactGroupBy)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AnalyticsArtifactGroupBy value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AnalyticsArtifactGroupBy.Product => "product",
                AnalyticsArtifactGroupBy.RbacGroupID => "rbac_group_id",
                AnalyticsArtifactGroupBy.UserID => "user_id",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
