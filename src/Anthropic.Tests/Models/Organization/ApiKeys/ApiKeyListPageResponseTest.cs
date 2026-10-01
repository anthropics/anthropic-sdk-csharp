using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using ApiKeys = Anthropic.Models.Organization.ApiKeys;

namespace Anthropic.Tests.Models.Organization.ApiKeys;

public class ApiKeyListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ApiKeys::ApiKeyListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "apikey_01Rj2N8SVvo6BePZj99NhmiT",
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    CreatedBy = new()
                    {
                        ID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                        Type = ApiKeys::Type.User,
                    },
                    ExpiresAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    Name = "Developer Key",
                    PartialKeyHint = "sk-ant-api03-R2D...igAA",
                    Principal = new ApiKeys::ApiKeyUserActor("user_01WCz1FkmYMm4gnmykNKUu3Q"),
                    Scope = new ApiKeys::ApiKeyWorkspaceScope("wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"),
                    Status = ApiKeys::ApiKeyStatus.Active,
                },
            ],
            FirstID = "first_id",
            HasMore = true,
            LastID = "last_id",
        };

        List<ApiKeys::ApiKey> expectedData =
        [
            new()
            {
                ID = "apikey_01Rj2N8SVvo6BePZj99NhmiT",
                CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                CreatedBy = new()
                {
                    ID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                    Type = ApiKeys::Type.User,
                },
                ExpiresAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                Name = "Developer Key",
                PartialKeyHint = "sk-ant-api03-R2D...igAA",
                Principal = new ApiKeys::ApiKeyUserActor("user_01WCz1FkmYMm4gnmykNKUu3Q"),
                Scope = new ApiKeys::ApiKeyWorkspaceScope("wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"),
                Status = ApiKeys::ApiKeyStatus.Active,
            },
        ];
        string expectedFirstID = "first_id";
        bool expectedHasMore = true;
        string expectedLastID = "last_id";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedFirstID, model.FirstID);
        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedLastID, model.LastID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ApiKeys::ApiKeyListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "apikey_01Rj2N8SVvo6BePZj99NhmiT",
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    CreatedBy = new()
                    {
                        ID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                        Type = ApiKeys::Type.User,
                    },
                    ExpiresAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    Name = "Developer Key",
                    PartialKeyHint = "sk-ant-api03-R2D...igAA",
                    Principal = new ApiKeys::ApiKeyUserActor("user_01WCz1FkmYMm4gnmykNKUu3Q"),
                    Scope = new ApiKeys::ApiKeyWorkspaceScope("wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"),
                    Status = ApiKeys::ApiKeyStatus.Active,
                },
            ],
            FirstID = "first_id",
            HasMore = true,
            LastID = "last_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKeys::ApiKeyListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ApiKeys::ApiKeyListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "apikey_01Rj2N8SVvo6BePZj99NhmiT",
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    CreatedBy = new()
                    {
                        ID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                        Type = ApiKeys::Type.User,
                    },
                    ExpiresAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    Name = "Developer Key",
                    PartialKeyHint = "sk-ant-api03-R2D...igAA",
                    Principal = new ApiKeys::ApiKeyUserActor("user_01WCz1FkmYMm4gnmykNKUu3Q"),
                    Scope = new ApiKeys::ApiKeyWorkspaceScope("wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"),
                    Status = ApiKeys::ApiKeyStatus.Active,
                },
            ],
            FirstID = "first_id",
            HasMore = true,
            LastID = "last_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKeys::ApiKeyListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ApiKeys::ApiKey> expectedData =
        [
            new()
            {
                ID = "apikey_01Rj2N8SVvo6BePZj99NhmiT",
                CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                CreatedBy = new()
                {
                    ID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                    Type = ApiKeys::Type.User,
                },
                ExpiresAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                Name = "Developer Key",
                PartialKeyHint = "sk-ant-api03-R2D...igAA",
                Principal = new ApiKeys::ApiKeyUserActor("user_01WCz1FkmYMm4gnmykNKUu3Q"),
                Scope = new ApiKeys::ApiKeyWorkspaceScope("wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"),
                Status = ApiKeys::ApiKeyStatus.Active,
            },
        ];
        string expectedFirstID = "first_id";
        bool expectedHasMore = true;
        string expectedLastID = "last_id";

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedFirstID, deserialized.FirstID);
        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedLastID, deserialized.LastID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ApiKeys::ApiKeyListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "apikey_01Rj2N8SVvo6BePZj99NhmiT",
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    CreatedBy = new()
                    {
                        ID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                        Type = ApiKeys::Type.User,
                    },
                    ExpiresAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    Name = "Developer Key",
                    PartialKeyHint = "sk-ant-api03-R2D...igAA",
                    Principal = new ApiKeys::ApiKeyUserActor("user_01WCz1FkmYMm4gnmykNKUu3Q"),
                    Scope = new ApiKeys::ApiKeyWorkspaceScope("wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"),
                    Status = ApiKeys::ApiKeyStatus.Active,
                },
            ],
            FirstID = "first_id",
            HasMore = true,
            LastID = "last_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ApiKeys::ApiKeyListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "apikey_01Rj2N8SVvo6BePZj99NhmiT",
                    CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    CreatedBy = new()
                    {
                        ID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
                        Type = ApiKeys::Type.User,
                    },
                    ExpiresAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
                    Name = "Developer Key",
                    PartialKeyHint = "sk-ant-api03-R2D...igAA",
                    Principal = new ApiKeys::ApiKeyUserActor("user_01WCz1FkmYMm4gnmykNKUu3Q"),
                    Scope = new ApiKeys::ApiKeyWorkspaceScope("wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"),
                    Status = ApiKeys::ApiKeyStatus.Active,
                },
            ],
            FirstID = "first_id",
            HasMore = true,
            LastID = "last_id",
        };

        ApiKeys::ApiKeyListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
