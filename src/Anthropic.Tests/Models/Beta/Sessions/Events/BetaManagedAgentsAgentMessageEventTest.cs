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
            ID = "sevt_011CZkZHPq1jCdq5lbRTjiVnz",
            Content =
            [
                new()
                {
                    Text = "Let me look up order #1234 for you.",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Type = BetaManagedAgentsAgentMessageEventType.AgentMessage,
        };

        string expectedID = "sevt_011CZkZHPq1jCdq5lbRTjiVnz";
        List<BetaManagedAgentsTextBlock> expectedContent =
        [
            new()
            {
                Text = "Let me look up order #1234 for you.",
                Type = BetaManagedAgentsTextBlockType.Text,
            },
        ];
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        ApiEnum<string, BetaManagedAgentsAgentMessageEventType> expectedType =
            BetaManagedAgentsAgentMessageEventType.AgentMessage;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedContent.Count, model.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], model.Content[i]);
        }
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentMessageEvent
        {
            ID = "sevt_011CZkZHPq1jCdq5lbRTjiVnz",
            Content =
            [
                new()
                {
                    Text = "Let me look up order #1234 for you.",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Type = BetaManagedAgentsAgentMessageEventType.AgentMessage,
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
            ID = "sevt_011CZkZHPq1jCdq5lbRTjiVnz",
            Content =
            [
                new()
                {
                    Text = "Let me look up order #1234 for you.",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Type = BetaManagedAgentsAgentMessageEventType.AgentMessage,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentMessageEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "sevt_011CZkZHPq1jCdq5lbRTjiVnz";
        List<BetaManagedAgentsTextBlock> expectedContent =
        [
            new()
            {
                Text = "Let me look up order #1234 for you.",
                Type = BetaManagedAgentsTextBlockType.Text,
            },
        ];
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");
        ApiEnum<string, BetaManagedAgentsAgentMessageEventType> expectedType =
            BetaManagedAgentsAgentMessageEventType.AgentMessage;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedContent.Count, deserialized.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], deserialized.Content[i]);
        }
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsAgentMessageEvent
        {
            ID = "sevt_011CZkZHPq1jCdq5lbRTjiVnz",
            Content =
            [
                new()
                {
                    Text = "Let me look up order #1234 for you.",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Type = BetaManagedAgentsAgentMessageEventType.AgentMessage,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsAgentMessageEvent
        {
            ID = "sevt_011CZkZHPq1jCdq5lbRTjiVnz",
            Content =
            [
                new()
                {
                    Text = "Let me look up order #1234 for you.",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
            Type = BetaManagedAgentsAgentMessageEventType.AgentMessage,
        };

        BetaManagedAgentsAgentMessageEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsAgentMessageEventTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsAgentMessageEventType.AgentMessage)]
    public void Validation_Works(BetaManagedAgentsAgentMessageEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentMessageEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentMessageEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsAgentMessageEventType.AgentMessage)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsAgentMessageEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentMessageEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentMessageEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentMessageEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentMessageEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
