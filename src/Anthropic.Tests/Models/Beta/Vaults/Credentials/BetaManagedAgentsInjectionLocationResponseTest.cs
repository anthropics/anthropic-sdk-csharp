using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsInjectionLocationResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsInjectionLocationResponse { Body = true, Header = true };

        bool expectedBody = true;
        bool expectedHeader = true;

        Assert.Equal(expectedBody, model.Body);
        Assert.Equal(expectedHeader, model.Header);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsInjectionLocationResponse { Body = true, Header = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsInjectionLocationResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsInjectionLocationResponse { Body = true, Header = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsInjectionLocationResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedBody = true;
        bool expectedHeader = true;

        Assert.Equal(expectedBody, deserialized.Body);
        Assert.Equal(expectedHeader, deserialized.Header);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsInjectionLocationResponse { Body = true, Header = true };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsInjectionLocationResponse { Body = true, Header = true };

        BetaManagedAgentsInjectionLocationResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
