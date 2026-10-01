using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Workspaces.RateLimits;

namespace Anthropic.Tests.Models.Beta.Organization.Workspaces.RateLimits;

public class BetaWorkspaceRateLimitValueTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaWorkspaceRateLimitValue
        {
            OrgLimit = 0,
            Source = new BetaWorkspaceRateLimitWorkspaceSource(),
            Type = "type",
            Value = 0,
        };

        long expectedOrgLimit = 0;
        Source expectedSource = new BetaWorkspaceRateLimitWorkspaceSource();
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
        var model = new BetaWorkspaceRateLimitValue
        {
            OrgLimit = 0,
            Source = new BetaWorkspaceRateLimitWorkspaceSource(),
            Type = "type",
            Value = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWorkspaceRateLimitValue>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaWorkspaceRateLimitValue
        {
            OrgLimit = 0,
            Source = new BetaWorkspaceRateLimitWorkspaceSource(),
            Type = "type",
            Value = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWorkspaceRateLimitValue>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedOrgLimit = 0;
        Source expectedSource = new BetaWorkspaceRateLimitWorkspaceSource();
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
        var model = new BetaWorkspaceRateLimitValue
        {
            OrgLimit = 0,
            Source = new BetaWorkspaceRateLimitWorkspaceSource(),
            Type = "type",
            Value = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaWorkspaceRateLimitValue
        {
            OrgLimit = 0,
            Source = new BetaWorkspaceRateLimitWorkspaceSource(),
            Type = "type",
            Value = 0,
        };

        BetaWorkspaceRateLimitValue copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SourceTest : TestBase
{
    [Fact]
    public void BetaWorkspaceRateLimitWorkspaceValidationWorks()
    {
        Source value = new BetaWorkspaceRateLimitWorkspaceSource();
        value.Validate();
    }

    [Fact]
    public void BetaWorkspaceRateLimitOrganizationValidationWorks()
    {
        Source value = new BetaWorkspaceRateLimitOrganizationSource();
        value.Validate();
    }

    [Fact]
    public void BetaWorkspaceRateLimitWorkspaceSerializationRoundtripWorks()
    {
        Source value = new BetaWorkspaceRateLimitWorkspaceSource();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Source>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaWorkspaceRateLimitOrganizationSerializationRoundtripWorks()
    {
        Source value = new BetaWorkspaceRateLimitOrganizationSource();
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
