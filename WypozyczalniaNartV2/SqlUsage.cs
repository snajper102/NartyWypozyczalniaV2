using System;
using System.Data.SQLite;

namespace WypozyczalniaNartV2;

public class SqlUsage
{
    public static void DisplayDataFromSQLite()
    {
        string connectionString = "Data Source=NartyWypo.db;Version=3;";

        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            string sql = "SELECT User_Id, Name, Surname, PESEL,City, Street, ZipCode FROM User";
            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int User_Id = reader.GetInt32(0);
                        string Name = reader.GetString(1);
                        string Surname = reader.GetString(2);
                        string PESEL = reader.GetString(3);
                        string City = reader.GetString(4);
                        string Street = reader.GetString(5);
                        int ZipCode = reader.GetInt32(6);
                        
                        
                        

                        
                    }
                }
            }
            connection.Close();
        }
    }

    
    
    public static void AddUserToDatabase(string name, string surname, string pesel, string city, string street, int zipCode)
    {
        // Łączymy się z bazą danych SQLite
        string connectionString = "Data Source=NartyWypo.db;Version=3;";
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            // Wstawiamy dane do tabeli
            string insertQuery = "INSERT INTO User (Name, Surname, PESEL, City, Street, ZipCode) VALUES (@Name, @Surname, @PESEL, @City, @Street, @ZipCode)";
            using (SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection))
            {
                insertCommand.Parameters.AddWithValue("@Name", name);
                insertCommand.Parameters.AddWithValue("@Surname", surname);
                insertCommand.Parameters.AddWithValue("@PESEL", pesel);
                insertCommand.Parameters.AddWithValue("@City", city);
                insertCommand.Parameters.AddWithValue("@Street", street);
                insertCommand.Parameters.AddWithValue("@ZipCode", zipCode);

                insertCommand.ExecuteNonQuery();
            }
            Console.WriteLine(insertQuery);
            connection.Close();
        }
    }
    public static void AddSkisToDatabase(string company, string model, int lenght,int width, int pricePerDay)
    {
        string connectionString = "Data Source=NartyWypo.db;Version=3;";
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string insertQuery = "INSERT INTO Skis (Company, Model, Lenght, Width, PricePerDay) VALUES (@Company, @Model, @Lenght, @Width, @PricePerDay)";
            using (SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection))
            {
                insertCommand.Parameters.AddWithValue("@Company", company);
                insertCommand.Parameters.AddWithValue("@Model", model);
                insertCommand.Parameters.AddWithValue("@Lenght", lenght);
                insertCommand.Parameters.AddWithValue("@Width", width);
                insertCommand.Parameters.AddWithValue("@PricePerDay", pricePerDay);
         

                insertCommand.ExecuteNonQuery();
            }
            Console.WriteLine(insertQuery);
            connection.Close();
        }
    }
}