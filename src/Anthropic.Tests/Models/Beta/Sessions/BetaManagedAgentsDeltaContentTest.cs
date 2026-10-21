using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsDeltaContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDeltaContent
        {
            Content = new("Where is my order #1234?"),
            Index = 0,
        };

        BetaManagedAgentsTextBlock expectedContent = new("Where is my order #1234?");
        JsonElement expectedType = JsonSerializer.SerializeToElement("content_delta");
        long expectedIndex = 0;

        Assert.Equal(expectedContent, model.Content);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedIndex, model.Index);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDeltaContent
        {
            Content = new("Where is my order #1234?"),
            Index = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeltaContent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsDeltaContent
        {
            Content = new("Where is my order #1234?"),
            Index = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeltaContent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaManagedAgentsTextBlock expectedContent = new("Where is my order #1234?");
        JsonElement expectedType = JsonSerializer.SerializeToElement("content_delta");
        long expectedIndex = 0;

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedIndex, deserialized.Index);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsDeltaContent
        {
            Content = new("Where is my order #1234?"),
            Index = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsDeltaContent { Content = new("Where is my order #1234?") };

        Assert.Null(model.Index);
        Assert.False(model.RawData.ContainsKey("index"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsDeltaContent { Content = new("Where is my order #1234?") };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsDeltaContent
        {
            Content = new("Where is my order #1234?"),

            // Null should be interpreted as omitted for these properties
            Index = null,
        };

        Assert.Null(model.Index);
        Assert.False(model.RawData.ContainsKey("index"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullInWithAreUnset_Works()
    {
        var model = new BetaManagedAgentsDeltaContent
        {
            Content = new("Where is my order #1234?"),
            Index = 0,
        } with
        {
            // Null should be interpreted as omitted for these properties
            Index = null,
        };

        Assert.Null(model.Index);
        Assert.False(model.RawData.ContainsKey("index"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsDeltaContent
        {
            Content = new("Where is my order #1234?"),

            // Null should be interpreted as omitted for these properties
            Index = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsDeltaContent
        {
            Content = new("Where is my order #1234?"),
            Index = 0,
        };

        BetaManagedAgentsDeltaContent copied = new(model);

        Assert.Equal(model, copied);
    }
}
