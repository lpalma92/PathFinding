using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFinding.Classes
{
    class Pathfinding
    {

        private static Pathfinding _instance;
        private Heap<Node> open;
        private HashSet<Node> close;
        private Grid grid;
        public static Pathfinding Instance
        {
            get {
                    if (_instance == null)
                        return _instance = new Pathfinding();
                    return _instance;
                }
        }

        public Pathfinding()
        {

        }

        public void FindPath(Grid _grid)
        {
            Node start = _grid.StartNode;
            Node end = _grid.EndNode;
            open = new Heap<Node>(_grid.GridMaxSize);
            close = new HashSet<Node>();
            open.Add(start);
            while (open.Count > 0)
            {
                Node current = open.GetFirst();
                if (current.GridBlock.Equals(end.GridBlock))
                    return;
                foreach(Node p in _grid.GetNeighbours(current))
                {
                    if (p.GridBlock.Type != GridBlock.BlockType.Obstacle || close.Contains(p))
                        continue;                                      
                    int gCost = current.gCost + GetDistance(current, p);
                    if(gCost < current.gCost || !open.Contains(p))
                    {
                        p.gCost = gCost;
                        p.hCost = GetDistance(current, p);
                        p.Parent = current;
                        if (!open.Contains(p))
                            open.Add(p);
                    }
                }
            }
        }

        private void TracePath(Node start, Node end)
        {
            List<Node> path = new List<Node>();
            Node current = end;
            while (current.GridBlock.Equals(start.GridBlock))
            {
                path.Add(current);
                current = current.Parent;
            }
            path.Reverse();
            grid.Path = path;
        }

        private int GetDistance(Node a, Node b)
        {
            int distX = Math.Abs(a.GridBlock.Position.X - b.GridBlock.Position.X);
            int distY = Math.Abs(a.GridBlock.Position.Y - b.GridBlock.Position.Y);
            return distX + distY;
        }
    }
}
