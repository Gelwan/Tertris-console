using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TertrisV2
{
    static class Board
    {
        public static int width = Rules.boardWidth;
        public static int height = Rules.boardHeight;
        public static int[,] boardTab = new int[width,height];
        public static int[,] boardStaticTab = new int[width,height];

        static Board()
        {
            for(int i = 0; i < width; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    boardStaticTab[i, j] = 0;
                }
            }
        }


        public static void clearBoardTab()
        {
            for(int i = 0; i < boardTab.GetLength(1); i++)
            {
                for(int j = 0; j < boardTab.GetLength(0); j++)
                {
                    boardTab[j,i] = 0;
                }
            }
        }
        public static void printBoardTab()
        {
            Console.Clear();
            for (int i = -1; i <= boardTab.GetLength(1); i++)
            {
                for (int j = -1; j <= boardTab.GetLength(0); j++)
                {
                    if (i == -1 || j == -1 || i == boardTab.GetLength(1) || j == boardTab.GetLength(0)) Console.Write('#');
                    else if (boardTab[j, i] == 0) Console.Write(' ');
                    else if (boardTab[j, i] == 1) Console.Write(Rules.shapeChar);
                    Console.Write(' ');
                }
                Console.Write("\n");
            }
        }
        
    }
}
