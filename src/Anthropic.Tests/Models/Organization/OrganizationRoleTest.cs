using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Organization;

namespace Anthropic.Tests.Models.Organization;

public class OrganizationRoleTest : TestBase
{
    [Theory]
    [InlineData(OrganizationRole.Admin)]
    [InlineData(OrganizationRole.Billing)]
    [InlineData(OrganizationRole.ClaudeCodeUser)]
    [InlineData(OrganizationRole.Developer)]
    [InlineData(OrganizationRole.Managed)]
    [InlineData(OrganizationRole.MembershipAdmin)]
    [InlineData(OrganizationRole.Owner)]
    [InlineData(OrganizationRole.PrimaryOwner)]
    [InlineData(OrganizationRole.User)]
    public void Validation_Works(OrganizationRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OrganizationRole> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OrganizationRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(OrganizationRole.Admin)]
    [InlineData(OrganizationRole.Billing)]
    [InlineData(OrganizationRole.ClaudeCodeUser)]
    [InlineData(OrganizationRole.Developer)]
    [InlineData(OrganizationRole.Managed)]
    [InlineData(OrganizationRole.MembershipAdmin)]
    [InlineData(OrganizationRole.Owner)]
    [InlineData(OrganizationRole.PrimaryOwner)]
    [InlineData(OrganizationRole.User)]
    public void SerializationRoundtrip_Works(OrganizationRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OrganizationRole> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OrganizationRole>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, OrganizationRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OrganizationRole>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
