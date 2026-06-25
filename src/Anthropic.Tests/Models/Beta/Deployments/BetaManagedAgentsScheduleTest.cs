using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Deployments;

namespace Anthropic.Tests.Models.Beta.Deployments;

public class BetaManagedAgentsScheduleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSchedule
        {
            Expression = "0 9 * * 1-5",
            Timezone = "America/Los_Angeles",
            Type = BetaManagedAgentsScheduleType.Cron,
            LastRunAt = DateTimeOffset.Parse("2026-03-16T16:00:09Z"),
            UpcomingRunsAt =
            [
                DateTimeOffset.Parse("2026-03-17T16:00:00Z"),
                DateTimeOffset.Parse("2026-03-18T16:00:00Z"),
            ],
        };

        string expectedExpression = "0 9 * * 1-5";
        string expectedTimezone = "America/Los_Angeles";
        ApiEnum<string, BetaManagedAgentsScheduleType> expectedType =
            BetaManagedAgentsScheduleType.Cron;
        DateTimeOffset expectedLastRunAt = DateTimeOffset.Parse("2026-03-16T16:00:09Z");
        List<DateTimeOffset> expectedUpcomingRunsAt =
        [
            DateTimeOffset.Parse("2026-03-17T16:00:00Z"),
            DateTimeOffset.Parse("2026-03-18T16:00:00Z"),
        ];

        Assert.Equal(expectedExpression, model.Expression);
        Assert.Equal(expectedTimezone, model.Timezone);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedLastRunAt, model.LastRunAt);
        Assert.NotNull(model.UpcomingRunsAt);
        Assert.Equal(expectedUpcomingRunsAt.Count, model.UpcomingRunsAt.Count);
        for (int i = 0; i < expectedUpcomingRunsAt.Count; i++)
        {
            Assert.Equal(expectedUpcomingRunsAt[i], model.UpcomingRunsAt[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSchedule
        {
            Expression = "0 9 * * 1-5",
            Timezone = "America/Los_Angeles",
            Type = BetaManagedAgentsScheduleType.Cron,
            LastRunAt = DateTimeOffset.Parse("2026-03-16T16:00:09Z"),
            UpcomingRunsAt =
            [
                DateTimeOffset.Parse("2026-03-17T16:00:00Z"),
                DateTimeOffset.Parse("2026-03-18T16:00:00Z"),
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSchedule>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSchedule
        {
            Expression = "0 9 * * 1-5",
            Timezone = "America/Los_Angeles",
            Type = BetaManagedAgentsScheduleType.Cron,
            LastRunAt = DateTimeOffset.Parse("2026-03-16T16:00:09Z"),
            UpcomingRunsAt =
            [
                DateTimeOffset.Parse("2026-03-17T16:00:00Z"),
                DateTimeOffset.Parse("2026-03-18T16:00:00Z"),
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSchedule>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedExpression = "0 9 * * 1-5";
        string expectedTimezone = "America/Los_Angeles";
        ApiEnum<string, BetaManagedAgentsScheduleType> expectedType =
            BetaManagedAgentsScheduleType.Cron;
        DateTimeOffset expectedLastRunAt = DateTimeOffset.Parse("2026-03-16T16:00:09Z");
        List<DateTimeOffset> expectedUpcomingRunsAt =
        [
            DateTimeOffset.Parse("2026-03-17T16:00:00Z"),
            DateTimeOffset.Parse("2026-03-18T16:00:00Z"),
        ];

        Assert.Equal(expectedExpression, deserialized.Expression);
        Assert.Equal(expectedTimezone, deserialized.Timezone);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedLastRunAt, deserialized.LastRunAt);
        Assert.NotNull(deserialized.UpcomingRunsAt);
        Assert.Equal(expectedUpcomingRunsAt.Count, deserialized.UpcomingRunsAt.Count);
        for (int i = 0; i < expectedUpcomingRunsAt.Count; i++)
        {
            Assert.Equal(expectedUpcomingRunsAt[i], deserialized.UpcomingRunsAt[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSchedule
        {
            Expression = "0 9 * * 1-5",
            Timezone = "America/Los_Angeles",
            Type = BetaManagedAgentsScheduleType.Cron,
            LastRunAt = DateTimeOffset.Parse("2026-03-16T16:00:09Z"),
            UpcomingRunsAt =
            [
                DateTimeOffset.Parse("2026-03-17T16:00:00Z"),
                DateTimeOffset.Parse("2026-03-18T16:00:00Z"),
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsSchedule
        {
            Expression = "0 9 * * 1-5",
            Timezone = "America/Los_Angeles",
            Type = BetaManagedAgentsScheduleType.Cron,
            LastRunAt = DateTimeOffset.Parse("2026-03-16T16:00:09Z"),
        };

        Assert.Null(model.UpcomingRunsAt);
        Assert.False(model.RawData.ContainsKey("upcoming_runs_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsSchedule
        {
            Expression = "0 9 * * 1-5",
            Timezone = "America/Los_Angeles",
            Type = BetaManagedAgentsScheduleType.Cron,
            LastRunAt = DateTimeOffset.Parse("2026-03-16T16:00:09Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsSchedule
        {
            Expression = "0 9 * * 1-5",
            Timezone = "America/Los_Angeles",
            Type = BetaManagedAgentsScheduleType.Cron,
            LastRunAt = DateTimeOffset.Parse("2026-03-16T16:00:09Z"),

            // Null should be interpreted as omitted for these properties
            UpcomingRunsAt = null,
        };

        Assert.Null(model.UpcomingRunsAt);
        Assert.False(model.RawData.ContainsKey("upcoming_runs_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsSchedule
        {
            Expression = "0 9 * * 1-5",
            Timezone = "America/Los_Angeles",
            Type = BetaManagedAgentsScheduleType.Cron,
            LastRunAt = DateTimeOffset.Parse("2026-03-16T16:00:09Z"),

            // Null should be interpreted as omitted for these properties
            UpcomingRunsAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsSchedule
        {
            Expression = "0 9 * * 1-5",
            Timezone = "America/Los_Angeles",
            Type = BetaManagedAgentsScheduleType.Cron,
            UpcomingRunsAt =
            [
                DateTimeOffset.Parse("2026-03-17T16:00:00Z"),
                DateTimeOffset.Parse("2026-03-18T16:00:00Z"),
            ],
        };

        Assert.Null(model.LastRunAt);
        Assert.False(model.RawData.ContainsKey("last_run_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsSchedule
        {
            Expression = "0 9 * * 1-5",
            Timezone = "America/Los_Angeles",
            Type = BetaManagedAgentsScheduleType.Cron,
            UpcomingRunsAt =
            [
                DateTimeOffset.Parse("2026-03-17T16:00:00Z"),
                DateTimeOffset.Parse("2026-03-18T16:00:00Z"),
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsSchedule
        {
            Expression = "0 9 * * 1-5",
            Timezone = "America/Los_Angeles",
            Type = BetaManagedAgentsScheduleType.Cron,
            UpcomingRunsAt =
            [
                DateTimeOffset.Parse("2026-03-17T16:00:00Z"),
                DateTimeOffset.Parse("2026-03-18T16:00:00Z"),
            ],

            LastRunAt = null,
        };

        Assert.Null(model.LastRunAt);
        Assert.True(model.RawData.ContainsKey("last_run_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsSchedule
        {
            Expression = "0 9 * * 1-5",
            Timezone = "America/Los_Angeles",
            Type = BetaManagedAgentsScheduleType.Cron,
            UpcomingRunsAt =
            [
                DateTimeOffset.Parse("2026-03-17T16:00:00Z"),
                DateTimeOffset.Parse("2026-03-18T16:00:00Z"),
            ],

            LastRunAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSchedule
        {
            Expression = "0 9 * * 1-5",
            Timezone = "America/Los_Angeles",
            Type = BetaManagedAgentsScheduleType.Cron,
            LastRunAt = DateTimeOffset.Parse("2026-03-16T16:00:09Z"),
            UpcomingRunsAt =
            [
                DateTimeOffset.Parse("2026-03-17T16:00:00Z"),
                DateTimeOffset.Parse("2026-03-18T16:00:00Z"),
            ],
        };

        BetaManagedAgentsSchedule copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsScheduleTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsScheduleType.Cron)]
    public void Validation_Works(BetaManagedAgentsScheduleType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsScheduleType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsScheduleType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsScheduleType.Cron)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsScheduleType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsScheduleType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsScheduleType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsScheduleType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsScheduleType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
