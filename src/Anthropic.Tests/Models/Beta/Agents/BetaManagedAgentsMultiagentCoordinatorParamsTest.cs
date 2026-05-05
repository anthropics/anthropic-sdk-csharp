using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsMultiagentCoordinatorParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMultiagentCoordinatorParams
        {
            Agents =
            [
                "agent_011CZkYqphY8vELVzwCUpqiQ",
                new BetaManagedAgentsMultiagentSelfParams(
                    BetaManagedAgentsMultiagentSelfParamsType.Self
                ),
            ],
            Type = BetaManagedAgentsMultiagentCoordinatorParamsType.Coordinator,
        };

        List<BetaManagedAgentsMultiagentRosterEntryParams> expectedAgents =
        [
            "agent_011CZkYqphY8vELVzwCUpqiQ",
            new BetaManagedAgentsMultiagentSelfParams(
                BetaManagedAgentsMultiagentSelfParamsType.Self
            ),
        ];
        ApiEnum<string, BetaManagedAgentsMultiagentCoordinatorParamsType> expectedType =
            BetaManagedAgentsMultiagentCoordinatorParamsType.Coordinator;

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
        var model = new BetaManagedAgentsMultiagentCoordinatorParams
        {
            Agents =
            [
                "agent_011CZkYqphY8vELVzwCUpqiQ",
                new BetaManagedAgentsMultiagentSelfParams(
                    BetaManagedAgentsMultiagentSelfParamsType.Self
                ),
            ],
            Type = BetaManagedAgentsMultiagentCoordinatorParamsType.Coordinator,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagentCoordinatorParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMultiagentCoordinatorParams
        {
            Agents =
            [
                "agent_011CZkYqphY8vELVzwCUpqiQ",
                new BetaManagedAgentsMultiagentSelfParams(
                    BetaManagedAgentsMultiagentSelfParamsType.Self
                ),
            ],
            Type = BetaManagedAgentsMultiagentCoordinatorParamsType.Coordinator,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagentCoordinatorParams>(
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
        ApiEnum<string, BetaManagedAgentsMultiagentCoordinatorParamsType> expectedType =
            BetaManagedAgentsMultiagentCoordinatorParamsType.Coordinator;

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
        var model = new BetaManagedAgentsMultiagentCoordinatorParams
        {
            Agents =
            [
                "agent_011CZkYqphY8vELVzwCUpqiQ",
                new BetaManagedAgentsMultiagentSelfParams(
                    BetaManagedAgentsMultiagentSelfParamsType.Self
                ),
            ],
            Type = BetaManagedAgentsMultiagentCoordinatorParamsType.Coordinator,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMultiagentCoordinatorParams
        {
            Agents =
            [
                "agent_011CZkYqphY8vELVzwCUpqiQ",
                new BetaManagedAgentsMultiagentSelfParams(
                    BetaManagedAgentsMultiagentSelfParamsType.Self
                ),
            ],
            Type = BetaManagedAgentsMultiagentCoordinatorParamsType.Coordinator,
        };

        BetaManagedAgentsMultiagentCoordinatorParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsMultiagentCoordinatorParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsMultiagentCoordinatorParamsType.Coordinator)]
    public void Validation_Works(BetaManagedAgentsMultiagentCoordinatorParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMultiagentCoordinatorParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentCoordinatorParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsMultiagentCoordinatorParamsType.Coordinator)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsMultiagentCoordinatorParamsType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMultiagentCoordinatorParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentCoordinatorParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentCoordinatorParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentCoordinatorParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
