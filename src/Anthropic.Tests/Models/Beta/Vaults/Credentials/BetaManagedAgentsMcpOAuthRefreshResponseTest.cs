using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsMcpOAuthRefreshResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthRefreshResponse
        {
            ClientID = "client_id",
            TokenEndpoint = "token_endpoint",
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneResponse(
                BetaManagedAgentsTokenEndpointAuthNoneResponseType.None
            ),
            Resource = "resource",
            Scope = "scope",
        };

        string expectedClientID = "client_id";
        string expectedTokenEndpoint = "token_endpoint";
        BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth expectedTokenEndpointAuth =
            new BetaManagedAgentsTokenEndpointAuthNoneResponse(
                BetaManagedAgentsTokenEndpointAuthNoneResponseType.None
            );
        string expectedResource = "resource";
        string expectedScope = "scope";

        Assert.Equal(expectedClientID, model.ClientID);
        Assert.Equal(expectedTokenEndpoint, model.TokenEndpoint);
        Assert.Equal(expectedTokenEndpointAuth, model.TokenEndpointAuth);
        Assert.Equal(expectedResource, model.Resource);
        Assert.Equal(expectedScope, model.Scope);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthRefreshResponse
        {
            ClientID = "client_id",
            TokenEndpoint = "token_endpoint",
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneResponse(
                BetaManagedAgentsTokenEndpointAuthNoneResponseType.None
            ),
            Resource = "resource",
            Scope = "scope",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMcpOAuthRefreshResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthRefreshResponse
        {
            ClientID = "client_id",
            TokenEndpoint = "token_endpoint",
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneResponse(
                BetaManagedAgentsTokenEndpointAuthNoneResponseType.None
            ),
            Resource = "resource",
            Scope = "scope",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMcpOAuthRefreshResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedClientID = "client_id";
        string expectedTokenEndpoint = "token_endpoint";
        BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth expectedTokenEndpointAuth =
            new BetaManagedAgentsTokenEndpointAuthNoneResponse(
                BetaManagedAgentsTokenEndpointAuthNoneResponseType.None
            );
        string expectedResource = "resource";
        string expectedScope = "scope";

        Assert.Equal(expectedClientID, deserialized.ClientID);
        Assert.Equal(expectedTokenEndpoint, deserialized.TokenEndpoint);
        Assert.Equal(expectedTokenEndpointAuth, deserialized.TokenEndpointAuth);
        Assert.Equal(expectedResource, deserialized.Resource);
        Assert.Equal(expectedScope, deserialized.Scope);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthRefreshResponse
        {
            ClientID = "client_id",
            TokenEndpoint = "token_endpoint",
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneResponse(
                BetaManagedAgentsTokenEndpointAuthNoneResponseType.None
            ),
            Resource = "resource",
            Scope = "scope",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthRefreshResponse
        {
            ClientID = "client_id",
            TokenEndpoint = "token_endpoint",
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneResponse(
                BetaManagedAgentsTokenEndpointAuthNoneResponseType.None
            ),
        };

        Assert.Null(model.Resource);
        Assert.False(model.RawData.ContainsKey("resource"));
        Assert.Null(model.Scope);
        Assert.False(model.RawData.ContainsKey("scope"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthRefreshResponse
        {
            ClientID = "client_id",
            TokenEndpoint = "token_endpoint",
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneResponse(
                BetaManagedAgentsTokenEndpointAuthNoneResponseType.None
            ),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthRefreshResponse
        {
            ClientID = "client_id",
            TokenEndpoint = "token_endpoint",
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneResponse(
                BetaManagedAgentsTokenEndpointAuthNoneResponseType.None
            ),

            Resource = null,
            Scope = null,
        };

        Assert.Null(model.Resource);
        Assert.True(model.RawData.ContainsKey("resource"));
        Assert.Null(model.Scope);
        Assert.True(model.RawData.ContainsKey("scope"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthRefreshResponse
        {
            ClientID = "client_id",
            TokenEndpoint = "token_endpoint",
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneResponse(
                BetaManagedAgentsTokenEndpointAuthNoneResponseType.None
            ),

            Resource = null,
            Scope = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthRefreshResponse
        {
            ClientID = "client_id",
            TokenEndpoint = "token_endpoint",
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneResponse(
                BetaManagedAgentsTokenEndpointAuthNoneResponseType.None
            ),
            Resource = "resource",
            Scope = "scope",
        };

        BetaManagedAgentsMcpOAuthRefreshResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuthTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsTokenEndpointAuthNoneResponseValidationWorks()
    {
        BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth value =
            new BetaManagedAgentsTokenEndpointAuthNoneResponse(
                BetaManagedAgentsTokenEndpointAuthNoneResponseType.None
            );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsTokenEndpointAuthBasicResponseValidationWorks()
    {
        BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth value =
            new BetaManagedAgentsTokenEndpointAuthBasicResponse(
                BetaManagedAgentsTokenEndpointAuthBasicResponseType.ClientSecretBasic
            );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsTokenEndpointAuthPostResponseValidationWorks()
    {
        BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth value =
            new BetaManagedAgentsTokenEndpointAuthPostResponse(
                BetaManagedAgentsTokenEndpointAuthPostResponseType.ClientSecretPost
            );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsTokenEndpointAuthNoneResponseSerializationRoundtripWorks()
    {
        BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth value =
            new BetaManagedAgentsTokenEndpointAuthNoneResponse(
                BetaManagedAgentsTokenEndpointAuthNoneResponseType.None
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsTokenEndpointAuthBasicResponseSerializationRoundtripWorks()
    {
        BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth value =
            new BetaManagedAgentsTokenEndpointAuthBasicResponse(
                BetaManagedAgentsTokenEndpointAuthBasicResponseType.ClientSecretBasic
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsTokenEndpointAuthPostResponseSerializationRoundtripWorks()
    {
        BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth value =
            new BetaManagedAgentsTokenEndpointAuthPostResponse(
                BetaManagedAgentsTokenEndpointAuthPostResponseType.ClientSecretPost
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}
