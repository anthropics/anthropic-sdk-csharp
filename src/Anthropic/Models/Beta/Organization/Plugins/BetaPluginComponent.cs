using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Organization.Plugins;

[JsonConverter(typeof(JsonModelConverter<BetaPluginComponent, BetaPluginComponentFromRaw>))]
public sealed record class BetaPluginComponent : JsonModel
{
    /// <summary>
    /// What the component declares about itself; always null for MCP servers, hooks,
    /// and CLIs.
    /// </summary>
    public required string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// The component's name: a skill's, command's or agent's name, an MCP server's
    /// key in the manifest, the event a hook runs on, or a CLI's executable.
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
    /// The kind of component.
    /// </summary>
    public required ApiEnum<string, global::Anthropic.Models.Beta.Organization.Plugins.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Anthropic.Models.Beta.Organization.Plugins.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.Name;
        this.Type.Validate();
    }

    public BetaPluginComponent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaPluginComponent(BetaPluginComponent betaPluginComponent)
        : base(betaPluginComponent) { }
#pragma warning restore CS8618

    public BetaPluginComponent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaPluginComponent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaPluginComponentFromRaw.FromRawUnchecked"/>
    public static BetaPluginComponent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaPluginComponentFromRaw : IFromRawJson<BetaPluginComponent>
{
    /// <inheritdoc/>
    public BetaPluginComponent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaPluginComponent.FromRawUnchecked(rawData);
}

/// <summary>
/// The kind of component.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Agent,
    Cli,
    Command,
    Hook,
    McpServer,
    Skill,
}

sealed class TypeConverter : JsonConverter<global::Anthropic.Models.Beta.Organization.Plugins.Type>
{
    public override global::Anthropic.Models.Beta.Organization.Plugins.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "agent" => global::Anthropic.Models.Beta.Organization.Plugins.Type.Agent,
            "cli" => global::Anthropic.Models.Beta.Organization.Plugins.Type.Cli,
            "command" => global::Anthropic.Models.Beta.Organization.Plugins.Type.Command,
            "hook" => global::Anthropic.Models.Beta.Organization.Plugins.Type.Hook,
            "mcp_server" => global::Anthropic.Models.Beta.Organization.Plugins.Type.McpServer,
            "skill" => global::Anthropic.Models.Beta.Organization.Plugins.Type.Skill,
            _ => (global::Anthropic.Models.Beta.Organization.Plugins.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Models.Beta.Organization.Plugins.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Anthropic.Models.Beta.Organization.Plugins.Type.Agent => "agent",
                global::Anthropic.Models.Beta.Organization.Plugins.Type.Cli => "cli",
                global::Anthropic.Models.Beta.Organization.Plugins.Type.Command => "command",
                global::Anthropic.Models.Beta.Organization.Plugins.Type.Hook => "hook",
                global::Anthropic.Models.Beta.Organization.Plugins.Type.McpServer => "mcp_server",
                global::Anthropic.Models.Beta.Organization.Plugins.Type.Skill => "skill",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
