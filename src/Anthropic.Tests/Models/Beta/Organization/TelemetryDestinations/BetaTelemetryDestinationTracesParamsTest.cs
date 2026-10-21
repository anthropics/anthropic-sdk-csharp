using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.TelemetryDestinations;

namespace Anthropic.Tests.Models.Beta.Organization.TelemetryDestinations;

public class BetaTelemetryDestinationTracesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaTelemetryDestinationTracesParams
        {
            ContentMode = BetaTelemetryDestinationContentMode.MetadataOnly,
            Enabled = true,
            EndpointUrl = "endpoint_url",
            MaxContentBytes = 0,
        };

        ApiEnum<string, BetaTelemetryDestinationContentMode> expectedContentMode =
            BetaTelemetryDestinationContentMode.MetadataOnly;
        bool expectedEnabled = true;
        string expectedEndpointUrl = "endpoint_url";
        int expectedMaxContentBytes = 0;

        Assert.Equal(expectedContentMode, model.ContentMode);
        Assert.Equal(expectedEnabled, model.Enabled);
        Assert.Equal(expectedEndpointUrl, model.EndpointUrl);
        Assert.Equal(expectedMaxContentBytes, model.MaxContentBytes);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaTelemetryDestinationTracesParams
        {
            ContentMode = BetaTelemetryDestinationContentMode.MetadataOnly,
            Enabled = true,
            EndpointUrl = "endpoint_url",
            MaxContentBytes = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTelemetryDestinationTracesParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaTelemetryDestinationTracesParams
        {
            ContentMode = BetaTelemetryDestinationContentMode.MetadataOnly,
            Enabled = true,
            EndpointUrl = "endpoint_url",
            MaxContentBytes = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTelemetryDestinationTracesParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaTelemetryDestinationContentMode> expectedContentMode =
            BetaTelemetryDestinationContentMode.MetadataOnly;
        bool expectedEnabled = true;
        string expectedEndpointUrl = "endpoint_url";
        int expectedMaxContentBytes = 0;

        Assert.Equal(expectedContentMode, deserialized.ContentMode);
        Assert.Equal(expectedEnabled, deserialized.Enabled);
        Assert.Equal(expectedEndpointUrl, deserialized.EndpointUrl);
        Assert.Equal(expectedMaxContentBytes, deserialized.MaxContentBytes);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaTelemetryDestinationTracesParams
        {
            ContentMode = BetaTelemetryDestinationContentMode.MetadataOnly,
            Enabled = true,
            EndpointUrl = "endpoint_url",
            MaxContentBytes = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaTelemetryDestinationTracesParams
        {
            ContentMode = BetaTelemetryDestinationContentMode.MetadataOnly,
            EndpointUrl = "endpoint_url",
            MaxContentBytes = 0,
        };

        Assert.Null(model.Enabled);
        Assert.False(model.RawData.ContainsKey("enabled"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaTelemetryDestinationTracesParams
        {
            ContentMode = BetaTelemetryDestinationContentMode.MetadataOnly,
            EndpointUrl = "endpoint_url",
            MaxContentBytes = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaTelemetryDestinationTracesParams
        {
            ContentMode = BetaTelemetryDestinationContentMode.MetadataOnly,
            EndpointUrl = "endpoint_url",
            MaxContentBytes = 0,

            // Null should be interpreted as omitted for these properties
            Enabled = null,
        };

        Assert.Null(model.Enabled);
        Assert.False(model.RawData.ContainsKey("enabled"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullInWithAreUnset_Works()
    {
        var model = new BetaTelemetryDestinationTracesParams
        {
            ContentMode = BetaTelemetryDestinationContentMode.MetadataOnly,
            Enabled = true,
            EndpointUrl = "endpoint_url",
            MaxContentBytes = 0,
        } with
        {
            // Null should be interpreted as omitted for these properties
            Enabled = null,
        };

        Assert.Null(model.Enabled);
        Assert.False(model.RawData.ContainsKey("enabled"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaTelemetryDestinationTracesParams
        {
            ContentMode = BetaTelemetryDestinationContentMode.MetadataOnly,
            EndpointUrl = "endpoint_url",
            MaxContentBytes = 0,

            // Null should be interpreted as omitted for these properties
            Enabled = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaTelemetryDestinationTracesParams { Enabled = true };

        Assert.Null(model.ContentMode);
        Assert.False(model.RawData.ContainsKey("content_mode"));
        Assert.Null(model.EndpointUrl);
        Assert.False(model.RawData.ContainsKey("endpoint_url"));
        Assert.Null(model.MaxContentBytes);
        Assert.False(model.RawData.ContainsKey("max_content_bytes"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaTelemetryDestinationTracesParams { Enabled = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaTelemetryDestinationTracesParams
        {
            Enabled = true,

            ContentMode = null,
            EndpointUrl = null,
            MaxContentBytes = null,
        };

        Assert.Null(model.ContentMode);
        Assert.True(model.RawData.ContainsKey("content_mode"));
        Assert.Null(model.EndpointUrl);
        Assert.True(model.RawData.ContainsKey("endpoint_url"));
        Assert.Null(model.MaxContentBytes);
        Assert.True(model.RawData.ContainsKey("max_content_bytes"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaTelemetryDestinationTracesParams
        {
            Enabled = true,

            ContentMode = null,
            EndpointUrl = null,
            MaxContentBytes = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaTelemetryDestinationTracesParams
        {
            ContentMode = BetaTelemetryDestinationContentMode.MetadataOnly,
            Enabled = true,
            EndpointUrl = "endpoint_url",
            MaxContentBytes = 0,
        };

        BetaTelemetryDestinationTracesParams copied = new(model);

        Assert.Equal(model, copied);
    }
}
