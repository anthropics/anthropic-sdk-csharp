using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.SpendLimits;

namespace Anthropic.Tests.Models.Organization.SpendLimits;

public class SpendLimitScopedApiKeyActorTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SpendLimitScopedApiKeyActor { ScopedApiKeyID = "scoped_api_key_id" };

        string expectedScopedApiKeyID = "scoped_api_key_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("scoped_api_key_actor");

        Assert.Equal(expectedScopedApiKeyID, model.ScopedApiKeyID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SpendLimitScopedApiKeyActor { ScopedApiKeyID = "scoped_api_key_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SpendLimitScopedApiKeyActor>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SpendLimitScopedApiKeyActor { ScopedApiKeyID = "scoped_api_key_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SpendLimitScopedApiKeyActor>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedScopedApiKeyID = "scoped_api_key_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("scoped_api_key_actor");

        Assert.Equal(expectedScopedApiKeyID, deserialized.ScopedApiKeyID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SpendLimitScopedApiKeyActor { ScopedApiKeyID = "scoped_api_key_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SpendLimitScopedApiKeyActor { ScopedApiKeyID = "scoped_api_key_id" };

        SpendLimitScopedApiKeyActor copied = new(model);

        Assert.Equal(model, copied);
    }
}
