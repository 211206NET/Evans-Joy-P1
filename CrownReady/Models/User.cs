// using CustomExceptions;

namespace Models;

// create a new public class for users
public class User{
    //Empty Constructor
    public User() {}

    // setting automatic properties: name, email
    public int ID { get; set;}
    public string Name { get; set;}
    public string Email { get; set;}
    public bool IsEmployee { get; set;}
}