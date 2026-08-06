using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// Platform advisor roster entry: a model the session's primary thread may consult
/// mid-turn. At most one per roster; the entry occupies the roster name `anthropic.advisor`.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsAdvisorParams,
        BetaManagedAgentsAdvisorParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsAdvisorParams : JsonModel
{
    /// <summary>
    /// A Claude model id. The model must be permitted as an advisor for this agent's
    /// model — see the sessions/threads/advisor spec.
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

    public required ApiEnum<string, global::Anthropic.Models.Beta.Sessions.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Anthropic.Models.Beta.Sessions.Type>
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

    public BetaManagedAgentsAdvisorParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsAdvisorParams(
        BetaManagedAgentsAdvisorParams betaManagedAgentsAdvisorParams
    )
        : base(betaManagedAgentsAdvisorParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsAdvisorParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsAdvisorParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsAdvisorParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsAdvisorParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsAdvisorParamsFromRaw : IFromRawJson<BetaManagedAgentsAdvisorParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsAdvisorParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsAdvisorParams.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Advisor,
}

sealed class TypeConverter : JsonConverter<global::Anthropic.Models.Beta.Sessions.Type>
{
    public override global::Anthropic.Models.Beta.Sessions.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "advisor" => global::Anthropic.Models.Beta.Sessions.Type.Advisor,
            _ => (global::Anthropic.Models.Beta.Sessions.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Models.Beta.Sessions.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Anthropic.Models.Beta.Sessions.Type.Advisor => "advisor",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
