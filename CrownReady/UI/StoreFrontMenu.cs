using DL;
namespace UI;

public class StoreFrontMenu : IMenu
{
    private IBL _bl;
    public StoreFrontMenu(IBL bl)
    {
        _bl = bl;
    }
    public void Start()
    {
        bool exit = false;
        while(!exit)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("So what would you like to do today?");
            Console.WriteLine("[1] Shop locations");
            Console.WriteLine("[2] View Previous Orders");

            Console.WriteLine("[x] Logout", Console.ForegroundColor = ConsoleColor.Red); //Optional: have text be shown in red

            Console.ForegroundColor = ConsoleColor.White;
            string? input = Console.ReadLine();

            switch(input)
            {   
                case "1":
                    viewAllStoreFronts();
                break;

                case "2":
                    Console.WriteLine("Coming Soon: View Previous Orders");
                break;

                case "x":
                    Console.WriteLine("Goodbye!");
                    exit = true;

                break;
                
                default:
                    Console.WriteLine("Sorry about that but I don't understand");
                break;
            }
        }
    }
    private void viewAllStoreFronts(){
        List<StoreFront> getAllStoreFronts = _bl.GetAllStoreFronts();
        List<Inventory> getAllInventory = _bl.GetAllInventory();

        Console.WriteLine("Select a location:");
        if (getAllStoreFronts.Count > 0)
        {
            for(int i = 0; i < getAllStoreFronts.Count; i++)
            {
                Console.WriteLine($" [{i}] {getAllStoreFronts[i].DisplayStoreFront()}");
            }
            int selection = Int32.Parse(Console.ReadLine() ?? "");
            StoreFront selectStoreFront = getAllStoreFronts[selection];

            _bl.InventoryExists(selection);
            
            Console.WriteLine($"Welcome to {selectStoreFront.Name}");
            if (getAllInventory.Count > 0)
            {
                for(int i = 0; i < getAllInventory.Count; i++)
                {
                    Console.WriteLine($"[{i}] {getAllInventory[i].DisplayInventory()}");
                }
            }
            else
            {
            Console.WriteLine("There are no products available :(");
            }
            // new CustomerMenu().Start();
        }
        else
        {
            Console.WriteLine("There are no stores available :(");
        }
    }
}