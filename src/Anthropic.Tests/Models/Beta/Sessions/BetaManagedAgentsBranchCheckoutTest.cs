using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsBranchCheckoutTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsBranchCheckout
        {
            Name = "main",
            Type = BetaManagedAgentsBranchCheckoutType.Branch,
        };

        string expectedName = "main";
        ApiEnum<string, BetaManagedAgentsBranchCheckoutType> expectedType =
            BetaManagedAgentsBranchCheckoutType.Branch;

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsBranchCheckout
        {
            Name = "main",
            Type = BetaManagedAgentsBranchCheckoutType.Branch,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsBranchCheckout>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsBranchCheckout
        {
            Name = "main",
            Type = BetaManagedAgentsBranchCheckoutType.Branch,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsBranchCheckout>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "main";
        ApiEnum<string, BetaManagedAgentsBranchCheckoutType> expectedType =
            BetaManagedAgentsBranchCheckoutType.Branch;

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsBranchCheckout
        {
            Name = "main",
            Type = BetaManagedAgentsBranchCheckoutType.Branch,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsBranchCheckout
        {
            Name = "main",
            Type = BetaManagedAgentsBranchCheckoutType.Branch,
        };

        BetaManagedAgentsBranchCheckout copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsBranchCheckoutTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsBranchCheckoutType.Branch)]
    public void Validation_Works(BetaManagedAgentsBranchCheckoutType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsBranchCheckoutType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsBranchCheckoutType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsBranchCheckoutType.Branch)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsBranchCheckoutType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsBranchCheckoutType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsBranchCheckoutType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsBranchCheckoutType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsBranchCheckoutType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
