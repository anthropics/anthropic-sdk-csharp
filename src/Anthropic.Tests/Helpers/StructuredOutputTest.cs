using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Helpers;
using Anthropic.Models.Beta.Messages;
using Anthropic.Models.Messages;
using Anthropic.Services;
using Anthropic.Services.Beta;
using Moq;

namespace Anthropic.Tests.Helpers;

// Test model classes

public class SimpleModel : StructuredOutputModel
{
    public string Name { get; set; } = "";
    public int Age { get; set; }
    public double Score { get; set; }
    public bool Active { get; set; }
}

public class ModelWithDescriptions : StructuredOutputModel
{
    [SchemaProperty("The person's full name")]
    public string Name { get; set; } = "";

    [SchemaProperty("Age in years")]
    public int Age { get; set; }
}

public class ModelWithOptionalFields : StructuredOutputModel
{
    public string RequiredField { get; set; } = "";
    public string? OptionalField { get; set; }
    public int? OptionalNumber { get; set; }
}

public class ModelWithEnum : StructuredOutputModel
{
    [SchemaProperty("Current status", Enum = new object[] { "active", "inactive", "pending" })]
    public string Status { get; set; } = "";
}

public class ModelWithFormat : StructuredOutputModel
{
    [SchemaProperty("Email address", Format = StringFormat.Email)]
    public string Email { get; set; } = "";

    [SchemaProperty("Website URL", Format = StringFormat.Uri)]
    public string Website { get; set; } = "";

    [SchemaProperty("IP address", Format = StringFormat.IPv4)]
    public string IP { get; set; } = "";
}

public class ModelWithUnsupportedConstraints : StructuredOutputModel
{
    [SchemaProperty("Age with constraints", Minimum = 0, Maximum = 150)]
    public int Age { get; set; }

    [SchemaProperty("Username", MinLength = 3, MaxLength = 20)]
    public string Username { get; set; } = "";

    [SchemaProperty("Score", MultipleOf = 0.5)]
    public double Score { get; set; }
}

public class ModelWithConst : StructuredOutputModel
{
    [SchemaProperty("API version", Const = "1.0")]
    public string Version { get; set; } = "";
}

public class ModelWithDefault : StructuredOutputModel
{
    [SchemaProperty("Priority level", Default = "normal")]
    public string Priority { get; set; } = "";
}

public class NestedAddress : StructuredOutputModel
{
    public string Street { get; set; } = "";
    public string City { get; set; } = "";
    public string Country { get; set; } = "";
}

public class ModelWithNestedObject : StructuredOutputModel
{
    public string Name { get; set; } = "";
    public NestedAddress Address { get; set; } = new();
}

public class SkillItem : StructuredOutputModel
{
    public string Name { get; set; } = "";

    [SchemaProperty("Skill level", Enum = new object[] { "beginner", "intermediate", "expert" })]
    public string Level { get; set; } = "";
}

public class ModelWithArrayOfObjects : StructuredOutputModel
{
    public string Name { get; set; } = "";

    [SchemaProperty("List of skills", MinItems = 1)]
    public List<SkillItem> Skills { get; set; } = new();
}

public class ModelWithArrayMinItemsUnsupported : StructuredOutputModel
{
    [SchemaProperty("Items with high minItems", MinItems = 5)]
    public List<SkillItem> Items { get; set; } = new();
}

[SchemaClass("A model with a custom description")]
public class ModelWithCustomDescription : StructuredOutputModel
{
    public string Content { get; set; } = "";
}

public class ModelWithJsonIgnore : StructuredOutputModel
{
    public string Name { get; set; } = "";

    [JsonIgnore]
    public string InternalToken { get; set; } = "";

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ConditionalField { get; set; }
}

public class ModelWithJsonRequired : StructuredOutputModel
{
    [JsonRequired]
    public string? NullableButRequired { get; set; }

    public int? NullableNotRequired { get; set; } // int? is reliably optional on all targets
}

/// <summary>
/// Tests for structured output functionality.
/// </summary>
public class StructuredOutputTest
{
    // =========================================================================
    // Schema Generation Tests
    // =========================================================================

    [Fact]
    public void BasicTypeInference()
    {
        var schema = StructuredOutput.ToJsonSchema<SimpleModel>();

        Assert.Equal("object", schema["type"]!.GetValue<string>());
        Assert.NotNull(schema["properties"]);

        var properties = schema["properties"]!.AsObject();
        var required = schema["required"]!.AsArray().Select(r => r!.GetValue<string>()).ToList();

        // Check type mappings
        Assert.Equal("string", properties["name"]!["type"]!.GetValue<string>());
        Assert.Equal("integer", properties["age"]!["type"]!.GetValue<string>());
        Assert.Equal("number", properties["score"]!["type"]!.GetValue<string>());
        Assert.Equal("boolean", properties["active"]!["type"]!.GetValue<string>());

        // All fields should be required
        Assert.Contains("name", required);
        Assert.Contains("age", required);
        Assert.Contains("score", required);
        Assert.Contains("active", required);

        // additionalProperties should always be false
        Assert.False(schema["additionalProperties"]!.GetValue<bool>());
    }

    [Fact]
    public void DescriptionsAreIncluded()
    {
        var schema = StructuredOutput.ToJsonSchema<ModelWithDescriptions>();
        var properties = schema["properties"]!.AsObject();

        Assert.Equal(
            "The person's full name",
            properties["name"]!["description"]!.GetValue<string>()
        );
        Assert.Equal("Age in years", properties["age"]!["description"]!.GetValue<string>());
    }

    [Fact]
    public void OptionalFieldsNotInRequired()
    {
        var schema = StructuredOutput.ToJsonSchema<ModelWithOptionalFields>();
        var required = schema["required"]!.AsArray().Select(r => r!.GetValue<string>()).ToList();

        Assert.Contains("requiredField", required);
        // Nullable value types (int?) work on all frameworks
        Assert.DoesNotContain("optionalNumber", required);
#if NET6_0_OR_GREATER
        // Nullable reference types (string?) only detected properly on .NET 6+
        Assert.DoesNotContain("optionalField", required);
#endif
    }

    [Fact]
    public void EnumIsIncluded()
    {
        var schema = StructuredOutput.ToJsonSchema<ModelWithEnum>();
        var properties = schema["properties"]!.AsObject();
        var statusSchema = properties["status"]!.AsObject();

        var enumValues = statusSchema["enum"]!
            .AsArray()
            .Select(v => v!.GetValue<string>())
            .ToList();
        Assert.Equal(3, enumValues.Count);
        Assert.Contains("active", enumValues);
        Assert.Contains("inactive", enumValues);
        Assert.Contains("pending", enumValues);
    }

    [Fact]
    public void SupportedFormatsAreIncluded()
    {
        var schema = StructuredOutput.ToJsonSchema<ModelWithFormat>();
        var properties = schema["properties"]!.AsObject();

        Assert.Equal("email", properties["email"]!["format"]!.GetValue<string>());
        Assert.Equal("uri", properties["website"]!["format"]!.GetValue<string>());
        Assert.Equal("ipv4", properties["ip"]!["format"]!.GetValue<string>());
    }

    [Fact]
    public void UnsupportedConstraintsMovedToDescription()
    {
        var schema = StructuredOutput.ToJsonSchema<ModelWithUnsupportedConstraints>();
        var properties = schema["properties"]!.AsObject();

        // Age should have constraints in description
        var ageDesc = properties["age"]!["description"]!.GetValue<string>();
        Assert.Contains("minimum", ageDesc);
        Assert.Contains("maximum", ageDesc);
        Assert.Contains("0", ageDesc);
        Assert.Contains("150", ageDesc);

        // Username should have length constraints in description
        var usernameDesc = properties["username"]!["description"]!.GetValue<string>();
        Assert.Contains("minLength", usernameDesc);
        Assert.Contains("maxLength", usernameDesc);

        // Score should have multipleOf in description
        var scoreDesc = properties["score"]!["description"]!.GetValue<string>();
        Assert.Contains("multipleOf", scoreDesc);

        // Unsupported constraints should NOT be in the schema properties directly
        var ageProps = properties["age"]!.AsObject();
        var usernameProps = properties["username"]!.AsObject();

        Assert.False(ageProps.ContainsKey("minimum"));
        Assert.False(ageProps.ContainsKey("maximum"));
        Assert.False(usernameProps.ContainsKey("minLength"));
        Assert.False(usernameProps.ContainsKey("maxLength"));
    }

    [Fact]
    public void ConstIsIncluded()
    {
        var schema = StructuredOutput.ToJsonSchema<ModelWithConst>();
        var properties = schema["properties"]!.AsObject();

        Assert.Equal("1.0", properties["version"]!["const"]!.GetValue<string>());
    }

    [Fact]
    public void DefaultIsIncluded()
    {
        var schema = StructuredOutput.ToJsonSchema<ModelWithDefault>();
        var properties = schema["properties"]!.AsObject();

        Assert.Equal("normal", properties["priority"]!["default"]!.GetValue<string>());
    }

    [Fact]
    public void JsonIgnoredPropertiesExcludedFromSchema()
    {
        var schema = StructuredOutput.ToJsonSchema<ModelWithJsonIgnore>();
        var properties = schema["properties"]!.AsObject();

        Assert.True(properties.ContainsKey("name"));
        Assert.False(properties.ContainsKey("internalToken")); // [JsonIgnore] — excluded
        Assert.False(properties.ContainsKey("conditionalField")); // [JsonIgnore(Condition=WhenWritingNull)] — excluded
    }

    [Fact]
    public void JsonIgnoredPropertiesSkippedDuringParsing()
    {
        var json = """{"name":"Alice","internalToken":"secret","conditionalField":"value"}""";

        var model = StructuredOutput.Parse<ModelWithJsonIgnore>(json);

        Assert.Equal("Alice", model.Name);
        Assert.Equal("", model.InternalToken); // not populated — [JsonIgnore]
        // [JsonIgnore(Condition=WhenWritingNull)] only affects serialization, not deserialization.
        // The property is excluded from schema (so the API won't generate it), but if JSON
        // does contain it, STJ will populate it during deserialization.
        Assert.Equal("value", model.ConditionalField);
    }

    [Fact]
    public void JsonRequiredForcesRequiredRegardlessOfNullability()
    {
        var schema = StructuredOutput.ToJsonSchema<ModelWithJsonRequired>();
        var required = schema["required"]!.AsArray().Select(r => r!.GetValue<string>()).ToList();

        Assert.Contains("nullableButRequired", required); // [JsonRequired] overrides nullable
        Assert.DoesNotContain("nullableNotRequired", required); // nullable without [JsonRequired] = optional
    }

    [Fact]
    public void NestedObjectSchema()
    {
        var schema = StructuredOutput.ToJsonSchema<ModelWithNestedObject>();
        var properties = schema["properties"]!.AsObject();

        // Address should be an object type
        var addressSchema = properties["address"]!.AsObject();
        Assert.Equal("object", addressSchema["type"]!.GetValue<string>());
        Assert.NotNull(addressSchema["properties"]);

        var addressProps = addressSchema["properties"]!.AsObject();
        Assert.Equal("string", addressProps["street"]!["type"]!.GetValue<string>());
        Assert.Equal("string", addressProps["city"]!["type"]!.GetValue<string>());
        Assert.Equal("string", addressProps["country"]!["type"]!.GetValue<string>());
        Assert.False(addressSchema["additionalProperties"]!.GetValue<bool>());
    }

    [Fact]
    public void ArrayOfObjectsSchema()
    {
        var schema = StructuredOutput.ToJsonSchema<ModelWithArrayOfObjects>();
        var properties = schema["properties"]!.AsObject();

        // Skills should be an array with items schema
        var skillsSchema = properties["skills"]!.AsObject();
        Assert.Equal("array", skillsSchema["type"]!.GetValue<string>());
        Assert.Equal(1, skillsSchema["minItems"]!.GetValue<int>());
        Assert.NotNull(skillsSchema["items"]);

        // Items should be objects
        var itemsSchema = skillsSchema["items"]!.AsObject();
        Assert.Equal("object", itemsSchema["type"]!.GetValue<string>());

        var itemsProps = itemsSchema["properties"]!.AsObject();
        Assert.Equal("string", itemsProps["name"]!["type"]!.GetValue<string>());

        var levelSchema = itemsProps["level"]!.AsObject();
        var levelEnum = levelSchema["enum"]!.AsArray().Select(v => v!.GetValue<string>()).ToList();
        Assert.Contains("beginner", levelEnum);
        Assert.Contains("intermediate", levelEnum);
        Assert.Contains("expert", levelEnum);
    }

    [Fact]
    public void MinItemsGreaterThanOneMovedToDescription()
    {
        var schema = StructuredOutput.ToJsonSchema<ModelWithArrayMinItemsUnsupported>();
        var properties = schema["properties"]!.AsObject();

        // minItems > 1 should be moved to description, not in schema
        var itemsSchema = properties["items"]!.AsObject();
        Assert.False(itemsSchema.ContainsKey("minItems"));
        var desc = itemsSchema["description"]!.GetValue<string>();
        Assert.Contains("minItems", desc);
        Assert.Contains("5", desc);
    }

    [Fact]
    public void ModelDescriptionIsIncluded()
    {
        var schema = StructuredOutput.ToJsonSchema<ModelWithCustomDescription>();

        Assert.Equal(
            "A model with a custom description",
            schema["description"]!.GetValue<string>()
        );
    }

    // =========================================================================
    // Response Parsing Tests
    // =========================================================================

    [Fact]
    public void ParseSimpleModel()
    {
        var json = """{"name":"Alice","age":30,"score":95.5,"active":true}""";

        var model = StructuredOutput.Parse<SimpleModel>(json);

        Assert.NotNull(model);
        Assert.Equal("Alice", model.Name);
        Assert.Equal(30, model.Age);
        Assert.Equal(95.5, model.Score);
        Assert.True(model.Active);
    }

    [Fact]
    public void ParseModelWithOptionalFields()
    {
        // With optional field present
        var json =
            """{"requiredField":"value","optionalField":"optional value","optionalNumber":42}""";

        var model = StructuredOutput.Parse<ModelWithOptionalFields>(json);
        Assert.Equal("value", model.RequiredField);
        Assert.Equal("optional value", model.OptionalField);
        Assert.Equal(42, model.OptionalNumber);

        // Without optional fields
        var json2 = """{"requiredField":"value"}""";
        var model2 = StructuredOutput.Parse<ModelWithOptionalFields>(json2);
        Assert.Equal("value", model2.RequiredField);
    }

    [Fact]
    public void ParseModelWithNullOptionalFields()
    {
        var json = """{"requiredField":"value","optionalField":null,"optionalNumber":null}""";

        var model = StructuredOutput.Parse<ModelWithOptionalFields>(json);
        Assert.Equal("value", model.RequiredField);
        Assert.Null(model.OptionalField);
        Assert.Null(model.OptionalNumber);
    }

    [Fact]
    public void ParseNestedObject()
    {
        var json =
            """{"name":"Alice","address":{"street":"123 Main St","city":"San Francisco","country":"USA"}}""";

        var model = StructuredOutput.Parse<ModelWithNestedObject>(json);

        Assert.Equal("Alice", model.Name);
        Assert.NotNull(model.Address);
        Assert.Equal("123 Main St", model.Address.Street);
        Assert.Equal("San Francisco", model.Address.City);
        Assert.Equal("USA", model.Address.Country);
    }

    [Fact]
    public void ParseArrayOfObjects()
    {
        var json =
            """{"name":"Bob","skills":[{"name":"C#","level":"expert"},{"name":"Python","level":"intermediate"},{"name":"Go","level":"beginner"}]}""";

        var model = StructuredOutput.Parse<ModelWithArrayOfObjects>(json);

        Assert.Equal("Bob", model.Name);
        Assert.Equal(3, model.Skills.Count);

        Assert.Equal("C#", model.Skills[0].Name);
        Assert.Equal("expert", model.Skills[0].Level);

        Assert.Equal("Python", model.Skills[1].Name);
        Assert.Equal("intermediate", model.Skills[1].Level);

        Assert.Equal("Go", model.Skills[2].Name);
        Assert.Equal("beginner", model.Skills[2].Level);
    }

    [Fact]
    public void ModelSerializesToJson()
    {
        var model = new SimpleModel
        {
            Name = "Alice",
            Age = 30,
            Score = 95.5,
            Active = true,
        };

        var json = model.ToJson();
        var parsed = JsonDocument.Parse(json);

        Assert.Equal("Alice", parsed.RootElement.GetProperty("name").GetString());
        Assert.Equal(30, parsed.RootElement.GetProperty("age").GetInt32());
        Assert.Equal(95.5, parsed.RootElement.GetProperty("score").GetDouble());
        Assert.True(parsed.RootElement.GetProperty("active").GetBoolean());
    }

    // =========================================================================
    // Edge Cases
    // =========================================================================

    [Fact]
    public void EmptyArrayParsesCorrectly()
    {
        var json = """{"name":"Bob","skills":[]}""";

        var model = StructuredOutput.Parse<ModelWithArrayOfObjects>(json);
        Assert.Equal("Bob", model.Name);
        Assert.NotNull(model.Skills);
        Assert.Empty(model.Skills);
    }

    [Fact]
    public void DescriptionWithConstraintsAppended()
    {
        // Test that constraints are properly appended to existing description
        var schema = StructuredOutput.ToJsonSchema<ModelWithUnsupportedConstraints>();
        var properties = schema["properties"]!.AsObject();
        var ageDesc = properties["age"]!["description"]!.GetValue<string>();

        // Should start with the original description
        Assert.StartsWith("Age with constraints", ageDesc);

        // Should have JSON constraints appended after double newline
        Assert.Contains("\n\n{", ageDesc);
    }

    // =========================================================================
    // JsonOutputFormat Creation Tests
    // =========================================================================

    [Fact]
    public void CreateJsonFormat_CreatesValidFormat()
    {
        var format = StructuredOutput.CreateJsonFormat<SimpleModel>();

        Assert.NotNull(format);
        Assert.NotNull(format.Schema);

        // Schema should have the expected structure
        Assert.True(format.Schema.ContainsKey("type"));
        Assert.Equal("object", format.Schema["type"].GetString());
        Assert.True(format.Schema.ContainsKey("properties"));
        Assert.True(format.Schema.ContainsKey("additionalProperties"));
        Assert.False(format.Schema["additionalProperties"].GetBoolean());
    }

    [Fact]
    public void CreateJsonFormat_IncludesNestedModels()
    {
        var format = StructuredOutput.CreateJsonFormat<ModelWithNestedObject>();

        Assert.NotNull(format);

        var properties = format.Schema["properties"];
        Assert.True(properties.TryGetProperty("address", out var addressSchema));
        Assert.Equal("object", addressSchema.GetProperty("type").GetString());
    }

    // =========================================================================
    // Beta JsonOutputFormat Creation Tests
    // =========================================================================

    [Fact]
    public void CreateBetaJsonFormat_CreatesValidFormat()
    {
        var format = StructuredOutput.CreateBetaJsonFormat<SimpleModel>();

        Assert.NotNull(format);
        Assert.NotNull(format.Schema);

        Assert.True(format.Schema.ContainsKey("type"));
        Assert.Equal("object", format.Schema["type"].GetString());
        Assert.True(format.Schema.ContainsKey("properties"));
        Assert.True(format.Schema.ContainsKey("additionalProperties"));
        Assert.False(format.Schema["additionalProperties"].GetBoolean());
    }

    [Fact]
    public void CreateBetaJsonFormat_IncludesNestedModels()
    {
        var format = StructuredOutput.CreateBetaJsonFormat<ModelWithNestedObject>();

        Assert.NotNull(format);

        var properties = format.Schema["properties"];
        Assert.True(properties.TryGetProperty("address", out var addressSchema));
        Assert.Equal("object", addressSchema.GetProperty("type").GetString());
    }

    // =========================================================================
    // Parsed Tests
    // =========================================================================

    // Minimal JSON for a GA Message with a JSON-structured text block
    const string MessageWithJsonContent =
        """{"id":"msg_test","type":"message","role":"assistant","content":[{"type":"text","text":"{\"name\":\"Alice\",\"age\":30,\"score\":95.5,\"active\":true}","citations":null}],"model":"claude-opus-4-6","stop_reason":"end_turn","stop_sequence":null,"container":null,"context_management":null,"usage":{"input_tokens":10,"output_tokens":20,"cache_creation_input_tokens":null,"cache_read_input_tokens":null,"server_tool_use":null,"cache_creation":null,"service_tier":null,"inference_geo":null}}""";

    // Minimal JSON for a GA Message with plain (non-JSON) text
    const string MessageWithPlainContent =
        """{"id":"msg_test","type":"message","role":"assistant","content":[{"type":"text","text":"plain text","citations":null}],"model":"claude-opus-4-6","stop_reason":"end_turn","stop_sequence":null,"container":null,"context_management":null,"usage":{"input_tokens":10,"output_tokens":20,"cache_creation_input_tokens":null,"cache_read_input_tokens":null,"server_tool_use":null,"cache_creation":null,"service_tier":null,"inference_geo":null}}""";

    // Minimal JSON for a Beta Message with a JSON-structured text block
    const string BetaMessageWithJsonContent =
        """{"id":"msg_test","type":"message","role":"assistant","content":[{"type":"text","text":"{\"name\":\"Alice\",\"age\":30,\"score\":95.5,\"active\":true}","citations":null}],"model":"claude-opus-4-6","stop_reason":"end_turn","stop_sequence":null,"container":null,"context_management":null,"usage":{"input_tokens":10,"output_tokens":20,"cache_creation_input_tokens":null,"cache_read_input_tokens":null,"server_tool_use":null,"cache_creation":null,"service_tier":null,"inference_geo":null,"iterations":null,"speed":null}}""";

    // Minimal JSON for a Beta Message with plain (non-JSON) text
    const string BetaMessageWithPlainContent =
        """{"id":"msg_test","type":"message","role":"assistant","content":[{"type":"text","text":"plain text","citations":null}],"model":"claude-opus-4-6","stop_reason":"end_turn","stop_sequence":null,"container":null,"context_management":null,"usage":{"input_tokens":10,"output_tokens":20,"cache_creation_input_tokens":null,"cache_read_input_tokens":null,"server_tool_use":null,"cache_creation":null,"service_tier":null,"inference_geo":null,"iterations":null,"speed":null}}""";

    static Message MessageFromJson(string json) =>
        Message.FromRawUnchecked(
            JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json)!
        );

    static BetaMessage BetaMessageFromJson(string json) =>
        BetaMessage.FromRawUnchecked(
            JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json)!
        );

    [Fact]
    public async Task Parsed_ReturnsTypedResult()
    {
        var mockService = new Mock<Anthropic.Services.IMessageService>();
        mockService
            .Setup(s =>
                s.Create(
                    It.IsAny<Anthropic.Models.Messages.MessageCreateParams>(),
                    It.IsAny<CancellationToken>()
                )
            )
            .ReturnsAsync(MessageFromJson(MessageWithJsonContent));

        var message = await mockService.Object.Create<SimpleModel>(
            new Anthropic.Models.Messages.MessageCreateParams
            {
                MaxTokens = 1024,
                Messages = [new() { Content = "", Role = Anthropic.Models.Messages.Role.User }],
                Model = Model.ClaudeSonnet4_0,
            },
            TestContext.Current.CancellationToken
        );

        var result = message.Content[0].Parsed();
        Assert.NotNull(result);
        Assert.Equal("Alice", result.Name);
        Assert.Equal(30, result.Age);
    }

    [Fact]
    public async Task Parsed_ThrowsWhenContentIsNotJson()
    {
        var mockService = new Mock<Anthropic.Services.IMessageService>();
        mockService
            .Setup(s =>
                s.Create(
                    It.IsAny<Anthropic.Models.Messages.MessageCreateParams>(),
                    It.IsAny<CancellationToken>()
                )
            )
            .ReturnsAsync(MessageFromJson(MessageWithPlainContent));

        var message = await mockService.Object.Create<SimpleModel>(
            new Anthropic.Models.Messages.MessageCreateParams
            {
                MaxTokens = 1024,
                Messages = [new() { Content = "", Role = Anthropic.Models.Messages.Role.User }],
                Model = Model.ClaudeSonnet4_0,
            },
            TestContext.Current.CancellationToken
        );

        Assert.Throws<AnthropicInvalidDataException>(() => message.Content[0].Parsed());
    }

    [Fact]
    public async Task BetaParsed_ReturnsTypedResult()
    {
        var mockService = new Mock<Anthropic.Services.Beta.IMessageService>();
        mockService
            .Setup(s =>
                s.Create(
                    It.IsAny<Anthropic.Models.Beta.Messages.MessageCreateParams>(),
                    It.IsAny<CancellationToken>()
                )
            )
            .ReturnsAsync(BetaMessageFromJson(BetaMessageWithJsonContent));

        var message = await mockService.Object.Create<SimpleModel>(
            new Anthropic.Models.Beta.Messages.MessageCreateParams
            {
                MaxTokens = 1024,
                Messages =
                [
                    new() { Content = "", Role = Anthropic.Models.Beta.Messages.Role.User },
                ],
                Model = Model.ClaudeSonnet4_0,
            },
            TestContext.Current.CancellationToken
        );

        var result = message.Content[0].Parsed();
        Assert.NotNull(result);
        Assert.Equal("Alice", result.Name);
        Assert.Equal(30, result.Age);
    }

    [Fact]
    public async Task BetaParsed_ThrowsWhenContentIsNotJson()
    {
        var mockService = new Mock<Anthropic.Services.Beta.IMessageService>();
        mockService
            .Setup(s =>
                s.Create(
                    It.IsAny<Anthropic.Models.Beta.Messages.MessageCreateParams>(),
                    It.IsAny<CancellationToken>()
                )
            )
            .ReturnsAsync(BetaMessageFromJson(BetaMessageWithPlainContent));

        var message = await mockService.Object.Create<SimpleModel>(
            new Anthropic.Models.Beta.Messages.MessageCreateParams
            {
                MaxTokens = 1024,
                Messages =
                [
                    new() { Content = "", Role = Anthropic.Models.Beta.Messages.Role.User },
                ],
                Model = Model.ClaudeSonnet4_0,
            },
            TestContext.Current.CancellationToken
        );

        Assert.Throws<AnthropicInvalidDataException>(() => message.Content[0].Parsed());
    }

    // =========================================================================
    // Round-trip / no-leak Tests
    // =========================================================================

    [Fact]
    public async Task Parsed_DoesNotLeakIntoSerializedMessage()
    {
        // Regression test: in some SDKs (PHP, Ruby) the client-side `parsed`
        // field was accidentally included when serializing the message back to
        // JSON for subsequent API requests. Verify that calling Parsed() on a
        // StructuredMessage does NOT pollute the underlying Message's RawData.

        var mockService = new Mock<Anthropic.Services.IMessageService>();
        mockService
            .Setup(s =>
                s.Create(
                    It.IsAny<Anthropic.Models.Messages.MessageCreateParams>(),
                    It.IsAny<CancellationToken>()
                )
            )
            .ReturnsAsync(MessageFromJson(MessageWithJsonContent));

        var structured = await mockService.Object.Create<SimpleModel>(
            new Anthropic.Models.Messages.MessageCreateParams
            {
                MaxTokens = 1024,
                Messages = [new() { Content = "", Role = Anthropic.Models.Messages.Role.User }],
                Model = Model.ClaudeSonnet4_0,
            },
            TestContext.Current.CancellationToken
        );

        // Force parsing so any side-effects would have occurred
        var parsed = structured.Content[0].Parsed();
        Assert.NotNull(parsed);

        // Serialize the underlying Message (as would happen when sending it back
        // as conversation history in a subsequent request)
        Message message = structured;
        var json = JsonSerializer.Serialize(message);
        using var doc = JsonDocument.Parse(json);

        // The serialized message must NOT contain a "parsed" key at the top level
        Assert.False(doc.RootElement.TryGetProperty("parsed", out _));

        // Nor should any content block contain a "parsed" key
        foreach (var block in doc.RootElement.GetProperty("content").EnumerateArray())
        {
            Assert.False(
                block.TryGetProperty("parsed", out _),
                "Content block should not contain a 'parsed' field after round-tripping"
            );
        }
    }

    [Fact]
    public async Task BetaParsed_DoesNotLeakIntoSerializedMessage()
    {
        var mockService = new Mock<Anthropic.Services.Beta.IMessageService>();
        mockService
            .Setup(s =>
                s.Create(
                    It.IsAny<Anthropic.Models.Beta.Messages.MessageCreateParams>(),
                    It.IsAny<CancellationToken>()
                )
            )
            .ReturnsAsync(BetaMessageFromJson(BetaMessageWithJsonContent));

        var structured = await mockService.Object.Create<SimpleModel>(
            new Anthropic.Models.Beta.Messages.MessageCreateParams
            {
                MaxTokens = 1024,
                Messages =
                [
                    new() { Content = "", Role = Anthropic.Models.Beta.Messages.Role.User },
                ],
                Model = Model.ClaudeSonnet4_0,
            },
            TestContext.Current.CancellationToken
        );

        var parsed = structured.Content[0].Parsed();
        Assert.NotNull(parsed);

        BetaMessage message = structured;
        var json = JsonSerializer.Serialize(message);
        using var doc = JsonDocument.Parse(json);

        Assert.False(doc.RootElement.TryGetProperty("parsed", out _));

        foreach (var block in doc.RootElement.GetProperty("content").EnumerateArray())
        {
            Assert.False(
                block.TryGetProperty("parsed", out _),
                "Content block should not contain a 'parsed' field after round-tripping"
            );
        }
    }
}
