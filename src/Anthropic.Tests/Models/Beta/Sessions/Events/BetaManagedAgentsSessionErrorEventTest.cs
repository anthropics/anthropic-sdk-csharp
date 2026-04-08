using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsSessionErrorEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionErrorEvent
        {
            ID = "id",
            Error = new BetaManagedAgentsUnknownError()
            {
                Message = "message",
                RetryStatus = new BetaManagedAgentsRetryStatusRetrying(
                    BetaManagedAgentsRetryStatusRetryingType.Retrying
                ),
                Type = BetaManagedAgentsUnknownErrorType.UnknownError,
            },
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsSessionErrorEventType.SessionError,
        };

        string expectedID = "id";
        Error expectedError = new BetaManagedAgentsUnknownError()
        {
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            ),
            Type = BetaManagedAgentsUnknownErrorType.UnknownError,
        };
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, BetaManagedAgentsSessionErrorEventType> expectedType =
            BetaManagedAgentsSessionErrorEventType.SessionError;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionErrorEvent
        {
            ID = "id",
            Error = new BetaManagedAgentsUnknownError()
            {
                Message = "message",
                RetryStatus = new BetaManagedAgentsRetryStatusRetrying(
                    BetaManagedAgentsRetryStatusRetryingType.Retrying
                ),
                Type = BetaManagedAgentsUnknownErrorType.UnknownError,
            },
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsSessionErrorEventType.SessionError,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionErrorEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSessionErrorEvent
        {
            ID = "id",
            Error = new BetaManagedAgentsUnknownError()
            {
                Message = "message",
                RetryStatus = new BetaManagedAgentsRetryStatusRetrying(
                    BetaManagedAgentsRetryStatusRetryingType.Retrying
                ),
                Type = BetaManagedAgentsUnknownErrorType.UnknownError,
            },
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsSessionErrorEventType.SessionError,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionErrorEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        Error expectedError = new BetaManagedAgentsUnknownError()
        {
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            ),
            Type = BetaManagedAgentsUnknownErrorType.UnknownError,
        };
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, BetaManagedAgentsSessionErrorEventType> expectedType =
            BetaManagedAgentsSessionErrorEventType.SessionError;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSessionErrorEvent
        {
            ID = "id",
            Error = new BetaManagedAgentsUnknownError()
            {
                Message = "message",
                RetryStatus = new BetaManagedAgentsRetryStatusRetrying(
                    BetaManagedAgentsRetryStatusRetryingType.Retrying
                ),
                Type = BetaManagedAgentsUnknownErrorType.UnknownError,
            },
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsSessionErrorEventType.SessionError,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSessionErrorEvent
        {
            ID = "id",
            Error = new BetaManagedAgentsUnknownError()
            {
                Message = "message",
                RetryStatus = new BetaManagedAgentsRetryStatusRetrying(
                    BetaManagedAgentsRetryStatusRetryingType.Retrying
                ),
                Type = BetaManagedAgentsUnknownErrorType.UnknownError,
            },
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsSessionErrorEventType.SessionError,
        };

        BetaManagedAgentsSessionErrorEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ErrorTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsUnknownValidationWorks()
    {
        Error value = new BetaManagedAgentsUnknownError()
        {
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            ),
            Type = BetaManagedAgentsUnknownErrorType.UnknownError,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsModelOverloadedValidationWorks()
    {
        Error value = new BetaManagedAgentsModelOverloadedError()
        {
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            ),
            Type = BetaManagedAgentsModelOverloadedErrorType.ModelOverloadedError,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsModelRateLimitedValidationWorks()
    {
        Error value = new BetaManagedAgentsModelRateLimitedError()
        {
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            ),
            Type = BetaManagedAgentsModelRateLimitedErrorType.ModelRateLimitedError,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsModelRequestFailedValidationWorks()
    {
        Error value = new BetaManagedAgentsModelRequestFailedError()
        {
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            ),
            Type = BetaManagedAgentsModelRequestFailedErrorType.ModelRequestFailedError,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsMcpConnectionFailedValidationWorks()
    {
        Error value = new BetaManagedAgentsMcpConnectionFailedError()
        {
            McpServerName = "mcp_server_name",
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            ),
            Type = BetaManagedAgentsMcpConnectionFailedErrorType.McpConnectionFailedError,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsMcpAuthenticationFailedValidationWorks()
    {
        Error value = new BetaManagedAgentsMcpAuthenticationFailedError()
        {
            McpServerName = "mcp_server_name",
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            ),
            Type = BetaManagedAgentsMcpAuthenticationFailedErrorType.McpAuthenticationFailedError,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsBillingValidationWorks()
    {
        Error value = new BetaManagedAgentsBillingError()
        {
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            ),
            Type = BetaManagedAgentsBillingErrorType.BillingError,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsUnknownSerializationRoundtripWorks()
    {
        Error value = new BetaManagedAgentsUnknownError()
        {
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            ),
            Type = BetaManagedAgentsUnknownErrorType.UnknownError,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsModelOverloadedSerializationRoundtripWorks()
    {
        Error value = new BetaManagedAgentsModelOverloadedError()
        {
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            ),
            Type = BetaManagedAgentsModelOverloadedErrorType.ModelOverloadedError,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsModelRateLimitedSerializationRoundtripWorks()
    {
        Error value = new BetaManagedAgentsModelRateLimitedError()
        {
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            ),
            Type = BetaManagedAgentsModelRateLimitedErrorType.ModelRateLimitedError,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsModelRequestFailedSerializationRoundtripWorks()
    {
        Error value = new BetaManagedAgentsModelRequestFailedError()
        {
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            ),
            Type = BetaManagedAgentsModelRequestFailedErrorType.ModelRequestFailedError,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsMcpConnectionFailedSerializationRoundtripWorks()
    {
        Error value = new BetaManagedAgentsMcpConnectionFailedError()
        {
            McpServerName = "mcp_server_name",
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            ),
            Type = BetaManagedAgentsMcpConnectionFailedErrorType.McpConnectionFailedError,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsMcpAuthenticationFailedSerializationRoundtripWorks()
    {
        Error value = new BetaManagedAgentsMcpAuthenticationFailedError()
        {
            McpServerName = "mcp_server_name",
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            ),
            Type = BetaManagedAgentsMcpAuthenticationFailedErrorType.McpAuthenticationFailedError,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsBillingSerializationRoundtripWorks()
    {
        Error value = new BetaManagedAgentsBillingError()
        {
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(
                BetaManagedAgentsRetryStatusRetryingType.Retrying
            ),
            Type = BetaManagedAgentsBillingErrorType.BillingError,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class BetaManagedAgentsSessionErrorEventTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSessionErrorEventType.SessionError)]
    public void Validation_Works(BetaManagedAgentsSessionErrorEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionErrorEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionErrorEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSessionErrorEventType.SessionError)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsSessionErrorEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSessionErrorEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionErrorEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionErrorEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSessionErrorEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
