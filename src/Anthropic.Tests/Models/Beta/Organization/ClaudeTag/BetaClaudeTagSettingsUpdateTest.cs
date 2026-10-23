using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeTag;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeTag;

public class BetaClaudeTagSettingsUpdateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaClaudeTagSettingsUpdate
        {
            Enabled = true,
            EnvironmentID = "x",
            GuestPolicy = new BetaClaudeTagGuestPolicyAllow(),
            Instructions = "instructions",
            Model = "x",
        };

        bool expectedEnabled = true;
        string expectedEnvironmentID = "x";
        BetaClaudeTagGuestPolicy expectedGuestPolicy = new BetaClaudeTagGuestPolicyAllow();
        string expectedInstructions = "instructions";
        string expectedModel = "x";

        Assert.Equal(expectedEnabled, model.Enabled);
        Assert.Equal(expectedEnvironmentID, model.EnvironmentID);
        Assert.Equal(expectedGuestPolicy, model.GuestPolicy);
        Assert.Equal(expectedInstructions, model.Instructions);
        Assert.Equal(expectedModel, model.Model);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaClaudeTagSettingsUpdate
        {
            Enabled = true,
            EnvironmentID = "x",
            GuestPolicy = new BetaClaudeTagGuestPolicyAllow(),
            Instructions = "instructions",
            Model = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagSettingsUpdate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaClaudeTagSettingsUpdate
        {
            Enabled = true,
            EnvironmentID = "x",
            GuestPolicy = new BetaClaudeTagGuestPolicyAllow(),
            Instructions = "instructions",
            Model = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagSettingsUpdate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedEnabled = true;
        string expectedEnvironmentID = "x";
        BetaClaudeTagGuestPolicy expectedGuestPolicy = new BetaClaudeTagGuestPolicyAllow();
        string expectedInstructions = "instructions";
        string expectedModel = "x";

        Assert.Equal(expectedEnabled, deserialized.Enabled);
        Assert.Equal(expectedEnvironmentID, deserialized.EnvironmentID);
        Assert.Equal(expectedGuestPolicy, deserialized.GuestPolicy);
        Assert.Equal(expectedInstructions, deserialized.Instructions);
        Assert.Equal(expectedModel, deserialized.Model);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaClaudeTagSettingsUpdate
        {
            Enabled = true,
            EnvironmentID = "x",
            GuestPolicy = new BetaClaudeTagGuestPolicyAllow(),
            Instructions = "instructions",
            Model = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaClaudeTagSettingsUpdate { };

        Assert.Null(model.Enabled);
        Assert.False(model.RawData.ContainsKey("enabled"));
        Assert.Null(model.EnvironmentID);
        Assert.False(model.RawData.ContainsKey("environment_id"));
        Assert.Null(model.GuestPolicy);
        Assert.False(model.RawData.ContainsKey("guest_policy"));
        Assert.Null(model.Instructions);
        Assert.False(model.RawData.ContainsKey("instructions"));
        Assert.Null(model.Model);
        Assert.False(model.RawData.ContainsKey("model"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaClaudeTagSettingsUpdate { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaClaudeTagSettingsUpdate
        {
            Enabled = null,
            EnvironmentID = null,
            GuestPolicy = null,
            Instructions = null,
            Model = null,
        };

        Assert.Null(model.Enabled);
        Assert.True(model.RawData.ContainsKey("enabled"));
        Assert.Null(model.EnvironmentID);
        Assert.True(model.RawData.ContainsKey("environment_id"));
        Assert.Null(model.GuestPolicy);
        Assert.True(model.RawData.ContainsKey("guest_policy"));
        Assert.Null(model.Instructions);
        Assert.True(model.RawData.ContainsKey("instructions"));
        Assert.Null(model.Model);
        Assert.True(model.RawData.ContainsKey("model"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaClaudeTagSettingsUpdate
        {
            Enabled = null,
            EnvironmentID = null,
            GuestPolicy = null,
            Instructions = null,
            Model = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaClaudeTagSettingsUpdate
        {
            Enabled = true,
            EnvironmentID = "x",
            GuestPolicy = new BetaClaudeTagGuestPolicyAllow(),
            Instructions = "instructions",
            Model = "x",
        };

        BetaClaudeTagSettingsUpdate copied = new(model);

        Assert.Equal(model, copied);
    }
}
