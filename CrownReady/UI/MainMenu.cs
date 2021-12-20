using Models;
// using DL;
using BL;

namespace UI;

using System.Collections.Generic; //this is temp storage

// create a public class called 'MainMenu'
public class MainMenu {

    private CRBL _bl;

    public MainMenu()
    {
        _bl = new CRBL();
    }



    // create method inside class to hold code from Program.cs file
    public void Start() {

        Console.Out.NewLine = "\r\n\r\n"; //For more info check out link: https://www.sitereq.com/post/6-ways-to-insert-new-line-in-c-and-aspnet
        Console.ForegroundColor = ConsoleColor.Cyan;
        bool exit = false;

        // Testing for various Storefront locations:
        StoreFront locationOne = new StoreFront();
        locationOne.name = "CrownReady - Pearland";
        locationOne.address = "random address";

        StoreFront locationTwo = new StoreFront();
        locationTwo.name = "CrownReady - Sugar Land";
        locationTwo.address = "random address";

        StoreFront locationThree = new StoreFront();
        locationThree.name = "CrownReady - Houston";
        locationThree.address = "random address";

        List<StoreFront> allLocations = new List<StoreFront>();
        allLocations.Add(locationOne);
        allLocations.Add(locationTwo);
        allLocations.Add(locationThree);
        
        // the function below is for greeting the user and asking them to either
        // login or sign up
        User menu = new User();
        menu.Greeting();

        do
        {

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("So what would you like to do today?");
            Console.WriteLine("[1] Find locations");
            Console.WriteLine("[2] View products");
            Console.WriteLine("[3] View cart");
            Console.WriteLine("[x] Logout"); //Optional: have text be shown in red
            // Things to consider:
            // 1. If you choose to view products, 
            // 1. If you choose to find locations, the user can set location as store
            string input = Console.ReadLine();

            switch(input)
            {
                case "1":
                    Console.WriteLine("All locations");

                    // code below for displaying each StoreFront location
                    foreach(StoreFront storeFrontDetail in allLocations)
                    // foreach({c# filename} {empty constructor } in {list name})
                    {
                        Console.WriteLine(storeFrontDetail.DisplayStoreFront());
                    }

                break;
                case "2":
                    Console.WriteLine("View products");
                break;
                case "3":
                    Console.WriteLine("View cart");
                break;
                case "x":
                    Console.WriteLine("Goodbye!");
                    exit = true;
                break;
                default:
                    Console.WriteLine("Sorry about that but I don't understand");
                break;
            }
        } while(!exit);

    }

}