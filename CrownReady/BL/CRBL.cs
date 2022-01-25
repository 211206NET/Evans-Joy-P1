namespace BL;
public class CRBL : IBL
{
    private IRepo _dl;

    public CRBL(IRepo repo)
    {
        _dl = repo;
    }

    // storefront methods(first):(1)add storefront;(2)get all storefronts
    /// <summary>
    /// gets all storefronts
    /// </summary>
    /// <returns>list of all storefronts</returns>
    public List<StoreFront> GetAllStoreFronts()
    {
        return _dl.GetAllStoreFronts();
        // return new List<StoreFront>();
    }
    /// <summary>
    /// adds new storefront to the list
    /// </summary>
    /// <param name="storeFront">storefront object to add</param>
    public void AddStoreFront (StoreFront storeFrontToAdd)
    {
        _dl.AddStoreFront(storeFrontToAdd);
    }


    // inventory methods(first):(1)add inventory to storefront
    /// <summary>
    /// add inventory to storefront
    /// </summary>
    /// <param name="storeFrontID">storefront obj. to add</param>
    /// <param name="productID">product obj. to add</param>
    /// <param name="inventoryToAdd"></param>
    public void AddToInventory(int storeFrontID, int productID, Inventory inventoryToAdd)
    {
        // future code (20211214 @ 24:10)
        _dl.AddToInventory(storeFrontID, productID, inventoryToAdd);
    }
    public List<Inventory> GetAllInventory()
    {
        return _dl.GetAllInventory();
    }
    public bool InventoryExists(int storeFrontID)
    {
        return _dl.InventoryExists(storeFrontID);
    }

    // user methods(first):(1)get all users; (2)add user; (3)create signup method
    public List<User> GetAllUsers()
    {
        return _dl.GetAllUsers();
        // return new List<User>();
    }
    /// <summary>
    /// adds new user to the list
    /// </summary>
    /// <param name="userToAdd">user object to add</param>
    public void AddUser ( User userToAdd)
    {
        _dl.AddUser(userToAdd);
    }
    /// <summary>
    /// signup method that adds a new user
    /// </summary>
    /// <param name="name">name string</param>
    /// <param name="email">email string</param>
    public void SignUp(string name, string email)
    {
        _dl.SignUp(name, email);
    }
    public bool LogIn(string email)
    {
        return _dl.LogIn(email);
    }
    public void CurrentUser(User currentUser)
    {
        _dl.CurrentUser(currentUser);
    }
    public User GetUserByName(string name)
    {
        return _dl.GetUserByName(name);
    }
    // product methods(first):(1)add product;(2)get all products
    /// <summary>
    /// adds a new product to the list
    /// </summary>
    /// <param name="productToAdd">product object to add</param>
    public void AddProduct (Product productToAdd)
    {
        _dl.AddProduct(productToAdd);
    }
    public List<Product> GetAllProducts()
    {
        return _dl.GetAllProducts();
    }


    // order methods(first):
    public void AddOrder(int userID, int storeID, Order orderToAdd)
    {
        // future code (20211214 @ 24:10)
        _dl.AddOrder(userID, storeID, orderToAdd);
    }
    public List<Order> GetOrderByUserId(int id)
    {
        return _dl.GetOrderByUserId(id);
    }
    public List<Order> GetOrderByStoreId(int id)
    {
        return _dl.GetOrderByStoreId(id);
    }

    // lineitem methods(first):(1)create a lineitem object
        public void AddLineitem(int inventoryID, int orderID, LineItem lineitemToAdd)
    {
        // future code (20211214 @ 24:10)
        _dl.AddLineitem(inventoryID, orderID, lineitemToAdd);
    }

    public StoreFront GetStoreFrontById(int storeFrontId)
    {
        return _dl.GetStoreFrontById(storeFrontId);
    }
}
