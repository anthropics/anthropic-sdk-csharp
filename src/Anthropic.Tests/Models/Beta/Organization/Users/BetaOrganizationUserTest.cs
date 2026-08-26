using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization;
using Anthropic.Models.Beta.Organization.Users;

namespace Anthropic.Tests.Models.Beta.Organization.Users;

public class BetaOrganizationUserTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaOrganizationUser
        {
            ID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            AddedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            Email = "user@emaildomain.com",
            Name = "Jane Doe",
            Role = BetaOrganizationRole.Admin,
        };

        string expectedID = "user_01WCz1FkmYMm4gnmykNKUu3Q";
        DateTimeOffset expectedAddedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedEmail = "user@emaildomain.com";
        string expectedName = "Jane Doe";
        ApiEnum<string, BetaOrganizationRole> expectedRole = BetaOrganizationRole.Admin;
        JsonElement expectedType = JsonSerializer.SerializeToElement("user");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAddedAt, model.AddedAt);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedRole, model.Role);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaOrganizationUser
        {
            ID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            AddedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            Email = "user@emaildomain.com",
            Name = "Jane Doe",
            Role = BetaOrganizationRole.Admin,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaOrganizationUser>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaOrganizationUser
        {
            ID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            AddedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            Email = "user@emaildomain.com",
            Name = "Jane Doe",
            Role = BetaOrganizationRole.Admin,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaOrganizationUser>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "user_01WCz1FkmYMm4gnmykNKUu3Q";
        DateTimeOffset expectedAddedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedEmail = "user@emaildomain.com";
        string expectedName = "Jane Doe";
        ApiEnum<string, BetaOrganizationRole> expectedRole = BetaOrganizationRole.Admin;
        JsonElement expectedType = JsonSerializer.SerializeToElement("user");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAddedAt, deserialized.AddedAt);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedRole, deserialized.Role);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaOrganizationUser
        {
            ID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            AddedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            Email = "user@emaildomain.com",
            Name = "Jane Doe",
            Role = BetaOrganizationRole.Admin,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaOrganizationUser
        {
            ID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            AddedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            Email = "user@emaildomain.com",
            Name = "Jane Doe",
            Role = BetaOrganizationRole.Admin,
        };

        BetaOrganizationUser copied = new(model);

        Assert.Equal(model, copied);
    }
}
