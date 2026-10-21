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
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            FromSessionThreadID = "from_session_thread_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FromAgentName = "from_agent_name",
        };

        string expectedID = "id";
        List<BetaManagedAgentsAgentThreadMessageReceivedEventContent> expectedContent =
        [
            new BetaManagedAgentsTextBlock("Where is my order #1234?"),
        ];
        string expectedFromSessionThreadID = "from_session_thread_id";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "agent.thread_message_received"
        );
        string expectedFromAgentName = "from_agent_name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedContent.Count, model.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], model.Content[i]);
        }
        Assert.Equal(expectedFromSessionThreadID, model.FromSessionThreadID);
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedFromAgentName, model.FromAgentName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentThreadMessageReceivedEvent
        {
            ID = "id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            FromSessionThreadID = "from_session_thread_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            FromSessionThreadID = "from_session_thread_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            new BetaManagedAgentsTextBlock("Where is my order #1234?"),
        ];
        string expectedFromSessionThreadID = "from_session_thread_id";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "agent.thread_message_received"
        );
        string expectedFromAgentName = "from_agent_name";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedContent.Count, deserialized.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], deserialized.Content[i]);
        }
        Assert.Equal(expectedFromSessionThreadID, deserialized.FromSessionThreadID);
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedFromAgentName, deserialized.FromAgentName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsAgentThreadMessageReceivedEvent
        {
            ID = "id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            FromSessionThreadID = "from_session_thread_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            FromSessionThreadID = "from_session_thread_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            FromSessionThreadID = "from_session_thread_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsAgentThreadMessageReceivedEvent
        {
            ID = "id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            FromSessionThreadID = "from_session_thread_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

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
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            FromSessionThreadID = "from_session_thread_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

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
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            FromSessionThreadID = "from_session_thread_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            new BetaManagedAgentsTextBlock("Where is my order #1234?");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsImageBlockValidationWorks()
    {
        BetaManagedAgentsAgentThreadMessageReceivedEventContent value =
            new BetaManagedAgentsImageBlock(
                new BetaManagedAgentsBase64ImageSource() { Data = "x", MediaType = "x" }
            );
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
                },
                Context = "context",
                Title = "title",
            };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRedactedBlockValidationWorks()
    {
        BetaManagedAgentsAgentThreadMessageReceivedEventContent value =
            new BetaManagedAgentsRedactedBlock();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsTextBlockSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentThreadMessageReceivedEventContent value =
            new BetaManagedAgentsTextBlock("Where is my order #1234?");
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
            new BetaManagedAgentsImageBlock(
                new BetaManagedAgentsBase64ImageSource() { Data = "x", MediaType = "x" }
            );
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
                },
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

    [Fact]
    public void BetaManagedAgentsRedactedBlockSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentThreadMessageReceivedEventContent value =
            new BetaManagedAgentsRedactedBlock();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsAgentThreadMessageReceivedEventContent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsTextBlockTypeWorks()
    {
        BetaManagedAgentsAgentThreadMessageReceivedEventContent value =
            new BetaManagedAgentsTextBlock("Where is my order #1234?");
        Assert.Equal(
            BetaManagedAgentsAgentThreadMessageReceivedEventContentType.Text,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsImageBlockTypeWorks()
    {
        BetaManagedAgentsAgentThreadMessageReceivedEventContent value =
            new BetaManagedAgentsImageBlock(
                new BetaManagedAgentsBase64ImageSource() { Data = "x", MediaType = "x" }
            );
        Assert.Equal(
            BetaManagedAgentsAgentThreadMessageReceivedEventContentType.Image,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsDocumentBlockTypeWorks()
    {
        BetaManagedAgentsAgentThreadMessageReceivedEventContent value =
            new BetaManagedAgentsDocumentBlock()
            {
                Source = new BetaManagedAgentsBase64DocumentSource()
                {
                    Data = "x",
                    MediaType = "x",
                },
                Context = "context",
                Title = "title",
            };
        Assert.Equal(
            BetaManagedAgentsAgentThreadMessageReceivedEventContentType.Document,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsRedactedBlockTypeWorks()
    {
        BetaManagedAgentsAgentThreadMessageReceivedEventContent value =
            new BetaManagedAgentsRedactedBlock();
        Assert.Equal(
            BetaManagedAgentsAgentThreadMessageReceivedEventContentType.Redacted,
            value.Type.Value()
        );
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsAgentThreadMessageReceivedEventContent value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "text"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsAgentThreadMessageReceivedEventContentType> expectedType =
            BetaManagedAgentsAgentThreadMessageReceivedEventContentType.Text;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsAgentThreadMessageReceivedEventContent emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsAgentThreadMessageReceivedEventContentTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsAgentThreadMessageReceivedEventContentType.Text)]
    [InlineData(BetaManagedAgentsAgentThreadMessageReceivedEventContentType.Image)]
    [InlineData(BetaManagedAgentsAgentThreadMessageReceivedEventContentType.Document)]
    [InlineData(BetaManagedAgentsAgentThreadMessageReceivedEventContentType.Redacted)]
    public void Validation_Works(
        BetaManagedAgentsAgentThreadMessageReceivedEventContentType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentThreadMessageReceivedEventContentType> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentThreadMessageReceivedEventContentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsAgentThreadMessageReceivedEventContentType.Text)]
    [InlineData(BetaManagedAgentsAgentThreadMessageReceivedEventContentType.Image)]
    [InlineData(BetaManagedAgentsAgentThreadMessageReceivedEventContentType.Document)]
    [InlineData(BetaManagedAgentsAgentThreadMessageReceivedEventContentType.Redacted)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsAgentThreadMessageReceivedEventContentType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentThreadMessageReceivedEventContentType> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentThreadMessageReceivedEventContentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentThreadMessageReceivedEventContentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentThreadMessageReceivedEventContentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
