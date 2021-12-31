namespace UI;

public class CustomerMenu
{
    private CRBL _bl;

    public CustomerMenu()
    {
        _bl = new CRBL();
    }
    public void Start()
    {
        bool exit = false;
        while(!exit)
        {
            Console.WriteLine("Welcome to [Selected StoreFront]!");
            Console.WriteLine("Please make a selection of what you would like to do today.");
            Console.WriteLine("[1] View Products");
            Console.WriteLine("[2] View cart");
            Console.WriteLine("[3] View Order");
            Console.WriteLine("[x] Go back to Main Menu");

            string? input = Console.ReadLine(); 

            switch(input)
            {
                case "1":
                Console.WriteLine("Products");
                break;

                case "2":
                Console.WriteLine("Cart");
                break;

                case "3":
                Console.WriteLine("View orders");
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