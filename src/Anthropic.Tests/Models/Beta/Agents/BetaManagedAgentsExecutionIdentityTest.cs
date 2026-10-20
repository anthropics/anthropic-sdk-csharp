using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsExecutionIdentityTest : TestBase
{
    [Fact]
    public void AwsRoleValidationWorks()
    {
        BetaManagedAgentsExecutionIdentity value = new BetaManagedAgentsAwsRoleExecutionIdentity(
            "role_arn"
        );
        value.Validate();
    }

    [Fact]
    public void ServiceAccountValidationWorks()
    {
        BetaManagedAgentsExecutionIdentity value =
            new BetaManagedAgentsServiceAccountExecutionIdentity();
        value.Validate();
    }

    [Fact]
    public void AwsRoleSerializationRoundtripWorks()
    {
        BetaManagedAgentsExecutionIdentity value = new BetaManagedAgentsAwsRoleExecutionIdentity(
            "role_arn"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsExecutionIdentity>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ServiceAccountSerializationRoundtripWorks()
    {
        BetaManagedAgentsExecutionIdentity value =
            new BetaManagedAgentsServiceAccountExecutionIdentity();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsExecutionIdentity>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsExecutionIdentity value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "aws_role"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        JsonElement expectedType = JsonSerializer.SerializeToElement("aws_role");

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        BetaManagedAgentsExecutionIdentity emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}
