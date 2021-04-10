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
        int reiheSpringer = 0;
        int spalteSpringer = 0;

        public SpringerProblem(int sizeOfPlayground)
        {
            this.sizeOfPlayground = sizeOfPlayground;
            grid = new string[sizeOfPlayground][];
            for (int i = 0; i < sizeOfPlayground; i++)
            {
                grid[i] = new string[sizeOfPlayground];
            }
        }
        public void SpringerSchritt()       //Springer springt auf eingegebenes Feld und alte Position wird markiert
        {
            string sprung = Console.ReadLine();
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
                    else 
                    {
                        grid[i][j] = "x";
                    }
                }
            }
        }

        /*public void MarkiereMoeglicheSpruenge()
        {
            for (int i = 1; i < 3; i++)
            {
                for (int j = 1; j < 3; j++)
                {
                    if (i != j && SprungMoeglich(i;j))
                    {
                        
                    }

                }
            }
        }*/

        /*private static bool SprungMoeglich(int i; int j)
        {
            
        }*/

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
                    Console.Write($" { grid[i][j] } ");
                }
                Console.WriteLine("");
            }
            for (int k = 0; k < 3; k++)
            {
                Console.WriteLine("");
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
