namespace BL;
public class CRBL : IBL
{
    private IRepo _dl;

    public CRBL(IRepo repo)
    {
        _dl = repo;
    }
    /// <summary>
    /// gets all storefronts
    /// </summary>
    /// <returns>list of al storefronts</returns>
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

    /// <summary>
    /// Add a new inventory to the storefront that exists on that index
    /// </summary>
    /// <param name="storeFrontIndex">index of the storefront to add inventory</param>
    /// <param name="inventoryToAdd">an inventory object to be added to the storefront</param>
    public void AddInventory(int storeFrontIndex, Inventory inventoryToAdd)
    {
        // future code (20211214 @ 24:10)
        _dl.AddInventory(storeFrontIndex, inventoryToAdd);
    }
}
