using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsFederatedActorProviderTest : TestBase
{
    [Fact]
    public void AwsValidationWorks()
    {
        BetaAnalyticsFederatedActorProvider value = new BetaAnalyticsFederatedActorAwsProvider()
        {
            AccountID = "account_id",
            SignedPrincipal = "signed_principal",
        };
        value.Validate();
    }

    [Fact]
    public void AzureValidationWorks()
    {
        BetaAnalyticsFederatedActorProvider value = new BetaAnalyticsFederatedActorAzureProvider(
            "subscription_id"
        );
        value.Validate();
    }

    [Fact]
    public void GcpValidationWorks()
    {
        BetaAnalyticsFederatedActorProvider value = new BetaAnalyticsFederatedActorGcpProvider(
            "project_number"
        );
        value.Validate();
    }

    [Fact]
    public void OidcValidationWorks()
    {
        BetaAnalyticsFederatedActorProvider value = new BetaAnalyticsFederatedActorOidcProvider(
            "issuer"
        );
        value.Validate();
    }

    [Fact]
    public void AwsSerializationRoundtripWorks()
    {
        BetaAnalyticsFederatedActorProvider value = new BetaAnalyticsFederatedActorAwsProvider()
        {
            AccountID = "account_id",
            SignedPrincipal = "signed_principal",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsFederatedActorProvider>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AzureSerializationRoundtripWorks()
    {
        BetaAnalyticsFederatedActorProvider value = new BetaAnalyticsFederatedActorAzureProvider(
            "subscription_id"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsFederatedActorProvider>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GcpSerializationRoundtripWorks()
    {
        BetaAnalyticsFederatedActorProvider value = new BetaAnalyticsFederatedActorGcpProvider(
            "project_number"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsFederatedActorProvider>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void OidcSerializationRoundtripWorks()
    {
        BetaAnalyticsFederatedActorProvider value = new BetaAnalyticsFederatedActorOidcProvider(
            "issuer"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsFederatedActorProvider>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AwsTypeWorks()
    {
        BetaAnalyticsFederatedActorProvider value = new BetaAnalyticsFederatedActorAwsProvider()
        {
            AccountID = "account_id",
            SignedPrincipal = "signed_principal",
        };
        Assert.Equal(BetaAnalyticsFederatedActorProviderType.Aws, value.Type.Value());
    }

    [Fact]
    public void AzureTypeWorks()
    {
        BetaAnalyticsFederatedActorProvider value = new BetaAnalyticsFederatedActorAzureProvider(
            "subscription_id"
        );
        Assert.Equal(BetaAnalyticsFederatedActorProviderType.Azure, value.Type.Value());
    }

    [Fact]
    public void GcpTypeWorks()
    {
        BetaAnalyticsFederatedActorProvider value = new BetaAnalyticsFederatedActorGcpProvider(
            "project_number"
        );
        Assert.Equal(BetaAnalyticsFederatedActorProviderType.Gcp, value.Type.Value());
    }

    [Fact]
    public void OidcTypeWorks()
    {
        BetaAnalyticsFederatedActorProvider value = new BetaAnalyticsFederatedActorOidcProvider(
            "issuer"
        );
        Assert.Equal(BetaAnalyticsFederatedActorProviderType.Oidc, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaAnalyticsFederatedActorProvider value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "aws"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaAnalyticsFederatedActorProviderType> expectedType =
            BetaAnalyticsFederatedActorProviderType.Aws;

        Assert.Equal(expectedType, value.Type);

        BetaAnalyticsFederatedActorProvider emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaAnalyticsFederatedActorProviderTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaAnalyticsFederatedActorProviderType.Aws)]
    [InlineData(BetaAnalyticsFederatedActorProviderType.Azure)]
    [InlineData(BetaAnalyticsFederatedActorProviderType.Gcp)]
    [InlineData(BetaAnalyticsFederatedActorProviderType.Oidc)]
    public void Validation_Works(BetaAnalyticsFederatedActorProviderType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsFederatedActorProviderType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsFederatedActorProviderType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaAnalyticsFederatedActorProviderType.Aws)]
    [InlineData(BetaAnalyticsFederatedActorProviderType.Azure)]
    [InlineData(BetaAnalyticsFederatedActorProviderType.Gcp)]
    [InlineData(BetaAnalyticsFederatedActorProviderType.Oidc)]
    public void SerializationRoundtrip_Works(BetaAnalyticsFederatedActorProviderType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaAnalyticsFederatedActorProviderType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsFederatedActorProviderType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsFederatedActorProviderType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaAnalyticsFederatedActorProviderType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
