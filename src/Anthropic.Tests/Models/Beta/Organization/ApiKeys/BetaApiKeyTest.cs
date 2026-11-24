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
            ID = "apikey_01BcDeFgHjKmNpQrStUvWxYz",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            CreatedBy = new() { ID = "user_01WxYzAbCdEfGhJkMnPqRsTu", Type = ApiKeys::Type.User },
            ExpiresAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            Name = "Developer Key",
            PartialKeyHint = "sk-ant-api03-R2D...igAA",
            Principal = new ApiKeys::BetaApiKeyUserActor("user_01WxYzAbCdEfGhJkMnPqRsTu"),
            Scope = new ApiKeys::BetaApiKeyWorkspaceScope("wrkspc_01AbCdEfGhJkLmNpQrStUvWx"),
            Status = ApiKeys::BetaApiKeyStatus.Active,
        };

        string expectedID = "apikey_01BcDeFgHjKmNpQrStUvWxYz";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        ApiKeys::BetaApiKeyCreatedBy expectedCreatedBy = new()
        {
            ID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
            Type = ApiKeys::Type.User,
        };
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedName = "Developer Key";
        string expectedPartialKeyHint = "sk-ant-api03-R2D...igAA";
        ApiKeys::Principal expectedPrincipal = new ApiKeys::BetaApiKeyUserActor(
            "user_01WxYzAbCdEfGhJkMnPqRsTu"
        );
        ApiKeys::Scope expectedScope = new ApiKeys::BetaApiKeyWorkspaceScope(
            "wrkspc_01AbCdEfGhJkLmNpQrStUvWx"
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
            ID = "apikey_01BcDeFgHjKmNpQrStUvWxYz",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            CreatedBy = new() { ID = "user_01WxYzAbCdEfGhJkMnPqRsTu", Type = ApiKeys::Type.User },
            ExpiresAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            Name = "Developer Key",
            PartialKeyHint = "sk-ant-api03-R2D...igAA",
            Principal = new ApiKeys::BetaApiKeyUserActor("user_01WxYzAbCdEfGhJkMnPqRsTu"),
            Scope = new ApiKeys::BetaApiKeyWorkspaceScope("wrkspc_01AbCdEfGhJkLmNpQrStUvWx"),
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
            ID = "apikey_01BcDeFgHjKmNpQrStUvWxYz",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            CreatedBy = new() { ID = "user_01WxYzAbCdEfGhJkMnPqRsTu", Type = ApiKeys::Type.User },
            ExpiresAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            Name = "Developer Key",
            PartialKeyHint = "sk-ant-api03-R2D...igAA",
            Principal = new ApiKeys::BetaApiKeyUserActor("user_01WxYzAbCdEfGhJkMnPqRsTu"),
            Scope = new ApiKeys::BetaApiKeyWorkspaceScope("wrkspc_01AbCdEfGhJkLmNpQrStUvWx"),
            Status = ApiKeys::BetaApiKeyStatus.Active,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKeys::BetaApiKey>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "apikey_01BcDeFgHjKmNpQrStUvWxYz";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        ApiKeys::BetaApiKeyCreatedBy expectedCreatedBy = new()
        {
            ID = "user_01WxYzAbCdEfGhJkMnPqRsTu",
            Type = ApiKeys::Type.User,
        };
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z");
        string expectedName = "Developer Key";
        string expectedPartialKeyHint = "sk-ant-api03-R2D...igAA";
        ApiKeys::Principal expectedPrincipal = new ApiKeys::BetaApiKeyUserActor(
            "user_01WxYzAbCdEfGhJkMnPqRsTu"
        );
        ApiKeys::Scope expectedScope = new ApiKeys::BetaApiKeyWorkspaceScope(
            "wrkspc_01AbCdEfGhJkLmNpQrStUvWx"
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
            ID = "apikey_01BcDeFgHjKmNpQrStUvWxYz",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            CreatedBy = new() { ID = "user_01WxYzAbCdEfGhJkMnPqRsTu", Type = ApiKeys::Type.User },
            ExpiresAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            Name = "Developer Key",
            PartialKeyHint = "sk-ant-api03-R2D...igAA",
            Principal = new ApiKeys::BetaApiKeyUserActor("user_01WxYzAbCdEfGhJkMnPqRsTu"),
            Scope = new ApiKeys::BetaApiKeyWorkspaceScope("wrkspc_01AbCdEfGhJkLmNpQrStUvWx"),
            Status = ApiKeys::BetaApiKeyStatus.Active,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ApiKeys::BetaApiKey
        {
            ID = "apikey_01BcDeFgHjKmNpQrStUvWxYz",
            CreatedAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            CreatedBy = new() { ID = "user_01WxYzAbCdEfGhJkMnPqRsTu", Type = ApiKeys::Type.User },
            ExpiresAt = DateTimeOffset.Parse("2024-10-30T23:58:27.427722Z"),
            Name = "Developer Key",
            PartialKeyHint = "sk-ant-api03-R2D...igAA",
            Principal = new ApiKeys::BetaApiKeyUserActor("user_01WxYzAbCdEfGhJkMnPqRsTu"),
            Scope = new ApiKeys::BetaApiKeyWorkspaceScope("wrkspc_01AbCdEfGhJkLmNpQrStUvWx"),
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
            "user_01WxYzAbCdEfGhJkMnPqRsTu"
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
            "user_01WxYzAbCdEfGhJkMnPqRsTu"
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
            "user_01WxYzAbCdEfGhJkMnPqRsTu"
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
    [InlineData(ApiKeys::PrincipalType.UserActor, 0, "user_actor")]
    [InlineData(ApiKeys::PrincipalType.ServiceAccountActor, 1, "service_account_actor")]
    public void EnumMemberSerializationRoundtrip_Works(
        ApiKeys::PrincipalType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ApiKeys::PrincipalType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ApiKeys::PrincipalType>>(
            apiJson,
            ModelBase.SerializerOptions
        );

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
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
            "wrkspc_01AbCdEfGhJkLmNpQrStUvWx"
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
            "wrkspc_01AbCdEfGhJkLmNpQrStUvWx"
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
            "wrkspc_01AbCdEfGhJkLmNpQrStUvWx"
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
    [InlineData(ApiKeys::ScopeType.Organization, 0, "organization")]
    [InlineData(ApiKeys::ScopeType.Workspace, 1, "workspace")]
    public void EnumMemberSerializationRoundtrip_Works(
        ApiKeys::ScopeType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ApiKeys::ScopeType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ApiKeys::ScopeType>>(
            apiJson,
            ModelBase.SerializerOptions
        );

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
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
    [InlineData(ApiKeys::BetaApiKeyStatus.Active, 0, "active")]
    [InlineData(ApiKeys::BetaApiKeyStatus.Archived, 1, "archived")]
    [InlineData(ApiKeys::BetaApiKeyStatus.Expired, 2, "expired")]
    [InlineData(ApiKeys::BetaApiKeyStatus.Inactive, 3, "inactive")]
    public void EnumMemberSerializationRoundtrip_Works(
        ApiKeys::BetaApiKeyStatus rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ApiKeys::BetaApiKeyStatus> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ApiKeys::BetaApiKeyStatus>>(
            apiJson,
            ModelBase.SerializerOptions
        );

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
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
