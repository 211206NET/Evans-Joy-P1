using Models;
using BL;

namespace UI;

public class AdminMenu
{
    private CRBL _bl;

    public AdminMenu()
    {
        _bl = new CRBL();
    }
    public void Start()
    {
        bool exit = false;
        while(!exit)
        {
            Console.WriteLine("Welcome to the Admin Menu.");
            Console.WriteLine("Please make a selection of what you would like to do today.");
            Console.WriteLine("[1] View all locations");
            Console.WriteLine("[2] Add new locations");
            Console.WriteLine("[3] Check inventory");
            Console.WriteLine("[x] Go back to Main Menu");

            string? input = Console.ReadLine();

            switch(input)
            {
                case "1":
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

                case "2":
                    Console.WriteLine("Name:");
                        string? Name = Console.ReadLine();
                        Console.WriteLine("Address:");
                        string? Address = Console.ReadLine();
                        Console.WriteLine("City:");
                        string? City = Console.ReadLine();
                        Console.WriteLine("State:");
                        string? State = Console.ReadLine();

                        StoreFront newStoreFront = new StoreFront();
                        newStoreFront.SetName(Name);
                        newStoreFront.SetAddress(Address);
                        newStoreFront.SetCity(City);
                        newStoreFront.SetState(State);

                        _bl.AddStoreFront(newStoreFront);

                        Console.WriteLine($"You successfully added a new location: {newStoreFront.GetName()}.");
                    // create an option to return to the main menu
                break;

                case "3":
                Console.WriteLine("Inventory");
                break;

                case "x":
                exit = true;
                break;

                default:
                Console.WriteLine("???");
                break;
            }

        }


    }
}