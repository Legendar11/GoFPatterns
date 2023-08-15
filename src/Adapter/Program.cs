using Adapter;

// Gang of Four, Adapter:
// An adapter allows two incompatible interfaces to work together.
// This is the real-world definition for an adapter.
// Interfaces may be incompatible, but the inner functionality should suit the need.
// The adapter design pattern allows otherwise incompatible classes to work together
// by converting the interface of one class into an interface expected by the clients.

// Galactic Empire has Tatooine planet.
// They need to establish communication.
// Galactice Empire needs to special adapter to contact with Tatooine.

// Galactic Empire - Client,
// Tatooine - Service with incompatible interface,
// TatooineAdapter - Adapter with expected interface.

var empire = new GalacticEmpire();

Console.WriteLine(empire);