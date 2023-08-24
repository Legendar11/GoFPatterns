using Composite;

// Software design pattern Composite:
// The composite pattern describes a group of objects that are treated
// the same way as a single instance of the same type of object.
// The intent of a composite is to "compose" objects into tree structures to represent part-whole hierarchies.
// Implementing the composite pattern lets clients treat individual objects and compositions uniformly.

// We will use IStatistics interface for all next objects:
// In Composite pattern it doesn't matter - we work with leafs or composite objects.

// Work with leaf component
IStatistics user = new User { LastLoginAt = DateTime.Parse("01.01.2000") };

// Work with composite element with leafs
IStatistics tenant = new Tenant
{
    InnerStatistics = new List<IStatistics>
    {
        new User { LastLoginAt = DateTime.Parse("01.01.2000") },
        new User { LastLoginAt = DateTime.Parse("02.01.2000") },
        new User { LastLoginAt = DateTime.Parse("03.01.2000") }
    }
};

// Work with composite element with composite elements
IStatistics superTenant = new Tenant
{
    InnerStatistics = new List<IStatistics>
    {
        new Tenant
        {
            InnerStatistics = new List<IStatistics>
            {
                new User { LastLoginAt = DateTime.Parse("01.01.2000") },
                new User { LastLoginAt = DateTime.Parse("02.01.2000") }
            }
        },
        new Tenant
        {
            InnerStatistics = new List<IStatistics>
            {
                new User { LastLoginAt = DateTime.Parse("01.01.2003") }
            }
        },
        new Tenant
        {
            InnerStatistics = new List<IStatistics>
            {
                new User { LastLoginAt = DateTime.Parse("01.01.2002") },
                new User { LastLoginAt = DateTime.Parse("02.01.2002") },
                new User { LastLoginAt = DateTime.Parse("02.01.2002") }
            }
        }
    }
};

Console.WriteLine($"User Last login: {user.GetLastDateOfLogin()}");
Console.WriteLine($"Tenant Last login: {tenant.GetLastDateOfLogin()}");
Console.WriteLine($"SuperTenant Last login: {superTenant.GetLastDateOfLogin()}");