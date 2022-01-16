using System.Text.Json;
namespace DL;

public class FileRepo : IRepo
{
    public FileRepo()
    {}
    private string filePath = "../DL/StoreFronts.json";

    /// <summary>
    /// Returns all storefronts written in file
    /// </summary>
    /// <returns>List of all storefronts</returns>
    public List<StoreFront> GetAllStoreFronts()
    {
        string jsonString = "";
        try
        {
            jsonString = File.ReadAllText(filePath);
        }
        catch(FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        return JsonSerializer.Deserialize<List<StoreFront>>(jsonString) ?? new List<StoreFront>();
    }
    /// <summary>
    /// Adds storefront to list and then writes it to file
    /// </summary>
    /// <param name="storeFrontToAdd">storefront object to be added</param>
    public void AddStoreFront(StoreFront storeFrontToAdd)
    {
        List<StoreFront> allStoreFronts = GetAllStoreFronts();
        allStoreFronts.Add(storeFrontToAdd);

        string jsonString = JsonSerializer.Serialize(allStoreFronts);
        File.WriteAllText(filePath, jsonString);
    }
    /// <summary>
    /// Adds inventory to storefront object and then writes to file
    /// </summary>
    /// <param name="storeFrontIndex">Using index to select storefront object in the list</param>
    /// <param name="inventoryToAdd">Inventory object to be added</param>
    public void AddInventory(int storeFrontID, int productID, Inventory inventoryToAdd)
    {

    }
    // user methods(first):(1)get all users; (2)add user; (3)create signup method
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
    public void SignUp(string name, string email)
    {
        // _dl.SignUp(name, email);
    }
    public bool LogIn(string email)
    {
        throw new NotImplementedException();
    }
    public void CurrentUser(User currentUser)
    {
        // _dl.CurrentUser(currentUser);
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

    // order methods(first):
    public void AddOrder(int userID, int storeID, Order orderToAdd)
    {
        // future code (20211214 @ 24:10)
        // _dl.AddOrder(userID, storeID, orderToAdd);
    }
    

    // lineitem methods(first):(1)create a lineitem object
    public void AddLineitem(int inventoryID, int orderID, LineItem lineitemToAdd)
    {
        // future code (20211214 @ 24:10)
        // _dl.AddLineitem(inventoryID, orderID, lineitemToAdd);
    }

    public StoreFront GetStoreFrontById(int storeFrontId)
    {
        throw new NotImplementedException();
    }
}