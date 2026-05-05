using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsMultiagentCoordinatorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMultiagentCoordinator
        {
            Agents =
            [
                new()
                {
                    ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                    Type = BetaManagedAgentsAgentReferenceType.Agent,
                    Version = 1,
                },
            ],
            Type = BetaManagedAgentsMultiagentCoordinatorType.Coordinator,
        };

        List<BetaManagedAgentsAgentReference> expectedAgents =
        [
            new()
            {
                ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                Type = BetaManagedAgentsAgentReferenceType.Agent,
                Version = 1,
            },
        ];
        ApiEnum<string, BetaManagedAgentsMultiagentCoordinatorType> expectedType =
            BetaManagedAgentsMultiagentCoordinatorType.Coordinator;

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
        var model = new BetaManagedAgentsMultiagentCoordinator
        {
            Agents =
            [
                new()
                {
                    ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                    Type = BetaManagedAgentsAgentReferenceType.Agent,
                    Version = 1,
                },
            ],
            Type = BetaManagedAgentsMultiagentCoordinatorType.Coordinator,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagentCoordinator>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMultiagentCoordinator
        {
            Agents =
            [
                new()
                {
                    ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                    Type = BetaManagedAgentsAgentReferenceType.Agent,
                    Version = 1,
                },
            ],
            Type = BetaManagedAgentsMultiagentCoordinatorType.Coordinator,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagentCoordinator>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaManagedAgentsAgentReference> expectedAgents =
        [
            new()
            {
                ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                Type = BetaManagedAgentsAgentReferenceType.Agent,
                Version = 1,
            },
        ];
        ApiEnum<string, BetaManagedAgentsMultiagentCoordinatorType> expectedType =
            BetaManagedAgentsMultiagentCoordinatorType.Coordinator;

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
        var model = new BetaManagedAgentsMultiagentCoordinator
        {
            Agents =
            [
                new()
                {
                    ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                    Type = BetaManagedAgentsAgentReferenceType.Agent,
                    Version = 1,
                },
            ],
            Type = BetaManagedAgentsMultiagentCoordinatorType.Coordinator,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMultiagentCoordinator
        {
            Agents =
            [
                new()
                {
                    ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                    Type = BetaManagedAgentsAgentReferenceType.Agent,
                    Version = 1,
                },
            ],
            Type = BetaManagedAgentsMultiagentCoordinatorType.Coordinator,
        };

        BetaManagedAgentsMultiagentCoordinator copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsMultiagentCoordinatorTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsMultiagentCoordinatorType.Coordinator)]
    public void Validation_Works(BetaManagedAgentsMultiagentCoordinatorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMultiagentCoordinatorType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentCoordinatorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsMultiagentCoordinatorType.Coordinator)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsMultiagentCoordinatorType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMultiagentCoordinatorType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentCoordinatorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentCoordinatorType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMultiagentCoordinatorType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
