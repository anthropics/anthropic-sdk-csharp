using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsCompactionLimitReachedErrorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsCompactionLimitReachedError
        {
            Message =
                "This turn stopped because the context was compacted the maximum number of times in a row without the model producing a message or a tool call. Nothing failed. This can happen when content sent with every request, such as a large system prompt, leaves too little room for the conversation. Send the session a new message to continue; nothing from the stopped turn is discarded.",
            RetryStatus = new BetaManagedAgentsRetryStatusExhausted(),
        };

        string expectedMessage =
            "This turn stopped because the context was compacted the maximum number of times in a row without the model producing a message or a tool call. Nothing failed. This can happen when content sent with every request, such as a large system prompt, leaves too little room for the conversation. Send the session a new message to continue; nothing from the stopped turn is discarded.";
        BetaManagedAgentsCompactionLimitReachedErrorRetryStatus expectedRetryStatus =
            new BetaManagedAgentsRetryStatusExhausted();
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "compaction_limit_reached_error"
        );

        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedRetryStatus, model.RetryStatus);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsCompactionLimitReachedError
        {
            Message =
                "This turn stopped because the context was compacted the maximum number of times in a row without the model producing a message or a tool call. Nothing failed. This can happen when content sent with every request, such as a large system prompt, leaves too little room for the conversation. Send the session a new message to continue; nothing from the stopped turn is discarded.",
            RetryStatus = new BetaManagedAgentsRetryStatusExhausted(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsCompactionLimitReachedError>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsCompactionLimitReachedError
        {
            Message =
                "This turn stopped because the context was compacted the maximum number of times in a row without the model producing a message or a tool call. Nothing failed. This can happen when content sent with every request, such as a large system prompt, leaves too little room for the conversation. Send the session a new message to continue; nothing from the stopped turn is discarded.",
            RetryStatus = new BetaManagedAgentsRetryStatusExhausted(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsCompactionLimitReachedError>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMessage =
            "This turn stopped because the context was compacted the maximum number of times in a row without the model producing a message or a tool call. Nothing failed. This can happen when content sent with every request, such as a large system prompt, leaves too little room for the conversation. Send the session a new message to continue; nothing from the stopped turn is discarded.";
        BetaManagedAgentsCompactionLimitReachedErrorRetryStatus expectedRetryStatus =
            new BetaManagedAgentsRetryStatusExhausted();
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "compaction_limit_reached_error"
        );

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedRetryStatus, deserialized.RetryStatus);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsCompactionLimitReachedError
        {
            Message =
                "This turn stopped because the context was compacted the maximum number of times in a row without the model producing a message or a tool call. Nothing failed. This can happen when content sent with every request, such as a large system prompt, leaves too little room for the conversation. Send the session a new message to continue; nothing from the stopped turn is discarded.",
            RetryStatus = new BetaManagedAgentsRetryStatusExhausted(),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsCompactionLimitReachedError
        {
            Message =
                "This turn stopped because the context was compacted the maximum number of times in a row without the model producing a message or a tool call. Nothing failed. This can happen when content sent with every request, such as a large system prompt, leaves too little room for the conversation. Send the session a new message to continue; nothing from the stopped turn is discarded.",
            RetryStatus = new BetaManagedAgentsRetryStatusExhausted(),
        };

        BetaManagedAgentsCompactionLimitReachedError copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsCompactionLimitReachedErrorRetryStatusTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsRetryStatusRetryingValidationWorks()
    {
        BetaManagedAgentsCompactionLimitReachedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusRetrying();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusExhaustedValidationWorks()
    {
        BetaManagedAgentsCompactionLimitReachedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusExhausted();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusTerminalValidationWorks()
    {
        BetaManagedAgentsCompactionLimitReachedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusTerminal();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusRetryingSerializationRoundtripWorks()
    {
        BetaManagedAgentsCompactionLimitReachedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusRetrying();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsCompactionLimitReachedErrorRetryStatus>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusExhaustedSerializationRoundtripWorks()
    {
        BetaManagedAgentsCompactionLimitReachedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusExhausted();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsCompactionLimitReachedErrorRetryStatus>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusTerminalSerializationRoundtripWorks()
    {
        BetaManagedAgentsCompactionLimitReachedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusTerminal();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsCompactionLimitReachedErrorRetryStatus>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusRetryingTypeWorks()
    {
        BetaManagedAgentsCompactionLimitReachedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusRetrying();
        Assert.Equal(
            BetaManagedAgentsCompactionLimitReachedErrorRetryStatusType.Retrying,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusExhaustedTypeWorks()
    {
        BetaManagedAgentsCompactionLimitReachedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusExhausted();
        Assert.Equal(
            BetaManagedAgentsCompactionLimitReachedErrorRetryStatusType.Exhausted,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsRetryStatusTerminalTypeWorks()
    {
        BetaManagedAgentsCompactionLimitReachedErrorRetryStatus value =
            new BetaManagedAgentsRetryStatusTerminal();
        Assert.Equal(
            BetaManagedAgentsCompactionLimitReachedErrorRetryStatusType.Terminal,
            value.Type.Value()
        );
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsCompactionLimitReachedErrorRetryStatus value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "exhausted"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsCompactionLimitReachedErrorRetryStatusType> expectedType =
            BetaManagedAgentsCompactionLimitReachedErrorRetryStatusType.Exhausted;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsCompactionLimitReachedErrorRetryStatus emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsCompactionLimitReachedErrorRetryStatusTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsCompactionLimitReachedErrorRetryStatusType.Retrying)]
    [InlineData(BetaManagedAgentsCompactionLimitReachedErrorRetryStatusType.Exhausted)]
    [InlineData(BetaManagedAgentsCompactionLimitReachedErrorRetryStatusType.Terminal)]
    public void Validation_Works(
        BetaManagedAgentsCompactionLimitReachedErrorRetryStatusType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsCompactionLimitReachedErrorRetryStatusType> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsCompactionLimitReachedErrorRetryStatusType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsCompactionLimitReachedErrorRetryStatusType.Retrying)]
    [InlineData(BetaManagedAgentsCompactionLimitReachedErrorRetryStatusType.Exhausted)]
    [InlineData(BetaManagedAgentsCompactionLimitReachedErrorRetryStatusType.Terminal)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsCompactionLimitReachedErrorRetryStatusType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsCompactionLimitReachedErrorRetryStatusType> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsCompactionLimitReachedErrorRetryStatusType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsCompactionLimitReachedErrorRetryStatusType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsCompactionLimitReachedErrorRetryStatusType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
