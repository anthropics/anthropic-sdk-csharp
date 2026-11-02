using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsToolUseLimitReachedErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsToolUseLimitReachedError
        {
            Message =
                "This turn stopped because the agent loop reached its limit of 500 tool-use rounds since the turn started or last resumed. A round is one model response that calls tools, plus running those tools. Nothing failed. Send the session a new message to continue; nothing from the stopped turn is discarded.",
            RetryStatus = new BetaManagedAgentsRetryStatusExhausted(),
        };

        string expectedMessage =
            "This turn stopped because the agent loop reached its limit of 500 tool-use rounds since the turn started or last resumed. A round is one model response that calls tools, plus running those tools. Nothing failed. Send the session a new message to continue; nothing from the stopped turn is discarded.";
        BetaManagedAgentsToolUseLimitReachedErrorRetryStatus expectedRetryStatus =
            new BetaManagedAgentsRetryStatusExhausted();
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "tool_use_limit_reached_error"
        );

        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedRetryStatus, model.RetryStatus);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsToolUseLimitReachedError
        {
            Message =
                "This turn stopped because the agent loop reached its limit of 500 tool-use rounds since the turn started or last resumed. A round is one model response that calls tools, plus running those tools. Nothing failed. Send the session a new message to continue; nothing from the stopped turn is discarded.",
            RetryStatus = new BetaManagedAgentsRetryStatusExhausted(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsToolUseLimitReachedError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsToolUseLimitReachedError
        {
            Message =
                "This turn stopped because the agent loop reached its limit of 500 tool-use rounds since the turn started or last resumed. A round is one model response that calls tools, plus running those tools. Nothing failed. Send the session a new message to continue; nothing from the stopped turn is discarded.",
            RetryStatus = new BetaManagedAgentsRetryStatusExhausted(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsToolUseLimitReachedError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMessage =
            "This turn stopped because the agent loop reached its limit of 500 tool-use rounds since the turn started or last resumed. A round is one model response that calls tools, plus running those tools. Nothing failed. Send the session a new message to continue; nothing from the stopped turn is discarded.";
        BetaManagedAgentsToolUseLimitReachedErrorRetryStatus expectedRetryStatus =
            new BetaManagedAgentsRetryStatusExhausted();
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "tool_use_limit_reached_error"
        );

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedRetryStatus, deserialized.RetryStatus);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsToolUseLimitReachedError
        {
            Message =
                "This turn stopped because the agent loop reached its limit of 500 tool-use rounds since the turn started or last resumed. A round is one model response that calls tools, plus running those tools. Nothing failed. Send the session a new message to continue; nothing from the stopped turn is discarded.",
            RetryStatus = new BetaManagedAgentsRetryStatusExhausted(),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsToolUseLimitReachedError
        {
            Message =
                "This turn stopped because the agent loop reached its limit of 500 tool-use rounds since the turn started or last resumed. A round is one model response that calls tools, plus running those tools. Nothing failed. Send the session a new message to continue; nothing from the stopped turn is discarded.",
            RetryStatus = new BetaManagedAgentsRetryStatusExhausted(),
        };

        BetaManagedAgentsToolUseLimitReachedError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsToolUseLimitReachedErrorRetryStatusTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsRetryStatusRetryingValidationWorks()
    {
        BetaManagedAgentsToolUseLimitReachedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusRetrying();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusExhaustedValidationWorks()
    {
        BetaManagedAgentsToolUseLimitReachedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusExhausted();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusTerminalValidationWorks()
    {
        BetaManagedAgentsToolUseLimitReachedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusTerminal();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusRetryingSerializationRoundtripWorks()
    {
        BetaManagedAgentsToolUseLimitReachedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusRetrying();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsToolUseLimitReachedErrorRetryStatus>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusExhaustedSerializationRoundtripWorks()
    {
        BetaManagedAgentsToolUseLimitReachedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusExhausted();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsToolUseLimitReachedErrorRetryStatus>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusTerminalSerializationRoundtripWorks()
    {
        BetaManagedAgentsToolUseLimitReachedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusTerminal();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsToolUseLimitReachedErrorRetryStatus>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusRetryingTypeWorks()
    {
        BetaManagedAgentsToolUseLimitReachedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusRetrying();
        Assert.Equal(
            BetaManagedAgentsToolUseLimitReachedErrorRetryStatusType.Retrying,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusExhaustedTypeWorks()
    {
        BetaManagedAgentsToolUseLimitReachedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusExhausted();
        Assert.Equal(
            BetaManagedAgentsToolUseLimitReachedErrorRetryStatusType.Exhausted,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusTerminalTypeWorks()
    {
        BetaManagedAgentsToolUseLimitReachedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusTerminal();
        Assert.Equal(
            BetaManagedAgentsToolUseLimitReachedErrorRetryStatusType.Terminal,
            value.Type.Value()
        );
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsToolUseLimitReachedErrorRetryStatus value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "exhausted"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsToolUseLimitReachedErrorRetryStatusType> expectedType =
            BetaManagedAgentsToolUseLimitReachedErrorRetryStatusType.Exhausted;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsToolUseLimitReachedErrorRetryStatus emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsToolUseLimitReachedErrorRetryStatusTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsToolUseLimitReachedErrorRetryStatusType.Retrying)]
    [InlineData(BetaManagedAgentsToolUseLimitReachedErrorRetryStatusType.Exhausted)]
    [InlineData(BetaManagedAgentsToolUseLimitReachedErrorRetryStatusType.Terminal)]
    public void Validation_Works(BetaManagedAgentsToolUseLimitReachedErrorRetryStatusType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsToolUseLimitReachedErrorRetryStatusType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsToolUseLimitReachedErrorRetryStatusType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsToolUseLimitReachedErrorRetryStatusType.Retrying)]
    [InlineData(BetaManagedAgentsToolUseLimitReachedErrorRetryStatusType.Exhausted)]
    [InlineData(BetaManagedAgentsToolUseLimitReachedErrorRetryStatusType.Terminal)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsToolUseLimitReachedErrorRetryStatusType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsToolUseLimitReachedErrorRetryStatusType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsToolUseLimitReachedErrorRetryStatusType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsToolUseLimitReachedErrorRetryStatusType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsToolUseLimitReachedErrorRetryStatusType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
