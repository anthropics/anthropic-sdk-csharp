using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Analytics;

/// <summary>
/// A dimension to group skill activity by.
/// </summary>
[JsonConverter(typeof(AnalyticsSkillGroupByConverter))]
public enum AnalyticsSkillGroupBy
{
    Product,
    RbacGroupID,
    UserID,
}

sealed class AnalyticsSkillGroupByConverter : JsonConverter<AnalyticsSkillGroupBy>
{
    public override AnalyticsSkillGroupBy Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "product" => AnalyticsSkillGroupBy.Product,
            "rbac_group_id" => AnalyticsSkillGroupBy.RbacGroupID,
            "user_id" => AnalyticsSkillGroupBy.UserID,
            _ => (AnalyticsSkillGroupBy)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AnalyticsSkillGroupBy value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AnalyticsSkillGroupBy.Product => "product",
                AnalyticsSkillGroupBy.RbacGroupID => "rbac_group_id",
                AnalyticsSkillGroupBy.UserID => "user_id",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
