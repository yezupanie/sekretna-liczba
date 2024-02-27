using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sekretna_liczba
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("WITAJ W GRZE `SEKRETNA LICZBA`");
            Console.WriteLine("SPRÓBUJ ODGADNĄĆ LICZBĘ WYLOSOWANĄ PRZEZ KOMPUTER\n");

            Console.WriteLine("WYBIERZ POZIOM TRUDNOŚCI:");
            Console.WriteLine("1 => ŁATWY (LICZBA JEDNOCYFROWA, ILOŚĆ PRÓB: 2)");
            Console.WriteLine("2 => ŚREDNI (LICZBA DWUCYFROWA, ILOŚĆ PRÓB: 5)");
            Console.WriteLine("3 => TRUDNY (LICZBA TRZYCYFROWA, ILOŚĆ PRÓB: 8)\n");

            int poziomTrudnosci;
            do
            {
                Console.Write("WYBIERZ 1, 2 LUB 3: ");
            } while (!int.TryParse(Console.ReadLine(), out poziomTrudnosci) || poziomTrudnosci < 1 || poziomTrudnosci > 3);

            int iloscProb;
            string przedzialTekst;

            switch (poziomTrudnosci)
            {
                case 1:
                    iloscProb = 2;
                    przedzialTekst = "(1-9)";
                    break;
                case 2:
                    iloscProb = 5;
                    przedzialTekst = "(10-99)";
                    break;
                case 3:
                    iloscProb = 8;
                    przedzialTekst = "(100-999)";
                    break;
                default:
                    iloscProb = 0;
                    przedzialTekst = "";
                    break;
            }

            if (iloscProb == 0)
            {
                Console.WriteLine("Błędny wybór poziomu trudności.");
                return;
            }

            Console.Clear();

            Console.WriteLine($"POZIOM GRY: {(poziomTrudnosci == 1 ? "ŁATWY" : (poziomTrudnosci == 2 ? "ŚREDNI" : "TRUDNY"))}");
            Console.WriteLine($"ILOŚĆ POZOSTAŁYCH PRÓB: {iloscProb}");
            Console.WriteLine($"PODAJ SWOJĄ LICZBĘ Z PRZEDZIAŁU: {przedzialTekst}\n");

            Random random = new Random();
            int przedzialMin, przedzialMax;

            switch (poziomTrudnosci)
            {
                case 1:
                    przedzialMin = 1;
                    przedzialMax = 9;
                    break;
                case 2:
                    przedzialMin = 10;
                    przedzialMax = 99;
                    break;
                case 3:
                    przedzialMin = 100;
                    przedzialMax = 999;
                    break;
                default:
                    przedzialMin = przedzialMax = 0;
                    break;
            }

            int liczbaDoOdgadniecia = random.Next(przedzialMin, przedzialMax + 1);

            Console.WriteLine($"Zgadnij liczbę z przedziału {przedzialMin} - {przedzialMax}.");
            Console.WriteLine($"Masz {iloscProb} prób.");

            for (int proba = 1; proba <= iloscProb; proba++)
            {
                Console.Write($"Próba {proba}: ");
                if (int.TryParse(Console.ReadLine(), out int propozycja))
                {
                    Console.Clear();

                    if (propozycja == liczbaDoOdgadniecia)
                    {
                        Console.WriteLine("Brawo! Odgadłeś(aś) liczbę!");
                        break;
                    }
                    else if (propozycja < liczbaDoOdgadniecia)
                    {
                        Console.WriteLine("TWOJA LICZBA JEST MNIEJSZA OD SEKRETNEJ LICZBY");
                    }
                    else
                    {
                        Console.WriteLine("TWOJA LICZBA JEST WIĘKSZA OD SEKRETNEJ LICZBY");
                    }

                    Console.WriteLine($"POZIOM GRY: {(poziomTrudnosci == 1 ? "ŁATWY" : (poziomTrudnosci == 2 ? "ŚREDNI" : "TRUDNY"))}");
                    Console.WriteLine($"ILOŚĆ POZOSTAŁYCH PRÓB: {iloscProb - proba}");
                    Console.WriteLine($"PODAJ SWOJĄ LICZBĘ Z PRZEDZIAŁU: {przedzialTekst}\n");
                }
                else
                {
                    Console.WriteLine("Nieprawidłowy format liczby. Spróbuj ponownie.");
                    proba--;
                }

                if (proba == iloscProb)
                {
                    Console.WriteLine($"Niestety, skończyły się próby. Prawidłowa liczba to: {liczbaDoOdgadniecia}");
                }
            }

            Console.ReadLine();
        }
    }
}
