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
    public void AllTypeWorks()
    {
        BetaTelemetryDestinationWorkspacesParams value =
            new BetaTelemetryDestinationWorkspacesAllParams();
        Assert.Equal(BetaTelemetryDestinationWorkspacesParamsType.All, value.Type.Value());
    }

    [Fact]
    public void IncludeTypeWorks()
    {
        BetaTelemetryDestinationWorkspacesParams value =
            new BetaTelemetryDestinationWorkspacesIncludeParams() { WorkspaceIds = ["string"] };
        Assert.Equal(BetaTelemetryDestinationWorkspacesParamsType.Include, value.Type.Value());
    }

    [Fact]
    public void ExcludeTypeWorks()
    {
        BetaTelemetryDestinationWorkspacesParams value =
            new BetaTelemetryDestinationWorkspacesExcludeParams() { WorkspaceIds = ["string"] };
        Assert.Equal(BetaTelemetryDestinationWorkspacesParamsType.Exclude, value.Type.Value());
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

        ApiEnum<string, BetaTelemetryDestinationWorkspacesParamsType> expectedType =
            BetaTelemetryDestinationWorkspacesParamsType.All;
        List<string> expectedWorkspaceIds = ["string"];

        Assert.Equal(expectedType, value.Type);
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

public class BetaTelemetryDestinationWorkspacesParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaTelemetryDestinationWorkspacesParamsType.All)]
    [InlineData(BetaTelemetryDestinationWorkspacesParamsType.Include)]
    [InlineData(BetaTelemetryDestinationWorkspacesParamsType.Exclude)]
    public void Validation_Works(BetaTelemetryDestinationWorkspacesParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaTelemetryDestinationWorkspacesParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaTelemetryDestinationWorkspacesParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaTelemetryDestinationWorkspacesParamsType.All)]
    [InlineData(BetaTelemetryDestinationWorkspacesParamsType.Include)]
    [InlineData(BetaTelemetryDestinationWorkspacesParamsType.Exclude)]
    public void SerializationRoundtrip_Works(BetaTelemetryDestinationWorkspacesParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaTelemetryDestinationWorkspacesParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaTelemetryDestinationWorkspacesParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaTelemetryDestinationWorkspacesParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaTelemetryDestinationWorkspacesParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
