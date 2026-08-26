using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ServiceAccounts;

namespace Anthropic.Tests.Models.Beta.Organization.ServiceAccounts;

public class ServiceAccountListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ServiceAccountListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextPage = "next_page",
        };

        List<BetaServiceAccount> expectedData =
        [
            new()
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
            },
        ];
        string expectedNextPage = "next_page";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedNextPage, model.NextPage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ServiceAccountListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextPage = "next_page",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ServiceAccountListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ServiceAccountListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextPage = "next_page",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ServiceAccountListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaServiceAccount> expectedData =
        [
            new()
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
            },
        ];
        string expectedNextPage = "next_page";

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedNextPage, deserialized.NextPage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ServiceAccountListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextPage = "next_page",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ServiceAccountListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextPage = "next_page",
        };

        ServiceAccountListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
