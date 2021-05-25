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

namespace PathFinding.Classes
{
    /// <summary>
    /// Pathfinding class 
    /// </summary>
    class Pathfinding
    {
        public bool isResolved = false;

        private Heap<Node> open;
        private List<Node> close;
        private Grid grid;
        private List<Node> path;

        /// <summary>
        /// Create the Pathfinding class for a given grid
        /// </summary>
        /// <param name="_grid">Grid to resolve using the pathfinding method</param>
        public Pathfinding(Grid _grid)
        {
            grid = _grid;
        }

        /// <summary>
        /// Execute the resolve of the pathfinding on the grid using the A* algorithm
        /// </summary>
        public void FindPath()
        {
            Node start = grid.StartNode;
            Node end = grid.EndNode;
            open = new Heap<Node>(grid.GridMaxSize);
            close = new List<Node>();
            open.Add(start);

            while (open.Count > 0)
            {
                Node currentNode = open.RemoveFirst();
                close.Add(currentNode);
                if (currentNode.GridBlock.Equals(end.GridBlock))
                {
                    isResolved = true;
                    break;
                }

                List<Node> neigbours = GetNeighbours(currentNode);
                foreach (Node p in neigbours)
                {
                    if (p.GridBlock.Type == GridBlock.BlockType.Obstacle || close.Contains(p))
                        continue;
                    int gCost = currentNode.gCost + GetDistance(currentNode, p);
                    if(gCost < currentNode.gCost || !open.Contains(p))
                    {
                        p.gCost = gCost;
                        p.hCost = GetDistance(p, end);
                        p.Parent = currentNode;
                        p.GridBlock.Type = p.GridBlock.Type != GridBlock.BlockType.End ? GridBlock.BlockType.OpenNode : GridBlock.BlockType.End;
                        if (!open.Contains(p))
                            open.Add(p);
                        else
                            open.UpdateItem(p);
                    }
                }
            }
            if (isResolved)
            {
                grid.Path = TracePath();
            }
        }

        /// <summary>
        /// Trace the path from the end to the start node
        /// </summary>
        /// <returns>List of the node that conform the trace</returns>
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

        /// <summary>
        /// Paint the path of the solution
        /// </summary>
        public void ShowResult()
        {
            grid.Resolve();
        }

        /// <summary>
        /// Calculate the distance between two nodes based on Manhattan distance
        /// </summary>
        /// <param name="current">The current node for calculate distance</param>
        /// <param name="goal">The goal node for calculate distance</param>
        /// <returns></returns>
        private int GetDistance(Node current, Node goal)
        {
            int distX = Math.Abs(goal.GetXPos - current.GetXPos);
            int distY = Math.Abs(goal.GetYPos - current.GetYPos);
            return 18 * (distX + distY);
        }

        /// <summary>
        /// Get the list of neigbours nodes of a open node
        /// </summary>
        /// <param name="node">Node to evalute</param>
        /// <returns>A list of Node</returns>
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
            if (node.GetYPos < grid.GridYArraySize) // Right Node
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
            if (node.GetXPos < grid.GridXArraySize) // Bottom Node
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
