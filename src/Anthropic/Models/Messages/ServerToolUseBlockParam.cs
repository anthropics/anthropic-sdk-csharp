using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<ServerToolUseBlockParam, ServerToolUseBlockParamFromRaw>))]
public sealed record class ServerToolUseBlockParam : JsonModel
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

    public required ApiEnum<string, ServerToolUseBlockParamName> Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ServerToolUseBlockParamName>>(
                "name"
            );
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

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public CacheControlEphemeral? CacheControl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CacheControlEphemeral>("cache_control");
        }
        init { this._rawData.Set("cache_control", value); }
    }

    /// <summary>
    /// Tool invocation directly from the model.
    /// </summary>
    public ServerToolUseBlockParamCaller? Caller
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ServerToolUseBlockParamCaller>("caller");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("caller", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Input;
        this.Name.Validate();
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("server_tool_use"))
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
        this.Caller?.Validate();
    }

    public ServerToolUseBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("server_tool_use");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ServerToolUseBlockParam(ServerToolUseBlockParam serverToolUseBlockParam)
        : base(serverToolUseBlockParam) { }
#pragma warning restore CS8618

    public ServerToolUseBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("server_tool_use");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ServerToolUseBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ServerToolUseBlockParamFromRaw.FromRawUnchecked"/>
    public static ServerToolUseBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ServerToolUseBlockParamFromRaw : IFromRawJson<ServerToolUseBlockParam>
{
    /// <inheritdoc/>
    public ServerToolUseBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ServerToolUseBlockParam.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ServerToolUseBlockParamNameConverter))]
public enum ServerToolUseBlockParamName
{
    WebSearch,
    WebFetch,
    CodeExecution,
    BashCodeExecution,
    TextEditorCodeExecution,
    ToolSearchToolRegex,
    ToolSearchToolBm25,
}

sealed class ServerToolUseBlockParamNameConverter : JsonConverter<ServerToolUseBlockParamName>
{
    public override ServerToolUseBlockParamName Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "web_search" => ServerToolUseBlockParamName.WebSearch,
            "web_fetch" => ServerToolUseBlockParamName.WebFetch,
            "code_execution" => ServerToolUseBlockParamName.CodeExecution,
            "bash_code_execution" => ServerToolUseBlockParamName.BashCodeExecution,
            "text_editor_code_execution" => ServerToolUseBlockParamName.TextEditorCodeExecution,
            "tool_search_tool_regex" => ServerToolUseBlockParamName.ToolSearchToolRegex,
            "tool_search_tool_bm25" => ServerToolUseBlockParamName.ToolSearchToolBm25,
            _ => (ServerToolUseBlockParamName)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ServerToolUseBlockParamName value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ServerToolUseBlockParamName.WebSearch => "web_search",
                ServerToolUseBlockParamName.WebFetch => "web_fetch",
                ServerToolUseBlockParamName.CodeExecution => "code_execution",
                ServerToolUseBlockParamName.BashCodeExecution => "bash_code_execution",
                ServerToolUseBlockParamName.TextEditorCodeExecution => "text_editor_code_execution",
                ServerToolUseBlockParamName.ToolSearchToolRegex => "tool_search_tool_regex",
                ServerToolUseBlockParamName.ToolSearchToolBm25 => "tool_search_tool_bm25",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Tool invocation directly from the model.
/// </summary>
[JsonConverter(typeof(ServerToolUseBlockParamCallerConverter))]
public record class ServerToolUseBlockParamCaller : ModelBase
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

    public ServerToolUseBlockParamCaller(DirectCaller value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ServerToolUseBlockParamCaller(ServerToolCaller value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ServerToolUseBlockParamCaller(
        ServerToolUseBlockParamCallerCodeExecution20260120 value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ServerToolUseBlockParamCaller(JsonElement element)
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
    /// type <see cref="ServerToolUseBlockParamCallerCodeExecution20260120"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCodeExecution20260120(out var value)) {
    ///     // `value` is of type `ServerToolUseBlockParamCallerCodeExecution20260120`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCodeExecution20260120(
        [NotNullWhen(true)] out ServerToolUseBlockParamCallerCodeExecution20260120? value
    )
    {
        value = this.Value as ServerToolUseBlockParamCallerCodeExecution20260120;
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
    ///     (ServerToolUseBlockParamCallerCodeExecution20260120 value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<DirectCaller> direct,
        System::Action<ServerToolCaller> serverTool,
        System::Action<ServerToolUseBlockParamCallerCodeExecution20260120> codeExecution20260120
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
            case ServerToolUseBlockParamCallerCodeExecution20260120 value:
                codeExecution20260120(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ServerToolUseBlockParamCaller"
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
    ///     (ServerToolUseBlockParamCallerCodeExecution20260120 value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<DirectCaller, T> direct,
        System::Func<ServerToolCaller, T> serverTool,
        System::Func<ServerToolUseBlockParamCallerCodeExecution20260120, T> codeExecution20260120
    )
    {
        return this.Value switch
        {
            DirectCaller value => direct(value),
            ServerToolCaller value => serverTool(value),
            ServerToolUseBlockParamCallerCodeExecution20260120 value => codeExecution20260120(
                value
            ),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ServerToolUseBlockParamCaller"
            ),
        };
    }

    public static implicit operator ServerToolUseBlockParamCaller(DirectCaller value) => new(value);

    public static implicit operator ServerToolUseBlockParamCaller(ServerToolCaller value) =>
        new(value);

    public static implicit operator ServerToolUseBlockParamCaller(
        ServerToolUseBlockParamCallerCodeExecution20260120 value
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
                "Data did not match any variant of ServerToolUseBlockParamCaller"
            );
        }
        this.Switch(
            (direct) => direct.Validate(),
            (serverTool) => serverTool.Validate(),
            (codeExecution20260120) => codeExecution20260120.Validate()
        );
    }

    public virtual bool Equals(ServerToolUseBlockParamCaller? other) =>
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
            ServerToolUseBlockParamCallerCodeExecution20260120 _ => 2,
            _ => -1,
        };
    }
}

sealed class ServerToolUseBlockParamCallerConverter : JsonConverter<ServerToolUseBlockParamCaller>
{
    public override ServerToolUseBlockParamCaller? Read(
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
                        JsonSerializer.Deserialize<ServerToolUseBlockParamCallerCodeExecution20260120>(
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
                return new ServerToolUseBlockParamCaller(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ServerToolUseBlockParamCaller value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ServerToolUseBlockParamCallerCodeExecution20260120,
        ServerToolUseBlockParamCallerCodeExecution20260120FromRaw
    >)
)]
public sealed record class ServerToolUseBlockParamCallerCodeExecution20260120 : JsonModel
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

    public ServerToolUseBlockParamCallerCodeExecution20260120()
    {
        this.Type = JsonSerializer.SerializeToElement("code_execution_20260120");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ServerToolUseBlockParamCallerCodeExecution20260120(
        ServerToolUseBlockParamCallerCodeExecution20260120 serverToolUseBlockParamCallerCodeExecution20260120
    )
        : base(serverToolUseBlockParamCallerCodeExecution20260120) { }
#pragma warning restore CS8618

    public ServerToolUseBlockParamCallerCodeExecution20260120(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("code_execution_20260120");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ServerToolUseBlockParamCallerCodeExecution20260120(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ServerToolUseBlockParamCallerCodeExecution20260120FromRaw.FromRawUnchecked"/>
    public static ServerToolUseBlockParamCallerCodeExecution20260120 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ServerToolUseBlockParamCallerCodeExecution20260120(string toolID)
        : this()
    {
        this.ToolID = toolID;
    }
}

class ServerToolUseBlockParamCallerCodeExecution20260120FromRaw
    : IFromRawJson<ServerToolUseBlockParamCallerCodeExecution20260120>
{
    /// <inheritdoc/>
    public ServerToolUseBlockParamCallerCodeExecution20260120 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ServerToolUseBlockParamCallerCodeExecution20260120.FromRawUnchecked(rawData);
}
