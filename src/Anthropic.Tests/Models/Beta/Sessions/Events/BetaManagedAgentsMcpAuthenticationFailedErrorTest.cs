using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsMcpAuthenticationFailedErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpAuthenticationFailedError
        {
            McpServerName = "mcp_server_name",
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };

        string expectedMcpServerName = "mcp_server_name";
        string expectedMessage = "message";
        BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatus expectedRetryStatus =
            new BetaManagedAgentsRetryStatusRetrying();
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "mcp_authentication_failed_error"
        );

        Assert.Equal(expectedMcpServerName, model.McpServerName);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedRetryStatus, model.RetryStatus);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpAuthenticationFailedError
        {
            McpServerName = "mcp_server_name",
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMcpAuthenticationFailedError>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMcpAuthenticationFailedError
        {
            McpServerName = "mcp_server_name",
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMcpAuthenticationFailedError>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedMcpServerName = "mcp_server_name";
        string expectedMessage = "message";
        BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatus expectedRetryStatus =
            new BetaManagedAgentsRetryStatusRetrying();
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "mcp_authentication_failed_error"
        );

        Assert.Equal(expectedMcpServerName, deserialized.McpServerName);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedRetryStatus, deserialized.RetryStatus);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMcpAuthenticationFailedError
        {
            McpServerName = "mcp_server_name",
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMcpAuthenticationFailedError
        {
            McpServerName = "mcp_server_name",
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };

        BetaManagedAgentsMcpAuthenticationFailedError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatusTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsRetryStatusRetryingValidationWorks()
    {
        BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusRetrying();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusExhaustedValidationWorks()
    {
        BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusExhausted();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusTerminalValidationWorks()
    {
        BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusTerminal();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusRetryingSerializationRoundtripWorks()
    {
        BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusRetrying();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatus>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusExhaustedSerializationRoundtripWorks()
    {
        BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusExhausted();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatus>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusTerminalSerializationRoundtripWorks()
    {
        BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusTerminal();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatus>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusRetryingTypeWorks()
    {
        BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusRetrying();
        Assert.Equal(
            BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatusType.Retrying,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusExhaustedTypeWorks()
    {
        BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusExhausted();
        Assert.Equal(
            BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatusType.Exhausted,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusTerminalTypeWorks()
    {
        BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusTerminal();
        Assert.Equal(
            BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatusType.Terminal,
            value.Type.Value()
        );
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatus value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "retrying"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatusType> expectedType =
            BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatusType.Retrying;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatus emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatusTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatusType.Retrying)]
    [InlineData(BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatusType.Exhausted)]
    [InlineData(BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatusType.Terminal)]
    public void Validation_Works(
        BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatusType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatusType> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatusType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatusType.Retrying)]
    [InlineData(BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatusType.Exhausted)]
    [InlineData(BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatusType.Terminal)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatusType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatusType> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatusType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatusType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpAuthenticationFailedErrorRetryStatusType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
