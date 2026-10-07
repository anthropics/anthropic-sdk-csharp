using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Which party invoked the tool call: the model directly, or a server tool on its behalf.
/// </summary>
[JsonConverter(typeof(BetaToolUseCallerConverter))]
public record class BetaToolUseCaller : ModelBase
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
            return this.Value switch
            {
                BetaDirectCaller x => x.Type,
                BetaServerToolCaller x => x.Type,
                BetaServerToolCaller20260120 x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public string? ToolID
    {
        get
        {
            return this.Value switch
            {
                BetaDirectCaller _ => null,
                BetaServerToolCaller x => x.ToolID,
                BetaServerToolCaller20260120 x => x.ToolID,
                _ => WrappedJsonSerializer.GetNullableClassProperty<string>(this.Json, "tool_id"),
            };
        }
    }

    public BetaToolUseCaller(BetaDirectCaller value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaToolUseCaller(BetaServerToolCaller value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaToolUseCaller(BetaServerToolCaller20260120 value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaToolUseCaller(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaDirectCaller"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDirect(out var value)) {
    ///     // `value` is of type `BetaDirectCaller`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDirect([NotNullWhen(true)] out BetaDirectCaller? value)
    {
        value = this.Value as BetaDirectCaller;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaServerToolCaller"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickServerTool(out var value)) {
    ///     // `value` is of type `BetaServerToolCaller`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickServerTool([NotNullWhen(true)] out BetaServerToolCaller? value)
    {
        value = this.Value as BetaServerToolCaller;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaServerToolCaller20260120"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickServerToolCaller20260120(out var value)) {
    ///     // `value` is of type `BetaServerToolCaller20260120`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickServerToolCaller20260120(
        [NotNullWhen(true)] out BetaServerToolCaller20260120? value
    )
    {
        value = this.Value as BetaServerToolCaller20260120;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
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
    ///     (BetaDirectCaller value) =&gt; {...},
    ///     (BetaServerToolCaller value) =&gt; {...},
    ///     (BetaServerToolCaller20260120 value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaDirectCaller> direct,
        System::Action<BetaServerToolCaller> serverTool,
        System::Action<BetaServerToolCaller20260120> serverToolCaller20260120
    )
    {
        switch (this.Value)
        {
            case BetaDirectCaller value:
                direct(value);
                break;
            case BetaServerToolCaller value:
                serverTool(value);
                break;
            case BetaServerToolCaller20260120 value:
                serverToolCaller20260120(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaToolUseCaller"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
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
    ///     (BetaDirectCaller value) =&gt; {...},
    ///     (BetaServerToolCaller value) =&gt; {...},
    ///     (BetaServerToolCaller20260120 value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaDirectCaller, T> direct,
        System::Func<BetaServerToolCaller, T> serverTool,
        System::Func<BetaServerToolCaller20260120, T> serverToolCaller20260120
    )
    {
        return this.Value switch
        {
            BetaDirectCaller value => direct(value),
            BetaServerToolCaller value => serverTool(value),
            BetaServerToolCaller20260120 value => serverToolCaller20260120(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaToolUseCaller"
            ),
        };
    }

    public static implicit operator BetaToolUseCaller(BetaDirectCaller value) => new(value);

    public static implicit operator BetaToolUseCaller(BetaServerToolCaller value) => new(value);

    public static implicit operator BetaToolUseCaller(BetaServerToolCaller20260120 value) =>
        new(value);

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
                "Data did not match any variant of BetaToolUseCaller"
            );
        }
        this.Switch(
            (direct) => direct.Validate(),
            (serverTool) => serverTool.Validate(),
            (serverToolCaller20260120) => serverToolCaller20260120.Validate()
        );
    }

    public virtual bool Equals(BetaToolUseCaller? other) =>
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
            BetaDirectCaller _ => 0,
            BetaServerToolCaller _ => 1,
            BetaServerToolCaller20260120 _ => 2,
            _ => -1,
        };
    }
}

sealed class BetaToolUseCallerConverter : JsonConverter<BetaToolUseCaller>
{
    public override BetaToolUseCaller? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaDirectCaller>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "code_execution_20250825":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaServerToolCaller>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "code_execution_20260120":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaServerToolCaller20260120>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new BetaToolUseCaller(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaToolUseCaller value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
