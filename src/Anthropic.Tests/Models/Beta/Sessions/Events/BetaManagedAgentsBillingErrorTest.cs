using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsBillingErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsBillingError
        {
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };

        string expectedMessage = "message";
        RetryStatus expectedRetryStatus = new BetaManagedAgentsRetryStatusRetrying();
        JsonElement expectedType = JsonSerializer.SerializeToElement("billing_error");

        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedRetryStatus, model.RetryStatus);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsBillingError
        {
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsBillingError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsBillingError
        {
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsBillingError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMessage = "message";
        RetryStatus expectedRetryStatus = new BetaManagedAgentsRetryStatusRetrying();
        JsonElement expectedType = JsonSerializer.SerializeToElement("billing_error");

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedRetryStatus, deserialized.RetryStatus);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsBillingError
        {
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsBillingError
        {
            Message = "message",
            RetryStatus = new BetaManagedAgentsRetryStatusRetrying(),
        };

        BetaManagedAgentsBillingError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RetryStatusTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsRetryStatusRetryingValidationWorks()
    {
        RetryStatus value = new BetaManagedAgentsRetryStatusRetrying();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusExhaustedValidationWorks()
    {
        RetryStatus value = new BetaManagedAgentsRetryStatusExhausted();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusTerminalValidationWorks()
    {
        RetryStatus value = new BetaManagedAgentsRetryStatusTerminal();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusRetryingSerializationRoundtripWorks()
    {
        RetryStatus value = new BetaManagedAgentsRetryStatusRetrying();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RetryStatus>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusExhaustedSerializationRoundtripWorks()
    {
        RetryStatus value = new BetaManagedAgentsRetryStatusExhausted();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RetryStatus>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusTerminalSerializationRoundtripWorks()
    {
        RetryStatus value = new BetaManagedAgentsRetryStatusTerminal();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RetryStatus>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusRetryingTypeWorks()
    {
        RetryStatus value = new BetaManagedAgentsRetryStatusRetrying();
        Assert.Equal(RetryStatusType.Retrying, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusExhaustedTypeWorks()
    {
        RetryStatus value = new BetaManagedAgentsRetryStatusExhausted();
        Assert.Equal(RetryStatusType.Exhausted, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusTerminalTypeWorks()
    {
        RetryStatus value = new BetaManagedAgentsRetryStatusTerminal();
        Assert.Equal(RetryStatusType.Terminal, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        RetryStatus value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "retrying"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, RetryStatusType> expectedType = RetryStatusType.Retrying;

        Assert.Equal(expectedType, value.Type);

        RetryStatus emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class RetryStatusTypeTest : TestBase
{
    [Theory]
    [InlineData(RetryStatusType.Retrying)]
    [InlineData(RetryStatusType.Exhausted)]
    [InlineData(RetryStatusType.Terminal)]
    public void Validation_Works(RetryStatusType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RetryStatusType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RetryStatusType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RetryStatusType.Retrying)]
    [InlineData(RetryStatusType.Exhausted)]
    [InlineData(RetryStatusType.Terminal)]
    public void SerializationRoundtrip_Works(RetryStatusType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RetryStatusType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RetryStatusType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RetryStatusType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RetryStatusType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
