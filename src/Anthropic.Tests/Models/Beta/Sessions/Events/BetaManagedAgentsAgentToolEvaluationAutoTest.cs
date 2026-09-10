using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsAgentToolEvaluationAutoTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentToolEvaluationAuto
        {
            EvaluatedPermission = new BetaManagedAgentsAgentAutoEvaluatedPermissionAllow(),
        };

        BetaManagedAgentsAgentAutoEvaluatedPermission expectedEvaluatedPermission =
            new BetaManagedAgentsAgentAutoEvaluatedPermissionAllow();
        JsonElement expectedType = JsonSerializer.SerializeToElement("auto");

        Assert.Equal(expectedEvaluatedPermission, model.EvaluatedPermission);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentToolEvaluationAuto
        {
            EvaluatedPermission = new BetaManagedAgentsAgentAutoEvaluatedPermissionAllow(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentToolEvaluationAuto>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsAgentToolEvaluationAuto
        {
            EvaluatedPermission = new BetaManagedAgentsAgentAutoEvaluatedPermissionAllow(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentToolEvaluationAuto>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaManagedAgentsAgentAutoEvaluatedPermission expectedEvaluatedPermission =
            new BetaManagedAgentsAgentAutoEvaluatedPermissionAllow();
        JsonElement expectedType = JsonSerializer.SerializeToElement("auto");

        Assert.Equal(expectedEvaluatedPermission, deserialized.EvaluatedPermission);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsAgentToolEvaluationAuto
        {
            EvaluatedPermission = new BetaManagedAgentsAgentAutoEvaluatedPermissionAllow(),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsAgentToolEvaluationAuto
        {
            EvaluatedPermission = new BetaManagedAgentsAgentAutoEvaluatedPermissionAllow(),
        };

        BetaManagedAgentsAgentToolEvaluationAuto copied = new(model);

        Assert.Equal(model, copied);
    }
}
