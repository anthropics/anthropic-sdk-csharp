using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeTag;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeTag;

public class BetaClaudeTagSlackDefaultSettingSourceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaClaudeTagSlackDefaultSettingSource { };

        JsonElement expectedType = JsonSerializer.SerializeToElement("slack_default");

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaClaudeTagSlackDefaultSettingSource { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagSlackDefaultSettingSource>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaClaudeTagSlackDefaultSettingSource { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagSlackDefaultSettingSource>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("slack_default");

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaClaudeTagSlackDefaultSettingSource { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaClaudeTagSlackDefaultSettingSource { };

        BetaClaudeTagSlackDefaultSettingSource copied = new(model);

        Assert.Equal(model, copied);
    }
}
