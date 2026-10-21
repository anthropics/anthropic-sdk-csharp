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
            Error = new BetaManagedAgentsRepositoryAuthenticationError()
            {
                Message =
                    "The repository host rejected the credentials for the repository, or required credentials and received none.",
                RepositoryUrl = "https://github.com/example-org/example-repo",
                RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
            },
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        Error expectedError = new BetaManagedAgentsRepositoryAuthenticationError()
        {
            Message =
                "The repository host rejected the credentials for the repository, or required credentials and received none.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("session.error");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedError, model.Error);
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSessionErrorEvent
        {
            ID = "id",
            Error = new BetaManagedAgentsRepositoryAuthenticationError()
            {
                Message =
                    "The repository host rejected the credentials for the repository, or required credentials and received none.",
                RepositoryUrl = "https://github.com/example-org/example-repo",
                RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
            },
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            Error = new BetaManagedAgentsRepositoryAuthenticationError()
            {
                Message =
                    "The repository host rejected the credentials for the repository, or required credentials and received none.",
                RepositoryUrl = "https://github.com/example-org/example-repo",
                RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
            },
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSessionErrorEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        Error expectedError = new BetaManagedAgentsRepositoryAuthenticationError()
        {
            Message =
                "The repository host rejected the credentials for the repository, or required credentials and received none.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("session.error");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSessionErrorEvent
        {
            ID = "id",
            Error = new BetaManagedAgentsRepositoryAuthenticationError()
            {
                Message =
                    "The repository host rejected the credentials for the repository, or required credentials and received none.",
                RepositoryUrl = "https://github.com/example-org/example-repo",
                RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
            },
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSessionErrorEvent
        {
            ID = "id",
            Error = new BetaManagedAgentsRepositoryAuthenticationError()
            {
                Message =
                    "The repository host rejected the credentials for the repository, or required credentials and received none.",
                RepositoryUrl = "https://github.com/example-org/example-repo",
                RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
            },
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsModelOverloadedValidationWorks()
    {
        Error value = new BetaManagedAgentsModelOverloadedError()
        {
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsModelRateLimitedValidationWorks()
    {
        Error value = new BetaManagedAgentsModelRateLimitedError()
        {
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsModelRequestFailedValidationWorks()
    {
        Error value = new BetaManagedAgentsModelRequestFailedError()
        {
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
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
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
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
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsBillingValidationWorks()
    {
        Error value = new BetaManagedAgentsBillingError()
        {
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsCredentialHostUnreachableValidationWorks()
    {
        Error value = new BetaManagedAgentsCredentialHostUnreachableError()
        {
            CredentialID = "credential_id",
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
            VaultID = "vault_id",
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRepositoryAuthenticationValidationWorks()
    {
        Error value = new BetaManagedAgentsRepositoryAuthenticationError()
        {
            Message =
                "The repository host rejected the credentials for the repository, or required credentials and received none.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRepositoryForbiddenValidationWorks()
    {
        Error value = new BetaManagedAgentsRepositoryForbiddenError()
        {
            Message = "The repository host refused access to the repository.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRepositoryNotFoundValidationWorks()
    {
        Error value = new BetaManagedAgentsRepositoryNotFoundError()
        {
            Message = "The repository host reported the repository as not found.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRepositoryCheckoutValidationWorks()
    {
        Error value = new BetaManagedAgentsRepositoryCheckoutError()
        {
            Message = "The requested branch or commit does not exist in the repository.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRepositoryCloneValidationWorks()
    {
        Error value = new BetaManagedAgentsRepositoryCloneError()
        {
            Message = "The repository could not be cloned.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsUnknownSerializationRoundtripWorks()
    {
        Error value = new BetaManagedAgentsUnknownError()
        {
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
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
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
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
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
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
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
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
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
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
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
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
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsCredentialHostUnreachableSerializationRoundtripWorks()
    {
        Error value = new BetaManagedAgentsCredentialHostUnreachableError()
        {
            CredentialID = "credential_id",
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
            VaultID = "vault_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsRepositoryAuthenticationSerializationRoundtripWorks()
    {
        Error value = new BetaManagedAgentsRepositoryAuthenticationError()
        {
            Message =
                "The repository host rejected the credentials for the repository, or required credentials and received none.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsRepositoryForbiddenSerializationRoundtripWorks()
    {
        Error value = new BetaManagedAgentsRepositoryForbiddenError()
        {
            Message = "The repository host refused access to the repository.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsRepositoryNotFoundSerializationRoundtripWorks()
    {
        Error value = new BetaManagedAgentsRepositoryNotFoundError()
        {
            Message = "The repository host reported the repository as not found.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsRepositoryCheckoutSerializationRoundtripWorks()
    {
        Error value = new BetaManagedAgentsRepositoryCheckoutError()
        {
            Message = "The requested branch or commit does not exist in the repository.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsRepositoryCloneSerializationRoundtripWorks()
    {
        Error value = new BetaManagedAgentsRepositoryCloneError()
        {
            Message = "The repository could not be cloned.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Error>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsUnknownTypeWorks()
    {
        Error value = new BetaManagedAgentsUnknownError()
        {
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };
        Assert.Equal(ErrorType.UnknownError, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsModelOverloadedTypeWorks()
    {
        Error value = new BetaManagedAgentsModelOverloadedError()
        {
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };
        Assert.Equal(ErrorType.ModelOverloadedError, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsModelRateLimitedTypeWorks()
    {
        Error value = new BetaManagedAgentsModelRateLimitedError()
        {
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };
        Assert.Equal(ErrorType.ModelRateLimitedError, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsModelRequestFailedTypeWorks()
    {
        Error value = new BetaManagedAgentsModelRequestFailedError()
        {
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };
        Assert.Equal(ErrorType.ModelRequestFailedError, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsMcpConnectionFailedTypeWorks()
    {
        Error value = new BetaManagedAgentsMcpConnectionFailedError()
        {
            McpServerName = "mcp_server_name",
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };
        Assert.Equal(ErrorType.McpConnectionFailedError, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsMcpAuthenticationFailedTypeWorks()
    {
        Error value = new BetaManagedAgentsMcpAuthenticationFailedError()
        {
            McpServerName = "mcp_server_name",
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };
        Assert.Equal(ErrorType.McpAuthenticationFailedError, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsBillingTypeWorks()
    {
        Error value = new BetaManagedAgentsBillingError()
        {
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };
        Assert.Equal(ErrorType.BillingError, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsCredentialHostUnreachableTypeWorks()
    {
        Error value = new BetaManagedAgentsCredentialHostUnreachableError()
        {
            CredentialID = "credential_id",
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
            VaultID = "vault_id",
        };
        Assert.Equal(ErrorType.CredentialHostUnreachableError, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsRepositoryAuthenticationTypeWorks()
    {
        Error value = new BetaManagedAgentsRepositoryAuthenticationError()
        {
            Message =
                "The repository host rejected the credentials for the repository, or required credentials and received none.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };
        Assert.Equal(ErrorType.RepositoryAuthenticationError, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsRepositoryForbiddenTypeWorks()
    {
        Error value = new BetaManagedAgentsRepositoryForbiddenError()
        {
            Message = "The repository host refused access to the repository.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };
        Assert.Equal(ErrorType.RepositoryForbiddenError, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsRepositoryNotFoundTypeWorks()
    {
        Error value = new BetaManagedAgentsRepositoryNotFoundError()
        {
            Message = "The repository host reported the repository as not found.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };
        Assert.Equal(ErrorType.RepositoryNotFoundError, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsRepositoryCheckoutTypeWorks()
    {
        Error value = new BetaManagedAgentsRepositoryCheckoutError()
        {
            Message = "The requested branch or commit does not exist in the repository.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };
        Assert.Equal(ErrorType.RepositoryCheckoutError, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsRepositoryCloneTypeWorks()
    {
        Error value = new BetaManagedAgentsRepositoryCloneError()
        {
            Message = "The repository could not be cloned.",
            RepositoryUrl = "https://github.com/example-org/example-repo",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };
        Assert.Equal(ErrorType.RepositoryCloneError, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Error value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "message": "message",
                  "type": "unknown_error",
                  "mcp_server_name": "mcp_server_name",
                  "repository_url": "https://github.com/example-org/example-repo"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        string expectedMessage = "message";
        ApiEnum<string, ErrorType> expectedType = ErrorType.UnknownError;
        string expectedMcpServerName = "mcp_server_name";
        string expectedRepositoryUrl = "https://github.com/example-org/example-repo";

        Assert.Equal(expectedMessage, value.Message);
        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedMcpServerName, value.McpServerName);
        Assert.Equal(expectedRepositoryUrl, value.RepositoryUrl);

        Error emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Message);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.McpServerName);
        Assert.Null(emptyValue.RepositoryUrl);

        Error mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "message": [
                    "invalid"
                  ],
                  "mcp_server_name": [
                    "invalid"
                  ],
                  "repository_url": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Throws<AnthropicInvalidDataException>(() => mismatchedValue.Message);
        Assert.Null(mismatchedValue.McpServerName);
        Assert.Null(mismatchedValue.RepositoryUrl);
    }
}

public class ErrorTypeTest : TestBase
{
    [Theory]
    [InlineData(ErrorType.UnknownError)]
    [InlineData(ErrorType.ModelOverloadedError)]
    [InlineData(ErrorType.ModelRateLimitedError)]
    [InlineData(ErrorType.ModelRequestFailedError)]
    [InlineData(ErrorType.McpConnectionFailedError)]
    [InlineData(ErrorType.McpAuthenticationFailedError)]
    [InlineData(ErrorType.BillingError)]
    [InlineData(ErrorType.CredentialHostUnreachableError)]
    [InlineData(ErrorType.RepositoryAuthenticationError)]
    [InlineData(ErrorType.RepositoryForbiddenError)]
    [InlineData(ErrorType.RepositoryNotFoundError)]
    [InlineData(ErrorType.RepositoryCheckoutError)]
    [InlineData(ErrorType.RepositoryCloneError)]
    public void Validation_Works(ErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ErrorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ErrorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ErrorType.UnknownError)]
    [InlineData(ErrorType.ModelOverloadedError)]
    [InlineData(ErrorType.ModelRateLimitedError)]
    [InlineData(ErrorType.ModelRequestFailedError)]
    [InlineData(ErrorType.McpConnectionFailedError)]
    [InlineData(ErrorType.McpAuthenticationFailedError)]
    [InlineData(ErrorType.BillingError)]
    [InlineData(ErrorType.CredentialHostUnreachableError)]
    [InlineData(ErrorType.RepositoryAuthenticationError)]
    [InlineData(ErrorType.RepositoryForbiddenError)]
    [InlineData(ErrorType.RepositoryNotFoundError)]
    [InlineData(ErrorType.RepositoryCheckoutError)]
    [InlineData(ErrorType.RepositoryCloneError)]
    public void SerializationRoundtrip_Works(ErrorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ErrorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ErrorType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ErrorType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ErrorType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
