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
    public void AwsRoleTypeWorks()
    {
        BetaManagedAgentsExecutionIdentity value = new BetaManagedAgentsAwsRoleExecutionIdentity(
            "role_arn"
        );
        Assert.Equal(BetaManagedAgentsExecutionIdentityType.AwsRole, value.Type.Value());
    }

    [Fact]
    public void ServiceAccountTypeWorks()
    {
        BetaManagedAgentsExecutionIdentity value =
            new BetaManagedAgentsServiceAccountExecutionIdentity();
        Assert.Equal(BetaManagedAgentsExecutionIdentityType.ServiceAccount, value.Type.Value());
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

        ApiEnum<string, BetaManagedAgentsExecutionIdentityType> expectedType =
            BetaManagedAgentsExecutionIdentityType.AwsRole;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsExecutionIdentity emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsExecutionIdentityTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsExecutionIdentityType.AwsRole)]
    [InlineData(BetaManagedAgentsExecutionIdentityType.ServiceAccount)]
    public void Validation_Works(BetaManagedAgentsExecutionIdentityType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsExecutionIdentityType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsExecutionIdentityType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsExecutionIdentityType.AwsRole)]
    [InlineData(BetaManagedAgentsExecutionIdentityType.ServiceAccount)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsExecutionIdentityType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsExecutionIdentityType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsExecutionIdentityType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsExecutionIdentityType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsExecutionIdentityType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
