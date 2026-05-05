using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsFileRubricParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsFileRubricParams
        {
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            Type = BetaManagedAgentsFileRubricParamsType.File,
        };

        string expectedFileID = "file_011CNha8iCJcU1wXNR6q4V8w";
        ApiEnum<string, BetaManagedAgentsFileRubricParamsType> expectedType =
            BetaManagedAgentsFileRubricParamsType.File;

        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsFileRubricParams
        {
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            Type = BetaManagedAgentsFileRubricParamsType.File,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsFileRubricParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsFileRubricParams
        {
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            Type = BetaManagedAgentsFileRubricParamsType.File,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsFileRubricParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFileID = "file_011CNha8iCJcU1wXNR6q4V8w";
        ApiEnum<string, BetaManagedAgentsFileRubricParamsType> expectedType =
            BetaManagedAgentsFileRubricParamsType.File;

        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsFileRubricParams
        {
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            Type = BetaManagedAgentsFileRubricParamsType.File,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsFileRubricParams
        {
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            Type = BetaManagedAgentsFileRubricParamsType.File,
        };

        BetaManagedAgentsFileRubricParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsFileRubricParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsFileRubricParamsType.File)]
    public void Validation_Works(BetaManagedAgentsFileRubricParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsFileRubricParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsFileRubricParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsFileRubricParamsType.File)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsFileRubricParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsFileRubricParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsFileRubricParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsFileRubricParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsFileRubricParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
