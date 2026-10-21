using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsCoworkMetricsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsCoworkMetrics
        {
            ActionCount = 0,
            ArtifactsCreatedCount = 0,
            ConnectorsUsedCount = 0,
            DispatchTurnCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SkillsUsedCount = 0,
            DistinctPluginsUsedCount = 0,
            EditToolCount = 0,
            FileEditCount = 0,
            MultiEditToolCount = 0,
            NotebookEditToolCount = 0,
            PluginsUsedCount = 0,
            SessionsWithFileEditsCount = 0,
            WriteToolCount = 0,
        };

        long expectedActionCount = 0;
        long expectedArtifactsCreatedCount = 0;
        long expectedConnectorsUsedCount = 0;
        long expectedDispatchTurnCount = 0;
        long expectedDistinctConnectorsUsedCount = 0;
        long expectedDistinctSessionCount = 0;
        long expectedDistinctSkillsUsedCount = 0;
        long expectedMessageCount = 0;
        long expectedSkillsUsedCount = 0;
        long expectedDistinctPluginsUsedCount = 0;
        long expectedEditToolCount = 0;
        long expectedFileEditCount = 0;
        long expectedMultiEditToolCount = 0;
        long expectedNotebookEditToolCount = 0;
        long expectedPluginsUsedCount = 0;
        long expectedSessionsWithFileEditsCount = 0;
        long expectedWriteToolCount = 0;

        Assert.Equal(expectedActionCount, model.ActionCount);
        Assert.Equal(expectedArtifactsCreatedCount, model.ArtifactsCreatedCount);
        Assert.Equal(expectedConnectorsUsedCount, model.ConnectorsUsedCount);
        Assert.Equal(expectedDispatchTurnCount, model.DispatchTurnCount);
        Assert.Equal(expectedDistinctConnectorsUsedCount, model.DistinctConnectorsUsedCount);
        Assert.Equal(expectedDistinctSessionCount, model.DistinctSessionCount);
        Assert.Equal(expectedDistinctSkillsUsedCount, model.DistinctSkillsUsedCount);
        Assert.Equal(expectedMessageCount, model.MessageCount);
        Assert.Equal(expectedSkillsUsedCount, model.SkillsUsedCount);
        Assert.Equal(expectedDistinctPluginsUsedCount, model.DistinctPluginsUsedCount);
        Assert.Equal(expectedEditToolCount, model.EditToolCount);
        Assert.Equal(expectedFileEditCount, model.FileEditCount);
        Assert.Equal(expectedMultiEditToolCount, model.MultiEditToolCount);
        Assert.Equal(expectedNotebookEditToolCount, model.NotebookEditToolCount);
        Assert.Equal(expectedPluginsUsedCount, model.PluginsUsedCount);
        Assert.Equal(expectedSessionsWithFileEditsCount, model.SessionsWithFileEditsCount);
        Assert.Equal(expectedWriteToolCount, model.WriteToolCount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsCoworkMetrics
        {
            ActionCount = 0,
            ArtifactsCreatedCount = 0,
            ConnectorsUsedCount = 0,
            DispatchTurnCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SkillsUsedCount = 0,
            DistinctPluginsUsedCount = 0,
            EditToolCount = 0,
            FileEditCount = 0,
            MultiEditToolCount = 0,
            NotebookEditToolCount = 0,
            PluginsUsedCount = 0,
            SessionsWithFileEditsCount = 0,
            WriteToolCount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsCoworkMetrics>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsCoworkMetrics
        {
            ActionCount = 0,
            ArtifactsCreatedCount = 0,
            ConnectorsUsedCount = 0,
            DispatchTurnCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SkillsUsedCount = 0,
            DistinctPluginsUsedCount = 0,
            EditToolCount = 0,
            FileEditCount = 0,
            MultiEditToolCount = 0,
            NotebookEditToolCount = 0,
            PluginsUsedCount = 0,
            SessionsWithFileEditsCount = 0,
            WriteToolCount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsCoworkMetrics>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedActionCount = 0;
        long expectedArtifactsCreatedCount = 0;
        long expectedConnectorsUsedCount = 0;
        long expectedDispatchTurnCount = 0;
        long expectedDistinctConnectorsUsedCount = 0;
        long expectedDistinctSessionCount = 0;
        long expectedDistinctSkillsUsedCount = 0;
        long expectedMessageCount = 0;
        long expectedSkillsUsedCount = 0;
        long expectedDistinctPluginsUsedCount = 0;
        long expectedEditToolCount = 0;
        long expectedFileEditCount = 0;
        long expectedMultiEditToolCount = 0;
        long expectedNotebookEditToolCount = 0;
        long expectedPluginsUsedCount = 0;
        long expectedSessionsWithFileEditsCount = 0;
        long expectedWriteToolCount = 0;

        Assert.Equal(expectedActionCount, deserialized.ActionCount);
        Assert.Equal(expectedArtifactsCreatedCount, deserialized.ArtifactsCreatedCount);
        Assert.Equal(expectedConnectorsUsedCount, deserialized.ConnectorsUsedCount);
        Assert.Equal(expectedDispatchTurnCount, deserialized.DispatchTurnCount);
        Assert.Equal(expectedDistinctConnectorsUsedCount, deserialized.DistinctConnectorsUsedCount);
        Assert.Equal(expectedDistinctSessionCount, deserialized.DistinctSessionCount);
        Assert.Equal(expectedDistinctSkillsUsedCount, deserialized.DistinctSkillsUsedCount);
        Assert.Equal(expectedMessageCount, deserialized.MessageCount);
        Assert.Equal(expectedSkillsUsedCount, deserialized.SkillsUsedCount);
        Assert.Equal(expectedDistinctPluginsUsedCount, deserialized.DistinctPluginsUsedCount);
        Assert.Equal(expectedEditToolCount, deserialized.EditToolCount);
        Assert.Equal(expectedFileEditCount, deserialized.FileEditCount);
        Assert.Equal(expectedMultiEditToolCount, deserialized.MultiEditToolCount);
        Assert.Equal(expectedNotebookEditToolCount, deserialized.NotebookEditToolCount);
        Assert.Equal(expectedPluginsUsedCount, deserialized.PluginsUsedCount);
        Assert.Equal(expectedSessionsWithFileEditsCount, deserialized.SessionsWithFileEditsCount);
        Assert.Equal(expectedWriteToolCount, deserialized.WriteToolCount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsCoworkMetrics
        {
            ActionCount = 0,
            ArtifactsCreatedCount = 0,
            ConnectorsUsedCount = 0,
            DispatchTurnCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SkillsUsedCount = 0,
            DistinctPluginsUsedCount = 0,
            EditToolCount = 0,
            FileEditCount = 0,
            MultiEditToolCount = 0,
            NotebookEditToolCount = 0,
            PluginsUsedCount = 0,
            SessionsWithFileEditsCount = 0,
            WriteToolCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaAnalyticsCoworkMetrics
        {
            ActionCount = 0,
            ArtifactsCreatedCount = 0,
            ConnectorsUsedCount = 0,
            DispatchTurnCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SkillsUsedCount = 0,
        };

        Assert.Null(model.DistinctPluginsUsedCount);
        Assert.False(model.RawData.ContainsKey("distinct_plugins_used_count"));
        Assert.Null(model.EditToolCount);
        Assert.False(model.RawData.ContainsKey("edit_tool_count"));
        Assert.Null(model.FileEditCount);
        Assert.False(model.RawData.ContainsKey("file_edit_count"));
        Assert.Null(model.MultiEditToolCount);
        Assert.False(model.RawData.ContainsKey("multi_edit_tool_count"));
        Assert.Null(model.NotebookEditToolCount);
        Assert.False(model.RawData.ContainsKey("notebook_edit_tool_count"));
        Assert.Null(model.PluginsUsedCount);
        Assert.False(model.RawData.ContainsKey("plugins_used_count"));
        Assert.Null(model.SessionsWithFileEditsCount);
        Assert.False(model.RawData.ContainsKey("sessions_with_file_edits_count"));
        Assert.Null(model.WriteToolCount);
        Assert.False(model.RawData.ContainsKey("write_tool_count"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaAnalyticsCoworkMetrics
        {
            ActionCount = 0,
            ArtifactsCreatedCount = 0,
            ConnectorsUsedCount = 0,
            DispatchTurnCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SkillsUsedCount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaAnalyticsCoworkMetrics
        {
            ActionCount = 0,
            ArtifactsCreatedCount = 0,
            ConnectorsUsedCount = 0,
            DispatchTurnCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SkillsUsedCount = 0,

            DistinctPluginsUsedCount = null,
            EditToolCount = null,
            FileEditCount = null,
            MultiEditToolCount = null,
            NotebookEditToolCount = null,
            PluginsUsedCount = null,
            SessionsWithFileEditsCount = null,
            WriteToolCount = null,
        };

        Assert.Null(model.DistinctPluginsUsedCount);
        Assert.True(model.RawData.ContainsKey("distinct_plugins_used_count"));
        Assert.Null(model.EditToolCount);
        Assert.True(model.RawData.ContainsKey("edit_tool_count"));
        Assert.Null(model.FileEditCount);
        Assert.True(model.RawData.ContainsKey("file_edit_count"));
        Assert.Null(model.MultiEditToolCount);
        Assert.True(model.RawData.ContainsKey("multi_edit_tool_count"));
        Assert.Null(model.NotebookEditToolCount);
        Assert.True(model.RawData.ContainsKey("notebook_edit_tool_count"));
        Assert.Null(model.PluginsUsedCount);
        Assert.True(model.RawData.ContainsKey("plugins_used_count"));
        Assert.Null(model.SessionsWithFileEditsCount);
        Assert.True(model.RawData.ContainsKey("sessions_with_file_edits_count"));
        Assert.Null(model.WriteToolCount);
        Assert.True(model.RawData.ContainsKey("write_tool_count"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaAnalyticsCoworkMetrics
        {
            ActionCount = 0,
            ArtifactsCreatedCount = 0,
            ConnectorsUsedCount = 0,
            DispatchTurnCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SkillsUsedCount = 0,

            DistinctPluginsUsedCount = null,
            EditToolCount = null,
            FileEditCount = null,
            MultiEditToolCount = null,
            NotebookEditToolCount = null,
            PluginsUsedCount = null,
            SessionsWithFileEditsCount = null,
            WriteToolCount = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsCoworkMetrics
        {
            ActionCount = 0,
            ArtifactsCreatedCount = 0,
            ConnectorsUsedCount = 0,
            DispatchTurnCount = 0,
            DistinctConnectorsUsedCount = 0,
            DistinctSessionCount = 0,
            DistinctSkillsUsedCount = 0,
            MessageCount = 0,
            SkillsUsedCount = 0,
            DistinctPluginsUsedCount = 0,
            EditToolCount = 0,
            FileEditCount = 0,
            MultiEditToolCount = 0,
            NotebookEditToolCount = 0,
            PluginsUsedCount = 0,
            SessionsWithFileEditsCount = 0,
            WriteToolCount = 0,
        };

        BetaAnalyticsCoworkMetrics copied = new(model);

        Assert.Equal(model, copied);
    }
}
