using DL;

namespace UI;

using System.Collections.Generic; //this is temp storage for models: User, Storefront

// create a public class called 'MainMenu'
public class MainMenu : IMenu {

    private IBL _bl;

    public MainMenu(IBL bl)
    {
        _bl = bl;
    }



    // create method inside class to hold code from Program.cs file
    public void Start() {

        Console.Out.NewLine = "\r\n\r\n"; //For more info check out link: https://www.sitereq.com/post/6-ways-to-insert-new-line-in-c-and-aspnet
        Console.ForegroundColor = ConsoleColor.Cyan;
        bool exit = false;

        // Testing for various users:
        User userOne = new User();
        userOne.Name = "Joy";
        userOne.Email = "joy@email.com";
        User userTwo = new User();
        userTwo.Name = "Test";
        userTwo.Email = "test@email.com";

        List<User> allUsers = new List<User>();
        allUsers.Add(userOne);
        allUsers.Add(userTwo);

        bool close = false;

        do
        {

        // Optional: Strongly considering having 'readline' be a standout color from 'writeline'
        Console.WriteLine("Hello, Welcome to CrownReady Beauty Supply!");
        Console.WriteLine("The place where you find ... no matter your skin type or hair texture");
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
                
                foreach (User user in allUsers)
                {
                    if (user.Email.Contains(input))
                        {
                            Console.WriteLine($"Welcome back {user.Name}! You've successfully logged in!");
                            new StoreFrontMenu().Start();
                        }
                    else
                        {
                            Console.WriteLine("Try Again.");
                        }
                
                }
                break;

                //case 1 works!!!

                case "2":
                Console.WriteLine("Name:");
                string? name = Console.ReadLine();
                Console.WriteLine("Email:");
                string? email = Console.ReadLine(); 
                User newUser = new User {
                    Name = name,
                    Email = email
                };

                // also make sure the user's account don't already exist

                allUsers.Add(newUser);
                Console.WriteLine($"Congrats {name}! You successfully signed up!");
                new StoreFrontMenu().Start();
                break;

                // case 2 works!!!

                case "3":
                close = true;
                Console.WriteLine("Access Granted");
                new AdminMenu().Start();
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