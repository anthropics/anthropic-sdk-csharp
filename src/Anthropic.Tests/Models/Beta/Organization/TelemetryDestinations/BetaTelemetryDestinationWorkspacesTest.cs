using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.TelemetryDestinations;

namespace Anthropic.Tests.Models.Beta.Organization.TelemetryDestinations;

public class BetaTelemetryDestinationWorkspacesTest : TestBase
{
    [Fact]
    public void AllValidationWorks()
    {
        BetaTelemetryDestinationWorkspaces value = new BetaTelemetryDestinationWorkspacesAll();
        value.Validate();
    }

    [Fact]
    public void IncludeValidationWorks()
    {
        BetaTelemetryDestinationWorkspaces value = new BetaTelemetryDestinationWorkspacesInclude();
        value.Validate();
    }

    [Fact]
    public void ExcludeValidationWorks()
    {
        BetaTelemetryDestinationWorkspaces value = new BetaTelemetryDestinationWorkspacesExclude();
        value.Validate();
    }

    [Fact]
    public void AllSerializationRoundtripWorks()
    {
        BetaTelemetryDestinationWorkspaces value = new BetaTelemetryDestinationWorkspacesAll();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTelemetryDestinationWorkspaces>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void IncludeSerializationRoundtripWorks()
    {
        BetaTelemetryDestinationWorkspaces value = new BetaTelemetryDestinationWorkspacesInclude();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTelemetryDestinationWorkspaces>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ExcludeSerializationRoundtripWorks()
    {
        BetaTelemetryDestinationWorkspaces value = new BetaTelemetryDestinationWorkspacesExclude();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTelemetryDestinationWorkspaces>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AllTypeWorks()
    {
        BetaTelemetryDestinationWorkspaces value = new BetaTelemetryDestinationWorkspacesAll();
        Assert.Equal(BetaTelemetryDestinationWorkspacesType.All, value.Type.Value());
    }

    [Fact]
    public void IncludeTypeWorks()
    {
        BetaTelemetryDestinationWorkspaces value = new BetaTelemetryDestinationWorkspacesInclude();
        Assert.Equal(BetaTelemetryDestinationWorkspacesType.Include, value.Type.Value());
    }

    [Fact]
    public void ExcludeTypeWorks()
    {
        BetaTelemetryDestinationWorkspaces value = new BetaTelemetryDestinationWorkspacesExclude();
        Assert.Equal(BetaTelemetryDestinationWorkspacesType.Exclude, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaTelemetryDestinationWorkspaces value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "all"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaTelemetryDestinationWorkspacesType> expectedType =
            BetaTelemetryDestinationWorkspacesType.All;

        Assert.Equal(expectedType, value.Type);

        BetaTelemetryDestinationWorkspaces emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaTelemetryDestinationWorkspacesTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaTelemetryDestinationWorkspacesType.All)]
    [InlineData(BetaTelemetryDestinationWorkspacesType.Include)]
    [InlineData(BetaTelemetryDestinationWorkspacesType.Exclude)]
    public void Validation_Works(BetaTelemetryDestinationWorkspacesType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaTelemetryDestinationWorkspacesType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaTelemetryDestinationWorkspacesType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaTelemetryDestinationWorkspacesType.All)]
    [InlineData(BetaTelemetryDestinationWorkspacesType.Include)]
    [InlineData(BetaTelemetryDestinationWorkspacesType.Exclude)]
    public void SerializationRoundtrip_Works(BetaTelemetryDestinationWorkspacesType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaTelemetryDestinationWorkspacesType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaTelemetryDestinationWorkspacesType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaTelemetryDestinationWorkspacesType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaTelemetryDestinationWorkspacesType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
