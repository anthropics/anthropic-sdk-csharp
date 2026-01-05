using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Json.Schema;
using Microsoft.Extensions.AI;
using Xunit;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests
{
    /// <summary>
    /// Tests that verify the 'pattern' parameter is not causing issues.
    /// </summary>
    public class PatternParameterBugTests
    {
        [Description("Search for text using a pattern")]
        public static Task<string> SearchWithPatternAsync(
            [Description("The pattern to search for")] string pattern)
        {
            return Task.FromResult($"Searching for: {pattern}");
        }

        [Fact]
        public async Task PatternParameter_ShouldBeNestedUnderProperties_NotAtTopLevel()
        {
            // Capture the actual HTTP request that would be sent to Anthropic
            string? capturedRequestBody = null;
            var testHandler = new TestHttpMessageHandler(async (request, cancellationToken) =>
            {
                // Capture the request body
                if (request.Content != null)
                {
                    capturedRequestBody = await request.Content.ReadAsStringAsync();
                }

                // Return a minimal valid response
                var responseContent = JsonSerializer.Serialize(new
                {
                    id = "msg_test",
                    type = "message",
                    role = "assistant",
                    content = new[]
                    {
                        new { type = "text", text = "Test response" }
                    },
                    model = "claude-3-5-sonnet-20241022",
                    stop_reason = "end_turn",
                    usage = new { input_tokens = 10, output_tokens = 20 }
                });

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(responseContent, System.Text.Encoding.UTF8, "application/json")
                };
            });

            var httpClient = new HttpClient(testHandler)
            {
                BaseAddress = new Uri("https://api.anthropic.com")
            };

            // Create client with our test HTTP handler
            var anthropicClient = new AnthropicClient(new ClientOptions
            {
                APIKey = "test-key",
                HttpClient = httpClient
            });

            var chatClient = anthropicClient.AsIChatClient("claude-3-5-sonnet-20241022");

            // Create AIFunction with 'pattern' parameter
            var toolWithPattern = AIFunctionFactory.Create(SearchWithPatternAsync);

            // Make a request with this tool
            var messages = new List<ChatMessage>
            {
                new(ChatRole.User, "Search for 'error'")
            };

            var options = new ChatOptions
            {
                Tools = [toolWithPattern]
            };

            try
            {
                await chatClient.GetResponseAsync(messages, options);
            }
            catch (Exception ex)
            {
                Assert.Fail($"GetResponseAsync error: {ex.Message}. ");
            }

            // Now analyze the captured request
            Assert.NotNull(capturedRequestBody);

            Console.WriteLine("Captured Request Body:");
            Console.WriteLine(capturedRequestBody);

            var requestJson = JsonDocument.Parse(capturedRequestBody);
            var root = requestJson.RootElement;

            // Find the tools array
            Assert.True(root.TryGetProperty("tools", out var toolsElement),
                "Request should have 'tools' property");
            Assert.True(toolsElement.ValueKind == JsonValueKind.Array,
                "tools should be an array");

            var toolsArray = toolsElement.EnumerateArray().ToList();
            Assert.Single(toolsArray); // Should have exactly one tool

            var tool = toolsArray[0];
            Assert.True(tool.TryGetProperty("input_schema", out var inputSchema),
                "Tool should have 'input_schema'");

            var inputSchemaJson = JsonSerializer.Serialize(inputSchema, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine(inputSchemaJson);

            // validate against json schema specification (Current: Draft 2020-12)
            JsonSchema schema;
            try
            {
                schema = JsonSerializer.Deserialize<JsonSchema>(inputSchemaJson)!;
            }
            catch (Exception ex)
            {
                Assert.Fail($"Validation error: {ex.Message}. ");
            }
        }

        /// <summary>
        /// Custom HTTP message handler that lets us intercept requests
        /// </summary>
        private class TestHttpMessageHandler : HttpMessageHandler
        {
            private readonly Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> _handler;

            public TestHttpMessageHandler(Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> handler)
            {
                _handler = handler;
            }

            protected override Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request, 
                CancellationToken cancellationToken)
            {
                return _handler(request, cancellationToken);
            }
        }
    }
}
