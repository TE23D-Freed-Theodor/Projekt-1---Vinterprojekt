using System;
Random random = new Random();

List<string> potentiella_ord = ["ord", "ordigare", "ordigast"]; // Alla potentiella ord
List<string> gissade_bokstäver = []; // Alla bokstäver som spelaren har gissat

int liv; // mängden liv som spelaren har (5 från början)
string korrekt_ord = random.Next(potentiella_ord.Count);

hangman();

static void hangman() {
    Console.WriteLine("test");
    Console.ReadLine();
}

static void avslut() {

}