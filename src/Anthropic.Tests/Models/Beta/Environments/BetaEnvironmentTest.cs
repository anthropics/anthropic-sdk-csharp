using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
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
            Config = new()
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

        string expectedID = "env_011CZkZ9X2dpNyB7HsEFoRfW";
        BetaCloudConfig expectedConfig = new()
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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaEnvironment
        {
            ID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            ArchivedAt = null,
            Config = new()
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
            Config = new()
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaEnvironment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "env_011CZkZ9X2dpNyB7HsEFoRfW";
        BetaCloudConfig expectedConfig = new()
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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaEnvironment
        {
            ID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            ArchivedAt = null,
            Config = new()
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
    public void CopyConstructor_Works()
    {
        var model = new BetaEnvironment
        {
            ID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
            ArchivedAt = null,
            Config = new()
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

        BetaEnvironment copied = new(model);

        Assert.Equal(model, copied);
    }
}
