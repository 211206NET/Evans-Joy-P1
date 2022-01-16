using DL;

namespace UI;

using System.Collections.Generic; //this is temp storage for models: User

public class MainMenu : IMenu {

    private IBL _bl;

    public MainMenu(IBL bl)
    {
        _bl = bl;
    }

    public void Start() {

        string connectionString = File.ReadAllText("connectionString.txt");
        IRepo repo = new DBRepo(connectionString);

        IBL bl = new CRBL(repo);

        Console.Out.NewLine = "\r\n\r\n"; //For more info check out link: https://www.sitereq.com/post/6-ways-to-insert-new-line-in-c-and-aspnet
        Console.ForegroundColor = ConsoleColor.Cyan;

        bool close = false;

        do
        {

        // Optional: Strongly considering having 'readline' be a standout color from 'writeline'
        Console.WriteLine("Hello, Welcome to CrownReady Beauty Supply!");
        Console.WriteLine("The place where you find the right product no matter your skin type or hair texture!");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Let's get started!");
        Console.WriteLine("[1] Login");
        Console.WriteLine("[2] Create Account");
        Console.WriteLine("[3] Admin Access");
        Console.WriteLine("[x] Exit", Console.ForegroundColor = ConsoleColor.Red);
        
        Console.ForegroundColor = ConsoleColor.White;
        string? response = Console.ReadLine();

        switch(response)
            {
                case "1":
                Console.WriteLine("Email:");
                string? input = Console.ReadLine();
                
                if(bl.LogIn(input) == true)
                {
                    new StoreFrontMenu(bl).Start();
                }
                else
                {
                    Console.WriteLine("Try Again.");
                }
                break;

                case "2":
                
                Console.WriteLine("Name:");
                string? name = Console.ReadLine();
                Console.WriteLine("Email:");
                string? email = Console.ReadLine(); 

                bl.SignUp(name, email);

                new StoreFrontMenu(bl).Start();

                break;

                // case 2 works!!!

                case "3":

                List<User> getAdmin = bl.GetAllUsers();

                Console.WriteLine("Email:");
                string? input2 = Console.ReadLine();
                
                foreach (User user in getAdmin)
                {
                    if (user.Email == input2 && user.IsEmployee.Equals(true))
                        {
                            Console.WriteLine("Access Granted");
                            Console.WriteLine($"Welcome back {user.Name}! You've successfully logged in!");
                            new AdminMenu(bl).Start();
                        }
                    else //fix issue
                        {
                            Console.WriteLine("Try Again.");
                        }
                
                }
                break;

                // case 3 works!!!

                case "x":
                close = true;
                break;

                // case x works!!!

                default:
                Console.WriteLine("Sorry, Try again");
                break;

                //default works!!!
            }
            
        } while (!close);
    }
}