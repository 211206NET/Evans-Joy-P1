using Models;

namespace DL;

// A static class in C# is a class that cannot be instantiated.
// A static class can only contain static data members including static methods, static constructors, and static properties.
// In C#, a static class is a class that cannot be instantiated. ... You can't create an object for the static class.
public class StaticStorage :  IRepo
{

    private static List<StoreFront> _allStoreFronts = new List<StoreFront>();

    /// <summary>
    /// Returns all storefronts from _allStoreFronts list
    /// </summary>
    /// <returns>all storefronts in the list</returns>
    public List<StoreFront> GetAllStoreFronts()
    {
        return StaticStorage._allStoreFronts;
    }

    /// <summary>
    /// add a new storefront to the list
    /// </summary>
    /// <param name="storeFront">a new storefront object to add</param>
    public void AddStoreFront (StoreFront storeFrontToAdd)
    {
        StaticStorage._allStoreFronts.Add(storeFrontToAdd);
    }

    public void AddInventory(int storeFrontIndex, Inventory inventoryToAdd)
    {
        // future code (20211214 @ 10:41)
    }


}
