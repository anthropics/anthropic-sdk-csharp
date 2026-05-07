using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsMultiagentParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMultiagentParams
        {
            Agents =
            [
                "agent_011CZkYqphY8vELVzwCUpqiQ",
                new BetaManagedAgentsMultiagentSelfParams(
                    BetaManagedAgentsMultiagentSelfParamsType.Self
                ),
            ],
            Type = BetaManagedAgentsMultiagentParamsType.Coordinator,
        };

        List<BetaManagedAgentsMultiagentRosterEntryParams> expectedAgents =
        [
            "agent_011CZkYqphY8vELVzwCUpqiQ",
            new BetaManagedAgentsMultiagentSelfParams(
                BetaManagedAgentsMultiagentSelfParamsType.Self
            ),
        ];
        ApiEnum<string, BetaManagedAgentsMultiagentParamsType> expectedType =
            BetaManagedAgentsMultiagentParamsType.Coordinator;

        Assert.Equal(expectedAgents.Count, model.Agents.Count);
        for (int i = 0; i < expectedAgents.Count; i++)
        {
            Assert.Equal(expectedAgents[i], model.Agents[i]);
        }
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMultiagentParams
        {
            Agents =
            [
                "agent_011CZkYqphY8vELVzwCUpqiQ",
                new BetaManagedAgentsMultiagentSelfParams(
                    BetaManagedAgentsMultiagentSelfParamsType.Self
                ),
            ],
            Type = BetaManagedAgentsMultiagentParamsType.Coordinator,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagentParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMultiagentParams
        {
            Agents =
            [
                "agent_011CZkYqphY8vELVzwCUpqiQ",
                new BetaManagedAgentsMultiagentSelfParams(
                    BetaManagedAgentsMultiagentSelfParamsType.Self
                ),
            ],
            Type = BetaManagedAgentsMultiagentParamsType.Coordinator,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagentParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaManagedAgentsMultiagentRosterEntryParams> expectedAgents =
        [
            "agent_011CZkYqphY8vELVzwCUpqiQ",
            new BetaManagedAgentsMultiagentSelfParams(
                BetaManagedAgentsMultiagentSelfParamsType.Self
            ),
        ];
        ApiEnum<string, BetaManagedAgentsMultiagentParamsType> expectedType =
            BetaManagedAgentsMultiagentParamsType.Coordinator;

        Assert.Equal(expectedAgents.Count, deserialized.Agents.Count);
        for (int i = 0; i < expectedAgents.Count; i++)
        {
            Assert.Equal(expectedAgents[i], deserialized.Agents[i]);
        }
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMultiagentParams
        {
            Agents =
            [
                "agent_011CZkYqphY8vELVzwCUpqiQ",
                new BetaManagedAgentsMultiagentSelfParams(
                    BetaManagedAgentsMultiagentSelfParamsType.Self
                ),
            ],
            Type = BetaManagedAgentsMultiagentParamsType.Coordinator,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMultiagentParams
        {
            Agents =
            [
                "agent_011CZkYqphY8vELVzwCUpqiQ",
                new BetaManagedAgentsMultiagentSelfParams(
                    BetaManagedAgentsMultiagentSelfParamsType.Self
                ),
            ],
            Type = BetaManagedAgentsMultiagentParamsType.Coordinator,
        };

        BetaManagedAgentsMultiagentParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsMultiagentParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsMultiagentParamsType.Coordinator)]
    public void Validation_Works(BetaManagedAgentsMultiagentParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMultiagentParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsMultiagentParamsType.Coordinator)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsMultiagentParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMultiagentParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
