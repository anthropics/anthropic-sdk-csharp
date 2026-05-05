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
    typeof(JsonModelConverter<BetaManagedAgentsFileRubric, BetaManagedAgentsFileRubricFromRaw>)
)]
public sealed record class BetaManagedAgentsFileRubric : JsonModel
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

    public required ApiEnum<string, BetaManagedAgentsFileRubricType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaManagedAgentsFileRubricType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FileID;
        this.Type.Validate();
    }

    public BetaManagedAgentsFileRubric() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsFileRubric(BetaManagedAgentsFileRubric betaManagedAgentsFileRubric)
        : base(betaManagedAgentsFileRubric) { }
#pragma warning restore CS8618

    public BetaManagedAgentsFileRubric(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsFileRubric(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsFileRubricFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsFileRubric FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsFileRubricFromRaw : IFromRawJson<BetaManagedAgentsFileRubric>
{
    /// <inheritdoc/>
    public BetaManagedAgentsFileRubric FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsFileRubric.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsFileRubricTypeConverter))]
public enum BetaManagedAgentsFileRubricType
{
    File,
}

sealed class BetaManagedAgentsFileRubricTypeConverter
    : JsonConverter<BetaManagedAgentsFileRubricType>
{
    public override BetaManagedAgentsFileRubricType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "file" => BetaManagedAgentsFileRubricType.File,
            _ => (BetaManagedAgentsFileRubricType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsFileRubricType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsFileRubricType.File => "file",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
