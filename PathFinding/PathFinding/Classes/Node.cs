//The MIT License(MIT)

//Copyright(c) 2016 Luis Palma

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PathFinding.Classes
{
    class Node : IHeapItem<Node>
    {
        int gridX;
        int gridY;
        int heapIndex;
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

        public System.Drawing.Point GetPosition
        {
            get { return new System.Drawing.Point(GetXPos, GetYPos); }
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

        public int HeapIndex
        {
            get { return heapIndex; }
            set { heapIndex = value; }
        }

        public void ChangeType()
        {
            if (GridBlock.Type == GridBlock.BlockType.Obstacle || GridBlock.Type == GridBlock.BlockType.Way)
            {
                GridBlock.Type = GridBlock.Type == GridBlock.BlockType.Obstacle ? GridBlock.BlockType.Way : GridBlock.BlockType.Obstacle;
            }
        }

        //public int CompareTo(object compareNode)
        //{
        //    int i = fCost.CompareTo((compareNode as Node).fCost);
        //    if (i == 0)
        //        return i = fCost.CompareTo((compareNode as Node).hCost);
        //    return -i;
        //}

        public int CompareTo(Node other)
        {
            int i = fCost.CompareTo(other.fCost);
            if (i == 0)
                i = hCost.CompareTo(other.hCost);
            return -i;
        }
    }
}