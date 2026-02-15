using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Services.Beta.Skills;

namespace Anthropic.Models.Beta.Skills.Versions;

/// <summary>
/// Create Skill Version
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class VersionCreateParams : ParamsBase
{
    readonly MultipartJsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, MultipartJsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? SkillID { get; init; }

    /// <summary>
    /// Files to upload for the skill.
    ///
    /// <para>All files must be in the same top-level directory and must include
    /// a SKILL.md file at the root of that directory.</para>
    /// </summary>
    public IReadOnlyList<BinaryContent>? Files
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<BinaryContent>>("files");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<BinaryContent>?>(
                "files",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Optional header to specify the beta version(s) you want to use.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, AnthropicBeta>>? Betas
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, AnthropicBeta>>
            >("anthropic-beta");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set<ImmutableArray<ApiEnum<string, AnthropicBeta>>?>(
                "anthropic-beta",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public VersionCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VersionCreateParams(VersionCreateParams versionCreateParams)
        : base(versionCreateParams)
    {
        this.SkillID = versionCreateParams.SkillID;

        this._rawBodyData = new(versionCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public VersionCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, MultipartJsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VersionCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, MultipartJsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static VersionCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, MultipartJsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, MultipartJsonElement>()
                {
                    ["SkillID"] = JsonSerializer.SerializeToElement(this.SkillID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(VersionCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.SkillID?.Equals(other.SkillID) ?? other.SkillID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/skills/{0}/versions?beta=true", this.SkillID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return MultipartJsonSerializer.Serialize(RawBodyData);
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        VersionService.AddDefaultHeaders(request);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
