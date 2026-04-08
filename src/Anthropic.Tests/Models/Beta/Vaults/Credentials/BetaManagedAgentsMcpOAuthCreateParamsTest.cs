using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsMcpOAuthCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthCreateParams
        {
            AccessToken = "x",
            McpServerUrl = "x",
            Type = BetaManagedAgentsMcpOAuthCreateParamsType.McpOAuth,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                ClientID = "x",
                RefreshToken = "x",
                TokenEndpoint = "x",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneParam(
                    BetaManagedAgentsTokenEndpointAuthNoneParamType.None
                ),
                Resource = "x",
                Scope = "x",
            },
        };

        string expectedAccessToken = "x";
        string expectedMcpServerUrl = "x";
        ApiEnum<string, BetaManagedAgentsMcpOAuthCreateParamsType> expectedType =
            BetaManagedAgentsMcpOAuthCreateParamsType.McpOAuth;
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        BetaManagedAgentsMcpOAuthRefreshParams expectedRefresh = new()
        {
            ClientID = "x",
            RefreshToken = "x",
            TokenEndpoint = "x",
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneParam(
                BetaManagedAgentsTokenEndpointAuthNoneParamType.None
            ),
            Resource = "x",
            Scope = "x",
        };

        Assert.Equal(expectedAccessToken, model.AccessToken);
        Assert.Equal(expectedMcpServerUrl, model.McpServerUrl);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedRefresh, model.Refresh);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthCreateParams
        {
            AccessToken = "x",
            McpServerUrl = "x",
            Type = BetaManagedAgentsMcpOAuthCreateParamsType.McpOAuth,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                ClientID = "x",
                RefreshToken = "x",
                TokenEndpoint = "x",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneParam(
                    BetaManagedAgentsTokenEndpointAuthNoneParamType.None
                ),
                Resource = "x",
                Scope = "x",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMcpOAuthCreateParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthCreateParams
        {
            AccessToken = "x",
            McpServerUrl = "x",
            Type = BetaManagedAgentsMcpOAuthCreateParamsType.McpOAuth,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                ClientID = "x",
                RefreshToken = "x",
                TokenEndpoint = "x",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneParam(
                    BetaManagedAgentsTokenEndpointAuthNoneParamType.None
                ),
                Resource = "x",
                Scope = "x",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMcpOAuthCreateParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAccessToken = "x";
        string expectedMcpServerUrl = "x";
        ApiEnum<string, BetaManagedAgentsMcpOAuthCreateParamsType> expectedType =
            BetaManagedAgentsMcpOAuthCreateParamsType.McpOAuth;
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        BetaManagedAgentsMcpOAuthRefreshParams expectedRefresh = new()
        {
            ClientID = "x",
            RefreshToken = "x",
            TokenEndpoint = "x",
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneParam(
                BetaManagedAgentsTokenEndpointAuthNoneParamType.None
            ),
            Resource = "x",
            Scope = "x",
        };

        Assert.Equal(expectedAccessToken, deserialized.AccessToken);
        Assert.Equal(expectedMcpServerUrl, deserialized.McpServerUrl);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedRefresh, deserialized.Refresh);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthCreateParams
        {
            AccessToken = "x",
            McpServerUrl = "x",
            Type = BetaManagedAgentsMcpOAuthCreateParamsType.McpOAuth,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                ClientID = "x",
                RefreshToken = "x",
                TokenEndpoint = "x",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneParam(
                    BetaManagedAgentsTokenEndpointAuthNoneParamType.None
                ),
                Resource = "x",
                Scope = "x",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthCreateParams
        {
            AccessToken = "x",
            McpServerUrl = "x",
            Type = BetaManagedAgentsMcpOAuthCreateParamsType.McpOAuth,
        };

        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.Refresh);
        Assert.False(model.RawData.ContainsKey("refresh"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthCreateParams
        {
            AccessToken = "x",
            McpServerUrl = "x",
            Type = BetaManagedAgentsMcpOAuthCreateParamsType.McpOAuth,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthCreateParams
        {
            AccessToken = "x",
            McpServerUrl = "x",
            Type = BetaManagedAgentsMcpOAuthCreateParamsType.McpOAuth,

            ExpiresAt = null,
            Refresh = null,
        };

        Assert.Null(model.ExpiresAt);
        Assert.True(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.Refresh);
        Assert.True(model.RawData.ContainsKey("refresh"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthCreateParams
        {
            AccessToken = "x",
            McpServerUrl = "x",
            Type = BetaManagedAgentsMcpOAuthCreateParamsType.McpOAuth,

            ExpiresAt = null,
            Refresh = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthCreateParams
        {
            AccessToken = "x",
            McpServerUrl = "x",
            Type = BetaManagedAgentsMcpOAuthCreateParamsType.McpOAuth,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                ClientID = "x",
                RefreshToken = "x",
                TokenEndpoint = "x",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneParam(
                    BetaManagedAgentsTokenEndpointAuthNoneParamType.None
                ),
                Resource = "x",
                Scope = "x",
            },
        };

        BetaManagedAgentsMcpOAuthCreateParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsMcpOAuthCreateParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsMcpOAuthCreateParamsType.McpOAuth)]
    public void Validation_Works(BetaManagedAgentsMcpOAuthCreateParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMcpOAuthCreateParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpOAuthCreateParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsMcpOAuthCreateParamsType.McpOAuth)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsMcpOAuthCreateParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMcpOAuthCreateParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpOAuthCreateParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpOAuthCreateParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpOAuthCreateParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
