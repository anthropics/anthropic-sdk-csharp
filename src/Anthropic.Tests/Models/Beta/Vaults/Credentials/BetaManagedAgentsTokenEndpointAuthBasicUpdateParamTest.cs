using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsTokenEndpointAuthBasicUpdateParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam { ClientSecret = "x" };

        JsonElement expectedType = JsonSerializer.SerializeToElement("client_secret_basic");
        string expectedClientSecret = "x";

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedClientSecret, model.ClientSecret);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam { ClientSecret = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsTokenEndpointAuthBasicUpdateParam>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam { ClientSecret = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsTokenEndpointAuthBasicUpdateParam>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("client_secret_basic");
        string expectedClientSecret = "x";

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedClientSecret, deserialized.ClientSecret);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam { ClientSecret = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam { };

        Assert.Null(model.ClientSecret);
        Assert.False(model.RawData.ContainsKey("client_secret"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam { ClientSecret = null };

        Assert.Null(model.ClientSecret);
        Assert.True(model.RawData.ContainsKey("client_secret"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam { ClientSecret = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam { ClientSecret = "x" };

        BetaManagedAgentsTokenEndpointAuthBasicUpdateParam copied = new(model);

        Assert.Equal(model, copied);
    }
}
