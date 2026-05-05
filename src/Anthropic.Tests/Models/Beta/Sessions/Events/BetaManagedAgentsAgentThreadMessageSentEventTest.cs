using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsAgentThreadMessageSentEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentThreadMessageSentEvent
        {
            ID = "id",
            Content =
            [
                new BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ToSessionThreadID = "to_session_thread_id",
            Type = BetaManagedAgentsAgentThreadMessageSentEventType.AgentThreadMessageSent,
            ToAgentName = "to_agent_name",
        };

        string expectedID = "id";
        List<BetaManagedAgentsAgentThreadMessageSentEventContent> expectedContent =
        [
            new BetaManagedAgentsTextBlock()
            {
                Text = "Where is my order #1234?",
                Type = BetaManagedAgentsTextBlockType.Text,
            },
        ];
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedToSessionThreadID = "to_session_thread_id";
        ApiEnum<string, BetaManagedAgentsAgentThreadMessageSentEventType> expectedType =
            BetaManagedAgentsAgentThreadMessageSentEventType.AgentThreadMessageSent;
        string expectedToAgentName = "to_agent_name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedContent.Count, model.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], model.Content[i]);
        }
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.Equal(expectedToSessionThreadID, model.ToSessionThreadID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedToAgentName, model.ToAgentName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentThreadMessageSentEvent
        {
            ID = "id",
            Content =
            [
                new BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ToSessionThreadID = "to_session_thread_id",
            Type = BetaManagedAgentsAgentThreadMessageSentEventType.AgentThreadMessageSent,
            ToAgentName = "to_agent_name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentThreadMessageSentEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsAgentThreadMessageSentEvent
        {
            ID = "id",
            Content =
            [
                new BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ToSessionThreadID = "to_session_thread_id",
            Type = BetaManagedAgentsAgentThreadMessageSentEventType.AgentThreadMessageSent,
            ToAgentName = "to_agent_name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentThreadMessageSentEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<BetaManagedAgentsAgentThreadMessageSentEventContent> expectedContent =
        [
            new BetaManagedAgentsTextBlock()
            {
                Text = "Where is my order #1234?",
                Type = BetaManagedAgentsTextBlockType.Text,
            },
        ];
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedToSessionThreadID = "to_session_thread_id";
        ApiEnum<string, BetaManagedAgentsAgentThreadMessageSentEventType> expectedType =
            BetaManagedAgentsAgentThreadMessageSentEventType.AgentThreadMessageSent;
        string expectedToAgentName = "to_agent_name";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedContent.Count, deserialized.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], deserialized.Content[i]);
        }
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.Equal(expectedToSessionThreadID, deserialized.ToSessionThreadID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedToAgentName, deserialized.ToAgentName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsAgentThreadMessageSentEvent
        {
            ID = "id",
            Content =
            [
                new BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ToSessionThreadID = "to_session_thread_id",
            Type = BetaManagedAgentsAgentThreadMessageSentEventType.AgentThreadMessageSent,
            ToAgentName = "to_agent_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsAgentThreadMessageSentEvent
        {
            ID = "id",
            Content =
            [
                new BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ToSessionThreadID = "to_session_thread_id",
            Type = BetaManagedAgentsAgentThreadMessageSentEventType.AgentThreadMessageSent,
        };

        Assert.Null(model.ToAgentName);
        Assert.False(model.RawData.ContainsKey("to_agent_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsAgentThreadMessageSentEvent
        {
            ID = "id",
            Content =
            [
                new BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ToSessionThreadID = "to_session_thread_id",
            Type = BetaManagedAgentsAgentThreadMessageSentEventType.AgentThreadMessageSent,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsAgentThreadMessageSentEvent
        {
            ID = "id",
            Content =
            [
                new BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ToSessionThreadID = "to_session_thread_id",
            Type = BetaManagedAgentsAgentThreadMessageSentEventType.AgentThreadMessageSent,

            ToAgentName = null,
        };

        Assert.Null(model.ToAgentName);
        Assert.True(model.RawData.ContainsKey("to_agent_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsAgentThreadMessageSentEvent
        {
            ID = "id",
            Content =
            [
                new BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ToSessionThreadID = "to_session_thread_id",
            Type = BetaManagedAgentsAgentThreadMessageSentEventType.AgentThreadMessageSent,

            ToAgentName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsAgentThreadMessageSentEvent
        {
            ID = "id",
            Content =
            [
                new BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ToSessionThreadID = "to_session_thread_id",
            Type = BetaManagedAgentsAgentThreadMessageSentEventType.AgentThreadMessageSent,
            ToAgentName = "to_agent_name",
        };

        BetaManagedAgentsAgentThreadMessageSentEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsAgentThreadMessageSentEventContentTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsTextBlockValidationWorks()
    {
        BetaManagedAgentsAgentThreadMessageSentEventContent value = new BetaManagedAgentsTextBlock()
        {
            Text = "Where is my order #1234?",
            Type = BetaManagedAgentsTextBlockType.Text,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsImageBlockValidationWorks()
    {
        BetaManagedAgentsAgentThreadMessageSentEventContent value =
            new BetaManagedAgentsImageBlock()
            {
                Source = new BetaManagedAgentsBase64ImageSource()
                {
                    Data = "x",
                    MediaType = "x",
                    Type = BetaManagedAgentsBase64ImageSourceType.Base64,
                },
                Type = BetaManagedAgentsImageBlockType.Image,
            };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsDocumentBlockValidationWorks()
    {
        BetaManagedAgentsAgentThreadMessageSentEventContent value =
            new BetaManagedAgentsDocumentBlock()
            {
                Source = new BetaManagedAgentsBase64DocumentSource()
                {
                    Data = "x",
                    MediaType = "x",
                    Type = BetaManagedAgentsBase64DocumentSourceType.Base64,
                },
                Type = BetaManagedAgentsDocumentBlockType.Document,
                Context = "context",
                Title = "title",
            };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsTextBlockSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentThreadMessageSentEventContent value = new BetaManagedAgentsTextBlock()
        {
            Text = "Where is my order #1234?",
            Type = BetaManagedAgentsTextBlockType.Text,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsAgentThreadMessageSentEventContent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsImageBlockSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentThreadMessageSentEventContent value =
            new BetaManagedAgentsImageBlock()
            {
                Source = new BetaManagedAgentsBase64ImageSource()
                {
                    Data = "x",
                    MediaType = "x",
                    Type = BetaManagedAgentsBase64ImageSourceType.Base64,
                },
                Type = BetaManagedAgentsImageBlockType.Image,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsAgentThreadMessageSentEventContent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsDocumentBlockSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentThreadMessageSentEventContent value =
            new BetaManagedAgentsDocumentBlock()
            {
                Source = new BetaManagedAgentsBase64DocumentSource()
                {
                    Data = "x",
                    MediaType = "x",
                    Type = BetaManagedAgentsBase64DocumentSourceType.Base64,
                },
                Type = BetaManagedAgentsDocumentBlockType.Document,
                Context = "context",
                Title = "title",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsAgentThreadMessageSentEventContent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class BetaManagedAgentsAgentThreadMessageSentEventTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsAgentThreadMessageSentEventType.AgentThreadMessageSent)]
    public void Validation_Works(BetaManagedAgentsAgentThreadMessageSentEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentThreadMessageSentEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentThreadMessageSentEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsAgentThreadMessageSentEventType.AgentThreadMessageSent)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsAgentThreadMessageSentEventType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentThreadMessageSentEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentThreadMessageSentEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentThreadMessageSentEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentThreadMessageSentEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
