using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.ServiceAccounts;

namespace Anthropic.Tests.Models.Beta.Organization.ServiceAccounts;

public class BetaServiceAccountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaServiceAccount
        {
            ID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ArchivedByActorID = "archived_by_actor_id",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            CreatedByActorID = "created_by_actor_id",
            Description = "description",
            Name = "ci-deploy-bot",
            OrganizationRole = BetaServiceAccountOrganizationRole.Admin,
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            UpdatedByActorID = "updated_by_actor_id",
        };

        string expectedID = "svac_01SDCCSbTxrXDpWc1phhtcfK";
        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedArchivedByActorID = "archived_by_actor_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedCreatedByActorID = "created_by_actor_id";
        string expectedDescription = "description";
        string expectedName = "ci-deploy-bot";
        ApiEnum<string, BetaServiceAccountOrganizationRole> expectedOrganizationRole =
            BetaServiceAccountOrganizationRole.Admin;
        JsonElement expectedType = JsonSerializer.SerializeToElement("service_account");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedUpdatedByActorID = "updated_by_actor_id";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedArchivedAt, model.ArchivedAt);
        Assert.Equal(expectedArchivedByActorID, model.ArchivedByActorID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreatedByActorID, model.CreatedByActorID);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedOrganizationRole, model.OrganizationRole);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedUpdatedByActorID, model.UpdatedByActorID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaServiceAccount
        {
            ID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ArchivedByActorID = "archived_by_actor_id",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            CreatedByActorID = "created_by_actor_id",
            Description = "description",
            Name = "ci-deploy-bot",
            OrganizationRole = BetaServiceAccountOrganizationRole.Admin,
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            UpdatedByActorID = "updated_by_actor_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaServiceAccount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaServiceAccount
        {
            ID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ArchivedByActorID = "archived_by_actor_id",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            CreatedByActorID = "created_by_actor_id",
            Description = "description",
            Name = "ci-deploy-bot",
            OrganizationRole = BetaServiceAccountOrganizationRole.Admin,
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            UpdatedByActorID = "updated_by_actor_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaServiceAccount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "svac_01SDCCSbTxrXDpWc1phhtcfK";
        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedArchivedByActorID = "archived_by_actor_id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedCreatedByActorID = "created_by_actor_id";
        string expectedDescription = "description";
        string expectedName = "ci-deploy-bot";
        ApiEnum<string, BetaServiceAccountOrganizationRole> expectedOrganizationRole =
            BetaServiceAccountOrganizationRole.Admin;
        JsonElement expectedType = JsonSerializer.SerializeToElement("service_account");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedUpdatedByActorID = "updated_by_actor_id";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedArchivedAt, deserialized.ArchivedAt);
        Assert.Equal(expectedArchivedByActorID, deserialized.ArchivedByActorID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreatedByActorID, deserialized.CreatedByActorID);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedOrganizationRole, deserialized.OrganizationRole);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedUpdatedByActorID, deserialized.UpdatedByActorID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaServiceAccount
        {
            ID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ArchivedByActorID = "archived_by_actor_id",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            CreatedByActorID = "created_by_actor_id",
            Description = "description",
            Name = "ci-deploy-bot",
            OrganizationRole = BetaServiceAccountOrganizationRole.Admin,
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            UpdatedByActorID = "updated_by_actor_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaServiceAccount
        {
            ID = "svac_01SDCCSbTxrXDpWc1phhtcfK",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ArchivedByActorID = "archived_by_actor_id",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            CreatedByActorID = "created_by_actor_id",
            Description = "description",
            Name = "ci-deploy-bot",
            OrganizationRole = BetaServiceAccountOrganizationRole.Admin,
            UpdatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            UpdatedByActorID = "updated_by_actor_id",
        };

        BetaServiceAccount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaServiceAccountOrganizationRoleTest : TestBase
{
    [Theory]
    [InlineData(BetaServiceAccountOrganizationRole.Admin)]
    [InlineData(BetaServiceAccountOrganizationRole.Developer)]
    public void Validation_Works(BetaServiceAccountOrganizationRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaServiceAccountOrganizationRole> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaServiceAccountOrganizationRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaServiceAccountOrganizationRole.Admin)]
    [InlineData(BetaServiceAccountOrganizationRole.Developer)]
    public void SerializationRoundtrip_Works(BetaServiceAccountOrganizationRole rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaServiceAccountOrganizationRole> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaServiceAccountOrganizationRole>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaServiceAccountOrganizationRole>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaServiceAccountOrganizationRole>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
