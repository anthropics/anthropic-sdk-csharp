using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsMcpOAuthUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthUpdateParams
        {
            Type = BetaManagedAgentsMcpOAuthUpdateParamsType.McpOAuth,
            AccessToken = "x",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                RefreshToken = "x",
                Scope = "scope",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam()
                {
                    Type = BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType.ClientSecretBasic,
                    ClientSecret = "x",
                },
            },
        };

        ApiEnum<string, BetaManagedAgentsMcpOAuthUpdateParamsType> expectedType =
            BetaManagedAgentsMcpOAuthUpdateParamsType.McpOAuth;
        string expectedAccessToken = "x";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        BetaManagedAgentsMcpOAuthRefreshUpdateParams expectedRefresh = new()
        {
            RefreshToken = "x",
            Scope = "scope",
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam()
            {
                Type = BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType.ClientSecretBasic,
                ClientSecret = "x",
            },
        };

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedAccessToken, model.AccessToken);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedRefresh, model.Refresh);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthUpdateParams
        {
            Type = BetaManagedAgentsMcpOAuthUpdateParamsType.McpOAuth,
            AccessToken = "x",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                RefreshToken = "x",
                Scope = "scope",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam()
                {
                    Type = BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType.ClientSecretBasic,
                    ClientSecret = "x",
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMcpOAuthUpdateParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthUpdateParams
        {
            Type = BetaManagedAgentsMcpOAuthUpdateParamsType.McpOAuth,
            AccessToken = "x",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                RefreshToken = "x",
                Scope = "scope",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam()
                {
                    Type = BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType.ClientSecretBasic,
                    ClientSecret = "x",
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMcpOAuthUpdateParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaManagedAgentsMcpOAuthUpdateParamsType> expectedType =
            BetaManagedAgentsMcpOAuthUpdateParamsType.McpOAuth;
        string expectedAccessToken = "x";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        BetaManagedAgentsMcpOAuthRefreshUpdateParams expectedRefresh = new()
        {
            RefreshToken = "x",
            Scope = "scope",
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam()
            {
                Type = BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType.ClientSecretBasic,
                ClientSecret = "x",
            },
        };

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedAccessToken, deserialized.AccessToken);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedRefresh, deserialized.Refresh);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthUpdateParams
        {
            Type = BetaManagedAgentsMcpOAuthUpdateParamsType.McpOAuth,
            AccessToken = "x",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                RefreshToken = "x",
                Scope = "scope",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam()
                {
                    Type = BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType.ClientSecretBasic,
                    ClientSecret = "x",
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthUpdateParams
        {
            Type = BetaManagedAgentsMcpOAuthUpdateParamsType.McpOAuth,
        };

        Assert.Null(model.AccessToken);
        Assert.False(model.RawData.ContainsKey("access_token"));
        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.Refresh);
        Assert.False(model.RawData.ContainsKey("refresh"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthUpdateParams
        {
            Type = BetaManagedAgentsMcpOAuthUpdateParamsType.McpOAuth,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthUpdateParams
        {
            Type = BetaManagedAgentsMcpOAuthUpdateParamsType.McpOAuth,

            AccessToken = null,
            ExpiresAt = null,
            Refresh = null,
        };

        Assert.Null(model.AccessToken);
        Assert.True(model.RawData.ContainsKey("access_token"));
        Assert.Null(model.ExpiresAt);
        Assert.True(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.Refresh);
        Assert.True(model.RawData.ContainsKey("refresh"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthUpdateParams
        {
            Type = BetaManagedAgentsMcpOAuthUpdateParamsType.McpOAuth,

            AccessToken = null,
            ExpiresAt = null,
            Refresh = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthUpdateParams
        {
            Type = BetaManagedAgentsMcpOAuthUpdateParamsType.McpOAuth,
            AccessToken = "x",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                RefreshToken = "x",
                Scope = "scope",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam()
                {
                    Type = BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType.ClientSecretBasic,
                    ClientSecret = "x",
                },
            },
        };

        BetaManagedAgentsMcpOAuthUpdateParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsMcpOAuthUpdateParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsMcpOAuthUpdateParamsType.McpOAuth)]
    public void Validation_Works(BetaManagedAgentsMcpOAuthUpdateParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMcpOAuthUpdateParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpOAuthUpdateParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsMcpOAuthUpdateParamsType.McpOAuth)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsMcpOAuthUpdateParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMcpOAuthUpdateParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpOAuthUpdateParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpOAuthUpdateParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpOAuthUpdateParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
