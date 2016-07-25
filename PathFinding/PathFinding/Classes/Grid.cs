using System;
using System.Collections.Generic;
using System.Drawing;

namespace PathFinding.Classes
{
    class Grid
    {
        int gridSizeX, gridSizeY;
        Graphics graphics;
        Node[,] gridNodes;
        Node start, end;
        List<Node> path;
 
        public Grid(int _gridSizeX, int _gridSizeY)
        {
            gridSizeX = _gridSizeX;
            gridSizeY = _gridSizeY;
        }

        public Grid(int _gridSizeX, int _gridSizeY, Graphics _graphics)
        {
            gridSizeX = _gridSizeX;
            gridSizeY = _gridSizeY;
            graphics = _graphics;
        }

        public Node StartNode
        {
            get { return start; }
            set { start = value; }
        }

        public Node EndNode
        {
            get { return end; }
            set { end = value; }
        }

        public int GridMaxSize
        {
            get { return gridSizeX * gridSizeY; }
        }

        public Graphics Graphic
        {
            set { graphics = value; }
        }

        public List<Node> Path
        {
            get { return path; }
            set { path = value; }
        }

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
                    else if (j == 14 && i == 14)
                        block.Type = GridBlock.BlockType.End;
                    gridNodes[i, j] = new Node(i, j, block);
                    posX += 20;
                }
                posX = 0;
                posY += 20;
            }
            this.start = gridNodes[0, 0];
            this.end = gridNodes[14, 14];
        }

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
                            case GridBlock.BlockType.Way: graphics.FillRectangle(Brushes.Cyan, gridNodes[i, j].GridBlock.Rect); break;
                            case GridBlock.BlockType.Obstacle: graphics.FillRectangle(Brushes.Blue, gridNodes[i, j].GridBlock.Rect); break;
                        }
                    } catch (ArgumentException e)
                    {
                        string error = e.Message;
                    }
                }
            }
        }

        public void Reset()
        {
            gridNodes = null;
            Create();
        }

        public Node GetNodeFromPosition(Point _position)
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

        public Node GetNodeFromPosition(int _x, int _y)
        {
            return gridNodes[_x, _y];
        }

        public void SetNodeTypeInPosition(int _x, int _y, GridBlock.BlockType _type)
        {
            gridNodes[_x, _y].GridBlock.Type = _type;
            if (_type == GridBlock.BlockType.Start)
                StartNode = gridNodes[_x, _y];
            else if (_type == GridBlock.BlockType.End)
                EndNode = gridNodes[_x, _y];
        }

        public List<Node> GetNeighbours(Node start)
        {
            List<Node> neighbours = new List<Node>();
            return neighbours;
        }

        //public class Path
        //{
        //    public Pen pencil;
        //    public Point start;
        //    public Point end;
        //    public const int distance = 10;

        //    public Path(Point _start, Point _end)
        //    {
        //        start = new Point(_start.X + distance, _start.Y + distance);
        //        end = new Point(_end.X + distance, _end.Y + distance);
        //        pencil = new Pen(Color.Black, 2);
        //    }
        //}
    }
}
