using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsDeletedSessionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDeletedSession { ID = "sesn_011CZkZAtmR3yMPDzynEDxu7" };

        string expectedID = "sesn_011CZkZAtmR3yMPDzynEDxu7";
        JsonElement expectedType = JsonSerializer.SerializeToElement("session_deleted");

        Assert.Equal(expectedID, model.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDeletedSession { ID = "sesn_011CZkZAtmR3yMPDzynEDxu7" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeletedSession>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsDeletedSession { ID = "sesn_011CZkZAtmR3yMPDzynEDxu7" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeletedSession>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "sesn_011CZkZAtmR3yMPDzynEDxu7";
        JsonElement expectedType = JsonSerializer.SerializeToElement("session_deleted");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsDeletedSession { ID = "sesn_011CZkZAtmR3yMPDzynEDxu7" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsDeletedSession { ID = "sesn_011CZkZAtmR3yMPDzynEDxu7" };

        BetaManagedAgentsDeletedSession copied = new(model);

        Assert.Equal(model, copied);
    }
}
