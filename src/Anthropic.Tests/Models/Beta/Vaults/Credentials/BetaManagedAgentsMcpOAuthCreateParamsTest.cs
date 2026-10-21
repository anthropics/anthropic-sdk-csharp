using System;
using System.Text.Json;
using Anthropic.Core;
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
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                ClientID = "x",
                RefreshToken = "x",
                TokenEndpoint = "x",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneParam(),
                Resource = "x",
                Scope = "x",
            },
        };

        string expectedAccessToken = "x";
        string expectedMcpServerUrl = "x";
        JsonElement expectedType = JsonSerializer.SerializeToElement("mcp_oauth");
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        BetaManagedAgentsMcpOAuthRefreshParams expectedRefresh = new()
        {
            ClientID = "x",
            RefreshToken = "x",
            TokenEndpoint = "x",
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneParam(),
            Resource = "x",
            Scope = "x",
        };

        Assert.Equal(expectedAccessToken, model.AccessToken);
        Assert.Equal(expectedMcpServerUrl, model.McpServerUrl);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
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
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                ClientID = "x",
                RefreshToken = "x",
                TokenEndpoint = "x",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneParam(),
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
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                ClientID = "x",
                RefreshToken = "x",
                TokenEndpoint = "x",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneParam(),
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
        JsonElement expectedType = JsonSerializer.SerializeToElement("mcp_oauth");
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        BetaManagedAgentsMcpOAuthRefreshParams expectedRefresh = new()
        {
            ClientID = "x",
            RefreshToken = "x",
            TokenEndpoint = "x",
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneParam(),
            Resource = "x",
            Scope = "x",
        };

        Assert.Equal(expectedAccessToken, deserialized.AccessToken);
        Assert.Equal(expectedMcpServerUrl, deserialized.McpServerUrl);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
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
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                ClientID = "x",
                RefreshToken = "x",
                TokenEndpoint = "x",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneParam(),
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
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                ClientID = "x",
                RefreshToken = "x",
                TokenEndpoint = "x",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneParam(),
                Resource = "x",
                Scope = "x",
            },
        };

        BetaManagedAgentsMcpOAuthCreateParams copied = new(model);

        Assert.Equal(model, copied);
    }
}
