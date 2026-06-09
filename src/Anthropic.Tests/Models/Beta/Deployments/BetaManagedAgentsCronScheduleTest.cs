using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Deployments;

namespace Anthropic.Tests.Models.Beta.Deployments;

public class BetaManagedAgentsCronScheduleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsCronSchedule
        {
            Expression = "x",
            Timezone = "x",
            Type = BetaManagedAgentsCronScheduleType.Cron,
            LastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpcomingRunsAt = [DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")],
        };

        string expectedExpression = "x";
        string expectedTimezone = "x";
        ApiEnum<string, BetaManagedAgentsCronScheduleType> expectedType =
            BetaManagedAgentsCronScheduleType.Cron;
        DateTimeOffset expectedLastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<DateTimeOffset> expectedUpcomingRunsAt =
        [
            DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new BetaManagedAgentsCronSchedule
        {
            Expression = "x",
            Timezone = "x",
            Type = BetaManagedAgentsCronScheduleType.Cron,
            LastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpcomingRunsAt = [DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsCronSchedule>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsCronSchedule
        {
            Expression = "x",
            Timezone = "x",
            Type = BetaManagedAgentsCronScheduleType.Cron,
            LastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpcomingRunsAt = [DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsCronSchedule>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedExpression = "x";
        string expectedTimezone = "x";
        ApiEnum<string, BetaManagedAgentsCronScheduleType> expectedType =
            BetaManagedAgentsCronScheduleType.Cron;
        DateTimeOffset expectedLastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<DateTimeOffset> expectedUpcomingRunsAt =
        [
            DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new BetaManagedAgentsCronSchedule
        {
            Expression = "x",
            Timezone = "x",
            Type = BetaManagedAgentsCronScheduleType.Cron,
            LastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpcomingRunsAt = [DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsCronSchedule
        {
            Expression = "x",
            Timezone = "x",
            Type = BetaManagedAgentsCronScheduleType.Cron,
            LastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.UpcomingRunsAt);
        Assert.False(model.RawData.ContainsKey("upcoming_runs_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsCronSchedule
        {
            Expression = "x",
            Timezone = "x",
            Type = BetaManagedAgentsCronScheduleType.Cron,
            LastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsCronSchedule
        {
            Expression = "x",
            Timezone = "x",
            Type = BetaManagedAgentsCronScheduleType.Cron,
            LastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            UpcomingRunsAt = null,
        };

        Assert.Null(model.UpcomingRunsAt);
        Assert.False(model.RawData.ContainsKey("upcoming_runs_at"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsCronSchedule
        {
            Expression = "x",
            Timezone = "x",
            Type = BetaManagedAgentsCronScheduleType.Cron,
            LastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            UpcomingRunsAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsCronSchedule
        {
            Expression = "x",
            Timezone = "x",
            Type = BetaManagedAgentsCronScheduleType.Cron,
            UpcomingRunsAt = [DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")],
        };

        Assert.Null(model.LastRunAt);
        Assert.False(model.RawData.ContainsKey("last_run_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsCronSchedule
        {
            Expression = "x",
            Timezone = "x",
            Type = BetaManagedAgentsCronScheduleType.Cron,
            UpcomingRunsAt = [DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsCronSchedule
        {
            Expression = "x",
            Timezone = "x",
            Type = BetaManagedAgentsCronScheduleType.Cron,
            UpcomingRunsAt = [DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")],

            LastRunAt = null,
        };

        Assert.Null(model.LastRunAt);
        Assert.True(model.RawData.ContainsKey("last_run_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsCronSchedule
        {
            Expression = "x",
            Timezone = "x",
            Type = BetaManagedAgentsCronScheduleType.Cron,
            UpcomingRunsAt = [DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")],

            LastRunAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsCronSchedule
        {
            Expression = "x",
            Timezone = "x",
            Type = BetaManagedAgentsCronScheduleType.Cron,
            LastRunAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpcomingRunsAt = [DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")],
        };

        BetaManagedAgentsCronSchedule copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsCronScheduleTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsCronScheduleType.Cron)]
    public void Validation_Works(BetaManagedAgentsCronScheduleType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsCronScheduleType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsCronScheduleType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsCronScheduleType.Cron)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsCronScheduleType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsCronScheduleType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsCronScheduleType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsCronScheduleType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsCronScheduleType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
