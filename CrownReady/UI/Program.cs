// using StoreFront;
// changing to 'using Models' to make things consistant
// using Models;

// after moving code to MainMenu.cs, add using keyword below
using UI;
using DL;

FileRepo repo = new FileRepo();
CRBL bl = new CRBL(repo);
// instantiate MainMenu
MainMenu menu = new MainMenu(bl);
// then call the Start method
menu.Start();