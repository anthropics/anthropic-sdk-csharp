using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsFileDocumentSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsFileDocumentSource
        {
            FileID = "file_id",
            Type = BetaManagedAgentsFileDocumentSourceType.File,
        };

        string expectedFileID = "file_id";
        ApiEnum<string, BetaManagedAgentsFileDocumentSourceType> expectedType =
            BetaManagedAgentsFileDocumentSourceType.File;

        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsFileDocumentSource
        {
            FileID = "file_id",
            Type = BetaManagedAgentsFileDocumentSourceType.File,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsFileDocumentSource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsFileDocumentSource
        {
            FileID = "file_id",
            Type = BetaManagedAgentsFileDocumentSourceType.File,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsFileDocumentSource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFileID = "file_id";
        ApiEnum<string, BetaManagedAgentsFileDocumentSourceType> expectedType =
            BetaManagedAgentsFileDocumentSourceType.File;

        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsFileDocumentSource
        {
            FileID = "file_id",
            Type = BetaManagedAgentsFileDocumentSourceType.File,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsFileDocumentSource
        {
            FileID = "file_id",
            Type = BetaManagedAgentsFileDocumentSourceType.File,
        };

        BetaManagedAgentsFileDocumentSource copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsFileDocumentSourceTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsFileDocumentSourceType.File)]
    public void Validation_Works(BetaManagedAgentsFileDocumentSourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsFileDocumentSourceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsFileDocumentSourceType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsFileDocumentSourceType.File)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsFileDocumentSourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsFileDocumentSourceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsFileDocumentSourceType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsFileDocumentSourceType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsFileDocumentSourceType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
