using Anthropic;
using Anthropic.Core;
using Anthropic.Credentials;
using Anthropic.Models.Messages;

// -------------------------------------------------------------------
// Option 1: Zero-config (recommended)
// -------------------------------------------------------------------
// Just construct the client. Auth is resolved automatically in this order:
//
//   1. Explicit ApiKey / AuthToken / Credentials constructor arg
//   2. ANTHROPIC_API_KEY env var         → API key auth
//   3. ANTHROPIC_AUTH_TOKEN env var      → static bearer token
//   4. ANTHROPIC_PROFILE env var        → named profile from config files
//   5. ANTHROPIC_FEDERATION_RULE_ID
//      + ANTHROPIC_IDENTITY_TOKEN_FILE (or ANTHROPIC_IDENTITY_TOKEN)
//      + ANTHROPIC_ORGANIZATION_ID      → workload identity federation
//   6. Active profile from disk         → ~/.config/anthropic/active_config
//
// For Kubernetes / GitHub Actions / etc., set the env vars on the workload.
// For interactive use, run `ant auth login` to create a profile.

using var client = new AnthropicClient();

// -------------------------------------------------------------------
// Option 2: Explicit workload identity credentials
// -------------------------------------------------------------------
// Use this when you want to provide the federation rule and identity
// token source directly instead of relying on env vars / config files.

// using var client = new AnthropicClient(new ClientOptions
// {
//     Credentials = new WorkloadIdentityCredentials(new WorkloadIdentityOptions
//     {
//         FederationRuleId = "fdrl_01example",
//         OrganizationId = "00000000-0000-0000-0000-000000000000",
//         IdentityTokenProvider = new FileIdentityTokenProvider("/var/run/tokens/oidc-jwt"),
//     }),
// });

// -------------------------------------------------------------------
// Option 3: Static bearer token
// -------------------------------------------------------------------
// If you already have an access token (e.g., from a CLI login):

// using var client = new AnthropicClient(new ClientOptions
// {
//     Credentials = new StaticTokenCredentials("sk-ant-oat01-..."),
// });

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
