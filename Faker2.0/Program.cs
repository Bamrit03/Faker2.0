using System;
using Faker;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Tervetuloa feikkihenkilöiden generointiohjelmaan!");

        if (args.Length == 0)
        {
            Console.WriteLine("Et antanut yhtään komentoa. Käytä joko --personcount tai --interactive.");
            return;
        }

        string komento = args[0];

        if (komento == "--personcount")
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Anna henkilöiden määrä komennon jälkeen. Esim: --personcount 5");
                return;
            }

            if (int.TryParse(args[1], out int määrä))
            {
                LuoHenkilöitä(määrä);
            }
            else
            {
                Console.WriteLine("Virhe: syötä kelvollinen numero.");
            }
        }
        else if (komento == "--interactive")
        {
            Console.Write("Kuinka monta henkilöä haluat luoda? ");
            string? syöte = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(syöte))
            {
                Console.WriteLine("Et syöttänyt mitään.");
                return;
            }

            if (int.TryParse(syöte, out int määrä))
            {
                LuoHenkilöitä(määrä);
            }
            else
            {
                Console.WriteLine("Syötteen pitää olla numero.");
            }

            if (args.Length > 1)
            {
                Console.WriteLine("(Huom: muut argumentit jätettiin huomiotta.)");
            }
        }
        else
        {
            Console.WriteLine($"Tuntematon komento: {komento}");
            Console.WriteLine("Kokeile --personcount tai --interactive");
        }
    }

    static void LuoHenkilöitä(int määrä)
    {
        Console.WriteLine();
        Console.WriteLine($"Luodaan {määrä} henkilöä...");
        Console.WriteLine();

        for (int i = 1; i <= määrä; i++)
        {
            string etunimi = Name.First();
            string sukunimi = Name.Last();
            string osoite = Address.StreetAddress();
            string hetu = $"A {RandomNumber.Next(1000, 9999)} {RandomNumber.Next(1000, 9999)}";

            Console.WriteLine($"Henkilö #{i}:");
            Console.WriteLine($"Nimi: {etunimi} {sukunimi}");
            Console.WriteLine($"Osoite: {osoite}");
            Console.WriteLine($"Henkilötunnus: {hetu}");
            Console.WriteLine(new string('-', 40));
        }
    }
}
