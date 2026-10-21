using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Vaults.Credentials;

/// <summary>
/// Parameters for creating a static bearer token credential.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsStaticBearerCreateParams,
        BetaManagedAgentsStaticBearerCreateParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsStaticBearerCreateParams : JsonModel
{
    /// <summary>
    /// The static bearer token to send to the MCP server, such as an API key or
    /// personal access token.
    /// </summary>
    public required string Token
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("token");
        }
        init { this._rawData.Set("token", value); }
    }

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
        _ = this.Token;
        _ = this.McpServerUrl;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("static_bearer")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsStaticBearerCreateParams()
    {
        this.Type = JsonSerializer.SerializeToElement("static_bearer");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsStaticBearerCreateParams(
        BetaManagedAgentsStaticBearerCreateParams betaManagedAgentsStaticBearerCreateParams
    )
        : base(betaManagedAgentsStaticBearerCreateParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsStaticBearerCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("static_bearer");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsStaticBearerCreateParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsStaticBearerCreateParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsStaticBearerCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsStaticBearerCreateParamsFromRaw
    : IFromRawJson<BetaManagedAgentsStaticBearerCreateParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsStaticBearerCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsStaticBearerCreateParams.FromRawUnchecked(rawData);
}
