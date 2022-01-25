namespace DL;

public interface IRepo
{
    // storefront methods:(1)add storefront;(2)get all storefronts
    List<StoreFront> GetAllStoreFronts();
    void AddStoreFront(StoreFront storeFrontToAdd);
    StoreFront GetStoreFrontById(int storeFrontId);
    // inventory methods(second):(1)add inventory;(2)get all inventories;(3)add inventory to storefront
    void AddToInventory(int storeFrontID, int productID, Inventory inventoryToAdd);
    List<Inventory> GetAllInventory();
    bool InventoryExists(int storeFrontID);
    // user methods(first):(1)get all users; (2)add user; (3)create signup method
    List<User> GetAllUsers();
    User GetUserByName(string name);
    void AddUser ( User userToAdd);
    void SignUp(string name, string email);
    bool LogIn(string email);
    void CurrentUser(User currentUser);
    // product methods(second):(1)add product;(2)get all products;(3)add product to inventory
    List<Product> GetAllProducts();
    void AddProduct (Product productToAdd);
    
    // order methods(second):
    void AddOrder(int userID, int storeID, Order orderToAdd);
    List<Order> GetOrderByUserId(int id);
    List<Order> GetOrderByStoreId(int id);

    // lineitem methods(second):(1)create a lineitem object
    void AddLineitem(int inventoryID, int orderID, LineItem lineitemToAdd);

}