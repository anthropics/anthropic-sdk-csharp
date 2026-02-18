using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(
    typeof(JsonModelConverter<ServerToolCaller20260120, ServerToolCaller20260120FromRaw>)
)]
public sealed record class ServerToolCaller20260120 : JsonModel
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

    public ServerToolCaller20260120()
    {
        this.Type = JsonSerializer.SerializeToElement("code_execution_20260120");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ServerToolCaller20260120(ServerToolCaller20260120 serverToolCaller20260120)
        : base(serverToolCaller20260120) { }
#pragma warning restore CS8618

    public ServerToolCaller20260120(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("code_execution_20260120");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ServerToolCaller20260120(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ServerToolCaller20260120FromRaw.FromRawUnchecked"/>
    public static ServerToolCaller20260120 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ServerToolCaller20260120(string toolID)
        : this()
    {
        this.ToolID = toolID;
    }
}

class ServerToolCaller20260120FromRaw : IFromRawJson<ServerToolCaller20260120>
{
    /// <inheritdoc/>
    public ServerToolCaller20260120 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ServerToolCaller20260120.FromRawUnchecked(rawData);
}
