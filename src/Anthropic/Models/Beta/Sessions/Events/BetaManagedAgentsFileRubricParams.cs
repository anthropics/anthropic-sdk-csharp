using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// Rubric referenced by a file uploaded via the Files API.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsFileRubricParams,
        BetaManagedAgentsFileRubricParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsFileRubricParams : JsonModel
{
    /// <summary>
    /// ID of the rubric file.
    /// </summary>
    public required string FileID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("file_id");
        }
        init { this._rawData.Set("file_id", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsFileRubricParamsType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsFileRubricParamsType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FileID;
        this.Type.Validate();
    }

    public BetaManagedAgentsFileRubricParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsFileRubricParams(
        BetaManagedAgentsFileRubricParams betaManagedAgentsFileRubricParams
    )
        : base(betaManagedAgentsFileRubricParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsFileRubricParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsFileRubricParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsFileRubricParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsFileRubricParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsFileRubricParamsFromRaw : IFromRawJson<BetaManagedAgentsFileRubricParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsFileRubricParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsFileRubricParams.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsFileRubricParamsTypeConverter))]
public enum BetaManagedAgentsFileRubricParamsType
{
    File,
}

sealed class BetaManagedAgentsFileRubricParamsTypeConverter
    : JsonConverter<BetaManagedAgentsFileRubricParamsType>
{
    public override BetaManagedAgentsFileRubricParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "file" => BetaManagedAgentsFileRubricParamsType.File,
            _ => (BetaManagedAgentsFileRubricParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsFileRubricParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsFileRubricParamsType.File => "file",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
