namespace Models;

// create a new public class for users
public class User{
    //Empty Constructor
    public User() {}

    // setting automatic properties: name, email
    public string Name { get; set;}
    public string Email { get; set;}

    public string SignUp(string name, string email){
        this.Name = name; 
        this.Email = name;
        return "SignUp Method";
    }
    // public void SignUp(string name, string email){
    //     this.Name = name; 
    //     this.Email = name; 
    // }
    public string Login(string name, string email){
        this.Name = name; 
        this.Email = name;
        return "SignUp Method";
    }
    // public void LogIn(string name, string email){
    //     this.Name = name; 
    //     this.Email = name;
    // }

    public void Greeting() {

        bool exit = false;
        
        do
        {

        // Optional: Strongly considering having 'readline' be a standout color from 'writeline'
        Console.WriteLine("Hello, Welcome to CrownReady Beauty Supply!");
        Console.WriteLine("The place where you find ... no matter your skin type of hair texture");
        Console.WriteLine("Let's get started! Login or Create an account");

        string response = Console.ReadLine();

        switch(response)
            {
                // If user input == Login, ask for user.email
                case "L":
                Console.WriteLine("Login");
                break;

                // If user input == Create an account, ask for user.name and user.email
                case "S":
                Console.WriteLine("Signup");
                break;
                
                default:
                // else, ask user to "Try again" and loop back to main menu
                Console.WriteLine("Sorry, Try again");
                break;
            }
            
        } while (!exit);
        // Once the user successfully either creates an account or login, 
        // they'll proceed to the main menu
    }
}