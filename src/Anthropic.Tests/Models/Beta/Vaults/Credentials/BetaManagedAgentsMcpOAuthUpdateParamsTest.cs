using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsMcpOAuthUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthUpdateParams
        {
            AccessToken = "x",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                RefreshToken = "x",
                Scope = "scope",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam()
                {
                    ClientSecret = "x",
                },
            },
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("mcp_oauth");
        string expectedAccessToken = "x";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        BetaManagedAgentsMcpOAuthRefreshUpdateParams expectedRefresh = new()
        {
            RefreshToken = "x",
            Scope = "scope",
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam()
            {
                ClientSecret = "x",
            },
        };

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedAccessToken, model.AccessToken);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedRefresh, model.Refresh);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthUpdateParams
        {
            AccessToken = "x",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                RefreshToken = "x",
                Scope = "scope",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam()
                {
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
            AccessToken = "x",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                RefreshToken = "x",
                Scope = "scope",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam()
                {
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

        JsonElement expectedType = JsonSerializer.SerializeToElement("mcp_oauth");
        string expectedAccessToken = "x";
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        BetaManagedAgentsMcpOAuthRefreshUpdateParams expectedRefresh = new()
        {
            RefreshToken = "x",
            Scope = "scope",
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam()
            {
                ClientSecret = "x",
            },
        };

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedAccessToken, deserialized.AccessToken);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedRefresh, deserialized.Refresh);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthUpdateParams
        {
            AccessToken = "x",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                RefreshToken = "x",
                Scope = "scope",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam()
                {
                    ClientSecret = "x",
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthUpdateParams { };

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
        var model = new BetaManagedAgentsMcpOAuthUpdateParams { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthUpdateParams
        {
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
            AccessToken = "x",
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Refresh = new()
            {
                RefreshToken = "x",
                Scope = "scope",
                TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam()
                {
                    ClientSecret = "x",
                },
            },
        };

        BetaManagedAgentsMcpOAuthUpdateParams copied = new(model);

        Assert.Equal(model, copied);
    }
}
