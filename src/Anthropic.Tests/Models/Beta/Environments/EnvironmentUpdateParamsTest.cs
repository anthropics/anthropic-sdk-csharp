using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Environments;

namespace Anthropic.Tests.Models.Beta.Environments;

public class EnvironmentUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EnvironmentUpdateParams
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            Config = new BetaCloudConfigParams()
            {
                Networking = new BetaLimitedNetworkParams()
                {
                    AllowMcpServers = true,
                    AllowPackageManagers = true,
                    AllowedHosts = ["api.example.com"],
                },
                Packages = new()
                {
                    Apt = ["string"],
                    Cargo = ["string"],
                    Gem = ["string"],
                    Go = ["string"],
                    Npm = ["string"],
                    Pip = ["pandas", "numpy"],
                    Type = BetaPackagesParamsType.Packages,
                },
            },
            Description = "Python environment with data-analysis packages.",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            Name = "x",
            Scope = EnvironmentUpdateParamsScope.Organization,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedEnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW";
        EnvironmentUpdateParamsConfig expectedConfig = new BetaCloudConfigParams()
        {
            Networking = new BetaLimitedNetworkParams()
            {
                AllowMcpServers = true,
                AllowPackageManagers = true,
                AllowedHosts = ["api.example.com"],
            },
            Packages = new()
            {
                Apt = ["string"],
                Cargo = ["string"],
                Gem = ["string"],
                Go = ["string"],
                Npm = ["string"],
                Pip = ["pandas", "numpy"],
                Type = BetaPackagesParamsType.Packages,
            },
        };
        string expectedDescription = "Python environment with data-analysis packages.";
        Dictionary<string, string?> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "x";
        ApiEnum<string, EnvironmentUpdateParamsScope> expectedScope =
            EnvironmentUpdateParamsScope.Organization;
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedEnvironmentID, parameters.EnvironmentID);
        Assert.Equal(expectedConfig, parameters.Config);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedScope, parameters.Scope);
        Assert.NotNull(parameters.Betas);
        Assert.Equal(expectedBetas.Count, parameters.Betas.Count);
        for (int i = 0; i < expectedBetas.Count; i++)
        {
            Assert.Equal(expectedBetas[i], parameters.Betas[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EnvironmentUpdateParams
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            Config = new BetaCloudConfigParams()
            {
                Networking = new BetaLimitedNetworkParams()
                {
                    AllowMcpServers = true,
                    AllowPackageManagers = true,
                    AllowedHosts = ["api.example.com"],
                },
                Packages = new()
                {
                    Apt = ["string"],
                    Cargo = ["string"],
                    Gem = ["string"],
                    Go = ["string"],
                    Npm = ["string"],
                    Pip = ["pandas", "numpy"],
                    Type = BetaPackagesParamsType.Packages,
                },
            },
            Description = "Python environment with data-analysis packages.",
            Name = "x",
            Scope = EnvironmentUpdateParamsScope.Organization,
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EnvironmentUpdateParams
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            Config = new BetaCloudConfigParams()
            {
                Networking = new BetaLimitedNetworkParams()
                {
                    AllowMcpServers = true,
                    AllowPackageManagers = true,
                    AllowedHosts = ["api.example.com"],
                },
                Packages = new()
                {
                    Apt = ["string"],
                    Cargo = ["string"],
                    Gem = ["string"],
                    Go = ["string"],
                    Npm = ["string"],
                    Pip = ["pandas", "numpy"],
                    Type = BetaPackagesParamsType.Packages,
                },
            },
            Description = "Python environment with data-analysis packages.",
            Name = "x",
            Scope = EnvironmentUpdateParamsScope.Organization,

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            Betas = null,
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EnvironmentUpdateParams
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.Config);
        Assert.False(parameters.RawBodyData.ContainsKey("config"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Scope);
        Assert.False(parameters.RawBodyData.ContainsKey("scope"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new EnvironmentUpdateParams
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            Config = null,
            Description = null,
            Name = null,
            Scope = null,
        };

        Assert.Null(parameters.Config);
        Assert.True(parameters.RawBodyData.ContainsKey("config"));
        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Scope);
        Assert.True(parameters.RawBodyData.ContainsKey("scope"));
    }

    [Fact]
    public void Url_Works()
    {
        EnvironmentUpdateParams parameters = new()
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.anthropic.com/v1/environments/env_011CZkZ9X2dpNyB7HsEFoRfW?beta=true"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        EnvironmentUpdateParams parameters = new()
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["managed-agents-2026-04-01", "message-batches-2024-09-24"],
            requestMessage.Headers.GetValues("anthropic-beta")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EnvironmentUpdateParams
        {
            EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            Config = new BetaCloudConfigParams()
            {
                Networking = new BetaLimitedNetworkParams()
                {
                    AllowMcpServers = true,
                    AllowPackageManagers = true,
                    AllowedHosts = ["api.example.com"],
                },
                Packages = new()
                {
                    Apt = ["string"],
                    Cargo = ["string"],
                    Gem = ["string"],
                    Go = ["string"],
                    Npm = ["string"],
                    Pip = ["pandas", "numpy"],
                    Type = BetaPackagesParamsType.Packages,
                },
            },
            Description = "Python environment with data-analysis packages.",
            Metadata = new Dictionary<string, string?>() { { "foo", "string" } },
            Name = "x",
            Scope = EnvironmentUpdateParamsScope.Organization,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        EnvironmentUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class EnvironmentUpdateParamsConfigTest : TestBase
{
    [Fact]
    public void BetaCloudConfigParamsValidationWorks()
    {
        EnvironmentUpdateParamsConfig value = new BetaCloudConfigParams()
        {
            Networking = new BetaLimitedNetworkParams()
            {
                AllowMcpServers = true,
                AllowPackageManagers = true,
                AllowedHosts = ["api.example.com"],
            },
            Packages = new()
            {
                Apt = ["string"],
                Cargo = ["string"],
                Gem = ["string"],
                Go = ["string"],
                Npm = ["string"],
                Pip = ["pandas", "numpy"],
                Type = BetaPackagesParamsType.Packages,
            },
        };
        value.Validate();
    }

    [Fact]
    public void BetaSelfHostedConfigParamsValidationWorks()
    {
        EnvironmentUpdateParamsConfig value = new BetaSelfHostedConfigParams();
        value.Validate();
    }

    [Fact]
    public void BetaCloudConfigParamsSerializationRoundtripWorks()
    {
        EnvironmentUpdateParamsConfig value = new BetaCloudConfigParams()
        {
            Networking = new BetaLimitedNetworkParams()
            {
                AllowMcpServers = true,
                AllowPackageManagers = true,
                AllowedHosts = ["api.example.com"],
            },
            Packages = new()
            {
                Apt = ["string"],
                Cargo = ["string"],
                Gem = ["string"],
                Go = ["string"],
                Npm = ["string"],
                Pip = ["pandas", "numpy"],
                Type = BetaPackagesParamsType.Packages,
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EnvironmentUpdateParamsConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSelfHostedConfigParamsSerializationRoundtripWorks()
    {
        EnvironmentUpdateParamsConfig value = new BetaSelfHostedConfigParams();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EnvironmentUpdateParamsConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class EnvironmentUpdateParamsScopeTest : TestBase
{
    [Theory]
    [InlineData(EnvironmentUpdateParamsScope.Organization)]
    [InlineData(EnvironmentUpdateParamsScope.Account)]
    public void Validation_Works(EnvironmentUpdateParamsScope rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EnvironmentUpdateParamsScope> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EnvironmentUpdateParamsScope>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EnvironmentUpdateParamsScope.Organization)]
    [InlineData(EnvironmentUpdateParamsScope.Account)]
    public void SerializationRoundtrip_Works(EnvironmentUpdateParamsScope rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EnvironmentUpdateParamsScope> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EnvironmentUpdateParamsScope>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EnvironmentUpdateParamsScope>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EnvironmentUpdateParamsScope>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
