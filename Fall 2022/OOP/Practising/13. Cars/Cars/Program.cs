using Cars;

internal class Program
{
    static void Main(string[] args)
    {
        var carAudi = new Car();
        var AudiOwner = new Owner(); // Lisätty


        carAudi.BrandName = "Audi";
        carAudi.Slogan = "Teknistä etumatkaa";
        carAudi.YearOfManufacture = 2021;
        carAudi.DrivedKM = 7809;
        carAudi.Owner = AudiOwner; // Lisätty
        AudiOwner.OwnerName = "Matti Meikäläinen";
        AudiOwner.StreetAddress = "Karjalankatu 3";
        AudiOwner.City = "Joensuu";
        AudiOwner.PostalCode = "80200";

        carAudi.PrintCarInfo();

        var carMB = new Car();
        var MBOwner = new Owner(); // Lisätty

        carMB.BrandName = "Mercedes-Benz";
        carMB.Slogan = "Paras tai ei mitään";
        carMB.YearOfManufacture = 2019;
        carMB.DrivedKM = 120000;
        carMB.Owner = MBOwner; // Lisätty
        MBOwner.OwnerName = "Sirpa Teikäläinen";
        MBOwner.StreetAddress = "Mersuntie 1";
        MBOwner.City = "Joensuu";
        MBOwner.PostalCode = "80160";

        carMB.PrintCarInfo();

        var carMB2 = new Car();
        var MB2Owner = new Owner(); // Lisätty

        carMB2.BrandName = "Mercedes-Benz";
        carMB2.Slogan = "Paras tai ei mitään";
        carMB2.YearOfManufacture = 2009;
        carMB2.DrivedKM = 580000;
        carMB2.Owner = MB2Owner; // Lisätty
        MB2Owner.OwnerName = "Taxi Oy";
        MB2Owner.StreetAddress = "Taksikuskintie 2";
        MB2Owner.City = "Joensuu";
        MB2Owner.PostalCode = "80110";

        carMB2.PrintCarInfo();
    }
}



