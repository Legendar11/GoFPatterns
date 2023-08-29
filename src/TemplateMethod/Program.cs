using TemplateMethod;
using TemplateMethod.PasswordGenerators;

// Software design pattern Template Method:
// A template method defines the basis of an algorithm and allows subclasses
// to redefine some of the steps in the algorithm without changing its structure as a whole.

// First version of implemented 'Generate' method
using IPasswordGenerator generatorSimlple = new SimplePasswordGenerator();
Console.WriteLine(generatorSimlple.Generate());

// Second version of implemented 'Generate' method
using IPasswordGenerator generatorStrong = new StrongPasswordGenerator();
Console.WriteLine(generatorStrong.Generate());