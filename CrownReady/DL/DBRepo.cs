using Microsoft.Data.SqlClient;
using System.Data;

namespace DL;

public class DBRepo : IRepo
{
    private string _connectionString;
    // public DBRepo(string connectionString) {
    //     _connectionString = connectionString;
    // }

    public DBRepo(string connectionString)
    {
        // _connectionString = connectionString;
        _connectionString = connectionString;
        // _connectionString = File.ReadAllText("connectionString.txt");
    }
    public void AddToInventory(int storeFrontID, int productID, Inventory inventoryToAdd)
    {
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string insertCmd = $"INSERT INTO Inventory (StorefrontId, ProductId, Quantity, Markup) VALUES (@storefrontID, @productID, @quantity, @markup)";

            using(SqlCommand cmd = new SqlCommand(insertCmd, connection))
            {
                SqlParameter param = new SqlParameter("@storefrontID", storeFrontID);
                cmd.Parameters.Add(param);
                
                param = new SqlParameter("@productID", productID);
                cmd.Parameters.Add(param);
                
                param = new SqlParameter("@quantity", inventoryToAdd.Quantity);
                cmd.Parameters.Add(param);
                
                param = new SqlParameter("@markup", inventoryToAdd.Markup);
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public void AddLineitem(int inventoryID, int orderID, LineItem lineitemToAdd)
    {
        throw new NotImplementedException();
    }

    public void AddOrder(int userID, int storeID, Order orderToAdd)
    {
        throw new NotImplementedException();
    }

    public void AddProduct(Product productToAdd)
    {
        string selectCmd = "SELECT * FROM Product WHERE ID = -1";

        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            using(SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd, connection))
            {
                DataSet productSet = new DataSet();
                dataAdapter.Fill(productSet, "Product");

                DataTable productTable = productSet.Tables["Product"];

                DataRow newRow = productTable.NewRow();

                newRow["Name"] = productToAdd.Name; 
                newRow["Description"] = productToAdd.Description ?? "";
                newRow["Price"] = productToAdd.Price;

                productTable.Rows.Add(newRow);

                string insertCmd = $"INSERT INTO Product (Name, Description, Price) VALUES ('{productToAdd.Name}', '{productToAdd.Description}', '{productToAdd.Price}')";

                SqlCommandBuilder cmdBuilder= new SqlCommandBuilder(dataAdapter);

                dataAdapter.InsertCommand = cmdBuilder.GetInsertCommand();
                
                dataAdapter.Update(productTable);
            }
        }
    }

    public void AddStoreFront(StoreFront storeFrontToAdd)
    {
        string selectCmd = "SELECT * FROM Storefront WHERE ID = -1";

        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            using(SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd, connection))
            {
                DataSet storeSet = new DataSet();
                dataAdapter.Fill(storeSet, "Storefront");

                DataTable storeTable = storeSet.Tables["Storefront"];

                DataRow newRow = storeTable.NewRow();

                newRow["Name"] = storeFrontToAdd.Name; 
                newRow["Address"] = storeFrontToAdd.Address ?? "";
                newRow["City"] = storeFrontToAdd.City ?? "";
                newRow["State"] = storeFrontToAdd.State ?? "";

                storeTable.Rows.Add(newRow);

                string insertCmd = $"INSERT INTO Storefront (Name, Address, City, State) VALUES ('{storeFrontToAdd.Name}', '{storeFrontToAdd.Address}', '{storeFrontToAdd.City}', '{storeFrontToAdd.State}')";

                SqlCommandBuilder cmdBuilder= new SqlCommandBuilder(dataAdapter);

                dataAdapter.InsertCommand = cmdBuilder.GetInsertCommand();
                
                dataAdapter.Update(storeTable);
            }
        }
    }

    public void AddUser(User userToAdd)
    {
    string selectCmd = "SELECT * FROM [User] WHERE ID = -1";

        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            using(SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd, connection))
            {
                DataSet userSet = new DataSet();
                dataAdapter.Fill(userSet, "User");

                DataTable userTable = userSet.Tables["User"];

                DataRow newRow = userTable.NewRow();

                newRow["Name"] = userToAdd.Name; 
                newRow["Email"] = userToAdd.Email;
                newRow["IsEmployee"] = userToAdd.IsEmployee;

                userTable.Rows.Add(newRow);

                string insertCmd = $"INSERT INTO User (Name, Email) VALUES ('{userToAdd.Name}', '{userToAdd.Email}')";

                SqlCommandBuilder cmdBuilder= new SqlCommandBuilder(dataAdapter);

                dataAdapter.InsertCommand = cmdBuilder.GetInsertCommand();
                
                dataAdapter.Update(userTable);
            }
        }    
    }
    public List<Product> GetAllProducts()
    {
        List<Product> allProducts = new List<Product>();

        using SqlConnection connection = new SqlConnection(_connectionString);

        {
            connection.Open();

            string queryTxt = "SELECT * FROM Product";
            using(SqlCommand cmd = new SqlCommand(queryTxt, connection))
            {
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                            Product products = new Product();
                            products.ID = reader.GetInt32(0);
                            // Console.WriteLine(reader.GetInt32(0));

                            products.Name = reader.GetString(1);
                            // Console.WriteLine(reader.GetString(1));
                            
                            products.Description = reader.GetString(2);
                            // Console.WriteLine(reader.GetString(2));
                            
                            products.Price = reader.GetDecimal(3);
                            // Console.WriteLine(reader.GetString(3));

                            allProducts.Add(products);
                    }
                }
            }
            connection.Close();
        }
        return allProducts;
    }

    public List<StoreFront> GetAllStoreFronts()
    {
        List<StoreFront> allStoreFronts = new List<StoreFront>();

        // using(SqlConnection connection = new SqlConnection(_connectionString))
        using SqlConnection connection = new SqlConnection(_connectionString);

        {
            connection.Open();

            string queryTxt = "SELECT * FROM Storefront";
            using(SqlCommand cmd = new SqlCommand(queryTxt, connection))
            {
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                            StoreFront storeFront = new StoreFront();
                            storeFront.ID = reader.GetInt32(0);
                            // Console.WriteLine(reader.GetInt32(0));

                            storeFront.Name = reader.GetString(1);
                            // Console.WriteLine(reader.GetString(1));
                            
                            storeFront.Address = reader.GetString(2);
                            // Console.WriteLine(reader.GetString(2));
                            
                            storeFront.City = reader.GetString(3);
                            // Console.WriteLine(reader.GetString(3));
                            
                            storeFront.State = reader.GetString(4);
                            // Console.WriteLine(reader.GetString(4));

                            allStoreFronts.Add(storeFront);
                    }
                }
            }
            connection.Close();
        }
        return allStoreFronts;
    }

    public List<User> GetAllUsers()
    {
        List<User> allUsers = new List<User>();
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            string queryTxt = "SELECT * FROM [User]";
            using(SqlCommand cmd = new SqlCommand(queryTxt, connection))
            {
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                            User user = new User();
                            user.ID = reader.GetInt32(0);
                            // Console.WriteLine(reader.GetInt32(0));

                            user.Name = reader.GetString(1);
                            // Console.WriteLine(reader.GetString(1));
                            
                            user.Email = reader.GetString(2);
                            // Console.WriteLine(reader.GetString(2));

                            user.IsEmployee = reader.GetBoolean(3);

                            allUsers.Add(user);
                    }
                }
            }
            connection.Close();
        }
        return allUsers;
    }

    public StoreFront GetStoreFrontById(int storeFrontId)
    {
        string query = "Select * From Storefront Where ID = @storefrontID";
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        using SqlCommand cmd = new SqlCommand(query, connection);
        SqlParameter param = new SqlParameter("@storefrontID", storeFrontId);
        cmd.Parameters.Add(param);

        using SqlDataReader reader = cmd.ExecuteReader();
        StoreFront storeFront = new StoreFront();
        if (reader.Read())
        {
            storeFront.ID = reader.GetInt32(0);
            storeFront.Name = reader.GetString(1);
            storeFront.Address = reader.GetString(2);
            storeFront.City = reader.GetString(3);
            storeFront.State = reader.GetString(4);
        }
        connection.Close ();
        return storeFront;
    }
    public void CurrentUser(User currentUser)
    {
        // Console.WriteLine(currentUser.Name);
        // Console.WriteLine($"Welcome back {currentUser.Name}! You've successfully logged in!");
    }

    public bool LogIn(string email)
    {
        List<User> getUsers = GetAllUsers();

        foreach (User user in getUsers) 
            {
                if (user.Email == email && user.IsEmployee.Equals(false))
                {
                    CurrentUser(user); // get currect user info
                    Console.WriteLine($"Welcome back {user.Name}! You've successfully logged in!");
                    return true;
                }
                else if (user.Email == email && user.IsEmployee.Equals(true))
                {
                    CurrentUser(user); // get currect user info
                    Console.WriteLine("Access Granted");
                    Console.WriteLine($"Welcome back {user.Name}! You've successfully logged in!");
                    return true;
                }
            }
        return false;
    }

    public void SignUp(string name, string email)
    {
        Console.WriteLine(name);
        Console.WriteLine(email);

        User newUser = new User 
        {
            Name = name ?? "",
            Email = email ?? "",
            IsEmployee = false
        };

        AddUser(newUser);

        Console.WriteLine($"Congrats {newUser.Name}! You successfully signed up!");
    }
}