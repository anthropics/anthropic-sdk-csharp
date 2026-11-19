using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
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
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneResponse(),
            Resource = "resource",
            Scope = "scope",
        };

        string expectedClientID = "client_id";
        string expectedTokenEndpoint = "token_endpoint";
        BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth expectedTokenEndpointAuth =
            new BetaManagedAgentsTokenEndpointAuthNoneResponse();
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
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneResponse(),
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
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneResponse(),
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
            new BetaManagedAgentsTokenEndpointAuthNoneResponse();
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
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneResponse(),
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
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneResponse(),
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
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneResponse(),
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
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneResponse(),

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
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneResponse(),

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
            TokenEndpointAuth = new BetaManagedAgentsTokenEndpointAuthNoneResponse(),
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
            new BetaManagedAgentsTokenEndpointAuthNoneResponse();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsTokenEndpointAuthBasicResponseValidationWorks()
    {
        BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth value =
            new BetaManagedAgentsTokenEndpointAuthBasicResponse();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsTokenEndpointAuthPostResponseValidationWorks()
    {
        BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth value =
            new BetaManagedAgentsTokenEndpointAuthPostResponse();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsTokenEndpointAuthNoneResponseSerializationRoundtripWorks()
    {
        BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth value =
            new BetaManagedAgentsTokenEndpointAuthNoneResponse();
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
            new BetaManagedAgentsTokenEndpointAuthBasicResponse();
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
            new BetaManagedAgentsTokenEndpointAuthPostResponse();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsTokenEndpointAuthNoneResponseTypeWorks()
    {
        BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth value =
            new BetaManagedAgentsTokenEndpointAuthNoneResponse();
        Assert.Equal(
            BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuthType.None,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsTokenEndpointAuthBasicResponseTypeWorks()
    {
        BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth value =
            new BetaManagedAgentsTokenEndpointAuthBasicResponse();
        Assert.Equal(
            BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuthType.ClientSecretBasic,
            value.Type.Value()
        );
    }

    [Fact]
    public void BetaManagedAgentsTokenEndpointAuthPostResponseTypeWorks()
    {
        BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth value =
            new BetaManagedAgentsTokenEndpointAuthPostResponse();
        Assert.Equal(
            BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuthType.ClientSecretPost,
            value.Type.Value()
        );
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "none"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<
            string,
            BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuthType
        > expectedType = BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuthType.None;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuth emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuthTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuthType.None)]
    [InlineData(BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuthType.ClientSecretBasic)]
    [InlineData(BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuthType.ClientSecretPost)]
    public void Validation_Works(
        BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuthType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuthType> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuthType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuthType.None, 0, "none")]
    [InlineData(
        BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuthType.ClientSecretBasic,
        1,
        "client_secret_basic"
    )]
    [InlineData(
        BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuthType.ClientSecretPost,
        2,
        "client_secret_post"
    )]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuthType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuthType> value =
            rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuthType>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuthType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsMcpOAuthRefreshResponseTokenEndpointAuthType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
