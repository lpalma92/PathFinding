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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFinding.Classes
{
    class Pathfinding
    {
        public bool isResolved = false;

        private Heap<Node> open;
        private HashSet<Node> close;
        private Grid grid;
        private List<Node> path;

        public Pathfinding(Grid _grid)
        {
            grid = _grid;
        }

        public void FindPath()
        {
            Node start = grid.StartNode;
            Node end = grid.EndNode;
            open = new Heap<Node>(grid.GridMaxSize);
            close = new HashSet<Node>();
            open.Add(start);

            while (open.Count > 0)
            {
                Node current = open.RemoveFirst();
                close.Add(current);
                if (current.GridBlock.Equals(end.GridBlock))
                {
                    isResolved = true;
                    break;
                }

                List<Node> neigbours = GetNeighbours(current);
                foreach (Node p in neigbours)
                {
                    if (p.GridBlock.Type == GridBlock.BlockType.Obstacle || close.Contains(p))
                        continue;
                    int gCost = current.gCost + GetDistance(current, p);
                    if(gCost < current.gCost || !open.Contains(p))
                    {
                        p.gCost = gCost;
                        p.hCost = GetDistance(p, end);
                        p.Parent = current;
                        p.GridBlock.Type = p.GridBlock.Type != GridBlock.BlockType.End ? GridBlock.BlockType.OpenNode : GridBlock.BlockType.End;
                        if (!open.Contains(p))
                            open.Add(p);
                    }
                }
            }
            if (isResolved)
            {
                grid.Path = TracePath();
            }
        }

        public List<Node> TracePath()
        {
            path = new List<Node>();
            Node current = grid.EndNode;
            while (!current.GridBlock.Equals(grid.StartNode.GridBlock))
            {
                path.Add(current);
                current.GridBlock.Type = current.GridBlock.Type != GridBlock.BlockType.End ? GridBlock.BlockType.PathNode : GridBlock.BlockType.End;
                current = current.Parent;
            }
            path.Add(current);
            return path;
        }

        public void ShowResult()
        {
            grid.Resolve();
        }

        private int GetDistance(Node a, Node b)
        {
            int distX = Math.Abs(a.GridBlock.Position.X - b.GridBlock.Position.X) / 20;
            int distY = Math.Abs(a.GridBlock.Position.Y - b.GridBlock.Position.Y) / 20;
            return  (distX + distY);
        }

        private List<Node> GetNeighbours(Node node)
        {
            List<Node> neighbours = new List<Node>();
            if (node.GetYPos > 0) // Left Node
            {
                if (grid.GetNodeFromPosition(node.GetXPos, node.GetYPos - 1) != node)
                {
                    Node aux = grid.GetNodeFromPosition(node.GetXPos, node.GetYPos - 1);
                    neighbours.Add(aux);
                }
            }
            if (node.GetYPos < 14) // Right Node
            {
                if (grid.GetNodeFromPosition(node.GetXPos, node.GetYPos + 1) != node)
                {
                    Node aux = grid.GetNodeFromPosition(node.GetXPos, node.GetYPos + 1);
                    neighbours.Add(aux);
                }
            }
            if (node.GetXPos > 0) // Top Node
            {
                if (grid.GetNodeFromPosition(node.GetXPos - 1, node.GetYPos) != node)
                {
                    Node aux = grid.GetNodeFromPosition(node.GetXPos - 1, node.GetYPos);
                    neighbours.Add(aux);
                }
            }
            if (node.GetXPos < 14) // Bottom Node
            {
                if (grid.GetNodeFromPosition(node.GetXPos + 1, node.GetYPos) != node)
                {
                    Node aux = grid.GetNodeFromPosition(node.GetXPos + 1, node.GetYPos);
                    neighbours.Add(aux);
                }
            }
            return neighbours;
        }
    }
}
