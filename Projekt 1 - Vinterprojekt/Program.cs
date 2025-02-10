using System;
using Raylib_cs;

Main(args);

static void Main(string[] args)
{
    int stage = 0; // Om spelaren når stage 11 så förlorar den

    List<string> stages = ["", @"                                                                                    
                                                    
                       @@@@@@@@@@@@@@@              
                @@@@@@@@@@@@@@@@@@@@@@@@            
             @@@@@@@@@@  @       @@@@@@@@@          
           @@@@@@ @    @@@ @ @ @@   @@@@@@@         
         @@@@@@   @   @@ @  @@@    @   @@@@@        
       @@@@@ @  @    @@  @@@@@ @ @ @  @@@@@@@       
      @@@@   @ @ @@ @@  @ @@ @ @@ @@@ @ @@@@@@      
     @@@@ @ @ @  @@ @  @ @@   @ @ @@ @@@ @@@@@@     
    @@@@@    @@ @@@@@   @@   @ @ @@@ @   @@@@@@@    
   @@@@    @ @ @@@    @@@@  @ @  @  @   @  @@@@@@   
   @@@   @  @ @@@@ @ @@ @ @  @@  @   @   @@  @@@@   
  @@@  @ @@@ @@@  @ @@      @@  @@@@@@ @@  @@@@@@   
  @@@ @ @@@ @@@  @@  @    @@ @  @  @@@@   @  @@@    
 @@@  @         @         @          @       @@@    
 @@@                                         @@@    
", @"                                                    
                                                    
                                                    
              @@@@                                  
              @@@@                                  
              @@@@                                  
              @@@                                   
              @@@                                   
              @@@                                   
              @@@                                   
              @@@                                   
              @@@@                                  
             @@@@                                   
             @@@@                                   
             @@@@                                   
             @@@@                                   
              @@@                                   
              @@@                                   
             @@@@                                   
             @@@@      @@@@@@@@@@@@@@@              
             @@@@@@@@@@@@@@@@@@@@@@@@@@@            
             @@@@@@@@@@  @       @@@@@@@@@          
           @@@@@@ @    @@@ @ @ @@   @@@@@@@         
         @@@@@@   @   @@ @  @@@ @  @   @@@@@        
       @@@@@ @  @    @@  @@@@ @@ @ @  @@@@@@@       
      @@@@   @ @ @@ @@  @    @ @@ @@@ @ @@@@@@      
     @@@@ @ @ @  @@ @  @ @@   @ @ @@ @@@ @@@@@@     
    @@@@@    @@ @@@@@   @@   @ @  @  @   @@@@@@@    
   @@@@    @ @ @@@    @@ @  @ @  @  @   @  @@@@@@   
   @@@   @  @ @@@@ @ @@ @ @  @@  @@  @   @@  @@@@   
  @@@  @ @@@ @@@  @@@@      @@  @@@@@@ @@@ @@@@@@   
  @@@ @ @@  @@@  @@  @    @@ @  @  @@@@   @  @@@    
 @@@  @         @         @          @       @@@    
 @@@                                         @@@    
                                                    
                                                    ", @"                                                    
                                                    
                           @@@                      
              @@@@@@@@@@@@@@@@@@@@@@@@@@@           
              @@@@@@@@@@@@@                         
              @@@@     @@@                          
              @@@     @@                            
              @@@  @@@                              
              @@@@@@                                
              @@@@@                                 
              @@@                                   
              @@@@                                  
             @@@@                                   
             @@@@                                   
             @@@@                                   
             @@@@                                   
              @@@                                   
              @@@                                   
             @@@@                                   
             @@@@      @@@@@@@@@@@@@@@              
             @@@@@@@@@@@@@@@@@@@@@@@@@@@            
             @@@@@@@@@@  @       @@@@@@@@@          
           @@@@@@ @    @@@ @ @ @@   @@@@@@@         
         @@@@@@   @   @@ @  @@@ @  @   @@@@@        
       @@@@@ @  @    @@  @@@@ @@ @ @  @@@@@@@       
      @@@@   @ @ @@ @@  @    @ @@ @@@ @ @@@@@@      
     @@@@ @ @ @  @@ @  @ @@   @ @ @@ @@@ @@@@@@     
    @@@@@    @@ @@@@@   @@   @ @  @  @   @@@@@@@    
   @@@@    @ @ @@@    @@ @  @ @  @  @   @  @@@@@@   
   @@@   @  @ @@@@ @ @@ @ @  @@  @@  @   @@  @@@@   
  @@@  @ @@@ @@@  @@@@      @@  @@@@@@ @@@ @@@@@@   
  @@@ @ @@  @@@  @@  @    @@ @  @  @@@@   @  @@@    
 @@@  @         @         @          @       @@@    
 @@@                                         @@@    
                                                    
                                                    ", @"                                                    
                                                    
                           @@@                      
              @@@@@@@@@@@@@@@@@@@@@@@@@@@           
              @@@@@@@@@@@@@          @@@@           
              @@@@     @@@           @@@@           
              @@@     @@             @@@@           
              @@@  @@@               @@@@           
              @@@@@@                 @@@@           
              @@@@@                   @             
              @@@                                   
              @@@@                                  
             @@@@                                   
             @@@@                                   
             @@@@                                   
             @@@@                                   
              @@@                                   
              @@@                                   
             @@@@                                   
             @@@@      @@@@@@@@@@@@@@@              
             @@@@@@@@@@@@@@@@@@@@@@@@@@@            
             @@@@@@@@@@  @       @@@@@@@@@          
           @@@@@@ @    @@@ @ @ @@   @@@@@@@         
         @@@@@@   @   @@ @  @@@ @  @   @@@@@        
       @@@@@ @  @    @@  @@@@ @@ @ @  @@@@@@@       
      @@@@   @ @ @@ @@  @    @ @@ @@@ @ @@@@@@      
     @@@@ @ @ @  @@ @  @ @@   @ @ @@ @@@ @@@@@@     
    @@@@@    @@ @@@@@   @@   @ @  @  @   @@@@@@@    
   @@@@    @ @ @@@    @@ @  @ @  @  @   @  @@@@@@   
   @@@   @  @ @@@@ @ @@ @ @  @@  @@  @   @@  @@@@   
  @@@  @ @@@ @@@  @@@@      @@  @@@@@@ @@@ @@@@@@   
  @@@ @ @@  @@@  @@  @    @@ @  @  @@@@   @  @@@    
 @@@  @         @         @          @       @@@    
 @@@                                         @@@    
                                                    
                                                    ", @"                                                    
                                                    
                           @@@                      
              @@@@@@@@@@@@@@@@@@@@@@@@@@@           
              @@@@@@@@@@@@@          @@@@           
              @@@@     @@@           @@@@           
              @@@     @@             @@@@           
              @@@  @@@               @@@@           
              @@@@@@                 @@@@           
              @@@@@                @@ @  @          
              @@@                @         @        
              @@@@               @    @ @ @@        
             @@@@                  @@@@@@@          
             @@@@                @@@  @ @@          
             @@@@                     @     @@      
             @@@@                    @@             
              @@@                 @@    @@          
              @@@                         @         
             @@@@                                   
             @@@@      @@@@@@@@@@@@@@@              
             @@@@@@@@@@@@@@@@@@@@@@@@@@@            
             @@@@@@@@@@  @       @@@@@@@@@          
           @@@@@@ @    @@@ @ @ @@   @@@@@@@         
         @@@@@@   @   @@ @  @@@ @  @   @@@@@        
       @@@@@ @  @    @@  @@@@ @@ @ @  @@@@@@@       
      @@@@   @ @ @@ @@  @    @ @@ @@@ @ @@@@@@      
     @@@@ @ @ @  @@ @  @ @    @ @ @@ @@@ @@@@@@     
    @@@@@    @@ @@@@@   @@   @ @  @  @   @@@@@@@    
   @@@@    @ @ @@@    @@ @@@@@@  @  @   @  @@@@@@   
   @@@   @  @ @@@@ @ @@ @ @@@@@  @@  @   @@  @@@@   
  @@@  @ @@@ @@@  @@@@      @@  @@@@@@ @@@ @@@@@@   
  @@@ @ @@  @@@  @@  @    @@ @  @  @@@@   @  @@@    
 @@@  @         @         @          @       @@@    
 @@@                                         @@@    
                                                    
                                                    "];


    Raylib.InitWindow(1600, 900, "test lol");
    Raylib.SetTargetFPS(60);

    // Skapar variablerna som skickas till metoderna
    Random random = new Random();
    List<string> potentiella_ord = new List<string> { "orfdjifhdjsohfiodfoisfd", "ordigarfdsnufhdshfdsofdosjifsdfe", "ordigastjfdioshfoidsjhfoisdjfoisdjofjdsoijfidsjsf" }; // Alla potentiella ord
    List<string> gissade_bokstäver = new List<string>(); // Alla bokstäver som spelaren har gissat
    int liv = 5; // mängden liv som spelaren har (5 från början)
    string korrekt_ord = "";
    string gissning = "";

    // Kör spelet
    Console.InputEncoding = System.Text.Encoding.Unicode;
    Console.OutputEncoding = System.Text.Encoding.Unicode;

    gissade_bokstäver.Clear(); // Tömmer listan som heter "gissade bokstäver"
    korrekt_ord = potentiella_ord[random.Next(potentiella_ord.Count())]; // Hittar det korrekta ordet genom att ta ett slumpmässigt tal från potentiella_ord
    List<string> korrekt_ord_array = korrekt_ord.Select(c => c.ToString()).ToList();

    while (!Raylib.WindowShouldClose()) {hangman(gissning, random, potentiella_ord, gissade_bokstäver, korrekt_ord, liv, stage, stages);}

    Raylib.CloseWindow();
}

static void hangman(string gissning, Random random, List<string> potentiella_ord, List<string> gissade_bokstäver, string korrekt_ord, int liv, int stage, List<string> stages)
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Black);
    
    string ord_på_skärm = "";

    while (liv > 0)
    {
        foreach (char p in korrekt_ord) {
            if (gissade_bokstäver.Contains(p.ToString())) {
                ord_på_skärm += p;
            }
            else {
                ord_på_skärm += "_";
            }
        }

        int ord_på_skärm_bredd = Raylib.MeasureText(ord_på_skärm, 40);

        string instruktion = "Tryck på en bokstav mellan A-Z för att gissa";
        int instruktion_bredd = Raylib.MeasureText(instruktion, 40);

        int stage_bredd = Raylib.MeasureText(stages[stage], 1);

        int centerX = (Raylib.GetScreenWidth() - ord_på_skärm_bredd)/2;
        Raylib.DrawText(ord_på_skärm, centerX, 200, 40, Color.White); // Skriver ut ordet fast om en bokstav finns med i gissade_bokstäver men inte är korrekt så skrivs fortfarande ett "_"
        Raylib.DrawText(instruktion, (Raylib.GetScreenWidth() - instruktion_bredd) / 2, 300, 40, Color.White); 
        Raylib.DrawText(stages[stage], (Raylib.GetScreenWidth() - stage_bredd) / 2, 670, 1, Color.White);

        break;
    }

    Raylib.EndDrawing();
}


/*

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

*/