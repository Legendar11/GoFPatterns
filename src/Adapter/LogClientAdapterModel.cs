namespace Adapter;

internal class LogClientAdapterModel
{
    public string UserId { get; set; } = null!;

    public DateTime? DateTime { get; set; } = null!;

    public LogClientAdapterModelEvent? Event { get; set; } = null!;

    public static LogClientAdapterModel Convert(string userId, object value)
    {
        dynamic dynamicValue = value;
        return new LogClientAdapterModel
        {
            UserId = userId,
            DateTime = dynamicValue.Date,
            Event = dynamicValue.Event switch
            {
                "login" => LogClientAdapterModelEvent.Login,
                "reset_password" => LogClientAdapterModelEvent.ResetPassword,
                "change_restore_question" => LogClientAdapterModelEvent.ChangeRestoreQuestion,
                _ => throw new NotSupportedException($"{dynamicValue.Event} is not supported")
            }
        };
    }
}
