using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
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
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneParam(),
            Resource = "x",
            Scope = "x",
        };

        string expectedClientID = "x";
        string expectedRefreshToken = "x";
        string expectedTokenEndpoint = "x";
        TokenEndpointAuth expectedTokenEndpointAuth =
            new BetaManagedAgentsTokenEndpointAuthNoneParam();
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
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneParam(),
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
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneParam(),
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
            new BetaManagedAgentsTokenEndpointAuthNoneParam();
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
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneParam(),
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
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneParam(),
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
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneParam(),
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
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneParam(),

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
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneParam(),

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
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneParam(),
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
        TokenEndpointAuth value = new BetaManagedAgentsTokenEndpointAuthNoneParam();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsTokenEndpointAuthBasicParamValidationWorks()
    {
        TokenEndpointAuth value = new BetaManagedAgentsTokenEndpointAuthBasicParam("x");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsTokenEndpointAuthPostParamValidationWorks()
    {
        TokenEndpointAuth value = new BetaManagedAgentsTokenEndpointAuthPostParam("x");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsTokenEndpointAuthNoneParamSerializationRoundtripWorks()
    {
        TokenEndpointAuth value = new BetaManagedAgentsTokenEndpointAuthNoneParam();
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
        TokenEndpointAuth value = new BetaManagedAgentsTokenEndpointAuthBasicParam("x");
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
        TokenEndpointAuth value = new BetaManagedAgentsTokenEndpointAuthPostParam("x");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TokenEndpointAuth>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsTokenEndpointAuthNoneParamTypeWorks()
    {
        TokenEndpointAuth value = new BetaManagedAgentsTokenEndpointAuthNoneParam();
        Assert.Equal(TokenEndpointAuthType.None, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsTokenEndpointAuthBasicParamTypeWorks()
    {
        TokenEndpointAuth value = new BetaManagedAgentsTokenEndpointAuthBasicParam("x");
        Assert.Equal(TokenEndpointAuthType.ClientSecretBasic, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsTokenEndpointAuthPostParamTypeWorks()
    {
        TokenEndpointAuth value = new BetaManagedAgentsTokenEndpointAuthPostParam("x");
        Assert.Equal(TokenEndpointAuthType.ClientSecretPost, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        TokenEndpointAuth value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "none",
                  "client_secret": "x"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, TokenEndpointAuthType> expectedType = TokenEndpointAuthType.None;
        string expectedClientSecret = "x";

        Assert.Equal(expectedType, value.Type);
        Assert.Equal(expectedClientSecret, value.ClientSecret);

        TokenEndpointAuth emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.ClientSecret);

        TokenEndpointAuth mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "client_secret": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.ClientSecret);
    }
}

public class TokenEndpointAuthTypeTest : TestBase
{
    [Theory]
    [InlineData(TokenEndpointAuthType.None)]
    [InlineData(TokenEndpointAuthType.ClientSecretBasic)]
    [InlineData(TokenEndpointAuthType.ClientSecretPost)]
    public void Validation_Works(TokenEndpointAuthType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TokenEndpointAuthType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TokenEndpointAuthType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TokenEndpointAuthType.None)]
    [InlineData(TokenEndpointAuthType.ClientSecretBasic)]
    [InlineData(TokenEndpointAuthType.ClientSecretPost)]
    public void SerializationRoundtrip_Works(TokenEndpointAuthType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TokenEndpointAuthType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TokenEndpointAuthType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TokenEndpointAuthType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TokenEndpointAuthType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
