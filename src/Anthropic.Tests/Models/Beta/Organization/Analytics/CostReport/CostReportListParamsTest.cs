using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Analytics.CostReport;
using Analytics = Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics.CostReport;

public class CostReportListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CostReportListParams
        {
            StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BucketWidth = BucketWidth.Day,
            ClaudeTagCategories = [Analytics::BetaAnalyticsClaudeTagCategory.Engaged],
            ClaudeTagUserIds = ["U0123ABCDEF"],
            ContextWindows = [Analytics::BetaAnalyticsContextWindow.From0To200k],
            EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            GroupBy = [GroupBy.ClaudeTagCategory],
            InferenceGeos = [Analytics::BetaAnalyticsInferenceGeoFilter.Global],
            Limit = 1,
            Models = ["string"],
            Page = "page",
            Products = [Analytics::BetaAnalyticsProductFilter.Chat],
            RbacGroupIds = ["rbac_group_012rppKaSVsmTo6NqRDXQXNF"],
            SlackChannelIds = ["C0123ABCDEF"],
            Speeds = [Speed.Fast],
            UserIds = ["string"],
        };

        DateTimeOffset expectedStartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, BucketWidth> expectedBucketWidth = BucketWidth.Day;
        List<
            ApiEnum<string, Analytics::BetaAnalyticsClaudeTagCategory>
        > expectedClaudeTagCategories = [Analytics::BetaAnalyticsClaudeTagCategory.Engaged];
        List<string> expectedClaudeTagUserIds = ["U0123ABCDEF"];
        List<ApiEnum<string, Analytics::BetaAnalyticsContextWindow>> expectedContextWindows =
        [
            Analytics::BetaAnalyticsContextWindow.From0To200k,
        ];
        DateTimeOffset expectedEndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<ApiEnum<string, GroupBy>> expectedGroupBy = [GroupBy.ClaudeTagCategory];
        List<ApiEnum<string, Analytics::BetaAnalyticsInferenceGeoFilter>> expectedInferenceGeos =
        [
            Analytics::BetaAnalyticsInferenceGeoFilter.Global,
        ];
        long expectedLimit = 1;
        List<string> expectedModels = ["string"];
        string expectedPage = "page";
        List<ApiEnum<string, Analytics::BetaAnalyticsProductFilter>> expectedProducts =
        [
            Analytics::BetaAnalyticsProductFilter.Chat,
        ];
        List<string> expectedRbacGroupIds = ["rbac_group_012rppKaSVsmTo6NqRDXQXNF"];
        List<string> expectedSlackChannelIds = ["C0123ABCDEF"];
        List<ApiEnum<string, Speed>> expectedSpeeds = [Speed.Fast];
        List<string> expectedUserIds = ["string"];

        Assert.Equal(expectedStartingAt, parameters.StartingAt);
        Assert.Equal(expectedBucketWidth, parameters.BucketWidth);
        Assert.NotNull(parameters.ClaudeTagCategories);
        Assert.Equal(expectedClaudeTagCategories.Count, parameters.ClaudeTagCategories.Count);
        for (int i = 0; i < expectedClaudeTagCategories.Count; i++)
        {
            Assert.Equal(expectedClaudeTagCategories[i], parameters.ClaudeTagCategories[i]);
        }
        Assert.NotNull(parameters.ClaudeTagUserIds);
        Assert.Equal(expectedClaudeTagUserIds.Count, parameters.ClaudeTagUserIds.Count);
        for (int i = 0; i < expectedClaudeTagUserIds.Count; i++)
        {
            Assert.Equal(expectedClaudeTagUserIds[i], parameters.ClaudeTagUserIds[i]);
        }
        Assert.NotNull(parameters.ContextWindows);
        Assert.Equal(expectedContextWindows.Count, parameters.ContextWindows.Count);
        for (int i = 0; i < expectedContextWindows.Count; i++)
        {
            Assert.Equal(expectedContextWindows[i], parameters.ContextWindows[i]);
        }
        Assert.Equal(expectedEndingAt, parameters.EndingAt);
        Assert.NotNull(parameters.GroupBy);
        Assert.Equal(expectedGroupBy.Count, parameters.GroupBy.Count);
        for (int i = 0; i < expectedGroupBy.Count; i++)
        {
            Assert.Equal(expectedGroupBy[i], parameters.GroupBy[i]);
        }
        Assert.NotNull(parameters.InferenceGeos);
        Assert.Equal(expectedInferenceGeos.Count, parameters.InferenceGeos.Count);
        for (int i = 0; i < expectedInferenceGeos.Count; i++)
        {
            Assert.Equal(expectedInferenceGeos[i], parameters.InferenceGeos[i]);
        }
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.NotNull(parameters.Models);
        Assert.Equal(expectedModels.Count, parameters.Models.Count);
        for (int i = 0; i < expectedModels.Count; i++)
        {
            Assert.Equal(expectedModels[i], parameters.Models[i]);
        }
        Assert.Equal(expectedPage, parameters.Page);
        Assert.NotNull(parameters.Products);
        Assert.Equal(expectedProducts.Count, parameters.Products.Count);
        for (int i = 0; i < expectedProducts.Count; i++)
        {
            Assert.Equal(expectedProducts[i], parameters.Products[i]);
        }
        Assert.NotNull(parameters.RbacGroupIds);
        Assert.Equal(expectedRbacGroupIds.Count, parameters.RbacGroupIds.Count);
        for (int i = 0; i < expectedRbacGroupIds.Count; i++)
        {
            Assert.Equal(expectedRbacGroupIds[i], parameters.RbacGroupIds[i]);
        }
        Assert.NotNull(parameters.SlackChannelIds);
        Assert.Equal(expectedSlackChannelIds.Count, parameters.SlackChannelIds.Count);
        for (int i = 0; i < expectedSlackChannelIds.Count; i++)
        {
            Assert.Equal(expectedSlackChannelIds[i], parameters.SlackChannelIds[i]);
        }
        Assert.NotNull(parameters.Speeds);
        Assert.Equal(expectedSpeeds.Count, parameters.Speeds.Count);
        for (int i = 0; i < expectedSpeeds.Count; i++)
        {
            Assert.Equal(expectedSpeeds[i], parameters.Speeds[i]);
        }
        Assert.NotNull(parameters.UserIds);
        Assert.Equal(expectedUserIds.Count, parameters.UserIds.Count);
        for (int i = 0; i < expectedUserIds.Count; i++)
        {
            Assert.Equal(expectedUserIds[i], parameters.UserIds[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CostReportListParams
        {
            StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ClaudeTagCategories = [Analytics::BetaAnalyticsClaudeTagCategory.Engaged],
            ClaudeTagUserIds = ["U0123ABCDEF"],
            ContextWindows = [Analytics::BetaAnalyticsContextWindow.From0To200k],
            EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            GroupBy = [GroupBy.ClaudeTagCategory],
            InferenceGeos = [Analytics::BetaAnalyticsInferenceGeoFilter.Global],
            Limit = 1,
            Models = ["string"],
            Page = "page",
            Products = [Analytics::BetaAnalyticsProductFilter.Chat],
            RbacGroupIds = ["rbac_group_012rppKaSVsmTo6NqRDXQXNF"],
            SlackChannelIds = ["C0123ABCDEF"],
            Speeds = [Speed.Fast],
            UserIds = ["string"],
        };

        Assert.Null(parameters.BucketWidth);
        Assert.False(parameters.RawQueryData.ContainsKey("bucket_width"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CostReportListParams
        {
            StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ClaudeTagCategories = [Analytics::BetaAnalyticsClaudeTagCategory.Engaged],
            ClaudeTagUserIds = ["U0123ABCDEF"],
            ContextWindows = [Analytics::BetaAnalyticsContextWindow.From0To200k],
            EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            GroupBy = [GroupBy.ClaudeTagCategory],
            InferenceGeos = [Analytics::BetaAnalyticsInferenceGeoFilter.Global],
            Limit = 1,
            Models = ["string"],
            Page = "page",
            Products = [Analytics::BetaAnalyticsProductFilter.Chat],
            RbacGroupIds = ["rbac_group_012rppKaSVsmTo6NqRDXQXNF"],
            SlackChannelIds = ["C0123ABCDEF"],
            Speeds = [Speed.Fast],
            UserIds = ["string"],

            // Null should be interpreted as omitted for these properties
            BucketWidth = null,
        };

        Assert.Null(parameters.BucketWidth);
        Assert.False(parameters.RawQueryData.ContainsKey("bucket_width"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullInWithAreUnset_Works()
    {
        var parameters = new CostReportListParams
        {
            StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BucketWidth = BucketWidth.Day,
            ClaudeTagCategories = [Analytics::BetaAnalyticsClaudeTagCategory.Engaged],
            ClaudeTagUserIds = ["U0123ABCDEF"],
            ContextWindows = [Analytics::BetaAnalyticsContextWindow.From0To200k],
            EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            GroupBy = [GroupBy.ClaudeTagCategory],
            InferenceGeos = [Analytics::BetaAnalyticsInferenceGeoFilter.Global],
            Limit = 1,
            Models = ["string"],
            Page = "page",
            Products = [Analytics::BetaAnalyticsProductFilter.Chat],
            RbacGroupIds = ["rbac_group_012rppKaSVsmTo6NqRDXQXNF"],
            SlackChannelIds = ["C0123ABCDEF"],
            Speeds = [Speed.Fast],
            UserIds = ["string"],
        } with
        {
            // Null should be interpreted as omitted for these properties
            BucketWidth = null,
        };

        Assert.Null(parameters.BucketWidth);
        Assert.False(parameters.RawQueryData.ContainsKey("bucket_width"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CostReportListParams
        {
            StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BucketWidth = BucketWidth.Day,
        };

        Assert.Null(parameters.ClaudeTagCategories);
        Assert.False(parameters.RawQueryData.ContainsKey("claude_tag_categories"));
        Assert.Null(parameters.ClaudeTagUserIds);
        Assert.False(parameters.RawQueryData.ContainsKey("claude_tag_user_ids"));
        Assert.Null(parameters.ContextWindows);
        Assert.False(parameters.RawQueryData.ContainsKey("context_windows"));
        Assert.Null(parameters.EndingAt);
        Assert.False(parameters.RawQueryData.ContainsKey("ending_at"));
        Assert.Null(parameters.GroupBy);
        Assert.False(parameters.RawQueryData.ContainsKey("group_by"));
        Assert.Null(parameters.InferenceGeos);
        Assert.False(parameters.RawQueryData.ContainsKey("inference_geos"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Models);
        Assert.False(parameters.RawQueryData.ContainsKey("models"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Products);
        Assert.False(parameters.RawQueryData.ContainsKey("products"));
        Assert.Null(parameters.RbacGroupIds);
        Assert.False(parameters.RawQueryData.ContainsKey("rbac_group_ids"));
        Assert.Null(parameters.SlackChannelIds);
        Assert.False(parameters.RawQueryData.ContainsKey("slack_channel_ids"));
        Assert.Null(parameters.Speeds);
        Assert.False(parameters.RawQueryData.ContainsKey("speeds"));
        Assert.Null(parameters.UserIds);
        Assert.False(parameters.RawQueryData.ContainsKey("user_ids"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new CostReportListParams
        {
            StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BucketWidth = BucketWidth.Day,

            ClaudeTagCategories = null,
            ClaudeTagUserIds = null,
            ContextWindows = null,
            EndingAt = null,
            GroupBy = null,
            InferenceGeos = null,
            Limit = null,
            Models = null,
            Page = null,
            Products = null,
            RbacGroupIds = null,
            SlackChannelIds = null,
            Speeds = null,
            UserIds = null,
        };

        Assert.Null(parameters.ClaudeTagCategories);
        Assert.True(parameters.RawQueryData.ContainsKey("claude_tag_categories"));
        Assert.Null(parameters.ClaudeTagUserIds);
        Assert.True(parameters.RawQueryData.ContainsKey("claude_tag_user_ids"));
        Assert.Null(parameters.ContextWindows);
        Assert.True(parameters.RawQueryData.ContainsKey("context_windows"));
        Assert.Null(parameters.EndingAt);
        Assert.True(parameters.RawQueryData.ContainsKey("ending_at"));
        Assert.Null(parameters.GroupBy);
        Assert.True(parameters.RawQueryData.ContainsKey("group_by"));
        Assert.Null(parameters.InferenceGeos);
        Assert.True(parameters.RawQueryData.ContainsKey("inference_geos"));
        Assert.Null(parameters.Limit);
        Assert.True(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Models);
        Assert.True(parameters.RawQueryData.ContainsKey("models"));
        Assert.Null(parameters.Page);
        Assert.True(parameters.RawQueryData.ContainsKey("page"));
        Assert.Null(parameters.Products);
        Assert.True(parameters.RawQueryData.ContainsKey("products"));
        Assert.Null(parameters.RbacGroupIds);
        Assert.True(parameters.RawQueryData.ContainsKey("rbac_group_ids"));
        Assert.Null(parameters.SlackChannelIds);
        Assert.True(parameters.RawQueryData.ContainsKey("slack_channel_ids"));
        Assert.Null(parameters.Speeds);
        Assert.True(parameters.RawQueryData.ContainsKey("speeds"));
        Assert.Null(parameters.UserIds);
        Assert.True(parameters.RawQueryData.ContainsKey("user_ids"));
    }

    [Fact]
    public void Url_Works()
    {
        CostReportListParams parameters = new()
        {
            StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            BucketWidth = BucketWidth.Day,
            ClaudeTagCategories = [Analytics::BetaAnalyticsClaudeTagCategory.Engaged],
            ClaudeTagUserIds = ["U0123ABCDEF"],
            ContextWindows = [Analytics::BetaAnalyticsContextWindow.From0To200k],
            EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            GroupBy = [GroupBy.ClaudeTagCategory],
            InferenceGeos = [Analytics::BetaAnalyticsInferenceGeoFilter.Global],
            Limit = 1,
            Models = ["string"],
            Page = "page",
            Products = [Analytics::BetaAnalyticsProductFilter.Chat],
            RbacGroupIds = ["rbac_group_012rppKaSVsmTo6NqRDXQXNF"],
            SlackChannelIds = ["C0123ABCDEF"],
            Speeds = [Speed.Fast],
            UserIds = ["string"],
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/analytics/cost_report?beta=true&starting_at=2019-12-27T18%3a11%3a19.117%2b00%3a00&bucket_width=1d&claude_tag_categories%5b%5d=engaged&claude_tag_user_ids%5b%5d=U0123ABCDEF&context_windows%5b%5d=0-200k&ending_at=2019-12-27T18%3a11%3a19.117%2b00%3a00&group_by%5b%5d=claude_tag_category&inference_geos%5b%5d=global&limit=1&models%5b%5d=string&page=page&products%5b%5d=chat&rbac_group_ids%5b%5d=rbac_group_012rppKaSVsmTo6NqRDXQXNF&slack_channel_ids%5b%5d=C0123ABCDEF&speeds%5b%5d=fast&user_ids%5b%5d=string"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CostReportListParams
        {
            StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BucketWidth = BucketWidth.Day,
            ClaudeTagCategories = [Analytics::BetaAnalyticsClaudeTagCategory.Engaged],
            ClaudeTagUserIds = ["U0123ABCDEF"],
            ContextWindows = [Analytics::BetaAnalyticsContextWindow.From0To200k],
            EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            GroupBy = [GroupBy.ClaudeTagCategory],
            InferenceGeos = [Analytics::BetaAnalyticsInferenceGeoFilter.Global],
            Limit = 1,
            Models = ["string"],
            Page = "page",
            Products = [Analytics::BetaAnalyticsProductFilter.Chat],
            RbacGroupIds = ["rbac_group_012rppKaSVsmTo6NqRDXQXNF"],
            SlackChannelIds = ["C0123ABCDEF"],
            Speeds = [Speed.Fast],
            UserIds = ["string"],
        };

        CostReportListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class BucketWidthTest : TestBase
{
    [Theory]
    [InlineData(BucketWidth.Day)]
    [InlineData(BucketWidth.Hour)]
    [InlineData(BucketWidth.Minute)]
    public void Validation_Works(BucketWidth rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BucketWidth> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BucketWidth>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BucketWidth.Day)]
    [InlineData(BucketWidth.Hour)]
    [InlineData(BucketWidth.Minute)]
    public void SerializationRoundtrip_Works(BucketWidth rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BucketWidth> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BucketWidth>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BucketWidth>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BucketWidth>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class GroupByTest : TestBase
{
    [Theory]
    [InlineData(GroupBy.ClaudeTagCategory)]
    [InlineData(GroupBy.ClaudeTagUserID)]
    [InlineData(GroupBy.ContextWindow)]
    [InlineData(GroupBy.CostType)]
    [InlineData(GroupBy.InferenceGeo)]
    [InlineData(GroupBy.Model)]
    [InlineData(GroupBy.Product)]
    [InlineData(GroupBy.RbacGroupID)]
    [InlineData(GroupBy.SlackChannelID)]
    [InlineData(GroupBy.Speed)]
    [InlineData(GroupBy.TokenType)]
    public void Validation_Works(GroupBy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GroupBy> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GroupBy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(GroupBy.ClaudeTagCategory)]
    [InlineData(GroupBy.ClaudeTagUserID)]
    [InlineData(GroupBy.ContextWindow)]
    [InlineData(GroupBy.CostType)]
    [InlineData(GroupBy.InferenceGeo)]
    [InlineData(GroupBy.Model)]
    [InlineData(GroupBy.Product)]
    [InlineData(GroupBy.RbacGroupID)]
    [InlineData(GroupBy.SlackChannelID)]
    [InlineData(GroupBy.Speed)]
    [InlineData(GroupBy.TokenType)]
    public void SerializationRoundtrip_Works(GroupBy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GroupBy> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GroupBy>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GroupBy>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GroupBy>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SpeedTest : TestBase
{
    [Theory]
    [InlineData(Speed.Fast)]
    [InlineData(Speed.Standard)]
    public void Validation_Works(Speed rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Speed> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Speed>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Speed.Fast)]
    [InlineData(Speed.Standard)]
    public void SerializationRoundtrip_Works(Speed rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Speed> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Speed>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Speed>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Speed>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
