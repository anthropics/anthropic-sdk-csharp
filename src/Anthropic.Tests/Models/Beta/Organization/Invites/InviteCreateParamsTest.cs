using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Invites;

namespace Anthropic.Tests.Models.Beta.Organization.Invites;

public class InviteCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InviteCreateParams
        {
            Email = "user@emaildomain.com",
            Role = Role.User,
            RbacGroupIds = ["string"],
        };

        string expectedEmail = "user@emaildomain.com";
        ApiEnum<string, Role> expectedRole = Role.User;
        List<string> expectedRbacGroupIds = ["string"];

        Assert.Equal(expectedEmail, parameters.Email);
        Assert.Equal(expectedRole, parameters.Role);
        Assert.NotNull(parameters.RbacGroupIds);
        Assert.Equal(expectedRbacGroupIds.Count, parameters.RbacGroupIds.Count);
        for (int i = 0; i < expectedRbacGroupIds.Count; i++)
        {
            Assert.Equal(expectedRbacGroupIds[i], parameters.RbacGroupIds[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InviteCreateParams
        {
            Email = "user@emaildomain.com",
            Role = Role.User,
        };

        Assert.Null(parameters.RbacGroupIds);
        Assert.False(parameters.RawBodyData.ContainsKey("rbac_group_ids"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new InviteCreateParams
        {
            Email = "user@emaildomain.com",
            Role = Role.User,

            // Null should be interpreted as omitted for these properties
            RbacGroupIds = null,
        };

        Assert.Null(parameters.RbacGroupIds);
        Assert.False(parameters.RawBodyData.ContainsKey("rbac_group_ids"));
    }

    [Fact]
    public void Url_Works()
    {
        InviteCreateParams parameters = new() { Email = "user@emaildomain.com", Role = Role.User };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.anthropic.com/v1/organizations/invites?beta=true"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InviteCreateParams
        {
            Email = "user@emaildomain.com",
            Role = Role.User,
            RbacGroupIds = ["string"],
        };

        InviteCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class RoleTest : TestBase
{
    [Theory]
    [InlineData(Role.Billing)]
    [InlineData(Role.ClaudeCodeUser)]
    [InlineData(Role.Developer)]
    [InlineData(Role.Managed)]
    [InlineData(Role.User)]
    public void Validation_Works(Role rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Role> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Role.Billing)]
    [InlineData(Role.ClaudeCodeUser)]
    [InlineData(Role.Developer)]
    [InlineData(Role.Managed)]
    [InlineData(Role.User)]
    public void SerializationRoundtrip_Works(Role rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Role> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
