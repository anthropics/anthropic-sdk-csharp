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
    [InlineData(BetaOrganizationRole.Admin)]
    [InlineData(BetaOrganizationRole.Billing)]
    [InlineData(BetaOrganizationRole.ClaudeCodeUser)]
    [InlineData(BetaOrganizationRole.Developer)]
    [InlineData(BetaOrganizationRole.Managed)]
    [InlineData(BetaOrganizationRole.MembershipAdmin)]
    [InlineData(BetaOrganizationRole.Owner)]
    [InlineData(BetaOrganizationRole.PrimaryOwner)]
    [InlineData(BetaOrganizationRole.User)]
    public void SerializationRoundtrip_Works(BetaOrganizationRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaOrganizationRole> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaOrganizationRole>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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
