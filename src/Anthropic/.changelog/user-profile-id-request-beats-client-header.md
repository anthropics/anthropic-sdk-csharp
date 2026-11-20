fix(client): send one user profile ID when the request and the client both set one

A user profile ID set on a request and another set in the client's `ExtraHeaders` were both sent, as `anthropic-user-profile-id: a, b`. The request's ID is now sent alone, as `anthropic-workspace-id` already was.
