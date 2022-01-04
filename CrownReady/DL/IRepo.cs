namespace DL;

public interface IRepo
{
    List<StoreFront> GetAllStoreFronts();

    void AddStoreFront(StoreFront storeFrontToAdd);
}