using System.Collections.Generic;
using System.Text.Json.Serialization;
using ContentVariants = Anthropic.Models.Beta.Messages.BetaMessageParamProperties.ContentVariants;

namespace Anthropic.Models.Beta.Messages.BetaMessageParamProperties;

[JsonConverter(typeof(UnionConverter<Content>))]
public abstract record class Content
{
    internal Content() { }

    public static implicit operator Content(string value) => new ContentVariants::String(value);

    public static implicit operator Content(List<BetaContentBlockParam> value) =>
        new ContentVariants::BetaContentBlockParams(value);

    public abstract void Validate();
}
