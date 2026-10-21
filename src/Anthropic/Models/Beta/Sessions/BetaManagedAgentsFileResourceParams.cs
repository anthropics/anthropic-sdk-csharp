using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions;

/// <summary>
/// Mount a file uploaded via the Files API into the session.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsFileResourceParams,
        BetaManagedAgentsFileResourceParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsFileResourceParams : JsonModel
{
    /// <summary>
    /// ID of a previously uploaded file.
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

    /// <summary>
    /// Mount path in the container. Defaults to `/mnt/session/uploads/&lt;file_id&gt;`.
    /// </summary>
    public string? MountPath
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mount_path");
        }
        init { this._rawData.Set("mount_path", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FileID;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("file")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.MountPath;
    }

    public BetaManagedAgentsFileResourceParams()
    {
        this.Type = JsonSerializer.SerializeToElement("file");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsFileResourceParams(
        BetaManagedAgentsFileResourceParams betaManagedAgentsFileResourceParams
    )
        : base(betaManagedAgentsFileResourceParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsFileResourceParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("file");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsFileResourceParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsFileResourceParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsFileResourceParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsFileResourceParams(string fileID)
        : this()
    {
        this.FileID = fileID;
    }
}

class BetaManagedAgentsFileResourceParamsFromRaw : IFromRawJson<BetaManagedAgentsFileResourceParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsFileResourceParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsFileResourceParams.FromRawUnchecked(rawData);
}
