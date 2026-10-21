using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsWebFetchUrlSourcesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsWebFetchUrlSources
        {
            ClientToolResults = new BetaManagedAgentsWebFetchUrlSourceAll(),
            ServerToolResults = new BetaManagedAgentsWebFetchUrlSourceAll(),
            UserInput = new BetaManagedAgentsWebFetchUrlSourceAll(),
        };

        BetaManagedAgentsWebFetchUrlSourceToolFilter expectedClientToolResults =
            new BetaManagedAgentsWebFetchUrlSourceAll();
        BetaManagedAgentsWebFetchUrlSourceToolFilter expectedServerToolResults =
            new BetaManagedAgentsWebFetchUrlSourceAll();
        BetaManagedAgentsWebFetchUrlSourceUserInput expectedUserInput =
            new BetaManagedAgentsWebFetchUrlSourceAll();

        Assert.Equal(expectedClientToolResults, model.ClientToolResults);
        Assert.Equal(expectedServerToolResults, model.ServerToolResults);
        Assert.Equal(expectedUserInput, model.UserInput);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsWebFetchUrlSources
        {
            ClientToolResults = new BetaManagedAgentsWebFetchUrlSourceAll(),
            ServerToolResults = new BetaManagedAgentsWebFetchUrlSourceAll(),
            UserInput = new BetaManagedAgentsWebFetchUrlSourceAll(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWebFetchUrlSources>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsWebFetchUrlSources
        {
            ClientToolResults = new BetaManagedAgentsWebFetchUrlSourceAll(),
            ServerToolResults = new BetaManagedAgentsWebFetchUrlSourceAll(),
            UserInput = new BetaManagedAgentsWebFetchUrlSourceAll(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWebFetchUrlSources>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaManagedAgentsWebFetchUrlSourceToolFilter expectedClientToolResults =
            new BetaManagedAgentsWebFetchUrlSourceAll();
        BetaManagedAgentsWebFetchUrlSourceToolFilter expectedServerToolResults =
            new BetaManagedAgentsWebFetchUrlSourceAll();
        BetaManagedAgentsWebFetchUrlSourceUserInput expectedUserInput =
            new BetaManagedAgentsWebFetchUrlSourceAll();

        Assert.Equal(expectedClientToolResults, deserialized.ClientToolResults);
        Assert.Equal(expectedServerToolResults, deserialized.ServerToolResults);
        Assert.Equal(expectedUserInput, deserialized.UserInput);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsWebFetchUrlSources
        {
            ClientToolResults = new BetaManagedAgentsWebFetchUrlSourceAll(),
            ServerToolResults = new BetaManagedAgentsWebFetchUrlSourceAll(),
            UserInput = new BetaManagedAgentsWebFetchUrlSourceAll(),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsWebFetchUrlSources
        {
            ClientToolResults = new BetaManagedAgentsWebFetchUrlSourceAll(),
            ServerToolResults = new BetaManagedAgentsWebFetchUrlSourceAll(),
            UserInput = new BetaManagedAgentsWebFetchUrlSourceAll(),
        };

        BetaManagedAgentsWebFetchUrlSources copied = new(model);

        Assert.Equal(model, copied);
    }
}
