using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsExecutionIdentityParamsTest : TestBase
{
    [Fact]
    public void AwsRoleValidationWorks()
    {
        BetaManagedAgentsExecutionIdentityParams value =
            new BetaManagedAgentsAwsRoleExecutionIdentityParams("role_arn");
        value.Validate();
    }

    [Fact]
    public void ServiceAccountValidationWorks()
    {
        BetaManagedAgentsExecutionIdentityParams value =
            new BetaManagedAgentsServiceAccountExecutionIdentityParams();
        value.Validate();
    }

    [Fact]
    public void AwsRoleSerializationRoundtripWorks()
    {
        BetaManagedAgentsExecutionIdentityParams value =
            new BetaManagedAgentsAwsRoleExecutionIdentityParams("role_arn");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsExecutionIdentityParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ServiceAccountSerializationRoundtripWorks()
    {
        BetaManagedAgentsExecutionIdentityParams value =
            new BetaManagedAgentsServiceAccountExecutionIdentityParams();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsExecutionIdentityParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsExecutionIdentityParams value = new(
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

        BetaManagedAgentsExecutionIdentityParams emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}
