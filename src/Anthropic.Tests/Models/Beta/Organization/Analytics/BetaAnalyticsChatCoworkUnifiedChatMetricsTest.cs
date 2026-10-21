using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsChatCoworkUnifiedChatMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsChatCoworkUnifiedChatMetrics
        {
            ConnectorsUsedCount = 0,
            DistinctArtifactsCreatedCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctConversationCount = 0,
            DistinctFilesUploadedCount = 0,
            DistinctProjectsCreatedCount = 0,
            DistinctProjectsUsedCount = 0,
            DistinctSharedArtifactsViewedCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SharedConversationsViewedCount = 0,
            ThinkingMessageCount = 0,
        };

        long expectedConnectorsUsedCount = 0;
        long expectedDistinctArtifactsCreatedCount = 0;
        long expectedDistinctConnectorsUsedCount = 0;
        long expectedDistinctConversationCount = 0;
        long expectedDistinctFilesUploadedCount = 0;
        long expectedDistinctProjectsCreatedCount = 0;
        long expectedDistinctProjectsUsedCount = 0;
        long expectedDistinctSharedArtifactsViewedCount = 0;
        long expectedDistinctSkillsUsedCount = 0;
        long expectedMessageCount = 0;
        long expectedSharedConversationsViewedCount = 0;
        long expectedThinkingMessageCount = 0;

        Assert.Equal(expectedConnectorsUsedCount, model.ConnectorsUsedCount);
        Assert.Equal(expectedDistinctArtifactsCreatedCount, model.DistinctArtifactsCreatedCount);
        Assert.Equal(expectedDistinctConnectorsUsedCount, model.DistinctConnectorsUsedCount);
        Assert.Equal(expectedDistinctConversationCount, model.DistinctConversationCount);
        Assert.Equal(expectedDistinctFilesUploadedCount, model.DistinctFilesUploadedCount);
        Assert.Equal(expectedDistinctProjectsCreatedCount, model.DistinctProjectsCreatedCount);
        Assert.Equal(expectedDistinctProjectsUsedCount, model.DistinctProjectsUsedCount);
        Assert.Equal(
            expectedDistinctSharedArtifactsViewedCount,
            model.DistinctSharedArtifactsViewedCount
        );
        Assert.Equal(expectedDistinctSkillsUsedCount, model.DistinctSkillsUsedCount);
        Assert.Equal(expectedMessageCount, model.MessageCount);
        Assert.Equal(expectedSharedConversationsViewedCount, model.SharedConversationsViewedCount);
        Assert.Equal(expectedThinkingMessageCount, model.ThinkingMessageCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsChatCoworkUnifiedChatMetrics
        {
            ConnectorsUsedCount = 0,
            DistinctArtifactsCreatedCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctConversationCount = 0,
            DistinctFilesUploadedCount = 0,
            DistinctProjectsCreatedCount = 0,
            DistinctProjectsUsedCount = 0,
            DistinctSharedArtifactsViewedCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SharedConversationsViewedCount = 0,
            ThinkingMessageCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsChatCoworkUnifiedChatMetrics>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsChatCoworkUnifiedChatMetrics
        {
            ConnectorsUsedCount = 0,
            DistinctArtifactsCreatedCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctConversationCount = 0,
            DistinctFilesUploadedCount = 0,
            DistinctProjectsCreatedCount = 0,
            DistinctProjectsUsedCount = 0,
            DistinctSharedArtifactsViewedCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SharedConversationsViewedCount = 0,
            ThinkingMessageCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsChatCoworkUnifiedChatMetrics>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedConnectorsUsedCount = 0;
        long expectedDistinctArtifactsCreatedCount = 0;
        long expectedDistinctConnectorsUsedCount = 0;
        long expectedDistinctConversationCount = 0;
        long expectedDistinctFilesUploadedCount = 0;
        long expectedDistinctProjectsCreatedCount = 0;
        long expectedDistinctProjectsUsedCount = 0;
        long expectedDistinctSharedArtifactsViewedCount = 0;
        long expectedDistinctSkillsUsedCount = 0;
        long expectedMessageCount = 0;
        long expectedSharedConversationsViewedCount = 0;
        long expectedThinkingMessageCount = 0;

        Assert.Equal(expectedConnectorsUsedCount, deserialized.ConnectorsUsedCount);
        Assert.Equal(
            expectedDistinctArtifactsCreatedCount,
            deserialized.DistinctArtifactsCreatedCount
        );
        Assert.Equal(expectedDistinctConnectorsUsedCount, deserialized.DistinctConnectorsUsedCount);
        Assert.Equal(expectedDistinctConversationCount, deserialized.DistinctConversationCount);
        Assert.Equal(expectedDistinctFilesUploadedCount, deserialized.DistinctFilesUploadedCount);
        Assert.Equal(
            expectedDistinctProjectsCreatedCount,
            deserialized.DistinctProjectsCreatedCount
        );
        Assert.Equal(expectedDistinctProjectsUsedCount, deserialized.DistinctProjectsUsedCount);
        Assert.Equal(
            expectedDistinctSharedArtifactsViewedCount,
            deserialized.DistinctSharedArtifactsViewedCount
        );
        Assert.Equal(expectedDistinctSkillsUsedCount, deserialized.DistinctSkillsUsedCount);
        Assert.Equal(expectedMessageCount, deserialized.MessageCount);
        Assert.Equal(
            expectedSharedConversationsViewedCount,
            deserialized.SharedConversationsViewedCount
        );
        Assert.Equal(expectedThinkingMessageCount, deserialized.ThinkingMessageCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsChatCoworkUnifiedChatMetrics
        {
            ConnectorsUsedCount = 0,
            DistinctArtifactsCreatedCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctConversationCount = 0,
            DistinctFilesUploadedCount = 0,
            DistinctProjectsCreatedCount = 0,
            DistinctProjectsUsedCount = 0,
            DistinctSharedArtifactsViewedCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SharedConversationsViewedCount = 0,
            ThinkingMessageCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsChatCoworkUnifiedChatMetrics
        {
            ConnectorsUsedCount = 0,
            DistinctArtifactsCreatedCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctConversationCount = 0,
            DistinctFilesUploadedCount = 0,
            DistinctProjectsCreatedCount = 0,
            DistinctProjectsUsedCount = 0,
            DistinctSharedArtifactsViewedCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SharedConversationsViewedCount = 0,
            ThinkingMessageCount = 0,
        };

        BetaAnalyticsChatCoworkUnifiedChatMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}
