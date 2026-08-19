using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// The computer toolset: a single ``tools[]`` entry (carrying no ``name``) that declares
/// the computer tool family. The model is served the family's tool with any members
/// disabled via ``configs`` removed from its schema. Every member is enabled by
/// default, zoom included. The single-tool options ``display_number`` and ``enable_zoom``
/// are not fields of a toolset entry — it carries only ``type``, ``configs``, and
/// ``cache_control``; zoom is controlled via ``configs.zoom.enabled``.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaComputerToolset20260801, BetaComputerToolset20260801FromRaw>)
)]
public sealed record class BetaComputerToolset20260801 : JsonModel
{
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    public IReadOnlyList<ApiEnum<string, BetaComputerToolset20260801AllowedCaller>>? AllowedCallers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, BetaComputerToolset20260801AllowedCaller>>
            >("allowed_callers");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<
                ApiEnum<string, BetaComputerToolset20260801AllowedCaller>
            >?>("allowed_callers", value == null ? null : ImmutableArray.ToImmutableArray(value));
        }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaCacheControlEphemeral>("cache_control");
        }
        init { this._rawData.Set("cache_control", value); }
    }

    /// <summary>
    /// Per-member configuration for ``computer_toolset_20260801``: one optional
    /// field per member tool, keyed by the member name — the same name the member's
    /// ``tool_use`` blocks carry. Every member is an accepted key, and a member's
    /// defaults apply wherever its key is absent. Unknown keys are rejected: the
    /// field set is this toolset version's complete member set.
    /// </summary>
    public BetaComputerToolsetConfigs? Configs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaComputerToolsetConfigs>("configs");
        }
        init { this._rawData.Set("configs", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("computer_toolset_20260801")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        foreach (var item in this.AllowedCallers ?? [])
        {
            item.Validate();
        }
        this.CacheControl?.Validate();
        this.Configs?.Validate();
    }

    public BetaComputerToolset20260801()
    {
        this.Type = JsonSerializer.SerializeToElement("computer_toolset_20260801");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComputerToolset20260801(BetaComputerToolset20260801 betaComputerToolset20260801)
        : base(betaComputerToolset20260801) { }
#pragma warning restore CS8618

    public BetaComputerToolset20260801(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("computer_toolset_20260801");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComputerToolset20260801(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComputerToolset20260801FromRaw.FromRawUnchecked"/>
    public static BetaComputerToolset20260801 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaComputerToolset20260801FromRaw : IFromRawJson<BetaComputerToolset20260801>
{
    /// <inheritdoc/>
    public BetaComputerToolset20260801 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComputerToolset20260801.FromRawUnchecked(rawData);
}

/// <summary>
/// Specifies who can invoke a tool.
///
/// <para>Values:     direct: The model can call this tool directly.     code_execution_20250825:
/// The tool can be called from the code execution environment (v1).     code_execution_20260120:
/// The tool can be called from the code execution environment (v2 with persistence).
///     code_execution_20260521: The tool can be called from the code execution environment
/// (v2 with persistence).</para>
/// </summary>
[JsonConverter(typeof(BetaComputerToolset20260801AllowedCallerConverter))]
public enum BetaComputerToolset20260801AllowedCaller
{
    Direct,
    CodeExecution20250825,
    CodeExecution20260120,
    CodeExecution20260521,
}

sealed class BetaComputerToolset20260801AllowedCallerConverter
    : JsonConverter<BetaComputerToolset20260801AllowedCaller>
{
    public override BetaComputerToolset20260801AllowedCaller Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "direct" => BetaComputerToolset20260801AllowedCaller.Direct,
            "code_execution_20250825" =>
                BetaComputerToolset20260801AllowedCaller.CodeExecution20250825,
            "code_execution_20260120" =>
                BetaComputerToolset20260801AllowedCaller.CodeExecution20260120,
            "code_execution_20260521" =>
                BetaComputerToolset20260801AllowedCaller.CodeExecution20260521,
            _ => (BetaComputerToolset20260801AllowedCaller)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaComputerToolset20260801AllowedCaller value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaComputerToolset20260801AllowedCaller.Direct => "direct",
                BetaComputerToolset20260801AllowedCaller.CodeExecution20250825 =>
                    "code_execution_20250825",
                BetaComputerToolset20260801AllowedCaller.CodeExecution20260120 =>
                    "code_execution_20260120",
                BetaComputerToolset20260801AllowedCaller.CodeExecution20260521 =>
                    "code_execution_20260521",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
