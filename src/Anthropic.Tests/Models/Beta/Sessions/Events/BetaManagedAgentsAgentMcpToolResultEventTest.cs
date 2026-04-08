using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsAgentMcpToolResultEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentMcpToolResultEvent
        {
            ID = "id",
            McpToolUseID = "mcp_tool_use_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsAgentMcpToolResultEventType.AgentMcpToolResult,
            Content =
            [
                new BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],
            IsError = true,
        };

        string expectedID = "id";
        string expectedMcpToolUseID = "mcp_tool_use_id";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, BetaManagedAgentsAgentMcpToolResultEventType> expectedType =
            BetaManagedAgentsAgentMcpToolResultEventType.AgentMcpToolResult;
        List<Content> expectedContent =
        [
            new BetaManagedAgentsTextBlock()
            {
                Text = "Where is my order #1234?",
                Type = BetaManagedAgentsTextBlockType.Text,
            },
        ];
        bool expectedIsError = true;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedMcpToolUseID, model.McpToolUseID);
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.Equal(expectedType, model.Type);
        Assert.NotNull(model.Content);
        Assert.Equal(expectedContent.Count, model.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], model.Content[i]);
        }
        Assert.Equal(expectedIsError, model.IsError);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentMcpToolResultEvent
        {
            ID = "id",
            McpToolUseID = "mcp_tool_use_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsAgentMcpToolResultEventType.AgentMcpToolResult,
            Content =
            [
                new BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],
            IsError = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentMcpToolResultEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsAgentMcpToolResultEvent
        {
            ID = "id",
            McpToolUseID = "mcp_tool_use_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsAgentMcpToolResultEventType.AgentMcpToolResult,
            Content =
            [
                new BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],
            IsError = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentMcpToolResultEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedMcpToolUseID = "mcp_tool_use_id";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, BetaManagedAgentsAgentMcpToolResultEventType> expectedType =
            BetaManagedAgentsAgentMcpToolResultEventType.AgentMcpToolResult;
        List<Content> expectedContent =
        [
            new BetaManagedAgentsTextBlock()
            {
                Text = "Where is my order #1234?",
                Type = BetaManagedAgentsTextBlockType.Text,
            },
        ];
        bool expectedIsError = true;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedMcpToolUseID, deserialized.McpToolUseID);
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.NotNull(deserialized.Content);
        Assert.Equal(expectedContent.Count, deserialized.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], deserialized.Content[i]);
        }
        Assert.Equal(expectedIsError, deserialized.IsError);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsAgentMcpToolResultEvent
        {
            ID = "id",
            McpToolUseID = "mcp_tool_use_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsAgentMcpToolResultEventType.AgentMcpToolResult,
            Content =
            [
                new BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],
            IsError = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsAgentMcpToolResultEvent
        {
            ID = "id",
            McpToolUseID = "mcp_tool_use_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsAgentMcpToolResultEventType.AgentMcpToolResult,
            IsError = true,
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsAgentMcpToolResultEvent
        {
            ID = "id",
            McpToolUseID = "mcp_tool_use_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsAgentMcpToolResultEventType.AgentMcpToolResult,
            IsError = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsAgentMcpToolResultEvent
        {
            ID = "id",
            McpToolUseID = "mcp_tool_use_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsAgentMcpToolResultEventType.AgentMcpToolResult,
            IsError = true,

            // Null should be interpreted as omitted for these properties
            Content = null,
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsAgentMcpToolResultEvent
        {
            ID = "id",
            McpToolUseID = "mcp_tool_use_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsAgentMcpToolResultEventType.AgentMcpToolResult,
            IsError = true,

            // Null should be interpreted as omitted for these properties
            Content = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsAgentMcpToolResultEvent
        {
            ID = "id",
            McpToolUseID = "mcp_tool_use_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsAgentMcpToolResultEventType.AgentMcpToolResult,
            Content =
            [
                new BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],
        };

        Assert.Null(model.IsError);
        Assert.False(model.RawData.ContainsKey("is_error"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsAgentMcpToolResultEvent
        {
            ID = "id",
            McpToolUseID = "mcp_tool_use_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsAgentMcpToolResultEventType.AgentMcpToolResult,
            Content =
            [
                new BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsAgentMcpToolResultEvent
        {
            ID = "id",
            McpToolUseID = "mcp_tool_use_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsAgentMcpToolResultEventType.AgentMcpToolResult,
            Content =
            [
                new BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],

            IsError = null,
        };

        Assert.Null(model.IsError);
        Assert.True(model.RawData.ContainsKey("is_error"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsAgentMcpToolResultEvent
        {
            ID = "id",
            McpToolUseID = "mcp_tool_use_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsAgentMcpToolResultEventType.AgentMcpToolResult,
            Content =
            [
                new BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],

            IsError = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsAgentMcpToolResultEvent
        {
            ID = "id",
            McpToolUseID = "mcp_tool_use_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsAgentMcpToolResultEventType.AgentMcpToolResult,
            Content =
            [
                new BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],
            IsError = true,
        };

        BetaManagedAgentsAgentMcpToolResultEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsAgentMcpToolResultEventTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsAgentMcpToolResultEventType.AgentMcpToolResult)]
    public void Validation_Works(BetaManagedAgentsAgentMcpToolResultEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentMcpToolResultEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentMcpToolResultEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsAgentMcpToolResultEventType.AgentMcpToolResult)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsAgentMcpToolResultEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentMcpToolResultEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentMcpToolResultEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentMcpToolResultEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentMcpToolResultEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ContentTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsTextBlockValidationWorks()
    {
        Content value = new BetaManagedAgentsTextBlock()
        {
            Text = "Where is my order #1234?",
            Type = BetaManagedAgentsTextBlockType.Text,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsImageBlockValidationWorks()
    {
        Content value = new BetaManagedAgentsImageBlock()
        {
            Source = new BetaManagedAgentsBase64ImageSource()
            {
                Data = "data",
                MediaType = "media_type",
                Type = BetaManagedAgentsBase64ImageSourceType.Base64,
            },
            Type = BetaManagedAgentsImageBlockType.Image,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsDocumentBlockValidationWorks()
    {
        Content value = new BetaManagedAgentsDocumentBlock()
        {
            Source = new BetaManagedAgentsBase64DocumentSource()
            {
                Data = "data",
                MediaType = "media_type",
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
        Content value = new BetaManagedAgentsTextBlock()
        {
            Text = "Where is my order #1234?",
            Type = BetaManagedAgentsTextBlockType.Text,
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
        Content value = new BetaManagedAgentsImageBlock()
        {
            Source = new BetaManagedAgentsBase64ImageSource()
            {
                Data = "data",
                MediaType = "media_type",
                Type = BetaManagedAgentsBase64ImageSourceType.Base64,
            },
            Type = BetaManagedAgentsImageBlockType.Image,
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
        Content value = new BetaManagedAgentsDocumentBlock()
        {
            Source = new BetaManagedAgentsBase64DocumentSource()
            {
                Data = "data",
                MediaType = "media_type",
                Type = BetaManagedAgentsBase64DocumentSourceType.Base64,
            },
            Type = BetaManagedAgentsDocumentBlockType.Document,
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
}
