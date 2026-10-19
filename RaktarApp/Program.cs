using RaktarApp;

List<Termek> termekek_lista = new List<Termek>();
int hibasSorokSzama = 0;
foreach (var sor in File.ReadAllLines(@"C:\Users\13d\source\repos\RaktarApp\RaktarApp\bin\Debug\net10.0\termekek.txt").Skip(1))
{
    string[] adatok = sor.Split('|');
    string tipus = adatok[0];
    string cikkszam = adatok[1];
    if (adatok.Count() != 4)
    {
        hibasSorokSzama++;
        continue;
    }

    if (string.IsNullOrWhiteSpace(tipus) || string.IsNullOrWhiteSpace(cikkszam))
    {
        hibasSorokSzama++;
        continue;
    }
    
    if (int.TryParse(adatok[2], out int alapar))
    {
        
        if (int.TryParse(adatok[3], out int garanciaev))
        {
            
            if (tipus == "S")
            {
                Termek termek = new Termek(cikkszam, alapar);
                termekek_lista.Add(termek);
            }
            else if (tipus == "G")
            {
                TartosTermek tartos = new TartosTermek(cikkszam, alapar, garanciaev);
                termekek_lista.Add(tartos);
            }
        }
        else
        {
            hibasSorokSzama++;
            continue;
        }
    }
    else
    {
        hibasSorokSzama++;
        continue;
    }
}


Console.WriteLine($"Sikeresen beolvasott termékek: {termekek_lista.Count()} db");
Console.WriteLine($"Hibás termékek száma: {hibasSorokSzama} db");
Console.WriteLine();
foreach (var item in termekek_lista)
{
    Console.WriteLine(item);
}

Console.WriteLine($"Teljes raktár lóvé: {termekek_lista.Sum(t => t.ErtekSzamitas(10))}");
Console.WriteLine($"Statikus számláló értéke: {Termek.OsszesTermekSzama}");