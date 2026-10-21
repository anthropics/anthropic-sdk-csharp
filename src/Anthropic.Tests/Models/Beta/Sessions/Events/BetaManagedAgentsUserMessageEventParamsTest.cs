using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsUserMessageEventParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsUserMessageEventParams
        {
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
        };

        List<BetaManagedAgentsUserMessageEventParamsContent> expectedContent =
        [
            new BetaManagedAgentsTextBlock("Where is my order #1234?"),
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("user.message");

        Assert.Equal(expectedContent.Count, model.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], model.Content[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsUserMessageEventParams
        {
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsUserMessageEventParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsUserMessageEventParams
        {
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsUserMessageEventParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaManagedAgentsUserMessageEventParamsContent> expectedContent =
        [
            new BetaManagedAgentsTextBlock("Where is my order #1234?"),
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("user.message");

        Assert.Equal(expectedContent.Count, deserialized.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], deserialized.Content[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsUserMessageEventParams
        {
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsUserMessageEventParams
        {
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
        };

        BetaManagedAgentsUserMessageEventParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsUserMessageEventParamsContentTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsTextBlockValidationWorks()
    {
        BetaManagedAgentsUserMessageEventParamsContent value = new BetaManagedAgentsTextBlock(
            "Where is my order #1234?"
        );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsImageBlockValidationWorks()
    {
        BetaManagedAgentsUserMessageEventParamsContent value = new BetaManagedAgentsImageBlock(
            new BetaManagedAgentsBase64ImageSource() { Data = "x", MediaType = "x" }
        );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsDocumentBlockValidationWorks()
    {
        BetaManagedAgentsUserMessageEventParamsContent value = new BetaManagedAgentsDocumentBlock()
        {
            Source = new BetaManagedAgentsBase64DocumentSource() { Data = "x", MediaType = "x" },
            Context = "context",
            Title = "title",
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRedactedBlockValidationWorks()
    {
        BetaManagedAgentsUserMessageEventParamsContent value = new BetaManagedAgentsRedactedBlock();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsTextBlockSerializationRoundtripWorks()
    {
        BetaManagedAgentsUserMessageEventParamsContent value = new BetaManagedAgentsTextBlock(
            "Where is my order #1234?"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsUserMessageEventParamsContent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsImageBlockSerializationRoundtripWorks()
    {
        BetaManagedAgentsUserMessageEventParamsContent value = new BetaManagedAgentsImageBlock(
            new BetaManagedAgentsBase64ImageSource() { Data = "x", MediaType = "x" }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsUserMessageEventParamsContent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsDocumentBlockSerializationRoundtripWorks()
    {
        BetaManagedAgentsUserMessageEventParamsContent value = new BetaManagedAgentsDocumentBlock()
        {
            Source = new BetaManagedAgentsBase64DocumentSource() { Data = "x", MediaType = "x" },
            Context = "context",
            Title = "title",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsUserMessageEventParamsContent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsRedactedBlockSerializationRoundtripWorks()
    {
        BetaManagedAgentsUserMessageEventParamsContent value = new BetaManagedAgentsRedactedBlock();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsUserMessageEventParamsContent>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsTextBlockTypeWorks()
    {
        BetaManagedAgentsUserMessageEventParamsContent value = new BetaManagedAgentsTextBlock(
            "Where is my order #1234?"
        );
        Assert.Equal(BetaManagedAgentsUserMessageEventParamsContentType.Text, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsImageBlockTypeWorks()
    {
        BetaManagedAgentsUserMessageEventParamsContent value = new BetaManagedAgentsImageBlock(
            new BetaManagedAgentsBase64ImageSource() { Data = "x", MediaType = "x" }
        );
        Assert.Equal(BetaManagedAgentsUserMessageEventParamsContentType.Image, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsDocumentBlockTypeWorks()
    {
        BetaManagedAgentsUserMessageEventParamsContent value = new BetaManagedAgentsDocumentBlock()
        {
            Source = new BetaManagedAgentsBase64DocumentSource() { Data = "x", MediaType = "x" },
            Context = "context",
            Title = "title",
        };
        Assert.Equal(
            BetaManagedAgentsUserMessageEventParamsContentType.Document,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsRedactedBlockTypeWorks()
    {
        BetaManagedAgentsUserMessageEventParamsContent value = new BetaManagedAgentsRedactedBlock();
        Assert.Equal(
            BetaManagedAgentsUserMessageEventParamsContentType.Redacted,
            value.Type.Value()
        );
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsUserMessageEventParamsContent value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "text"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsUserMessageEventParamsContentType> expectedType =
            BetaManagedAgentsUserMessageEventParamsContentType.Text;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsUserMessageEventParamsContent emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsUserMessageEventParamsContentTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsUserMessageEventParamsContentType.Text)]
    [InlineData(BetaManagedAgentsUserMessageEventParamsContentType.Image)]
    [InlineData(BetaManagedAgentsUserMessageEventParamsContentType.Document)]
    [InlineData(BetaManagedAgentsUserMessageEventParamsContentType.Redacted)]
    public void Validation_Works(BetaManagedAgentsUserMessageEventParamsContentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUserMessageEventParamsContentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserMessageEventParamsContentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsUserMessageEventParamsContentType.Text)]
    [InlineData(BetaManagedAgentsUserMessageEventParamsContentType.Image)]
    [InlineData(BetaManagedAgentsUserMessageEventParamsContentType.Document)]
    [InlineData(BetaManagedAgentsUserMessageEventParamsContentType.Redacted)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsUserMessageEventParamsContentType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUserMessageEventParamsContentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserMessageEventParamsContentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserMessageEventParamsContentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserMessageEventParamsContentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
