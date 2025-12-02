using Anthropic.Core;
using Anthropic.Models.Beta.Files;

namespace Anthropic.Tests.Models.Beta.Files;

public class DeletedFileTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeletedFile { ID = "id", Type = Type.FileDeleted };

        string expectedID = "id";
        ApiEnum<string, Type> expectedType = Type.FileDeleted;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
    }
}
