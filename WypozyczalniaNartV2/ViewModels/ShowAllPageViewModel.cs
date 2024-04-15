using System.Collections.ObjectModel;
using System.Data.SQLite;
using System;
namespace WypozyczalniaNartV2.ViewModels;

public class ShowAllPageViewModel : ViewModelBase
{
    public ObservableCollection<SkiModel> Skiss { get; } = new ObservableCollection<SkiModel>();
    public ObservableCollection<UserModel> Userr { get; } = new ObservableCollection<UserModel>();

    public ShowAllPageViewModel()

    {
        using (var connection = new SQLiteConnection("Data Source=NartyWypo.db"))
        {
            connection.Open();
            string query = "SELECT * FROM Skis";
            using (var command = new SQLiteCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["Id_Skis"]);
                        string? company = Convert.ToString(reader["Company"]);
                        string? model = Convert.ToString(reader["Model"]);
                        int length = Convert.ToInt32(reader["Lenght"]);
                        int width = Convert.ToInt32(reader["Width"]);
                        int pricePerDay = Convert.ToInt32(reader["PricePerDay"]);

                        Skiss.Add(new SkiModel(id, company, model, length, width, pricePerDay));
                    }
                }
            }
            string query1 = "SELECT * FROM User";
                using (var command = new SQLiteCommand(query1, connection))
                {
                    using (var reader1 = command.ExecuteReader())
                    {
                        while (reader1.Read())
                        {
                            int id1 = Convert.ToInt32(reader1["User_Id"]);
                            string? name = Convert.ToString(reader1["Name"]);
                            string? surname = Convert.ToString(reader1["Surname"]);
                            string? pe = Convert.ToString(reader1["PESEL"]);
                            string? city = Convert.ToString(reader1["City"]);
                            string? street = Convert.ToString(reader1["Street"]);
                            int zipcode = Convert.ToInt32(reader1["ZipCode"]);

                            Userr.Add(new UserModel(id1, name, surname, pe, city, street, zipcode));
                        }
                    }
                }
                connection.Close();
        }
    }
}



