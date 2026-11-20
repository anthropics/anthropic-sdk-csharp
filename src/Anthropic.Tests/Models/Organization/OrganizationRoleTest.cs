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
    [InlineData(OrganizationRole.Admin, 0, "admin")]
    [InlineData(OrganizationRole.Billing, 1, "billing")]
    [InlineData(OrganizationRole.ClaudeCodeUser, 2, "claude_code_user")]
    [InlineData(OrganizationRole.Developer, 3, "developer")]
    [InlineData(OrganizationRole.Managed, 4, "managed")]
    [InlineData(OrganizationRole.MembershipAdmin, 5, "membership_admin")]
    [InlineData(OrganizationRole.Owner, 6, "owner")]
    [InlineData(OrganizationRole.PrimaryOwner, 7, "primary_owner")]
    [InlineData(OrganizationRole.User, 8, "user")]
    public void EnumMemberSerializationRoundtrip_Works(
        OrganizationRole rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, OrganizationRole> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, OrganizationRole>>(
            apiJson,
            ModelBase.SerializerOptions
        );

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
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
