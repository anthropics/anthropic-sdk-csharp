using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Environments;

/// <summary>
/// Unified Environment resource for both cloud and BYOC environments.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaEnvironment, BetaEnvironmentFromRaw>))]
public sealed record class BetaEnvironment : JsonModel
{
    /// <summary>
    /// Environment identifier (e.g., 'env_...')
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
    /// RFC 3339 timestamp when environment was archived, or null if not archived
    /// </summary>
    public required string? ArchivedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("archived_at");
        }
        init { this._rawData.Set("archived_at", value); }
    }

    /// <summary>
    /// `cloud` environment configuration.
    /// </summary>
    public required BetaCloudConfig Config
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaCloudConfig>("config");
        }
        init { this._rawData.Set("config", value); }
    }

    /// <summary>
    /// RFC 3339 timestamp when environment was created
    /// </summary>
    public required string CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// User-provided description for the environment
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// User-provided metadata key-value pairs
    /// </summary>
    public required IReadOnlyDictionary<string, string> Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "metadata",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Human-readable name for the environment
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The type of object (always 'environment')
    /// </summary>
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
    /// RFC 3339 timestamp when environment was last updated
    /// </summary>
    public required string UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ArchivedAt;
        this.Config.Validate();
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.Metadata;
        _ = this.Name;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("environment")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UpdatedAt;
    }

    public BetaEnvironment()
    {
        this.Type = JsonSerializer.SerializeToElement("environment");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaEnvironment(BetaEnvironment betaEnvironment)
        : base(betaEnvironment) { }
#pragma warning restore CS8618

    public BetaEnvironment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("environment");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaEnvironment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaEnvironmentFromRaw.FromRawUnchecked"/>
    public static BetaEnvironment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaEnvironmentFromRaw : IFromRawJson<BetaEnvironment>
{
    /// <inheritdoc/>
    public BetaEnvironment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaEnvironment.FromRawUnchecked(rawData);
}
