using System.Collections.Generic;
using System.Text.Json.Serialization;
using SystemVariants = Anthropic.Models.Messages.MessageCreateParamsProperties.SystemVariants;

namespace Anthropic.Models.Messages.MessageCreateParamsProperties;

/// <summary>
/// System prompt.
///
/// A system prompt is a way of providing context and instructions to Claude, such
/// as specifying a particular goal or role. See our [guide to system prompts](https://docs.anthropic.com/en/docs/system-prompts).
/// </summary>
[JsonConverter(typeof(UnionConverter<System>))]
public abstract record class System
{
    internal System() { }

    public static implicit operator System(string value) => new SystemVariants::String(value);

    public static implicit operator System(List<TextBlockParam> value) =>
        new SystemVariants::TextBlockParams(value);

    public abstract void Validate();
}
