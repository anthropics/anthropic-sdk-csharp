using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.TelemetryDestinations;

namespace Anthropic.Tests.Models.Beta.Organization.TelemetryDestinations;

public class BetaTelemetryDestinationWorkspacesParamsTest : TestBase
{
    [Fact]
    public void AllValidationWorks()
    {
        BetaTelemetryDestinationWorkspacesParams value =
            new BetaTelemetryDestinationWorkspacesAllParams();
        value.Validate();
    }

    [Fact]
    public void IncludeValidationWorks()
    {
        BetaTelemetryDestinationWorkspacesParams value =
            new BetaTelemetryDestinationWorkspacesIncludeParams() { WorkspaceIds = ["string"] };
        value.Validate();
    }

    [Fact]
    public void ExcludeValidationWorks()
    {
        BetaTelemetryDestinationWorkspacesParams value =
            new BetaTelemetryDestinationWorkspacesExcludeParams() { WorkspaceIds = ["string"] };
        value.Validate();
    }

    [Fact]
    public void AllSerializationRoundtripWorks()
    {
        BetaTelemetryDestinationWorkspacesParams value =
            new BetaTelemetryDestinationWorkspacesAllParams();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTelemetryDestinationWorkspacesParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void IncludeSerializationRoundtripWorks()
    {
        BetaTelemetryDestinationWorkspacesParams value =
            new BetaTelemetryDestinationWorkspacesIncludeParams() { WorkspaceIds = ["string"] };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTelemetryDestinationWorkspacesParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ExcludeSerializationRoundtripWorks()
    {
        BetaTelemetryDestinationWorkspacesParams value =
            new BetaTelemetryDestinationWorkspacesExcludeParams() { WorkspaceIds = ["string"] };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaTelemetryDestinationWorkspacesParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaTelemetryDestinationWorkspacesParams value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "all",
                  "workspace_ids": [
                    "string"
                  ]
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        JsonElement expectedType = JsonSerializer.SerializeToElement("all");
        List<string> expectedWorkspaceIds = ["string"];

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));
        Assert.NotNull(value.WorkspaceIds);
        Assert.Equal(expectedWorkspaceIds.Count, value.WorkspaceIds.Count);
        for (int i = 0; i < expectedWorkspaceIds.Count; i++)
        {
            Assert.Equal(expectedWorkspaceIds[i], value.WorkspaceIds[i]);
        }

        BetaTelemetryDestinationWorkspacesParams emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.WorkspaceIds);
    }
}
