namespace BL;

public interface IBL
{
    // storefront methods:(1)add storefront;(2)get all storefronts
    List<StoreFront> GetAllStoreFronts();
    void AddStoreFront (StoreFront storeFrontToAdd);
    StoreFront GetStoreFrontById(int storeFrontId);
    // inventory methods(third):(1)add inventory;(2)get all inventories;(3)add inventory to storefront
    void AddToInventory(int storeFrontID, int productID, Inventory inventoryToAdd);

    // user methods(first):(1)get all users; (2)add user; (3)create signup method
    List<User> GetAllUsers();
    void AddUser ( User userToAdd);
    void SignUp(string name, string email);
    bool LogIn(string email);
    void CurrentUser(User currentUser);
    // product methods(third):(1)add product;(2)get all products;(3)add product to inventory
    void AddProduct (Product productToAdd);
    List<Product> GetAllProducts();
    // order methods(third):
    void AddOrder(int userID, int storeID, Order orderToAdd);

    // lineitem methods(third):(1)create a lineitem object
    void AddLineitem(int inventoryID, int orderID, LineItem lineitemToAdd);
}