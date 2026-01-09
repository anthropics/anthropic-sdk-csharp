using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ServerToolUsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ServerToolUsage { WebSearchRequests = 0 };

        long expectedWebSearchRequests = 0;

        Assert.Equal(expectedWebSearchRequests, model.WebSearchRequests);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ServerToolUsage { WebSearchRequests = 0 };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ServerToolUsage>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ServerToolUsage { WebSearchRequests = 0 };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ServerToolUsage>(element);
        Assert.NotNull(deserialized);

        long expectedWebSearchRequests = 0;

        Assert.Equal(expectedWebSearchRequests, deserialized.WebSearchRequests);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ServerToolUsage { WebSearchRequests = 0 };

        model.Validate();
    }
}
