using Anthropic.Client.Core;
using Messages = Anthropic.Client.Models.Beta.Messages;

namespace Anthropic.Client.Models.Beta.Messages.BetaTextEditorCodeExecutionToolResultBlockParamProperties.ContentVariants;

public sealed record class BetaTextEditorCodeExecutionToolResultErrorParam(
    Messages::BetaTextEditorCodeExecutionToolResultErrorParam Value
)
    : Content,
        IVariant<
            BetaTextEditorCodeExecutionToolResultErrorParam,
            Messages::BetaTextEditorCodeExecutionToolResultErrorParam
        >
{
    public static BetaTextEditorCodeExecutionToolResultErrorParam From(
        Messages::BetaTextEditorCodeExecutionToolResultErrorParam value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaTextEditorCodeExecutionViewResultBlockParam(
    Messages::BetaTextEditorCodeExecutionViewResultBlockParam Value
)
    : Content,
        IVariant<
            BetaTextEditorCodeExecutionViewResultBlockParam,
            Messages::BetaTextEditorCodeExecutionViewResultBlockParam
        >
{
    public static BetaTextEditorCodeExecutionViewResultBlockParam From(
        Messages::BetaTextEditorCodeExecutionViewResultBlockParam value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaTextEditorCodeExecutionCreateResultBlockParam(
    Messages::BetaTextEditorCodeExecutionCreateResultBlockParam Value
)
    : Content,
        IVariant<
            BetaTextEditorCodeExecutionCreateResultBlockParam,
            Messages::BetaTextEditorCodeExecutionCreateResultBlockParam
        >
{
    public static BetaTextEditorCodeExecutionCreateResultBlockParam From(
        Messages::BetaTextEditorCodeExecutionCreateResultBlockParam value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaTextEditorCodeExecutionStrReplaceResultBlockParam(
    Messages::BetaTextEditorCodeExecutionStrReplaceResultBlockParam Value
)
    : Content,
        IVariant<
            BetaTextEditorCodeExecutionStrReplaceResultBlockParam,
            Messages::BetaTextEditorCodeExecutionStrReplaceResultBlockParam
        >
{
    public static BetaTextEditorCodeExecutionStrReplaceResultBlockParam From(
        Messages::BetaTextEditorCodeExecutionStrReplaceResultBlockParam value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
