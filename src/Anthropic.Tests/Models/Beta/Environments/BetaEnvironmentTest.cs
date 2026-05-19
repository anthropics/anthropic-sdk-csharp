using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Environments;

namespace Anthropic.Tests.Models.Beta.Environments;

public class BetaEnvironmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaEnvironment
        {
            ID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            ArchivedAt = null,
            Config = new BetaCloudConfig()
            {
                Networking = new BetaLimitedNetwork()
                {
                    AllowMcpServers = false,
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
                    Type = Type.Packages,
                },
            },
            CreatedAt = "2026-03-15T10:00:00Z",
            Description = "Python environment with data-analysis packages.",
            Metadata = new Dictionary<string, string>(),
            Name = "python-data-analysis",
            UpdatedAt = "2026-03-15T10:00:00Z",
            Scope = BetaEnvironmentScope.Organization,
        };

        string expectedID = "env_011CZkZ9X2dpNyB7HsEFoRfW";
        BetaEnvironmentConfig expectedConfig = new BetaCloudConfig()
        {
            Networking = new BetaLimitedNetwork()
            {
                AllowMcpServers = false,
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
                Type = Type.Packages,
            },
        };
        string expectedCreatedAt = "2026-03-15T10:00:00Z";
        string expectedDescription = "Python environment with data-analysis packages.";
        Dictionary<string, string> expectedMetadata = new();
        string expectedName = "python-data-analysis";
        JsonElement expectedType = JsonSerializer.SerializeToElement("environment");
        string expectedUpdatedAt = "2026-03-15T10:00:00Z";
        ApiEnum<string, BetaEnvironmentScope> expectedScope = BetaEnvironmentScope.Organization;

        Assert.Equal(expectedID, model.ID);
        Assert.Null(model.ArchivedAt);
        Assert.Equal(expectedConfig, model.Config);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, model.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedScope, model.Scope);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaEnvironment
        {
            ID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            ArchivedAt = null,
            Config = new BetaCloudConfig()
            {
                Networking = new BetaLimitedNetwork()
                {
                    AllowMcpServers = false,
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
                    Type = Type.Packages,
                },
            },
            CreatedAt = "2026-03-15T10:00:00Z",
            Description = "Python environment with data-analysis packages.",
            Metadata = new Dictionary<string, string>(),
            Name = "python-data-analysis",
            UpdatedAt = "2026-03-15T10:00:00Z",
            Scope = BetaEnvironmentScope.Organization,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaEnvironment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaEnvironment
        {
            ID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            ArchivedAt = null,
            Config = new BetaCloudConfig()
            {
                Networking = new BetaLimitedNetwork()
                {
                    AllowMcpServers = false,
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
                    Type = Type.Packages,
                },
            },
            CreatedAt = "2026-03-15T10:00:00Z",
            Description = "Python environment with data-analysis packages.",
            Metadata = new Dictionary<string, string>(),
            Name = "python-data-analysis",
            UpdatedAt = "2026-03-15T10:00:00Z",
            Scope = BetaEnvironmentScope.Organization,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaEnvironment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "env_011CZkZ9X2dpNyB7HsEFoRfW";
        BetaEnvironmentConfig expectedConfig = new BetaCloudConfig()
        {
            Networking = new BetaLimitedNetwork()
            {
                AllowMcpServers = false,
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
                Type = Type.Packages,
            },
        };
        string expectedCreatedAt = "2026-03-15T10:00:00Z";
        string expectedDescription = "Python environment with data-analysis packages.";
        Dictionary<string, string> expectedMetadata = new();
        string expectedName = "python-data-analysis";
        JsonElement expectedType = JsonSerializer.SerializeToElement("environment");
        string expectedUpdatedAt = "2026-03-15T10:00:00Z";
        ApiEnum<string, BetaEnvironmentScope> expectedScope = BetaEnvironmentScope.Organization;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Null(deserialized.ArchivedAt);
        Assert.Equal(expectedConfig, deserialized.Config);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedScope, deserialized.Scope);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaEnvironment
        {
            ID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            ArchivedAt = null,
            Config = new BetaCloudConfig()
            {
                Networking = new BetaLimitedNetwork()
                {
                    AllowMcpServers = false,
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
                    Type = Type.Packages,
                },
            },
            CreatedAt = "2026-03-15T10:00:00Z",
            Description = "Python environment with data-analysis packages.",
            Metadata = new Dictionary<string, string>(),
            Name = "python-data-analysis",
            UpdatedAt = "2026-03-15T10:00:00Z",
            Scope = BetaEnvironmentScope.Organization,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaEnvironment
        {
            ID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            ArchivedAt = null,
            Config = new BetaCloudConfig()
            {
                Networking = new BetaLimitedNetwork()
                {
                    AllowMcpServers = false,
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
                    Type = Type.Packages,
                },
            },
            CreatedAt = "2026-03-15T10:00:00Z",
            Description = "Python environment with data-analysis packages.",
            Metadata = new Dictionary<string, string>(),
            Name = "python-data-analysis",
            UpdatedAt = "2026-03-15T10:00:00Z",
        };

        Assert.Null(model.Scope);
        Assert.False(model.RawData.ContainsKey("scope"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaEnvironment
        {
            ID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            ArchivedAt = null,
            Config = new BetaCloudConfig()
            {
                Networking = new BetaLimitedNetwork()
                {
                    AllowMcpServers = false,
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
                    Type = Type.Packages,
                },
            },
            CreatedAt = "2026-03-15T10:00:00Z",
            Description = "Python environment with data-analysis packages.",
            Metadata = new Dictionary<string, string>(),
            Name = "python-data-analysis",
            UpdatedAt = "2026-03-15T10:00:00Z",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaEnvironment
        {
            ID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            ArchivedAt = null,
            Config = new BetaCloudConfig()
            {
                Networking = new BetaLimitedNetwork()
                {
                    AllowMcpServers = false,
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
                    Type = Type.Packages,
                },
            },
            CreatedAt = "2026-03-15T10:00:00Z",
            Description = "Python environment with data-analysis packages.",
            Metadata = new Dictionary<string, string>(),
            Name = "python-data-analysis",
            UpdatedAt = "2026-03-15T10:00:00Z",

            // Null should be interpreted as omitted for these properties
            Scope = null,
        };

        Assert.Null(model.Scope);
        Assert.False(model.RawData.ContainsKey("scope"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaEnvironment
        {
            ID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            ArchivedAt = null,
            Config = new BetaCloudConfig()
            {
                Networking = new BetaLimitedNetwork()
                {
                    AllowMcpServers = false,
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
                    Type = Type.Packages,
                },
            },
            CreatedAt = "2026-03-15T10:00:00Z",
            Description = "Python environment with data-analysis packages.",
            Metadata = new Dictionary<string, string>(),
            Name = "python-data-analysis",
            UpdatedAt = "2026-03-15T10:00:00Z",

            // Null should be interpreted as omitted for these properties
            Scope = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaEnvironment
        {
            ID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            ArchivedAt = null,
            Config = new BetaCloudConfig()
            {
                Networking = new BetaLimitedNetwork()
                {
                    AllowMcpServers = false,
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
                    Type = Type.Packages,
                },
            },
            CreatedAt = "2026-03-15T10:00:00Z",
            Description = "Python environment with data-analysis packages.",
            Metadata = new Dictionary<string, string>(),
            Name = "python-data-analysis",
            UpdatedAt = "2026-03-15T10:00:00Z",
            Scope = BetaEnvironmentScope.Organization,
        };

        BetaEnvironment copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaEnvironmentConfigTest : TestBase
{
    [Fact]
    public void BetaCloudValidationWorks()
    {
        BetaEnvironmentConfig value = new BetaCloudConfig()
        {
            Networking = new BetaLimitedNetwork()
            {
                AllowMcpServers = false,
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
                Type = Type.Packages,
            },
        };
        value.Validate();
    }

    [Fact]
    public void BetaSelfHostedValidationWorks()
    {
        BetaEnvironmentConfig value = new BetaSelfHostedConfig();
        value.Validate();
    }

    [Fact]
    public void BetaCloudSerializationRoundtripWorks()
    {
        BetaEnvironmentConfig value = new BetaCloudConfig()
        {
            Networking = new BetaLimitedNetwork()
            {
                AllowMcpServers = false,
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
                Type = Type.Packages,
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaEnvironmentConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSelfHostedSerializationRoundtripWorks()
    {
        BetaEnvironmentConfig value = new BetaSelfHostedConfig();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaEnvironmentConfig>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BetaEnvironmentScopeTest : TestBase
{
    [Theory]
    [InlineData(BetaEnvironmentScope.Organization)]
    [InlineData(BetaEnvironmentScope.Account)]
    public void Validation_Works(BetaEnvironmentScope rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaEnvironmentScope> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaEnvironmentScope>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaEnvironmentScope.Organization)]
    [InlineData(BetaEnvironmentScope.Account)]
    public void SerializationRoundtrip_Works(BetaEnvironmentScope rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaEnvironmentScope> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaEnvironmentScope>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaEnvironmentScope>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaEnvironmentScope>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
