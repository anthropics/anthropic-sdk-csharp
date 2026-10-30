using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// A dimension to group skill activity by.
/// </summary>
[JsonConverter(typeof(BetaAnalyticsSkillGroupByConverter))]
public enum BetaAnalyticsSkillGroupBy
{
    Product,
    RbacGroupID,
    UserID,
}

sealed class BetaAnalyticsSkillGroupByConverter : JsonConverter<BetaAnalyticsSkillGroupBy>
{
    public override BetaAnalyticsSkillGroupBy Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "product" => BetaAnalyticsSkillGroupBy.Product,
            "rbac_group_id" => BetaAnalyticsSkillGroupBy.RbacGroupID,
            "user_id" => BetaAnalyticsSkillGroupBy.UserID,
            _ => (BetaAnalyticsSkillGroupBy)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaAnalyticsSkillGroupBy value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaAnalyticsSkillGroupBy.Product => "product",
                BetaAnalyticsSkillGroupBy.RbacGroupID => "rbac_group_id",
                BetaAnalyticsSkillGroupBy.UserID => "user_id",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
