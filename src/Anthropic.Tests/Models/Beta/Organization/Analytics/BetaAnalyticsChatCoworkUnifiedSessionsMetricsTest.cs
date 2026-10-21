using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsChatCoworkUnifiedSessionsMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsChatCoworkUnifiedSessionsMetrics
        {
            ActionCount = 0,
            ArtifactsCreatedCount = 0,
            ConnectorsUsedCount = 0,
            DispatchTurnCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctPluginsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            EditToolCount = 0,
            FileEditCount = 0,
            MessageCount = 0,
            MultiEditToolCount = 0,
            NotebookEditToolCount = 0,
            PluginsUsedCount = 0,
            SessionsWithFileEditsCount = 0,
            SkillsUsedCount = 0,
            WriteToolCount = 0,
        };

        long expectedActionCount = 0;
        long expectedArtifactsCreatedCount = 0;
        long expectedConnectorsUsedCount = 0;
        long expectedDispatchTurnCount = 0;
        long expectedDistinctConnectorsUsedCount = 0;
        long expectedDistinctPluginsUsedCount = 0;
        long expectedDistinctSessionCount = 0;
        long expectedDistinctSkillsUsedCount = 0;
        long expectedEditToolCount = 0;
        long expectedFileEditCount = 0;
        long expectedMessageCount = 0;
        long expectedMultiEditToolCount = 0;
        long expectedNotebookEditToolCount = 0;
        long expectedPluginsUsedCount = 0;
        long expectedSessionsWithFileEditsCount = 0;
        long expectedSkillsUsedCount = 0;
        long expectedWriteToolCount = 0;

        Assert.Equal(expectedActionCount, model.ActionCount);
        Assert.Equal(expectedArtifactsCreatedCount, model.ArtifactsCreatedCount);
        Assert.Equal(expectedConnectorsUsedCount, model.ConnectorsUsedCount);
        Assert.Equal(expectedDispatchTurnCount, model.DispatchTurnCount);
        Assert.Equal(expectedDistinctConnectorsUsedCount, model.DistinctConnectorsUsedCount);
        Assert.Equal(expectedDistinctPluginsUsedCount, model.DistinctPluginsUsedCount);
        Assert.Equal(expectedDistinctSessionCount, model.DistinctSessionCount);
        Assert.Equal(expectedDistinctSkillsUsedCount, model.DistinctSkillsUsedCount);
        Assert.Equal(expectedEditToolCount, model.EditToolCount);
        Assert.Equal(expectedFileEditCount, model.FileEditCount);
        Assert.Equal(expectedMessageCount, model.MessageCount);
        Assert.Equal(expectedMultiEditToolCount, model.MultiEditToolCount);
        Assert.Equal(expectedNotebookEditToolCount, model.NotebookEditToolCount);
        Assert.Equal(expectedPluginsUsedCount, model.PluginsUsedCount);
        Assert.Equal(expectedSessionsWithFileEditsCount, model.SessionsWithFileEditsCount);
        Assert.Equal(expectedSkillsUsedCount, model.SkillsUsedCount);
        Assert.Equal(expectedWriteToolCount, model.WriteToolCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsChatCoworkUnifiedSessionsMetrics
        {
            ActionCount = 0,
            ArtifactsCreatedCount = 0,
            ConnectorsUsedCount = 0,
            DispatchTurnCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctPluginsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            EditToolCount = 0,
            FileEditCount = 0,
            MessageCount = 0,
            MultiEditToolCount = 0,
            NotebookEditToolCount = 0,
            PluginsUsedCount = 0,
            SessionsWithFileEditsCount = 0,
            SkillsUsedCount = 0,
            WriteToolCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaAnalyticsChatCoworkUnifiedSessionsMetrics>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsChatCoworkUnifiedSessionsMetrics
        {
            ActionCount = 0,
            ArtifactsCreatedCount = 0,
            ConnectorsUsedCount = 0,
            DispatchTurnCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctPluginsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            EditToolCount = 0,
            FileEditCount = 0,
            MessageCount = 0,
            MultiEditToolCount = 0,
            NotebookEditToolCount = 0,
            PluginsUsedCount = 0,
            SessionsWithFileEditsCount = 0,
            SkillsUsedCount = 0,
            WriteToolCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaAnalyticsChatCoworkUnifiedSessionsMetrics>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        long expectedActionCount = 0;
        long expectedArtifactsCreatedCount = 0;
        long expectedConnectorsUsedCount = 0;
        long expectedDispatchTurnCount = 0;
        long expectedDistinctConnectorsUsedCount = 0;
        long expectedDistinctPluginsUsedCount = 0;
        long expectedDistinctSessionCount = 0;
        long expectedDistinctSkillsUsedCount = 0;
        long expectedEditToolCount = 0;
        long expectedFileEditCount = 0;
        long expectedMessageCount = 0;
        long expectedMultiEditToolCount = 0;
        long expectedNotebookEditToolCount = 0;
        long expectedPluginsUsedCount = 0;
        long expectedSessionsWithFileEditsCount = 0;
        long expectedSkillsUsedCount = 0;
        long expectedWriteToolCount = 0;

        Assert.Equal(expectedActionCount, deserialized.ActionCount);
        Assert.Equal(expectedArtifactsCreatedCount, deserialized.ArtifactsCreatedCount);
        Assert.Equal(expectedConnectorsUsedCount, deserialized.ConnectorsUsedCount);
        Assert.Equal(expectedDispatchTurnCount, deserialized.DispatchTurnCount);
        Assert.Equal(expectedDistinctConnectorsUsedCount, deserialized.DistinctConnectorsUsedCount);
        Assert.Equal(expectedDistinctPluginsUsedCount, deserialized.DistinctPluginsUsedCount);
        Assert.Equal(expectedDistinctSessionCount, deserialized.DistinctSessionCount);
        Assert.Equal(expectedDistinctSkillsUsedCount, deserialized.DistinctSkillsUsedCount);
        Assert.Equal(expectedEditToolCount, deserialized.EditToolCount);
        Assert.Equal(expectedFileEditCount, deserialized.FileEditCount);
        Assert.Equal(expectedMessageCount, deserialized.MessageCount);
        Assert.Equal(expectedMultiEditToolCount, deserialized.MultiEditToolCount);
        Assert.Equal(expectedNotebookEditToolCount, deserialized.NotebookEditToolCount);
        Assert.Equal(expectedPluginsUsedCount, deserialized.PluginsUsedCount);
        Assert.Equal(expectedSessionsWithFileEditsCount, deserialized.SessionsWithFileEditsCount);
        Assert.Equal(expectedSkillsUsedCount, deserialized.SkillsUsedCount);
        Assert.Equal(expectedWriteToolCount, deserialized.WriteToolCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsChatCoworkUnifiedSessionsMetrics
        {
            ActionCount = 0,
            ArtifactsCreatedCount = 0,
            ConnectorsUsedCount = 0,
            DispatchTurnCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctPluginsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            EditToolCount = 0,
            FileEditCount = 0,
            MessageCount = 0,
            MultiEditToolCount = 0,
            NotebookEditToolCount = 0,
            PluginsUsedCount = 0,
            SessionsWithFileEditsCount = 0,
            SkillsUsedCount = 0,
            WriteToolCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsChatCoworkUnifiedSessionsMetrics
        {
            ActionCount = 0,
            ArtifactsCreatedCount = 0,
            ConnectorsUsedCount = 0,
            DispatchTurnCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctPluginsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            EditToolCount = 0,
            FileEditCount = 0,
            MessageCount = 0,
            MultiEditToolCount = 0,
            NotebookEditToolCount = 0,
            PluginsUsedCount = 0,
            SessionsWithFileEditsCount = 0,
            SkillsUsedCount = 0,
            WriteToolCount = 0,
        };

        BetaAnalyticsChatCoworkUnifiedSessionsMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}
