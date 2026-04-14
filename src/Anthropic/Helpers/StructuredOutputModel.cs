using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Helpers;

/// <summary>
/// Optional base class for defining structured output models.
///
/// <para><b>NOTE:</b> This base class is optional! You can use any class with public properties
/// and a parameterless constructor for structured outputs. This base class provides convenience
/// methods like <see cref="ToJson"/> for backward compatibility.</para>
///
/// <para>Use the <see cref="SchemaClassAttribute"/> attribute on the class
/// and <see cref="SchemaPropertyAttribute"/> attribute on properties
/// to define your structured output schema. The SDK will automatically convert
/// your model to a JSON schema for the API and parse responses back into instances.</para>
///
/// <para><b>Type Inference:</b></para>
/// <para>Types and required/optional status are automatically inferred from C# types:</para>
/// <list type="bullet">
/// <item><c>string Name</c> -> required string</item>
/// <item><c>string? Name</c> -> optional string</item>
/// <item><c>int Age</c> -> required integer</item>
/// <item><c>double Price</c> -> required number</item>
/// <item><c>bool Active</c> -> required boolean</item>
/// <item><c>List&lt;T&gt; Items</c> -> required array (item type auto-detected)</item>
/// <item><c>NestedModel Child</c> -> required nested object (auto-detected)</item>
/// </list>
///
/// <para><b>Nested Models:</b></para>
/// <para>For nested objects, you have two options:</para>
/// <list type="number">
/// <item>Type hint with the model class directly: <c>public NestedModel Child { get; set; }</c></item>
/// <item>For arrays of models, the generic type argument is used: <c>public List&lt;Item&gt; Items { get; set; }</c></item>
/// </list>
/// </summary>
/// <example>
/// <code>
/// [SchemaClass("A mathematically significant number")]
/// public class FamousNumber : StructuredOutputModel
/// {
///     [SchemaProperty("The numerical value")]
///     public double Value { get; set; }
///
///     [SchemaProperty("Why this number is mathematically significant")]
///     public string? Reason { get; set; }  // Automatically optional due to ?
/// }
///
/// [SchemaClass("A collection of famous numbers")]
/// public class Output : StructuredOutputModel
/// {
///     [SchemaProperty("A list of famous numbers", MinItems = 1)]
///     public List&lt;FamousNumber&gt; Numbers { get; set; } = new();
/// }
///
/// // Use with the Messages API:
/// var message = await client.Messages.Create&lt;Output&gt;(new MessageCreateParams
/// {
///     MaxTokens = 1024,
///     Messages = [new MessageParam { Role = "user", Content = "Give me some famous numbers" }],
///     Model = "claude-sonnet-4-5-20250929",
/// });
///
/// // Find the first text block and access the parsed output:
/// var output = message.Content.Select(b => b.Parsed()).FirstOrDefault(p => p != null);
/// foreach (var number in output.Numbers)
/// {
///     Console.WriteLine($"{number.Value}: {number.Reason}");
/// }
/// </code>
/// </example>
public abstract class StructuredOutputModel
{
    static readonly JsonSerializerOptions SerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = false,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    };

    /// <summary>
    /// Converts the model to a JSON string.
    /// </summary>
    public string ToJson()
    {
        return JsonSerializer.Serialize(this, GetType(), SerializerOptions);
    }

    /// <summary>
    /// Creates an instance from a JSON string.
    /// </summary>
    public static T FromJson<T>(string json)
        where T : StructuredOutputModel, new()
    {
        return StructuredOutput.Parse<T>(json);
    }

    /// <summary>
    /// Creates an instance from a JsonElement.
    /// </summary>
    public static T FromJsonElement<T>(JsonElement element)
        where T : StructuredOutputModel, new()
    {
        if (!typeof(StructuredOutputModel).IsAssignableFrom(typeof(T)))
        {
            throw new ArgumentException(
                $"Type {typeof(T).FullName} must inherit from StructuredOutputModel",
                nameof(T)
            );
        }

        return StructuredOutput.Parse<T>(element);
    }
}
