using System;

namespace Anthropic.Helpers;

/// <summary>
/// Optional attribute for defining class-level schema metadata.
///
/// <para>Use this attribute to add a description to your model class. This description
/// will be included in the generated JSON schema for better LLM understanding.</para>
/// </summary>
/// <example>
/// <code>
/// [SchemaClass("A person with their name and age")]
/// public class Person
/// {
///     [SchemaProperty("The person's full name")]
///     public string Name { get; set; }
///
///     [SchemaProperty("The person's age in years")]
///     public int Age { get; set; }
/// }
/// </code>
/// </example>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public sealed class SchemaClassAttribute : Attribute
{
    /// <summary>
    /// Human-readable description of the class (optional but recommended for better LLM output).
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Creates a new schema class attribute.
    /// </summary>
    /// <param name="description">Human-readable description of the class.</param>
    public SchemaClassAttribute(string? description = null)
    {
        Description = description;
    }
}
