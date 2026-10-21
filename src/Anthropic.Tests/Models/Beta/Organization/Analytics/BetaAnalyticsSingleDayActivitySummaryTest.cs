using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsSingleDayActivitySummaryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsSingleDayActivitySummary
        {
            AssignedSeatCount = 0,
            CoworkDailyActiveUserCount = 0,
            CoworkMonthlyActiveUserCount = 0,
            CoworkWeeklyActiveUserCount = 0,
            DailyActiveUserCount = 0,
            DailyAdoptionRate = 0,
            EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MonthlyActiveUserCount = 0,
            MonthlyAdoptionRate = 0,
            PendingInviteCount = 0,
            StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WeeklyActiveUserCount = 0,
            WeeklyAdoptionRate = 0,
            ChatCoworkUnifiedDailyActiveUserCount = 0,
            ChatCoworkUnifiedMonthlyActiveUserCount = 0,
            ChatCoworkUnifiedWeeklyActiveUserCount = 0,
            ChatDailyActiveUserCount = 0,
            ChatMonthlyActiveUserCount = 0,
            ChatWeeklyActiveUserCount = 0,
            ClaudeCodeDailyActiveUserCount = 0,
            ClaudeCodeMonthlyActiveUserCount = 0,
            ClaudeCodeWeeklyActiveUserCount = 0,
            ClaudeDesignDailyActiveUserCount = 0,
            ClaudeDesignMonthlyActiveUserCount = 0,
            ClaudeDesignWeeklyActiveUserCount = 0,
            OfficeAgentDailyActiveUserCount = 0,
            OfficeAgentMonthlyActiveUserCount = 0,
            OfficeAgentWeeklyActiveUserCount = 0,
            ScienceDailyActiveUserCount = 0,
            ScienceEntitledUserCount = 0,
            ScienceMonthlyActiveUserCount = 0,
            ScienceWeeklyActiveUserCount = 0,
        };

        long expectedAssignedSeatCount = 0;
        long expectedCoworkDailyActiveUserCount = 0;
        long expectedCoworkMonthlyActiveUserCount = 0;
        long expectedCoworkWeeklyActiveUserCount = 0;
        long expectedDailyActiveUserCount = 0;
        double expectedDailyAdoptionRate = 0;
        DateTimeOffset expectedEndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedMonthlyActiveUserCount = 0;
        double expectedMonthlyAdoptionRate = 0;
        long expectedPendingInviteCount = 0;
        DateTimeOffset expectedStartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedWeeklyActiveUserCount = 0;
        double expectedWeeklyAdoptionRate = 0;
        long expectedChatCoworkUnifiedDailyActiveUserCount = 0;
        long expectedChatCoworkUnifiedMonthlyActiveUserCount = 0;
        long expectedChatCoworkUnifiedWeeklyActiveUserCount = 0;
        long expectedChatDailyActiveUserCount = 0;
        long expectedChatMonthlyActiveUserCount = 0;
        long expectedChatWeeklyActiveUserCount = 0;
        long expectedClaudeCodeDailyActiveUserCount = 0;
        long expectedClaudeCodeMonthlyActiveUserCount = 0;
        long expectedClaudeCodeWeeklyActiveUserCount = 0;
        long expectedClaudeDesignDailyActiveUserCount = 0;
        long expectedClaudeDesignMonthlyActiveUserCount = 0;
        long expectedClaudeDesignWeeklyActiveUserCount = 0;
        long expectedOfficeAgentDailyActiveUserCount = 0;
        long expectedOfficeAgentMonthlyActiveUserCount = 0;
        long expectedOfficeAgentWeeklyActiveUserCount = 0;
        long expectedScienceDailyActiveUserCount = 0;
        long expectedScienceEntitledUserCount = 0;
        long expectedScienceMonthlyActiveUserCount = 0;
        long expectedScienceWeeklyActiveUserCount = 0;

        Assert.Equal(expectedAssignedSeatCount, model.AssignedSeatCount);
        Assert.Equal(expectedCoworkDailyActiveUserCount, model.CoworkDailyActiveUserCount);
        Assert.Equal(expectedCoworkMonthlyActiveUserCount, model.CoworkMonthlyActiveUserCount);
        Assert.Equal(expectedCoworkWeeklyActiveUserCount, model.CoworkWeeklyActiveUserCount);
        Assert.Equal(expectedDailyActiveUserCount, model.DailyActiveUserCount);
        Assert.Equal(expectedDailyAdoptionRate, model.DailyAdoptionRate);
        Assert.Equal(expectedEndingAt, model.EndingAt);
        Assert.Equal(expectedMonthlyActiveUserCount, model.MonthlyActiveUserCount);
        Assert.Equal(expectedMonthlyAdoptionRate, model.MonthlyAdoptionRate);
        Assert.Equal(expectedPendingInviteCount, model.PendingInviteCount);
        Assert.Equal(expectedStartingAt, model.StartingAt);
        Assert.Equal(expectedWeeklyActiveUserCount, model.WeeklyActiveUserCount);
        Assert.Equal(expectedWeeklyAdoptionRate, model.WeeklyAdoptionRate);
        Assert.Equal(
            expectedChatCoworkUnifiedDailyActiveUserCount,
            model.ChatCoworkUnifiedDailyActiveUserCount
        );
        Assert.Equal(
            expectedChatCoworkUnifiedMonthlyActiveUserCount,
            model.ChatCoworkUnifiedMonthlyActiveUserCount
        );
        Assert.Equal(
            expectedChatCoworkUnifiedWeeklyActiveUserCount,
            model.ChatCoworkUnifiedWeeklyActiveUserCount
        );
        Assert.Equal(expectedChatDailyActiveUserCount, model.ChatDailyActiveUserCount);
        Assert.Equal(expectedChatMonthlyActiveUserCount, model.ChatMonthlyActiveUserCount);
        Assert.Equal(expectedChatWeeklyActiveUserCount, model.ChatWeeklyActiveUserCount);
        Assert.Equal(expectedClaudeCodeDailyActiveUserCount, model.ClaudeCodeDailyActiveUserCount);
        Assert.Equal(
            expectedClaudeCodeMonthlyActiveUserCount,
            model.ClaudeCodeMonthlyActiveUserCount
        );
        Assert.Equal(
            expectedClaudeCodeWeeklyActiveUserCount,
            model.ClaudeCodeWeeklyActiveUserCount
        );
        Assert.Equal(
            expectedClaudeDesignDailyActiveUserCount,
            model.ClaudeDesignDailyActiveUserCount
        );
        Assert.Equal(
            expectedClaudeDesignMonthlyActiveUserCount,
            model.ClaudeDesignMonthlyActiveUserCount
        );
        Assert.Equal(
            expectedClaudeDesignWeeklyActiveUserCount,
            model.ClaudeDesignWeeklyActiveUserCount
        );
        Assert.Equal(
            expectedOfficeAgentDailyActiveUserCount,
            model.OfficeAgentDailyActiveUserCount
        );
        Assert.Equal(
            expectedOfficeAgentMonthlyActiveUserCount,
            model.OfficeAgentMonthlyActiveUserCount
        );
        Assert.Equal(
            expectedOfficeAgentWeeklyActiveUserCount,
            model.OfficeAgentWeeklyActiveUserCount
        );
        Assert.Equal(expectedScienceDailyActiveUserCount, model.ScienceDailyActiveUserCount);
        Assert.Equal(expectedScienceEntitledUserCount, model.ScienceEntitledUserCount);
        Assert.Equal(expectedScienceMonthlyActiveUserCount, model.ScienceMonthlyActiveUserCount);
        Assert.Equal(expectedScienceWeeklyActiveUserCount, model.ScienceWeeklyActiveUserCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsSingleDayActivitySummary
        {
            AssignedSeatCount = 0,
            CoworkDailyActiveUserCount = 0,
            CoworkMonthlyActiveUserCount = 0,
            CoworkWeeklyActiveUserCount = 0,
            DailyActiveUserCount = 0,
            DailyAdoptionRate = 0,
            EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MonthlyActiveUserCount = 0,
            MonthlyAdoptionRate = 0,
            PendingInviteCount = 0,
            StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WeeklyActiveUserCount = 0,
            WeeklyAdoptionRate = 0,
            ChatCoworkUnifiedDailyActiveUserCount = 0,
            ChatCoworkUnifiedMonthlyActiveUserCount = 0,
            ChatCoworkUnifiedWeeklyActiveUserCount = 0,
            ChatDailyActiveUserCount = 0,
            ChatMonthlyActiveUserCount = 0,
            ChatWeeklyActiveUserCount = 0,
            ClaudeCodeDailyActiveUserCount = 0,
            ClaudeCodeMonthlyActiveUserCount = 0,
            ClaudeCodeWeeklyActiveUserCount = 0,
            ClaudeDesignDailyActiveUserCount = 0,
            ClaudeDesignMonthlyActiveUserCount = 0,
            ClaudeDesignWeeklyActiveUserCount = 0,
            OfficeAgentDailyActiveUserCount = 0,
            OfficeAgentMonthlyActiveUserCount = 0,
            OfficeAgentWeeklyActiveUserCount = 0,
            ScienceDailyActiveUserCount = 0,
            ScienceEntitledUserCount = 0,
            ScienceMonthlyActiveUserCount = 0,
            ScienceWeeklyActiveUserCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsSingleDayActivitySummary>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsSingleDayActivitySummary
        {
            AssignedSeatCount = 0,
            CoworkDailyActiveUserCount = 0,
            CoworkMonthlyActiveUserCount = 0,
            CoworkWeeklyActiveUserCount = 0,
            DailyActiveUserCount = 0,
            DailyAdoptionRate = 0,
            EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MonthlyActiveUserCount = 0,
            MonthlyAdoptionRate = 0,
            PendingInviteCount = 0,
            StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WeeklyActiveUserCount = 0,
            WeeklyAdoptionRate = 0,
            ChatCoworkUnifiedDailyActiveUserCount = 0,
            ChatCoworkUnifiedMonthlyActiveUserCount = 0,
            ChatCoworkUnifiedWeeklyActiveUserCount = 0,
            ChatDailyActiveUserCount = 0,
            ChatMonthlyActiveUserCount = 0,
            ChatWeeklyActiveUserCount = 0,
            ClaudeCodeDailyActiveUserCount = 0,
            ClaudeCodeMonthlyActiveUserCount = 0,
            ClaudeCodeWeeklyActiveUserCount = 0,
            ClaudeDesignDailyActiveUserCount = 0,
            ClaudeDesignMonthlyActiveUserCount = 0,
            ClaudeDesignWeeklyActiveUserCount = 0,
            OfficeAgentDailyActiveUserCount = 0,
            OfficeAgentMonthlyActiveUserCount = 0,
            OfficeAgentWeeklyActiveUserCount = 0,
            ScienceDailyActiveUserCount = 0,
            ScienceEntitledUserCount = 0,
            ScienceMonthlyActiveUserCount = 0,
            ScienceWeeklyActiveUserCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsSingleDayActivitySummary>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAssignedSeatCount = 0;
        long expectedCoworkDailyActiveUserCount = 0;
        long expectedCoworkMonthlyActiveUserCount = 0;
        long expectedCoworkWeeklyActiveUserCount = 0;
        long expectedDailyActiveUserCount = 0;
        double expectedDailyAdoptionRate = 0;
        DateTimeOffset expectedEndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedMonthlyActiveUserCount = 0;
        double expectedMonthlyAdoptionRate = 0;
        long expectedPendingInviteCount = 0;
        DateTimeOffset expectedStartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedWeeklyActiveUserCount = 0;
        double expectedWeeklyAdoptionRate = 0;
        long expectedChatCoworkUnifiedDailyActiveUserCount = 0;
        long expectedChatCoworkUnifiedMonthlyActiveUserCount = 0;
        long expectedChatCoworkUnifiedWeeklyActiveUserCount = 0;
        long expectedChatDailyActiveUserCount = 0;
        long expectedChatMonthlyActiveUserCount = 0;
        long expectedChatWeeklyActiveUserCount = 0;
        long expectedClaudeCodeDailyActiveUserCount = 0;
        long expectedClaudeCodeMonthlyActiveUserCount = 0;
        long expectedClaudeCodeWeeklyActiveUserCount = 0;
        long expectedClaudeDesignDailyActiveUserCount = 0;
        long expectedClaudeDesignMonthlyActiveUserCount = 0;
        long expectedClaudeDesignWeeklyActiveUserCount = 0;
        long expectedOfficeAgentDailyActiveUserCount = 0;
        long expectedOfficeAgentMonthlyActiveUserCount = 0;
        long expectedOfficeAgentWeeklyActiveUserCount = 0;
        long expectedScienceDailyActiveUserCount = 0;
        long expectedScienceEntitledUserCount = 0;
        long expectedScienceMonthlyActiveUserCount = 0;
        long expectedScienceWeeklyActiveUserCount = 0;

        Assert.Equal(expectedAssignedSeatCount, deserialized.AssignedSeatCount);
        Assert.Equal(expectedCoworkDailyActiveUserCount, deserialized.CoworkDailyActiveUserCount);
        Assert.Equal(
            expectedCoworkMonthlyActiveUserCount,
            deserialized.CoworkMonthlyActiveUserCount
        );
        Assert.Equal(expectedCoworkWeeklyActiveUserCount, deserialized.CoworkWeeklyActiveUserCount);
        Assert.Equal(expectedDailyActiveUserCount, deserialized.DailyActiveUserCount);
        Assert.Equal(expectedDailyAdoptionRate, deserialized.DailyAdoptionRate);
        Assert.Equal(expectedEndingAt, deserialized.EndingAt);
        Assert.Equal(expectedMonthlyActiveUserCount, deserialized.MonthlyActiveUserCount);
        Assert.Equal(expectedMonthlyAdoptionRate, deserialized.MonthlyAdoptionRate);
        Assert.Equal(expectedPendingInviteCount, deserialized.PendingInviteCount);
        Assert.Equal(expectedStartingAt, deserialized.StartingAt);
        Assert.Equal(expectedWeeklyActiveUserCount, deserialized.WeeklyActiveUserCount);
        Assert.Equal(expectedWeeklyAdoptionRate, deserialized.WeeklyAdoptionRate);
        Assert.Equal(
            expectedChatCoworkUnifiedDailyActiveUserCount,
            deserialized.ChatCoworkUnifiedDailyActiveUserCount
        );
        Assert.Equal(
            expectedChatCoworkUnifiedMonthlyActiveUserCount,
            deserialized.ChatCoworkUnifiedMonthlyActiveUserCount
        );
        Assert.Equal(
            expectedChatCoworkUnifiedWeeklyActiveUserCount,
            deserialized.ChatCoworkUnifiedWeeklyActiveUserCount
        );
        Assert.Equal(expectedChatDailyActiveUserCount, deserialized.ChatDailyActiveUserCount);
        Assert.Equal(expectedChatMonthlyActiveUserCount, deserialized.ChatMonthlyActiveUserCount);
        Assert.Equal(expectedChatWeeklyActiveUserCount, deserialized.ChatWeeklyActiveUserCount);
        Assert.Equal(
            expectedClaudeCodeDailyActiveUserCount,
            deserialized.ClaudeCodeDailyActiveUserCount
        );
        Assert.Equal(
            expectedClaudeCodeMonthlyActiveUserCount,
            deserialized.ClaudeCodeMonthlyActiveUserCount
        );
        Assert.Equal(
            expectedClaudeCodeWeeklyActiveUserCount,
            deserialized.ClaudeCodeWeeklyActiveUserCount
        );
        Assert.Equal(
            expectedClaudeDesignDailyActiveUserCount,
            deserialized.ClaudeDesignDailyActiveUserCount
        );
        Assert.Equal(
            expectedClaudeDesignMonthlyActiveUserCount,
            deserialized.ClaudeDesignMonthlyActiveUserCount
        );
        Assert.Equal(
            expectedClaudeDesignWeeklyActiveUserCount,
            deserialized.ClaudeDesignWeeklyActiveUserCount
        );
        Assert.Equal(
            expectedOfficeAgentDailyActiveUserCount,
            deserialized.OfficeAgentDailyActiveUserCount
        );
        Assert.Equal(
            expectedOfficeAgentMonthlyActiveUserCount,
            deserialized.OfficeAgentMonthlyActiveUserCount
        );
        Assert.Equal(
            expectedOfficeAgentWeeklyActiveUserCount,
            deserialized.OfficeAgentWeeklyActiveUserCount
        );
        Assert.Equal(expectedScienceDailyActiveUserCount, deserialized.ScienceDailyActiveUserCount);
        Assert.Equal(expectedScienceEntitledUserCount, deserialized.ScienceEntitledUserCount);
        Assert.Equal(
            expectedScienceMonthlyActiveUserCount,
            deserialized.ScienceMonthlyActiveUserCount
        );
        Assert.Equal(
            expectedScienceWeeklyActiveUserCount,
            deserialized.ScienceWeeklyActiveUserCount
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsSingleDayActivitySummary
        {
            AssignedSeatCount = 0,
            CoworkDailyActiveUserCount = 0,
            CoworkMonthlyActiveUserCount = 0,
            CoworkWeeklyActiveUserCount = 0,
            DailyActiveUserCount = 0,
            DailyAdoptionRate = 0,
            EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MonthlyActiveUserCount = 0,
            MonthlyAdoptionRate = 0,
            PendingInviteCount = 0,
            StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WeeklyActiveUserCount = 0,
            WeeklyAdoptionRate = 0,
            ChatCoworkUnifiedDailyActiveUserCount = 0,
            ChatCoworkUnifiedMonthlyActiveUserCount = 0,
            ChatCoworkUnifiedWeeklyActiveUserCount = 0,
            ChatDailyActiveUserCount = 0,
            ChatMonthlyActiveUserCount = 0,
            ChatWeeklyActiveUserCount = 0,
            ClaudeCodeDailyActiveUserCount = 0,
            ClaudeCodeMonthlyActiveUserCount = 0,
            ClaudeCodeWeeklyActiveUserCount = 0,
            ClaudeDesignDailyActiveUserCount = 0,
            ClaudeDesignMonthlyActiveUserCount = 0,
            ClaudeDesignWeeklyActiveUserCount = 0,
            OfficeAgentDailyActiveUserCount = 0,
            OfficeAgentMonthlyActiveUserCount = 0,
            OfficeAgentWeeklyActiveUserCount = 0,
            ScienceDailyActiveUserCount = 0,
            ScienceEntitledUserCount = 0,
            ScienceMonthlyActiveUserCount = 0,
            ScienceWeeklyActiveUserCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaAnalyticsSingleDayActivitySummary
        {
            AssignedSeatCount = 0,
            CoworkDailyActiveUserCount = 0,
            CoworkMonthlyActiveUserCount = 0,
            CoworkWeeklyActiveUserCount = 0,
            DailyActiveUserCount = 0,
            DailyAdoptionRate = 0,
            EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MonthlyActiveUserCount = 0,
            MonthlyAdoptionRate = 0,
            PendingInviteCount = 0,
            StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WeeklyActiveUserCount = 0,
            WeeklyAdoptionRate = 0,
        };

        Assert.Null(model.ChatCoworkUnifiedDailyActiveUserCount);
        Assert.False(model.RawData.ContainsKey("chat_cowork_unified_daily_active_user_count"));
        Assert.Null(model.ChatCoworkUnifiedMonthlyActiveUserCount);
        Assert.False(model.RawData.ContainsKey("chat_cowork_unified_monthly_active_user_count"));
        Assert.Null(model.ChatCoworkUnifiedWeeklyActiveUserCount);
        Assert.False(model.RawData.ContainsKey("chat_cowork_unified_weekly_active_user_count"));
        Assert.Null(model.ChatDailyActiveUserCount);
        Assert.False(model.RawData.ContainsKey("chat_daily_active_user_count"));
        Assert.Null(model.ChatMonthlyActiveUserCount);
        Assert.False(model.RawData.ContainsKey("chat_monthly_active_user_count"));
        Assert.Null(model.ChatWeeklyActiveUserCount);
        Assert.False(model.RawData.ContainsKey("chat_weekly_active_user_count"));
        Assert.Null(model.ClaudeCodeDailyActiveUserCount);
        Assert.False(model.RawData.ContainsKey("claude_code_daily_active_user_count"));
        Assert.Null(model.ClaudeCodeMonthlyActiveUserCount);
        Assert.False(model.RawData.ContainsKey("claude_code_monthly_active_user_count"));
        Assert.Null(model.ClaudeCodeWeeklyActiveUserCount);
        Assert.False(model.RawData.ContainsKey("claude_code_weekly_active_user_count"));
        Assert.Null(model.ClaudeDesignDailyActiveUserCount);
        Assert.False(model.RawData.ContainsKey("claude_design_daily_active_user_count"));
        Assert.Null(model.ClaudeDesignMonthlyActiveUserCount);
        Assert.False(model.RawData.ContainsKey("claude_design_monthly_active_user_count"));
        Assert.Null(model.ClaudeDesignWeeklyActiveUserCount);
        Assert.False(model.RawData.ContainsKey("claude_design_weekly_active_user_count"));
        Assert.Null(model.OfficeAgentDailyActiveUserCount);
        Assert.False(model.RawData.ContainsKey("office_agent_daily_active_user_count"));
        Assert.Null(model.OfficeAgentMonthlyActiveUserCount);
        Assert.False(model.RawData.ContainsKey("office_agent_monthly_active_user_count"));
        Assert.Null(model.OfficeAgentWeeklyActiveUserCount);
        Assert.False(model.RawData.ContainsKey("office_agent_weekly_active_user_count"));
        Assert.Null(model.ScienceDailyActiveUserCount);
        Assert.False(model.RawData.ContainsKey("science_daily_active_user_count"));
        Assert.Null(model.ScienceEntitledUserCount);
        Assert.False(model.RawData.ContainsKey("science_entitled_user_count"));
        Assert.Null(model.ScienceMonthlyActiveUserCount);
        Assert.False(model.RawData.ContainsKey("science_monthly_active_user_count"));
        Assert.Null(model.ScienceWeeklyActiveUserCount);
        Assert.False(model.RawData.ContainsKey("science_weekly_active_user_count"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaAnalyticsSingleDayActivitySummary
        {
            AssignedSeatCount = 0,
            CoworkDailyActiveUserCount = 0,
            CoworkMonthlyActiveUserCount = 0,
            CoworkWeeklyActiveUserCount = 0,
            DailyActiveUserCount = 0,
            DailyAdoptionRate = 0,
            EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MonthlyActiveUserCount = 0,
            MonthlyAdoptionRate = 0,
            PendingInviteCount = 0,
            StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WeeklyActiveUserCount = 0,
            WeeklyAdoptionRate = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaAnalyticsSingleDayActivitySummary
        {
            AssignedSeatCount = 0,
            CoworkDailyActiveUserCount = 0,
            CoworkMonthlyActiveUserCount = 0,
            CoworkWeeklyActiveUserCount = 0,
            DailyActiveUserCount = 0,
            DailyAdoptionRate = 0,
            EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MonthlyActiveUserCount = 0,
            MonthlyAdoptionRate = 0,
            PendingInviteCount = 0,
            StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WeeklyActiveUserCount = 0,
            WeeklyAdoptionRate = 0,

            ChatCoworkUnifiedDailyActiveUserCount = null,
            ChatCoworkUnifiedMonthlyActiveUserCount = null,
            ChatCoworkUnifiedWeeklyActiveUserCount = null,
            ChatDailyActiveUserCount = null,
            ChatMonthlyActiveUserCount = null,
            ChatWeeklyActiveUserCount = null,
            ClaudeCodeDailyActiveUserCount = null,
            ClaudeCodeMonthlyActiveUserCount = null,
            ClaudeCodeWeeklyActiveUserCount = null,
            ClaudeDesignDailyActiveUserCount = null,
            ClaudeDesignMonthlyActiveUserCount = null,
            ClaudeDesignWeeklyActiveUserCount = null,
            OfficeAgentDailyActiveUserCount = null,
            OfficeAgentMonthlyActiveUserCount = null,
            OfficeAgentWeeklyActiveUserCount = null,
            ScienceDailyActiveUserCount = null,
            ScienceEntitledUserCount = null,
            ScienceMonthlyActiveUserCount = null,
            ScienceWeeklyActiveUserCount = null,
        };

        Assert.Null(model.ChatCoworkUnifiedDailyActiveUserCount);
        Assert.True(model.RawData.ContainsKey("chat_cowork_unified_daily_active_user_count"));
        Assert.Null(model.ChatCoworkUnifiedMonthlyActiveUserCount);
        Assert.True(model.RawData.ContainsKey("chat_cowork_unified_monthly_active_user_count"));
        Assert.Null(model.ChatCoworkUnifiedWeeklyActiveUserCount);
        Assert.True(model.RawData.ContainsKey("chat_cowork_unified_weekly_active_user_count"));
        Assert.Null(model.ChatDailyActiveUserCount);
        Assert.True(model.RawData.ContainsKey("chat_daily_active_user_count"));
        Assert.Null(model.ChatMonthlyActiveUserCount);
        Assert.True(model.RawData.ContainsKey("chat_monthly_active_user_count"));
        Assert.Null(model.ChatWeeklyActiveUserCount);
        Assert.True(model.RawData.ContainsKey("chat_weekly_active_user_count"));
        Assert.Null(model.ClaudeCodeDailyActiveUserCount);
        Assert.True(model.RawData.ContainsKey("claude_code_daily_active_user_count"));
        Assert.Null(model.ClaudeCodeMonthlyActiveUserCount);
        Assert.True(model.RawData.ContainsKey("claude_code_monthly_active_user_count"));
        Assert.Null(model.ClaudeCodeWeeklyActiveUserCount);
        Assert.True(model.RawData.ContainsKey("claude_code_weekly_active_user_count"));
        Assert.Null(model.ClaudeDesignDailyActiveUserCount);
        Assert.True(model.RawData.ContainsKey("claude_design_daily_active_user_count"));
        Assert.Null(model.ClaudeDesignMonthlyActiveUserCount);
        Assert.True(model.RawData.ContainsKey("claude_design_monthly_active_user_count"));
        Assert.Null(model.ClaudeDesignWeeklyActiveUserCount);
        Assert.True(model.RawData.ContainsKey("claude_design_weekly_active_user_count"));
        Assert.Null(model.OfficeAgentDailyActiveUserCount);
        Assert.True(model.RawData.ContainsKey("office_agent_daily_active_user_count"));
        Assert.Null(model.OfficeAgentMonthlyActiveUserCount);
        Assert.True(model.RawData.ContainsKey("office_agent_monthly_active_user_count"));
        Assert.Null(model.OfficeAgentWeeklyActiveUserCount);
        Assert.True(model.RawData.ContainsKey("office_agent_weekly_active_user_count"));
        Assert.Null(model.ScienceDailyActiveUserCount);
        Assert.True(model.RawData.ContainsKey("science_daily_active_user_count"));
        Assert.Null(model.ScienceEntitledUserCount);
        Assert.True(model.RawData.ContainsKey("science_entitled_user_count"));
        Assert.Null(model.ScienceMonthlyActiveUserCount);
        Assert.True(model.RawData.ContainsKey("science_monthly_active_user_count"));
        Assert.Null(model.ScienceWeeklyActiveUserCount);
        Assert.True(model.RawData.ContainsKey("science_weekly_active_user_count"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaAnalyticsSingleDayActivitySummary
        {
            AssignedSeatCount = 0,
            CoworkDailyActiveUserCount = 0,
            CoworkMonthlyActiveUserCount = 0,
            CoworkWeeklyActiveUserCount = 0,
            DailyActiveUserCount = 0,
            DailyAdoptionRate = 0,
            EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MonthlyActiveUserCount = 0,
            MonthlyAdoptionRate = 0,
            PendingInviteCount = 0,
            StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WeeklyActiveUserCount = 0,
            WeeklyAdoptionRate = 0,

            ChatCoworkUnifiedDailyActiveUserCount = null,
            ChatCoworkUnifiedMonthlyActiveUserCount = null,
            ChatCoworkUnifiedWeeklyActiveUserCount = null,
            ChatDailyActiveUserCount = null,
            ChatMonthlyActiveUserCount = null,
            ChatWeeklyActiveUserCount = null,
            ClaudeCodeDailyActiveUserCount = null,
            ClaudeCodeMonthlyActiveUserCount = null,
            ClaudeCodeWeeklyActiveUserCount = null,
            ClaudeDesignDailyActiveUserCount = null,
            ClaudeDesignMonthlyActiveUserCount = null,
            ClaudeDesignWeeklyActiveUserCount = null,
            OfficeAgentDailyActiveUserCount = null,
            OfficeAgentMonthlyActiveUserCount = null,
            OfficeAgentWeeklyActiveUserCount = null,
            ScienceDailyActiveUserCount = null,
            ScienceEntitledUserCount = null,
            ScienceMonthlyActiveUserCount = null,
            ScienceWeeklyActiveUserCount = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsSingleDayActivitySummary
        {
            AssignedSeatCount = 0,
            CoworkDailyActiveUserCount = 0,
            CoworkMonthlyActiveUserCount = 0,
            CoworkWeeklyActiveUserCount = 0,
            DailyActiveUserCount = 0,
            DailyAdoptionRate = 0,
            EndingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            MonthlyActiveUserCount = 0,
            MonthlyAdoptionRate = 0,
            PendingInviteCount = 0,
            StartingAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            WeeklyActiveUserCount = 0,
            WeeklyAdoptionRate = 0,
            ChatCoworkUnifiedDailyActiveUserCount = 0,
            ChatCoworkUnifiedMonthlyActiveUserCount = 0,
            ChatCoworkUnifiedWeeklyActiveUserCount = 0,
            ChatDailyActiveUserCount = 0,
            ChatMonthlyActiveUserCount = 0,
            ChatWeeklyActiveUserCount = 0,
            ClaudeCodeDailyActiveUserCount = 0,
            ClaudeCodeMonthlyActiveUserCount = 0,
            ClaudeCodeWeeklyActiveUserCount = 0,
            ClaudeDesignDailyActiveUserCount = 0,
            ClaudeDesignMonthlyActiveUserCount = 0,
            ClaudeDesignWeeklyActiveUserCount = 0,
            OfficeAgentDailyActiveUserCount = 0,
            OfficeAgentMonthlyActiveUserCount = 0,
            OfficeAgentWeeklyActiveUserCount = 0,
            ScienceDailyActiveUserCount = 0,
            ScienceEntitledUserCount = 0,
            ScienceMonthlyActiveUserCount = 0,
            ScienceWeeklyActiveUserCount = 0,
        };

        BetaAnalyticsSingleDayActivitySummary copied = new(model);

        Assert.Equal(model, copied);
    }
}
