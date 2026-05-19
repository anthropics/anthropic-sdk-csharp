using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsAgentToolset20260401GlobInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401GlobInput
        {
            Pattern = "pattern",
            Path = "path",
        };

        string expectedPattern = "pattern";
        string expectedPath = "path";

        Assert.Equal(expectedPattern, model.Pattern);
        Assert.Equal(expectedPath, model.Path);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401GlobInput
        {
            Pattern = "pattern",
            Path = "path",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsAgentToolset20260401GlobInput>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401GlobInput
        {
            Pattern = "pattern",
            Path = "path",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsAgentToolset20260401GlobInput>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedPattern = "pattern";
        string expectedPath = "path";

        Assert.Equal(expectedPattern, deserialized.Pattern);
        Assert.Equal(expectedPath, deserialized.Path);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401GlobInput
        {
            Pattern = "pattern",
            Path = "path",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401GlobInput { Pattern = "pattern" };

        Assert.Null(model.Path);
        Assert.False(model.RawData.ContainsKey("path"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401GlobInput { Pattern = "pattern" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401GlobInput
        {
            Pattern = "pattern",

            // Null should be interpreted as omitted for these properties
            Path = null,
        };

        Assert.Null(model.Path);
        Assert.False(model.RawData.ContainsKey("path"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401GlobInput
        {
            Pattern = "pattern",

            // Null should be interpreted as omitted for these properties
            Path = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401GlobInput
        {
            Pattern = "pattern",
            Path = "path",
        };

        BetaManagedAgentsAgentToolset20260401GlobInput copied = new(model);

        Assert.Equal(model, copied);
    }
}
