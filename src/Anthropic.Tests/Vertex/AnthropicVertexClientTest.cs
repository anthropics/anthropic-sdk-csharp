using System.Net.Http;
using System.Threading.Tasks;
using Anthropic.Vertex;

namespace Anthropic.Tests.Vertex;

public class AnthropicVertexClientTest
{
    [Theory]
    [InlineData("global", "https://aiplatform.googleapis.com")]
    [InlineData(null, "https://aiplatform.googleapis.com")]
    [InlineData("us", "https://aiplatform.us.rep.googleapis.com")]
    [InlineData("us-central1", "https://us-central1-aiplatform.googleapis.com")]
    [InlineData("eu", "https://aiplatform.eu.rep.googleapis.com")]
    [InlineData("europe-west4", "https://europe-west4-aiplatform.googleapis.com")]
    public void Constructor_SetsCorrectBaseUrl(string? region, string expectedBaseUrl)
    {
        var credentials = new FakeVertexCredentials(region!, "test-project");

        var client = new AnthropicVertexClient(credentials);

        Assert.Equal(expectedBaseUrl, client.BaseUrl);
    }

    private class FakeVertexCredentials : IAnthropicVertexCredentials
    {
        public FakeVertexCredentials(string region, string project)
        {
            Region = region;
            Project = project;
        }

        public string Region { get; }
        public string Project { get; }

        public ValueTask ApplyAsync(HttpRequestMessage requestMessage) => default;
    }
}
