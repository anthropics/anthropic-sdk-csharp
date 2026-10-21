using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Resources;

namespace Anthropic.Tests.Models.Beta.Sessions.Resources;

public class BetaManagedAgentsDeleteSessionResourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDeleteSessionResource
        {
            ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
        };

        string expectedID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht";
        JsonElement expectedType = JsonSerializer.SerializeToElement("session_resource_deleted");

        Assert.Equal(expectedID, model.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDeleteSessionResource
        {
            ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeleteSessionResource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsDeleteSessionResource
        {
            ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeleteSessionResource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht";
        JsonElement expectedType = JsonSerializer.SerializeToElement("session_resource_deleted");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsDeleteSessionResource
        {
            ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsDeleteSessionResource
        {
            ID = "sesrsc_011CZkZBJq5dWxk9fVLNcPht",
        };

        BetaManagedAgentsDeleteSessionResource copied = new(model);

        Assert.Equal(model, copied);
    }
}
