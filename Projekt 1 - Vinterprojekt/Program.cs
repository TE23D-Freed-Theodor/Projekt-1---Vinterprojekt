using System;
using Raylib_cs;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // skapar fönster
        Raylib.InitWindow(1600, 900, "Hangman");
        Raylib.SetTargetFPS(60);

        // Alla stages (steg i hänga gubbe)
        List<string> stages = new List<string>
        {
            @"+---+
  |   |
      |
      |
      |
      |
=========", @"+---+
  |   |
  O   |
      |
      |
      |
=========", @"+---+
  |   |
  O   |
 /|   |
      |
      |
=========", @"+---+
  |   |
  O   |
 /|\  |
      |
      |
=========", @"+---+
  |   |
  O   |
 /|\  |
 /    |
      |
=========", @"+---+
  |   |
  O   |
 /|\  |
 / \  |
      |
========="
        };

        // Lista med potentiella ord
        List<string> potentiella_ord = new List<string> { "sverige", "norge", "finland", "danmark" };
        Random random = new Random();

        // Spelvariabler
        string korrekt_ord = "";
        List<string> gissade_bokstäver = new List<string>();
        int liv = 5;
        int stage = 0;
        bool gameOver = false;
        bool gameWin = false;
        int redanGissadTimer = 0;

        // function för att starta ett nytt spel
        void NewGame()
        {
            liv = 5;
            stage = 0;
            gissade_bokstäver.Clear();
            korrekt_ord = potentiella_ord[random.Next(potentiella_ord.Count)];
            gameOver = false;
            gameWin = false;
        }
        NewGame();

        // den här loopen får spelet att köras om och om
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            if (!gameOver)
            {
                // Rita ut ordet med rätt gissade bokstäver (inga mellanslag mellan tecknen)
                string ord_på_skärm = "";
                foreach (char c in korrekt_ord)
                {
                    if (gissade_bokstäver.Contains(c.ToString()))
                        ord_på_skärm += c;
                    else
                        ord_på_skärm += "_";
                }
                int ordBredd = Raylib.MeasureText(ord_på_skärm, 40);
                Raylib.DrawText(ord_på_skärm, (Raylib.GetScreenWidth() - ordBredd) / 2, 200, 40, Color.White);

                // Instruktionstext
                string instruktion = "Tryck på en bokstav mellan A-Ö för att gissa";
                int instBredd = Raylib.MeasureText(instruktion, 40);
                Raylib.DrawText(instruktion, (Raylib.GetScreenWidth() - instBredd) / 2, 300, 40, Color.White);

                // Visa antalet kvarvarande liv
                string livesText = "Liv kvar: " + liv;
                Raylib.DrawText(livesText, 50, 50, 30, Color.White);

                // Rita hänga gubbe-steget (ascii-art)
                // Tidigare y-värde var 670, nu är det 550 (för att placera den längre upp)
                if (stage < stages.Count)
                {
                    int stageBredd = Raylib.MeasureText(stages[stage], 1);
                    Raylib.DrawText(stages[stage], (Raylib.GetScreenWidth() - stageBredd) / 2, 550, 20, Color.White);
                }

                // Meddelande om redan gissat bokstav
                if (redanGissadTimer > 0)
                {
                    Raylib.DrawText("Redan gissat!", 650, 120, 40, Color.White);
                    redanGissadTimer--;
                }

                // Hantera tangenttryckning
                int knapp = Raylib.GetKeyPressed();
                if (knapp != 0 && redanGissadTimer <= 0)
                {
                    char bokstav = char.ToLower((char)knapp);
                    if (char.IsLetter(bokstav))
                    {
                        string bokstav_sträng = bokstav.ToString();
                        if (gissade_bokstäver.Contains(bokstav_sträng))
                        {
                            redanGissadTimer = 60;
                        }
                        else
                        {
                            gissade_bokstäver.Add(bokstav_sträng);
                            // Om bokstaven inte finns i ordet: dra ett liv och gå till nästa steg
                            if (!korrekt_ord.Contains(bokstav_sträng))
                            {
                                liv--;
                                stage++;
                            }
                        }
                    }
                }

                // Kontrollera om spelaren har gissat alla bokstäver
                bool allaGissade = true;
                foreach (char c in korrekt_ord)
                {
                    if (!gissade_bokstäver.Contains(c.ToString()))
                    {
                        allaGissade = false;
                        break;
                    }
                }
                if (allaGissade)
                {
                    gameWin = true;
                    gameOver = true;
                }

                // Kontrollera om spelaren har förlorat
                if (liv <= 0 || stage >= stages.Count)
                {
                    gameOver = true;
                }
            }
            else
            {
                // Spelöver-meddelande (ingen gul text, nu vit)
                string message = gameWin ? "Grattis, du vann!" : "Du förlorade!";
                int messageWidth = Raylib.MeasureText(message, 60);
                Raylib.DrawText(message, (Raylib.GetScreenWidth() - messageWidth) / 2, 300, 60, Color.White);

                string replay = "Tryck på Enter för att spela igen";
                int replayWidth = Raylib.MeasureText(replay, 30);
                Raylib.DrawText(replay, (Raylib.GetScreenWidth() - replayWidth) / 2, 400, 30, Color.White);

                // Om spelaren trycker Enter startas ett nytt spel
                if (Raylib.IsKeyPressed(KeyboardKey.Enter))
                {
                    NewGame();
                }
            }

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}
