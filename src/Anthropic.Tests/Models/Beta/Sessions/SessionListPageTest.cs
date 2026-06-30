using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class SessionListPageTest
{
    [Fact]
    public void CursorsAndResponse_AreExposed()
    {
        var response = new SessionListPageResponse
        {
            Data = [],
            NextPage = "page_next_cursor",
            PrevPage = "page_prev_cursor",
        };
        var page = new SessionListPage(null!, new SessionListParams(), response);

        Assert.Same(response, page.Response);
        Assert.Equal("page_next_cursor", page.NextPage);
        Assert.Equal("page_prev_cursor", page.PrevPage);
    }

    [Fact]
    public void Cursors_NullWhenAbsent()
    {
        var page = new SessionListPage(
            null!,
            new SessionListParams(),
            new SessionListPageResponse { Data = [] }
        );

        Assert.Null(page.NextPage);
        Assert.Null(page.PrevPage);
    }
}
