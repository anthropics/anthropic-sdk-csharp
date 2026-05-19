using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Environments;

namespace Anthropic.Tests.Models.Beta.Environments;

public class EnvironmentCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EnvironmentCreateParams
        {
            Name = "python-data-analysis",
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
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Scope = Scope.Organization,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        string expectedName = "python-data-analysis";
        Config expectedConfig = new BetaCloudConfigParams()
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
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, Scope> expectedScope = Scope.Organization;
        List<ApiEnum<string, AnthropicBeta>> expectedBetas =
        [
            AnthropicBeta.MessageBatches2024_09_24,
        ];

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedConfig, parameters.Config);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
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
        var parameters = new EnvironmentCreateParams
        {
            Name = "python-data-analysis",
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
            Scope = Scope.Organization,
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Betas);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-beta"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EnvironmentCreateParams
        {
            Name = "python-data-analysis",
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
            Scope = Scope.Organization,

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
        var parameters = new EnvironmentCreateParams
        {
            Name = "python-data-analysis",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        Assert.Null(parameters.Config);
        Assert.False(parameters.RawBodyData.ContainsKey("config"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Scope);
        Assert.False(parameters.RawBodyData.ContainsKey("scope"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new EnvironmentCreateParams
        {
            Name = "python-data-analysis",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Betas = [AnthropicBeta.MessageBatches2024_09_24],

            Config = null,
            Description = null,
            Scope = null,
        };

        Assert.Null(parameters.Config);
        Assert.True(parameters.RawBodyData.ContainsKey("config"));
        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Scope);
        Assert.True(parameters.RawBodyData.ContainsKey("scope"));
    }

    [Fact]
    public void Url_Works()
    {
        EnvironmentCreateParams parameters = new() { Name = "python-data-analysis" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.anthropic.com/v1/environments?beta=true"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        EnvironmentCreateParams parameters = new()
        {
            Name = "python-data-analysis",
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
        var parameters = new EnvironmentCreateParams
        {
            Name = "python-data-analysis",
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
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Scope = Scope.Organization,
            Betas = [AnthropicBeta.MessageBatches2024_09_24],
        };

        EnvironmentCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ConfigTest : TestBase
{
    [Fact]
    public void BetaCloudConfigParamsValidationWorks()
    {
        Config value = new BetaCloudConfigParams()
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
        Config value = new BetaSelfHostedConfigParams();
        value.Validate();
    }

    [Fact]
    public void BetaCloudConfigParamsSerializationRoundtripWorks()
    {
        Config value = new BetaCloudConfigParams()
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
        var deserialized = JsonSerializer.Deserialize<Config>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSelfHostedConfigParamsSerializationRoundtripWorks()
    {
        Config value = new BetaSelfHostedConfigParams();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Config>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ScopeTest : TestBase
{
    [Theory]
    [InlineData(Scope.Organization)]
    [InlineData(Scope.Account)]
    public void Validation_Works(Scope rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Scope> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Scope>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Scope.Organization)]
    [InlineData(Scope.Account)]
    public void SerializationRoundtrip_Works(Scope rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Scope> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Scope>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Scope>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Scope>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
