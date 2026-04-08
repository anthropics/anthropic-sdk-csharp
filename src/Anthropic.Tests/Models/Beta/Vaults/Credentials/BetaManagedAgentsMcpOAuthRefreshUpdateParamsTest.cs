using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsMcpOAuthRefreshUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthRefreshUpdateParams
        {
            RefreshToken = "x",
            Scope = "scope",
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam()
            {
                Type = BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType.ClientSecretBasic,
                ClientSecret = "x",
            },
        };

        string expectedRefreshToken = "x";
        string expectedScope = "scope";
        BetaManagedAgentsMcpOAuthRefreshUpdateParamsTokenEndpointAuth expectedTokenEndpointAuth =
            new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam()
            {
                Type = BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType.ClientSecretBasic,
                ClientSecret = "x",
            };

        Assert.Equal(expectedRefreshToken, model.RefreshToken);
        Assert.Equal(expectedScope, model.Scope);
        Assert.Equal(expectedTokenEndpointAuth, model.TokenEndpointAuth);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthRefreshUpdateParams
        {
            RefreshToken = "x",
            Scope = "scope",
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam()
            {
                Type = BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType.ClientSecretBasic,
                ClientSecret = "x",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMcpOAuthRefreshUpdateParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthRefreshUpdateParams
        {
            RefreshToken = "x",
            Scope = "scope",
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam()
            {
                Type = BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType.ClientSecretBasic,
                ClientSecret = "x",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsMcpOAuthRefreshUpdateParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedRefreshToken = "x";
        string expectedScope = "scope";
        BetaManagedAgentsMcpOAuthRefreshUpdateParamsTokenEndpointAuth expectedTokenEndpointAuth =
            new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam()
            {
                Type = BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType.ClientSecretBasic,
                ClientSecret = "x",
            };

        Assert.Equal(expectedRefreshToken, deserialized.RefreshToken);
        Assert.Equal(expectedScope, deserialized.Scope);
        Assert.Equal(expectedTokenEndpointAuth, deserialized.TokenEndpointAuth);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthRefreshUpdateParams
        {
            RefreshToken = "x",
            Scope = "scope",
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam()
            {
                Type = BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType.ClientSecretBasic,
                ClientSecret = "x",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthRefreshUpdateParams
        {
            RefreshToken = "x",
            Scope = "scope",
        };

        Assert.Null(model.TokenEndpointAuth);
        Assert.False(model.RawData.ContainsKey("token_endpoint_auth"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthRefreshUpdateParams
        {
            RefreshToken = "x",
            Scope = "scope",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthRefreshUpdateParams
        {
            RefreshToken = "x",
            Scope = "scope",

            // Null should be interpreted as omitted for these properties
            TokenEndpointAuth = null,
        };

        Assert.Null(model.TokenEndpointAuth);
        Assert.False(model.RawData.ContainsKey("token_endpoint_auth"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthRefreshUpdateParams
        {
            RefreshToken = "x",
            Scope = "scope",

            // Null should be interpreted as omitted for these properties
            TokenEndpointAuth = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthRefreshUpdateParams
        {
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam()
            {
                Type = BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType.ClientSecretBasic,
                ClientSecret = "x",
            },
        };

        Assert.Null(model.RefreshToken);
        Assert.False(model.RawData.ContainsKey("refresh_token"));
        Assert.Null(model.Scope);
        Assert.False(model.RawData.ContainsKey("scope"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthRefreshUpdateParams
        {
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam()
            {
                Type = BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType.ClientSecretBasic,
                ClientSecret = "x",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthRefreshUpdateParams
        {
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam()
            {
                Type = BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType.ClientSecretBasic,
                ClientSecret = "x",
            },

            RefreshToken = null,
            Scope = null,
        };

        Assert.Null(model.RefreshToken);
        Assert.True(model.RawData.ContainsKey("refresh_token"));
        Assert.Null(model.Scope);
        Assert.True(model.RawData.ContainsKey("scope"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthRefreshUpdateParams
        {
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam()
            {
                Type = BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType.ClientSecretBasic,
                ClientSecret = "x",
            },

            RefreshToken = null,
            Scope = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsMcpOAuthRefreshUpdateParams
        {
            RefreshToken = "x",
            Scope = "scope",
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam()
            {
                Type = BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType.ClientSecretBasic,
                ClientSecret = "x",
            },
        };

        BetaManagedAgentsMcpOAuthRefreshUpdateParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsMcpOAuthRefreshUpdateParamsTokenEndpointAuthTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsTokenEndpointAuthBasicUpdateParamValidationWorks()
    {
        BetaManagedAgentsMcpOAuthRefreshUpdateParamsTokenEndpointAuth value =
            new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam()
            {
                Type = BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType.ClientSecretBasic,
                ClientSecret = "x",
            };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsTokenEndpointAuthPostUpdateParamValidationWorks()
    {
        BetaManagedAgentsMcpOAuthRefreshUpdateParamsTokenEndpointAuth value =
            new BetaManagedAgentsTokenEndpointAuthPostUpdateParam()
            {
                Type = BetaManagedAgentsTokenEndpointAuthPostUpdateParamType.ClientSecretPost,
                ClientSecret = "x",
            };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsTokenEndpointAuthBasicUpdateParamSerializationRoundtripWorks()
    {
        BetaManagedAgentsMcpOAuthRefreshUpdateParamsTokenEndpointAuth value =
            new BetaManagedAgentsTokenEndpointAuthBasicUpdateParam()
            {
                Type = BetaManagedAgentsTokenEndpointAuthBasicUpdateParamType.ClientSecretBasic,
                ClientSecret = "x",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMcpOAuthRefreshUpdateParamsTokenEndpointAuth>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsTokenEndpointAuthPostUpdateParamSerializationRoundtripWorks()
    {
        BetaManagedAgentsMcpOAuthRefreshUpdateParamsTokenEndpointAuth value =
            new BetaManagedAgentsTokenEndpointAuthPostUpdateParam()
            {
                Type = BetaManagedAgentsTokenEndpointAuthPostUpdateParamType.ClientSecretPost,
                ClientSecret = "x",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMcpOAuthRefreshUpdateParamsTokenEndpointAuth>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}
