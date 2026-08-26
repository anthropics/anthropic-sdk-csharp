using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Invites;

namespace Anthropic.Tests.Models.Beta.Organization.Invites;

public class InviteListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InviteListParams
        {
            AfterID = "after_id",
            BeforeID = "before_id",
            Email = "dev@stainless.com",
            Limit = 1,
            Roles = ["string"],
            Statuses = [Status.Accepted],
        };

        string expectedAfterID = "after_id";
        string expectedBeforeID = "before_id";
        string expectedEmail = "dev@stainless.com";
        long expectedLimit = 1;
        List<string> expectedRoles = ["string"];
        List<ApiEnum<string, Status>> expectedStatuses = [Status.Accepted];

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
        Assert.NotNull(parameters.Statuses);
        Assert.Equal(expectedStatuses.Count, parameters.Statuses.Count);
        for (int i = 0; i < expectedStatuses.Count; i++)
        {
            Assert.Equal(expectedStatuses[i], parameters.Statuses[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InviteListParams { };

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
        Assert.Null(parameters.Statuses);
        Assert.False(parameters.RawQueryData.ContainsKey("statuses"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new InviteListParams
        {
            // Null should be interpreted as omitted for these properties
            AfterID = null,
            BeforeID = null,
            Email = null,
            Limit = null,
            Roles = null,
            Statuses = null,
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
        Assert.Null(parameters.Statuses);
        Assert.False(parameters.RawQueryData.ContainsKey("statuses"));
    }

    [Fact]
    public void Url_Works()
    {
        InviteListParams parameters = new()
        {
            AfterID = "after_id",
            BeforeID = "before_id",
            Email = "dev@stainless.com",
            Limit = 1,
            Roles = ["string"],
            Statuses = [Status.Accepted],
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/organizations/invites?beta=true&after_id=after_id&before_id=before_id&email=dev%40stainless.com&limit=1&roles%5b%5d=string&statuses%5b%5d=accepted"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InviteListParams
        {
            AfterID = "after_id",
            BeforeID = "before_id",
            Email = "dev@stainless.com",
            Limit = 1,
            Roles = ["string"],
            Statuses = [Status.Accepted],
        };

        InviteListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Accepted)]
    [InlineData(Status.Expired)]
    [InlineData(Status.Pending)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Accepted)]
    [InlineData(Status.Expired)]
    [InlineData(Status.Pending)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
