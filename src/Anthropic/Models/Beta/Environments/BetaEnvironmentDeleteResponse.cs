using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

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
        _ = this.ID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("environment_deleted")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaEnvironmentDeleteResponse()
    {
        this.Type = JsonSerializer.SerializeToElement("environment_deleted");
    }

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

        this.Type = JsonSerializer.SerializeToElement("environment_deleted");
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

    [SetsRequiredMembers]
    public BetaEnvironmentDeleteResponse(string id)
        : this()
    {
        this.ID = id;
    }
}

class BetaEnvironmentDeleteResponseFromRaw : IFromRawJson<BetaEnvironmentDeleteResponse>
{
    /// <inheritdoc/>
    public BetaEnvironmentDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaEnvironmentDeleteResponse.FromRawUnchecked(rawData);
}
