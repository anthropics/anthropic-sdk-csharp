using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsUserCustomToolResultEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsUserCustomToolResultEvent
        {
            ID = "id",
            CustomToolUseID = "custom_tool_use_id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };

        string expectedID = "id";
        string expectedCustomToolUseID = "custom_tool_use_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("user.custom_tool_result");
        List<BetaManagedAgentsUserCustomToolResultEventContent> expectedContent =
        [
            new BetaManagedAgentsTextBlock("Where is my order #1234?"),
        ];
        bool expectedIsError = true;
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedSessionThreadID = "session_thread_id";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCustomToolUseID, model.CustomToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
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
        var model = new BetaManagedAgentsUserCustomToolResultEvent
        {
            ID = "id",
            CustomToolUseID = "custom_tool_use_id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsUserCustomToolResultEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsUserCustomToolResultEvent
        {
            ID = "id",
            CustomToolUseID = "custom_tool_use_id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsUserCustomToolResultEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedCustomToolUseID = "custom_tool_use_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("user.custom_tool_result");
        List<BetaManagedAgentsUserCustomToolResultEventContent> expectedContent =
        [
            new BetaManagedAgentsTextBlock("Where is my order #1234?"),
        ];
        bool expectedIsError = true;
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedSessionThreadID = "session_thread_id";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCustomToolUseID, deserialized.CustomToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
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
        var model = new BetaManagedAgentsUserCustomToolResultEvent
        {
            ID = "id",
            CustomToolUseID = "custom_tool_use_id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsUserCustomToolResultEvent
        {
            ID = "id",
            CustomToolUseID = "custom_tool_use_id",
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
        var model = new BetaManagedAgentsUserCustomToolResultEvent
        {
            ID = "id",
            CustomToolUseID = "custom_tool_use_id",
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsUserCustomToolResultEvent
        {
            ID = "id",
            CustomToolUseID = "custom_tool_use_id",
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
    public void OptionalNonNullablePropertiesSetToNullInWithAreUnset_Works()
    {
        var model = new BetaManagedAgentsUserCustomToolResultEvent
        {
            ID = "id",
            CustomToolUseID = "custom_tool_use_id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
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
        var model = new BetaManagedAgentsUserCustomToolResultEvent
        {
            ID = "id",
            CustomToolUseID = "custom_tool_use_id",
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
        var model = new BetaManagedAgentsUserCustomToolResultEvent
        {
            ID = "id",
            CustomToolUseID = "custom_tool_use_id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
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
        var model = new BetaManagedAgentsUserCustomToolResultEvent
        {
            ID = "id",
            CustomToolUseID = "custom_tool_use_id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsUserCustomToolResultEvent
        {
            ID = "id",
            CustomToolUseID = "custom_tool_use_id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],

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
        var model = new BetaManagedAgentsUserCustomToolResultEvent
        {
            ID = "id",
            CustomToolUseID = "custom_tool_use_id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],

            IsError = null,
            ProcessedAt = null,
            SessionThreadID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsUserCustomToolResultEvent
        {
            ID = "id",
            CustomToolUseID = "custom_tool_use_id",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SessionThreadID = "session_thread_id",
        };

        BetaManagedAgentsUserCustomToolResultEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsUserCustomToolResultEventContentTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsTextBlockValidationWorks()
    {
        BetaManagedAgentsUserCustomToolResultEventContent value = new BetaManagedAgentsTextBlock(
            "Where is my order #1234?"
        );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsImageBlockValidationWorks()
    {
        BetaManagedAgentsUserCustomToolResultEventContent value = new BetaManagedAgentsImageBlock(
            new BetaManagedAgentsBase64ImageSource() { Data = "x", MediaType = "x" }
        );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsDocumentBlockValidationWorks()
    {
        BetaManagedAgentsUserCustomToolResultEventContent value =
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
    public void BetaManagedAgentsSearchResultBlockValidationWorks()
    {
        BetaManagedAgentsUserCustomToolResultEventContent value =
            new BetaManagedAgentsSearchResultBlock()
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
        BetaManagedAgentsUserCustomToolResultEventContent value = new BetaManagedAgentsTextBlock(
            "Where is my order #1234?"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsUserCustomToolResultEventContent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsImageBlockSerializationRoundtripWorks()
    {
        BetaManagedAgentsUserCustomToolResultEventContent value = new BetaManagedAgentsImageBlock(
            new BetaManagedAgentsBase64ImageSource() { Data = "x", MediaType = "x" }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsUserCustomToolResultEventContent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsDocumentBlockSerializationRoundtripWorks()
    {
        BetaManagedAgentsUserCustomToolResultEventContent value =
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
            JsonSerializer.Deserialize<BetaManagedAgentsUserCustomToolResultEventContent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsSearchResultBlockSerializationRoundtripWorks()
    {
        BetaManagedAgentsUserCustomToolResultEventContent value =
            new BetaManagedAgentsSearchResultBlock()
            {
                Citations = new(true),
                Content = [new("x")],
                Source = "x",
                Title = "x",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsUserCustomToolResultEventContent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsTextBlockTypeWorks()
    {
        BetaManagedAgentsUserCustomToolResultEventContent value = new BetaManagedAgentsTextBlock(
            "Where is my order #1234?"
        );
        Assert.Equal(
            BetaManagedAgentsUserCustomToolResultEventContentType.Text,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsImageBlockTypeWorks()
    {
        BetaManagedAgentsUserCustomToolResultEventContent value = new BetaManagedAgentsImageBlock(
            new BetaManagedAgentsBase64ImageSource() { Data = "x", MediaType = "x" }
        );
        Assert.Equal(
            BetaManagedAgentsUserCustomToolResultEventContentType.Image,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsDocumentBlockTypeWorks()
    {
        BetaManagedAgentsUserCustomToolResultEventContent value =
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
            BetaManagedAgentsUserCustomToolResultEventContentType.Document,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsSearchResultBlockTypeWorks()
    {
        BetaManagedAgentsUserCustomToolResultEventContent value =
            new BetaManagedAgentsSearchResultBlock()
            {
                Citations = new(true),
                Content = [new("x")],
                Source = "x",
                Title = "x",
            };
        Assert.Equal(
            BetaManagedAgentsUserCustomToolResultEventContentType.SearchResult,
            value.Type.Value()
        );
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsUserCustomToolResultEventContent value = new(
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

        ApiEnum<string, BetaManagedAgentsUserCustomToolResultEventContentType> expectedType =
            BetaManagedAgentsUserCustomToolResultEventContentType.Text;
        string expectedTitle = "title";

        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedTitle, value.Title);

        BetaManagedAgentsUserCustomToolResultEventContent emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.Title);

        BetaManagedAgentsUserCustomToolResultEventContent mismatchedValue = new(
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

public class BetaManagedAgentsUserCustomToolResultEventContentTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsUserCustomToolResultEventContentType.Text)]
    [InlineData(BetaManagedAgentsUserCustomToolResultEventContentType.Image)]
    [InlineData(BetaManagedAgentsUserCustomToolResultEventContentType.Document)]
    [InlineData(BetaManagedAgentsUserCustomToolResultEventContentType.SearchResult)]
    public void Validation_Works(BetaManagedAgentsUserCustomToolResultEventContentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUserCustomToolResultEventContentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserCustomToolResultEventContentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsUserCustomToolResultEventContentType.Text)]
    [InlineData(BetaManagedAgentsUserCustomToolResultEventContentType.Image)]
    [InlineData(BetaManagedAgentsUserCustomToolResultEventContentType.Document)]
    [InlineData(BetaManagedAgentsUserCustomToolResultEventContentType.SearchResult)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsUserCustomToolResultEventContentType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUserCustomToolResultEventContentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserCustomToolResultEventContentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserCustomToolResultEventContentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserCustomToolResultEventContentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
