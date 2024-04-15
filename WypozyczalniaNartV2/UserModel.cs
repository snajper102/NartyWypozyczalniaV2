namespace WypozyczalniaNartV2;

public class UserModel
{
    public  int Id_User { get; set; }
    public  string? Name { get; set; }
    public  string? Surname { get; set; }
    public  string? PESEL { get; set; }
    public  string? City { get; set; }
    public string? Street { get; set; }
    public  int ZipCode { get; set; }

    public UserModel(int iduser, string? name, string? surname, string? pesel, string? city, string? street, int zipCode)
    {
        Id_User = iduser;
        Name = name;
        Surname = surname;
        PESEL = pesel;
        City = city;
        Street = street;
        ZipCode = zipCode;


    }
}
