using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Vaults;

namespace Anthropic.Tests.Models.Beta.Vaults;

public class BetaManagedAgentsDeletedVaultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDeletedVault { ID = "vlt_011CZkZDLs7fYzm1hXNPeRjv" };

        string expectedID = "vlt_011CZkZDLs7fYzm1hXNPeRjv";
        JsonElement expectedType = JsonSerializer.SerializeToElement("vault_deleted");

        Assert.Equal(expectedID, model.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDeletedVault { ID = "vlt_011CZkZDLs7fYzm1hXNPeRjv" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeletedVault>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsDeletedVault { ID = "vlt_011CZkZDLs7fYzm1hXNPeRjv" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeletedVault>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "vlt_011CZkZDLs7fYzm1hXNPeRjv";
        JsonElement expectedType = JsonSerializer.SerializeToElement("vault_deleted");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsDeletedVault { ID = "vlt_011CZkZDLs7fYzm1hXNPeRjv" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsDeletedVault { ID = "vlt_011CZkZDLs7fYzm1hXNPeRjv" };

        BetaManagedAgentsDeletedVault copied = new(model);

        Assert.Equal(model, copied);
    }
}
