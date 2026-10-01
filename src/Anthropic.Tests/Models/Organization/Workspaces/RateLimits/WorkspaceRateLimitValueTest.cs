using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Organization.Workspaces.RateLimits;

namespace Anthropic.Tests.Models.Organization.Workspaces.RateLimits;

public class WorkspaceRateLimitValueTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkspaceRateLimitValue
        {
            OrgLimit = 0,
            Source = new WorkspaceRateLimitWorkspaceSource(),
            Type = "type",
            Value = 0,
        };

        long expectedOrgLimit = 0;
        Source expectedSource = new WorkspaceRateLimitWorkspaceSource();
        string expectedType = "type";
        long expectedValue = 0;

        Assert.Equal(expectedOrgLimit, model.OrgLimit);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WorkspaceRateLimitValue
        {
            OrgLimit = 0,
            Source = new WorkspaceRateLimitWorkspaceSource(),
            Type = "type",
            Value = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkspaceRateLimitValue>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorkspaceRateLimitValue
        {
            OrgLimit = 0,
            Source = new WorkspaceRateLimitWorkspaceSource(),
            Type = "type",
            Value = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkspaceRateLimitValue>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedOrgLimit = 0;
        Source expectedSource = new WorkspaceRateLimitWorkspaceSource();
        string expectedType = "type";
        long expectedValue = 0;

        Assert.Equal(expectedOrgLimit, deserialized.OrgLimit);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WorkspaceRateLimitValue
        {
            OrgLimit = 0,
            Source = new WorkspaceRateLimitWorkspaceSource(),
            Type = "type",
            Value = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WorkspaceRateLimitValue
        {
            OrgLimit = 0,
            Source = new WorkspaceRateLimitWorkspaceSource(),
            Type = "type",
            Value = 0,
        };

        WorkspaceRateLimitValue copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SourceTest : TestBase
{
    [Fact]
    public void WorkspaceRateLimitWorkspaceValidationWorks()
    {
        Source value = new WorkspaceRateLimitWorkspaceSource();
        value.Validate();
    }

    [Fact]
    public void WorkspaceRateLimitOrganizationValidationWorks()
    {
        Source value = new WorkspaceRateLimitOrganizationSource();
        value.Validate();
    }

    [Fact]
    public void WorkspaceRateLimitWorkspaceSerializationRoundtripWorks()
    {
        Source value = new WorkspaceRateLimitWorkspaceSource();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Source>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WorkspaceRateLimitOrganizationSerializationRoundtripWorks()
    {
        Source value = new WorkspaceRateLimitOrganizationSource();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Source>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Source value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "workspace"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        JsonElement expectedType = JsonSerializer.SerializeToElement("workspace");

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        Source emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}
