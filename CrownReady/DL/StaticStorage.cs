using Models;

namespace DL;

// A static class in C# is a class that cannot be instantiated.
// A static class can only contain static data members including static methods, static constructors, and static properties.
// In C#, a static class is a class that cannot be instantiated. ... You can't create an object for the static class.
public static class StaticStorage
{

    public static List<StoreFrontDetail> allLocations = new List<StoreFrontDetail>();


}
