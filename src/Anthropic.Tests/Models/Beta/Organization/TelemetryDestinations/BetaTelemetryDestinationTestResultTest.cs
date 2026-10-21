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
    public void SuccessTypeWorks()
    {
        BetaTelemetryDestinationTestResult value = new BetaTelemetryDestinationTestSuccess();
        Assert.Equal(BetaTelemetryDestinationTestResultType.Success, value.Type.Value());
    }

    [Fact]
    public void FailureTypeWorks()
    {
        BetaTelemetryDestinationTestResult value = new BetaTelemetryDestinationTestFailure(
            "HTTP error (status 403)"
        );
        Assert.Equal(BetaTelemetryDestinationTestResultType.Failure, value.Type.Value());
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

        ApiEnum<string, BetaTelemetryDestinationTestResultType> expectedType =
            BetaTelemetryDestinationTestResultType.Success;

        Assert.Equal(expectedType, value.Type);

        BetaTelemetryDestinationTestResult emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaTelemetryDestinationTestResultTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaTelemetryDestinationTestResultType.Success)]
    [InlineData(BetaTelemetryDestinationTestResultType.Failure)]
    public void Validation_Works(BetaTelemetryDestinationTestResultType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaTelemetryDestinationTestResultType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaTelemetryDestinationTestResultType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaTelemetryDestinationTestResultType.Success)]
    [InlineData(BetaTelemetryDestinationTestResultType.Failure)]
    public void SerializationRoundtrip_Works(BetaTelemetryDestinationTestResultType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaTelemetryDestinationTestResultType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaTelemetryDestinationTestResultType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaTelemetryDestinationTestResultType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaTelemetryDestinationTestResultType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
