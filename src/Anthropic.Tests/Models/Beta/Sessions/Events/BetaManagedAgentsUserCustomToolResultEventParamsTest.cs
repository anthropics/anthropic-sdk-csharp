using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsUserCustomToolResultEventParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsUserCustomToolResultEventParams
        {
            CustomToolUseID = "x",
            Type = BetaManagedAgentsUserCustomToolResultEventParamsType.UserCustomToolResult,
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

        string expectedCustomToolUseID = "x";
        ApiEnum<string, BetaManagedAgentsUserCustomToolResultEventParamsType> expectedType =
            BetaManagedAgentsUserCustomToolResultEventParamsType.UserCustomToolResult;
        List<BetaManagedAgentsUserCustomToolResultEventParamsContent> expectedContent =
        [
            new BetaManagedAgentsTextBlock()
            {
                Text = "Where is my order #1234?",
                Type = BetaManagedAgentsTextBlockType.Text,
            },
        ];
        bool expectedIsError = true;

        Assert.Equal(expectedCustomToolUseID, model.CustomToolUseID);
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
        var model = new BetaManagedAgentsUserCustomToolResultEventParams
        {
            CustomToolUseID = "x",
            Type = BetaManagedAgentsUserCustomToolResultEventParamsType.UserCustomToolResult,
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
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsUserCustomToolResultEventParams>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsUserCustomToolResultEventParams
        {
            CustomToolUseID = "x",
            Type = BetaManagedAgentsUserCustomToolResultEventParamsType.UserCustomToolResult,
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
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsUserCustomToolResultEventParams>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCustomToolUseID = "x";
        ApiEnum<string, BetaManagedAgentsUserCustomToolResultEventParamsType> expectedType =
            BetaManagedAgentsUserCustomToolResultEventParamsType.UserCustomToolResult;
        List<BetaManagedAgentsUserCustomToolResultEventParamsContent> expectedContent =
        [
            new BetaManagedAgentsTextBlock()
            {
                Text = "Where is my order #1234?",
                Type = BetaManagedAgentsTextBlockType.Text,
            },
        ];
        bool expectedIsError = true;

        Assert.Equal(expectedCustomToolUseID, deserialized.CustomToolUseID);
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
        var model = new BetaManagedAgentsUserCustomToolResultEventParams
        {
            CustomToolUseID = "x",
            Type = BetaManagedAgentsUserCustomToolResultEventParamsType.UserCustomToolResult,
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
        var model = new BetaManagedAgentsUserCustomToolResultEventParams
        {
            CustomToolUseID = "x",
            Type = BetaManagedAgentsUserCustomToolResultEventParamsType.UserCustomToolResult,
            IsError = true,
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsUserCustomToolResultEventParams
        {
            CustomToolUseID = "x",
            Type = BetaManagedAgentsUserCustomToolResultEventParamsType.UserCustomToolResult,
            IsError = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsUserCustomToolResultEventParams
        {
            CustomToolUseID = "x",
            Type = BetaManagedAgentsUserCustomToolResultEventParamsType.UserCustomToolResult,
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
        var model = new BetaManagedAgentsUserCustomToolResultEventParams
        {
            CustomToolUseID = "x",
            Type = BetaManagedAgentsUserCustomToolResultEventParamsType.UserCustomToolResult,
            IsError = true,

            // Null should be interpreted as omitted for these properties
            Content = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsUserCustomToolResultEventParams
        {
            CustomToolUseID = "x",
            Type = BetaManagedAgentsUserCustomToolResultEventParamsType.UserCustomToolResult,
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
        var model = new BetaManagedAgentsUserCustomToolResultEventParams
        {
            CustomToolUseID = "x",
            Type = BetaManagedAgentsUserCustomToolResultEventParamsType.UserCustomToolResult,
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
        var model = new BetaManagedAgentsUserCustomToolResultEventParams
        {
            CustomToolUseID = "x",
            Type = BetaManagedAgentsUserCustomToolResultEventParamsType.UserCustomToolResult,
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
        var model = new BetaManagedAgentsUserCustomToolResultEventParams
        {
            CustomToolUseID = "x",
            Type = BetaManagedAgentsUserCustomToolResultEventParamsType.UserCustomToolResult,
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
        var model = new BetaManagedAgentsUserCustomToolResultEventParams
        {
            CustomToolUseID = "x",
            Type = BetaManagedAgentsUserCustomToolResultEventParamsType.UserCustomToolResult,
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

        BetaManagedAgentsUserCustomToolResultEventParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsUserCustomToolResultEventParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsUserCustomToolResultEventParamsType.UserCustomToolResult)]
    public void Validation_Works(BetaManagedAgentsUserCustomToolResultEventParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUserCustomToolResultEventParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserCustomToolResultEventParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsUserCustomToolResultEventParamsType.UserCustomToolResult)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsUserCustomToolResultEventParamsType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUserCustomToolResultEventParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserCustomToolResultEventParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserCustomToolResultEventParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserCustomToolResultEventParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class BetaManagedAgentsUserCustomToolResultEventParamsContentTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsTextBlockValidationWorks()
    {
        BetaManagedAgentsUserCustomToolResultEventParamsContent value =
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
        BetaManagedAgentsUserCustomToolResultEventParamsContent value =
            new BetaManagedAgentsImageBlock()
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
        BetaManagedAgentsUserCustomToolResultEventParamsContent value =
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
        BetaManagedAgentsUserCustomToolResultEventParamsContent value =
            new BetaManagedAgentsTextBlock()
            {
                Text = "Where is my order #1234?",
                Type = BetaManagedAgentsTextBlockType.Text,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsUserCustomToolResultEventParamsContent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsImageBlockSerializationRoundtripWorks()
    {
        BetaManagedAgentsUserCustomToolResultEventParamsContent value =
            new BetaManagedAgentsImageBlock()
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
            JsonSerializer.Deserialize<BetaManagedAgentsUserCustomToolResultEventParamsContent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsDocumentBlockSerializationRoundtripWorks()
    {
        BetaManagedAgentsUserCustomToolResultEventParamsContent value =
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
            JsonSerializer.Deserialize<BetaManagedAgentsUserCustomToolResultEventParamsContent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}
