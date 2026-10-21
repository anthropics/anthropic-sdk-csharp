using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Deployments;
using Anthropic.Models.Beta.Sessions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Deployments;

public class DeploymentListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeploymentListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "depl_011CZkZcDH3vPqd7xnEfwTai",
                    Agent = new() { ID = "agent_011CZkYpogX7uDKUyvBTophP", Version = 1 },
                    ArchivedAt = null,
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Description =
                        "Compiles yesterday's orders into a report every weekday morning.",
                    EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
                    InitialEvents =
                    [
                        new BetaManagedAgentsDeploymentUserMessageEvent(
                            [
                                new BetaManagedAgentsTextBlock(
                                    "Compile yesterday's orders into report.md."
                                ),
                            ]
                        ),
                    ],
                    Metadata = new Dictionary<string, string>(),
                    Name = "Daily order report",
                    PausedReason = new BetaManagedAgentsManualDeploymentPausedReason(),
                    Resources =
                    [
                        new BetaManagedAgentsGitHubRepositoryResourceConfig()
                        {
                            Url = "url",
                            Checkout = new BetaManagedAgentsBranchCheckout("main"),
                            MountPath = "mount_path",
                        },
                    ],
                    Schedule = new()
                    {
                        Expression = "0 9 * * 1-5",
                        Timezone = "America/Los_Angeles",
                        LastRunAt = DateTimeOffset.Parse("2026-03-16T16:00:09Z"),
                        UpcomingRunsAt =
                        [
                            DateTimeOffset.Parse("2026-03-17T16:00:00Z"),
                            DateTimeOffset.Parse("2026-03-18T16:00:00Z"),
                        ],
                    },
                    Status = BetaManagedAgentsDeploymentStatus.Active,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    VaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"],
                    Budget = new(
                        new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }
                    ),
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        List<BetaManagedAgentsDeployment> expectedData =
        [
            new()
            {
                ID = "depl_011CZkZcDH3vPqd7xnEfwTai",
                Agent = new() { ID = "agent_011CZkYpogX7uDKUyvBTophP", Version = 1 },
                ArchivedAt = null,
                CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                Description = "Compiles yesterday's orders into a report every weekday morning.",
                EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
                InitialEvents =
                [
                    new BetaManagedAgentsDeploymentUserMessageEvent(
                        [
                            new BetaManagedAgentsTextBlock(
                                "Compile yesterday's orders into report.md."
                            ),
                        ]
                    ),
                ],
                Metadata = new Dictionary<string, string>(),
                Name = "Daily order report",
                PausedReason = new BetaManagedAgentsManualDeploymentPausedReason(),
                Resources =
                [
                    new BetaManagedAgentsGitHubRepositoryResourceConfig()
                    {
                        Url = "url",
                        Checkout = new BetaManagedAgentsBranchCheckout("main"),
                        MountPath = "mount_path",
                    },
                ],
                Schedule = new()
                {
                    Expression = "0 9 * * 1-5",
                    Timezone = "America/Los_Angeles",
                    LastRunAt = DateTimeOffset.Parse("2026-03-16T16:00:09Z"),
                    UpcomingRunsAt =
                    [
                        DateTimeOffset.Parse("2026-03-17T16:00:00Z"),
                        DateTimeOffset.Parse("2026-03-18T16:00:00Z"),
                    ],
                },
                Status = BetaManagedAgentsDeploymentStatus.Active,
                UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                VaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"],
                Budget = new(
                    new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }
                ),
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
        var model = new DeploymentListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "depl_011CZkZcDH3vPqd7xnEfwTai",
                    Agent = new() { ID = "agent_011CZkYpogX7uDKUyvBTophP", Version = 1 },
                    ArchivedAt = null,
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Description =
                        "Compiles yesterday's orders into a report every weekday morning.",
                    EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
                    InitialEvents =
                    [
                        new BetaManagedAgentsDeploymentUserMessageEvent(
                            [
                                new BetaManagedAgentsTextBlock(
                                    "Compile yesterday's orders into report.md."
                                ),
                            ]
                        ),
                    ],
                    Metadata = new Dictionary<string, string>(),
                    Name = "Daily order report",
                    PausedReason = new BetaManagedAgentsManualDeploymentPausedReason(),
                    Resources =
                    [
                        new BetaManagedAgentsGitHubRepositoryResourceConfig()
                        {
                            Url = "url",
                            Checkout = new BetaManagedAgentsBranchCheckout("main"),
                            MountPath = "mount_path",
                        },
                    ],
                    Schedule = new()
                    {
                        Expression = "0 9 * * 1-5",
                        Timezone = "America/Los_Angeles",
                        LastRunAt = DateTimeOffset.Parse("2026-03-16T16:00:09Z"),
                        UpcomingRunsAt =
                        [
                            DateTimeOffset.Parse("2026-03-17T16:00:00Z"),
                            DateTimeOffset.Parse("2026-03-18T16:00:00Z"),
                        ],
                    },
                    Status = BetaManagedAgentsDeploymentStatus.Active,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    VaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"],
                    Budget = new(
                        new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }
                    ),
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeploymentListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeploymentListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "depl_011CZkZcDH3vPqd7xnEfwTai",
                    Agent = new() { ID = "agent_011CZkYpogX7uDKUyvBTophP", Version = 1 },
                    ArchivedAt = null,
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Description =
                        "Compiles yesterday's orders into a report every weekday morning.",
                    EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
                    InitialEvents =
                    [
                        new BetaManagedAgentsDeploymentUserMessageEvent(
                            [
                                new BetaManagedAgentsTextBlock(
                                    "Compile yesterday's orders into report.md."
                                ),
                            ]
                        ),
                    ],
                    Metadata = new Dictionary<string, string>(),
                    Name = "Daily order report",
                    PausedReason = new BetaManagedAgentsManualDeploymentPausedReason(),
                    Resources =
                    [
                        new BetaManagedAgentsGitHubRepositoryResourceConfig()
                        {
                            Url = "url",
                            Checkout = new BetaManagedAgentsBranchCheckout("main"),
                            MountPath = "mount_path",
                        },
                    ],
                    Schedule = new()
                    {
                        Expression = "0 9 * * 1-5",
                        Timezone = "America/Los_Angeles",
                        LastRunAt = DateTimeOffset.Parse("2026-03-16T16:00:09Z"),
                        UpcomingRunsAt =
                        [
                            DateTimeOffset.Parse("2026-03-17T16:00:00Z"),
                            DateTimeOffset.Parse("2026-03-18T16:00:00Z"),
                        ],
                    },
                    Status = BetaManagedAgentsDeploymentStatus.Active,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    VaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"],
                    Budget = new(
                        new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }
                    ),
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeploymentListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaManagedAgentsDeployment> expectedData =
        [
            new()
            {
                ID = "depl_011CZkZcDH3vPqd7xnEfwTai",
                Agent = new() { ID = "agent_011CZkYpogX7uDKUyvBTophP", Version = 1 },
                ArchivedAt = null,
                CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                Description = "Compiles yesterday's orders into a report every weekday morning.",
                EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
                InitialEvents =
                [
                    new BetaManagedAgentsDeploymentUserMessageEvent(
                        [
                            new BetaManagedAgentsTextBlock(
                                "Compile yesterday's orders into report.md."
                            ),
                        ]
                    ),
                ],
                Metadata = new Dictionary<string, string>(),
                Name = "Daily order report",
                PausedReason = new BetaManagedAgentsManualDeploymentPausedReason(),
                Resources =
                [
                    new BetaManagedAgentsGitHubRepositoryResourceConfig()
                    {
                        Url = "url",
                        Checkout = new BetaManagedAgentsBranchCheckout("main"),
                        MountPath = "mount_path",
                    },
                ],
                Schedule = new()
                {
                    Expression = "0 9 * * 1-5",
                    Timezone = "America/Los_Angeles",
                    LastRunAt = DateTimeOffset.Parse("2026-03-16T16:00:09Z"),
                    UpcomingRunsAt =
                    [
                        DateTimeOffset.Parse("2026-03-17T16:00:00Z"),
                        DateTimeOffset.Parse("2026-03-18T16:00:00Z"),
                    ],
                },
                Status = BetaManagedAgentsDeploymentStatus.Active,
                UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                VaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"],
                Budget = new(
                    new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }
                ),
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
        var model = new DeploymentListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "depl_011CZkZcDH3vPqd7xnEfwTai",
                    Agent = new() { ID = "agent_011CZkYpogX7uDKUyvBTophP", Version = 1 },
                    ArchivedAt = null,
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Description =
                        "Compiles yesterday's orders into a report every weekday morning.",
                    EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
                    InitialEvents =
                    [
                        new BetaManagedAgentsDeploymentUserMessageEvent(
                            [
                                new BetaManagedAgentsTextBlock(
                                    "Compile yesterday's orders into report.md."
                                ),
                            ]
                        ),
                    ],
                    Metadata = new Dictionary<string, string>(),
                    Name = "Daily order report",
                    PausedReason = new BetaManagedAgentsManualDeploymentPausedReason(),
                    Resources =
                    [
                        new BetaManagedAgentsGitHubRepositoryResourceConfig()
                        {
                            Url = "url",
                            Checkout = new BetaManagedAgentsBranchCheckout("main"),
                            MountPath = "mount_path",
                        },
                    ],
                    Schedule = new()
                    {
                        Expression = "0 9 * * 1-5",
                        Timezone = "America/Los_Angeles",
                        LastRunAt = DateTimeOffset.Parse("2026-03-16T16:00:09Z"),
                        UpcomingRunsAt =
                        [
                            DateTimeOffset.Parse("2026-03-17T16:00:00Z"),
                            DateTimeOffset.Parse("2026-03-18T16:00:00Z"),
                        ],
                    },
                    Status = BetaManagedAgentsDeploymentStatus.Active,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    VaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"],
                    Budget = new(
                        new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }
                    ),
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DeploymentListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "depl_011CZkZcDH3vPqd7xnEfwTai",
                    Agent = new() { ID = "agent_011CZkYpogX7uDKUyvBTophP", Version = 1 },
                    ArchivedAt = null,
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Description =
                        "Compiles yesterday's orders into a report every weekday morning.",
                    EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
                    InitialEvents =
                    [
                        new BetaManagedAgentsDeploymentUserMessageEvent(
                            [
                                new BetaManagedAgentsTextBlock(
                                    "Compile yesterday's orders into report.md."
                                ),
                            ]
                        ),
                    ],
                    Metadata = new Dictionary<string, string>(),
                    Name = "Daily order report",
                    PausedReason = new BetaManagedAgentsManualDeploymentPausedReason(),
                    Resources =
                    [
                        new BetaManagedAgentsGitHubRepositoryResourceConfig()
                        {
                            Url = "url",
                            Checkout = new BetaManagedAgentsBranchCheckout("main"),
                            MountPath = "mount_path",
                        },
                    ],
                    Schedule = new()
                    {
                        Expression = "0 9 * * 1-5",
                        Timezone = "America/Los_Angeles",
                        LastRunAt = DateTimeOffset.Parse("2026-03-16T16:00:09Z"),
                        UpcomingRunsAt =
                        [
                            DateTimeOffset.Parse("2026-03-17T16:00:00Z"),
                            DateTimeOffset.Parse("2026-03-18T16:00:00Z"),
                        ],
                    },
                    Status = BetaManagedAgentsDeploymentStatus.Active,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    VaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"],
                    Budget = new(
                        new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }
                    ),
                },
            ],
        };

        Assert.Null(model.NextPage);
        Assert.False(model.RawData.ContainsKey("next_page"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DeploymentListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "depl_011CZkZcDH3vPqd7xnEfwTai",
                    Agent = new() { ID = "agent_011CZkYpogX7uDKUyvBTophP", Version = 1 },
                    ArchivedAt = null,
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Description =
                        "Compiles yesterday's orders into a report every weekday morning.",
                    EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
                    InitialEvents =
                    [
                        new BetaManagedAgentsDeploymentUserMessageEvent(
                            [
                                new BetaManagedAgentsTextBlock(
                                    "Compile yesterday's orders into report.md."
                                ),
                            ]
                        ),
                    ],
                    Metadata = new Dictionary<string, string>(),
                    Name = "Daily order report",
                    PausedReason = new BetaManagedAgentsManualDeploymentPausedReason(),
                    Resources =
                    [
                        new BetaManagedAgentsGitHubRepositoryResourceConfig()
                        {
                            Url = "url",
                            Checkout = new BetaManagedAgentsBranchCheckout("main"),
                            MountPath = "mount_path",
                        },
                    ],
                    Schedule = new()
                    {
                        Expression = "0 9 * * 1-5",
                        Timezone = "America/Los_Angeles",
                        LastRunAt = DateTimeOffset.Parse("2026-03-16T16:00:09Z"),
                        UpcomingRunsAt =
                        [
                            DateTimeOffset.Parse("2026-03-17T16:00:00Z"),
                            DateTimeOffset.Parse("2026-03-18T16:00:00Z"),
                        ],
                    },
                    Status = BetaManagedAgentsDeploymentStatus.Active,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    VaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"],
                    Budget = new(
                        new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }
                    ),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DeploymentListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "depl_011CZkZcDH3vPqd7xnEfwTai",
                    Agent = new() { ID = "agent_011CZkYpogX7uDKUyvBTophP", Version = 1 },
                    ArchivedAt = null,
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Description =
                        "Compiles yesterday's orders into a report every weekday morning.",
                    EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
                    InitialEvents =
                    [
                        new BetaManagedAgentsDeploymentUserMessageEvent(
                            [
                                new BetaManagedAgentsTextBlock(
                                    "Compile yesterday's orders into report.md."
                                ),
                            ]
                        ),
                    ],
                    Metadata = new Dictionary<string, string>(),
                    Name = "Daily order report",
                    PausedReason = new BetaManagedAgentsManualDeploymentPausedReason(),
                    Resources =
                    [
                        new BetaManagedAgentsGitHubRepositoryResourceConfig()
                        {
                            Url = "url",
                            Checkout = new BetaManagedAgentsBranchCheckout("main"),
                            MountPath = "mount_path",
                        },
                    ],
                    Schedule = new()
                    {
                        Expression = "0 9 * * 1-5",
                        Timezone = "America/Los_Angeles",
                        LastRunAt = DateTimeOffset.Parse("2026-03-16T16:00:09Z"),
                        UpcomingRunsAt =
                        [
                            DateTimeOffset.Parse("2026-03-17T16:00:00Z"),
                            DateTimeOffset.Parse("2026-03-18T16:00:00Z"),
                        ],
                    },
                    Status = BetaManagedAgentsDeploymentStatus.Active,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    VaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"],
                    Budget = new(
                        new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }
                    ),
                },
            ],

            NextPage = null,
        };

        Assert.Null(model.NextPage);
        Assert.True(model.RawData.ContainsKey("next_page"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DeploymentListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "depl_011CZkZcDH3vPqd7xnEfwTai",
                    Agent = new() { ID = "agent_011CZkYpogX7uDKUyvBTophP", Version = 1 },
                    ArchivedAt = null,
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Description =
                        "Compiles yesterday's orders into a report every weekday morning.",
                    EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
                    InitialEvents =
                    [
                        new BetaManagedAgentsDeploymentUserMessageEvent(
                            [
                                new BetaManagedAgentsTextBlock(
                                    "Compile yesterday's orders into report.md."
                                ),
                            ]
                        ),
                    ],
                    Metadata = new Dictionary<string, string>(),
                    Name = "Daily order report",
                    PausedReason = new BetaManagedAgentsManualDeploymentPausedReason(),
                    Resources =
                    [
                        new BetaManagedAgentsGitHubRepositoryResourceConfig()
                        {
                            Url = "url",
                            Checkout = new BetaManagedAgentsBranchCheckout("main"),
                            MountPath = "mount_path",
                        },
                    ],
                    Schedule = new()
                    {
                        Expression = "0 9 * * 1-5",
                        Timezone = "America/Los_Angeles",
                        LastRunAt = DateTimeOffset.Parse("2026-03-16T16:00:09Z"),
                        UpcomingRunsAt =
                        [
                            DateTimeOffset.Parse("2026-03-17T16:00:00Z"),
                            DateTimeOffset.Parse("2026-03-18T16:00:00Z"),
                        ],
                    },
                    Status = BetaManagedAgentsDeploymentStatus.Active,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    VaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"],
                    Budget = new(
                        new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }
                    ),
                },
            ],

            NextPage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeploymentListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "depl_011CZkZcDH3vPqd7xnEfwTai",
                    Agent = new() { ID = "agent_011CZkYpogX7uDKUyvBTophP", Version = 1 },
                    ArchivedAt = null,
                    CreatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    Description =
                        "Compiles yesterday's orders into a report every weekday morning.",
                    EnvironmentID = "env_011CZkZ9X2dpNyB7HsEFoRfW",
                    InitialEvents =
                    [
                        new BetaManagedAgentsDeploymentUserMessageEvent(
                            [
                                new BetaManagedAgentsTextBlock(
                                    "Compile yesterday's orders into report.md."
                                ),
                            ]
                        ),
                    ],
                    Metadata = new Dictionary<string, string>(),
                    Name = "Daily order report",
                    PausedReason = new BetaManagedAgentsManualDeploymentPausedReason(),
                    Resources =
                    [
                        new BetaManagedAgentsGitHubRepositoryResourceConfig()
                        {
                            Url = "url",
                            Checkout = new BetaManagedAgentsBranchCheckout("main"),
                            MountPath = "mount_path",
                        },
                    ],
                    Schedule = new()
                    {
                        Expression = "0 9 * * 1-5",
                        Timezone = "America/Los_Angeles",
                        LastRunAt = DateTimeOffset.Parse("2026-03-16T16:00:09Z"),
                        UpcomingRunsAt =
                        [
                            DateTimeOffset.Parse("2026-03-17T16:00:00Z"),
                            DateTimeOffset.Parse("2026-03-18T16:00:00Z"),
                        ],
                    },
                    Status = BetaManagedAgentsDeploymentStatus.Active,
                    UpdatedAt = DateTimeOffset.Parse("2026-03-15T10:00:00Z"),
                    VaultIds = ["vlt_011CZkZDLs7fYzm1hXNPeRjv"],
                    Budget = new(
                        new BetaMonetaryAmount() { Amount = "2500", Currency = BetaCurrency.Usd }
                    ),
                },
            ],
            NextPage = "page_MjAyNS0wNS0xNFQwMDowMDowMFo=",
        };

        DeploymentListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
