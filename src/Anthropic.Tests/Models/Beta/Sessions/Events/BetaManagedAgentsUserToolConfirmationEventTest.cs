using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsUserToolConfirmationEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsUserToolConfirmationEvent
        {
            ID = "id",
            Result = Result.Allow,
            ToolUseID = "tool_use_id",
            Type = BetaManagedAgentsUserToolConfirmationEventType.UserToolConfirmation,
            DenyMessage = "deny_message",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };

        string expectedID = "id";
        ApiEnum<string, Result> expectedResult = Result.Allow;
        string expectedToolUseID = "tool_use_id";
        ApiEnum<string, BetaManagedAgentsUserToolConfirmationEventType> expectedType =
            BetaManagedAgentsUserToolConfirmationEventType.UserToolConfirmation;
        string expectedDenyMessage = "deny_message";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedSessionThreadID = "session_thread_id";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedResult, model.Result);
        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedDenyMessage, model.DenyMessage);
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.Equal(expectedSessionThreadID, model.SessionThreadID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsUserToolConfirmationEvent
        {
            ID = "id",
            Result = Result.Allow,
            ToolUseID = "tool_use_id",
            Type = BetaManagedAgentsUserToolConfirmationEventType.UserToolConfirmation,
            DenyMessage = "deny_message",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsUserToolConfirmationEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsUserToolConfirmationEvent
        {
            ID = "id",
            Result = Result.Allow,
            ToolUseID = "tool_use_id",
            Type = BetaManagedAgentsUserToolConfirmationEventType.UserToolConfirmation,
            DenyMessage = "deny_message",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsUserToolConfirmationEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, Result> expectedResult = Result.Allow;
        string expectedToolUseID = "tool_use_id";
        ApiEnum<string, BetaManagedAgentsUserToolConfirmationEventType> expectedType =
            BetaManagedAgentsUserToolConfirmationEventType.UserToolConfirmation;
        string expectedDenyMessage = "deny_message";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedSessionThreadID = "session_thread_id";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedResult, deserialized.Result);
        Assert.Equal(expectedToolUseID, deserialized.ToolUseID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedDenyMessage, deserialized.DenyMessage);
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.Equal(expectedSessionThreadID, deserialized.SessionThreadID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsUserToolConfirmationEvent
        {
            ID = "id",
            Result = Result.Allow,
            ToolUseID = "tool_use_id",
            Type = BetaManagedAgentsUserToolConfirmationEventType.UserToolConfirmation,
            DenyMessage = "deny_message",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsUserToolConfirmationEvent
        {
            ID = "id",
            Result = Result.Allow,
            ToolUseID = "tool_use_id",
            Type = BetaManagedAgentsUserToolConfirmationEventType.UserToolConfirmation,
        };

        Assert.Null(model.DenyMessage);
        Assert.False(model.RawData.ContainsKey("deny_message"));
        Assert.Null(model.ProcessedAt);
        Assert.False(model.RawData.ContainsKey("processed_at"));
        Assert.Null(model.SessionThreadID);
        Assert.False(model.RawData.ContainsKey("session_thread_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsUserToolConfirmationEvent
        {
            ID = "id",
            Result = Result.Allow,
            ToolUseID = "tool_use_id",
            Type = BetaManagedAgentsUserToolConfirmationEventType.UserToolConfirmation,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsUserToolConfirmationEvent
        {
            ID = "id",
            Result = Result.Allow,
            ToolUseID = "tool_use_id",
            Type = BetaManagedAgentsUserToolConfirmationEventType.UserToolConfirmation,

            DenyMessage = null,
            ProcessedAt = null,
            SessionThreadID = null,
        };

        Assert.Null(model.DenyMessage);
        Assert.True(model.RawData.ContainsKey("deny_message"));
        Assert.Null(model.ProcessedAt);
        Assert.True(model.RawData.ContainsKey("processed_at"));
        Assert.Null(model.SessionThreadID);
        Assert.True(model.RawData.ContainsKey("session_thread_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsUserToolConfirmationEvent
        {
            ID = "id",
            Result = Result.Allow,
            ToolUseID = "tool_use_id",
            Type = BetaManagedAgentsUserToolConfirmationEventType.UserToolConfirmation,

            DenyMessage = null,
            ProcessedAt = null,
            SessionThreadID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsUserToolConfirmationEvent
        {
            ID = "id",
            Result = Result.Allow,
            ToolUseID = "tool_use_id",
            Type = BetaManagedAgentsUserToolConfirmationEventType.UserToolConfirmation,
            DenyMessage = "deny_message",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };

        BetaManagedAgentsUserToolConfirmationEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResultTest : TestBase
{
    [Theory]
    [InlineData(Result.Allow)]
    [InlineData(Result.Deny)]
    public void Validation_Works(Result rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Result> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Result>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Result.Allow)]
    [InlineData(Result.Deny)]
    public void SerializationRoundtrip_Works(Result rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Result> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Result>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Result>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Result>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BetaManagedAgentsUserToolConfirmationEventTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsUserToolConfirmationEventType.UserToolConfirmation)]
    public void Validation_Works(BetaManagedAgentsUserToolConfirmationEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUserToolConfirmationEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserToolConfirmationEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsUserToolConfirmationEventType.UserToolConfirmation)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsUserToolConfirmationEventType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUserToolConfirmationEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserToolConfirmationEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserToolConfirmationEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserToolConfirmationEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
