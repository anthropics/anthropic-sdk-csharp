using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsCommitCheckoutTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsCommitCheckout { Sha = "xxxxxxx" };

        string expectedSha = "xxxxxxx";
        JsonElement expectedType = JsonSerializer.SerializeToElement("commit");

        Assert.Equal(expectedSha, model.Sha);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsCommitCheckout { Sha = "xxxxxxx" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsCommitCheckout>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsCommitCheckout { Sha = "xxxxxxx" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsCommitCheckout>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSha = "xxxxxxx";
        JsonElement expectedType = JsonSerializer.SerializeToElement("commit");

        Assert.Equal(expectedSha, deserialized.Sha);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsCommitCheckout { Sha = "xxxxxxx" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsCommitCheckout { Sha = "xxxxxxx" };

        BetaManagedAgentsCommitCheckout copied = new(model);

        Assert.Equal(model, copied);
    }
}
