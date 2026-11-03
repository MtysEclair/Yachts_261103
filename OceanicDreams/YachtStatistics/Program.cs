
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using YachtStatistics;

CultureInfo hu = new CultureInfo("hu-HU");

string fajlNev = Path.Combine(
    AppContext.BaseDirectory,
    "yacht_berlesek_2024.csv"
);

if (!File.Exists(fajlNev))
{
    Console.WriteLine("Hiba: A CSV-fájl nem található!");
    Console.WriteLine(fajlNev);
    return;
}

List<Berles> berlesek = new List<Berles>();

foreach (string sor in File.ReadLines(fajlNev).Skip(1))
{
    if (string.IsNullOrWhiteSpace(sor))
        continue;

    string[] adatok = sor.Split(';');

    Berles berles = new Berles
    {
        Uid = int.Parse(adatok[0]),
        YachtId = int.Parse(adatok[1]),
        StartDate = DateTime.ParseExact(
            adatok[2], "yyyy-MM-dd",
            CultureInfo.InvariantCulture),
        EndDate = DateTime.ParseExact(
            adatok[3], "yyyy-MM-dd",
            CultureInfo.InvariantCulture),
        DailyPrice = int.Parse(adatok[4]),
        Name = adatok[5].Trim()
    };

    berlesek.Add(berles);
}

if (berlesek.Count == 0)
{
    Console.WriteLine("A CSV nem tartalmaz bérléseket.");
    return;
}


int honap;

do
{
    Console.Write("Adjon meg egy hónapot (1-12): ");
} while (!int.TryParse(Console.ReadLine(), out honap)
         || honap < 1 || honap > 12);


DateTime honapKezdete = new DateTime(2024, honap, 1);
DateTime honapVege = honapKezdete.AddMonths(1).AddDays(-1);

long haviBevetel = berlesek
    .Where(b => b.StartDate <= honapVege
             && b.EndDate >= honapKezdete)
    .Sum(b => (long)b.TotalPrice);

Console.WriteLine(
    $"A(z) {honap}. hónap bevétele: " +
    $"{haviBevetel.ToString("N0", hu)} euró");


long evesBevetel = berlesek.Sum(b => (long)b.TotalPrice);

Console.WriteLine(
    $"A teljes 2024-es éves bevétel: " +
    $"{evesBevetel.ToString("N0", hu)} euró");


Berles legdragabb = berlesek
    .OrderByDescending(b => b.TotalPrice)
    .First();

Console.WriteLine(
    $"A legdrágább bérlés az {legdragabb.Name} yacht volt, " +
    $"teljes ár: {legdragabb.TotalPrice.ToString("N0", hu)} euró");


int yachtokSzama = berlesek
    .Select(b => b.YachtId)
    .Distinct()
    .Count();

Console.WriteLine(
    $"Összesen {yachtokSzama} különböző yachtot béreltek ki.");


var leggyakoribb = berlesek
    .GroupBy(b => b.Name)
    .OrderByDescending(g => g.Count())
    .First();

Console.WriteLine(
    $"A legtöbbször bérelt yacht: " +
    $"{leggyakoribb.Key} ({leggyakoribb.Count()} bérlés)");


double atlag = berlesek.Average(b => b.Days);

Console.WriteLine(
    $"Átlagos bérlési időtartam: " +
    $"{atlag.ToString("N2", hu)} nap");
