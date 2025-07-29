using Anthropic = Anthropic;
using BetaRequestDocumentBlockProperties = Anthropic.Models.Beta.Messages.BetaRequestDocumentBlockProperties;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<BetaRequestDocumentBlock>))]
public sealed record class BetaRequestDocumentBlock
    : Anthropic::ModelBase,
        Anthropic::IFromRaw<BetaRequestDocumentBlock>
{
    public required BetaRequestDocumentBlockProperties::Source Source
    {
        get
        {
            if (!this.Properties.TryGetValue("source", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "source",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<BetaRequestDocumentBlockProperties::Source>(
                    element
                ) ?? throw new System::ArgumentNullException("source");
        }
        set { this.Properties["source"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public Json::JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("type", "Missing required argument");

            return Json::JsonSerializer.Deserialize<Json::JsonElement>(element);
        }
        set { this.Properties["type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            if (!this.Properties.TryGetValue("cache_control", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<BetaCacheControlEphemeral?>(element);
        }
        set { this.Properties["cache_control"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public BetaCitationsConfigParam? Citations
    {
        get
        {
            if (!this.Properties.TryGetValue("citations", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<BetaCitationsConfigParam?>(element);
        }
        set { this.Properties["citations"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public string? Context
    {
        get
        {
            if (!this.Properties.TryGetValue("context", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["context"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public string? Title
    {
        get
        {
            if (!this.Properties.TryGetValue("title", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<string?>(element);
        }
        set { this.Properties["title"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        this.Source.Validate();
        this.CacheControl?.Validate();
        this.Citations?.Validate();
        _ = this.Context;
        _ = this.Title;
    }

    public BetaRequestDocumentBlock()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"document\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    BetaRequestDocumentBlock(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaRequestDocumentBlock FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
