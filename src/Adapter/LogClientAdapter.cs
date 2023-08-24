namespace Adapter;

/// <summary>
/// Adapter converts specific results from <see cref="ILogClient"/> to <see cref="ILogClientAdapter"/>
/// </summary>
internal class LogClientAdapter : ILogClientAdapter
{
    private readonly ILogClient _logClient;

    public LogClientAdapter(ILogClient logClient)
    {
        _logClient = logClient;
    }

    public async Task<DateTime?> GetLastLoginAsync(string userId, CancellationToken cancellationToken = default)
    {
        var loginLogs = await GetLogFromClientAsync(userId, LogClientAdapterModelEvent.Login, cancellationToken);

        var lastLogin = loginLogs.OrderByDescending(m => m.DateTime).FirstOrDefault();
        return lastLogin?.DateTime;
    }

    public async Task<DateTime?> GetLastResetPassword(string userId, CancellationToken cancellationToken = default)
    {
        var resetPasswordLogs = await GetLogFromClientAsync(userId, LogClientAdapterModelEvent.ResetPassword, cancellationToken);

        var lastResetPassword = resetPasswordLogs.OrderByDescending(m => m.DateTime).FirstOrDefault();
        return lastResetPassword?.DateTime;
    }

    private async Task<LogClientAdapterModel[]> GetLogFromClientAsync(
        string userId,
        LogClientAdapterModelEvent? filterByEvent = null,
        CancellationToken cancellationToken = default)
    {
        // Delegate all main work to innner adaptee service
        var logs = await Task.Run(() => _logClient.GetLogForUser(userId), cancellationToken);

        var convertedLogs = (logs as object[])!.Select(l => LogClientAdapterModel.Convert(userId, l));

        if (filterByEvent is not null)
        {
            convertedLogs = convertedLogs.Where(l => l.Event == filterByEvent);
        }

        return convertedLogs.ToArray();
    }
}
