using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Plugins.InstallationSettings;

[JsonConverter(
    typeof(JsonModelConverter<
        InstallationSettingListPageResponse,
        InstallationSettingListPageResponseFromRaw
    >)
)]
public sealed record class InstallationSettingListPageResponse : JsonModel
{
    public required IReadOnlyList<BetaPluginInstallationSetting> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaPluginInstallationSetting>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaPluginInstallationSetting>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Token to provide in as `page` in the subsequent request to retrieve the next
    /// page of data.
    /// </summary>
    public required string? NextPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("next_page");
        }
        init { this._rawData.Set("next_page", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        _ = this.NextPage;
    }

    public InstallationSettingListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InstallationSettingListPageResponse(
        InstallationSettingListPageResponse installationSettingListPageResponse
    )
        : base(installationSettingListPageResponse) { }
#pragma warning restore CS8618

    public InstallationSettingListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    InstallationSettingListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="InstallationSettingListPageResponseFromRaw.FromRawUnchecked"/>
    public static InstallationSettingListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class InstallationSettingListPageResponseFromRaw : IFromRawJson<InstallationSettingListPageResponse>
{
    /// <inheritdoc/>
    public InstallationSettingListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => InstallationSettingListPageResponse.FromRawUnchecked(rawData);
}
