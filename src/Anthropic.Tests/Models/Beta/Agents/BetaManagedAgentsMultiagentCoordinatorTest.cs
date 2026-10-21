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
                new BetaManagedAgentsAgentReference()
                {
                    ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                    Version = 1,
                },
            ],
        };

        List<Agent> expectedAgents =
        [
            new BetaManagedAgentsAgentReference()
            {
                ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                Version = 1,
            },
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("coordinator");

        Assert.Equal(expectedAgents.Count, model.Agents.Count);
        for (int i = 0; i < expectedAgents.Count; i++)
        {
            Assert.Equal(expectedAgents[i], model.Agents[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMultiagentCoordinator
        {
            Agents =
            [
                new BetaManagedAgentsAgentReference()
                {
                    ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                    Version = 1,
                },
            ],
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
                new BetaManagedAgentsAgentReference()
                {
                    ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                    Version = 1,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMultiagentCoordinator>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Agent> expectedAgents =
        [
            new BetaManagedAgentsAgentReference()
            {
                ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                Version = 1,
            },
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("coordinator");

        Assert.Equal(expectedAgents.Count, deserialized.Agents.Count);
        for (int i = 0; i < expectedAgents.Count; i++)
        {
            Assert.Equal(expectedAgents[i], deserialized.Agents[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMultiagentCoordinator
        {
            Agents =
            [
                new BetaManagedAgentsAgentReference()
                {
                    ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                    Version = 1,
                },
            ],
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
                new BetaManagedAgentsAgentReference()
                {
                    ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
                    Version = 1,
                },
            ],
        };

        BetaManagedAgentsMultiagentCoordinator copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AgentTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsAgentReferenceValidationWorks()
    {
        Agent value = new BetaManagedAgentsAgentReference()
        {
            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
            Version = 1,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAdvisorValidationWorks()
    {
        Agent value = new BetaManagedAgentsAdvisor("model");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsAgentReferenceSerializationRoundtripWorks()
    {
        Agent value = new BetaManagedAgentsAgentReference()
        {
            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
            Version = 1,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Agent>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAdvisorSerializationRoundtripWorks()
    {
        Agent value = new BetaManagedAgentsAdvisor("model");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Agent>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsAgentReferenceTypeWorks()
    {
        Agent value = new BetaManagedAgentsAgentReference()
        {
            ID = "agent_011CZkYqphY8vELVzwCUpqiQ",
            Version = 1,
        };
        Assert.Equal(AgentType.Agent, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsAdvisorTypeWorks()
    {
        Agent value = new BetaManagedAgentsAdvisor("model");
        Assert.Equal(AgentType.Advisor, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Agent value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "agent"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, AgentType> expectedType = AgentType.Agent;

        Assert.Equal(expectedType, value.Type);

        Agent emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class AgentTypeTest : TestBase
{
    [Theory]
    [InlineData(AgentType.Agent)]
    [InlineData(AgentType.Advisor)]
    public void Validation_Works(AgentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AgentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AgentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AgentType.Agent)]
    [InlineData(AgentType.Advisor)]
    public void SerializationRoundtrip_Works(AgentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AgentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AgentType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AgentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AgentType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
