using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsTextRubricParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsTextRubricParams
        {
            Content = "Must cover all five sections; cite sources inline.",
        };

        string expectedContent = "Must cover all five sections; cite sources inline.";
        JsonElement expectedType = JsonSerializer.SerializeToElement("text");

        Assert.Equal(expectedContent, model.Content);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsTextRubricParams
        {
            Content = "Must cover all five sections; cite sources inline.",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsTextRubricParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsTextRubricParams
        {
            Content = "Must cover all five sections; cite sources inline.",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsTextRubricParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedContent = "Must cover all five sections; cite sources inline.";
        JsonElement expectedType = JsonSerializer.SerializeToElement("text");

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsTextRubricParams
        {
            Content = "Must cover all five sections; cite sources inline.",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsTextRubricParams
        {
            Content = "Must cover all five sections; cite sources inline.",
        };

        BetaManagedAgentsTextRubricParams copied = new(model);

        Assert.Equal(model, copied);
    }
}
