
using Cars;
/// <summary>
/// Autoluokka
/// </summary>
public class Car
{

    // Staattinen juokseva numerointi
    private static int _id;

    public Car()
    {
        // Luodaan uudelle autolle yksilöllinne ID numero
        CreateNewID();
    }

    /// <summary>
    /// Palauttaa auton yksilöllisen numeron
    /// ns. readonly tyyppinen ominaisuus
    /// </summary>
    public int ID
    {
        get
        {
            return _id;
        }
    }

    public string BrandName { get; set; }
    public string Slogan { get; set; }
    public int YearOfManufacture { get; set; }
    public int DrivedKM { get; set; }
    public Owner Owner { get; set; } // Koostuu myös uudesta Owner luokasta


    /// <summary>
    /// Tulostaa kaikki auton tiedot allekkain konsoliin
    /// </summary>
    public void PrintCarInfo()
    {
        Console.WriteLine("#" + _id);
        Console.WriteLine("Auton valmistaja: " + BrandName);
        Console.WriteLine("Valmistajan tunnuslause: " + Slogan);
        Console.WriteLine("Valmistusvuosi: " + YearOfManufacture);
        Console.WriteLine("Ajettu: " + DrivedKM);
        Console.WriteLine("Omistaja: " + Owner.OwnerName);
        Console.WriteLine("Osoite:");
        // Tästä alaspäin uuden luokan ilmentymien ominaisuuksia
        Console.WriteLine(Owner.StreetAddress);
        Console.WriteLine(Owner.City);
        Console.WriteLine(Owner.PostalCode);
    }

    /// <summary>
    /// Metodi joka osaa luoda uuden juoksevan numeron autolle
    /// (KÄYTTÖ VAIN SISÄISESTI!)
    /// </summary>
    public void CreateNewID()
    {
        _id++;
    }
}

