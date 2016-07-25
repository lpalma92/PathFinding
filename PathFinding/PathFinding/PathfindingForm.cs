using System;
using System.Windows.Forms;
using PathFinding.Classes;

namespace PathFinding
{
    public partial class PathfindingForm : Form
    {
        Grid _grid;
        Node selectedNode;

        public PathfindingForm()
        {
            InitializeComponent();
        }

        private void PathfindingLoad(object sender, EventArgs e)
        {
            _grid = new Grid(15, 15);
            _grid.Create();
        }

        private void ResolveClick(object sender, EventArgs e)
        {
            lblMessage.Text = "Resolve";
            Pathfinding.Instance.FindPath(_grid);
        }

        private void RestartClick(object sender, EventArgs e)
        {
            lblMessage.Text = "Restart";
            _grid.Reset();
            grid.Invalidate();
           
        }

        private void PaintGrid(object sender, PaintEventArgs e)
        {
            _grid.Graphic = e.Graphics;
            _grid.Draw();
        }

        private new void MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Node node = _grid.GetNodeFromPosition(e.Location);
                if (node != null)
                {
                    lblMessage.Text = "Location: " + e.Location.ToString() + ", Position " + node.GetXPos + ", " + node.GetYPos;
                    if (!node.GridBlock.Equals(_grid.StartNode.GridBlock) && !node.GridBlock.Equals(_grid.EndNode.GridBlock))
                        node.ChangeType();
                    else
                    {
                        selectedNode = node;
                        lblMessage.Text = "Main Node";
                    }
                }
                grid.Invalidate();
            }
        }

        private new void MouseUp(object sender, MouseEventArgs e)
        {
            selectedNode = null;
        }

        private new void MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if(selectedNode  == null)
                {               
                    Node node = _grid.GetNodeFromPosition(e.Location);
                    if (node != null)
                    {
                        lblMessage.Text = "Location: " + e.Location.ToString() + ", Position " + node.GetXPos + ", " + node.GetYPos;
                        if (!node.GridBlock.Equals(_grid.StartNode.GridBlock) && !node.GridBlock.Equals(_grid.EndNode.GridBlock))
                            node.ChangeType();
                        else
                        {
                            selectedNode = node;
                            lblMessage.Text = "Main Node";
                        }
                    }
                }
                else
                {
                    Node node = _grid.GetNodeFromPosition(e.Location);
                    if (node != null) 
                    {
                        lblMessage.Text = "Location: " + e.Location.ToString() + ", Position " + node.GetXPos + ", " + node.GetYPos;
                        if (!selectedNode.Equals(node))
                        {
                            GridBlock.BlockType _nodeType = node.GridBlock.Type;
                            _grid.SetNodeTypeInPosition(node.GetXPos, node.GetYPos, selectedNode.GridBlock.Type);
                            _grid.SetNodeTypeInPosition(selectedNode.GetXPos, selectedNode.GetYPos, _nodeType);
                            selectedNode = _grid.GetNodeFromPosition(node.GetXPos, node.GetYPos);
                        }
                            
                    }
                }
                grid.Invalidate();
            }
        }
    }
}
