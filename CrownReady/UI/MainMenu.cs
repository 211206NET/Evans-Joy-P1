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
        IRepo repo = new DBRepo();

        IBL bl = new CRBL(repo);

        Console.Out.NewLine = "\r\n\r\n"; //For more info check out link: https://www.sitereq.com/post/6-ways-to-insert-new-line-in-c-and-aspnet
        Console.ForegroundColor = ConsoleColor.Cyan;

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
                List<User> getUsers = bl.GetAllUsers();

                Console.WriteLine("Email:");
                string? input = Console.ReadLine();
                
                foreach (User user in getUsers)
                {
                    if (user.Email == input)
                        {
                            Console.WriteLine($"Welcome back {user.Name}! You've successfully logged in!");
                            new StoreFrontMenu(bl).Start();
                        }
                    else
                        {
                            Console.WriteLine("Try Again.");
                        }
                
                }
                break;

                case "2":
                
                Console.WriteLine("Name:");
                string? name = Console.ReadLine();
                Console.WriteLine("Email:");
                string? email = Console.ReadLine(); 
                User newUser = new User {
                    Name = name ?? "",
                    Email = email ?? ""
                };

                bl.AddUser(newUser);

                // List<User> getAllUsers = bl.GetAllUsers();
                // also make sure the user's account don't already exist

                // getAllUsers.Add(newUser);
                // allUsers.Add(newUser);
                Console.WriteLine($"Congrats {newUser.Name}! You successfully signed up!");
                // Console.WriteLine($"Congrats {name}! You successfully signed up!");
                new StoreFrontMenu(bl).Start();

                break;

                // case 2 works!!!

                case "3":
                close = true;
                Console.WriteLine("Access Granted");
                new AdminMenu(bl).Start();
                // new AdminMenu(_bl).Start(); //this renders written file.
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