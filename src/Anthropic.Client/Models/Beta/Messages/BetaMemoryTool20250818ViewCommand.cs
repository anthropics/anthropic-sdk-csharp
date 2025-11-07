using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaMemoryTool20250818ViewCommand>))]
public sealed record class BetaMemoryTool20250818ViewCommand
    : ModelBase,
        IFromRaw<BetaMemoryTool20250818ViewCommand>
{
    /// <summary>
    /// Command type identifier
    /// </summary>
    public JsonElement Command
    {
        get
        {
            if (!this._properties.TryGetValue("command", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'command' cannot be null",
                    new System::ArgumentOutOfRangeException("command", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["command"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Path to directory or file to view
    /// </summary>
    public required string Path
    {
        get
        {
            if (!this._properties.TryGetValue("path", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'path' cannot be null",
                    new System::ArgumentOutOfRangeException("path", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'path' cannot be null",
                    new System::ArgumentNullException("path")
                );
        }
        init
        {
            this._properties["path"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Optional line range for viewing specific lines
    /// </summary>
    public List<long>? ViewRange
    {
        get
        {
            if (!this._properties.TryGetValue("view_range", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<long>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["view_range"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Command;
        _ = this.Path;
        _ = this.ViewRange;
    }

    public BetaMemoryTool20250818ViewCommand()
    {
        this.Command = JsonSerializer.Deserialize<JsonElement>("\"view\"");
    }

    public BetaMemoryTool20250818ViewCommand(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Command = JsonSerializer.Deserialize<JsonElement>("\"view\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMemoryTool20250818ViewCommand(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaMemoryTool20250818ViewCommand FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public BetaMemoryTool20250818ViewCommand(string path)
        : this()
    {
        this.Path = path;
    }
}
