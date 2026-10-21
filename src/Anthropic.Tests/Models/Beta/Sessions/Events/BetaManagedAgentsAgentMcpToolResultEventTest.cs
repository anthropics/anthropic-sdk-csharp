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
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
        };

        string expectedID = "id";
        string expectedMcpToolUseID = "mcp_tool_use_id";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        JsonElement expectedType = JsonSerializer.SerializeToElement("agent.mcp_tool_result");
        List<Content> expectedContent =
        [
            new BetaManagedAgentsTextBlock("Where is my order #1234?"),
        ];
        bool expectedIsError = true;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedMcpToolUseID, model.McpToolUseID);
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
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
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
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
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
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
        JsonElement expectedType = JsonSerializer.SerializeToElement("agent.mcp_tool_result");
        List<Content> expectedContent =
        [
            new BetaManagedAgentsTextBlock("Where is my order #1234?"),
        ];
        bool expectedIsError = true;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedMcpToolUseID, deserialized.McpToolUseID);
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
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
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
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
            IsError = true,

            // Null should be interpreted as omitted for these properties
            Content = null,
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullInWithAreUnset_Works()
    {
        var model = new BetaManagedAgentsAgentMcpToolResultEvent
        {
            ID = "id",
            McpToolUseID = "mcp_tool_use_id",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
        } with
        {
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
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
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
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
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
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],

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
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],

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
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
        };

        BetaManagedAgentsAgentMcpToolResultEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContentTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsTextBlockValidationWorks()
    {
        Content value = new BetaManagedAgentsTextBlock("Where is my order #1234?");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsImageBlockValidationWorks()
    {
        Content value = new BetaManagedAgentsImageBlock(
            new BetaManagedAgentsBase64ImageSource() { Data = "x", MediaType = "x" }
        );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsDocumentBlockValidationWorks()
    {
        Content value = new BetaManagedAgentsDocumentBlock()
        {
            Source = new BetaManagedAgentsBase64DocumentSource() { Data = "x", MediaType = "x" },
            Context = "context",
            Title = "title",
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsSearchResultBlockValidationWorks()
    {
        Content value = new BetaManagedAgentsSearchResultBlock()
        {
            Citations = new(true),
            Content = [new("x")],
            Source = "x",
            Title = "x",
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsTextBlockSerializationRoundtripWorks()
    {
        Content value = new BetaManagedAgentsTextBlock("Where is my order #1234?");
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
        Content value = new BetaManagedAgentsImageBlock(
            new BetaManagedAgentsBase64ImageSource() { Data = "x", MediaType = "x" }
        );
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
            Source = new BetaManagedAgentsBase64DocumentSource() { Data = "x", MediaType = "x" },
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
        Content value = new BetaManagedAgentsSearchResultBlock()
        {
            Citations = new(true),
            Content = [new("x")],
            Source = "x",
            Title = "x",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsTextBlockTypeWorks()
    {
        Content value = new BetaManagedAgentsTextBlock("Where is my order #1234?");
        Assert.Equal(ContentType.Text, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsImageBlockTypeWorks()
    {
        Content value = new BetaManagedAgentsImageBlock(
            new BetaManagedAgentsBase64ImageSource() { Data = "x", MediaType = "x" }
        );
        Assert.Equal(ContentType.Image, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsDocumentBlockTypeWorks()
    {
        Content value = new BetaManagedAgentsDocumentBlock()
        {
            Source = new BetaManagedAgentsBase64DocumentSource() { Data = "x", MediaType = "x" },
            Context = "context",
            Title = "title",
        };
        Assert.Equal(ContentType.Document, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsSearchResultBlockTypeWorks()
    {
        Content value = new BetaManagedAgentsSearchResultBlock()
        {
            Citations = new(true),
            Content = [new("x")],
            Source = "x",
            Title = "x",
        };
        Assert.Equal(ContentType.SearchResult, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Content value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "text",
                  "title": "title"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, ContentType> expectedType = ContentType.Text;
        string expectedTitle = "title";

        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedTitle, value.Title);

        Content emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.Title);

        Content mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "title": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.Title);
    }
}

public class ContentTypeTest : TestBase
{
    [Theory]
    [InlineData(ContentType.Text)]
    [InlineData(ContentType.Image)]
    [InlineData(ContentType.Document)]
    [InlineData(ContentType.SearchResult)]
    public void Validation_Works(ContentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ContentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ContentType.Text)]
    [InlineData(ContentType.Image)]
    [InlineData(ContentType.Document)]
    [InlineData(ContentType.SearchResult)]
    public void SerializationRoundtrip_Works(ContentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ContentType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ContentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ContentType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
