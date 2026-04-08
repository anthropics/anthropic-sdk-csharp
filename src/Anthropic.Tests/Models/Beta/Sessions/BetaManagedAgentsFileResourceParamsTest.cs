using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsFileResourceParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsFileResourceParams
        {
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            Type = BetaManagedAgentsFileResourceParamsType.File,
            MountPath = "/uploads/receipt.pdf",
        };

        string expectedFileID = "file_011CNha8iCJcU1wXNR6q4V8w";
        ApiEnum<string, BetaManagedAgentsFileResourceParamsType> expectedType =
            BetaManagedAgentsFileResourceParamsType.File;
        string expectedMountPath = "/uploads/receipt.pdf";

        Assert.Equal(expectedFileID, model.FileID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedMountPath, model.MountPath);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsFileResourceParams
        {
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            Type = BetaManagedAgentsFileResourceParamsType.File,
            MountPath = "/uploads/receipt.pdf",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsFileResourceParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsFileResourceParams
        {
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            Type = BetaManagedAgentsFileResourceParamsType.File,
            MountPath = "/uploads/receipt.pdf",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsFileResourceParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFileID = "file_011CNha8iCJcU1wXNR6q4V8w";
        ApiEnum<string, BetaManagedAgentsFileResourceParamsType> expectedType =
            BetaManagedAgentsFileResourceParamsType.File;
        string expectedMountPath = "/uploads/receipt.pdf";

        Assert.Equal(expectedFileID, deserialized.FileID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedMountPath, deserialized.MountPath);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsFileResourceParams
        {
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            Type = BetaManagedAgentsFileResourceParamsType.File,
            MountPath = "/uploads/receipt.pdf",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsFileResourceParams
        {
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            Type = BetaManagedAgentsFileResourceParamsType.File,
        };

        Assert.Null(model.MountPath);
        Assert.False(model.RawData.ContainsKey("mount_path"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsFileResourceParams
        {
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            Type = BetaManagedAgentsFileResourceParamsType.File,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsFileResourceParams
        {
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            Type = BetaManagedAgentsFileResourceParamsType.File,

            MountPath = null,
        };

        Assert.Null(model.MountPath);
        Assert.True(model.RawData.ContainsKey("mount_path"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsFileResourceParams
        {
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            Type = BetaManagedAgentsFileResourceParamsType.File,

            MountPath = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsFileResourceParams
        {
            FileID = "file_011CNha8iCJcU1wXNR6q4V8w",
            Type = BetaManagedAgentsFileResourceParamsType.File,
            MountPath = "/uploads/receipt.pdf",
        };

        BetaManagedAgentsFileResourceParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsFileResourceParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsFileResourceParamsType.File)]
    public void Validation_Works(BetaManagedAgentsFileResourceParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsFileResourceParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsFileResourceParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsFileResourceParamsType.File)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsFileResourceParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsFileResourceParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsFileResourceParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsFileResourceParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsFileResourceParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
