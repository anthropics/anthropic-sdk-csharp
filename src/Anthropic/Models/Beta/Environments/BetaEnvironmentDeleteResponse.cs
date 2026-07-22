using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Environments;

/// <summary>
/// Response after deleting an environment.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaEnvironmentDeleteResponse, BetaEnvironmentDeleteResponseFromRaw>)
)]
public sealed record class BetaEnvironmentDeleteResponse : JsonModel
{
    /// <summary>
    /// Environment identifier
    /// </summary>
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
    /// The type of response
    /// </summary>
    public required ApiEnum<string, global::Anthropic.Models.Beta.Environments.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Anthropic.Models.Beta.Environments.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Type.Validate();
    }

    public BetaEnvironmentDeleteResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaEnvironmentDeleteResponse(
        BetaEnvironmentDeleteResponse betaEnvironmentDeleteResponse
    )
        : base(betaEnvironmentDeleteResponse) { }
#pragma warning restore CS8618

    public BetaEnvironmentDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaEnvironmentDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaEnvironmentDeleteResponseFromRaw.FromRawUnchecked"/>
    public static BetaEnvironmentDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaEnvironmentDeleteResponseFromRaw : IFromRawJson<BetaEnvironmentDeleteResponse>
{
    /// <inheritdoc/>
    public BetaEnvironmentDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaEnvironmentDeleteResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of response
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    EnvironmentDeleted,
}

sealed class TypeConverter : JsonConverter<global::Anthropic.Models.Beta.Environments.Type>
{
    public override global::Anthropic.Models.Beta.Environments.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "environment_deleted" => global::Anthropic
                .Models
                .Beta
                .Environments
                .Type
                .EnvironmentDeleted,
            _ => (global::Anthropic.Models.Beta.Environments.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Models.Beta.Environments.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Anthropic.Models.Beta.Environments.Type.EnvironmentDeleted =>
                    "environment_deleted",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
