using System;

Main();

static void Main()
{
    // Skapar variablerna som skickas till metoderna
    Random random = new Random();
    List<string> potentiella_ord = new List<string> { "ord", "ordigare", "ordigast" }; // Alla potentiella ord
    List<string> gissade_bokstäver = new List<string>(); // Alla bokstäver som spelaren har gissat
    int liv = 5; // mängden liv som spelaren har (5 från början)
    string korrekt_ord = "";
    string gissning = "";

    // Kör spelet
    Console.InputEncoding = System.Text.Encoding.Unicode;
    Console.OutputEncoding = System.Text.Encoding.Unicode;
    hangman(gissning, random, potentiella_ord, gissade_bokstäver, korrekt_ord, liv);
}

static void hangman(string gissning, Random random, List<string> potentiella_ord, List<string> gissade_bokstäver, string korrekt_ord, int liv)
{
    gissade_bokstäver.Clear(); // Tömmer listan som heter "gissade bokstäver"
    korrekt_ord = potentiella_ord[random.Next(potentiella_ord.Count())]; // Hittar det korrekta ordet genom att ta ett slumpmässigt tal från potentiella_ord
    List<string> korrekt_ord_array = korrekt_ord.Select(c => c.ToString()).ToList();
    

    while (liv > 0)
    {
        for (int x = 0; x < korrekt_ord.Length; x++)
        {
            if (gissade_bokstäver.Contains(korrekt_ord_array[x]))
            {
                Console.Write(korrekt_ord[x]);
            }
            else
            {
                Console.Write("_");
            }
        }

        Console.WriteLine("Vilken bokstav vill du gissa på?");
        gissning = Console.ReadLine();

        while (gissade_bokstäver.Contains(gissning))
        {
            Console.WriteLine("Den där bokstaven finns redan!");
            gissning = Console.ReadLine();
        }

        while (string.IsNullOrEmpty(gissning) || gissning.Length != 1 || !char.IsLetter(gissning[0]))
        {
            Console.WriteLine("DUM! Ange endast en bokstav (a-ö) din lilla fuskis:");
            gissning = Console.ReadLine();
        }

        if (korrekt_ord_array.Contains(gissning))
        {
            Console.WriteLine("KORREKT! Duktig!");
            gissade_bokstäver.Add(gissning);
        }
        else
        {
            liv -= 1;
            Console.WriteLine("INKORREKT! SÄMST!");
            Console.WriteLine($"Nu har du {liv} liv kvar! Dum åsna!");
            gissade_bokstäver.Add(gissning);
        }

        if (korrekt_ord_array.All(bokstav => gissade_bokstäver.Contains(bokstav)))
        {
            Console.WriteLine("Grattis! Du har gissat alla bokstäver nu!");
            break;
        }

    }

    hangman(gissning, random, potentiella_ord, gissade_bokstäver, korrekt_ord, liv);
}
