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

using System.Drawing;

namespace PathFinding.Classes
{
    /// <summary>
    /// Node class
    /// </summary>
    class Node : IHeapItem<Node>
    {
        int gridX;
        int gridY;
        int heapIndex;
        int _gCost = 0;
        int _hCost = 0;

        Node parent;
        GridBlock gridBlock;

        /// <summary>
        /// Create a new Node using de X and Y position of the grid with a given GridBlock definition
        /// </summary>
        /// <param name="_gridX"></param>
        /// <param name="_gridY"></param>
        /// <param name="_gridBlock">GridBlock definition of the node</param>
        public Node(int _gridX, int _gridY, GridBlock _gridBlock)
        {
            gridX = _gridX;
            gridY = _gridY;
            gridBlock = _gridBlock; 
        }

        /// <summary>
        /// Get the X position of the node on the grid
        /// </summary>
        public int GetXPos
        {
            get { return gridX; }
        }

        /// <summary>
        /// Get the Y position of the node on the grid
        /// </summary>
        public int GetYPos
        {
            get { return gridY; }
        }

        /// <summary>
        /// Get a Point object with the X and Y position of the node
        /// </summary>
        public Point GetPosition
        {
            get { return new Point(GetXPos, GetYPos); }
        }

        /// <summary>
        /// Get and Set the node parent of the node
        /// </summary>
        public Node Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        /// <summary>
        /// Get the GridBlock definition of the node
        /// </summary>
        public GridBlock GridBlock
        {
            get { return gridBlock; }
        }

        /// <summary>
        /// Get and set the g cost of the node
        /// </summary>
        public int gCost
        {
            get { return _gCost; }
            set { _gCost = value; }
        }

        /// <summary>
        /// Get  and set the h cost of the node 
        /// </summary>
        public int hCost
        {
            get { return _hCost; }
            set { _hCost = value; }
        }

        /// <summary>
        ///  Get the f cost of the node
        /// </summary>
        public int fCost
        {
            get { return _gCost + _hCost; }
        }

        /// <summary>
        /// Get and set the index on a heap of the node
        /// </summary>
        public int HeapIndex
        {
            get { return heapIndex; }
            set { heapIndex = value; }
        }

        /// <summary>
        /// Change the GridBlock type of the node
        /// </summary>
        public void ChangeType()
        {
            if (GridBlock.Type == GridBlock.BlockType.Obstacle || GridBlock.Type == GridBlock.BlockType.Way)
            {
                GridBlock.Type = GridBlock.Type == GridBlock.BlockType.Obstacle ? GridBlock.BlockType.Way : GridBlock.BlockType.Obstacle;
            }
        }


        /// <summary>
        /// Compare the node with other node based on their f cost or h cost
        /// </summary>
        /// <param name="other">Node to compare</param>
        /// <returns></returns>
        public int CompareTo(Node other)
        {
            int i = this.fCost.CompareTo(other.fCost);
            if (i == 0)
                i = this.hCost.CompareTo(other.hCost);
            return -i;
        }
    }
}