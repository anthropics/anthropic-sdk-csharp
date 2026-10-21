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
    public void WorkspaceRateLimitWorkspaceTypeWorks()
    {
        Source value = new WorkspaceRateLimitWorkspaceSource();
        Assert.Equal(SourceType.Workspace, value.Type.Value());
    }

    [Fact]
    public void WorkspaceRateLimitOrganizationTypeWorks()
    {
        Source value = new WorkspaceRateLimitOrganizationSource();
        Assert.Equal(SourceType.Organization, value.Type.Value());
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

        ApiEnum<string, SourceType> expectedType = SourceType.Workspace;

        Assert.Equal(expectedType, value.Type);

        Source emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class SourceTypeTest : TestBase
{
    [Theory]
    [InlineData(SourceType.Workspace)]
    [InlineData(SourceType.Organization)]
    public void Validation_Works(SourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SourceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SourceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SourceType.Workspace)]
    [InlineData(SourceType.Organization)]
    public void SerializationRoundtrip_Works(SourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SourceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SourceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SourceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SourceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
