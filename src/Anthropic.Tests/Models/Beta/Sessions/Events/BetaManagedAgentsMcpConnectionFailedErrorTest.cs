using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsMcpConnectionFailedErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpConnectionFailedError
        {
            McpServerName = "mcp_server_name",
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };

        string expectedMcpServerName = "mcp_server_name";
        string expectedMessage = "message";
        BetaManagedAgentsMcpConnectionFailedErrorRetryStatus expectedRetryStatus =
            new BetaManagedAgentsRetryStatusRetrying();
        JsonElement expectedType = JsonSerializer.SerializeToElement("mcp_connection_failed_error");

        Assert.Equal(expectedMcpServerName, model.McpServerName);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedRetryStatus, model.RetryStatus);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpConnectionFailedError
        {
            McpServerName = "mcp_server_name",
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMcpConnectionFailedError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMcpConnectionFailedError
        {
            McpServerName = "mcp_server_name",
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMcpConnectionFailedError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMcpServerName = "mcp_server_name";
        string expectedMessage = "message";
        BetaManagedAgentsMcpConnectionFailedErrorRetryStatus expectedRetryStatus =
            new BetaManagedAgentsRetryStatusRetrying();
        JsonElement expectedType = JsonSerializer.SerializeToElement("mcp_connection_failed_error");

        Assert.Equal(expectedMcpServerName, deserialized.McpServerName);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedRetryStatus, deserialized.RetryStatus);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMcpConnectionFailedError
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
        var model = new BetaManagedAgentsMcpConnectionFailedError
        {
            McpServerName = "mcp_server_name",
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };

        BetaManagedAgentsMcpConnectionFailedError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsMcpConnectionFailedErrorRetryStatusTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsRetryStatusRetryingValidationWorks()
    {
        BetaManagedAgentsMcpConnectionFailedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusRetrying();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusExhaustedValidationWorks()
    {
        BetaManagedAgentsMcpConnectionFailedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusExhausted();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusTerminalValidationWorks()
    {
        BetaManagedAgentsMcpConnectionFailedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusTerminal();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusRetryingSerializationRoundtripWorks()
    {
        BetaManagedAgentsMcpConnectionFailedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusRetrying();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMcpConnectionFailedErrorRetryStatus>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusExhaustedSerializationRoundtripWorks()
    {
        BetaManagedAgentsMcpConnectionFailedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusExhausted();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMcpConnectionFailedErrorRetryStatus>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusTerminalSerializationRoundtripWorks()
    {
        BetaManagedAgentsMcpConnectionFailedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusTerminal();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMcpConnectionFailedErrorRetryStatus>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusRetryingTypeWorks()
    {
        BetaManagedAgentsMcpConnectionFailedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusRetrying();
        Assert.Equal(
            BetaManagedAgentsMcpConnectionFailedErrorRetryStatusType.Retrying,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusExhaustedTypeWorks()
    {
        BetaManagedAgentsMcpConnectionFailedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusExhausted();
        Assert.Equal(
            BetaManagedAgentsMcpConnectionFailedErrorRetryStatusType.Exhausted,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusTerminalTypeWorks()
    {
        BetaManagedAgentsMcpConnectionFailedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusTerminal();
        Assert.Equal(
            BetaManagedAgentsMcpConnectionFailedErrorRetryStatusType.Terminal,
            value.Type.Value()
        );
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsMcpConnectionFailedErrorRetryStatus value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "retrying"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsMcpConnectionFailedErrorRetryStatusType> expectedType =
            BetaManagedAgentsMcpConnectionFailedErrorRetryStatusType.Retrying;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsMcpConnectionFailedErrorRetryStatus emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsMcpConnectionFailedErrorRetryStatusTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsMcpConnectionFailedErrorRetryStatusType.Retrying)]
    [InlineData(BetaManagedAgentsMcpConnectionFailedErrorRetryStatusType.Exhausted)]
    [InlineData(BetaManagedAgentsMcpConnectionFailedErrorRetryStatusType.Terminal)]
    public void Validation_Works(BetaManagedAgentsMcpConnectionFailedErrorRetryStatusType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMcpConnectionFailedErrorRetryStatusType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpConnectionFailedErrorRetryStatusType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsMcpConnectionFailedErrorRetryStatusType.Retrying)]
    [InlineData(BetaManagedAgentsMcpConnectionFailedErrorRetryStatusType.Exhausted)]
    [InlineData(BetaManagedAgentsMcpConnectionFailedErrorRetryStatusType.Terminal)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsMcpConnectionFailedErrorRetryStatusType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMcpConnectionFailedErrorRetryStatusType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpConnectionFailedErrorRetryStatusType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpConnectionFailedErrorRetryStatusType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpConnectionFailedErrorRetryStatusType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
