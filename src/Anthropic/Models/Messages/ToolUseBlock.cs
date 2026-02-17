using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<ToolUseBlock, ToolUseBlockFromRaw>))]
public sealed record class ToolUseBlock : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Tool invocation directly from the model.
    /// </summary>
    public required ToolUseBlockCaller Caller
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ToolUseBlockCaller>("caller");
        }
        init { this._rawData.Set("caller", value); }
    }

    public required IReadOnlyDictionary<string, JsonElement> Input
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>("input");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "input",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Caller.Validate();
        _ = this.Input;
        _ = this.Name;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("tool_use")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ToolUseBlock()
    {
        this.Type = JsonSerializer.SerializeToElement("tool_use");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ToolUseBlock(ToolUseBlock toolUseBlock)
        : base(toolUseBlock) { }
#pragma warning restore CS8618

    public ToolUseBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("tool_use");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolUseBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolUseBlockFromRaw.FromRawUnchecked"/>
    public static ToolUseBlock FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ToolUseBlockFromRaw : IFromRawJson<ToolUseBlock>
{
    /// <inheritdoc/>
    public ToolUseBlock FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ToolUseBlock.FromRawUnchecked(rawData);
}

/// <summary>
/// Tool invocation directly from the model.
/// </summary>
[JsonConverter(typeof(ToolUseBlockCallerConverter))]
public record class ToolUseBlockCaller : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            return Match(
                direct: (x) => x.Type,
                serverTool: (x) => x.Type,
                codeExecution20260120: (x) => x.Type
            );
        }
    }

    public string? ToolID
    {
        get
        {
            return Match<string?>(
                direct: (_) => null,
                serverTool: (x) => x.ToolID,
                codeExecution20260120: (x) => x.ToolID
            );
        }
    }

    public ToolUseBlockCaller(DirectCaller value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ToolUseBlockCaller(ServerToolCaller value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ToolUseBlockCaller(
        ToolUseBlockCallerCodeExecution20260120 value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ToolUseBlockCaller(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="DirectCaller"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDirect(out var value)) {
    ///     // `value` is of type `DirectCaller`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDirect([NotNullWhen(true)] out DirectCaller? value)
    {
        value = this.Value as DirectCaller;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ServerToolCaller"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickServerTool(out var value)) {
    ///     // `value` is of type `ServerToolCaller`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickServerTool([NotNullWhen(true)] out ServerToolCaller? value)
    {
        value = this.Value as ServerToolCaller;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ToolUseBlockCallerCodeExecution20260120"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCodeExecution20260120(out var value)) {
    ///     // `value` is of type `ToolUseBlockCallerCodeExecution20260120`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCodeExecution20260120(
        [NotNullWhen(true)] out ToolUseBlockCallerCodeExecution20260120? value
    )
    {
        value = this.Value as ToolUseBlockCallerCodeExecution20260120;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (DirectCaller value) => {...},
    ///     (ServerToolCaller value) => {...},
    ///     (ToolUseBlockCallerCodeExecution20260120 value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<DirectCaller> direct,
        System::Action<ServerToolCaller> serverTool,
        System::Action<ToolUseBlockCallerCodeExecution20260120> codeExecution20260120
    )
    {
        switch (this.Value)
        {
            case DirectCaller value:
                direct(value);
                break;
            case ServerToolCaller value:
                serverTool(value);
                break;
            case ToolUseBlockCallerCodeExecution20260120 value:
                codeExecution20260120(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ToolUseBlockCaller"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (DirectCaller value) => {...},
    ///     (ServerToolCaller value) => {...},
    ///     (ToolUseBlockCallerCodeExecution20260120 value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<DirectCaller, T> direct,
        System::Func<ServerToolCaller, T> serverTool,
        System::Func<ToolUseBlockCallerCodeExecution20260120, T> codeExecution20260120
    )
    {
        return this.Value switch
        {
            DirectCaller value => direct(value),
            ServerToolCaller value => serverTool(value),
            ToolUseBlockCallerCodeExecution20260120 value => codeExecution20260120(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ToolUseBlockCaller"
            ),
        };
    }

    public static implicit operator ToolUseBlockCaller(DirectCaller value) => new(value);

    public static implicit operator ToolUseBlockCaller(ServerToolCaller value) => new(value);

    public static implicit operator ToolUseBlockCaller(
        ToolUseBlockCallerCodeExecution20260120 value
    ) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of ToolUseBlockCaller"
            );
        }
        this.Switch(
            (direct) => direct.Validate(),
            (serverTool) => serverTool.Validate(),
            (codeExecution20260120) => codeExecution20260120.Validate()
        );
    }

    public virtual bool Equals(ToolUseBlockCaller? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            DirectCaller _ => 0,
            ServerToolCaller _ => 1,
            ToolUseBlockCallerCodeExecution20260120 _ => 2,
            _ => -1,
        };
    }
}

sealed class ToolUseBlockCallerConverter : JsonConverter<ToolUseBlockCaller>
{
    public override ToolUseBlockCaller? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "direct":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<DirectCaller>(element, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "code_execution_20250825":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ServerToolCaller>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "code_execution_20260120":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<ToolUseBlockCallerCodeExecution20260120>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new ToolUseBlockCaller(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ToolUseBlockCaller value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ToolUseBlockCallerCodeExecution20260120,
        ToolUseBlockCallerCodeExecution20260120FromRaw
    >)
)]
public sealed record class ToolUseBlockCallerCodeExecution20260120 : JsonModel
{
    public required string ToolID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tool_id");
        }
        init { this._rawData.Set("tool_id", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ToolID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("code_execution_20260120")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ToolUseBlockCallerCodeExecution20260120()
    {
        this.Type = JsonSerializer.SerializeToElement("code_execution_20260120");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ToolUseBlockCallerCodeExecution20260120(
        ToolUseBlockCallerCodeExecution20260120 toolUseBlockCallerCodeExecution20260120
    )
        : base(toolUseBlockCallerCodeExecution20260120) { }
#pragma warning restore CS8618

    public ToolUseBlockCallerCodeExecution20260120(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("code_execution_20260120");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolUseBlockCallerCodeExecution20260120(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolUseBlockCallerCodeExecution20260120FromRaw.FromRawUnchecked"/>
    public static ToolUseBlockCallerCodeExecution20260120 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ToolUseBlockCallerCodeExecution20260120(string toolID)
        : this()
    {
        this.ToolID = toolID;
    }
}

class ToolUseBlockCallerCodeExecution20260120FromRaw
    : IFromRawJson<ToolUseBlockCallerCodeExecution20260120>
{
    /// <inheritdoc/>
    public ToolUseBlockCallerCodeExecution20260120 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ToolUseBlockCallerCodeExecution20260120.FromRawUnchecked(rawData);
}
