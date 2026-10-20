using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.TelemetryDestinations;

namespace Anthropic.Tests.Models.Beta.Organization.TelemetryDestinations;

public class BetaTelemetryDestinationTestResultTest : TestBase
{
    [Fact]
    public void SuccessValidationWorks()
    {
        BetaTelemetryDestinationTestResult value = new BetaTelemetryDestinationTestSuccess();
        value.Validate();
    }

    [Fact]
    public void FailureValidationWorks()
    {
        BetaTelemetryDestinationTestResult value = new BetaTelemetryDestinationTestFailure(
            "HTTP error (status 403)"
        );
        value.Validate();
    }

    [Fact]
    public void SuccessSerializationRoundtripWorks()
    {
        BetaTelemetryDestinationTestResult value = new BetaTelemetryDestinationTestSuccess();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTelemetryDestinationTestResult>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FailureSerializationRoundtripWorks()
    {
        BetaTelemetryDestinationTestResult value = new BetaTelemetryDestinationTestFailure(
            "HTTP error (status 403)"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTelemetryDestinationTestResult>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaTelemetryDestinationTestResult value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "success"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        JsonElement expectedType = JsonSerializer.SerializeToElement("success");

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        BetaTelemetryDestinationTestResult emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}
