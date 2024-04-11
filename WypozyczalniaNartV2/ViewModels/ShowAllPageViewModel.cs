using System.Collections.ObjectModel;
using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WypozyczalniaNartV2.ViewModels;

public class ShowAllPageViewModel : ViewModelBase
{
    public ObservableCollection<SkiModel> Skiss { get; } = new ObservableCollection<SkiModel>();

    public ShowAllPageViewModel()

    {
        // Łączenie z bazą danych SQLite
        using (var connection = new SQLiteConnection("Data Source=NartyWypo.db"))
        {
            connection.Open();

            // Zapytanie SQL do pobrania danych z tabeli Skis
            string query = "SELECT * FROM Skis";

            using (var command = new SQLiteCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    // Iteracja przez wyniki zapytania i dodanie ich do listy Skiss
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["Id_Skis"]);
                        string name = Convert.ToString(reader["Company"]);
                        string brand = Convert.ToString(reader["Model"]);
                        int length = Convert.ToInt32(reader["Lenght"]);
                        int width = Convert.ToInt32(reader["Width"]);
                        int pricePerDay = Convert.ToInt32(reader["PricePerDay"]);

                        Skiss.Add(new SkiModel(id, name, brand, length, width, pricePerDay));
                    }
                }
            }
            connection.Close();




            // var skis = new List<SkiModel>
            // {
            //    new SkiModel(1,"imie","ocs",15,15,15),


            // };
            //Skiss = new ObservableCollection<SkiModel>(skis);

        }
    }
}



