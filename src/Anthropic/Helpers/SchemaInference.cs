using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Schema;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace Anthropic.Helpers;

/// <summary>
/// Generates JSON schema from C# types using System.Text.Json's built-in schema exporter,
/// with transforms for Anthropic API compatibility (additionalProperties: false, unsupported
/// constraint migration, SchemaPropertyAttribute/SchemaClassAttribute processing).
/// </summary>
internal static class SchemaInference
{
    static readonly JsonSerializerOptions SchemaOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        TypeInfoResolver = new DefaultJsonTypeInfoResolver(),
        Converters = { new JsonStringEnumConverter(JsonNamingPolicy.SnakeCaseLower) },
    };

    static readonly JsonSchemaExporterOptions ExporterOptions = new()
    {
        TreatNullObliviousAsNonNullable = true,
        TransformSchemaNode = TransformSchema,
    };

    /// <summary>
    /// Generates a JSON schema for the given type, transformed for the Anthropic API.
    /// </summary>
    internal static JsonObject GenerateSchema<T>()
    {
        var node = JsonSchemaExporter.GetJsonSchemaAsNode(
            SchemaOptions,
            typeof(T),
            ExporterOptions
        );
        return node as JsonObject
            ?? throw new InvalidOperationException(
                $"Expected JsonObject schema for {typeof(T).FullName}"
            );
    }

    static JsonNode TransformSchema(JsonSchemaExporterContext context, JsonNode schema)
    {
        if (schema is not JsonObject obj)
            return schema;

        // --- Property-level: apply SchemaPropertyAttribute ---
        if (context.PropertyInfo?.AttributeProvider != null)
        {
            var attrs = context.PropertyInfo.AttributeProvider.GetCustomAttributes(
                typeof(SchemaPropertyAttribute),
                false
            );
            if (attrs.Length > 0 && attrs[0] is SchemaPropertyAttribute attr)
                ApplySchemaPropertyAttribute(obj, attr);
        }

        // --- Object-level: fix required array, strip null unions, add additionalProperties ---
        if (
            obj.TryGetPropertyValue("properties", out var propsNode)
            && propsNode is JsonObject props
        )
        {
            // Collect existing required entries (from [JsonRequired])
            var existingRequired = new HashSet<string>();
            if (obj.TryGetPropertyValue("required", out var reqNode) && reqNode is JsonArray reqArr)
            {
                foreach (var item in reqArr)
                {
                    var val = item?.GetValue<string>();
                    if (val != null)
                        existingRequired.Add(val);
                }
            }

            // Filter out [JsonIgnore(Condition != Never)] properties that STJ still includes
            // (e.g. WhenWritingNull, WhenWritingDefault)
            if (context.TypeInfo != null)
            {
                var propsToRemove = new List<string>();
                foreach (var prop in context.TypeInfo.Properties)
                {
                    var ignoreAttrs = prop.AttributeProvider?.GetCustomAttributes(
                        typeof(JsonIgnoreAttribute),
                        false
                    );
                    if (
                        ignoreAttrs?.Length > 0
                        && ignoreAttrs[0] is JsonIgnoreAttribute ignoreAttr
                        && ignoreAttr.Condition != JsonIgnoreCondition.Never
                        && ignoreAttr.Condition != JsonIgnoreCondition.Always
                    )
                    {
                        propsToRemove.Add(prop.Name);
                    }
                }
                foreach (var name in propsToRemove)
                    props.Remove(name);
            }

            // Build required array and strip null from type unions
            var required = new JsonArray();
            foreach (var kvp in props)
            {
                if (kvp.Value is not JsonObject propObj)
                    continue;

                bool wasNullable = false;
                if (
                    propObj.TryGetPropertyValue("type", out var typeNode)
                    && typeNode is JsonArray typeArr
                )
                {
                    // Strip "null" from type union → single type string
                    string? nonNullType = null;
                    foreach (var t in typeArr)
                    {
                        var v = t?.GetValue<string>();
                        if (v == "null")
                            wasNullable = true;
                        else if (v != null && nonNullType == null)
                            nonNullType = v;
                    }
                    if (nonNullType != null)
                        propObj["type"] = nonNullType;
                }

                // Non-nullable properties and [JsonRequired] properties are required
                if (!wasNullable || existingRequired.Contains(kvp.Key))
                    required.Add(JsonValue.Create(kvp.Key));
            }

            if (required.Count > 0)
                obj["required"] = required;
            else
                obj.Remove("required");

            obj["additionalProperties"] = false;

            // SchemaClassAttribute description
            if (context.TypeInfo?.Type != null)
            {
                var classAttr = context.TypeInfo.Type.GetCustomAttribute<SchemaClassAttribute>();
                if (classAttr?.Description != null)
                    obj["description"] = classAttr.Description;
            }
        }

        return schema;
    }

    static void ApplySchemaPropertyAttribute(JsonObject obj, SchemaPropertyAttribute attr)
    {
        var unsupported = new Dictionary<string, object?>();

        string? description = !string.IsNullOrEmpty(attr.Description) ? attr.Description : null;

        // Unsupported constraints → move to description
        if (attr.HasMinLength)
            unsupported["minLength"] = attr.MinLength;
        if (attr.HasMaxLength)
            unsupported["maxLength"] = attr.MaxLength;
        if (attr.HasMinimum)
            unsupported["minimum"] = attr.Minimum;
        if (attr.HasMaximum)
            unsupported["maximum"] = attr.Maximum;
        if (attr.HasMultipleOf)
            unsupported["multipleOf"] = attr.MultipleOf;

        // Format (supported)
        if (attr.Format != StringFormat.Unspecified)
            obj["format"] = attr.Format.ToFormatString();

        // Enum (supported)
        if (attr.Enum != null)
        {
            var enumArr = new JsonArray();
            foreach (var val in attr.Enum)
                enumArr.Add(JsonSerializer.SerializeToNode(val));
            obj["enum"] = enumArr;
        }

        // Const (supported)
        if (attr.Const != null)
            obj["const"] = JsonSerializer.SerializeToNode(attr.Const);

        // Default (supported — explicit attribute value only)
        if (attr.Default != null)
            obj["default"] = JsonSerializer.SerializeToNode(attr.Default);

        // MinItems for arrays (0 and 1 supported, >1 unsupported)
        if (attr.HasMinItems)
        {
            if (attr.MinItems <= 1)
                obj["minItems"] = attr.MinItems;
            else
                unsupported["minItems"] = attr.MinItems;
        }

        // Append unsupported constraints to description
        if (unsupported.Count > 0)
        {
            var constraintsJson = JsonSerializer.Serialize(unsupported);
            description =
                description != null ? description + "\n\n" + constraintsJson : constraintsJson;
        }

        if (description != null)
            obj["description"] = description;
    }
}
