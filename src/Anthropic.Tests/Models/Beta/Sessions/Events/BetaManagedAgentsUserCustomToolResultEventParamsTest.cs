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
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
        };

        string expectedCustomToolUseID = "x";
        JsonElement expectedType = JsonSerializer.SerializeToElement("user.custom_tool_result");
        List<BetaManagedAgentsUserCustomToolResultEventParamsContent> expectedContent =
        [
            new BetaManagedAgentsTextBlock("Where is my order #1234?"),
        ];
        bool expectedIsError = true;

        Assert.Equal(expectedCustomToolUseID, model.CustomToolUseID);
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
        var model = new BetaManagedAgentsUserCustomToolResultEventParams
        {
            CustomToolUseID = "x",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
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
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
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
        JsonElement expectedType = JsonSerializer.SerializeToElement("user.custom_tool_result");
        List<BetaManagedAgentsUserCustomToolResultEventParamsContent> expectedContent =
        [
            new BetaManagedAgentsTextBlock("Where is my order #1234?"),
        ];
        bool expectedIsError = true;

        Assert.Equal(expectedCustomToolUseID, deserialized.CustomToolUseID);
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
        var model = new BetaManagedAgentsUserCustomToolResultEventParams
        {
            CustomToolUseID = "x",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
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
        var model = new BetaManagedAgentsUserCustomToolResultEventParams
        {
            CustomToolUseID = "x",
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
        var model = new BetaManagedAgentsUserCustomToolResultEventParams
        {
            CustomToolUseID = "x",
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
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
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
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsUserCustomToolResultEventParams
        {
            CustomToolUseID = "x",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],

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
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],

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
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            IsError = true,
        };

        BetaManagedAgentsUserCustomToolResultEventParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsUserCustomToolResultEventParamsContentTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsTextBlockValidationWorks()
    {
        BetaManagedAgentsUserCustomToolResultEventParamsContent value =
            new BetaManagedAgentsTextBlock("Where is my order #1234?");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsImageBlockValidationWorks()
    {
        BetaManagedAgentsUserCustomToolResultEventParamsContent value =
            new BetaManagedAgentsImageBlock(
                new BetaManagedAgentsBase64ImageSource() { Data = "x", MediaType = "x" }
            );
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
        BetaManagedAgentsUserCustomToolResultEventParamsContent value =
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
        BetaManagedAgentsUserCustomToolResultEventParamsContent value =
            new BetaManagedAgentsTextBlock("Where is my order #1234?");
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
            new BetaManagedAgentsImageBlock(
                new BetaManagedAgentsBase64ImageSource() { Data = "x", MediaType = "x" }
            );
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
                    Data = "x",
                    MediaType = "x",
                },
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

    [Fact]
    public void BetaManagedAgentsSearchResultBlockSerializationRoundtripWorks()
    {
        BetaManagedAgentsUserCustomToolResultEventParamsContent value =
            new BetaManagedAgentsSearchResultBlock()
            {
                Citations = new(true),
                Content = [new("x")],
                Source = "x",
                Title = "x",
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
    public void BetaManagedAgentsTextBlockTypeWorks()
    {
        BetaManagedAgentsUserCustomToolResultEventParamsContent value =
            new BetaManagedAgentsTextBlock("Where is my order #1234?");
        Assert.Equal(
            BetaManagedAgentsUserCustomToolResultEventParamsContentType.Text,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsImageBlockTypeWorks()
    {
        BetaManagedAgentsUserCustomToolResultEventParamsContent value =
            new BetaManagedAgentsImageBlock(
                new BetaManagedAgentsBase64ImageSource() { Data = "x", MediaType = "x" }
            );
        Assert.Equal(
            BetaManagedAgentsUserCustomToolResultEventParamsContentType.Image,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsDocumentBlockTypeWorks()
    {
        BetaManagedAgentsUserCustomToolResultEventParamsContent value =
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
            BetaManagedAgentsUserCustomToolResultEventParamsContentType.Document,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsSearchResultBlockTypeWorks()
    {
        BetaManagedAgentsUserCustomToolResultEventParamsContent value =
            new BetaManagedAgentsSearchResultBlock()
            {
                Citations = new(true),
                Content = [new("x")],
                Source = "x",
                Title = "x",
            };
        Assert.Equal(
            BetaManagedAgentsUserCustomToolResultEventParamsContentType.SearchResult,
            value.Type.Value()
        );
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsUserCustomToolResultEventParamsContent value = new(
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

        ApiEnum<string, BetaManagedAgentsUserCustomToolResultEventParamsContentType> expectedType =
            BetaManagedAgentsUserCustomToolResultEventParamsContentType.Text;
        string expectedTitle = "title";

        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedTitle, value.Title);

        BetaManagedAgentsUserCustomToolResultEventParamsContent emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.Title);

        BetaManagedAgentsUserCustomToolResultEventParamsContent mismatchedValue = new(
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

public class BetaManagedAgentsUserCustomToolResultEventParamsContentTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsUserCustomToolResultEventParamsContentType.Text)]
    [InlineData(BetaManagedAgentsUserCustomToolResultEventParamsContentType.Image)]
    [InlineData(BetaManagedAgentsUserCustomToolResultEventParamsContentType.Document)]
    [InlineData(BetaManagedAgentsUserCustomToolResultEventParamsContentType.SearchResult)]
    public void Validation_Works(
        BetaManagedAgentsUserCustomToolResultEventParamsContentType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUserCustomToolResultEventParamsContentType> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserCustomToolResultEventParamsContentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsUserCustomToolResultEventParamsContentType.Text)]
    [InlineData(BetaManagedAgentsUserCustomToolResultEventParamsContentType.Image)]
    [InlineData(BetaManagedAgentsUserCustomToolResultEventParamsContentType.Document)]
    [InlineData(BetaManagedAgentsUserCustomToolResultEventParamsContentType.SearchResult)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsUserCustomToolResultEventParamsContentType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUserCustomToolResultEventParamsContentType> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserCustomToolResultEventParamsContentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserCustomToolResultEventParamsContentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserCustomToolResultEventParamsContentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
