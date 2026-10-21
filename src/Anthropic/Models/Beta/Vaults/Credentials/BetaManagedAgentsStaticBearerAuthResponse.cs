using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Vaults.Credentials;

/// <summary>
/// Static bearer token credential details for an MCP server.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsStaticBearerAuthResponse,
        BetaManagedAgentsStaticBearerAuthResponseFromRaw
    >)
)]
public sealed record class BetaManagedAgentsStaticBearerAuthResponse : JsonModel
{
    /// <summary>
    /// URL of the MCP server this credential authenticates against.
    /// </summary>
    public required string McpServerUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("mcp_server_url");
        }
        init { this._rawData.Set("mcp_server_url", value); }
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
        _ = this.McpServerUrl;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("static_bearer")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsStaticBearerAuthResponse()
    {
        this.Type = JsonSerializer.SerializeToElement("static_bearer");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsStaticBearerAuthResponse(
        BetaManagedAgentsStaticBearerAuthResponse betaManagedAgentsStaticBearerAuthResponse
    )
        : base(betaManagedAgentsStaticBearerAuthResponse) { }
#pragma warning restore CS8618

    public BetaManagedAgentsStaticBearerAuthResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("static_bearer");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsStaticBearerAuthResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsStaticBearerAuthResponseFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsStaticBearerAuthResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsStaticBearerAuthResponse(string mcpServerUrl)
        : this()
    {
        this.McpServerUrl = mcpServerUrl;
    }
}

class BetaManagedAgentsStaticBearerAuthResponseFromRaw
    : IFromRawJson<BetaManagedAgentsStaticBearerAuthResponse>
{
    /// <inheritdoc/>
    public BetaManagedAgentsStaticBearerAuthResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsStaticBearerAuthResponse.FromRawUnchecked(rawData);
}
