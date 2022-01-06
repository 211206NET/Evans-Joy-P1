// using CustomExceptions;

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
        return "Login Method";
    }
    // public void LogIn(string name, string email){
    //     this.Name = name; 
    //     this.Email = name;
    // }
}