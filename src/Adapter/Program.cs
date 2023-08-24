using Adapter;

// Gang of Four, Adapter:
// An adapter allows two incompatible interfaces to work together.
// Interfaces may be incompatible, but the inner functionality should suit the need.
// The adapter design pattern allows otherwise incompatible classes to work together
// by converting the interface of one class into an interface expected by the clients.

// Log client is hard to use - we need to use a specific adapter for it
var adaptedLogClient = new LogClientAdapter(new LogClient());

// Fetch necessary data in comfort way via adapter
var userId = Guid.NewGuid().ToString();
var lastLogin = await adaptedLogClient.GetLastLoginAsync(userId);
var lastResetPassword = await adaptedLogClient.GetLastResetPassword(userId);

Console.WriteLine($"Last login was at: {lastLogin.ToString() ?? "no_data"}");
Console.WriteLine($"Last reset password was at: {lastResetPassword.ToString() ?? "no_data"}");