using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Analytics;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaAnalyticsFederatedActorGcpProvider,
        BetaAnalyticsFederatedActorGcpProviderFromRaw
    >)
)]
public sealed record class BetaAnalyticsFederatedActorGcpProvider : JsonModel
{
    /// <summary>
    /// The Google Cloud project the organization is bound to.
    /// </summary>
    public required string ProjectNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("project_number");
        }
        init { this._rawData.Set("project_number", value); }
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
        _ = this.ProjectNumber;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("gcp")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaAnalyticsFederatedActorGcpProvider()
    {
        this.Type = JsonSerializer.SerializeToElement("gcp");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsFederatedActorGcpProvider(
        BetaAnalyticsFederatedActorGcpProvider betaAnalyticsFederatedActorGcpProvider
    )
        : base(betaAnalyticsFederatedActorGcpProvider) { }
#pragma warning restore CS8618

    public BetaAnalyticsFederatedActorGcpProvider(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("gcp");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsFederatedActorGcpProvider(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsFederatedActorGcpProviderFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsFederatedActorGcpProvider FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaAnalyticsFederatedActorGcpProvider(string projectNumber)
        : this()
    {
        this.ProjectNumber = projectNumber;
    }
}

class BetaAnalyticsFederatedActorGcpProviderFromRaw
    : IFromRawJson<BetaAnalyticsFederatedActorGcpProvider>
{
    /// <inheritdoc/>
    public BetaAnalyticsFederatedActorGcpProvider FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsFederatedActorGcpProvider.FromRawUnchecked(rawData);
}
