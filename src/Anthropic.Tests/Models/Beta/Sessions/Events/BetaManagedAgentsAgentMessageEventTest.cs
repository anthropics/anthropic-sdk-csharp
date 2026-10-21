using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsAgentMessageEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentMessageEvent
        {
            ID = "sevt_011CZkZHPq1jCdq5mbRTjiVn",
            Content = [new BetaManagedAgentsTextBlock("Let me look up order #1234 for you.")],
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };

        string expectedID = "sevt_011CZkZHPq1jCdq5mbRTjiVn";
        List<BetaManagedAgentsAgentMessageEventContent> expectedContent =
        [
            new BetaManagedAgentsTextBlock("Let me look up order #1234 for you."),
        ];
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("agent.message");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedContent.Count, model.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], model.Content[i]);
        }
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentMessageEvent
        {
            ID = "sevt_011CZkZHPq1jCdq5mbRTjiVn",
            Content = [new BetaManagedAgentsTextBlock("Let me look up order #1234 for you.")],
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentMessageEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsAgentMessageEvent
        {
            ID = "sevt_011CZkZHPq1jCdq5mbRTjiVn",
            Content = [new BetaManagedAgentsTextBlock("Let me look up order #1234 for you.")],
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentMessageEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "sevt_011CZkZHPq1jCdq5mbRTjiVn";
        List<BetaManagedAgentsAgentMessageEventContent> expectedContent =
        [
            new BetaManagedAgentsTextBlock("Let me look up order #1234 for you."),
        ];
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("agent.message");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedContent.Count, deserialized.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], deserialized.Content[i]);
        }
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsAgentMessageEvent
        {
            ID = "sevt_011CZkZHPq1jCdq5mbRTjiVn",
            Content = [new BetaManagedAgentsTextBlock("Let me look up order #1234 for you.")],
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsAgentMessageEvent
        {
            ID = "sevt_011CZkZHPq1jCdq5mbRTjiVn",
            Content = [new BetaManagedAgentsTextBlock("Let me look up order #1234 for you.")],
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };

        BetaManagedAgentsAgentMessageEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsAgentMessageEventContentTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsTextBlockValidationWorks()
    {
        BetaManagedAgentsAgentMessageEventContent value = new BetaManagedAgentsTextBlock(
            "Where is my order #1234?"
        );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRedactedBlockValidationWorks()
    {
        BetaManagedAgentsAgentMessageEventContent value = new BetaManagedAgentsRedactedBlock();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsTextBlockSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentMessageEventContent value = new BetaManagedAgentsTextBlock(
            "Where is my order #1234?"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentMessageEventContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsRedactedBlockSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentMessageEventContent value = new BetaManagedAgentsRedactedBlock();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentMessageEventContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsTextBlockTypeWorks()
    {
        BetaManagedAgentsAgentMessageEventContent value = new BetaManagedAgentsTextBlock(
            "Where is my order #1234?"
        );
        Assert.Equal(BetaManagedAgentsAgentMessageEventContentType.Text, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsRedactedBlockTypeWorks()
    {
        BetaManagedAgentsAgentMessageEventContent value = new BetaManagedAgentsRedactedBlock();
        Assert.Equal(BetaManagedAgentsAgentMessageEventContentType.Redacted, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsAgentMessageEventContent value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "text"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsAgentMessageEventContentType> expectedType =
            BetaManagedAgentsAgentMessageEventContentType.Text;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsAgentMessageEventContent emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsAgentMessageEventContentTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsAgentMessageEventContentType.Text)]
    [InlineData(BetaManagedAgentsAgentMessageEventContentType.Redacted)]
    public void Validation_Works(BetaManagedAgentsAgentMessageEventContentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentMessageEventContentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentMessageEventContentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsAgentMessageEventContentType.Text)]
    [InlineData(BetaManagedAgentsAgentMessageEventContentType.Redacted)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsAgentMessageEventContentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentMessageEventContentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentMessageEventContentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentMessageEventContentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentMessageEventContentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
