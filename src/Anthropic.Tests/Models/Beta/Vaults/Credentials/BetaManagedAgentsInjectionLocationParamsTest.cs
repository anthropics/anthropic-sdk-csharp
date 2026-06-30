using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsInjectionLocationParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsInjectionLocationParams { Body = true, Header = true };

        bool expectedBody = true;
        bool expectedHeader = true;

        Assert.Equal(expectedBody, model.Body);
        Assert.Equal(expectedHeader, model.Header);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsInjectionLocationParams { Body = true, Header = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsInjectionLocationParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsInjectionLocationParams { Body = true, Header = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsInjectionLocationParams>(
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
        var model = new BetaManagedAgentsInjectionLocationParams { Body = true, Header = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsInjectionLocationParams { };

        Assert.Null(model.Body);
        Assert.False(model.RawData.ContainsKey("body"));
        Assert.Null(model.Header);
        Assert.False(model.RawData.ContainsKey("header"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsInjectionLocationParams { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsInjectionLocationParams
        {
            // Null should be interpreted as omitted for these properties
            Body = null,
            Header = null,
        };

        Assert.Null(model.Body);
        Assert.False(model.RawData.ContainsKey("body"));
        Assert.Null(model.Header);
        Assert.False(model.RawData.ContainsKey("header"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsInjectionLocationParams
        {
            // Null should be interpreted as omitted for these properties
            Body = null,
            Header = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsInjectionLocationParams { Body = true, Header = true };

        BetaManagedAgentsInjectionLocationParams copied = new(model);

        Assert.Equal(model, copied);
    }
}
