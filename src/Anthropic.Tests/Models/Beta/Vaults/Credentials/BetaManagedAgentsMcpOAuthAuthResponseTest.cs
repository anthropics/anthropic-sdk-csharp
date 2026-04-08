using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsMcpOAuthAuthResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthAuthResponse
        {
            McpServerUrl = "mcp_server_url",
            Type = BetaManagedAgentsMcpOAuthAuthResponseType.McpOAuth,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                ClientID = "client_id",
                TokenEndpoint = "token_endpoint",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneResponse(
                    BetaManagedAgentsTokenEndpointAuthNoneResponseType.None
                ),
                Resource = "resource",
                Scope = "scope",
            },
        };

        string expectedMcpServerUrl = "mcp_server_url";
        ApiEnum<string, BetaManagedAgentsMcpOAuthAuthResponseType> expectedType =
            BetaManagedAgentsMcpOAuthAuthResponseType.McpOAuth;
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        BetaManagedAgentsMcpOAuthRefreshResponse expectedRefresh = new()
        {
            ClientID = "client_id",
            TokenEndpoint = "token_endpoint",
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneResponse(
                BetaManagedAgentsTokenEndpointAuthNoneResponseType.None
            ),
            Resource = "resource",
            Scope = "scope",
        };

        Assert.Equal(expectedMcpServerUrl, model.McpServerUrl);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedRefresh, model.Refresh);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthAuthResponse
        {
            McpServerUrl = "mcp_server_url",
            Type = BetaManagedAgentsMcpOAuthAuthResponseType.McpOAuth,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                ClientID = "client_id",
                TokenEndpoint = "token_endpoint",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneResponse(
                    BetaManagedAgentsTokenEndpointAuthNoneResponseType.None
                ),
                Resource = "resource",
                Scope = "scope",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMcpOAuthAuthResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthAuthResponse
        {
            McpServerUrl = "mcp_server_url",
            Type = BetaManagedAgentsMcpOAuthAuthResponseType.McpOAuth,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                ClientID = "client_id",
                TokenEndpoint = "token_endpoint",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneResponse(
                    BetaManagedAgentsTokenEndpointAuthNoneResponseType.None
                ),
                Resource = "resource",
                Scope = "scope",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMcpOAuthAuthResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMcpServerUrl = "mcp_server_url";
        ApiEnum<string, BetaManagedAgentsMcpOAuthAuthResponseType> expectedType =
            BetaManagedAgentsMcpOAuthAuthResponseType.McpOAuth;
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        BetaManagedAgentsMcpOAuthRefreshResponse expectedRefresh = new()
        {
            ClientID = "client_id",
            TokenEndpoint = "token_endpoint",
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneResponse(
                BetaManagedAgentsTokenEndpointAuthNoneResponseType.None
            ),
            Resource = "resource",
            Scope = "scope",
        };

        Assert.Equal(expectedMcpServerUrl, deserialized.McpServerUrl);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedRefresh, deserialized.Refresh);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthAuthResponse
        {
            McpServerUrl = "mcp_server_url",
            Type = BetaManagedAgentsMcpOAuthAuthResponseType.McpOAuth,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                ClientID = "client_id",
                TokenEndpoint = "token_endpoint",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneResponse(
                    BetaManagedAgentsTokenEndpointAuthNoneResponseType.None
                ),
                Resource = "resource",
                Scope = "scope",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthAuthResponse
        {
            McpServerUrl = "mcp_server_url",
            Type = BetaManagedAgentsMcpOAuthAuthResponseType.McpOAuth,
        };

        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.Refresh);
        Assert.False(model.RawData.ContainsKey("refresh"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthAuthResponse
        {
            McpServerUrl = "mcp_server_url",
            Type = BetaManagedAgentsMcpOAuthAuthResponseType.McpOAuth,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthAuthResponse
        {
            McpServerUrl = "mcp_server_url",
            Type = BetaManagedAgentsMcpOAuthAuthResponseType.McpOAuth,

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
        var model = new BetaManagedAgentsMcpOAuthAuthResponse
        {
            McpServerUrl = "mcp_server_url",
            Type = BetaManagedAgentsMcpOAuthAuthResponseType.McpOAuth,

            ExpiresAt = null,
            Refresh = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthAuthResponse
        {
            McpServerUrl = "mcp_server_url",
            Type = BetaManagedAgentsMcpOAuthAuthResponseType.McpOAuth,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                ClientID = "client_id",
                TokenEndpoint = "token_endpoint",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneResponse(
                    BetaManagedAgentsTokenEndpointAuthNoneResponseType.None
                ),
                Resource = "resource",
                Scope = "scope",
            },
        };

        BetaManagedAgentsMcpOAuthAuthResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsMcpOAuthAuthResponseTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsMcpOAuthAuthResponseType.McpOAuth)]
    public void Validation_Works(BetaManagedAgentsMcpOAuthAuthResponseType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMcpOAuthAuthResponseType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpOAuthAuthResponseType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsMcpOAuthAuthResponseType.McpOAuth)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsMcpOAuthAuthResponseType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMcpOAuthAuthResponseType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpOAuthAuthResponseType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpOAuthAuthResponseType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpOAuthAuthResponseType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
