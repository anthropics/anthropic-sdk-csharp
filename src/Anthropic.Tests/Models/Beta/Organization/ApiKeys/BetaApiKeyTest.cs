using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using ApiKeys = Anthropic.Models.Beta.Organization.ApiKeys;

namespace Anthropic.Tests.Models.Beta.Organization.ApiKeys;

public class BetaApiKeyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ApiKeys::BetaApiKey
        {
            ID = "apikey_01Rj2N8SVvo6BePZj99NhmiT",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            CreatedBy = new() { ID = "user_01WCz1FkmYMm4gnmykNKUu3Q", Type = ApiKeys::Type.User },
            ExpiresAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            Name = "Developer Key",
            PartialKeyHint = "sk-ant-api03-R2D...igAA",
            Principal = new ApiKeys::BetaApiKeyUserActor("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            Scope = new ApiKeys::BetaApiKeyWorkspaceScope("wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"),
            Status = ApiKeys::BetaApiKeyStatus.Active,
        };

        string expectedID = "apikey_01Rj2N8SVvo6BePZj99NhmiT";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        ApiKeys::BetaApiKeyCreatedBy expectedCreatedBy = new()
        {
            ID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            Type = ApiKeys::Type.User,
        };
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedName = "Developer Key";
        string expectedPartialKeyHint = "sk-ant-api03-R2D...igAA";
        ApiKeys::Principal expectedPrincipal = new ApiKeys::BetaApiKeyUserActor(
            "user_01WCz1FkmYMm4gnmykNKUu3Q"
        );
        ApiKeys::Scope expectedScope = new ApiKeys::BetaApiKeyWorkspaceScope(
            "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"
        );
        ApiEnum<string, ApiKeys::BetaApiKeyStatus> expectedStatus =
            ApiKeys::BetaApiKeyStatus.Active;
        JsonElement expectedType = JsonSerializer.SerializeToElement("api_key");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreatedBy, model.CreatedBy);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPartialKeyHint, model.PartialKeyHint);
        Assert.Equal(expectedPrincipal, model.Principal);
        Assert.Equal(expectedScope, model.Scope);
        Assert.Equal(expectedStatus, model.Status);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ApiKeys::BetaApiKey
        {
            ID = "apikey_01Rj2N8SVvo6BePZj99NhmiT",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            CreatedBy = new() { ID = "user_01WCz1FkmYMm4gnmykNKUu3Q", Type = ApiKeys::Type.User },
            ExpiresAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            Name = "Developer Key",
            PartialKeyHint = "sk-ant-api03-R2D...igAA",
            Principal = new ApiKeys::BetaApiKeyUserActor("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            Scope = new ApiKeys::BetaApiKeyWorkspaceScope("wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"),
            Status = ApiKeys::BetaApiKeyStatus.Active,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKeys::BetaApiKey>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ApiKeys::BetaApiKey
        {
            ID = "apikey_01Rj2N8SVvo6BePZj99NhmiT",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            CreatedBy = new() { ID = "user_01WCz1FkmYMm4gnmykNKUu3Q", Type = ApiKeys::Type.User },
            ExpiresAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            Name = "Developer Key",
            PartialKeyHint = "sk-ant-api03-R2D...igAA",
            Principal = new ApiKeys::BetaApiKeyUserActor("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            Scope = new ApiKeys::BetaApiKeyWorkspaceScope("wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"),
            Status = ApiKeys::BetaApiKeyStatus.Active,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKeys::BetaApiKey>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "apikey_01Rj2N8SVvo6BePZj99NhmiT";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        ApiKeys::BetaApiKeyCreatedBy expectedCreatedBy = new()
        {
            ID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            Type = ApiKeys::Type.User,
        };
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedName = "Developer Key";
        string expectedPartialKeyHint = "sk-ant-api03-R2D...igAA";
        ApiKeys::Principal expectedPrincipal = new ApiKeys::BetaApiKeyUserActor(
            "user_01WCz1FkmYMm4gnmykNKUu3Q"
        );
        ApiKeys::Scope expectedScope = new ApiKeys::BetaApiKeyWorkspaceScope(
            "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"
        );
        ApiEnum<string, ApiKeys::BetaApiKeyStatus> expectedStatus =
            ApiKeys::BetaApiKeyStatus.Active;
        JsonElement expectedType = JsonSerializer.SerializeToElement("api_key");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreatedBy, deserialized.CreatedBy);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPartialKeyHint, deserialized.PartialKeyHint);
        Assert.Equal(expectedPrincipal, deserialized.Principal);
        Assert.Equal(expectedScope, deserialized.Scope);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ApiKeys::BetaApiKey
        {
            ID = "apikey_01Rj2N8SVvo6BePZj99NhmiT",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            CreatedBy = new() { ID = "user_01WCz1FkmYMm4gnmykNKUu3Q", Type = ApiKeys::Type.User },
            ExpiresAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            Name = "Developer Key",
            PartialKeyHint = "sk-ant-api03-R2D...igAA",
            Principal = new ApiKeys::BetaApiKeyUserActor("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            Scope = new ApiKeys::BetaApiKeyWorkspaceScope("wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"),
            Status = ApiKeys::BetaApiKeyStatus.Active,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ApiKeys::BetaApiKey
        {
            ID = "apikey_01Rj2N8SVvo6BePZj99NhmiT",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            CreatedBy = new() { ID = "user_01WCz1FkmYMm4gnmykNKUu3Q", Type = ApiKeys::Type.User },
            ExpiresAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            Name = "Developer Key",
            PartialKeyHint = "sk-ant-api03-R2D...igAA",
            Principal = new ApiKeys::BetaApiKeyUserActor("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            Scope = new ApiKeys::BetaApiKeyWorkspaceScope("wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"),
            Status = ApiKeys::BetaApiKeyStatus.Active,
        };

        ApiKeys::BetaApiKey copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PrincipalTest : TestBase
{
    [Fact]
    public void BetaApiKeyUserActorValidationWorks()
    {
        ApiKeys::Principal value = new ApiKeys::BetaApiKeyUserActor(
            "user_01WCz1FkmYMm4gnmykNKUu3Q"
        );
        value.Validate();
    }

    [Fact]
    public void BetaApiKeyServiceAccountActorValidationWorks()
    {
        ApiKeys::Principal value = new ApiKeys::BetaApiKeyServiceAccountActor(
            "svac_01Hk3R9TWxq7CfQak00OiVw4"
        );
        value.Validate();
    }

    [Fact]
    public void BetaApiKeyUserActorSerializationRoundtripWorks()
    {
        ApiKeys::Principal value = new ApiKeys::BetaApiKeyUserActor(
            "user_01WCz1FkmYMm4gnmykNKUu3Q"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKeys::Principal>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaApiKeyServiceAccountActorSerializationRoundtripWorks()
    {
        ApiKeys::Principal value = new ApiKeys::BetaApiKeyServiceAccountActor(
            "svac_01Hk3R9TWxq7CfQak00OiVw4"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKeys::Principal>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaApiKeyUserActorTypeWorks()
    {
        ApiKeys::Principal value = new ApiKeys::BetaApiKeyUserActor(
            "user_01WCz1FkmYMm4gnmykNKUu3Q"
        );
        Assert.Equal(ApiKeys::PrincipalType.UserActor, value.Type.Value());
    }

    [Fact]
    public void BetaApiKeyServiceAccountActorTypeWorks()
    {
        ApiKeys::Principal value = new ApiKeys::BetaApiKeyServiceAccountActor(
            "svac_01Hk3R9TWxq7CfQak00OiVw4"
        );
        Assert.Equal(ApiKeys::PrincipalType.ServiceAccountActor, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        ApiKeys::Principal value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "user_actor"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, ApiKeys::PrincipalType> expectedType = ApiKeys::PrincipalType.UserActor;

        Assert.Equal(expectedType, value.Type);

        ApiKeys::Principal emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class PrincipalTypeTest : TestBase
{
    [Theory]
    [InlineData(ApiKeys::PrincipalType.UserActor)]
    [InlineData(ApiKeys::PrincipalType.ServiceAccountActor)]
    public void Validation_Works(ApiKeys::PrincipalType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ApiKeys::PrincipalType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ApiKeys::PrincipalType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ApiKeys::PrincipalType.UserActor)]
    [InlineData(ApiKeys::PrincipalType.ServiceAccountActor)]
    public void SerializationRoundtrip_Works(ApiKeys::PrincipalType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ApiKeys::PrincipalType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ApiKeys::PrincipalType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ApiKeys::PrincipalType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ApiKeys::PrincipalType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ScopeTest : TestBase
{
    [Fact]
    public void BetaApiKeyOrganizationValidationWorks()
    {
        ApiKeys::Scope value = new ApiKeys::BetaApiKeyOrganizationScope();
        value.Validate();
    }

    [Fact]
    public void BetaApiKeyWorkspaceValidationWorks()
    {
        ApiKeys::Scope value = new ApiKeys::BetaApiKeyWorkspaceScope(
            "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"
        );
        value.Validate();
    }

    [Fact]
    public void BetaApiKeyOrganizationSerializationRoundtripWorks()
    {
        ApiKeys::Scope value = new ApiKeys::BetaApiKeyOrganizationScope();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKeys::Scope>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaApiKeyWorkspaceSerializationRoundtripWorks()
    {
        ApiKeys::Scope value = new ApiKeys::BetaApiKeyWorkspaceScope(
            "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKeys::Scope>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaApiKeyOrganizationTypeWorks()
    {
        ApiKeys::Scope value = new ApiKeys::BetaApiKeyOrganizationScope();
        Assert.Equal(ApiKeys::ScopeType.Organization, value.Type.Value());
    }

    [Fact]
    public void BetaApiKeyWorkspaceTypeWorks()
    {
        ApiKeys::Scope value = new ApiKeys::BetaApiKeyWorkspaceScope(
            "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"
        );
        Assert.Equal(ApiKeys::ScopeType.Workspace, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        ApiKeys::Scope value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "workspace"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, ApiKeys::ScopeType> expectedType = ApiKeys::ScopeType.Workspace;

        Assert.Equal(expectedType, value.Type);

        ApiKeys::Scope emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class ScopeTypeTest : TestBase
{
    [Theory]
    [InlineData(ApiKeys::ScopeType.Organization)]
    [InlineData(ApiKeys::ScopeType.Workspace)]
    public void Validation_Works(ApiKeys::ScopeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ApiKeys::ScopeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ApiKeys::ScopeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ApiKeys::ScopeType.Organization)]
    [InlineData(ApiKeys::ScopeType.Workspace)]
    public void SerializationRoundtrip_Works(ApiKeys::ScopeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ApiKeys::ScopeType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ApiKeys::ScopeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ApiKeys::ScopeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ApiKeys::ScopeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BetaApiKeyStatusTest : TestBase
{
    [Theory]
    [InlineData(ApiKeys::BetaApiKeyStatus.Active)]
    [InlineData(ApiKeys::BetaApiKeyStatus.Archived)]
    [InlineData(ApiKeys::BetaApiKeyStatus.Expired)]
    [InlineData(ApiKeys::BetaApiKeyStatus.Inactive)]
    public void Validation_Works(ApiKeys::BetaApiKeyStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ApiKeys::BetaApiKeyStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ApiKeys::BetaApiKeyStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ApiKeys::BetaApiKeyStatus.Active)]
    [InlineData(ApiKeys::BetaApiKeyStatus.Archived)]
    [InlineData(ApiKeys::BetaApiKeyStatus.Expired)]
    [InlineData(ApiKeys::BetaApiKeyStatus.Inactive)]
    public void SerializationRoundtrip_Works(ApiKeys::BetaApiKeyStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ApiKeys::BetaApiKeyStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ApiKeys::BetaApiKeyStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ApiKeys::BetaApiKeyStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ApiKeys::BetaApiKeyStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
