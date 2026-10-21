using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.DeploymentRuns;

namespace Anthropic.Tests.Models.Beta.DeploymentRuns;

public class DeploymentRunListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeploymentRunListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Agent = new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 },
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DeploymentID = "deployment_id",
                    Error = new BetaManagedAgentsEnvironmentArchivedRunError("message"),
                    SessionID = "session_id",
                    TriggerContext = new BetaManagedAgentsScheduleTriggerContext(
                        DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")
                    ),
                },
            ],
            NextPage = "next_page",
        };

        List<BetaManagedAgentsDeploymentRun> expectedData =
        [
            new()
            {
                ID = "id",
                Agent = new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 },
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DeploymentID = "deployment_id",
                Error = new BetaManagedAgentsEnvironmentArchivedRunError("message"),
                SessionID = "session_id",
                TriggerContext = new BetaManagedAgentsScheduleTriggerContext(
                    DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")
                ),
            },
        ];
        string expectedNextPage = "next_page";

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
        var model = new DeploymentRunListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Agent = new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 },
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DeploymentID = "deployment_id",
                    Error = new BetaManagedAgentsEnvironmentArchivedRunError("message"),
                    SessionID = "session_id",
                    TriggerContext = new BetaManagedAgentsScheduleTriggerContext(
                        DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")
                    ),
                },
            ],
            NextPage = "next_page",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeploymentRunListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeploymentRunListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Agent = new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 },
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DeploymentID = "deployment_id",
                    Error = new BetaManagedAgentsEnvironmentArchivedRunError("message"),
                    SessionID = "session_id",
                    TriggerContext = new BetaManagedAgentsScheduleTriggerContext(
                        DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")
                    ),
                },
            ],
            NextPage = "next_page",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeploymentRunListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaManagedAgentsDeploymentRun> expectedData =
        [
            new()
            {
                ID = "id",
                Agent = new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 },
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DeploymentID = "deployment_id",
                Error = new BetaManagedAgentsEnvironmentArchivedRunError("message"),
                SessionID = "session_id",
                TriggerContext = new BetaManagedAgentsScheduleTriggerContext(
                    DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")
                ),
            },
        ];
        string expectedNextPage = "next_page";

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
        var model = new DeploymentRunListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Agent = new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 },
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DeploymentID = "deployment_id",
                    Error = new BetaManagedAgentsEnvironmentArchivedRunError("message"),
                    SessionID = "session_id",
                    TriggerContext = new BetaManagedAgentsScheduleTriggerContext(
                        DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")
                    ),
                },
            ],
            NextPage = "next_page",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DeploymentRunListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Agent = new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 },
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DeploymentID = "deployment_id",
                    Error = new BetaManagedAgentsEnvironmentArchivedRunError("message"),
                    SessionID = "session_id",
                    TriggerContext = new BetaManagedAgentsScheduleTriggerContext(
                        DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")
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
        var model = new DeploymentRunListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Agent = new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 },
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DeploymentID = "deployment_id",
                    Error = new BetaManagedAgentsEnvironmentArchivedRunError("message"),
                    SessionID = "session_id",
                    TriggerContext = new BetaManagedAgentsScheduleTriggerContext(
                        DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")
                    ),
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DeploymentRunListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Agent = new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 },
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DeploymentID = "deployment_id",
                    Error = new BetaManagedAgentsEnvironmentArchivedRunError("message"),
                    SessionID = "session_id",
                    TriggerContext = new BetaManagedAgentsScheduleTriggerContext(
                        DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")
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
        var model = new DeploymentRunListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Agent = new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 },
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DeploymentID = "deployment_id",
                    Error = new BetaManagedAgentsEnvironmentArchivedRunError("message"),
                    SessionID = "session_id",
                    TriggerContext = new BetaManagedAgentsScheduleTriggerContext(
                        DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")
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
        var model = new DeploymentRunListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Agent = new() { ID = "agent_011CZkYqphY8vELVzwCUpqiQ", Version = 1 },
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DeploymentID = "deployment_id",
                    Error = new BetaManagedAgentsEnvironmentArchivedRunError("message"),
                    SessionID = "session_id",
                    TriggerContext = new BetaManagedAgentsScheduleTriggerContext(
                        DateTimeOffset.Parse("2019-12-27T18:11:19.117Z")
                    ),
                },
            ],
            NextPage = "next_page",
        };

        DeploymentRunListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
