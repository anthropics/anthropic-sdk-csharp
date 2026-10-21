using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsStaticBearerUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsStaticBearerUpdateParams { Token = "x" };

        JsonElement expectedType = JsonSerializer.SerializeToElement("static_bearer");
        string expectedToken = "x";

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedToken, model.Token);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsStaticBearerUpdateParams { Token = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStaticBearerUpdateParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsStaticBearerUpdateParams { Token = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsStaticBearerUpdateParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("static_bearer");
        string expectedToken = "x";

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedToken, deserialized.Token);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsStaticBearerUpdateParams { Token = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsStaticBearerUpdateParams { };

        Assert.Null(model.Token);
        Assert.False(model.RawData.ContainsKey("token"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsStaticBearerUpdateParams { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsStaticBearerUpdateParams { Token = null };

        Assert.Null(model.Token);
        Assert.True(model.RawData.ContainsKey("token"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsStaticBearerUpdateParams { Token = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsStaticBearerUpdateParams { Token = "x" };

        BetaManagedAgentsStaticBearerUpdateParams copied = new(model);

        Assert.Equal(model, copied);
    }
}
