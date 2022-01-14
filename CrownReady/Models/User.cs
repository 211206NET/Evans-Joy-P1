using CustomExceptions;
using System.Text.RegularExpressions;

namespace Models;

// create a new public class for users
public class User{
    //Empty Constructor
    public User() {}

    // setting automatic properties: name, email
    public int ID { get; set;}
    // public string Name { get; set;}
    private string _name;

    public string Name {
        get => _name;
        set
        {
            Regex pattern = new Regex("^[a-zA-Z0-9 !?']+$");
            if(string.IsNullOrWhiteSpace(value))
            {
                //we're checking whether this string is null or whitespace
                throw new InputInvalidException("Name can't be empty");
            }
            //even if the string is not null or white space,
            //we can still check for the name's validity by using RegEx (Regular Expression)
            //Regular Expression is a way to pattern match a string for a certain condition
            //it has a confusing syntax, so I recommend looking up language specific RegEx reference page to build one
            else if(!pattern.IsMatch(value))
            {
                throw new InputInvalidException("User name can only have alphanumeric characters, white space, !, ?, and '.");
            }
            else
            {
                this._name = value;
            }
        }
    }
    public string Email { get; set;}
    public bool IsEmployee { get; set;}
}