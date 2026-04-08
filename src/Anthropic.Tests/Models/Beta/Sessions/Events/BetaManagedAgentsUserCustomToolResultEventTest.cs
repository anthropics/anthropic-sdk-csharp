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
            Type = BetaManagedAgentsUserCustomToolResultEventType.UserCustomToolResult,
            Content =
            [
                new BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        string expectedCustomToolUseID = "custom_tool_use_id";
        ApiEnum<string, BetaManagedAgentsUserCustomToolResultEventType> expectedType =
            BetaManagedAgentsUserCustomToolResultEventType.UserCustomToolResult;
        List<BetaManagedAgentsUserCustomToolResultEventContent> expectedContent =
        [
            new BetaManagedAgentsTextBlock()
            {
                Text = "Where is my order #1234?",
                Type = BetaManagedAgentsTextBlockType.Text,
            },
        ];
        bool expectedIsError = true;
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCustomToolUseID, model.CustomToolUseID);
        Assert.Equal(expectedType, model.Type);
        Assert.NotNull(model.Content);
        Assert.Equal(expectedContent.Count, model.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], model.Content[i]);
        }
        Assert.Equal(expectedIsError, model.IsError);
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsUserCustomToolResultEvent
        {
            ID = "id",
            CustomToolUseID = "custom_tool_use_id",
            Type = BetaManagedAgentsUserCustomToolResultEventType.UserCustomToolResult,
            Content =
            [
                new BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            Type = BetaManagedAgentsUserCustomToolResultEventType.UserCustomToolResult,
            Content =
            [
                new BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsUserCustomToolResultEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedCustomToolUseID = "custom_tool_use_id";
        ApiEnum<string, BetaManagedAgentsUserCustomToolResultEventType> expectedType =
            BetaManagedAgentsUserCustomToolResultEventType.UserCustomToolResult;
        List<BetaManagedAgentsUserCustomToolResultEventContent> expectedContent =
        [
            new BetaManagedAgentsTextBlock()
            {
                Text = "Where is my order #1234?",
                Type = BetaManagedAgentsTextBlockType.Text,
            },
        ];
        bool expectedIsError = true;
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCustomToolUseID, deserialized.CustomToolUseID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.NotNull(deserialized.Content);
        Assert.Equal(expectedContent.Count, deserialized.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], deserialized.Content[i]);
        }
        Assert.Equal(expectedIsError, deserialized.IsError);
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsUserCustomToolResultEvent
        {
            ID = "id",
            CustomToolUseID = "custom_tool_use_id",
            Type = BetaManagedAgentsUserCustomToolResultEventType.UserCustomToolResult,
            Content =
            [
                new BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            Type = BetaManagedAgentsUserCustomToolResultEventType.UserCustomToolResult,
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            Type = BetaManagedAgentsUserCustomToolResultEventType.UserCustomToolResult,
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            Type = BetaManagedAgentsUserCustomToolResultEventType.UserCustomToolResult,
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

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
            Type = BetaManagedAgentsUserCustomToolResultEventType.UserCustomToolResult,
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

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
            Type = BetaManagedAgentsUserCustomToolResultEventType.UserCustomToolResult,
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
        Assert.Null(model.ProcessedAt);
        Assert.False(model.RawData.ContainsKey("processed_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsUserCustomToolResultEvent
        {
            ID = "id",
            CustomToolUseID = "custom_tool_use_id",
            Type = BetaManagedAgentsUserCustomToolResultEventType.UserCustomToolResult,
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
        var model = new BetaManagedAgentsUserCustomToolResultEvent
        {
            ID = "id",
            CustomToolUseID = "custom_tool_use_id",
            Type = BetaManagedAgentsUserCustomToolResultEventType.UserCustomToolResult,
            Content =
            [
                new BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],

            IsError = null,
            ProcessedAt = null,
        };

        Assert.Null(model.IsError);
        Assert.True(model.RawData.ContainsKey("is_error"));
        Assert.Null(model.ProcessedAt);
        Assert.True(model.RawData.ContainsKey("processed_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsUserCustomToolResultEvent
        {
            ID = "id",
            CustomToolUseID = "custom_tool_use_id",
            Type = BetaManagedAgentsUserCustomToolResultEventType.UserCustomToolResult,
            Content =
            [
                new BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],

            IsError = null,
            ProcessedAt = null,
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
            Type = BetaManagedAgentsUserCustomToolResultEventType.UserCustomToolResult,
            Content =
            [
                new BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsTextBlockType.Text,
                },
            ],
            IsError = true,
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        BetaManagedAgentsUserCustomToolResultEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsUserCustomToolResultEventTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsUserCustomToolResultEventType.UserCustomToolResult)]
    public void Validation_Works(BetaManagedAgentsUserCustomToolResultEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUserCustomToolResultEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserCustomToolResultEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsUserCustomToolResultEventType.UserCustomToolResult)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsUserCustomToolResultEventType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUserCustomToolResultEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserCustomToolResultEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserCustomToolResultEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserCustomToolResultEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class BetaManagedAgentsUserCustomToolResultEventContentTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsTextBlockValidationWorks()
    {
        BetaManagedAgentsUserCustomToolResultEventContent value = new BetaManagedAgentsTextBlock()
        {
            Text = "Where is my order #1234?",
            Type = BetaManagedAgentsTextBlockType.Text,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsImageBlockValidationWorks()
    {
        BetaManagedAgentsUserCustomToolResultEventContent value = new BetaManagedAgentsImageBlock()
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
        BetaManagedAgentsUserCustomToolResultEventContent value =
            new BetaManagedAgentsDocumentBlock()
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
        BetaManagedAgentsUserCustomToolResultEventContent value = new BetaManagedAgentsTextBlock()
        {
            Text = "Where is my order #1234?",
            Type = BetaManagedAgentsTextBlockType.Text,
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
    public void BetaManagedAgentsImageBlockSerializationRoundtripWorks()
    {
        BetaManagedAgentsUserCustomToolResultEventContent value = new BetaManagedAgentsImageBlock()
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
                    Data = "data",
                    MediaType = "media_type",
                    Type = BetaManagedAgentsBase64DocumentSourceType.Base64,
                },
                Type = BetaManagedAgentsDocumentBlockType.Document,
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
}
