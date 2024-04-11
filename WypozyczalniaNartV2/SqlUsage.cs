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
                        
                        
                        

                        Console.WriteLine($"ID: {User_Id}, Name: {Name}, Surname: {Surname}, PESEL: {PESEL}, City: {City}, Street: {Street}, ZipCode: {ZipCode}");
                    }
                }
            }
        }
    }

    
    
    public static void AddRecordToDatabase(string name, string surname, string pesel, string city, string street, int zipCode)
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
}