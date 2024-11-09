using System;

namespace BitCraft.UserControls
{
    class Cells
    {

        int xPos;
        int yPos;
        bool isAlive;
        int neighbors;

        internal int Number { get; private set;}

        public Cells()
        {
            isAlive = false;
        }

        public Cells(int x, int y, int number)
        {
            xPos = x;
            yPos = y;
            isAlive = false;
            Number = number;
        }

        public override int GetHashCode()
        {
            return Number;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || !(obj is Cells))
                return false;
            else
                return Number == ((Cells)obj).Number;
        }

        public void setNeighbor(int x)
        {
            neighbors += x;
        }

        public bool getAlive()
        {
            return isAlive;
        }
        public void toggleAlive()
        {
            isAlive = !isAlive;
        }
        public void setAliveFalse()
        {
            isAlive = false;
        }
        public void setAliveTrue()
        {
            isAlive = true;
        }
        public int getNeighbors()
        {
            return neighbors;
        }
    }
}
