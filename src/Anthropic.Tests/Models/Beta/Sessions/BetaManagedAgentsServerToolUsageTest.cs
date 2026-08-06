using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsServerToolUsageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsServerToolUsage
        {
            WebFetchRequests = 0,
            WebSearchRequests = 3,
        };

        int expectedWebFetchRequests = 0;
        int expectedWebSearchRequests = 3;

        Assert.Equal(expectedWebFetchRequests, model.WebFetchRequests);
        Assert.Equal(expectedWebSearchRequests, model.WebSearchRequests);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsServerToolUsage
        {
            WebFetchRequests = 0,
            WebSearchRequests = 3,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsServerToolUsage>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsServerToolUsage
        {
            WebFetchRequests = 0,
            WebSearchRequests = 3,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsServerToolUsage>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        int expectedWebFetchRequests = 0;
        int expectedWebSearchRequests = 3;

        Assert.Equal(expectedWebFetchRequests, deserialized.WebFetchRequests);
        Assert.Equal(expectedWebSearchRequests, deserialized.WebSearchRequests);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsServerToolUsage
        {
            WebFetchRequests = 0,
            WebSearchRequests = 3,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsServerToolUsage { };

        Assert.Null(model.WebFetchRequests);
        Assert.False(model.RawData.ContainsKey("web_fetch_requests"));
        Assert.Null(model.WebSearchRequests);
        Assert.False(model.RawData.ContainsKey("web_search_requests"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsServerToolUsage { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsServerToolUsage
        {
            // Null should be interpreted as omitted for these properties
            WebFetchRequests = null,
            WebSearchRequests = null,
        };

        Assert.Null(model.WebFetchRequests);
        Assert.False(model.RawData.ContainsKey("web_fetch_requests"));
        Assert.Null(model.WebSearchRequests);
        Assert.False(model.RawData.ContainsKey("web_search_requests"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsServerToolUsage
        {
            // Null should be interpreted as omitted for these properties
            WebFetchRequests = null,
            WebSearchRequests = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsServerToolUsage
        {
            WebFetchRequests = 0,
            WebSearchRequests = 3,
        };

        BetaManagedAgentsServerToolUsage copied = new(model);

        Assert.Equal(model, copied);
    }
}
