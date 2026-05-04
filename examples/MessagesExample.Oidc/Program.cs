using Anthropic.Models.Messages;
using Anthropic.Oidc;

// -------------------------------------------------------------------
// Option 1: Explicit workload identity credentials
// -------------------------------------------------------------------
// Use this when you know the exact federation rule and identity token source.
// Set these environment variables or provide values directly:
//   ANTHROPIC_IDENTITY_TOKEN_FILE - path to OIDC JWT file (e.g., from Kubernetes projected volume)
//   ANTHROPIC_FEDERATION_RULE     - federation rule ID (e.g., fdrl_01...)
//   ANTHROPIC_ORGANIZATION_ID     - organization UUID
//   ANTHROPIC_SERVICE_ACCOUNT_ID  - optional service account ID (e.g., svac_01...)

// var credentials = new WorkloadIdentityCredentials(new WorkloadIdentityOptions
// {
//     FederationRuleId = "fdrl_01example",
//     OrganizationId = "00000000-0000-0000-0000-000000000000",
//     IdentityTokenProvider = new FileIdentityTokenProvider("/var/run/tokens/oidc-jwt"),
// });
// using var client = new AnthropicOidcClient(credentials);

// -------------------------------------------------------------------
// Option 2: Auto-resolved credentials from environment / config files
// -------------------------------------------------------------------
// Checks ANTHROPIC_API_KEY, ANTHROPIC_AUTH_TOKEN, config profiles, and
// environment variables in order. Returns null if API key auth should be used.
//
// Config profiles live in:
//   Linux/macOS: ~/.config/anthropic/configs/<profile>.json
//   Windows:     %APPDATA%\Anthropic\configs\<profile>.json

var result = AnthropicCredentials.Resolve();
if (result == null)
{
    Console.Error.WriteLine(
        "No OIDC credentials resolved. Set ANTHROPIC_FEDERATION_RULE and "
            + "ANTHROPIC_IDENTITY_TOKEN_FILE (or ANTHROPIC_IDENTITY_TOKEN) to use workload identity, "
            + "or configure a profile in ~/.config/anthropic/."
    );
    return;
}

using var client = new AnthropicOidcClient(result);

// -------------------------------------------------------------------
// Option 3: Static bearer token
// -------------------------------------------------------------------
// If you already have an access token (e.g., from a CLI login):
// using var client = new AnthropicOidcClient(new StaticTokenCredentials("sk-ant-oat01-..."));

MessageCreateParams parameters = new()
{
    MaxTokens = 2048,
    Messages =
    [
        new() { Content = "Tell me a story about building the best SDK!", Role = Role.User },
    ],
    Model = "claude-sonnet-4-5",
};

var response = await client.Messages.Create(parameters);

var message = string.Join(
    "",
    response
        .Content.Select(message => message.Value)
        .OfType<TextBlock>()
        .Select((textBlock) => textBlock.Text)
);

Console.WriteLine(message);
