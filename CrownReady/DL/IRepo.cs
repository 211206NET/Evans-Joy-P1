namespace DL;

public interface IRepo
{
    // storefront methods:(1)add storefront;(2)get all storefronts
    List<StoreFront> GetAllStoreFronts();
    void AddStoreFront(StoreFront storeFrontToAdd);
    StoreFront GetStoreFrontById(int storeFrontId);
    // inventory methods(second):(1)add inventory;(2)get all inventories;(3)add inventory to storefront
    void AddInventory(int storeFrontID, int productID, Inventory inventoryToAdd);
    // user methods
    List<User> GetAllUsers();
    void AddUser ( User userToAdd);
    // product methods(second):(1)add product;(2)get all products;(3)add product to inventory
    List<Product> GetAllProducts();
    void AddProduct (Product productToAdd);
    
    // order methods(second):
    void AddOrder(int userID, int storeID, Order orderToAdd);

    // lineitem methods(second):(1)create a lineitem object
    void AddLineitem(int inventoryID, int orderID, LineItem lineitemToAdd);

}