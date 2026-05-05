using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsAgentReferenceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentReference
        {
            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
            Type = BetaManagedAgentsAgentReferenceType.Agent,
            Version = 1,
        };

        string expectedID = "agent_011CZkYqphY8vELVzwCUpqiQ";
        ApiEnum<string, BetaManagedAgentsAgentReferenceType> expectedType =
            BetaManagedAgentsAgentReferenceType.Agent;
        int expectedVersion = 1;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentReference
        {
            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
            Type = BetaManagedAgentsAgentReferenceType.Agent,
            Version = 1,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentReference>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsAgentReference
        {
            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
            Type = BetaManagedAgentsAgentReferenceType.Agent,
            Version = 1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentReference>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "agent_011CZkYqphY8vELVzwCUpqiQ";
        ApiEnum<string, BetaManagedAgentsAgentReferenceType> expectedType =
            BetaManagedAgentsAgentReferenceType.Agent;
        int expectedVersion = 1;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsAgentReference
        {
            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
            Type = BetaManagedAgentsAgentReferenceType.Agent,
            Version = 1,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsAgentReference
        {
            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
            Type = BetaManagedAgentsAgentReferenceType.Agent,
            Version = 1,
        };

        BetaManagedAgentsAgentReference copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsAgentReferenceTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsAgentReferenceType.Agent)]
    public void Validation_Works(BetaManagedAgentsAgentReferenceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentReferenceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentReferenceType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsAgentReferenceType.Agent)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsAgentReferenceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentReferenceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentReferenceType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentReferenceType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentReferenceType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
