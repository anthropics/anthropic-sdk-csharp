using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// A dimension to group artifact activity by.
/// </summary>
[JsonConverter(typeof(BetaAnalyticsArtifactGroupByConverter))]
public enum BetaAnalyticsArtifactGroupBy
{
    Product,
    RbacGroupID,
    UserID,
}

sealed class BetaAnalyticsArtifactGroupByConverter : JsonConverter<BetaAnalyticsArtifactGroupBy>
{
    public override BetaAnalyticsArtifactGroupBy Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "product" => BetaAnalyticsArtifactGroupBy.Product,
            "rbac_group_id" => BetaAnalyticsArtifactGroupBy.RbacGroupID,
            "user_id" => BetaAnalyticsArtifactGroupBy.UserID,
            _ => (BetaAnalyticsArtifactGroupBy)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsArtifactGroupBy value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAnalyticsArtifactGroupBy.Product => "product",
                BetaAnalyticsArtifactGroupBy.RbacGroupID => "rbac_group_id",
                BetaAnalyticsArtifactGroupBy.UserID => "user_id",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
