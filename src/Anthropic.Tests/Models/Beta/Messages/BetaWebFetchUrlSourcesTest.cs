using System.Collections.Generic;
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
    public void OptionalNonNullablePropertiesSetToNullInWithAreUnset_Works()
    {
        var model = new BetaWebFetchUrlSources
        {
            ClientToolResults = new BetaWebFetchUrlSourceAll(),
            ServerToolResults = new BetaWebFetchUrlSourceAll(),
            UserInput = new BetaWebFetchUrlSourceAll(),
        } with
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
    public void BetaWebFetchUrlSourceAllTypeWorks()
    {
        ClientToolResults value = new BetaWebFetchUrlSourceAll();
        Assert.Equal(ClientToolResultsType.All, value.Type.Value());
    }

    [Fact]
    public void BetaWebFetchUrlSourceNoneTypeWorks()
    {
        ClientToolResults value = new BetaWebFetchUrlSourceNone();
        Assert.Equal(ClientToolResultsType.None, value.Type.Value());
    }

    [Fact]
    public void BetaWebFetchUrlSourceOnlyTypeWorks()
    {
        ClientToolResults value = new BetaWebFetchUrlSourceOnly([new("name")]);
        Assert.Equal(ClientToolResultsType.Only, value.Type.Value());
    }

    [Fact]
    public void BetaWebFetchUrlSourceExceptTypeWorks()
    {
        ClientToolResults value = new BetaWebFetchUrlSourceExcept([new("name")]);
        Assert.Equal(ClientToolResultsType.Except, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        ClientToolResults value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "all",
                  "tools": [
                    {
                      "name": "name",
                      "type": "tool_reference"
                    }
                  ]
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, ClientToolResultsType> expectedType = ClientToolResultsType.All;
        List<BetaWebFetchUrlSourceToolReference> expectedTools = [new("name")];

        Assert.Equal(expectedType, value.Type);
        Assert.NotNull(value.Tools);
        Assert.Equal(expectedTools.Count, value.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], value.Tools[i]);
        }

        ClientToolResults emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.Tools);
    }
}

public class ClientToolResultsTypeTest : TestBase
{
    [Theory]
    [InlineData(ClientToolResultsType.All)]
    [InlineData(ClientToolResultsType.None)]
    [InlineData(ClientToolResultsType.Only)]
    [InlineData(ClientToolResultsType.Except)]
    public void Validation_Works(ClientToolResultsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ClientToolResultsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ClientToolResultsType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ClientToolResultsType.All)]
    [InlineData(ClientToolResultsType.None)]
    [InlineData(ClientToolResultsType.Only)]
    [InlineData(ClientToolResultsType.Except)]
    public void SerializationRoundtrip_Works(ClientToolResultsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ClientToolResultsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ClientToolResultsType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ClientToolResultsType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ClientToolResultsType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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
    public void BetaWebFetchUrlSourceAllTypeWorks()
    {
        ServerToolResults value = new BetaWebFetchUrlSourceAll();
        Assert.Equal(ServerToolResultsType.All, value.Type.Value());
    }

    [Fact]
    public void BetaWebFetchUrlSourceNoneTypeWorks()
    {
        ServerToolResults value = new BetaWebFetchUrlSourceNone();
        Assert.Equal(ServerToolResultsType.None, value.Type.Value());
    }

    [Fact]
    public void BetaWebFetchUrlSourceOnlyTypeWorks()
    {
        ServerToolResults value = new BetaWebFetchUrlSourceOnly([new("name")]);
        Assert.Equal(ServerToolResultsType.Only, value.Type.Value());
    }

    [Fact]
    public void BetaWebFetchUrlSourceExceptTypeWorks()
    {
        ServerToolResults value = new BetaWebFetchUrlSourceExcept([new("name")]);
        Assert.Equal(ServerToolResultsType.Except, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        ServerToolResults value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "all",
                  "tools": [
                    {
                      "name": "name",
                      "type": "tool_reference"
                    }
                  ]
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, ServerToolResultsType> expectedType = ServerToolResultsType.All;
        List<BetaWebFetchUrlSourceToolReference> expectedTools = [new("name")];

        Assert.Equal(expectedType, value.Type);
        Assert.NotNull(value.Tools);
        Assert.Equal(expectedTools.Count, value.Tools.Count);
        for (int i = 0; i < expectedTools.Count; i++)
        {
            Assert.Equal(expectedTools[i], value.Tools[i]);
        }

        ServerToolResults emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.Tools);
    }
}

public class ServerToolResultsTypeTest : TestBase
{
    [Theory]
    [InlineData(ServerToolResultsType.All)]
    [InlineData(ServerToolResultsType.None)]
    [InlineData(ServerToolResultsType.Only)]
    [InlineData(ServerToolResultsType.Except)]
    public void Validation_Works(ServerToolResultsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ServerToolResultsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ServerToolResultsType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ServerToolResultsType.All)]
    [InlineData(ServerToolResultsType.None)]
    [InlineData(ServerToolResultsType.Only)]
    [InlineData(ServerToolResultsType.Except)]
    public void SerializationRoundtrip_Works(ServerToolResultsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ServerToolResultsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ServerToolResultsType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ServerToolResultsType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ServerToolResultsType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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
    public void BetaWebFetchUrlSourceAllTypeWorks()
    {
        UserInput value = new BetaWebFetchUrlSourceAll();
        Assert.Equal(UserInputType.All, value.Type.Value());
    }

    [Fact]
    public void BetaWebFetchUrlSourceNoneTypeWorks()
    {
        UserInput value = new BetaWebFetchUrlSourceNone();
        Assert.Equal(UserInputType.None, value.Type.Value());
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

        ApiEnum<string, UserInputType> expectedType = UserInputType.All;

        Assert.Equal(expectedType, value.Type);

        UserInput emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class UserInputTypeTest : TestBase
{
    [Theory]
    [InlineData(UserInputType.All)]
    [InlineData(UserInputType.None)]
    public void Validation_Works(UserInputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserInputType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserInputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UserInputType.All)]
    [InlineData(UserInputType.None)]
    public void SerializationRoundtrip_Works(UserInputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UserInputType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UserInputType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, UserInputType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, UserInputType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
