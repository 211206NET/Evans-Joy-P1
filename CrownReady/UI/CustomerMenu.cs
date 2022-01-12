using DL;

namespace UI;

public class CustomerMenu : IMenu
{
    private CRBL _bl;

    public CustomerMenu()
    {
        _bl = new CRBL(new FileRepo());
        // _bl = new CRBL();
    }
    public void Start()
    {
        bool exit = false;
        while(!exit)
        {
            Console.WriteLine("Please make a selection of what you would like to do today.");
            Console.WriteLine("[1] View Products");
            Console.WriteLine("[2] View cart");
            Console.WriteLine("[3] View Order");
            Console.WriteLine("[x] Go back to Main Menu", Console.ForegroundColor = ConsoleColor.Red);
            
            Console.ForegroundColor = ConsoleColor.White;
            string? input = Console.ReadLine(); 

            switch(input)
            {
                case "1":
                Console.WriteLine("Coming Soon: Products");
                break;

                case "2":
                Console.WriteLine("Coming Soon: Cart");
                break;

                case "3":
                Console.WriteLine("Coming Soon: View orders");
                break;

                case "x":
                exit = true;
                break;
                
                default:
                Console.WriteLine("Sorry about that but I don't understand");
                break;

            }
        }
    }
}