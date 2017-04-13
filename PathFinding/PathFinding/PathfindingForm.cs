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
using System.Windows.Forms;
using PathFinding.Classes;

namespace PathFinding
{
    public partial class PathfindingForm : Form
    {
        Grid _grid;
        Node selectedNode;
        Pathfinding pathfinding;
        bool resolved = false;
        bool process = false;

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
            pathfinding = new Pathfinding(_grid);
            process = true;
            btnResolve.Enabled = false;
            backgroundWorker.RunWorkerAsync();
            //pathfinding.FindPath();
            //resolved = pathfinding.isResolved;
            grid.Invalidate();
        }

        private void RestartClick(object sender, EventArgs e)
        {
            lblMessage.Text = "Restart";
            resolved = false;
            btnResolve.Enabled = true;
            btnRestart.Enabled = false;
            _grid.Reset();
            grid.Invalidate();

        }

        private void PaintGrid(object sender, PaintEventArgs e)
        {
            _grid.Graphic = e.Graphics;
            _grid.Draw();
            if (resolved)
            {
                pathfinding.ShowResult();
            }
        }

        private new void MouseDown(object sender, MouseEventArgs e)
        {

            if (resolved || process)
            {
                return;
            }

            if (e.Button == MouseButtons.Left && !resolved)
            {
                Node node = _grid.GetNodeFromMousePosition(e.Location);
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

            if (resolved || process)
            {
                return;
            }

            if (e.Button == MouseButtons.Left)
            {
                if (selectedNode == null)
                {
                    Node node = _grid.GetNodeFromMousePosition(e.Location);
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
                    Node node = _grid.GetNodeFromMousePosition(e.Location);
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
            }
            grid.Invalidate();
        }

        private void BackgroundWorkerDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            pathfinding.FindPath();
        }

        private void BackgroundWorkerRunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            btnRestart.Enabled = true;
            process = false;
            resolved = pathfinding.isResolved;
            grid.Invalidate();
        }
    }
}
