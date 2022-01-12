using DL;
namespace UI;

public class InventoryMenu : IMenu
{
    private IBL _bl;
    public InventoryMenu(IBL bl)
    {
        _bl = bl;
    }
    public void Start()
    {
        bool exit = false;
        while(!exit)
        {
            Console.WriteLine("Please make a selection of what you would like to do today.");
            Console.WriteLine("[1] Add new product");
            Console.WriteLine("[2] Update existing product");
            Console.WriteLine("[x] Go back to Main Menu", Console.ForegroundColor = ConsoleColor.Red);
            
            Console.ForegroundColor = ConsoleColor.White;
            string? input = Console.ReadLine();

            switch(input)
            {
                case "1":
                    Console.WriteLine("New product");
                break;

                case "2":
                    Console.WriteLine("Existing product");
                break;

                case "x":
                exit = true;

                // FileRepo repo = new FileRepo();
                // CRBL bl = new CRBL(repo);
                // // instantiate MainMenu
                // MainMenu menu = new MainMenu(bl);
                // // then call the Start method
                // menu.Start();
                
                break;

                default:
                Console.WriteLine("Sorry about that but I don't understand");
                break;
            }

        }
    }

}