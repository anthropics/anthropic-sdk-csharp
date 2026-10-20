using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Workspaces.RateLimits;

namespace Anthropic.Tests.Models.Beta.Organization.Workspaces.RateLimits;

public class BetaWorkspaceRateLimitUpdateValueTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaWorkspaceRateLimitUpdateValue
        {
            Type = BetaWorkspaceRateLimitType.FastItpmca,
            Value = 0,
        };

        ApiEnum<string, BetaWorkspaceRateLimitType> expectedType =
            BetaWorkspaceRateLimitType.FastItpmca;
        long expectedValue = 0;

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaWorkspaceRateLimitUpdateValue
        {
            Type = BetaWorkspaceRateLimitType.FastItpmca,
            Value = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWorkspaceRateLimitUpdateValue>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaWorkspaceRateLimitUpdateValue
        {
            Type = BetaWorkspaceRateLimitType.FastItpmca,
            Value = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWorkspaceRateLimitUpdateValue>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaWorkspaceRateLimitType> expectedType =
            BetaWorkspaceRateLimitType.FastItpmca;
        long expectedValue = 0;

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaWorkspaceRateLimitUpdateValue
        {
            Type = BetaWorkspaceRateLimitType.FastItpmca,
            Value = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaWorkspaceRateLimitUpdateValue
        {
            Type = BetaWorkspaceRateLimitType.FastItpmca,
            Value = 0,
        };

        BetaWorkspaceRateLimitUpdateValue copied = new(model);

        Assert.Equal(model, copied);
    }
}
