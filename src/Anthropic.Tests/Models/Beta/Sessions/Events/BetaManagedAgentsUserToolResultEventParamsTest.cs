using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsUserToolResultEventParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsUserToolResultEventParams
        {
            ToolUseID = "x",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
        };

        string expectedToolUseID = "x";
        JsonElement expectedType = JsonSerializer.SerializeToElement("user.tool_result");
        List<BetaManagedAgentsUserToolResultEventParamsContent> expectedContent =
        [
            new BetaManagedAgentsTextBlock("Where is my order #1234?"),
        ];
        bool expectedIsError = true;

        Assert.Equal(expectedToolUseID, model.ToolUseID);
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
        var model = new BetaManagedAgentsUserToolResultEventParams
        {
            ToolUseID = "x",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsUserToolResultEventParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsUserToolResultEventParams
        {
            ToolUseID = "x",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsUserToolResultEventParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedToolUseID = "x";
        JsonElement expectedType = JsonSerializer.SerializeToElement("user.tool_result");
        List<BetaManagedAgentsUserToolResultEventParamsContent> expectedContent =
        [
            new BetaManagedAgentsTextBlock("Where is my order #1234?"),
        ];
        bool expectedIsError = true;

        Assert.Equal(expectedToolUseID, deserialized.ToolUseID);
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
        var model = new BetaManagedAgentsUserToolResultEventParams
        {
            ToolUseID = "x",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsUserToolResultEventParams
        {
            ToolUseID = "x",
            IsError = true,
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsUserToolResultEventParams
        {
            ToolUseID = "x",
            IsError = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsUserToolResultEventParams
        {
            ToolUseID = "x",
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
        var model = new BetaManagedAgentsUserToolResultEventParams
        {
            ToolUseID = "x",
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
        var model = new BetaManagedAgentsUserToolResultEventParams
        {
            ToolUseID = "x",
            IsError = true,

            // Null should be interpreted as omitted for these properties
            Content = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsUserToolResultEventParams
        {
            ToolUseID = "x",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
        };

        Assert.Null(model.IsError);
        Assert.False(model.RawData.ContainsKey("is_error"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsUserToolResultEventParams
        {
            ToolUseID = "x",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsUserToolResultEventParams
        {
            ToolUseID = "x",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],

            IsError = null,
        };

        Assert.Null(model.IsError);
        Assert.True(model.RawData.ContainsKey("is_error"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsUserToolResultEventParams
        {
            ToolUseID = "x",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],

            IsError = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsUserToolResultEventParams
        {
            ToolUseID = "x",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
        };

        BetaManagedAgentsUserToolResultEventParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsUserToolResultEventParamsContentTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsTextBlockValidationWorks()
    {
        BetaManagedAgentsUserToolResultEventParamsContent value = new BetaManagedAgentsTextBlock(
            "Where is my order #1234?"
        );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsImageBlockValidationWorks()
    {
        BetaManagedAgentsUserToolResultEventParamsContent value = new BetaManagedAgentsImageBlock(
            new BetaManagedAgentsBase64ImageSource() { Data = "x", MediaType = "x" }
        );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsDocumentBlockValidationWorks()
    {
        BetaManagedAgentsUserToolResultEventParamsContent value =
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
        BetaManagedAgentsUserToolResultEventParamsContent value =
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
        BetaManagedAgentsUserToolResultEventParamsContent value = new BetaManagedAgentsTextBlock(
            "Where is my order #1234?"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsUserToolResultEventParamsContent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsImageBlockSerializationRoundtripWorks()
    {
        BetaManagedAgentsUserToolResultEventParamsContent value = new BetaManagedAgentsImageBlock(
            new BetaManagedAgentsBase64ImageSource() { Data = "x", MediaType = "x" }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsUserToolResultEventParamsContent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsDocumentBlockSerializationRoundtripWorks()
    {
        BetaManagedAgentsUserToolResultEventParamsContent value =
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
            JsonSerializer.Deserialize<BetaManagedAgentsUserToolResultEventParamsContent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsSearchResultBlockSerializationRoundtripWorks()
    {
        BetaManagedAgentsUserToolResultEventParamsContent value =
            new BetaManagedAgentsSearchResultBlock()
            {
                Citations = new(true),
                Content = [new("x")],
                Source = "x",
                Title = "x",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsUserToolResultEventParamsContent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsTextBlockTypeWorks()
    {
        BetaManagedAgentsUserToolResultEventParamsContent value = new BetaManagedAgentsTextBlock(
            "Where is my order #1234?"
        );
        Assert.Equal(
            BetaManagedAgentsUserToolResultEventParamsContentType.Text,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsImageBlockTypeWorks()
    {
        BetaManagedAgentsUserToolResultEventParamsContent value = new BetaManagedAgentsImageBlock(
            new BetaManagedAgentsBase64ImageSource() { Data = "x", MediaType = "x" }
        );
        Assert.Equal(
            BetaManagedAgentsUserToolResultEventParamsContentType.Image,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsDocumentBlockTypeWorks()
    {
        BetaManagedAgentsUserToolResultEventParamsContent value =
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
            BetaManagedAgentsUserToolResultEventParamsContentType.Document,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsSearchResultBlockTypeWorks()
    {
        BetaManagedAgentsUserToolResultEventParamsContent value =
            new BetaManagedAgentsSearchResultBlock()
            {
                Citations = new(true),
                Content = [new("x")],
                Source = "x",
                Title = "x",
            };
        Assert.Equal(
            BetaManagedAgentsUserToolResultEventParamsContentType.SearchResult,
            value.Type.Value()
        );
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsUserToolResultEventParamsContent value = new(
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

        ApiEnum<string, BetaManagedAgentsUserToolResultEventParamsContentType> expectedType =
            BetaManagedAgentsUserToolResultEventParamsContentType.Text;
        string expectedTitle = "title";

        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedTitle, value.Title);

        BetaManagedAgentsUserToolResultEventParamsContent emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.Title);

        BetaManagedAgentsUserToolResultEventParamsContent mismatchedValue = new(
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

public class BetaManagedAgentsUserToolResultEventParamsContentTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsUserToolResultEventParamsContentType.Text)]
    [InlineData(BetaManagedAgentsUserToolResultEventParamsContentType.Image)]
    [InlineData(BetaManagedAgentsUserToolResultEventParamsContentType.Document)]
    [InlineData(BetaManagedAgentsUserToolResultEventParamsContentType.SearchResult)]
    public void Validation_Works(BetaManagedAgentsUserToolResultEventParamsContentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUserToolResultEventParamsContentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserToolResultEventParamsContentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsUserToolResultEventParamsContentType.Text)]
    [InlineData(BetaManagedAgentsUserToolResultEventParamsContentType.Image)]
    [InlineData(BetaManagedAgentsUserToolResultEventParamsContentType.Document)]
    [InlineData(BetaManagedAgentsUserToolResultEventParamsContentType.SearchResult)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsUserToolResultEventParamsContentType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUserToolResultEventParamsContentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserToolResultEventParamsContentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserToolResultEventParamsContentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserToolResultEventParamsContentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
