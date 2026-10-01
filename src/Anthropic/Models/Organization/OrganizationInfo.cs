using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization;

[JsonConverter(typeof(JsonModelConverter<OrganizationInfo, OrganizationInfoFromRaw>))]
public sealed record class OrganizationInfo : JsonModel
{
    /// <summary>
    /// ID of the Organization.
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
    /// Name of the Organization.
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
    /// Object type.
    ///
    /// <para>For Organizations, this is always `"organization"`.</para>
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
        _ = this.Name;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("organization")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public OrganizationInfo()
    {
        this.Type = JsonSerializer.SerializeToElement("organization");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OrganizationInfo(OrganizationInfo organizationInfo)
        : base(organizationInfo) { }
#pragma warning restore CS8618

    public OrganizationInfo(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("organization");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OrganizationInfo(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OrganizationInfoFromRaw.FromRawUnchecked"/>
    public static OrganizationInfo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OrganizationInfoFromRaw : IFromRawJson<OrganizationInfo>
{
    /// <inheritdoc/>
    public OrganizationInfo FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OrganizationInfo.FromRawUnchecked(rawData);
}
