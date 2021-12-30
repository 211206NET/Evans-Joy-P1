using Models;
using BL;

namespace UI;

public class StoreFrontMenu
{
    private CRBL _bl;
    public StoreFrontMenu()
    {
        _bl = new CRBL();
    }
    public void Start()
    {
        bool exit = false;
        while(!exit)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("So what would you like to do today?");
            Console.WriteLine("[1] Admin Menu");
            Console.WriteLine("[2] Shop locations");
            Console.WriteLine("[x] Logout", Console.ForegroundColor = ConsoleColor.Red); //Optional: have text be shown in red

            Console.ForegroundColor = ConsoleColor.White;
            string? input = Console.ReadLine();

            switch(input)
            {
                case "1":
                new AdminMenu().Start();
                break;    

                case "2":
                new CustomerMenu().Start();
                    List<StoreFront> allStoreFronts = _bl.GetAllStores();
                    Console.WriteLine("Select a location:");

                    if (allStoreFronts.Count > 0)
                    {

                    for(int i = 0; i < allStoreFronts.Count; i++)
                    {
                        Console.WriteLine($" [{i}] name: {allStoreFronts[i].GetName()}: {allStoreFronts[i].GetAddress()}, {allStoreFronts[i].GetCity()}, {allStoreFronts[i].GetState()}");
                    }
                    int selection = Int32.Parse(Console.ReadLine());
                    StoreFront selectStoreFront = allStoreFronts[selection];

                    Console.WriteLine($"Welcome to {selectStoreFront.GetName()}");
                    Console.WriteLine("What would you like to do today?");

                    }
                    else
                    {
                        Console.WriteLine("There are no stores available :(");
                    }

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
}