using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization;
using Anthropic.Models.Beta.Organization.Invites;

namespace Anthropic.Tests.Models.Beta.Organization.Invites;

public class BetaOrganizationInviteTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaOrganizationInvite
        {
            ID = "invite_015gWxCN9Hfg2QhZwTK7Mdeu",
            AcceptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Email = "user@emaildomain.com",
            ExpiresAt = DateTimeOffset.Parse("2024-11-20T23:58:27.427722Z"),
            InvitedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            RbacGroupIds = ["string"],
            Role = BetaOrganizationRole.Admin,
            Status = BetaOrganizationInviteStatus.Pending,
        };

        string expectedID = "invite_015gWxCN9Hfg2QhZwTK7Mdeu";
        DateTimeOffset expectedAcceptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEmail = "user@emaildomain.com";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2024-11-20T23:58:27.427722Z");
        DateTimeOffset expectedInvitedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        List<string> expectedRbacGroupIds = ["string"];
        ApiEnum<string, BetaOrganizationRole> expectedRole = BetaOrganizationRole.Admin;
        ApiEnum<string, BetaOrganizationInviteStatus> expectedStatus =
            BetaOrganizationInviteStatus.Pending;
        JsonElement expectedType = JsonSerializer.SerializeToElement("invite");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAcceptedAt, model.AcceptedAt);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedInvitedAt, model.InvitedAt);
        Assert.Equal(expectedRbacGroupIds.Count, model.RbacGroupIds.Count);
        for (int i = 0; i < expectedRbacGroupIds.Count; i++)
        {
            Assert.Equal(expectedRbacGroupIds[i], model.RbacGroupIds[i]);
        }
        Assert.Equal(expectedRole, model.Role);
        Assert.Equal(expectedStatus, model.Status);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaOrganizationInvite
        {
            ID = "invite_015gWxCN9Hfg2QhZwTK7Mdeu",
            AcceptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Email = "user@emaildomain.com",
            ExpiresAt = DateTimeOffset.Parse("2024-11-20T23:58:27.427722Z"),
            InvitedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            RbacGroupIds = ["string"],
            Role = BetaOrganizationRole.Admin,
            Status = BetaOrganizationInviteStatus.Pending,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaOrganizationInvite>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaOrganizationInvite
        {
            ID = "invite_015gWxCN9Hfg2QhZwTK7Mdeu",
            AcceptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Email = "user@emaildomain.com",
            ExpiresAt = DateTimeOffset.Parse("2024-11-20T23:58:27.427722Z"),
            InvitedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            RbacGroupIds = ["string"],
            Role = BetaOrganizationRole.Admin,
            Status = BetaOrganizationInviteStatus.Pending,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaOrganizationInvite>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "invite_015gWxCN9Hfg2QhZwTK7Mdeu";
        DateTimeOffset expectedAcceptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedEmail = "user@emaildomain.com";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2024-11-20T23:58:27.427722Z");
        DateTimeOffset expectedInvitedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        List<string> expectedRbacGroupIds = ["string"];
        ApiEnum<string, BetaOrganizationRole> expectedRole = BetaOrganizationRole.Admin;
        ApiEnum<string, BetaOrganizationInviteStatus> expectedStatus =
            BetaOrganizationInviteStatus.Pending;
        JsonElement expectedType = JsonSerializer.SerializeToElement("invite");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAcceptedAt, deserialized.AcceptedAt);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedInvitedAt, deserialized.InvitedAt);
        Assert.Equal(expectedRbacGroupIds.Count, deserialized.RbacGroupIds.Count);
        for (int i = 0; i < expectedRbacGroupIds.Count; i++)
        {
            Assert.Equal(expectedRbacGroupIds[i], deserialized.RbacGroupIds[i]);
        }
        Assert.Equal(expectedRole, deserialized.Role);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaOrganizationInvite
        {
            ID = "invite_015gWxCN9Hfg2QhZwTK7Mdeu",
            AcceptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Email = "user@emaildomain.com",
            ExpiresAt = DateTimeOffset.Parse("2024-11-20T23:58:27.427722Z"),
            InvitedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            RbacGroupIds = ["string"],
            Role = BetaOrganizationRole.Admin,
            Status = BetaOrganizationInviteStatus.Pending,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaOrganizationInvite
        {
            ID = "invite_015gWxCN9Hfg2QhZwTK7Mdeu",
            AcceptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Email = "user@emaildomain.com",
            ExpiresAt = DateTimeOffset.Parse("2024-11-20T23:58:27.427722Z"),
            InvitedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            RbacGroupIds = ["string"],
            Role = BetaOrganizationRole.Admin,
            Status = BetaOrganizationInviteStatus.Pending,
        };

        BetaOrganizationInvite copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaOrganizationInviteStatusTest : TestBase
{
    [Theory]
    [InlineData(BetaOrganizationInviteStatus.Accepted)]
    [InlineData(BetaOrganizationInviteStatus.Deleted)]
    [InlineData(BetaOrganizationInviteStatus.Expired)]
    [InlineData(BetaOrganizationInviteStatus.Pending)]
    public void Validation_Works(BetaOrganizationInviteStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaOrganizationInviteStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaOrganizationInviteStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaOrganizationInviteStatus.Accepted)]
    [InlineData(BetaOrganizationInviteStatus.Deleted)]
    [InlineData(BetaOrganizationInviteStatus.Expired)]
    [InlineData(BetaOrganizationInviteStatus.Pending)]
    public void SerializationRoundtrip_Works(BetaOrganizationInviteStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaOrganizationInviteStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaOrganizationInviteStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaOrganizationInviteStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaOrganizationInviteStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
