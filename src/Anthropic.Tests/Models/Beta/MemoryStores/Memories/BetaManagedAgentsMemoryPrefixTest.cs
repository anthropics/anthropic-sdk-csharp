using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.MemoryStores.Memories;

namespace Anthropic.Tests.Models.Beta.MemoryStores.Memories;

public class BetaManagedAgentsMemoryPrefixTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMemoryPrefix
        {
            Path = "path",
            Type = BetaManagedAgentsMemoryPrefixType.MemoryPrefix,
        };

        string expectedPath = "path";
        ApiEnum<string, BetaManagedAgentsMemoryPrefixType> expectedType =
            BetaManagedAgentsMemoryPrefixType.MemoryPrefix;

        Assert.Equal(expectedPath, model.Path);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMemoryPrefix
        {
            Path = "path",
            Type = BetaManagedAgentsMemoryPrefixType.MemoryPrefix,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMemoryPrefix>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMemoryPrefix
        {
            Path = "path",
            Type = BetaManagedAgentsMemoryPrefixType.MemoryPrefix,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMemoryPrefix>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedPath = "path";
        ApiEnum<string, BetaManagedAgentsMemoryPrefixType> expectedType =
            BetaManagedAgentsMemoryPrefixType.MemoryPrefix;

        Assert.Equal(expectedPath, deserialized.Path);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMemoryPrefix
        {
            Path = "path",
            Type = BetaManagedAgentsMemoryPrefixType.MemoryPrefix,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMemoryPrefix
        {
            Path = "path",
            Type = BetaManagedAgentsMemoryPrefixType.MemoryPrefix,
        };

        BetaManagedAgentsMemoryPrefix copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsMemoryPrefixTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsMemoryPrefixType.MemoryPrefix)]
    public void Validation_Works(BetaManagedAgentsMemoryPrefixType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMemoryPrefixType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsMemoryPrefixType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsMemoryPrefixType.MemoryPrefix)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsMemoryPrefixType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMemoryPrefixType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryPrefixType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsMemoryPrefixType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMemoryPrefixType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
