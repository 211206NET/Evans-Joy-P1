using DL;

namespace UI;

public class AdminMenu : IMenu
{
    private CRBL _bl;

    public AdminMenu()
    {
        _bl = new CRBL(new FileRepo());
        // _bl = new CRBL();
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
                    viewAllStoreFronts();
                break;

                case "2":
                    addNewStoreFront();
                break;

                case "3":
                Console.WriteLine("Inventory");
                break;

                case "x":
                exit = true;

                FileRepo repo = new FileRepo();
                CRBL bl = new CRBL(repo);
                // instantiate MainMenu
                MainMenu menu = new MainMenu(bl);
                // then call the Start method
                menu.Start();
                
                break;

                default:
                Console.WriteLine("Sorry about that but I don't understand");
                break;
            }

        }


    }
    private void viewAllStoreFronts(){
            List<StoreFront> getAllStoreFronts = _bl.GetAllStoreFronts();
                        Console.WriteLine("Select a location:");

                        if (getAllStoreFronts.Count > 0)
                        {
                        //     foreach(StoreFront locations in getAllStoreFronts)
                        //     {
                        //         Console.WriteLine(locations);
                        //     }

                        for(int i = 0; i < getAllStoreFronts.Count; i++)
                        {
                            Console.WriteLine($" [{i}] {getAllStoreFronts[i].DisplayStoreFront()}");
                        }
                        int selection = Int32.Parse(Console.ReadLine());
                        StoreFront selectStoreFront = getAllStoreFronts[selection];

                        Console.WriteLine($"Welcome to {selectStoreFront.Name}");
                        Console.WriteLine("What would you like to do today?");

                        }
                        else
                        {
                            Console.WriteLine("There are no stores available :(");
                        }
        }

    private void addNewStoreFront(){
        Console.WriteLine("Name:");
                        string? Name = Console.ReadLine();
                        Console.WriteLine("Address:");
                        string? Address = Console.ReadLine();
                        Console.WriteLine("City:");
                        string? City = Console.ReadLine();
                        Console.WriteLine("State:");
                        string? State = Console.ReadLine();

                        StoreFront newStoreFront = new StoreFront();
                        newStoreFront.Name = Name;
                        newStoreFront.Address = Address;
                        newStoreFront.City = City;
                        newStoreFront.State = State;

                        _bl.AddStoreFront(newStoreFront);

                        Console.WriteLine($"You successfully added a new location: {newStoreFront.Name}.");
                    // create an option to return to the main menu
    }
}