using System;

Main();

static void Main() { 
    // Skapar variablerna som skickas till metoderna
    Random random = new Random();
    List<string> potentiella_ord = new List<string> { "ord", "ordigare", "ordigast" }; // Alla potentiella ord
    List<string> gissade_bokstäver = new List<string>(); // Alla bokstäver som spelaren har gissat
    int liv = 5; // mängden liv som spelaren har (5 från början)
    string korrekt_ord = "";

    // Kör spelet
    Console.InputEncoding = System.Text.Encoding.Unicode;
    Console.OutputEncoding = System.Text.Encoding.Unicode;
    hangman(random, potentiella_ord, gissade_bokstäver, ref korrekt_ord, ref liv);
}

static void hangman(Random random, List<string> potentiella_ord, List<string> gissade_bokstäver, ref string korrekt_ord, ref int liv) {
    gissade_bokstäver.Clear(); // Tömmer listan som heter "gissade bokstäver"
    korrekt_ord = potentiella_ord[random.Next(potentiella_ord.Count())]; // Hittar det korrekta ordet genom att ta ett slumpmässigt tal från potentiella_ord
    List<string> korrekt_ord_array = korrekt_ord.Select(c => c.ToString()).ToList();
    
    for (int x = 0; x < korrekt_ord.Length; x++) {
        if (gissade_bokstäver.Contains(korrekt_ord_array[x])) {
            Console.Write(korrekt_ord[x]);
        }
        else {
            Console.Write("_");
        }
    }
    Console.ReadLine();
}