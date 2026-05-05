using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsAgentThreadMessageReceivedEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentThreadMessageReceivedEvent
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
            FromSessionThreadID = "from_session_thread_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsAgentThreadMessageReceivedEventType.AgentThreadMessageReceived,
            FromAgentName = "from_agent_name",
        };

        string expectedID = "id";
        List<BetaManagedAgentsAgentThreadMessageReceivedEventContent> expectedContent =
        [
            new BetaManagedAgentsTextBlock()
            {
                Text = "Where is my order #1234?",
                Type = BetaManagedAgentsTextBlockType.Text,
            },
        ];
        string expectedFromSessionThreadID = "from_session_thread_id";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, BetaManagedAgentsAgentThreadMessageReceivedEventType> expectedType =
            BetaManagedAgentsAgentThreadMessageReceivedEventType.AgentThreadMessageReceived;
        string expectedFromAgentName = "from_agent_name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedContent.Count, model.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], model.Content[i]);
        }
        Assert.Equal(expectedFromSessionThreadID, model.FromSessionThreadID);
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedFromAgentName, model.FromAgentName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentThreadMessageReceivedEvent
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
            FromSessionThreadID = "from_session_thread_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsAgentThreadMessageReceivedEventType.AgentThreadMessageReceived,
            FromAgentName = "from_agent_name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsAgentThreadMessageReceivedEvent>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsAgentThreadMessageReceivedEvent
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
            FromSessionThreadID = "from_session_thread_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsAgentThreadMessageReceivedEventType.AgentThreadMessageReceived,
            FromAgentName = "from_agent_name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsAgentThreadMessageReceivedEvent>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<BetaManagedAgentsAgentThreadMessageReceivedEventContent> expectedContent =
        [
            new BetaManagedAgentsTextBlock()
            {
                Text = "Where is my order #1234?",
                Type = BetaManagedAgentsTextBlockType.Text,
            },
        ];
        string expectedFromSessionThreadID = "from_session_thread_id";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, BetaManagedAgentsAgentThreadMessageReceivedEventType> expectedType =
            BetaManagedAgentsAgentThreadMessageReceivedEventType.AgentThreadMessageReceived;
        string expectedFromAgentName = "from_agent_name";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedContent.Count, deserialized.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], deserialized.Content[i]);
        }
        Assert.Equal(expectedFromSessionThreadID, deserialized.FromSessionThreadID);
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedFromAgentName, deserialized.FromAgentName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsAgentThreadMessageReceivedEvent
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
            FromSessionThreadID = "from_session_thread_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsAgentThreadMessageReceivedEventType.AgentThreadMessageReceived,
            FromAgentName = "from_agent_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsAgentThreadMessageReceivedEvent
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
            FromSessionThreadID = "from_session_thread_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsAgentThreadMessageReceivedEventType.AgentThreadMessageReceived,
        };

        Assert.Null(model.FromAgentName);
        Assert.False(model.RawData.ContainsKey("from_agent_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsAgentThreadMessageReceivedEvent
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
            FromSessionThreadID = "from_session_thread_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsAgentThreadMessageReceivedEventType.AgentThreadMessageReceived,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsAgentThreadMessageReceivedEvent
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
            FromSessionThreadID = "from_session_thread_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsAgentThreadMessageReceivedEventType.AgentThreadMessageReceived,

            FromAgentName = null,
        };

        Assert.Null(model.FromAgentName);
        Assert.True(model.RawData.ContainsKey("from_agent_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsAgentThreadMessageReceivedEvent
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
            FromSessionThreadID = "from_session_thread_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsAgentThreadMessageReceivedEventType.AgentThreadMessageReceived,

            FromAgentName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsAgentThreadMessageReceivedEvent
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
            FromSessionThreadID = "from_session_thread_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsAgentThreadMessageReceivedEventType.AgentThreadMessageReceived,
            FromAgentName = "from_agent_name",
        };

        BetaManagedAgentsAgentThreadMessageReceivedEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsAgentThreadMessageReceivedEventContentTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsTextBlockValidationWorks()
    {
        BetaManagedAgentsAgentThreadMessageReceivedEventContent value =
            new BetaManagedAgentsTextBlock()
            {
                Text = "Where is my order #1234?",
                Type = BetaManagedAgentsTextBlockType.Text,
            };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsImageBlockValidationWorks()
    {
        BetaManagedAgentsAgentThreadMessageReceivedEventContent value =
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
        BetaManagedAgentsAgentThreadMessageReceivedEventContent value =
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
        BetaManagedAgentsAgentThreadMessageReceivedEventContent value =
            new BetaManagedAgentsTextBlock()
            {
                Text = "Where is my order #1234?",
                Type = BetaManagedAgentsTextBlockType.Text,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsAgentThreadMessageReceivedEventContent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsImageBlockSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentThreadMessageReceivedEventContent value =
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
            JsonSerializer.Deserialize<BetaManagedAgentsAgentThreadMessageReceivedEventContent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsDocumentBlockSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentThreadMessageReceivedEventContent value =
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
            JsonSerializer.Deserialize<BetaManagedAgentsAgentThreadMessageReceivedEventContent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}

public class BetaManagedAgentsAgentThreadMessageReceivedEventTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsAgentThreadMessageReceivedEventType.AgentThreadMessageReceived)]
    public void Validation_Works(BetaManagedAgentsAgentThreadMessageReceivedEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentThreadMessageReceivedEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentThreadMessageReceivedEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsAgentThreadMessageReceivedEventType.AgentThreadMessageReceived)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsAgentThreadMessageReceivedEventType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentThreadMessageReceivedEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentThreadMessageReceivedEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentThreadMessageReceivedEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentThreadMessageReceivedEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
