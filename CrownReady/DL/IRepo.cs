namespace DL;

public interface IRepo
{
    List<StoreFront> GetAllStoreFronts();

    void AddStoreFront(StoreFront storeFrontToAdd);

    void AddInventory(int storeFrontIndex, Inventory inventoryToAdd);
}