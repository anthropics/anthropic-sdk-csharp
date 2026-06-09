using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsSystemMessageEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSystemMessageEvent
        {
            ID = "id",
            Content =
            [
                new()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsSystemContentBlockType.Text,
                },
            ],
            Type = BetaManagedAgentsSystemMessageEventType.SystemMessage,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        List<BetaManagedAgentsSystemContentBlock> expectedContent =
        [
            new()
            {
                Text = "Where is my order #1234?",
                Type = BetaManagedAgentsSystemContentBlockType.Text,
            },
        ];
        ApiEnum<string, BetaManagedAgentsSystemMessageEventType> expectedType =
            BetaManagedAgentsSystemMessageEventType.SystemMessage;
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedContent.Count, model.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], model.Content[i]);
        }
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSystemMessageEvent
        {
            ID = "id",
            Content =
            [
                new()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsSystemContentBlockType.Text,
                },
            ],
            Type = BetaManagedAgentsSystemMessageEventType.SystemMessage,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSystemMessageEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSystemMessageEvent
        {
            ID = "id",
            Content =
            [
                new()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsSystemContentBlockType.Text,
                },
            ],
            Type = BetaManagedAgentsSystemMessageEventType.SystemMessage,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSystemMessageEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<BetaManagedAgentsSystemContentBlock> expectedContent =
        [
            new()
            {
                Text = "Where is my order #1234?",
                Type = BetaManagedAgentsSystemContentBlockType.Text,
            },
        ];
        ApiEnum<string, BetaManagedAgentsSystemMessageEventType> expectedType =
            BetaManagedAgentsSystemMessageEventType.SystemMessage;
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedContent.Count, deserialized.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], deserialized.Content[i]);
        }
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSystemMessageEvent
        {
            ID = "id",
            Content =
            [
                new()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsSystemContentBlockType.Text,
                },
            ],
            Type = BetaManagedAgentsSystemMessageEventType.SystemMessage,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsSystemMessageEvent
        {
            ID = "id",
            Content =
            [
                new()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsSystemContentBlockType.Text,
                },
            ],
            Type = BetaManagedAgentsSystemMessageEventType.SystemMessage,
        };

        Assert.Null(model.ProcessedAt);
        Assert.False(model.RawData.ContainsKey("processed_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsSystemMessageEvent
        {
            ID = "id",
            Content =
            [
                new()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsSystemContentBlockType.Text,
                },
            ],
            Type = BetaManagedAgentsSystemMessageEventType.SystemMessage,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsSystemMessageEvent
        {
            ID = "id",
            Content =
            [
                new()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsSystemContentBlockType.Text,
                },
            ],
            Type = BetaManagedAgentsSystemMessageEventType.SystemMessage,

            ProcessedAt = null,
        };

        Assert.Null(model.ProcessedAt);
        Assert.True(model.RawData.ContainsKey("processed_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsSystemMessageEvent
        {
            ID = "id",
            Content =
            [
                new()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsSystemContentBlockType.Text,
                },
            ],
            Type = BetaManagedAgentsSystemMessageEventType.SystemMessage,

            ProcessedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSystemMessageEvent
        {
            ID = "id",
            Content =
            [
                new()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsSystemContentBlockType.Text,
                },
            ],
            Type = BetaManagedAgentsSystemMessageEventType.SystemMessage,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        BetaManagedAgentsSystemMessageEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsSystemMessageEventTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSystemMessageEventType.SystemMessage)]
    public void Validation_Works(BetaManagedAgentsSystemMessageEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSystemMessageEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSystemMessageEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSystemMessageEventType.SystemMessage)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsSystemMessageEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSystemMessageEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSystemMessageEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSystemMessageEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSystemMessageEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
