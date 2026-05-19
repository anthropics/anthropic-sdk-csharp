using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsAgentToolset20260401WriteInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401WriteInput
        {
            Content = "content",
            FilePath = "file_path",
        };

        string expectedContent = "content";
        string expectedFilePath = "file_path";

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedFilePath, model.FilePath);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401WriteInput
        {
            Content = "content",
            FilePath = "file_path",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsAgentToolset20260401WriteInput>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401WriteInput
        {
            Content = "content",
            FilePath = "file_path",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsAgentToolset20260401WriteInput>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedContent = "content";
        string expectedFilePath = "file_path";

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedFilePath, deserialized.FilePath);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401WriteInput
        {
            Content = "content",
            FilePath = "file_path",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401WriteInput
        {
            Content = "content",
            FilePath = "file_path",
        };

        BetaManagedAgentsAgentToolset20260401WriteInput copied = new(model);

        Assert.Equal(model, copied);
    }
}
