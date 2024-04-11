namespace WypozyczalniaNartV2;

public class SkiModel
{
    public int Id_Skis { get; set; }
    public string Company { get; set; }
    public string Model { get; set; }
    public int Length { get; set; }
    public int Width { get; set; }
    public int PricePerDay { get; set; }

    public SkiModel(int idSkis, string company)
    {
        Id_Skis = idSkis;
        Company = company;
    }
   public  SkiModel(int idSkis, string company, string model, int length, int width, int pricePerDay)
    {
        Id_Skis = idSkis;
        Company = company;
        Model = model;
        Length = length;
        Width = width;
        PricePerDay = pricePerDay;


    }

   
}