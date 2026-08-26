using System.Text.Json;
using Anthropic.Core;
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
            Type = "type",
            Value = 0,
        };

        long expectedOrgLimit = 0;
        string expectedType = "type";
        long expectedValue = 0;

        Assert.Equal(expectedOrgLimit, model.OrgLimit);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaWorkspaceRateLimitValue
        {
            OrgLimit = 0,
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
        string expectedType = "type";
        long expectedValue = 0;

        Assert.Equal(expectedOrgLimit, deserialized.OrgLimit);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaWorkspaceRateLimitValue
        {
            OrgLimit = 0,
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
            Type = "type",
            Value = 0,
        };

        BetaWorkspaceRateLimitValue copied = new(model);

        Assert.Equal(model, copied);
    }
}
