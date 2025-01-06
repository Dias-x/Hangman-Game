using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        
       MainMenu();
       
    }

    //Methode erstellen
    static void MainMenu()
    {
        //Dauerhafte Schleife bis "while = true" ist
        while (true)
        {
            //Menu erstellen
            Console.WriteLine($"#### HANGMAN ###");
            Console.WriteLine($"################");

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"Wähle eine Aktion:");

            Console.WriteLine($"");

            //Schriftfarbe ändern
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"[1] Spielen:");
            Console.WriteLine($"[2] Exit:");
            
            //Schriftfarbe wieder auf Weiss ändern
            Console.ResetColor();

            Console.WriteLine();

            Console.Write($"Aktion: ");
            int aktioninput = int.Parse(Console.ReadLine());
            
            //Die "while" ist aktuell auf "true", damit der Programm nicht sofort beendet, setzten wir "end auf false"
            bool end = false;

            //Game Starten oder Beenden
            switch (aktioninput)
            {
                case 1:
                    //Zur "StartGame()" Methode
                    StartGames();
                    break;

                case 2:
                    //end auf "true", dann wird die "while = true" sein
                    end = true;
                    break;
            }

            //abfragung ob es wirklich "true" ist, fürs Beenden
            if (end == true)
            {
                break;
            }
            
            //Konsole Leeren
            Console.Clear();
        }
    }

    static void StartGames()
    {
        //"string-array" mit Wörter
        string[] words = new string[]
        {
            "Brot",
            "Hafenflocken",
            "Fussball",
            "Menschen",
            "Lokomotive",
            "Mitglied",
            "Umfeld",
            "Zeit",
            "Sex"
        };
        
        //Generiert eine zufallszahl
        Random rnd = new Random();
        
        //"index" wird einer zufälligenzahl zugewiesen, und zwar von 0 bis die anzahl an Wörter im oberigem Array
        int index = rnd.Next(0, words.Length);
        
        //das zufällige Wort wird zur neuen Datenvariable "word" zugewiesen
        //"ToLower" sorgt dafür, dass alles kleingeschrieben ist
        string word = words[index].ToLower();
        
        //"GameLoop()" abrufen
        GameLoop(word);
    }

    static void GameLoop(string word)
    {
        int lives = 6;
        string hiddenword = "";

        //das versteckte Wort wird durch "_" erstetzt mit der "for-Schleife"
        for (int i = 0; i < word.Length; i++)
        {
            hiddenword += "_";
        }

        //es läuft solange bis "Game Over oder Gewonnen"
        while (true)
        {
            Console.Clear();
            
            Console.WriteLine($"Gesuchtes Wort: {hiddenword}");
            Console.Write($"Lives: ");

            //die  anzahl Leben wird mit "X" angezeigt
            for (int i = 0; i < lives; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("X");
                Console.ResetColor();
            }

            Console.WriteLine();
            Console.Write($"Buchstabe: ");
            char buchstabe = char.Parse(Console.ReadLine().ToLower());
            
            //ist der Buchstabe "true or false"
            bool foundchar = false;

            //der eingegebene Buchstaben wird durch das Wort durchgehen und nach dem gleichem Buchtsbaben
            //gesucht
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == buchstabe)
                {
                    foundchar = true;
                    break;
                }
            }
            
            //"hiddenword" ist mit anzahl an buchstaben im Wort mit "_" gespeichert
            //dies wird mit dem "temphiddenword" zwischengespeichert
            string temphiddenword = hiddenword;
            //dann wird der "hiddenword" Speicherplatzt geleert
            hiddenword = "";

            //wenn der Buchstabe gefunden wurde
            if (foundchar)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    
                    //wird der Buchstabe im leeren Speicherplatz "hiddenword" hinzugefügt
                    if (word[i] == buchstabe)
                    {
                        hiddenword += buchstabe;
                    }
                    
                    /*wenn der Buchtsabe schon gefunden wurde, wird geprüft, ob es ungleich mit "_" ist
                    das heisst, wenn der Buchstabe schon erraten und richtig war, und die
                    restlichen Buchstaben bleiben versteckt*/
                    else if (temphiddenword[i] != '_')
                    {
                        //es wird im "temphiddenword" auch hinzugefügt, und zwar den buchstaben
                      hiddenword += temphiddenword[i];  
                    }
                    
                    //das "hiddenword" wird immernoch versteckt mit "_"
                    else
                    {
                        hiddenword += '_';
                    }
                }

                //Gewonnen
                if (hiddenword == word)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"GEWONNEN");
                    Console.WriteLine($"Das Wort war {word}");
                    Console.ReadKey();
                    Console.ResetColor();
                    break;
                }
            }

            //Leben abzug bei falschen Buchstaben
            else
            {
                //wenn es bei dem Wort keines der eingegebene Buchstabe ist, dann...
                hiddenword += temphiddenword;

                
                //Leben abzug
                if (lives > 0)
                {
                    lives--;
                }
                
                //kein Leben = Game Over
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"GAME OVER");
                    Console.ReadKey();
                    Console.ResetColor();
                    break;
                }
            }
        }

    }
}