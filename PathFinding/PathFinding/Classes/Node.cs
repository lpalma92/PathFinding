using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PathFinding.Classes
{
    class Node : IComparable
    {
        int gridX;
        int gridY;
        int _gCost = 0;
        int _hCost = 0;

        Node parent;
        GridBlock gridBlock;

        public Node(int _gridX, int _gridY, GridBlock _gridBlock)
        {
            gridX = _gridX;
            gridY = _gridY;
            gridBlock = _gridBlock;
        }

        public int GetXPos
        {
            get { return gridX; }
        }

        public int GetYPos
        {
            get { return gridY; }
        }

        public Node Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        public GridBlock GridBlock
        {
            get { return gridBlock; }
        }

        public int gCost
        {
            get { return _gCost; }
            set { _gCost = value; }
        }

        public int hCost
        {
            get { return _hCost; }
            set { _hCost = value; }
        }

        public int fCost
        {
            get { return _gCost + _hCost; }
        }

        public void ChangeType()
        {
            if (GridBlock.Type == GridBlock.BlockType.Obstacle || GridBlock.Type == GridBlock.BlockType.Way)
            {
                GridBlock.Type = GridBlock.Type == GridBlock.BlockType.Obstacle ? GridBlock.BlockType.Way : GridBlock.BlockType.Obstacle;
            }         
        }

        public int CompareTo(object compareNode)
        {
            int i = fCost.CompareTo((compareNode as Node).fCost);
            return i;
        }
    }
}
