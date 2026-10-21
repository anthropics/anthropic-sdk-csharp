using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsDeletedCredentialTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDeletedCredential { ID = "vcrd_011CZkZEMt8gZan2iYPQfSkw" };

        string expectedID = "vcrd_011CZkZEMt8gZan2iYPQfSkw";
        JsonElement expectedType = JsonSerializer.SerializeToElement("vault_credential_deleted");

        Assert.Equal(expectedID, model.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDeletedCredential { ID = "vcrd_011CZkZEMt8gZan2iYPQfSkw" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeletedCredential>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsDeletedCredential { ID = "vcrd_011CZkZEMt8gZan2iYPQfSkw" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeletedCredential>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "vcrd_011CZkZEMt8gZan2iYPQfSkw";
        JsonElement expectedType = JsonSerializer.SerializeToElement("vault_credential_deleted");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsDeletedCredential { ID = "vcrd_011CZkZEMt8gZan2iYPQfSkw" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsDeletedCredential { ID = "vcrd_011CZkZEMt8gZan2iYPQfSkw" };

        BetaManagedAgentsDeletedCredential copied = new(model);

        Assert.Equal(model, copied);
    }
}
