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

            string sql = "SELECT ID, Name, Surname, PESEL,City, Street, ZipCode FROM User";
            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int ID = reader.GetInt32(0);
                        string Name = reader.GetString(1);
                        string Surname = reader.GetString(2);
                        string PESEL = reader.GetString(3);
                        string City = reader.GetString(4);
                        string Street = reader.GetString(5);
                        int ZipCode = reader.GetInt32(6);
                        
                        
                        

                        Console.WriteLine($"ID: {ID}, Name: {Name}, Surname: {Surname}, PESEL: {PESEL}, City: {City}, Street: {Street}, ZipCode: {ZipCode}");
                    }
                }
            }
        }
    }

    public static void AddUserToSqLite()
    {
        
    }
}