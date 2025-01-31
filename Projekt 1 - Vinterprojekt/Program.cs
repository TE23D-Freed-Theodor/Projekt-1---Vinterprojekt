using System;
using Raylib_cs;


Main();

static void Main()
{
    Raylib.InitWindow(1600, 900, "test lol");
    Raylib.SetTargetFPS(60);
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Black);
    Raylib.EndDrawing();

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

    while (!Raylib.WindowShouldClose()) {hangman(gissning, random, potentiella_ord, gissade_bokstäver, korrekt_ord, liv);}

    Raylib.CloseWindow();
}

static void hangman(string gissning, Random random, List<string> potentiella_ord, List<string> gissade_bokstäver, string korrekt_ord, int liv)
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Black);
    Raylib.EndDrawing();

    gissade_bokstäver.Clear(); // Tömmer listan som heter "gissade bokstäver"
    korrekt_ord = potentiella_ord[random.Next(potentiella_ord.Count())]; // Hittar det korrekta ordet genom att ta ett slumpmässigt tal från potentiella_ord
    List<string> korrekt_ord_array = korrekt_ord.Select(c => c.ToString()).ToList();
    

    while (liv > 0)
    {
        for (int x = 0; x < korrekt_ord.Length; x++)
        {
            if (gissade_bokstäver.Contains(korrekt_ord_array[x]))
            {
                Raylib.DrawText(korrekt_ord[x].ToString(), 200, 200, 20, Color.White);
            }
            else
            {
                Raylib.DrawText("_", 200, 200, 20, Color.White);
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

    if (liv == 0) {
        gissade_bokstäver.Clear(); // Tömmer listan som heter "gissade bokstäver"
        korrekt_ord = potentiella_ord[random.Next(potentiella_ord.Count())]; // Hittar det korrekta ordet genom att ta ett slumpmässigt tal från potentiella_ord
        korrekt_ord_array = korrekt_ord.Select(c => c.ToString()).ToList();
        liv = 5;
        Console.WriteLine("NU kör vi om istället >:)");
    }

    hangman(gissning, random, potentiella_ord, gissade_bokstäver, korrekt_ord, liv);
}
