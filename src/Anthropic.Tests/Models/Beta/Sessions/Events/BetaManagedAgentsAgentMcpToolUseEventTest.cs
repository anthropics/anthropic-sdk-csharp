using System;
using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsAgentMcpToolUseEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentMcpToolUseEvent
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            McpServerName = "mcp_server_name",
            Name = "name",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsAgentMcpToolUseEventType.AgentMcpToolUse,
            EvaluatedPermission = EvaluatedPermission.Allow,
        };

        string expectedID = "id";
        Dictionary<string, JsonElement> expectedInput = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedMcpServerName = "mcp_server_name";
        string expectedName = "name";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, BetaManagedAgentsAgentMcpToolUseEventType> expectedType =
            BetaManagedAgentsAgentMcpToolUseEventType.AgentMcpToolUse;
        ApiEnum<string, EvaluatedPermission> expectedEvaluatedPermission =
            EvaluatedPermission.Allow;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedInput.Count, model.Input.Count);
        foreach (var item in expectedInput)
        {
            Assert.True(model.Input.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Input[item.Key]));
        }
        Assert.Equal(expectedMcpServerName, model.McpServerName);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedProcessedAt, model.ProcessedAt);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedEvaluatedPermission, model.EvaluatedPermission);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentMcpToolUseEvent
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            McpServerName = "mcp_server_name",
            Name = "name",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsAgentMcpToolUseEventType.AgentMcpToolUse,
            EvaluatedPermission = EvaluatedPermission.Allow,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentMcpToolUseEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsAgentMcpToolUseEvent
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            McpServerName = "mcp_server_name",
            Name = "name",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsAgentMcpToolUseEventType.AgentMcpToolUse,
            EvaluatedPermission = EvaluatedPermission.Allow,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentMcpToolUseEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        Dictionary<string, JsonElement> expectedInput = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedMcpServerName = "mcp_server_name";
        string expectedName = "name";
        DateTimeOffset expectedProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, BetaManagedAgentsAgentMcpToolUseEventType> expectedType =
            BetaManagedAgentsAgentMcpToolUseEventType.AgentMcpToolUse;
        ApiEnum<string, EvaluatedPermission> expectedEvaluatedPermission =
            EvaluatedPermission.Allow;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedInput.Count, deserialized.Input.Count);
        foreach (var item in expectedInput)
        {
            Assert.True(deserialized.Input.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Input[item.Key]));
        }
        Assert.Equal(expectedMcpServerName, deserialized.McpServerName);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedProcessedAt, deserialized.ProcessedAt);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedEvaluatedPermission, deserialized.EvaluatedPermission);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsAgentMcpToolUseEvent
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            McpServerName = "mcp_server_name",
            Name = "name",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsAgentMcpToolUseEventType.AgentMcpToolUse,
            EvaluatedPermission = EvaluatedPermission.Allow,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsAgentMcpToolUseEvent
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            McpServerName = "mcp_server_name",
            Name = "name",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsAgentMcpToolUseEventType.AgentMcpToolUse,
        };

        Assert.Null(model.EvaluatedPermission);
        Assert.False(model.RawData.ContainsKey("evaluated_permission"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsAgentMcpToolUseEvent
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            McpServerName = "mcp_server_name",
            Name = "name",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsAgentMcpToolUseEventType.AgentMcpToolUse,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsAgentMcpToolUseEvent
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            McpServerName = "mcp_server_name",
            Name = "name",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsAgentMcpToolUseEventType.AgentMcpToolUse,

            // Null should be interpreted as omitted for these properties
            EvaluatedPermission = null,
        };

        Assert.Null(model.EvaluatedPermission);
        Assert.False(model.RawData.ContainsKey("evaluated_permission"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsAgentMcpToolUseEvent
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            McpServerName = "mcp_server_name",
            Name = "name",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsAgentMcpToolUseEventType.AgentMcpToolUse,

            // Null should be interpreted as omitted for these properties
            EvaluatedPermission = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsAgentMcpToolUseEvent
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            McpServerName = "mcp_server_name",
            Name = "name",
            ProcessedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Type = BetaManagedAgentsAgentMcpToolUseEventType.AgentMcpToolUse,
            EvaluatedPermission = EvaluatedPermission.Allow,
        };

        BetaManagedAgentsAgentMcpToolUseEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsAgentMcpToolUseEventTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsAgentMcpToolUseEventType.AgentMcpToolUse)]
    public void Validation_Works(BetaManagedAgentsAgentMcpToolUseEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentMcpToolUseEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentMcpToolUseEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsAgentMcpToolUseEventType.AgentMcpToolUse)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsAgentMcpToolUseEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentMcpToolUseEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentMcpToolUseEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentMcpToolUseEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentMcpToolUseEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class EvaluatedPermissionTest : TestBase
{
    [Theory]
    [InlineData(EvaluatedPermission.Allow)]
    [InlineData(EvaluatedPermission.Ask)]
    [InlineData(EvaluatedPermission.Deny)]
    public void Validation_Works(EvaluatedPermission rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EvaluatedPermission> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EvaluatedPermission>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EvaluatedPermission.Allow)]
    [InlineData(EvaluatedPermission.Ask)]
    [InlineData(EvaluatedPermission.Deny)]
    public void SerializationRoundtrip_Works(EvaluatedPermission rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EvaluatedPermission> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EvaluatedPermission>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, EvaluatedPermission>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, EvaluatedPermission>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
