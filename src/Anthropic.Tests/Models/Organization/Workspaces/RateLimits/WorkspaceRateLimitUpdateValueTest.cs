using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.Workspaces.RateLimits;

namespace Anthropic.Tests.Models.Organization.Workspaces.RateLimits;

public class WorkspaceRateLimitUpdateValueTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkspaceRateLimitUpdateValue
        {
            Type = WorkspaceRateLimitType.FastItpmca,
            Value = 0,
        };

        ApiEnum<string, WorkspaceRateLimitType> expectedType = WorkspaceRateLimitType.FastItpmca;
        long expectedValue = 0;

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WorkspaceRateLimitUpdateValue
        {
            Type = WorkspaceRateLimitType.FastItpmca,
            Value = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkspaceRateLimitUpdateValue>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorkspaceRateLimitUpdateValue
        {
            Type = WorkspaceRateLimitType.FastItpmca,
            Value = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkspaceRateLimitUpdateValue>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, WorkspaceRateLimitType> expectedType = WorkspaceRateLimitType.FastItpmca;
        long expectedValue = 0;

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WorkspaceRateLimitUpdateValue
        {
            Type = WorkspaceRateLimitType.FastItpmca,
            Value = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WorkspaceRateLimitUpdateValue
        {
            Type = WorkspaceRateLimitType.FastItpmca,
            Value = 0,
        };

        WorkspaceRateLimitUpdateValue copied = new(model);

        Assert.Equal(model, copied);
    }
}
