using System;

class program
{
    static Random random = new Random();
    static List<string> potentiella_ord = new List<string> { "ord", "ordigare", "ordigast" }; // Alla potentiella ord
    static List<string> gissade_bokstäver = new List<string>(); // Alla bokstäver som spelaren har gissat
    int liv; // mängden liv som spelaren har (5 från början)
    static string korrekt_ord = "";

    static void Main() { 
        // Det är det här som programmet kommer att köra (hangman):
        Console.InputEncoding = System.Text.Encoding.Unicode;
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        hangman();
    }

    static void hangman()
    {
        gissade_bokstäver.Clear(); // Tömmer listan som heter "gissade bokstäver"
        korrekt_ord = potentiella_ord[random.Next(potentiella_ord.Count())]; // Hittar det korrekta ordet genom att ta ett slumpmässigt tal från potentiella_ord

        Console.WriteLine(korrekt_ord);
        Console.ReadLine();
    }

    static void avslut()
    {

    }

}