using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.MemoryStores.Memories;

namespace Anthropic.Tests.Models.Beta.MemoryStores.Memories;

public class BetaManagedAgentsPreconditionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsPrecondition
        {
            Type = BetaManagedAgentsPreconditionType.ContentSha256,
            ContentSha256 = "content_sha256",
        };

        ApiEnum<string, BetaManagedAgentsPreconditionType> expectedType =
            BetaManagedAgentsPreconditionType.ContentSha256;
        string expectedContentSha256 = "content_sha256";

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedContentSha256, model.ContentSha256);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsPrecondition
        {
            Type = BetaManagedAgentsPreconditionType.ContentSha256,
            ContentSha256 = "content_sha256",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsPrecondition>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsPrecondition
        {
            Type = BetaManagedAgentsPreconditionType.ContentSha256,
            ContentSha256 = "content_sha256",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsPrecondition>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaManagedAgentsPreconditionType> expectedType =
            BetaManagedAgentsPreconditionType.ContentSha256;
        string expectedContentSha256 = "content_sha256";

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedContentSha256, deserialized.ContentSha256);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsPrecondition
        {
            Type = BetaManagedAgentsPreconditionType.ContentSha256,
            ContentSha256 = "content_sha256",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsPrecondition
        {
            Type = BetaManagedAgentsPreconditionType.ContentSha256,
        };

        Assert.Null(model.ContentSha256);
        Assert.False(model.RawData.ContainsKey("content_sha256"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsPrecondition
        {
            Type = BetaManagedAgentsPreconditionType.ContentSha256,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsPrecondition
        {
            Type = BetaManagedAgentsPreconditionType.ContentSha256,

            // Null should be interpreted as omitted for these properties
            ContentSha256 = null,
        };

        Assert.Null(model.ContentSha256);
        Assert.False(model.RawData.ContainsKey("content_sha256"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsPrecondition
        {
            Type = BetaManagedAgentsPreconditionType.ContentSha256,

            // Null should be interpreted as omitted for these properties
            ContentSha256 = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsPrecondition
        {
            Type = BetaManagedAgentsPreconditionType.ContentSha256,
            ContentSha256 = "content_sha256",
        };

        BetaManagedAgentsPrecondition copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsPreconditionTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsPreconditionType.ContentSha256)]
    public void Validation_Works(BetaManagedAgentsPreconditionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsPreconditionType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsPreconditionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsPreconditionType.ContentSha256)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsPreconditionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsPreconditionType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsPreconditionType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsPreconditionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsPreconditionType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
