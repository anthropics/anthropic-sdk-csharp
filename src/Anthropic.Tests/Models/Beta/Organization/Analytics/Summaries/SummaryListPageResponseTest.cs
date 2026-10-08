using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;
using Anthropic.Models.Beta.Organization.Analytics.Summaries;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics.Summaries;

public class SummaryListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SummaryListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextPage = "next_page",
        };

        List<BetaAnalyticsSingleDayActivitySummary> expectedData =
        [
            new()
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
            },
        ];
        string expectedNextPage = "next_page";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedNextPage, model.NextPage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SummaryListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextPage = "next_page",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SummaryListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SummaryListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextPage = "next_page",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SummaryListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaAnalyticsSingleDayActivitySummary> expectedData =
        [
            new()
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
            },
        ];
        string expectedNextPage = "next_page";

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedNextPage, deserialized.NextPage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SummaryListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextPage = "next_page",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SummaryListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextPage = "next_page",
        };

        SummaryListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
