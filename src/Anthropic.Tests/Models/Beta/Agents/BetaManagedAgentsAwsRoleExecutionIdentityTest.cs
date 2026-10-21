using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsAwsRoleExecutionIdentityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAwsRoleExecutionIdentity { RoleArn = "role_arn" };

        string expectedRoleArn = "role_arn";
        JsonElement expectedType = JsonSerializer.SerializeToElement("aws_role");

        Assert.Equal(expectedRoleArn, model.RoleArn);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAwsRoleExecutionIdentity { RoleArn = "role_arn" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAwsRoleExecutionIdentity>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsAwsRoleExecutionIdentity { RoleArn = "role_arn" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAwsRoleExecutionIdentity>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedRoleArn = "role_arn";
        JsonElement expectedType = JsonSerializer.SerializeToElement("aws_role");

        Assert.Equal(expectedRoleArn, deserialized.RoleArn);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsAwsRoleExecutionIdentity { RoleArn = "role_arn" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsAwsRoleExecutionIdentity { RoleArn = "role_arn" };

        BetaManagedAgentsAwsRoleExecutionIdentity copied = new(model);

        Assert.Equal(model, copied);
    }
}
