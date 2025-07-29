using Anthropic = Anthropic;
using Generic = System.Collections.Generic;
using Messages = Anthropic.Models.Beta.Messages;
using Serialization = System.Text.Json.Serialization;
using SystemVariants = Anthropic.Models.Beta.Messages.Batches.BatchCreateParamsProperties.RequestProperties.ParamsProperties.SystemVariants;

namespace Anthropic.Models.Beta.Messages.Batches.BatchCreateParamsProperties.RequestProperties.ParamsProperties;

/// <summary>
/// System prompt.
///
/// A system prompt is a way of providing context and instructions to Claude, such
/// as specifying a particular goal or role. See our [guide to system prompts](https://docs.anthropic.com/en/docs/system-prompts).
/// </summary>
[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<System>))]
public abstract record class System
{
    internal System() { }

    public static implicit operator System(string value) => new SystemVariants::UnionMember0(value);

    public static implicit operator System(Generic::List<Messages::BetaTextBlockParam> value) =>
        new SystemVariants::UnionMember1(value);

    public abstract void Validate();
}
