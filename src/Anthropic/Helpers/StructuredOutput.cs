using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Anthropic.Models.Beta.Messages;
using Anthropic.Models.Messages;

namespace Anthropic.Helpers;

/// <summary>
/// Helper class for working with structured output models.
///
/// <para>This class provides utilities to:</para>
/// <list type="bullet">
/// <item>Convert C# classes to JSON schemas for the Anthropic API</item>
/// <item>Transform schemas for API compatibility (removing unsupported constraints)</item>
/// <item>Parse and validate API responses back into model instances</item>
/// </list>
/// </summary>
public static class StructuredOutput
{
    /// <summary>
    /// Creates a JsonOutputFormat with a schema generated from the specified model type.
    /// </summary>
    /// <typeparam name="T">The type to generate schema from.</typeparam>
    /// <returns>A JsonOutputFormat ready to be used in OutputConfig.</returns>
    public static JsonOutputFormat CreateJsonFormat<T>()
    {
        var schema = SchemaInference.GenerateSchema<T>();
        return new JsonOutputFormat { Schema = ToJsonElementDict(schema) };
    }

    /// <summary>
    /// Creates a BetaJsonOutputFormat with a schema generated from the specified model type.
    /// </summary>
    /// <typeparam name="T">The type to generate schema from.</typeparam>
    /// <returns>A BetaJsonOutputFormat ready to be used in BetaOutputConfig.</returns>
    public static BetaJsonOutputFormat CreateBetaJsonFormat<T>()
    {
        var schema = SchemaInference.GenerateSchema<T>();
        return new BetaJsonOutputFormat { Schema = ToJsonElementDict(schema) };
    }

    /// <summary>
    /// Generates a JSON schema for the given type as a JsonObject.
    /// Useful for inspecting the schema that will be sent to the API.
    /// </summary>
    public static JsonObject ToJsonSchema<T>()
    {
        return SchemaInference.GenerateSchema<T>();
    }

    /// <summary>
    /// Parses a JSON string into a model instance of type T.
    /// </summary>
    public static T Parse<T>(string json)
        where T : new()
    {
        return JsonSerializer.Deserialize<T>(json, DeserializeOptions)
            ?? throw new JsonException($"Failed to deserialize {typeof(T).Name}");
    }

    /// <summary>
    /// Parses a JsonElement into a model instance of type T.
    /// </summary>
    public static T Parse<T>(JsonElement element)
        where T : new()
    {
        return JsonSerializer.Deserialize<T>(element.GetRawText(), DeserializeOptions)
            ?? throw new JsonException($"Failed to deserialize {typeof(T).FullName}");
    }

    static Dictionary<string, JsonElement> ToJsonElementDict(JsonObject schema)
    {
        var result = new Dictionary<string, JsonElement>();
        foreach (var kvp in schema)
        {
            result[kvp.Key] = JsonSerializer.SerializeToElement(kvp.Value);
        }
        return result;
    }

    static readonly JsonSerializerOptions DeserializeOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters = { new JsonStringEnumConverter(JsonNamingPolicy.SnakeCaseLower) },
    };
}
