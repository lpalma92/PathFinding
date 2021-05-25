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
using System.Drawing;

namespace PathFinding.Classes
{
    /// <summary>
    /// Grid class
    /// </summary>
    class Grid
    {
        int gridSizeX, gridSizeY;
        Graphics graphics;
        Node[,] gridNodes;
        Node start, end;
        List<Node> path;

        /// <summary>
        /// Create a new Grid object with a X and Y size
        /// </summary>
        /// <param name="_gridSizeX">X max size of the grid</param>
        /// <param name="_gridSizeY">Y max size of the grid</param>
        public Grid(int _gridSizeX, int _gridSizeY)
        {
            gridSizeX = _gridSizeX;
            gridSizeY = _gridSizeY;
        }

        /// <summary>
        /// Create a new Grid object with a X and Y size and with a Graphics control
        /// </summary>
        /// <param name="_gridSizeX">X max size of the grid</param>
        /// <param name="_gridSizeY">Y max size of the grid</param>
        /// <param name="_graphics">Graphics control for the drawing of the grid</param>
        public Grid(int _gridSizeX, int _gridSizeY, Graphics _graphics)
        {
            gridSizeX = _gridSizeX;
            gridSizeY = _gridSizeY;
            graphics = _graphics;
        }

        /// <summary>
        /// Get and Set the Start Node of the grid
        /// </summary>
        public Node StartNode
        {
            get { return start; }
            set { start = value; }
        }

        /// <summary>
        /// Get and Set the End Node of the grid
        /// </summary>
        public Node EndNode
        {
            get { return end; }
            set { end = value; }
        }

        /// <summary>
        /// Get the grid X array size
        /// </summary>
        public int GridXArraySize
        {
            get { return gridSizeX - 1; }
        }

        /// <summary>
        /// Get the grid Y array size
        /// </summary>
        public int GridYArraySize
        {
            get { return gridSizeY - 1; }
        }

        /// <summary>
        /// Get the size of the grid 
        /// </summary>
        public int GridMaxSize
        {
            get { return gridSizeX * gridSizeY; }
        }

        /// <summary>
        /// Set the Graphics control for the drawing of the grid
        /// </summary>
        public Graphics Graphic
        {
            set { graphics = value; }
        }

        /// <summary>
        /// Get the list of nodes that genereted the resolve path
        /// </summary>
        public List<Node> Path
        {
            get { return path; }
            set { path = value; }
        }

        /// <summary>
        /// Create the grid structures of Node using de gridSizeX and gridSizeY propoerties given on the constructor
        /// </summary>
        public void Create()
        {
            int posX = 0;
            int posY = 0;
            gridNodes = new Node[gridSizeX, gridSizeY];
            for (int i = 0; i < gridSizeX; i++)
            {
                for (int j = 0; j < gridSizeY; j++)
                {
                    GridBlock block = new GridBlock(new Point(posX, posY), GridBlock.BlockType.Way);
                    if (i == 0 && j == 0)
                        block.Type = GridBlock.BlockType.Start;
                    else if (i == (gridSizeX - 1) && j == (gridSizeY - 1))
                        block.Type = GridBlock.BlockType.End;
                    gridNodes[i, j] = new Node(i, j, block);
                    posX += 20;
                }
                posX = 0;
                posY += 20;
            }
            this.start = gridNodes[0, 0];
            this.end = gridNodes[gridSizeX -1 , gridSizeY - 1];
        }

        /// <summary>
        /// Draw every Node of the grid with they given BlockType
        /// </summary>
        public void Draw()
        {
            for (int i = 0; i < gridSizeX; i++)
            {
                for (int j = 0; j < gridSizeY; j++)
                {
                    try
                    {
                        switch (gridNodes[i, j].GridBlock.Type)
                        {
                            case GridBlock.BlockType.Start: graphics.FillRectangle(Brushes.Green, gridNodes[i, j].GridBlock.Rect); break;
                            case GridBlock.BlockType.End: graphics.FillRectangle(Brushes.Red, gridNodes[i, j].GridBlock.Rect); break;
                            case GridBlock.BlockType.Way: graphics.FillRectangle(Brushes.White, gridNodes[i, j].GridBlock.Rect); break;
                            case GridBlock.BlockType.Obstacle: graphics.FillRectangle(Brushes.Gray, gridNodes[i, j].GridBlock.Rect); break;
                            case GridBlock.BlockType.OpenNode: graphics.FillRectangle(Brushes.LightBlue, gridNodes[i, j].GridBlock.Rect); break;
                            case GridBlock.BlockType.PathNode: graphics.FillRectangle(Brushes.LightGreen, gridNodes[i, j].GridBlock.Rect); break;
                        }
                    }
                    catch (ArgumentException e)
                    {
                        string error = e.Message;
                    }
                }
            }
        }

        /// <summary>
        /// Reset the grid to the default values
        /// </summary>
        public void Reset()
        {
            gridNodes = null;
            Create();
        }

        /// <summary>
        /// Draws the path of the resolved grid 
        /// </summary>
        public void Resolve()
        {
            if (Path != null)
            {
                List<GridPath> pathToDraw = new List<GridPath>();
                for (int i = Path.Count - 1; i > -1; i--)
                {
                    if (i > 0)
                    {
                        int aux = i - 1;
                        pathToDraw.Add(new GridPath(Path[i].GridBlock.Position, Path[aux].GridBlock.Position));
                    }
                    else
                    {
                        pathToDraw.Add(new GridPath(Path[i].GridBlock.Position, Path[i].GridBlock.Position));
                    }
                }

                foreach (GridPath item in pathToDraw)
                {
                    graphics.DrawLine(item.pencil, item.start, item.end);
                }
            }
        }

        /// <summary>
        /// Get a Node from a Point object
        /// </summary>
        /// <param name="_position">Point of the cursor</param>
        /// <returns>A Node object in the given position</returns>
        public Node GetNodeFromMousePosition(Point _position)
        {
            for (int _x = 0; _x < gridSizeX; _x++)
            {
                for (int _y = 0; _y < gridSizeY; _y++)
                {
                    if (gridNodes[_x, _y].GridBlock.Rect.IntersectsWith(new Rectangle(_position, new Size(1, 1))))
                    {
                        return gridNodes[_x, _y];
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Get a Node from a X and Y position
        /// </summary>
        /// <param name="_x">X position of the nod</param>
        /// <param name="_y">Y position of the node</param>
        /// <returns>A Node object in the given position</returns>
        public Node GetNodeFromPosition(int _x, int _y)
        {
            return gridNodes[_x, _y];
        }

        /// <summary>
        /// Change the GridBlock type of a Node in x and y position
        /// </summary>
        /// <param name="_x">X position of the node to change</param>
        /// <param name="_y">Y position of the node to change</param>
        /// <param name="_type">The new BlockType for the node in the given position</param>
        public void SetNodeTypeInPosition(int _x, int _y, GridBlock.BlockType _type)
        {
            gridNodes[_x, _y].GridBlock.Type = _type;
            if (_type == GridBlock.BlockType.Start)
                StartNode = gridNodes[_x, _y];
            else if (_type == GridBlock.BlockType.End)
                EndNode = gridNodes[_x, _y];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        public bool isValidNodeMove(Node parent)
        {
            return true;
        }
    }
}
