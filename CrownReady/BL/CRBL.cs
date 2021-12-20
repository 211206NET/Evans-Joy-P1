using Models;
using DL;

namespace BL;
public class CRBL
{
    /// <summary>
    /// gets all storefronts
    /// </summary>
    /// <returns>list of al storefronts</returns>
    public List<StoreFront> GetAllStores()
    {
        return StaticStorage.GetAllStores();
    }

    /// <summary>
    /// adds new storefront to the list
    /// </summary>
    /// <param name="storeFront">storefront object to add</param>
    public void AddStoreFront (StoreFront storeFront)
    {
        StaticStorage.AddStoreFront(storeFront);
    }
}
