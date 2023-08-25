using Facade;
using Facade.Clients;
using System.Text.Json;

// Software design pattern Facade:
// This pattern hides the complexities of the larger system and provides a simpler interface to the client.
// It typically involves a single wrapper class that contains a set of members required by the client.
// These members access the system on behalf of the facade client and hide the implementation details.

// Instantiate Facade with all dependencies
IUserService userService = new UserService(
    new UserBookingsClient(),
    new UserMetadataClient(),
    new UserStatisticsClient());

string userId = Guid.NewGuid().ToString();

// Instead of write complex logic in caller method - put all of it into Facade method
var user = await userService.GetUser(userId);

Console.WriteLine(JsonSerializer.Serialize(user, new JsonSerializerOptions { WriteIndented = true }));