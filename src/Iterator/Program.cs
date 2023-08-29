using Iterator;
using Iterator.Iterators;

// Software design patter Iterator:
// Provides the ability to permanently access all elements
// composite object without disclosing its internal appearance.
// The main purpose - separate and delegate iterating algorithm into special iterators.
// C# has native support for pattern - IEnumerable<T> and IEnumerator<T>.

UsersLogs users = new UsersLogs(new[]
{
    new UserLog("1", DateTime.Parse("01.01.2020"), UserAcitivity.Login),
    new UserLog("2", DateTime.Parse("02.01.2020"), UserAcitivity.RestorePassword),
    new UserLog("2", DateTime.Parse("01.01.2020"), UserAcitivity.Login),
    new UserLog("1", DateTime.Parse("01.01.2020"), UserAcitivity.MakeTicket),
});

Console.WriteLine("User.GetEnumerator:");
foreach (var user in users)
{
    Console.WriteLine(user);
}
Console.WriteLine("=====================//===================");

users.Iterator = new DefaultIterator(users.Users);
Console.WriteLine("DefaultIterator:");
foreach (var user in users)
{
    Console.WriteLine(user);
}
Console.WriteLine("=====================//===================");

users.Iterator = new GroupByIdIterator(users.Users);
Console.WriteLine("GroupByIdIterator:");
foreach (var user in users)
{
    Console.WriteLine(user);
}
Console.WriteLine("=====================//===================");

users.Iterator = new InfiniteLoopIterator(users.Users);
Console.WriteLine("InfiniteLoopIterator:");
IEnumerator<UserLog> iterator = users.Iterator;
foreach (var _ in Enumerable.Range(0, 10))
{
    Console.WriteLine(iterator.Current);
    iterator.MoveNext();
}
Console.WriteLine("=====================//===================");