using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisturbiaReinvented
{
    class SpringerProblem
    {
        private string[][] grid;
        private int sizeOfPlayground;
        private  int reiheSpringer = 0;
        private  int spalteSpringer = 0;

        public SpringerProblem(int sizeOfPlayground)
        {
            this.sizeOfPlayground = sizeOfPlayground;
            grid = new string[sizeOfPlayground][];
            for (int i = 0; i < sizeOfPlayground; i++)
            {
                grid[i] = new string[sizeOfPlayground];
            }
        }

        public void StarteSpringerProblem()
        {
            BelegeGridFuerAnfang();
            Startnachricht();
            int zahl = 2;           //Deckt den Anfangsfall ab (zwei mögliche Sprünge,
                                    //für SpringerSchritt() und HoleEingabe() wichtig)
            while (zahl != 0)
            {
                AusgabeGrid();
                string sprung = HoleEingabe(zahl);
                SpringerSchritt(sprung);
                zahl = MarkiereAlleMoeglichenSpruenge()-1;
            }
            bool fertig = FeldFertigAusgefuellt();
            if(!fertig)
            {
                AusgabeGrid();
                Console.WriteLine("Du hast einen Fehler gemacht! Willst du es nochmal probieren?");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Du hast es gelöst! Whoop Whoop!!");
            }
        }

        public void Startnachricht()
        {
            Console.WriteLine("Du musst das Springerproblem lösen! Das Ziel dabei ist, den Springer auf dem Spielfeld " +
                "so zu bewegen, dass er auf jedes Feld genau einmal auftritt. Mögliche Sprünge sind durch Zahlen markiert. " +
                "Um deinen Springer zu ziehen gebe einfach die gewünschte Zahl ein und bestätige. Viel Glück!");
        }
        public void SpringerSchritt(string sprung)       //Springer springt auf eingegebenes Feld und alte Position wird markiert
        {
            for(int i = 0; i < sizeOfPlayground; i++)
            {
                for(int j = 0; j < sizeOfPlayground; j++)
                {
                    if (grid[i][j] == sprung)
                    {
                        grid[i][j] = "K";
                        reiheSpringer = i;
                        spalteSpringer = j;
                    }
                    else if (grid[i][j] == "K")
                    {
                        grid[i][j] = "x";
                    }
                    else if (grid[i][j] != "x" && grid[i][j] != "K")
                    {
                        grid[i][j] = "#";
                    }
                }
            }
        }

        public string HoleEingabe(int anzahlMoeglicheSpruenge)
        {
            Console.Write("Nächster Sprung: ");
            string sprung = Console.ReadLine();
            int zahl = 0;
            EingabenKontrollieren:
            while(!int.TryParse(sprung, out zahl))
            {
                Console.Write("Du musst eine Ganzzahl eingeben: ");
                sprung = Console.ReadLine();
            }
            while (zahl < 1 || zahl > anzahlMoeglicheSpruenge)
            {
                if (anzahlMoeglicheSpruenge == 1)
                {
                    Console.Write($"Das ist kein gültiger Sprung. In dieser Runde ist nur der Sprung auf Feld 1 möglich. Wähle erneut: ");
                    sprung = Console.ReadLine();
                }
                else
                {
                    Console.Write($"Das ist kein gültiger Sprung. In dieser Runde sind nur Sprüngen auf die Felder 1 bis {anzahlMoeglicheSpruenge} möglich. Wähle erneut: ");
                    sprung = Console.ReadLine();
                }
                goto EingabenKontrollieren;
            }
            return sprung;
        }
        public int MarkiereAlleMoeglichenSpruenge()
        {
            int zahl = 1;
            zahl = MarkiereEinenMoeglichenSprung(-2, 1, zahl);
            zahl = MarkiereEinenMoeglichenSprung(-1, 2, zahl);
            zahl = MarkiereEinenMoeglichenSprung(1, 2, zahl); 
            zahl = MarkiereEinenMoeglichenSprung(2, 1, zahl);
            zahl = MarkiereEinenMoeglichenSprung(2, -1, zahl);
            zahl = MarkiereEinenMoeglichenSprung(1, -2, zahl);
            zahl = MarkiereEinenMoeglichenSprung(-1, -2, zahl);
            zahl = MarkiereEinenMoeglichenSprung(-2, -1, zahl);
            return zahl;
        }

        public int MarkiereEinenMoeglichenSprung(int changeReihe, int changeSpalte, int zahl)
        {
            if (SprungMoeglich(changeReihe, changeSpalte) && FeldNochNichtBesprungen(changeReihe, changeSpalte))
            {
                grid[reiheSpringer + changeReihe][spalteSpringer + changeSpalte] = Convert.ToString(zahl);
                return zahl + 1;
            }
            return zahl;
        }

        private bool FeldNochNichtBesprungen(int changeReihe, int changeSpalte)
        {
            if(grid[reiheSpringer + changeReihe][spalteSpringer + changeSpalte] == "#")
            {
                return true;
            }
            return false;
        }

        private bool SprungMoeglich(int changeReihe, int changeSpalte)
        {
               
            if( reiheSpringer + changeReihe >= 0 && reiheSpringer + changeReihe <= sizeOfPlayground - 1&&
                spalteSpringer + changeSpalte >= 0 && spalteSpringer + changeSpalte <= sizeOfPlayground -1 )
            {
                return true;
            }
            return false;
        }

        public bool FeldFertigAusgefuellt()
        {
            for(int i = 0; i < sizeOfPlayground; i++)
            {
                for(int j = 0; j < sizeOfPlayground; j++)
                {
                    if(grid[i][j] == "#")
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void AusgabeGrid()
        {
            for (int k = 0; k < 3; k++)
            {
                Console.WriteLine("");
            }
            for (int i = 0; i < sizeOfPlayground; i++)
            {
                for (int j = 0; j < sizeOfPlayground; j++)
                {
                    GebeGridInFarbeAus(i, j);
                }
                Console.WriteLine("");
            }
            for (int k = 0; k < 3; k++)
            {
                Console.WriteLine("");
            }
        }

        public void GebeGridInFarbeAus(int reihe, int spalte)
        {
            if(grid[reihe][spalte] == "K")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($" { grid[reihe][spalte] } ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (grid[reihe][spalte] == "x")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($" { grid[reihe][spalte] } ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (grid[reihe][spalte] == "#")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($" { grid[reihe][spalte] } ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write($" { grid[reihe][spalte] } ");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }

        public void BelegeGridFuerAnfang()
        {
            for (int i = 0; i < sizeOfPlayground; i++)
            {
                for (int j = 0; j < sizeOfPlayground; j++)
                {
                    grid[i][j] = "#";
                }
            }
            grid[0][0] = "K";
            grid[1][2] = "1";
            grid[2][1] = "2";
        }

    }
}
