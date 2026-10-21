using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

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
        _ = this.FileID;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("file")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsFileRubric()
    {
        this.Type = JsonSerializer.SerializeToElement("file");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsFileRubric(BetaManagedAgentsFileRubric betaManagedAgentsFileRubric)
        : base(betaManagedAgentsFileRubric) { }
#pragma warning restore CS8618

    public BetaManagedAgentsFileRubric(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("file");
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

    [SetsRequiredMembers]
    public BetaManagedAgentsFileRubric(string fileID)
        : this()
    {
        this.FileID = fileID;
    }
}

class BetaManagedAgentsFileRubricFromRaw : IFromRawJson<BetaManagedAgentsFileRubric>
{
    /// <inheritdoc/>
    public BetaManagedAgentsFileRubric FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsFileRubric.FromRawUnchecked(rawData);
}
