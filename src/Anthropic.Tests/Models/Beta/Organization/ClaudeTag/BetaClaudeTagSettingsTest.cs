using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeTag;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeTag;

public class BetaClaudeTagSettingsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaClaudeTagSettings
        {
            Enabled = true,
            EnvironmentID = "environment_id",
            GuestPolicy = new BetaClaudeTagGuestPolicyAllow(),
            Instructions = "instructions",
            Model = "model",
        };

        bool expectedEnabled = true;
        string expectedEnvironmentID = "environment_id";
        BetaClaudeTagGuestPolicy expectedGuestPolicy = new BetaClaudeTagGuestPolicyAllow();
        string expectedInstructions = "instructions";
        string expectedModel = "model";

        Assert.Equal(expectedEnabled, model.Enabled);
        Assert.Equal(expectedEnvironmentID, model.EnvironmentID);
        Assert.Equal(expectedGuestPolicy, model.GuestPolicy);
        Assert.Equal(expectedInstructions, model.Instructions);
        Assert.Equal(expectedModel, model.Model);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaClaudeTagSettings
        {
            Enabled = true,
            EnvironmentID = "environment_id",
            GuestPolicy = new BetaClaudeTagGuestPolicyAllow(),
            Instructions = "instructions",
            Model = "model",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagSettings>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaClaudeTagSettings
        {
            Enabled = true,
            EnvironmentID = "environment_id",
            GuestPolicy = new BetaClaudeTagGuestPolicyAllow(),
            Instructions = "instructions",
            Model = "model",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagSettings>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedEnabled = true;
        string expectedEnvironmentID = "environment_id";
        BetaClaudeTagGuestPolicy expectedGuestPolicy = new BetaClaudeTagGuestPolicyAllow();
        string expectedInstructions = "instructions";
        string expectedModel = "model";

        Assert.Equal(expectedEnabled, deserialized.Enabled);
        Assert.Equal(expectedEnvironmentID, deserialized.EnvironmentID);
        Assert.Equal(expectedGuestPolicy, deserialized.GuestPolicy);
        Assert.Equal(expectedInstructions, deserialized.Instructions);
        Assert.Equal(expectedModel, deserialized.Model);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaClaudeTagSettings
        {
            Enabled = true,
            EnvironmentID = "environment_id",
            GuestPolicy = new BetaClaudeTagGuestPolicyAllow(),
            Instructions = "instructions",
            Model = "model",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaClaudeTagSettings
        {
            Enabled = true,
            EnvironmentID = "environment_id",
            GuestPolicy = new BetaClaudeTagGuestPolicyAllow(),
            Instructions = "instructions",
            Model = "model",
        };

        BetaClaudeTagSettings copied = new(model);

        Assert.Equal(model, copied);
    }
}
