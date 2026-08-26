using System;
using System.Collections.Generic;
using Anthropic.Models.Beta.Organization.Users;

namespace Anthropic.Tests.Models.Beta.Organization.Users;

public class UserListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserListParams
        {
            AfterID = "after_id",
            BeforeID = "before_id",
            Email = "dev@stainless.com",
            Limit = 1,
            Roles = ["string"],
        };

        string expectedAfterID = "after_id";
        string expectedBeforeID = "before_id";
        string expectedEmail = "dev@stainless.com";
        long expectedLimit = 1;
        List<string> expectedRoles = ["string"];

        Assert.Equal(expectedAfterID, parameters.AfterID);
        Assert.Equal(expectedBeforeID, parameters.BeforeID);
        Assert.Equal(expectedEmail, parameters.Email);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.NotNull(parameters.Roles);
        Assert.Equal(expectedRoles.Count, parameters.Roles.Count);
        for (int i = 0; i < expectedRoles.Count; i++)
        {
            Assert.Equal(expectedRoles[i], parameters.Roles[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new UserListParams { };

        Assert.Null(parameters.AfterID);
        Assert.False(parameters.RawQueryData.ContainsKey("after_id"));
        Assert.Null(parameters.BeforeID);
        Assert.False(parameters.RawQueryData.ContainsKey("before_id"));
        Assert.Null(parameters.Email);
        Assert.False(parameters.RawQueryData.ContainsKey("email"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Roles);
        Assert.False(parameters.RawQueryData.ContainsKey("roles"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new UserListParams
        {
            // Null should be interpreted as omitted for these properties
            AfterID = null,
            BeforeID = null,
            Email = null,
            Limit = null,
            Roles = null,
        };

        Assert.Null(parameters.AfterID);
        Assert.False(parameters.RawQueryData.ContainsKey("after_id"));
        Assert.Null(parameters.BeforeID);
        Assert.False(parameters.RawQueryData.ContainsKey("before_id"));
        Assert.Null(parameters.Email);
        Assert.False(parameters.RawQueryData.ContainsKey("email"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Roles);
        Assert.False(parameters.RawQueryData.ContainsKey("roles"));
    }

    [Fact]
    public void Url_Works()
    {
        UserListParams parameters = new()
        {
            AfterID = "after_id",
            BeforeID = "before_id",
            Email = "dev@stainless.com",
            Limit = 1,
            Roles = ["string"],
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/users?beta=true&after_id=after_id&before_id=before_id&email=dev%40stainless.com&limit=1&roles%5b%5d=string"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new UserListParams
        {
            AfterID = "after_id",
            BeforeID = "before_id",
            Email = "dev@stainless.com",
            Limit = 1,
            Roles = ["string"],
        };

        UserListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
