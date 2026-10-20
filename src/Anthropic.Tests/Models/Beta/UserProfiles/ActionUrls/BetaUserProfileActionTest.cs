using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.UserProfiles.ActionUrls;

namespace Anthropic.Tests.Models.Beta.UserProfiles.ActionUrls;

public class BetaUserProfileActionTest : TestBase
{
    [Fact]
    public void EnrollEndUserValidationWorks()
    {
        BetaUserProfileAction value = new BetaUserProfileEnrollEndUserAction();
        value.Validate();
    }

    [Fact]
    public void EnrollEndUserSerializationRoundtripWorks()
    {
        BetaUserProfileAction value = new BetaUserProfileEnrollEndUserAction();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaUserProfileAction>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
