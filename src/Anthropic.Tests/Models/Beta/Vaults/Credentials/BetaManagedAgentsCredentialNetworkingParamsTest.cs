using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Tests.Models.Beta.Vaults.Credentials;

public class BetaManagedAgentsCredentialNetworkingParamsTest : TestBase
{
    [Fact]
    public void UnrestrictedValidationWorks()
    {
        BetaManagedAgentsCredentialNetworkingParams value =
            new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(
                BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType.Unrestricted
            );
        value.Validate();
    }

    [Fact]
    public void LimitedValidationWorks()
    {
        BetaManagedAgentsCredentialNetworkingParams value =
            new BetaManagedAgentsLimitedCredentialNetworkingParams()
            {
                AllowedHosts = ["string"],
                Type = BetaManagedAgentsLimitedCredentialNetworkingParamsType.Limited,
            };
        value.Validate();
    }

    [Fact]
    public void UnrestrictedSerializationRoundtripWorks()
    {
        BetaManagedAgentsCredentialNetworkingParams value =
            new BetaManagedAgentsUnrestrictedCredentialNetworkingParams(
                BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType.Unrestricted
            );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsCredentialNetworkingParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LimitedSerializationRoundtripWorks()
    {
        BetaManagedAgentsCredentialNetworkingParams value =
            new BetaManagedAgentsLimitedCredentialNetworkingParams()
            {
                AllowedHosts = ["string"],
                Type = BetaManagedAgentsLimitedCredentialNetworkingParamsType.Limited,
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsCredentialNetworkingParams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
