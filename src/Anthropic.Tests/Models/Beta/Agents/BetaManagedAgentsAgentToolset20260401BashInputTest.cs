using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsAgentToolset20260401BashInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401BashInput
        {
            Command = "command",
            Restart = true,
            TimeoutMs = 0,
        };

        string expectedCommand = "command";
        bool expectedRestart = true;
        long expectedTimeoutMs = 0;

        Assert.Equal(expectedCommand, model.Command);
        Assert.Equal(expectedRestart, model.Restart);
        Assert.Equal(expectedTimeoutMs, model.TimeoutMs);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401BashInput
        {
            Command = "command",
            Restart = true,
            TimeoutMs = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsAgentToolset20260401BashInput>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401BashInput
        {
            Command = "command",
            Restart = true,
            TimeoutMs = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsAgentToolset20260401BashInput>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCommand = "command";
        bool expectedRestart = true;
        long expectedTimeoutMs = 0;

        Assert.Equal(expectedCommand, deserialized.Command);
        Assert.Equal(expectedRestart, deserialized.Restart);
        Assert.Equal(expectedTimeoutMs, deserialized.TimeoutMs);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401BashInput
        {
            Command = "command",
            Restart = true,
            TimeoutMs = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401BashInput { };

        Assert.Null(model.Command);
        Assert.False(model.RawData.ContainsKey("command"));
        Assert.Null(model.Restart);
        Assert.False(model.RawData.ContainsKey("restart"));
        Assert.Null(model.TimeoutMs);
        Assert.False(model.RawData.ContainsKey("timeout_ms"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401BashInput { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401BashInput
        {
            // Null should be interpreted as omitted for these properties
            Command = null,
            Restart = null,
            TimeoutMs = null,
        };

        Assert.Null(model.Command);
        Assert.False(model.RawData.ContainsKey("command"));
        Assert.Null(model.Restart);
        Assert.False(model.RawData.ContainsKey("restart"));
        Assert.Null(model.TimeoutMs);
        Assert.False(model.RawData.ContainsKey("timeout_ms"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401BashInput
        {
            // Null should be interpreted as omitted for these properties
            Command = null,
            Restart = null,
            TimeoutMs = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401BashInput
        {
            Command = "command",
            Restart = true,
            TimeoutMs = 0,
        };

        BetaManagedAgentsAgentToolset20260401BashInput copied = new(model);

        Assert.Equal(model, copied);
    }
}
