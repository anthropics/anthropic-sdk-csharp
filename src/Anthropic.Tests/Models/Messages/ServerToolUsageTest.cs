using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ServerToolUsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ServerToolUsage { WebFetchRequests = 2, WebSearchRequests = 0 };

        long expectedWebFetchRequests = 2;
        long expectedWebSearchRequests = 0;

        Assert.Equal(expectedWebFetchRequests, model.WebFetchRequests);
        Assert.Equal(expectedWebSearchRequests, model.WebSearchRequests);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ServerToolUsage { WebFetchRequests = 2, WebSearchRequests = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ServerToolUsage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ServerToolUsage { WebFetchRequests = 2, WebSearchRequests = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ServerToolUsage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedWebFetchRequests = 2;
        long expectedWebSearchRequests = 0;

        Assert.Equal(expectedWebFetchRequests, deserialized.WebFetchRequests);
        Assert.Equal(expectedWebSearchRequests, deserialized.WebSearchRequests);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ServerToolUsage { WebFetchRequests = 2, WebSearchRequests = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ServerToolUsage { WebFetchRequests = 2, WebSearchRequests = 0 };

        ServerToolUsage copied = new(model);

        Assert.Equal(model, copied);
    }
}
