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
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ToSessionThreadID = "to_session_thread_id",
            ToAgentName = "to_agent_name",
        };

        string expectedID = "id";
        List<BetaManagedAgentsAgentThreadMessageSentEventContent> expectedContent =
        [
            new BetaManagedAgentsTextBlock("Where is my order #1234?"),
        ];
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedToSessionThreadID = "to_session_thread_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("agent.thread_message_sent");
        string expectedToAgentName = "to_agent_name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedContent.Count, model.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], model.Content[i]);
        }
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.Equal(expectedToSessionThreadID, model.ToSessionThreadID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedToAgentName, model.ToAgentName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentThreadMessageSentEvent
        {
            ID = "id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ToSessionThreadID = "to_session_thread_id",
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
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ToSessionThreadID = "to_session_thread_id",
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
            new BetaManagedAgentsTextBlock("Where is my order #1234?"),
        ];
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedToSessionThreadID = "to_session_thread_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("agent.thread_message_sent");
        string expectedToAgentName = "to_agent_name";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedContent.Count, deserialized.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], deserialized.Content[i]);
        }
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.Equal(expectedToSessionThreadID, deserialized.ToSessionThreadID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedToAgentName, deserialized.ToAgentName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsAgentThreadMessageSentEvent
        {
            ID = "id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ToSessionThreadID = "to_session_thread_id",
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
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ToSessionThreadID = "to_session_thread_id",
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
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ToSessionThreadID = "to_session_thread_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsAgentThreadMessageSentEvent
        {
            ID = "id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ToSessionThreadID = "to_session_thread_id",

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
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ToSessionThreadID = "to_session_thread_id",

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
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ToSessionThreadID = "to_session_thread_id",
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
        BetaManagedAgentsAgentThreadMessageSentEventContent value = new BetaManagedAgentsTextBlock(
            "Where is my order #1234?"
        );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsImageBlockValidationWorks()
    {
        BetaManagedAgentsAgentThreadMessageSentEventContent value = new BetaManagedAgentsImageBlock(
            new BetaManagedAgentsBase64ImageSource() { Data = "x", MediaType = "x" }
        );
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
                },
                Context = "context",
                Title = "title",
            };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRedactedBlockValidationWorks()
    {
        BetaManagedAgentsAgentThreadMessageSentEventContent value =
            new BetaManagedAgentsRedactedBlock();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsTextBlockSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentThreadMessageSentEventContent value = new BetaManagedAgentsTextBlock(
            "Where is my order #1234?"
        );
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
        BetaManagedAgentsAgentThreadMessageSentEventContent value = new BetaManagedAgentsImageBlock(
            new BetaManagedAgentsBase64ImageSource() { Data = "x", MediaType = "x" }
        );
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
                },
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

    [Fact]
    public void BetaManagedAgentsRedactedBlockSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentThreadMessageSentEventContent value =
            new BetaManagedAgentsRedactedBlock();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsAgentThreadMessageSentEventContent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsTextBlockTypeWorks()
    {
        BetaManagedAgentsAgentThreadMessageSentEventContent value = new BetaManagedAgentsTextBlock(
            "Where is my order #1234?"
        );
        Assert.Equal(
            BetaManagedAgentsAgentThreadMessageSentEventContentType.Text,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsImageBlockTypeWorks()
    {
        BetaManagedAgentsAgentThreadMessageSentEventContent value = new BetaManagedAgentsImageBlock(
            new BetaManagedAgentsBase64ImageSource() { Data = "x", MediaType = "x" }
        );
        Assert.Equal(
            BetaManagedAgentsAgentThreadMessageSentEventContentType.Image,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsDocumentBlockTypeWorks()
    {
        BetaManagedAgentsAgentThreadMessageSentEventContent value =
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
            BetaManagedAgentsAgentThreadMessageSentEventContentType.Document,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsRedactedBlockTypeWorks()
    {
        BetaManagedAgentsAgentThreadMessageSentEventContent value =
            new BetaManagedAgentsRedactedBlock();
        Assert.Equal(
            BetaManagedAgentsAgentThreadMessageSentEventContentType.Redacted,
            value.Type.Value()
        );
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsAgentThreadMessageSentEventContent value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "text"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsAgentThreadMessageSentEventContentType> expectedType =
            BetaManagedAgentsAgentThreadMessageSentEventContentType.Text;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsAgentThreadMessageSentEventContent emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsAgentThreadMessageSentEventContentTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsAgentThreadMessageSentEventContentType.Text)]
    [InlineData(BetaManagedAgentsAgentThreadMessageSentEventContentType.Image)]
    [InlineData(BetaManagedAgentsAgentThreadMessageSentEventContentType.Document)]
    [InlineData(BetaManagedAgentsAgentThreadMessageSentEventContentType.Redacted)]
    public void Validation_Works(BetaManagedAgentsAgentThreadMessageSentEventContentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentThreadMessageSentEventContentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentThreadMessageSentEventContentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsAgentThreadMessageSentEventContentType.Text)]
    [InlineData(BetaManagedAgentsAgentThreadMessageSentEventContentType.Image)]
    [InlineData(BetaManagedAgentsAgentThreadMessageSentEventContentType.Document)]
    [InlineData(BetaManagedAgentsAgentThreadMessageSentEventContentType.Redacted)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsAgentThreadMessageSentEventContentType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentThreadMessageSentEventContentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentThreadMessageSentEventContentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentThreadMessageSentEventContentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentThreadMessageSentEventContentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
