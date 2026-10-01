using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaWebFetchUrlSourcesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaWebFetchUrlSources
        {
            ClientToolResults = new BetaWebFetchUrlSourceAll(),
            ServerToolResults = new BetaWebFetchUrlSourceAll(),
            UserInput = new BetaWebFetchUrlSourceAll(),
        };

        ClientToolResults expectedClientToolResults = new BetaWebFetchUrlSourceAll();
        ServerToolResults expectedServerToolResults = new BetaWebFetchUrlSourceAll();
        UserInput expectedUserInput = new BetaWebFetchUrlSourceAll();

        Assert.Equal(expectedClientToolResults, model.ClientToolResults);
        Assert.Equal(expectedServerToolResults, model.ServerToolResults);
        Assert.Equal(expectedUserInput, model.UserInput);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaWebFetchUrlSources
        {
            ClientToolResults = new BetaWebFetchUrlSourceAll(),
            ServerToolResults = new BetaWebFetchUrlSourceAll(),
            UserInput = new BetaWebFetchUrlSourceAll(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebFetchUrlSources>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaWebFetchUrlSources
        {
            ClientToolResults = new BetaWebFetchUrlSourceAll(),
            ServerToolResults = new BetaWebFetchUrlSourceAll(),
            UserInput = new BetaWebFetchUrlSourceAll(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebFetchUrlSources>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ClientToolResults expectedClientToolResults = new BetaWebFetchUrlSourceAll();
        ServerToolResults expectedServerToolResults = new BetaWebFetchUrlSourceAll();
        UserInput expectedUserInput = new BetaWebFetchUrlSourceAll();

        Assert.Equal(expectedClientToolResults, deserialized.ClientToolResults);
        Assert.Equal(expectedServerToolResults, deserialized.ServerToolResults);
        Assert.Equal(expectedUserInput, deserialized.UserInput);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaWebFetchUrlSources
        {
            ClientToolResults = new BetaWebFetchUrlSourceAll(),
            ServerToolResults = new BetaWebFetchUrlSourceAll(),
            UserInput = new BetaWebFetchUrlSourceAll(),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaWebFetchUrlSources { };

        Assert.Null(model.ClientToolResults);
        Assert.False(model.RawData.ContainsKey("client_tool_results"));
        Assert.Null(model.ServerToolResults);
        Assert.False(model.RawData.ContainsKey("server_tool_results"));
        Assert.Null(model.UserInput);
        Assert.False(model.RawData.ContainsKey("user_input"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaWebFetchUrlSources { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaWebFetchUrlSources
        {
            // Null should be interpreted as omitted for these properties
            ClientToolResults = null,
            ServerToolResults = null,
            UserInput = null,
        };

        Assert.Null(model.ClientToolResults);
        Assert.False(model.RawData.ContainsKey("client_tool_results"));
        Assert.Null(model.ServerToolResults);
        Assert.False(model.RawData.ContainsKey("server_tool_results"));
        Assert.Null(model.UserInput);
        Assert.False(model.RawData.ContainsKey("user_input"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaWebFetchUrlSources
        {
            // Null should be interpreted as omitted for these properties
            ClientToolResults = null,
            ServerToolResults = null,
            UserInput = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaWebFetchUrlSources
        {
            ClientToolResults = new BetaWebFetchUrlSourceAll(),
            ServerToolResults = new BetaWebFetchUrlSourceAll(),
            UserInput = new BetaWebFetchUrlSourceAll(),
        };

        BetaWebFetchUrlSources copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ClientToolResultsTest : TestBase
{
    [Fact]
    public void BetaWebFetchUrlSourceAllValidationWorks()
    {
        ClientToolResults value = new BetaWebFetchUrlSourceAll();
        value.Validate();
    }

    [Fact]
    public void BetaWebFetchUrlSourceNoneValidationWorks()
    {
        ClientToolResults value = new BetaWebFetchUrlSourceNone();
        value.Validate();
    }

    [Fact]
    public void BetaWebFetchUrlSourceOnlyValidationWorks()
    {
        ClientToolResults value = new BetaWebFetchUrlSourceOnly([new("name")]);
        value.Validate();
    }

    [Fact]
    public void BetaWebFetchUrlSourceExceptValidationWorks()
    {
        ClientToolResults value = new BetaWebFetchUrlSourceExcept([new("name")]);
        value.Validate();
    }

    [Fact]
    public void BetaWebFetchUrlSourceAllSerializationRoundtripWorks()
    {
        ClientToolResults value = new BetaWebFetchUrlSourceAll();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClientToolResults>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaWebFetchUrlSourceNoneSerializationRoundtripWorks()
    {
        ClientToolResults value = new BetaWebFetchUrlSourceNone();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClientToolResults>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaWebFetchUrlSourceOnlySerializationRoundtripWorks()
    {
        ClientToolResults value = new BetaWebFetchUrlSourceOnly([new("name")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClientToolResults>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaWebFetchUrlSourceExceptSerializationRoundtripWorks()
    {
        ClientToolResults value = new BetaWebFetchUrlSourceExcept([new("name")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClientToolResults>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        ClientToolResults value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "all"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        JsonElement expectedType = JsonSerializer.SerializeToElement("all");

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        ClientToolResults emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class ServerToolResultsTest : TestBase
{
    [Fact]
    public void BetaWebFetchUrlSourceAllValidationWorks()
    {
        ServerToolResults value = new BetaWebFetchUrlSourceAll();
        value.Validate();
    }

    [Fact]
    public void BetaWebFetchUrlSourceNoneValidationWorks()
    {
        ServerToolResults value = new BetaWebFetchUrlSourceNone();
        value.Validate();
    }

    [Fact]
    public void BetaWebFetchUrlSourceOnlyValidationWorks()
    {
        ServerToolResults value = new BetaWebFetchUrlSourceOnly([new("name")]);
        value.Validate();
    }

    [Fact]
    public void BetaWebFetchUrlSourceExceptValidationWorks()
    {
        ServerToolResults value = new BetaWebFetchUrlSourceExcept([new("name")]);
        value.Validate();
    }

    [Fact]
    public void BetaWebFetchUrlSourceAllSerializationRoundtripWorks()
    {
        ServerToolResults value = new BetaWebFetchUrlSourceAll();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ServerToolResults>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaWebFetchUrlSourceNoneSerializationRoundtripWorks()
    {
        ServerToolResults value = new BetaWebFetchUrlSourceNone();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ServerToolResults>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaWebFetchUrlSourceOnlySerializationRoundtripWorks()
    {
        ServerToolResults value = new BetaWebFetchUrlSourceOnly([new("name")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ServerToolResults>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaWebFetchUrlSourceExceptSerializationRoundtripWorks()
    {
        ServerToolResults value = new BetaWebFetchUrlSourceExcept([new("name")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ServerToolResults>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        ServerToolResults value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "all"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        JsonElement expectedType = JsonSerializer.SerializeToElement("all");

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        ServerToolResults emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class UserInputTest : TestBase
{
    [Fact]
    public void BetaWebFetchUrlSourceAllValidationWorks()
    {
        UserInput value = new BetaWebFetchUrlSourceAll();
        value.Validate();
    }

    [Fact]
    public void BetaWebFetchUrlSourceNoneValidationWorks()
    {
        UserInput value = new BetaWebFetchUrlSourceNone();
        value.Validate();
    }

    [Fact]
    public void BetaWebFetchUrlSourceAllSerializationRoundtripWorks()
    {
        UserInput value = new BetaWebFetchUrlSourceAll();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaWebFetchUrlSourceNoneSerializationRoundtripWorks()
    {
        UserInput value = new BetaWebFetchUrlSourceNone();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        UserInput value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "all"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        JsonElement expectedType = JsonSerializer.SerializeToElement("all");

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        UserInput emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}
