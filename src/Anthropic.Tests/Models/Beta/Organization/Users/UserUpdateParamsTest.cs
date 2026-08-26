using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Users;

namespace Anthropic.Tests.Models.Beta.Organization.Users;

public class UserUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserUpdateParams { UserID = "user_id", Role = Role.User };

        string expectedUserID = "user_id";
        ApiEnum<string, Role> expectedRole = Role.User;

        Assert.Equal(expectedUserID, parameters.UserID);
        Assert.Equal(expectedRole, parameters.Role);
    }

    [Fact]
    public void Url_Works()
    {
        UserUpdateParams parameters = new() { UserID = "user_id", Role = Role.User };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.anthropic.com/v1/organizations/users/user_id?beta=true"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserUpdateParams { UserID = "user_id", Role = Role.User };

        UserUpdateParams copied = new(parameters);

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
