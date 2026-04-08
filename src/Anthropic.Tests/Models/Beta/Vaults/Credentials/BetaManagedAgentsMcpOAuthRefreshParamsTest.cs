using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsMcpOAuthRefreshParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthRefreshParams
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

        string expectedClientID = "x";
        string expectedRefreshToken = "x";
        string expectedTokenEndpoint = "x";
        TokenEndpointAuth expectedTokenEndpointAuth =
            new BetaManagedAgentsTokenEndpointAuthNoneParam(
                BetaManagedAgentsTokenEndpointAuthNoneParamType.None
            );
        string expectedResource = "x";
        string expectedScope = "x";

        Assert.Equal(expectedClientID, model.ClientID);
        Assert.Equal(expectedRefreshToken, model.RefreshToken);
        Assert.Equal(expectedTokenEndpoint, model.TokenEndpoint);
        Assert.Equal(expectedTokenEndpointAuth, model.TokenEndpointAuth);
        Assert.Equal(expectedResource, model.Resource);
        Assert.Equal(expectedScope, model.Scope);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthRefreshParams
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMcpOAuthRefreshParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthRefreshParams
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMcpOAuthRefreshParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedClientID = "x";
        string expectedRefreshToken = "x";
        string expectedTokenEndpoint = "x";
        TokenEndpointAuth expectedTokenEndpointAuth =
            new BetaManagedAgentsTokenEndpointAuthNoneParam(
                BetaManagedAgentsTokenEndpointAuthNoneParamType.None
            );
        string expectedResource = "x";
        string expectedScope = "x";

        Assert.Equal(expectedClientID, deserialized.ClientID);
        Assert.Equal(expectedRefreshToken, deserialized.RefreshToken);
        Assert.Equal(expectedTokenEndpoint, deserialized.TokenEndpoint);
        Assert.Equal(expectedTokenEndpointAuth, deserialized.TokenEndpointAuth);
        Assert.Equal(expectedResource, deserialized.Resource);
        Assert.Equal(expectedScope, deserialized.Scope);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthRefreshParams
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthRefreshParams
        {
            ClientID = "x",
            RefreshToken = "x",
            TokenEndpoint = "x",
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneParam(
                BetaManagedAgentsTokenEndpointAuthNoneParamType.None
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
        var model = new BetaManagedAgentsMcpOAuthRefreshParams
        {
            ClientID = "x",
            RefreshToken = "x",
            TokenEndpoint = "x",
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneParam(
                BetaManagedAgentsTokenEndpointAuthNoneParamType.None
            ),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthRefreshParams
        {
            ClientID = "x",
            RefreshToken = "x",
            TokenEndpoint = "x",
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneParam(
                BetaManagedAgentsTokenEndpointAuthNoneParamType.None
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
        var model = new BetaManagedAgentsMcpOAuthRefreshParams
        {
            ClientID = "x",
            RefreshToken = "x",
            TokenEndpoint = "x",
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneParam(
                BetaManagedAgentsTokenEndpointAuthNoneParamType.None
            ),

            Resource = null,
            Scope = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthRefreshParams
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

        BetaManagedAgentsMcpOAuthRefreshParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TokenEndpointAuthTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsTokenEndpointAuthNoneParamValidationWorks()
    {
        TokenEndpointAuth value = new BetaManagedAgentsTokenEndpointAuthNoneParam(
            BetaManagedAgentsTokenEndpointAuthNoneParamType.None
        );
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsTokenEndpointAuthBasicParamValidationWorks()
    {
        TokenEndpointAuth value = new BetaManagedAgentsTokenEndpointAuthBasicParam()
        {
            ClientSecret = "x",
            Type = BetaManagedAgentsTokenEndpointAuthBasicParamType.ClientSecretBasic,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsTokenEndpointAuthPostParamValidationWorks()
    {
        TokenEndpointAuth value = new BetaManagedAgentsTokenEndpointAuthPostParam()
        {
            ClientSecret = "x",
            Type = BetaManagedAgentsTokenEndpointAuthPostParamType.ClientSecretPost,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsTokenEndpointAuthNoneParamSerializationRoundtripWorks()
    {
        TokenEndpointAuth value = new BetaManagedAgentsTokenEndpointAuthNoneParam(
            BetaManagedAgentsTokenEndpointAuthNoneParamType.None
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TokenEndpointAuth>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsTokenEndpointAuthBasicParamSerializationRoundtripWorks()
    {
        TokenEndpointAuth value = new BetaManagedAgentsTokenEndpointAuthBasicParam()
        {
            ClientSecret = "x",
            Type = BetaManagedAgentsTokenEndpointAuthBasicParamType.ClientSecretBasic,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TokenEndpointAuth>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsTokenEndpointAuthPostParamSerializationRoundtripWorks()
    {
        TokenEndpointAuth value = new BetaManagedAgentsTokenEndpointAuthPostParam()
        {
            ClientSecret = "x",
            Type = BetaManagedAgentsTokenEndpointAuthPostParamType.ClientSecretPost,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TokenEndpointAuth>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
