using DL;
namespace UI;

public class StoreFrontMenu
{
    private CRBL _bl;
    public StoreFrontMenu()
    {
        _bl = new CRBL(new FileRepo());
        // _bl = new CRBL();
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
                    selectStoreFront();
                break;

                case "2":
                    Console.WriteLine("View Previous Orders");
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
    private void selectStoreFront(){
        List<StoreFront> allStoreFronts = _bl.GetAllStoreFronts();
                    Console.WriteLine("Select a location:");

                    if (allStoreFronts.Count > 0)
                    {

                    for(int i = 0; i < allStoreFronts.Count; i++)
                    {
                        Console.WriteLine($" [{i}] Name: {allStoreFronts[i].Name}: {allStoreFronts[i].Address}, {allStoreFronts[i].City}, {allStoreFronts[i].State}");
                    }
                    int selection = Int32.Parse(Console.ReadLine());
                    StoreFront selectStoreFront = allStoreFronts[selection];

                    Console.WriteLine($"Welcome to {selectStoreFront.Name}");
                    
                    new CustomerMenu().Start();

                    }
                    else
                    {
                        Console.WriteLine("There are no stores available :(");
                    }
    }
}