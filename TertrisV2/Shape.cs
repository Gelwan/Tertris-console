using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TertrisV2
{
    public class Shape
    {
        public int positionX;
        public int positionY;
        public int[,] shape;
        public bool moveable = true;

        public Shape(int positionX, int positionY, int shapeType)
        {
            this.positionX = positionX;
            this.positionY = positionY;
            if (shapeType == 0)
            {
                shape = new int[,]
                {
                        { 1,1,1},
                        { 1,1,1},
                        { 1,1,1}
                };
            }
            else if (shapeType == 1)
            {
                shape = new int[,]
                {
                        { 1,1},
                        { 1,0},
                        { 1,0}
                };
            }
            else if (shapeType == 2)
            {
                shape = new int[,]
                {
                        { 1,1,1},
                        { 0,1,0},
                        { 0,1,0}
                };
            }
        }

        public void changePosition(char key)
        {
            if (key == 'a')
            {
                if (ColisionCheck(key)) positionX--;
            }
            else if (key == 'd')
            {
                if (ColisionCheck(key)) positionX++;
            }
            else if (key == 's')
            {
                if (ColisionCheck(key)) positionY++;
            }
            else if (key == 'c') Rotate();
            Board.clearBoardTab();
            shapeIntoBoard();
        }
        private bool ColisionCheck(char key)
        {
            if(moveable)
            {
                if (key == 'a')
                {
                    if (positionX - 1 < 0) return false;
                }
                else if (key == 'd')
                {
                    if (positionX + 1 + shape.GetLength(0) > Board.width) return false;
                }
                else if (key == 's')
                {
                    if (positionY + shape.GetLength(1) > Board.height - 1)
                    {
                        moveable = false;
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        public void shapeIntoBoard()
        {
            for(int i=0;i<shape.GetLength(1);i++)
            {
                for(int j=0;j<shape.GetLength(0);j++)
                {
                    if(shape[j,i]==1) Board.boardTab[positionX + j, positionY + i] = 1;
                }
            }
        }
        public void Rotate()
        {
            var newShape = new int[shape.GetLength(1),shape.GetLength(0)];
            for(int i=0;i<shape.GetLength(0);i++)
            {
                int h1 = 1;
                for(int j=0;j<shape.GetLength(1);j++)
                {
                    //newShape[i, j] = shape[j, shape.GetLength(0) - i - 1];
                    newShape[j, shape.GetLength(0) - i - 1] = shape[i, j];
                }
                h1++;
            }
            shape = newShape;
            changePosition(' ');
        }
        public void shapeIntoStaticTab()
        {
            for(int i=0;i< shape.GetLength(0);i++)
            {
                for(int j=0;j<shape.GetLength(1);j++)
                {
                    if (shape[i,j]==1)
                    {
                        Board.boardStaticTab[positionX+i, positionY+j] = 1;
                    }
                }
            }
        }
    }
}
