using Messages = Anthropic.Client.Models.Beta.Messages;

namespace Anthropic.Client.Models.Beta.Messages.BetaMemoryTool20250818CommandVariants;

public sealed record class BetaMemoryTool20250818ViewCommand(
    Messages::BetaMemoryTool20250818ViewCommand Value
)
    : Messages::BetaMemoryTool20250818Command,
        IVariant<BetaMemoryTool20250818ViewCommand, Messages::BetaMemoryTool20250818ViewCommand>
{
    public static BetaMemoryTool20250818ViewCommand From(
        Messages::BetaMemoryTool20250818ViewCommand value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaMemoryTool20250818CreateCommand(
    Messages::BetaMemoryTool20250818CreateCommand Value
)
    : Messages::BetaMemoryTool20250818Command,
        IVariant<BetaMemoryTool20250818CreateCommand, Messages::BetaMemoryTool20250818CreateCommand>
{
    public static BetaMemoryTool20250818CreateCommand From(
        Messages::BetaMemoryTool20250818CreateCommand value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaMemoryTool20250818StrReplaceCommand(
    Messages::BetaMemoryTool20250818StrReplaceCommand Value
)
    : Messages::BetaMemoryTool20250818Command,
        IVariant<
            BetaMemoryTool20250818StrReplaceCommand,
            Messages::BetaMemoryTool20250818StrReplaceCommand
        >
{
    public static BetaMemoryTool20250818StrReplaceCommand From(
        Messages::BetaMemoryTool20250818StrReplaceCommand value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaMemoryTool20250818InsertCommand(
    Messages::BetaMemoryTool20250818InsertCommand Value
)
    : Messages::BetaMemoryTool20250818Command,
        IVariant<BetaMemoryTool20250818InsertCommand, Messages::BetaMemoryTool20250818InsertCommand>
{
    public static BetaMemoryTool20250818InsertCommand From(
        Messages::BetaMemoryTool20250818InsertCommand value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaMemoryTool20250818DeleteCommand(
    Messages::BetaMemoryTool20250818DeleteCommand Value
)
    : Messages::BetaMemoryTool20250818Command,
        IVariant<BetaMemoryTool20250818DeleteCommand, Messages::BetaMemoryTool20250818DeleteCommand>
{
    public static BetaMemoryTool20250818DeleteCommand From(
        Messages::BetaMemoryTool20250818DeleteCommand value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaMemoryTool20250818RenameCommand(
    Messages::BetaMemoryTool20250818RenameCommand Value
)
    : Messages::BetaMemoryTool20250818Command,
        IVariant<BetaMemoryTool20250818RenameCommand, Messages::BetaMemoryTool20250818RenameCommand>
{
    public static BetaMemoryTool20250818RenameCommand From(
        Messages::BetaMemoryTool20250818RenameCommand value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
