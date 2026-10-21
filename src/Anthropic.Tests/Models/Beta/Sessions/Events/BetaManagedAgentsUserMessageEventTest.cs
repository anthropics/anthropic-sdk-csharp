using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsUserMessageEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsUserMessageEvent
        {
            ID = "sevt_011CZkZGPp1iBcp4kaQSihUm",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };

        string expectedID = "sevt_011CZkZGPp1iBcp4kaQSihUm";
        List<BetaManagedAgentsUserMessageEventContent> expectedContent =
        [
            new BetaManagedAgentsTextBlock("Where is my order #1234?"),
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("user.message");
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedContent.Count, model.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], model.Content[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsUserMessageEvent
        {
            ID = "sevt_011CZkZGPp1iBcp4kaQSihUm",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsUserMessageEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsUserMessageEvent
        {
            ID = "sevt_011CZkZGPp1iBcp4kaQSihUm",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsUserMessageEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "sevt_011CZkZGPp1iBcp4kaQSihUm";
        List<BetaManagedAgentsUserMessageEventContent> expectedContent =
        [
            new BetaManagedAgentsTextBlock("Where is my order #1234?"),
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("user.message");
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedContent.Count, deserialized.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], deserialized.Content[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsUserMessageEvent
        {
            ID = "sevt_011CZkZGPp1iBcp4kaQSihUm",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsUserMessageEvent
        {
            ID = "sevt_011CZkZGPp1iBcp4kaQSihUm",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
        };

        Assert.Null(model.ProcessedAt);
        Assert.False(model.RawData.ContainsKey("processed_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsUserMessageEvent
        {
            ID = "sevt_011CZkZGPp1iBcp4kaQSihUm",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsUserMessageEvent
        {
            ID = "sevt_011CZkZGPp1iBcp4kaQSihUm",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],

            ProcessedAt = null,
        };

        Assert.Null(model.ProcessedAt);
        Assert.True(model.RawData.ContainsKey("processed_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsUserMessageEvent
        {
            ID = "sevt_011CZkZGPp1iBcp4kaQSihUm",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],

            ProcessedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsUserMessageEvent
        {
            ID = "sevt_011CZkZGPp1iBcp4kaQSihUm",
            Content = [new BetaManagedAgentsTextBlock("Where is my order #1234?")],
            ProcessedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
        };

        BetaManagedAgentsUserMessageEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsUserMessageEventContentTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsTextBlockValidationWorks()
    {
        BetaManagedAgentsUserMessageEventContent value = new BetaManagedAgentsTextBlock(
            "Where is my order #1234?"
        );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsImageBlockValidationWorks()
    {
        BetaManagedAgentsUserMessageEventContent value = new BetaManagedAgentsImageBlock(
            new BetaManagedAgentsBase64ImageSource() { Data = "x", MediaType = "x" }
        );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsDocumentBlockValidationWorks()
    {
        BetaManagedAgentsUserMessageEventContent value = new BetaManagedAgentsDocumentBlock()
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
        BetaManagedAgentsUserMessageEventContent value = new BetaManagedAgentsRedactedBlock();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsTextBlockSerializationRoundtripWorks()
    {
        BetaManagedAgentsUserMessageEventContent value = new BetaManagedAgentsTextBlock(
            "Where is my order #1234?"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsUserMessageEventContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsImageBlockSerializationRoundtripWorks()
    {
        BetaManagedAgentsUserMessageEventContent value = new BetaManagedAgentsImageBlock(
            new BetaManagedAgentsBase64ImageSource() { Data = "x", MediaType = "x" }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsUserMessageEventContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsDocumentBlockSerializationRoundtripWorks()
    {
        BetaManagedAgentsUserMessageEventContent value = new BetaManagedAgentsDocumentBlock()
        {
            Source = new BetaManagedAgentsBase64DocumentSource() { Data = "x", MediaType = "x" },
            Context = "context",
            Title = "title",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsUserMessageEventContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsRedactedBlockSerializationRoundtripWorks()
    {
        BetaManagedAgentsUserMessageEventContent value = new BetaManagedAgentsRedactedBlock();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsUserMessageEventContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsTextBlockTypeWorks()
    {
        BetaManagedAgentsUserMessageEventContent value = new BetaManagedAgentsTextBlock(
            "Where is my order #1234?"
        );
        Assert.Equal(BetaManagedAgentsUserMessageEventContentType.Text, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsImageBlockTypeWorks()
    {
        BetaManagedAgentsUserMessageEventContent value = new BetaManagedAgentsImageBlock(
            new BetaManagedAgentsBase64ImageSource() { Data = "x", MediaType = "x" }
        );
        Assert.Equal(BetaManagedAgentsUserMessageEventContentType.Image, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsDocumentBlockTypeWorks()
    {
        BetaManagedAgentsUserMessageEventContent value = new BetaManagedAgentsDocumentBlock()
        {
            Source = new BetaManagedAgentsBase64DocumentSource() { Data = "x", MediaType = "x" },
            Context = "context",
            Title = "title",
        };
        Assert.Equal(BetaManagedAgentsUserMessageEventContentType.Document, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsRedactedBlockTypeWorks()
    {
        BetaManagedAgentsUserMessageEventContent value = new BetaManagedAgentsRedactedBlock();
        Assert.Equal(BetaManagedAgentsUserMessageEventContentType.Redacted, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsUserMessageEventContent value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "text"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsUserMessageEventContentType> expectedType =
            BetaManagedAgentsUserMessageEventContentType.Text;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsUserMessageEventContent emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsUserMessageEventContentTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsUserMessageEventContentType.Text)]
    [InlineData(BetaManagedAgentsUserMessageEventContentType.Image)]
    [InlineData(BetaManagedAgentsUserMessageEventContentType.Document)]
    [InlineData(BetaManagedAgentsUserMessageEventContentType.Redacted)]
    public void Validation_Works(BetaManagedAgentsUserMessageEventContentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUserMessageEventContentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserMessageEventContentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsUserMessageEventContentType.Text)]
    [InlineData(BetaManagedAgentsUserMessageEventContentType.Image)]
    [InlineData(BetaManagedAgentsUserMessageEventContentType.Document)]
    [InlineData(BetaManagedAgentsUserMessageEventContentType.Redacted)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsUserMessageEventContentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUserMessageEventContentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserMessageEventContentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserMessageEventContentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserMessageEventContentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
