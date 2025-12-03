using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Skills.Versions;

[JsonConverter(typeof(ModelConverter<VersionDeleteResponse, VersionDeleteResponseFromRaw>))]
public sealed record class VersionDeleteResponse : ModelBase
{
    /// <summary>
    /// Version identifier for the skill.
    ///
    /// <para>Each version is identified by a Unix epoch timestamp (e.g., "1759178010641129").</para>
    /// </summary>
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// Deleted object type.
    ///
    /// <para>For Skill Versions, this is always `"skill_version_deleted"`.</para>
    /// </summary>
    public required string Type
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Type;
    }

    public VersionDeleteResponse() { }

    public VersionDeleteResponse(VersionDeleteResponse versionDeleteResponse)
        : base(versionDeleteResponse) { }

    public VersionDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VersionDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VersionDeleteResponseFromRaw.FromRawUnchecked"/>
    public static VersionDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VersionDeleteResponseFromRaw : IFromRaw<VersionDeleteResponse>
{
    /// <inheritdoc/>
    public VersionDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VersionDeleteResponse.FromRawUnchecked(rawData);
}
