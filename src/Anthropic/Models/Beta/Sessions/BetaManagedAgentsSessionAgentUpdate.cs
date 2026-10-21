using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using Agents = Anthropic.Models.Beta.Agents;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// Mid-session agent configuration update. Only `tools` and `mcp_servers` are updatable.
/// Full replacement: the provided array becomes the new value. To preserve existing
/// entries, GET the session, modify the array, and POST it back.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSessionAgentUpdate,
        BetaManagedAgentsSessionAgentUpdateFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSessionAgentUpdate : JsonModel
{
    /// <summary>
    /// Replacement MCP server list. Full replacement: the provided array becomes
    /// the new value. Send an empty array to clear; omit to preserve.
    /// </summary>
    public IReadOnlyList<Agents::BetaManagedAgentsUrlMcpServerParams>? McpServers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<Agents::BetaManagedAgentsUrlMcpServerParams>
            >("mcp_servers");
        }
        init
        {
            if (value == null)
            {
                this._rawData.Remove("mcp_servers");
                return;
            }

            this._rawData.Set<ImmutableArray<Agents::BetaManagedAgentsUrlMcpServerParams>?>(
                "mcp_servers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Replacement tool list. Full replacement: the provided array becomes the new
    /// value. Send an empty array to clear; omit to preserve.
    /// </summary>
    public IReadOnlyList<BetaManagedAgentsSessionAgentUpdateTool>? Tools
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<BetaManagedAgentsSessionAgentUpdateTool>
            >("tools");
        }
        init
        {
            if (value == null)
            {
                this._rawData.Remove("tools");
                return;
            }

            this._rawData.Set<ImmutableArray<BetaManagedAgentsSessionAgentUpdateTool>?>(
                "tools",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.McpServers ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Tools ?? [])
        {
            item.Validate();
        }
    }

    public BetaManagedAgentsSessionAgentUpdate() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSessionAgentUpdate(
        BetaManagedAgentsSessionAgentUpdate betaManagedAgentsSessionAgentUpdate
    )
        : base(betaManagedAgentsSessionAgentUpdate) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSessionAgentUpdate(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSessionAgentUpdate(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSessionAgentUpdateFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSessionAgentUpdate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsSessionAgentUpdateFromRaw : IFromRawJson<BetaManagedAgentsSessionAgentUpdate>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSessionAgentUpdate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSessionAgentUpdate.FromRawUnchecked(rawData);
}

/// <summary>
/// Union type for tool configurations in the tools array.
/// </summary>
[JsonConverter(typeof(BetaManagedAgentsSessionAgentUpdateToolConverter))]
public record class BetaManagedAgentsSessionAgentUpdateTool : ModelBase
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

    public ApiEnum<string, BetaManagedAgentsSessionAgentUpdateToolType> Type
    {
        get
        {
            return this.Value switch
            {
                Agents::BetaManagedAgentsAgentToolset20260401Params _ =>
                    BetaManagedAgentsSessionAgentUpdateToolType.AgentToolset20260401,
                Agents::BetaManagedAgentsMcpToolsetParams _ =>
                    BetaManagedAgentsSessionAgentUpdateToolType.McpToolset,
                Agents::BetaManagedAgentsCustomToolParams _ =>
                    BetaManagedAgentsSessionAgentUpdateToolType.Custom,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<
                    ApiEnum<string, BetaManagedAgentsSessionAgentUpdateToolType>
                >(this.Json, "type"),
            };
        }
    }

    public BetaManagedAgentsSessionAgentUpdateTool(
        Agents::BetaManagedAgentsAgentToolset20260401Params value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionAgentUpdateTool(
        Agents::BetaManagedAgentsMcpToolsetParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionAgentUpdateTool(
        Agents::BetaManagedAgentsCustomToolParams value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaManagedAgentsSessionAgentUpdateTool(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Agents::BetaManagedAgentsAgentToolset20260401Params"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsAgentToolset20260401Params(out var value)) {
    ///     // `value` is of type `Agents::BetaManagedAgentsAgentToolset20260401Params`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsAgentToolset20260401Params(
        [NotNullWhen(true)] out Agents::BetaManagedAgentsAgentToolset20260401Params? value
    )
    {
        value = this.Value as Agents::BetaManagedAgentsAgentToolset20260401Params;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Agents::BetaManagedAgentsMcpToolsetParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsMcpToolsetParams(out var value)) {
    ///     // `value` is of type `Agents::BetaManagedAgentsMcpToolsetParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsMcpToolsetParams(
        [NotNullWhen(true)] out Agents::BetaManagedAgentsMcpToolsetParams? value
    )
    {
        value = this.Value as Agents::BetaManagedAgentsMcpToolsetParams;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="Agents::BetaManagedAgentsCustomToolParams"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaManagedAgentsCustomToolParams(out var value)) {
    ///     // `value` is of type `Agents::BetaManagedAgentsCustomToolParams`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaManagedAgentsCustomToolParams(
        [NotNullWhen(true)] out Agents::BetaManagedAgentsCustomToolParams? value
    )
    {
        value = this.Value as Agents::BetaManagedAgentsCustomToolParams;
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
    ///     (Agents::BetaManagedAgentsAgentToolset20260401Params value) =&gt; {...},
    ///     (Agents::BetaManagedAgentsMcpToolsetParams value) =&gt; {...},
    ///     (Agents::BetaManagedAgentsCustomToolParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        Action<Agents::BetaManagedAgentsAgentToolset20260401Params> betaManagedAgentsAgentToolset20260401Params,
        Action<Agents::BetaManagedAgentsMcpToolsetParams> betaManagedAgentsMcpToolsetParams,
        Action<Agents::BetaManagedAgentsCustomToolParams> betaManagedAgentsCustomToolParams
    )
    {
        switch (this.Value)
        {
            case Agents::BetaManagedAgentsAgentToolset20260401Params value:
                betaManagedAgentsAgentToolset20260401Params(value);
                break;
            case Agents::BetaManagedAgentsMcpToolsetParams value:
                betaManagedAgentsMcpToolsetParams(value);
                break;
            case Agents::BetaManagedAgentsCustomToolParams value:
                betaManagedAgentsCustomToolParams(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaManagedAgentsSessionAgentUpdateTool"
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
    ///     (Agents::BetaManagedAgentsAgentToolset20260401Params value) =&gt; {...},
    ///     (Agents::BetaManagedAgentsMcpToolsetParams value) =&gt; {...},
    ///     (Agents::BetaManagedAgentsCustomToolParams value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        Func<
            Agents::BetaManagedAgentsAgentToolset20260401Params,
            T
        > betaManagedAgentsAgentToolset20260401Params,
        Func<Agents::BetaManagedAgentsMcpToolsetParams, T> betaManagedAgentsMcpToolsetParams,
        Func<Agents::BetaManagedAgentsCustomToolParams, T> betaManagedAgentsCustomToolParams
    )
    {
        return this.Value switch
        {
            Agents::BetaManagedAgentsAgentToolset20260401Params value =>
                betaManagedAgentsAgentToolset20260401Params(value),
            Agents::BetaManagedAgentsMcpToolsetParams value => betaManagedAgentsMcpToolsetParams(
                value
            ),
            Agents::BetaManagedAgentsCustomToolParams value => betaManagedAgentsCustomToolParams(
                value
            ),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaManagedAgentsSessionAgentUpdateTool"
            ),
        };
    }

    public static implicit operator BetaManagedAgentsSessionAgentUpdateTool(
        Agents::BetaManagedAgentsAgentToolset20260401Params value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionAgentUpdateTool(
        Agents::BetaManagedAgentsMcpToolsetParams value
    ) => new(value);

    public static implicit operator BetaManagedAgentsSessionAgentUpdateTool(
        Agents::BetaManagedAgentsCustomToolParams value
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
                "Data did not match any variant of BetaManagedAgentsSessionAgentUpdateTool"
            );
        }
        this.Switch(
            (betaManagedAgentsAgentToolset20260401Params) =>
                betaManagedAgentsAgentToolset20260401Params.Validate(),
            (betaManagedAgentsMcpToolsetParams) => betaManagedAgentsMcpToolsetParams.Validate(),
            (betaManagedAgentsCustomToolParams) => betaManagedAgentsCustomToolParams.Validate()
        );
    }

    public virtual bool Equals(BetaManagedAgentsSessionAgentUpdateTool? other) =>
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
            Agents::BetaManagedAgentsAgentToolset20260401Params _ => 0,
            Agents::BetaManagedAgentsMcpToolsetParams _ => 1,
            Agents::BetaManagedAgentsCustomToolParams _ => 2,
            _ => -1,
        };
    }
}

sealed class BetaManagedAgentsSessionAgentUpdateToolConverter
    : JsonConverter<BetaManagedAgentsSessionAgentUpdateTool>
{
    public override BetaManagedAgentsSessionAgentUpdateTool? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
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
            case "agent_toolset_20260401":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Agents::BetaManagedAgentsAgentToolset20260401Params>(
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
            case "mcp_toolset":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Agents::BetaManagedAgentsMcpToolsetParams>(
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
            case "custom":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<Agents::BetaManagedAgentsCustomToolParams>(
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
                return new BetaManagedAgentsSessionAgentUpdateTool(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionAgentUpdateTool value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(BetaManagedAgentsSessionAgentUpdateToolTypeConverter))]
public enum BetaManagedAgentsSessionAgentUpdateToolType
{
    AgentToolset20260401,
    McpToolset,
    Custom,
}

sealed class BetaManagedAgentsSessionAgentUpdateToolTypeConverter
    : JsonConverter<BetaManagedAgentsSessionAgentUpdateToolType>
{
    public override BetaManagedAgentsSessionAgentUpdateToolType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "agent_toolset_20260401" =>
                BetaManagedAgentsSessionAgentUpdateToolType.AgentToolset20260401,
            "mcp_toolset" => BetaManagedAgentsSessionAgentUpdateToolType.McpToolset,
            "custom" => BetaManagedAgentsSessionAgentUpdateToolType.Custom,
            _ => (BetaManagedAgentsSessionAgentUpdateToolType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsSessionAgentUpdateToolType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsSessionAgentUpdateToolType.AgentToolset20260401 =>
                    "agent_toolset_20260401",
                BetaManagedAgentsSessionAgentUpdateToolType.McpToolset => "mcp_toolset",
                BetaManagedAgentsSessionAgentUpdateToolType.Custom => "custom",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
