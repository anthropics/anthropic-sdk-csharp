using System;
using System.Text.Json;
using Anthropic.Core;
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
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                ClientID = "client_id",
                TokenEndpoint = "token_endpoint",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneResponse(),
                Resource = "resource",
                Scope = "scope",
            },
        };

        string expectedMcpServerUrl = "mcp_server_url";
        JsonElement expectedType = JsonSerializer.SerializeToElement("mcp_oauth");
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        BetaManagedAgentsMcpOAuthRefreshResponse expectedRefresh = new()
        {
            ClientID = "client_id",
            TokenEndpoint = "token_endpoint",
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneResponse(),
            Resource = "resource",
            Scope = "scope",
        };

        Assert.Equal(expectedMcpServerUrl, model.McpServerUrl);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedRefresh, model.Refresh);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthAuthResponse
        {
            McpServerUrl = "mcp_server_url",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                ClientID = "client_id",
                TokenEndpoint = "token_endpoint",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneResponse(),
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
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                ClientID = "client_id",
                TokenEndpoint = "token_endpoint",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneResponse(),
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
        JsonElement expectedType = JsonSerializer.SerializeToElement("mcp_oauth");
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        BetaManagedAgentsMcpOAuthRefreshResponse expectedRefresh = new()
        {
            ClientID = "client_id",
            TokenEndpoint = "token_endpoint",
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneResponse(),
            Resource = "resource",
            Scope = "scope",
        };

        Assert.Equal(expectedMcpServerUrl, deserialized.McpServerUrl);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedRefresh, deserialized.Refresh);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthAuthResponse
        {
            McpServerUrl = "mcp_server_url",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                ClientID = "client_id",
                TokenEndpoint = "token_endpoint",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneResponse(),
                Resource = "resource",
                Scope = "scope",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthAuthResponse { McpServerUrl = "mcp_server_url" };

        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expires_at"));
        Assert.Null(model.Refresh);
        Assert.False(model.RawData.ContainsKey("refresh"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthAuthResponse { McpServerUrl = "mcp_server_url" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthAuthResponse
        {
            McpServerUrl = "mcp_server_url",

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
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                ClientID = "client_id",
                TokenEndpoint = "token_endpoint",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneResponse(),
                Resource = "resource",
                Scope = "scope",
            },
        };

        BetaManagedAgentsMcpOAuthAuthResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
