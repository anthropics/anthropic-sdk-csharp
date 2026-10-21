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
    public void AwsRoleTypeWorks()
    {
        BetaManagedAgentsExecutionIdentityParams value =
            new BetaManagedAgentsAwsRoleExecutionIdentityParams("role_arn");
        Assert.Equal(BetaManagedAgentsExecutionIdentityParamsType.AwsRole, value.Type.Value());
    }

    [Fact]
    public void ServiceAccountTypeWorks()
    {
        BetaManagedAgentsExecutionIdentityParams value =
            new BetaManagedAgentsServiceAccountExecutionIdentityParams();
        Assert.Equal(
            BetaManagedAgentsExecutionIdentityParamsType.ServiceAccount,
            value.Type.Value()
        );
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

        ApiEnum<string, BetaManagedAgentsExecutionIdentityParamsType> expectedType =
            BetaManagedAgentsExecutionIdentityParamsType.AwsRole;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsExecutionIdentityParams emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsExecutionIdentityParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsExecutionIdentityParamsType.AwsRole)]
    [InlineData(BetaManagedAgentsExecutionIdentityParamsType.ServiceAccount)]
    public void Validation_Works(BetaManagedAgentsExecutionIdentityParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsExecutionIdentityParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsExecutionIdentityParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsExecutionIdentityParamsType.AwsRole)]
    [InlineData(BetaManagedAgentsExecutionIdentityParamsType.ServiceAccount)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsExecutionIdentityParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsExecutionIdentityParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsExecutionIdentityParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsExecutionIdentityParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsExecutionIdentityParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
