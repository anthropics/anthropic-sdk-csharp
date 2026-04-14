using System;

namespace Anthropic.Helpers;

/// <summary>
/// Optional attribute for schema properties with minimal boilerplate.
///
/// <para>The SDK automatically infers:</para>
/// <list type="bullet">
/// <item>Type from C# type hints (string, int, double, bool, arrays)</item>
/// <item>Required/optional from nullable types</item>
/// <item>Array item types from generic type arguments</item>
/// </list>
///
/// <para><b>Nullable reference type detection:</b> The SDK infers whether a reference-type
/// property (e.g. <c>string?</c>, <c>MyClass?</c>) is optional from C# nullable annotations.
/// This requires <c>&lt;Nullable&gt;enable&lt;/Nullable&gt;</c> in your project file — without
/// it, all reference-type properties are treated as required regardless of the <c>?</c>
/// annotation. Nullable value types (<c>int?</c>, <c>bool?</c>, etc.) are always detected
/// correctly on all targets.</para>
///
/// <para>This attribute is completely optional! Use it only when you need to add:</para>
/// <list type="bullet">
/// <item>Descriptions (recommended for better LLM output)</item>
/// <item>Constraints (min/max values, lengths, enums, etc.)</item>
/// <item>Explicit array minimum items</item>
/// </list>
///
/// <para><b>Supported JSON Schema Features:</b></para>
/// <para>The following are fully supported in the API:</para>
/// <list type="bullet">
/// <item>Description - Property descriptions</item>
/// <item>Enum - Enumerated values (strings, numbers, bools, nulls only)</item>
/// <item>Const - Constant values</item>
/// <item>Default - Default values</item>
/// <item>Format - String formats (see <see cref="StringFormat"/>)</item>
/// <item>MinItems - Array minimum items (only 0 and 1 supported)</item>
/// </list>
///
/// <para><b>Not Supported by API (moved to description):</b></para>
/// <para>The following constraints are NOT supported by the API and will be:</para>
/// <list type="number">
/// <item>Removed from the schema sent to the API</item>
/// <item>Added to the description as a stringified JSON block for reference</item>
/// <item>Validated on the SDK side when parsing responses</item>
/// </list>
/// <list type="bullet">
/// <item>Minimum, Maximum, MultipleOf - Numerical constraints</item>
/// <item>MinLength, MaxLength - String length constraints</item>
/// <item>MinItems &gt; 1 - Array minimum items beyond 0 or 1</item>
/// </list>
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public sealed class SchemaPropertyAttribute : Attribute
{
    /// <summary>
    /// Value used to indicate that an integer constraint is not set.
    /// </summary>
    public const int NotSetInt = int.MinValue;

    /// <summary>
    /// Value used to indicate that a double constraint is not set.
    /// </summary>
    public const double NotSetDouble = double.MinValue;

    /// <summary>
    /// Human-readable description (optional but recommended for better LLM output).
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// For strings: minimum length (NOT SUPPORTED by API - moved to description).
    /// Use <see cref="NotSetInt"/> or leave default to indicate not set.
    /// </summary>
    public int MinLength { get; set; } = NotSetInt;

    /// <summary>
    /// For strings: maximum length (NOT SUPPORTED by API - moved to description).
    /// Use <see cref="NotSetInt"/> or leave default to indicate not set.
    /// </summary>
    public int MaxLength { get; set; } = NotSetInt;

    /// <summary>
    /// For numbers: minimum value (NOT SUPPORTED by API - moved to description).
    /// Use <see cref="NotSetDouble"/> or leave default to indicate not set.
    /// </summary>
    public double Minimum { get; set; } = NotSetDouble;

    /// <summary>
    /// For numbers: maximum value (NOT SUPPORTED by API - moved to description).
    /// Use <see cref="NotSetDouble"/> or leave default to indicate not set.
    /// </summary>
    public double Maximum { get; set; } = NotSetDouble;

    /// <summary>
    /// For numbers: must be multiple of this value (NOT SUPPORTED by API - moved to description).
    /// Use <see cref="NotSetDouble"/> or leave default to indicate not set.
    /// </summary>
    public double MultipleOf { get; set; } = NotSetDouble;

    /// <summary>
    /// Array of allowed values (strings, numbers, bools, nulls only).
    /// </summary>
    public object[]? Enum { get; set; }

    /// <summary>
    /// Constant value that this property must equal.
    /// </summary>
    public object? Const { get; set; }

    /// <summary>
    /// Default value for this property.
    /// </summary>
    public object? Default { get; set; }

    /// <summary>
    /// String format. See <see cref="StringFormat"/> for supported values.
    /// </summary>
    public StringFormat Format { get; set; } = StringFormat.Unspecified;

    /// <summary>
    /// For arrays: minimum number of items (only 0 and 1 supported by API).
    /// Use <see cref="NotSetInt"/> or leave default to indicate not set.
    /// </summary>
    public int MinItems { get; set; } = NotSetInt;

    /// <summary>
    /// Creates a new schema property attribute.
    /// </summary>
    /// <param name="description">Human-readable description of the property.</param>
    public SchemaPropertyAttribute(string? description = null)
    {
        Description = description;
    }

    /// <summary>
    /// Check if MinLength has been set.
    /// </summary>
    public bool HasMinLength => MinLength != NotSetInt;

    /// <summary>
    /// Check if MaxLength has been set.
    /// </summary>
    public bool HasMaxLength => MaxLength != NotSetInt;

    /// <summary>
    /// Check if Minimum has been set.
    /// </summary>
    public bool HasMinimum => Minimum != NotSetDouble;

    /// <summary>
    /// Check if Maximum has been set.
    /// </summary>
    public bool HasMaximum => Maximum != NotSetDouble;

    /// <summary>
    /// Check if MultipleOf has been set.
    /// </summary>
    public bool HasMultipleOf => MultipleOf != NotSetDouble;

    /// <summary>
    /// Check if MinItems has been set.
    /// </summary>
    public bool HasMinItems => MinItems != NotSetInt;
}
