using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization;

namespace Anthropic.Tests.Models.Beta.Organization;

public class BetaOrganizationRoleTest : TestBase
{
    [Theory]
    [InlineData(BetaOrganizationRole.Admin)]
    [InlineData(BetaOrganizationRole.Billing)]
    [InlineData(BetaOrganizationRole.ClaudeCodeUser)]
    [InlineData(BetaOrganizationRole.Developer)]
    [InlineData(BetaOrganizationRole.Managed)]
    [InlineData(BetaOrganizationRole.MembershipAdmin)]
    [InlineData(BetaOrganizationRole.Owner)]
    [InlineData(BetaOrganizationRole.PrimaryOwner)]
    [InlineData(BetaOrganizationRole.User)]
    public void Validation_Works(BetaOrganizationRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaOrganizationRole> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaOrganizationRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaOrganizationRole.Admin, 0, "admin")]
    [InlineData(BetaOrganizationRole.Billing, 1, "billing")]
    [InlineData(BetaOrganizationRole.ClaudeCodeUser, 2, "claude_code_user")]
    [InlineData(BetaOrganizationRole.Developer, 3, "developer")]
    [InlineData(BetaOrganizationRole.Managed, 4, "managed")]
    [InlineData(BetaOrganizationRole.MembershipAdmin, 5, "membership_admin")]
    [InlineData(BetaOrganizationRole.Owner, 6, "owner")]
    [InlineData(BetaOrganizationRole.PrimaryOwner, 7, "primary_owner")]
    [InlineData(BetaOrganizationRole.User, 8, "user")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaOrganizationRole rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaOrganizationRole> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaOrganizationRole>>(
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
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaOrganizationRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaOrganizationRole>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
