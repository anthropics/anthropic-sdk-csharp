using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsCommitCheckoutTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsCommitCheckout
        {
            Sha = "xxxxxxx",
            Type = BetaManagedAgentsCommitCheckoutType.Commit,
        };

        string expectedSha = "xxxxxxx";
        ApiEnum<string, BetaManagedAgentsCommitCheckoutType> expectedType =
            BetaManagedAgentsCommitCheckoutType.Commit;

        Assert.Equal(expectedSha, model.Sha);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsCommitCheckout
        {
            Sha = "xxxxxxx",
            Type = BetaManagedAgentsCommitCheckoutType.Commit,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsCommitCheckout>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsCommitCheckout
        {
            Sha = "xxxxxxx",
            Type = BetaManagedAgentsCommitCheckoutType.Commit,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsCommitCheckout>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSha = "xxxxxxx";
        ApiEnum<string, BetaManagedAgentsCommitCheckoutType> expectedType =
            BetaManagedAgentsCommitCheckoutType.Commit;

        Assert.Equal(expectedSha, deserialized.Sha);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsCommitCheckout
        {
            Sha = "xxxxxxx",
            Type = BetaManagedAgentsCommitCheckoutType.Commit,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsCommitCheckout
        {
            Sha = "xxxxxxx",
            Type = BetaManagedAgentsCommitCheckoutType.Commit,
        };

        BetaManagedAgentsCommitCheckout copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsCommitCheckoutTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsCommitCheckoutType.Commit)]
    public void Validation_Works(BetaManagedAgentsCommitCheckoutType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsCommitCheckoutType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsCommitCheckoutType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsCommitCheckoutType.Commit)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsCommitCheckoutType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsCommitCheckoutType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsCommitCheckoutType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsCommitCheckoutType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsCommitCheckoutType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
