using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsAgentToolset20260401EditInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401EditInput
        {
            FilePath = "file_path",
            NewString = "new_string",
            OldString = "old_string",
            ReplaceAll = true,
        };

        string expectedFilePath = "file_path";
        string expectedNewString = "new_string";
        string expectedOldString = "old_string";
        bool expectedReplaceAll = true;

        Assert.Equal(expectedFilePath, model.FilePath);
        Assert.Equal(expectedNewString, model.NewString);
        Assert.Equal(expectedOldString, model.OldString);
        Assert.Equal(expectedReplaceAll, model.ReplaceAll);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401EditInput
        {
            FilePath = "file_path",
            NewString = "new_string",
            OldString = "old_string",
            ReplaceAll = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsAgentToolset20260401EditInput>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401EditInput
        {
            FilePath = "file_path",
            NewString = "new_string",
            OldString = "old_string",
            ReplaceAll = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsAgentToolset20260401EditInput>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedFilePath = "file_path";
        string expectedNewString = "new_string";
        string expectedOldString = "old_string";
        bool expectedReplaceAll = true;

        Assert.Equal(expectedFilePath, deserialized.FilePath);
        Assert.Equal(expectedNewString, deserialized.NewString);
        Assert.Equal(expectedOldString, deserialized.OldString);
        Assert.Equal(expectedReplaceAll, deserialized.ReplaceAll);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401EditInput
        {
            FilePath = "file_path",
            NewString = "new_string",
            OldString = "old_string",
            ReplaceAll = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401EditInput
        {
            FilePath = "file_path",
            NewString = "new_string",
            OldString = "old_string",
        };

        Assert.Null(model.ReplaceAll);
        Assert.False(model.RawData.ContainsKey("replace_all"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401EditInput
        {
            FilePath = "file_path",
            NewString = "new_string",
            OldString = "old_string",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401EditInput
        {
            FilePath = "file_path",
            NewString = "new_string",
            OldString = "old_string",

            // Null should be interpreted as omitted for these properties
            ReplaceAll = null,
        };

        Assert.Null(model.ReplaceAll);
        Assert.False(model.RawData.ContainsKey("replace_all"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401EditInput
        {
            FilePath = "file_path",
            NewString = "new_string",
            OldString = "old_string",

            // Null should be interpreted as omitted for these properties
            ReplaceAll = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsAgentToolset20260401EditInput
        {
            FilePath = "file_path",
            NewString = "new_string",
            OldString = "old_string",
            ReplaceAll = true,
        };

        BetaManagedAgentsAgentToolset20260401EditInput copied = new(model);

        Assert.Equal(model, copied);
    }
}
