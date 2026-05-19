using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Input payload for the `bash` tool of the `agent_toolset_20260401` toolset. All
/// fields are optional; a normal invocation supplies `command`, while `restart=true`
/// (with no `command`) reboots the runner-side bash session.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAgentToolset20260401BashInput,
        BetaManagedAgentsAgentToolset20260401BashInputFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAgentToolset20260401BashInput : JsonModel
{
    /// <summary>
    /// Shell command to execute. Omit only when `restart` is true.
    /// </summary>
    public string? Command
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("command");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("command", value);
        }
    }

    /// <summary>
    /// When true, restart the persistent bash session instead of running a command.
    /// Subsequent calls without `restart` will run against the fresh session.
    /// </summary>
    public bool? Restart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("restart");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("restart", value);
        }
    }

    /// <summary>
    /// Per-call timeout in milliseconds. Defaults to the runner-wide tool timeout
    /// when omitted or zero.
    /// </summary>
    public long? TimeoutMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("timeout_ms");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("timeout_ms", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Command;
        _ = this.Restart;
        _ = this.TimeoutMs;
    }

    public BetaManagedAgentsAgentToolset20260401BashInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAgentToolset20260401BashInput(
        BetaManagedAgentsAgentToolset20260401BashInput betaManagedAgentsAgentToolset20260401BashInput
    )
        : base(betaManagedAgentsAgentToolset20260401BashInput) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAgentToolset20260401BashInput(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAgentToolset20260401BashInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAgentToolset20260401BashInputFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAgentToolset20260401BashInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsAgentToolset20260401BashInputFromRaw
    : IFromRawJson<BetaManagedAgentsAgentToolset20260401BashInput>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAgentToolset20260401BashInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAgentToolset20260401BashInput.FromRawUnchecked(rawData);
}
