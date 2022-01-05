namespace BL;

public interface IBL
{
    List<StoreFront> GetAllStoreFronts();
    void AddStoreFront (StoreFront storeFrontToAdd);
    void AddInventory(int storeFrontIndex, Inventory inventoryToAdd);
}