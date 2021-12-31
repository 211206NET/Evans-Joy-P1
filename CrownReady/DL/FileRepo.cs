namespace DL;

public class FileRepo
{
    public FileRepo()
    {

    }
    /// <summary>
    /// Returns all storefronts written in file
    /// </summary>
    /// <returns>List of all storefronts</returns>
    public List<StoreFront> GetAllStoreFronts()
    {
        // returns all storefronts in file.
        return new List<StoreFront>();
    }
    /// <summary>
    /// Adds storefront to list and then writes it to file
    /// </summary>
    /// <param name="storeFrontToAdd"></param>
    public void AddStoreFront(StoreFront storeFrontToAdd)
    {
        
    }

    public void AddInventory(int storeFrontIndex, Inventory inventoryToAdd)
    {
        
    }
}