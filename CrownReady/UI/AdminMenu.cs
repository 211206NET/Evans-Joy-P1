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
            Console.WriteLine("[4] Add product to inventory");
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
                    addProductToInventory();
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
    private void addProductToInventory()
    {
        // select the storefront
        List<StoreFront> getAllStoreFronts = _bl.GetAllStoreFronts();
        Console.WriteLine("Select a location to add inventory:");
        if (getAllStoreFronts.Count > 0)
        {
            for(int i = 0; i < getAllStoreFronts.Count; i++)
            {
                Console.WriteLine($" [{getAllStoreFronts[i].ID}] {getAllStoreFronts[i].DisplayStoreFront()}");
            }
            int storeSelection = Int32.Parse(Console.ReadLine()?? "");
            // grab the storefront id
            StoreFront selectStoreFront = getAllStoreFronts[storeSelection];
        
            // next select product
            List<Product> getAllProducts = _bl.GetAllProducts();
            Console.WriteLine($"Next add new product to the inventory at {selectStoreFront.Name}.");
            if (getAllProducts.Count > 0)
            {
                for(int i = 0; i < getAllProducts.Count; i++)
                {
                    Console.WriteLine($" [{i}] {getAllProducts[i].Name}");
                }
                int productSelection = Int32.Parse(Console.ReadLine()?? "");
                // grab the product id
                Product selectProduct = getAllProducts[productSelection];

                Console.WriteLine($"Please add quantity and markup with {selectProduct.Name}.");
                Console.WriteLine("Quantity:");
                int quantity = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Markup:");
                decimal markup = decimal.Parse(Console.ReadLine());

                Inventory newInventory = new Inventory();
                newInventory.Quantity = quantity;
                newInventory.Markup = markup;
                
                _bl.AddToInventory(storeSelection, productSelection, newInventory);
                Console.WriteLine($"Congrats! You successfully added {selectProduct.Name} at {selectStoreFront.Name}.");
            }
        }
        else
        {
            Console.WriteLine("There are no stores available :(");
        }
    }
}