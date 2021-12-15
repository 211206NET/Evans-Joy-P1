﻿using StoreFront;

Console.Out.NewLine = "\r\n\r\n"; //For more info check out link: https://www.sitereq.com/post/6-ways-to-insert-new-line-in-c-and-aspnet

bool exit = false;

    // Optional: Strongly considering having 'readline' be a standout color from 'writeline'
    Console.WriteLine("Hello, Welcome to CrownReady Beauty Supply!");
    Console.WriteLine("The place where you find ... no matter your skin type of hair texture");
    Console.WriteLine("Let's get started! Login or Create an account");
    // If user input == Login, ask for user.email
    // If user input == Create an account, ask for user.name and user.email
    // else, ask user to "Try again" and loop back to main menu

    // Once the user successfully either creates an account or login, 
    // they'll proceed to the main menu
do
{
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

            StoreFrontDetail locationOne = new StoreFrontDetail();
            locationOne.name = "CrownReady - Pearland";
            locationOne.address = "random address";

            StoreFrontDetail locationTwo = new StoreFrontDetail();
            locationTwo.name = "CrownReady - Sugar Land";
            locationTwo.address = "random address";

            StoreFrontDetail locationThree = new StoreFrontDetail();
            locationThree.name = "CrownReady - Houston";
            locationThree.address = "random address";

            Console.WriteLine(locationOne.DisplayStoreFront());
            Console.WriteLine(locationTwo.DisplayStoreFront());
            Console.WriteLine(locationThree.DisplayStoreFront());
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
// }
