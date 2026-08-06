using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Agents;

/// <summary>
/// Platform advisor roster entry: a model the session's primary thread may consult mid-turn.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsAdvisor, BetaManagedAgentsAdvisorFromRaw>)
)]
public sealed record class BetaManagedAgentsAdvisor : JsonModel
{
    /// <summary>
    /// The advisor model id.
    /// </summary>
    public required string Model
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("model");
        }
        init { this._rawData.Set("model", value); }
    }

    public required ApiEnum<string, global::Anthropic.Models.Beta.Agents.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Anthropic.Models.Beta.Agents.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Model;
        this.Type.Validate();
    }

    public BetaManagedAgentsAdvisor() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAdvisor(BetaManagedAgentsAdvisor betaManagedAgentsAdvisor)
        : base(betaManagedAgentsAdvisor) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAdvisor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAdvisor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAdvisorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAdvisor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsAdvisorFromRaw : IFromRawJson<BetaManagedAgentsAdvisor>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAdvisor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAdvisor.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Advisor,
}

sealed class TypeConverter : JsonConverter<global::Anthropic.Models.Beta.Agents.Type>
{
    public override global::Anthropic.Models.Beta.Agents.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "advisor" => global::Anthropic.Models.Beta.Agents.Type.Advisor,
            _ => (global::Anthropic.Models.Beta.Agents.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Models.Beta.Agents.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Anthropic.Models.Beta.Agents.Type.Advisor => "advisor",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
