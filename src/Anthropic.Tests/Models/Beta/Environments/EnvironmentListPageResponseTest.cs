using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Environments;

namespace Anthropic.Tests.Models.Beta.Environments;

public class EnvironmentListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EnvironmentListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        List<BetaEnvironment> expectedData =
        [
            new()
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
            },
        ];
        string expectedNextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedNextPage, model.NextPage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EnvironmentListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EnvironmentListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EnvironmentListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EnvironmentListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaEnvironment> expectedData =
        [
            new()
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
            },
        ];
        string expectedNextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=";

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedNextPage, deserialized.NextPage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EnvironmentListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EnvironmentListPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        EnvironmentListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
