namespace Iterator;

internal sealed record UserLog(
    string UserId,
    DateTime CreatedAt,
    UserAcitivity Acitivity
);
