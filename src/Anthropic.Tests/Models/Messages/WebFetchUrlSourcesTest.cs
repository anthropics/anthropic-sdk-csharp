using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class WebFetchUrlSourcesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebFetchUrlSources
        {
            ClientToolResults = new WebFetchUrlSourceAll(),
            ServerToolResults = new WebFetchUrlSourceAll(),
            UserInput = new WebFetchUrlSourceAll(),
        };

        ClientToolResults expectedClientToolResults = new WebFetchUrlSourceAll();
        ServerToolResults expectedServerToolResults = new WebFetchUrlSourceAll();
        UserInput expectedUserInput = new WebFetchUrlSourceAll();

        Assert.Equal(expectedClientToolResults, model.ClientToolResults);
        Assert.Equal(expectedServerToolResults, model.ServerToolResults);
        Assert.Equal(expectedUserInput, model.UserInput);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebFetchUrlSources
        {
            ClientToolResults = new WebFetchUrlSourceAll(),
            ServerToolResults = new WebFetchUrlSourceAll(),
            UserInput = new WebFetchUrlSourceAll(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebFetchUrlSources>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebFetchUrlSources
        {
            ClientToolResults = new WebFetchUrlSourceAll(),
            ServerToolResults = new WebFetchUrlSourceAll(),
            UserInput = new WebFetchUrlSourceAll(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebFetchUrlSources>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ClientToolResults expectedClientToolResults = new WebFetchUrlSourceAll();
        ServerToolResults expectedServerToolResults = new WebFetchUrlSourceAll();
        UserInput expectedUserInput = new WebFetchUrlSourceAll();

        Assert.Equal(expectedClientToolResults, deserialized.ClientToolResults);
        Assert.Equal(expectedServerToolResults, deserialized.ServerToolResults);
        Assert.Equal(expectedUserInput, deserialized.UserInput);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebFetchUrlSources
        {
            ClientToolResults = new WebFetchUrlSourceAll(),
            ServerToolResults = new WebFetchUrlSourceAll(),
            UserInput = new WebFetchUrlSourceAll(),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebFetchUrlSources { };

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
        var model = new WebFetchUrlSources { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WebFetchUrlSources
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
        var model = new WebFetchUrlSources
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
        var model = new WebFetchUrlSources
        {
            ClientToolResults = new WebFetchUrlSourceAll(),
            ServerToolResults = new WebFetchUrlSourceAll(),
            UserInput = new WebFetchUrlSourceAll(),
        };

        WebFetchUrlSources copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ClientToolResultsTest : TestBase
{
    [Fact]
    public void WebFetchUrlSourceAllValidationWorks()
    {
        ClientToolResults value = new WebFetchUrlSourceAll();
        value.Validate();
    }

    [Fact]
    public void WebFetchUrlSourceNoneValidationWorks()
    {
        ClientToolResults value = new WebFetchUrlSourceNone();
        value.Validate();
    }

    [Fact]
    public void WebFetchUrlSourceOnlyValidationWorks()
    {
        ClientToolResults value = new WebFetchUrlSourceOnly([new("name")]);
        value.Validate();
    }

    [Fact]
    public void WebFetchUrlSourceExceptValidationWorks()
    {
        ClientToolResults value = new WebFetchUrlSourceExcept([new("name")]);
        value.Validate();
    }

    [Fact]
    public void WebFetchUrlSourceAllSerializationRoundtripWorks()
    {
        ClientToolResults value = new WebFetchUrlSourceAll();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClientToolResults>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebFetchUrlSourceNoneSerializationRoundtripWorks()
    {
        ClientToolResults value = new WebFetchUrlSourceNone();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClientToolResults>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebFetchUrlSourceOnlySerializationRoundtripWorks()
    {
        ClientToolResults value = new WebFetchUrlSourceOnly([new("name")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClientToolResults>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebFetchUrlSourceExceptSerializationRoundtripWorks()
    {
        ClientToolResults value = new WebFetchUrlSourceExcept([new("name")]);
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
    public void WebFetchUrlSourceAllValidationWorks()
    {
        ServerToolResults value = new WebFetchUrlSourceAll();
        value.Validate();
    }

    [Fact]
    public void WebFetchUrlSourceNoneValidationWorks()
    {
        ServerToolResults value = new WebFetchUrlSourceNone();
        value.Validate();
    }

    [Fact]
    public void WebFetchUrlSourceOnlyValidationWorks()
    {
        ServerToolResults value = new WebFetchUrlSourceOnly([new("name")]);
        value.Validate();
    }

    [Fact]
    public void WebFetchUrlSourceExceptValidationWorks()
    {
        ServerToolResults value = new WebFetchUrlSourceExcept([new("name")]);
        value.Validate();
    }

    [Fact]
    public void WebFetchUrlSourceAllSerializationRoundtripWorks()
    {
        ServerToolResults value = new WebFetchUrlSourceAll();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ServerToolResults>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebFetchUrlSourceNoneSerializationRoundtripWorks()
    {
        ServerToolResults value = new WebFetchUrlSourceNone();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ServerToolResults>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebFetchUrlSourceOnlySerializationRoundtripWorks()
    {
        ServerToolResults value = new WebFetchUrlSourceOnly([new("name")]);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ServerToolResults>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebFetchUrlSourceExceptSerializationRoundtripWorks()
    {
        ServerToolResults value = new WebFetchUrlSourceExcept([new("name")]);
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
    public void WebFetchUrlSourceAllValidationWorks()
    {
        UserInput value = new WebFetchUrlSourceAll();
        value.Validate();
    }

    [Fact]
    public void WebFetchUrlSourceNoneValidationWorks()
    {
        UserInput value = new WebFetchUrlSourceNone();
        value.Validate();
    }

    [Fact]
    public void WebFetchUrlSourceAllSerializationRoundtripWorks()
    {
        UserInput value = new WebFetchUrlSourceAll();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebFetchUrlSourceNoneSerializationRoundtripWorks()
    {
        UserInput value = new WebFetchUrlSourceNone();
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
