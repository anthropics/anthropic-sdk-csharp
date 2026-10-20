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

        JsonElement expectedType = JsonSerializer.SerializeToElement("all");

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        BetaTelemetryDestinationWorkspaces emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}
