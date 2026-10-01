using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using ApiKeys = Anthropic.Models.Organization.ApiKeys;

namespace Anthropic.Tests.Models.Organization.ApiKeys;

public class ApiKeyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ApiKeys::ApiKey
        {
            ID = "apikey_01Rj2N8SVvo6BePZj99NhmiT",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            CreatedBy = new() { ID = "user_01WCz1FkmYMm4gnmykNKUu3Q", Type = ApiKeys::Type.User },
            ExpiresAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            Name = "Developer Key",
            PartialKeyHint = "sk-ant-api03-R2D...igAA",
            Principal = new ApiKeys::ApiKeyUserActor("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            Scope = new ApiKeys::ApiKeyWorkspaceScope("wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"),
            Status = ApiKeys::ApiKeyStatus.Active,
        };

        string expectedID = "apikey_01Rj2N8SVvo6BePZj99NhmiT";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        ApiKeys::ApiKeyCreatedBy expectedCreatedBy = new()
        {
            ID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            Type = ApiKeys::Type.User,
        };
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedName = "Developer Key";
        string expectedPartialKeyHint = "sk-ant-api03-R2D...igAA";
        ApiKeys::Principal expectedPrincipal = new ApiKeys::ApiKeyUserActor(
            "user_01WCz1FkmYMm4gnmykNKUu3Q"
        );
        ApiKeys::Scope expectedScope = new ApiKeys::ApiKeyWorkspaceScope(
            "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"
        );
        ApiEnum<string, ApiKeys::ApiKeyStatus> expectedStatus = ApiKeys::ApiKeyStatus.Active;
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
        var model = new ApiKeys::ApiKey
        {
            ID = "apikey_01Rj2N8SVvo6BePZj99NhmiT",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            CreatedBy = new() { ID = "user_01WCz1FkmYMm4gnmykNKUu3Q", Type = ApiKeys::Type.User },
            ExpiresAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            Name = "Developer Key",
            PartialKeyHint = "sk-ant-api03-R2D...igAA",
            Principal = new ApiKeys::ApiKeyUserActor("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            Scope = new ApiKeys::ApiKeyWorkspaceScope("wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"),
            Status = ApiKeys::ApiKeyStatus.Active,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKeys::ApiKey>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ApiKeys::ApiKey
        {
            ID = "apikey_01Rj2N8SVvo6BePZj99NhmiT",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            CreatedBy = new() { ID = "user_01WCz1FkmYMm4gnmykNKUu3Q", Type = ApiKeys::Type.User },
            ExpiresAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            Name = "Developer Key",
            PartialKeyHint = "sk-ant-api03-R2D...igAA",
            Principal = new ApiKeys::ApiKeyUserActor("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            Scope = new ApiKeys::ApiKeyWorkspaceScope("wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"),
            Status = ApiKeys::ApiKeyStatus.Active,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKeys::ApiKey>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "apikey_01Rj2N8SVvo6BePZj99NhmiT";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        ApiKeys::ApiKeyCreatedBy expectedCreatedBy = new()
        {
            ID = "user_01WCz1FkmYMm4gnmykNKUu3Q",
            Type = ApiKeys::Type.User,
        };
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedName = "Developer Key";
        string expectedPartialKeyHint = "sk-ant-api03-R2D...igAA";
        ApiKeys::Principal expectedPrincipal = new ApiKeys::ApiKeyUserActor(
            "user_01WCz1FkmYMm4gnmykNKUu3Q"
        );
        ApiKeys::Scope expectedScope = new ApiKeys::ApiKeyWorkspaceScope(
            "wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"
        );
        ApiEnum<string, ApiKeys::ApiKeyStatus> expectedStatus = ApiKeys::ApiKeyStatus.Active;
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
        var model = new ApiKeys::ApiKey
        {
            ID = "apikey_01Rj2N8SVvo6BePZj99NhmiT",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            CreatedBy = new() { ID = "user_01WCz1FkmYMm4gnmykNKUu3Q", Type = ApiKeys::Type.User },
            ExpiresAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            Name = "Developer Key",
            PartialKeyHint = "sk-ant-api03-R2D...igAA",
            Principal = new ApiKeys::ApiKeyUserActor("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            Scope = new ApiKeys::ApiKeyWorkspaceScope("wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"),
            Status = ApiKeys::ApiKeyStatus.Active,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ApiKeys::ApiKey
        {
            ID = "apikey_01Rj2N8SVvo6BePZj99NhmiT",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            CreatedBy = new() { ID = "user_01WCz1FkmYMm4gnmykNKUu3Q", Type = ApiKeys::Type.User },
            ExpiresAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            Name = "Developer Key",
            PartialKeyHint = "sk-ant-api03-R2D...igAA",
            Principal = new ApiKeys::ApiKeyUserActor("user_01WCz1FkmYMm4gnmykNKUu3Q"),
            Scope = new ApiKeys::ApiKeyWorkspaceScope("wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ"),
            Status = ApiKeys::ApiKeyStatus.Active,
        };

        ApiKeys::ApiKey copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PrincipalTest : TestBase
{
    [Fact]
    public void ApiKeyUserActorValidationWorks()
    {
        ApiKeys::Principal value = new ApiKeys::ApiKeyUserActor("user_01WCz1FkmYMm4gnmykNKUu3Q");
        value.Validate();
    }

    [Fact]
    public void ApiKeyServiceAccountActorValidationWorks()
    {
        ApiKeys::Principal value = new ApiKeys::ApiKeyServiceAccountActor(
            "svac_01Hk3R9TWxq7CfQak00OiVw4"
        );
        value.Validate();
    }

    [Fact]
    public void ApiKeyUserActorSerializationRoundtripWorks()
    {
        ApiKeys::Principal value = new ApiKeys::ApiKeyUserActor("user_01WCz1FkmYMm4gnmykNKUu3Q");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKeys::Principal>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ApiKeyServiceAccountActorSerializationRoundtripWorks()
    {
        ApiKeys::Principal value = new ApiKeys::ApiKeyServiceAccountActor(
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

        JsonElement expectedType = JsonSerializer.SerializeToElement("user_actor");

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        ApiKeys::Principal emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class ScopeTest : TestBase
{
    [Fact]
    public void ApiKeyOrganizationValidationWorks()
    {
        ApiKeys::Scope value = new ApiKeys::ApiKeyOrganizationScope();
        value.Validate();
    }

    [Fact]
    public void ApiKeyWorkspaceValidationWorks()
    {
        ApiKeys::Scope value = new ApiKeys::ApiKeyWorkspaceScope("wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ");
        value.Validate();
    }

    [Fact]
    public void ApiKeyOrganizationSerializationRoundtripWorks()
    {
        ApiKeys::Scope value = new ApiKeys::ApiKeyOrganizationScope();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKeys::Scope>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ApiKeyWorkspaceSerializationRoundtripWorks()
    {
        ApiKeys::Scope value = new ApiKeys::ApiKeyWorkspaceScope("wrkspc_01JwQvzr7rXLA5AGx3HKfFUJ");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKeys::Scope>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        ApiKeys::Scope value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "organization"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        JsonElement expectedType = JsonSerializer.SerializeToElement("organization");

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        ApiKeys::Scope emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class ApiKeyStatusTest : TestBase
{
    [Theory]
    [InlineData(ApiKeys::ApiKeyStatus.Active)]
    [InlineData(ApiKeys::ApiKeyStatus.Archived)]
    [InlineData(ApiKeys::ApiKeyStatus.Expired)]
    [InlineData(ApiKeys::ApiKeyStatus.Inactive)]
    public void Validation_Works(ApiKeys::ApiKeyStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ApiKeys::ApiKeyStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ApiKeys::ApiKeyStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ApiKeys::ApiKeyStatus.Active)]
    [InlineData(ApiKeys::ApiKeyStatus.Archived)]
    [InlineData(ApiKeys::ApiKeyStatus.Expired)]
    [InlineData(ApiKeys::ApiKeyStatus.Inactive)]
    public void SerializationRoundtrip_Works(ApiKeys::ApiKeyStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ApiKeys::ApiKeyStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ApiKeys::ApiKeyStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ApiKeys::ApiKeyStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ApiKeys::ApiKeyStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
