namespace BL;

public interface IBL
{
    // storefront methods:(1)add storefront;(2)get all storefronts
    List<StoreFront> GetAllStoreFronts();
    void AddStoreFront (StoreFront storeFrontToAdd);
    StoreFront GetStoreFrontById(int storeFrontId);
    // inventory methods(third):(1)add inventory;(2)get all inventories;(3)add inventory to storefront
    void AddInventory(int storeFrontID, int productID, Inventory inventoryToAdd);

    // user methods
    List<User> GetAllUsers();
    void AddUser ( User userToAdd);
    // product methods(third):(1)add product;(2)get all products;(3)add product to inventory
    // order methods(third):
    void AddOrder(int userID, int storeID, Order orderToAdd);

    // lineitem methods(third):(1)create a lineitem object
    void AddLineitem(int inventoryID, int orderID, LineItem lineitemToAdd);
}