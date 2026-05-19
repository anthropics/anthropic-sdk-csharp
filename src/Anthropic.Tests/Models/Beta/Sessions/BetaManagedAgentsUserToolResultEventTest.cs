using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions;
using Events = Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsUserToolResultEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsUserToolResultEvent
        {
            ID = "id",
            ToolUseID = "tool_use_id",
            Type = BetaManagedAgentsUserToolResultEventType.UserToolResult,
            Content =
            [
                new Events::BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = Events::BetaManagedAgentsTextBlockType.Text,
                },
            ],
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };

        string expectedID = "id";
        string expectedToolUseID = "tool_use_id";
        ApiEnum<string, BetaManagedAgentsUserToolResultEventType> expectedType =
            BetaManagedAgentsUserToolResultEventType.UserToolResult;
        List<Content> expectedContent =
        [
            new Events::BetaManagedAgentsTextBlock()
            {
                Text = "Where is my order #1234?",
                Type = Events::BetaManagedAgentsTextBlockType.Text,
            },
        ];
        bool expectedIsError = true;
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedSessionThreadID = "session_thread_id";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.Equal(expectedType, model.Type);
        Assert.NotNull(model.Content);
        Assert.Equal(expectedContent.Count, model.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], model.Content[i]);
        }
        Assert.Equal(expectedIsError, model.IsError);
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.Equal(expectedSessionThreadID, model.SessionThreadID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsUserToolResultEvent
        {
            ID = "id",
            ToolUseID = "tool_use_id",
            Type = BetaManagedAgentsUserToolResultEventType.UserToolResult,
            Content =
            [
                new Events::BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = Events::BetaManagedAgentsTextBlockType.Text,
                },
            ],
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsUserToolResultEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsUserToolResultEvent
        {
            ID = "id",
            ToolUseID = "tool_use_id",
            Type = BetaManagedAgentsUserToolResultEventType.UserToolResult,
            Content =
            [
                new Events::BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = Events::BetaManagedAgentsTextBlockType.Text,
                },
            ],
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsUserToolResultEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedToolUseID = "tool_use_id";
        ApiEnum<string, BetaManagedAgentsUserToolResultEventType> expectedType =
            BetaManagedAgentsUserToolResultEventType.UserToolResult;
        List<Content> expectedContent =
        [
            new Events::BetaManagedAgentsTextBlock()
            {
                Text = "Where is my order #1234?",
                Type = Events::BetaManagedAgentsTextBlockType.Text,
            },
        ];
        bool expectedIsError = true;
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedSessionThreadID = "session_thread_id";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedToolUseID, deserialized.ToolUseID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.NotNull(deserialized.Content);
        Assert.Equal(expectedContent.Count, deserialized.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], deserialized.Content[i]);
        }
        Assert.Equal(expectedIsError, deserialized.IsError);
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.Equal(expectedSessionThreadID, deserialized.SessionThreadID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsUserToolResultEvent
        {
            ID = "id",
            ToolUseID = "tool_use_id",
            Type = BetaManagedAgentsUserToolResultEventType.UserToolResult,
            Content =
            [
                new Events::BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = Events::BetaManagedAgentsTextBlockType.Text,
                },
            ],
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsUserToolResultEvent
        {
            ID = "id",
            ToolUseID = "tool_use_id",
            Type = BetaManagedAgentsUserToolResultEventType.UserToolResult,
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsUserToolResultEvent
        {
            ID = "id",
            ToolUseID = "tool_use_id",
            Type = BetaManagedAgentsUserToolResultEventType.UserToolResult,
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsUserToolResultEvent
        {
            ID = "id",
            ToolUseID = "tool_use_id",
            Type = BetaManagedAgentsUserToolResultEventType.UserToolResult,
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",

            // Null should be interpreted as omitted for these properties
            Content = null,
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsUserToolResultEvent
        {
            ID = "id",
            ToolUseID = "tool_use_id",
            Type = BetaManagedAgentsUserToolResultEventType.UserToolResult,
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",

            // Null should be interpreted as omitted for these properties
            Content = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsUserToolResultEvent
        {
            ID = "id",
            ToolUseID = "tool_use_id",
            Type = BetaManagedAgentsUserToolResultEventType.UserToolResult,
            Content =
            [
                new Events::BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = Events::BetaManagedAgentsTextBlockType.Text,
                },
            ],
        };

        Assert.Null(model.IsError);
        Assert.False(model.RawData.ContainsKey("is_error"));
        Assert.Null(model.ProcessedAt);
        Assert.False(model.RawData.ContainsKey("processed_at"));
        Assert.Null(model.SessionThreadID);
        Assert.False(model.RawData.ContainsKey("session_thread_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsUserToolResultEvent
        {
            ID = "id",
            ToolUseID = "tool_use_id",
            Type = BetaManagedAgentsUserToolResultEventType.UserToolResult,
            Content =
            [
                new Events::BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = Events::BetaManagedAgentsTextBlockType.Text,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsUserToolResultEvent
        {
            ID = "id",
            ToolUseID = "tool_use_id",
            Type = BetaManagedAgentsUserToolResultEventType.UserToolResult,
            Content =
            [
                new Events::BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = Events::BetaManagedAgentsTextBlockType.Text,
                },
            ],

            IsError = null,
            ProcessedAt = null,
            SessionThreadID = null,
        };

        Assert.Null(model.IsError);
        Assert.True(model.RawData.ContainsKey("is_error"));
        Assert.Null(model.ProcessedAt);
        Assert.True(model.RawData.ContainsKey("processed_at"));
        Assert.Null(model.SessionThreadID);
        Assert.True(model.RawData.ContainsKey("session_thread_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsUserToolResultEvent
        {
            ID = "id",
            ToolUseID = "tool_use_id",
            Type = BetaManagedAgentsUserToolResultEventType.UserToolResult,
            Content =
            [
                new Events::BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = Events::BetaManagedAgentsTextBlockType.Text,
                },
            ],

            IsError = null,
            ProcessedAt = null,
            SessionThreadID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsUserToolResultEvent
        {
            ID = "id",
            ToolUseID = "tool_use_id",
            Type = BetaManagedAgentsUserToolResultEventType.UserToolResult,
            Content =
            [
                new Events::BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = Events::BetaManagedAgentsTextBlockType.Text,
                },
            ],
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };

        BetaManagedAgentsUserToolResultEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsUserToolResultEventTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsUserToolResultEventType.UserToolResult)]
    public void Validation_Works(BetaManagedAgentsUserToolResultEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUserToolResultEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserToolResultEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsUserToolResultEventType.UserToolResult)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsUserToolResultEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUserToolResultEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserToolResultEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserToolResultEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserToolResultEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ContentTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsTextBlockValidationWorks()
    {
        Content value = new Events::BetaManagedAgentsTextBlock()
        {
            Text = "Where is my order #1234?",
            Type = Events::BetaManagedAgentsTextBlockType.Text,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsImageBlockValidationWorks()
    {
        Content value = new Events::BetaManagedAgentsImageBlock()
        {
            Source = new Events::BetaManagedAgentsBase64ImageSource()
            {
                Data = "x",
                MediaType = "x",
                Type = Events::BetaManagedAgentsBase64ImageSourceType.Base64,
            },
            Type = Events::BetaManagedAgentsImageBlockType.Image,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsDocumentBlockValidationWorks()
    {
        Content value = new Events::BetaManagedAgentsDocumentBlock()
        {
            Source = new Events::BetaManagedAgentsBase64DocumentSource()
            {
                Data = "x",
                MediaType = "x",
                Type = Events::BetaManagedAgentsBase64DocumentSourceType.Base64,
            },
            Type = Events::BetaManagedAgentsDocumentBlockType.Document,
            Context = "context",
            Title = "title",
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSearchResultBlockValidationWorks()
    {
        Content value = new Events::BetaManagedAgentsSearchResultBlock()
        {
            Citations = new(true),
            Content =
            [
                new() { Text = "x", Type = Events::BetaManagedAgentsSearchResultContentType.Text },
            ],
            Source = "x",
            Title = "x",
            Type = Events::BetaManagedAgentsSearchResultBlockType.SearchResult,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsTextBlockSerializationRoundtripWorks()
    {
        Content value = new Events::BetaManagedAgentsTextBlock()
        {
            Text = "Where is my order #1234?",
            Type = Events::BetaManagedAgentsTextBlockType.Text,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsImageBlockSerializationRoundtripWorks()
    {
        Content value = new Events::BetaManagedAgentsImageBlock()
        {
            Source = new Events::BetaManagedAgentsBase64ImageSource()
            {
                Data = "x",
                MediaType = "x",
                Type = Events::BetaManagedAgentsBase64ImageSourceType.Base64,
            },
            Type = Events::BetaManagedAgentsImageBlockType.Image,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsDocumentBlockSerializationRoundtripWorks()
    {
        Content value = new Events::BetaManagedAgentsDocumentBlock()
        {
            Source = new Events::BetaManagedAgentsBase64DocumentSource()
            {
                Data = "x",
                MediaType = "x",
                Type = Events::BetaManagedAgentsBase64DocumentSourceType.Base64,
            },
            Type = Events::BetaManagedAgentsDocumentBlockType.Document,
            Context = "context",
            Title = "title",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsSearchResultBlockSerializationRoundtripWorks()
    {
        Content value = new Events::BetaManagedAgentsSearchResultBlock()
        {
            Citations = new(true),
            Content =
            [
                new() { Text = "x", Type = Events::BetaManagedAgentsSearchResultContentType.Text },
            ],
            Source = "x",
            Title = "x",
            Type = Events::BetaManagedAgentsSearchResultBlockType.SearchResult,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
