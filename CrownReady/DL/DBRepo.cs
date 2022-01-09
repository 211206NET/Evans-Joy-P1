using Microsoft.Data.SqlClient;
using System.Data;

namespace DL;

public class DBRepo : IRepo
{
    private string _connectionString;
    // public DBRepo(string connectionString) {
    //     _connectionString = connectionString;
    // }

    public DBRepo()
    {
        // _connectionString = connectionString;
        _connectionString = File.ReadAllText("connectionString.txt");
    }
    public void AddInventory(int storeFrontIndex, Inventory inventoryToAdd)
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    public List<StoreFront> GetAllStoreFronts()
    {
        List<StoreFront> allStoreFronts = new List<StoreFront>();

        using(SqlConnection connection = new SqlConnection(_connectionString))
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
                            Console.WriteLine(reader.GetInt32(0));

                            storeFront.Name = reader.GetString(1);
                            Console.WriteLine(reader.GetString(1));
                            
                            storeFront.Address = reader.GetString(2);
                            Console.WriteLine(reader.GetString(2));
                            
                            storeFront.City = reader.GetString(3);
                            Console.WriteLine(reader.GetString(3));
                            
                            storeFront.State = reader.GetString(4);
                            Console.WriteLine(reader.GetString(4));

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
        throw new NotImplementedException();
        // List<StoreFront> allStoreFronts = new List<StoreFront>();
        // using(SqlConnection connection = new SqlConnection(_connectionString))
        // {
        //     connection.Open();

        //     string queryTxt = "SELECT * FROM Storefront";
        //     using(SqlCommand cmd = new SqlCommand(queryTxt, connection))
        //     {
        //         using(SqlDataReader reader = cmd.ExecuteReader())
        //         {
        //             while(reader.Read())
        //             {
        //                     StoreFront storeFront = new StoreFront();
        //                     storeFront.ID = reader.GetInt32(0);
        //                     // Console.WriteLine(reader.GetInt32(0));

        //                     storeFront.Name = reader.GetString(1);
        //                     // Console.WriteLine(reader.GetString(1));
                            
        //                     storeFront.Address = reader.GetString(2);
        //                     // Console.WriteLine(reader.GetString(2));
                            
        //                     storeFront.City = reader.GetString(3);
        //                     // Console.WriteLine(reader.GetString(3));
                            
        //                     storeFront.State = reader.GetString(4);
        //                     // Console.WriteLine(reader.GetString(4));

        //                     allStoreFronts.Add(storeFront);
        //             }
        //         }
        //     }
        //     connection.Close();
        // }
        // return allStoreFronts;
    }
}