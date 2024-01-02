 namespace Harjoitustyö
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // Luodaan Listat- luokan ilmentymä
            Listat listat = new Listat();

            // Ilmentymä LaskuttavaOsapuoli luokasta, ainoa ilmentymä
            Laskuttaja asiakasRakennusOy = new Laskuttaja();

            // Ilmentymä LaskutettavaOsaPuoli luokasta
            Laskutettava firmaA = new Laskutettava();
            firmaA.Nimi = "Firma-A";
            firmaA.Osoite = "Juuritie 4";
            firmaA.Postinumero = "80100";
            firmaA.Kaupunki = "Joensuu";
            listat.Laskutettava.Add(firmaA); // Lisätään ilmentymä listalle

            // Ilmentymä LaskutettavaOsaPuoli luokasta
            Laskutettava firmaB = new Laskutettava();
            firmaB.Nimi = "Firma-B";
            firmaB.Osoite = "Puutie 3";
            firmaB.Postinumero = "70100";
            firmaB.Kaupunki = "Kuopio";
            listat.Laskutettava.Add(firmaB); // Lisätään ilmentymä listalle

            // Alla ilmentymien luontia Tuote- luokasta, lisätään samalla ilmentymät listalle
            Tuote mutteri = new Tuote("Mutteri", 0.1, "kpl");
            listat.Tuotelista.Add(mutteri);

            Tuote asennus = new Tuote("Asennus", 50, "h");
            listat.Tuotelista.Add(asennus);

            Tuote vasara = new Tuote("Vasara", 20, "kpl");
            listat.Tuotelista.Add(vasara);

            Tuote peili = new Tuote("Peili", 10, "kpl");
            listat.Tuotelista.Add(peili);

            Tuote laatta = new Tuote("Laatta", 2, "m");
            listat.Tuotelista.Add(laatta);

            // Luodaan lasku ja lisätään tarvittavat ominaisuudet
            Lasku testilasku1 = new Lasku("HOX HOX Lisätietoja");

            testilasku1.Laskuttaja = asiakasRakennusOy;
            testilasku1.Laskutettava = firmaA;

            // Lisätään laskulle laskurivit LisaaLaskulle- metodilla
            testilasku1.LisaaLaskulle(mutteri, 3);
            testilasku1.LisaaLaskulle(asennus, 5);
            testilasku1.LisaaLaskulle(vasara, 2);
            listat.Laskulista.Add(testilasku1); // Lisätään ilmentymä listalle

            Lasku testilasku2 = new Lasku();

            testilasku2.Laskuttaja = asiakasRakennusOy;
            testilasku2.Laskutettava = firmaB;
            testilasku2.LisaaLaskulle(peili, 3);
            testilasku2.LisaaLaskulle(laatta, 5);
            testilasku2.LisaaLaskulle(asennus, 2);

            listat.Laskulista.Add(testilasku2);

            // Tulostaa kaikki laskut
            Console.WriteLine(listat.TulostaKaikkiLaskut());

            // Yksittäisen laskun tulostus, haku tunnistenumerolla
            Console.WriteLine(listat.TulostaLasku(2));

            // Yksittäisen asiakkaan kaikkien laskujen hakeminen ja listaaminen. Haku nimellä
            Console.WriteLine(listat.TulostaLasku("Firma-A"));
            Console.WriteLine(listat.TulostaLasku("Firma-B"));
            Console.WriteLine(listat.TulostaLasku("Firma-C"));

            // Kaikkien tallennettujen tuotetietojen listaaminen
            Console.WriteLine(listat.TulostaTuotteet());

            // Kaikkien sellaisten laskutietojen hakeminen ja listaaminen testisovelluksessa, joissa esiintyy jokin
            // hakumetodille määrittämäsi tuote.
            Console.WriteLine(listat.TulostaLasku(peili));
        }


    }
}