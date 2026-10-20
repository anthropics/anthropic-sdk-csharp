using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.UserProfiles.ActionUrls;

namespace Anthropic.Tests.Models.UserProfiles.ActionUrls;

public class UserProfileActionTest : TestBase
{
    [Fact]
    public void EnrollEndUserValidationWorks()
    {
        UserProfileAction value = new UserProfileEnrollEndUserAction();
        value.Validate();
    }

    [Fact]
    public void EnrollEndUserSerializationRoundtripWorks()
    {
        UserProfileAction value = new UserProfileEnrollEndUserAction();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UserProfileAction>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
