using Bridge;
using Bridge.UserLogs;
using Bridge.Users;

// Software design pattern Bridge:
// When a class varies often, the features of object-oriented programming become very useful because changes
// to a program's code can be made easily with minimal prior knowledge about the program.
// The bridge pattern is useful when both the class and what it does vary often.
// The class itself can be thought of as the abstraction and what the class can do as the implementation.
// The bridge pattern can also be thought of as two layers of abstraction.

// Two independent abstractions, one uses the other
IUserLog log;
User user;

// Two independent implementations of abstractions
log = new RegularUserLog();
user = new RegularUser(log);

user.AddLogEntry("login", DateTime.UtcNow.ToString());
user.AddLogEntry("login", DateTime.UtcNow.ToString());
user.AddLogEntry("restore_password", "by_security_password");
user.AddLogEntry("login", DateTime.UtcNow.ToString());
user.AddLogEntry("get_order", "with_special_card");
Console.WriteLine("RegularUserLog:");
Console.WriteLine(string.Join(Environment.NewLine, user.GetLog().Select(l => $"\t{l}")));
Console.WriteLine("===================//=============================");

// Refined abstraction SecurityUser and Implementation UniqueUserLog are not connected,
// they are independent implementations
user = new SecurityUser(new UniqueUserLog());

user.AddLogEntry("login", DateTime.UtcNow.ToString());
user.AddLogEntry("login", DateTime.UtcNow.ToString());
user.AddLogEntry("restore_password", "by_security_password");
user.AddLogEntry("login", DateTime.UtcNow.ToString());
Console.WriteLine("UniqueUserLog:");
user.AddLogEntry("get_order", "with_special_card");
Console.WriteLine(string.Join(Environment.NewLine, user.GetLog().Select(l => $"\t{l}")));
Console.WriteLine("===================//=============================");