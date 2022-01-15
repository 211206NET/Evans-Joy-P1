/*namespace DL;

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

    public void AddInventory(int storeFrontID, int productID, Inventory inventoryToAdd)
    {
        // future code (20211214 @ 10:41)
    }

    // user methods
    public List<User> GetAllUsers()
    {
        // return _dl.GetAllUsers();
        return new List<User>();
    }
    /// <summary>
    /// adds new user to the list
    /// </summary>
    /// <param name="userToAdd">user object to add</param>
    public void AddUser ( User userToAdd)
    {
        // _dl.AddUser(userToAdd);
    }

        // order methods(first):
        public void AddOrder(int userID, int storeID, Order orderToAdd)
    {
        // future code (20211214 @ 24:10)
        // _dl.AddOrder(userID, storeID, orderToAdd);
    }
    

    // product methods(first):(1)add product;(2)get all products
    /// <summary>
    /// adds a new product to the list
    /// </summary>
    /// <param name="productToAdd">product object to add</param>
    public void AddProduct (Product productToAdd)
    {
        // _dl.AddProduct(productToAdd);
    }
    public List<Product> GetAllProducts()
    {
        return new List<Product>();
        // return _dl.GetAllProducts();
    }

    // lineitem methods(first):(1)create a lineitem object
        public void AddLineitem(int inventoryID, int orderID, LineItem lineitemToAdd)
    {
        // future code (20211214 @ 24:10)
        // _dl.AddLineitem(inventoryID, orderID, lineitemToAdd);
    }


}*/
