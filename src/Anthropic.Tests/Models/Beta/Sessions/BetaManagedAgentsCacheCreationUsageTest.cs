using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsCacheCreationUsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsCacheCreationUsage
        {
            Ephemeral1hInputTokens = 0,
            Ephemeral5mInputTokens = 0,
        };

        int expectedEphemeral1hInputTokens = 0;
        int expectedEphemeral5mInputTokens = 0;

        Assert.Equal(expectedEphemeral1hInputTokens, model.Ephemeral1hInputTokens);
        Assert.Equal(expectedEphemeral5mInputTokens, model.Ephemeral5mInputTokens);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsCacheCreationUsage
        {
            Ephemeral1hInputTokens = 0,
            Ephemeral5mInputTokens = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsCacheCreationUsage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsCacheCreationUsage
        {
            Ephemeral1hInputTokens = 0,
            Ephemeral5mInputTokens = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsCacheCreationUsage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        int expectedEphemeral1hInputTokens = 0;
        int expectedEphemeral5mInputTokens = 0;

        Assert.Equal(expectedEphemeral1hInputTokens, deserialized.Ephemeral1hInputTokens);
        Assert.Equal(expectedEphemeral5mInputTokens, deserialized.Ephemeral5mInputTokens);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsCacheCreationUsage
        {
            Ephemeral1hInputTokens = 0,
            Ephemeral5mInputTokens = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsCacheCreationUsage { };

        Assert.Null(model.Ephemeral1hInputTokens);
        Assert.False(model.RawData.ContainsKey("ephemeral_1h_input_tokens"));
        Assert.Null(model.Ephemeral5mInputTokens);
        Assert.False(model.RawData.ContainsKey("ephemeral_5m_input_tokens"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsCacheCreationUsage { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsCacheCreationUsage
        {
            // Null should be interpreted as omitted for these properties
            Ephemeral1hInputTokens = null,
            Ephemeral5mInputTokens = null,
        };

        Assert.Null(model.Ephemeral1hInputTokens);
        Assert.False(model.RawData.ContainsKey("ephemeral_1h_input_tokens"));
        Assert.Null(model.Ephemeral5mInputTokens);
        Assert.False(model.RawData.ContainsKey("ephemeral_5m_input_tokens"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsCacheCreationUsage
        {
            // Null should be interpreted as omitted for these properties
            Ephemeral1hInputTokens = null,
            Ephemeral5mInputTokens = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsCacheCreationUsage
        {
            Ephemeral1hInputTokens = 0,
            Ephemeral5mInputTokens = 0,
        };

        BetaManagedAgentsCacheCreationUsage copied = new(model);

        Assert.Equal(model, copied);
    }
}
