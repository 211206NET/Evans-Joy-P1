using CustomExceptions;
using DL;
namespace UI;

public class AdminMenu : IMenu
{
    private IBL _bl;
    public AdminMenu(IBL bl)
    {
        _bl = bl;
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
            Console.WriteLine("[3] Add new product");
            Console.WriteLine("[4] Check inventory");
            Console.WriteLine("[x] Go back to Main Menu", Console.ForegroundColor = ConsoleColor.Red);
            
            Console.ForegroundColor = ConsoleColor.White;
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
                    addNewProduct();
                break;

                case "4":
                    viewInventory();
                // Console.WriteLine("Inventory");
                // List<StoreFront> allStorefronts = _bl.GetAllStoreFronts();
                // Console.WriteLine("Select a location to add inventory.");
                // for(int i = 0; i < allStorefronts.Count; i++)
                // {
                //     Console.WriteLine($"[{i}] {allStorefronts[i].DisplayStoreFront()}");
                // }
                // string? response = Console.ReadLine();
                // int selection;

                // bool parseSuccess = Int32.TryParse(input, out selection);

                // if(parseSuccess && selection >= 0 && selection < allStorefronts.Count)
                // {
                //     //if the parse has been successful, then we know that the selection is integer and TryParse was able to convert the string to int successfully
                //     //And we're making sure that our integer is staying within the bounds of our List
                //     //now I want to collect information about the review
                //     createReview:
                //     Console.WriteLine("Give a rating: ");
                //     int rating;
                    
                //     bool success = Int32.TryParse(Console.ReadLine(), out rating);
                //     Console.WriteLine("Leave a Review: ");
                //     string note = Console.ReadLine() ?? "";

                //     try
                //     {
                //         Review newReview = new Review(rating, note);
                //         _bl.AddReview(allRestaurants[selection].Id, newReview);
                //         Console.WriteLine("Your review has been successfully added!");
                //     }
                //     catch(InputInvalidException ex)
                //     {
                //         Console.WriteLine(ex.Message);
                //         goto createReview;
                //     }
                // }
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
                    for(int i = 0; i < getAllStoreFronts.Count; i++)
                    {
                        Console.WriteLine($"{getAllStoreFronts[i].DisplayStoreFront()}");
                    }
                    // int selection = Int32.Parse(Console.ReadLine()?? "");
                    // StoreFront selectStoreFront = getAllStoreFronts[selection];

                    // Console.WriteLine($"Welcome to {selectStoreFront.Name}");
                    // Console.WriteLine("What would you like to do today?");
                }
                else
                {
                    Console.WriteLine("There are no stores available :(");
                }
        }

    private void addNewProduct(){
        createProduct:
        Console.WriteLine("Create new product:");
        Console.WriteLine("Name:");
        string? Name = Console.ReadLine();
        Console.WriteLine("Description:");
        string? Description = Console.ReadLine();
        Console.WriteLine("Price:");
        decimal Price = Decimal.Parse(Console.ReadLine()?? "");

        try
        {

        Product newProduct = new Product();
        newProduct.Name = Name ?? "";
        newProduct.Description = Description ?? "";
        newProduct.Price = Price;
        
        _bl.AddProduct(newProduct);

        Console.WriteLine($"You successfully added a new product: {newProduct.Name}.");
        // create an option to return to the main menu
        }
        catch(InputInvalidException ex)
        {
            Console.WriteLine(ex.Message);
            goto createProduct;
        }


    }
    private void addNewStoreFront(){
        createStoreFront:
        Console.WriteLine("Create new location:");
        Console.WriteLine("Name:");
        string? Name = Console.ReadLine();
        Console.WriteLine("Address:");
        string? Address = Console.ReadLine();
        Console.WriteLine("City:");
        string? City = Console.ReadLine();
        Console.WriteLine("State:");
        string? State = Console.ReadLine();

        try
        {

        StoreFront newStoreFront = new StoreFront();
        newStoreFront.Name = Name ?? "";
        newStoreFront.Address = Address ?? "";
        newStoreFront.City = City ?? "";
        newStoreFront.State = State ?? "";
        
        _bl.AddStoreFront(newStoreFront);

        Console.WriteLine($"You successfully added a new location: {newStoreFront.Name}.");
        // create an option to return to the main menu
        }
        catch(InputInvalidException ex)
        {
            Console.WriteLine(ex.Message);
            goto createStoreFront;
        }


    }
    private void viewInventory(){
            List<StoreFront> getAllStoreFronts = _bl.GetAllStoreFronts();
            Console.WriteLine("Select a location to add inventory:");
                if (getAllStoreFronts.Count > 0)
                {
                    for(int i = 0; i < getAllStoreFronts.Count; i++)
                    {
                        Console.WriteLine($" [{i}] {getAllStoreFronts[i].DisplayStoreFront()}");
                    }
                    int selection = Int32.Parse(Console.ReadLine()?? "");
                    StoreFront selectStoreFront = getAllStoreFronts[selection];

                    Console.WriteLine($"Welcome to {selectStoreFront.Name}");
                    new InventoryMenu(_bl).Start();
                }
                else
                {
                    Console.WriteLine("There are no stores available :(");
                }
        }
}