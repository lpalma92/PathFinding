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
using System.Linq;
using System.Text;

using System.Drawing;
using System.Threading.Tasks;

namespace PathFinding.Classes
{
    class GridBlock
    {
        Rectangle rect;
        BlockType type;
        Point position;
        int width;
        int height;

        public enum BlockType
        {
            Start,
            End,
            Obstacle,
            Way,
            OpenNode,
            PathNode,
        }

        public GridBlock(Point _position)
        {
            position = _position;
            width = 18;
            height = 18;
            rect = new Rectangle(position.X, position.Y, width, height);
        }

        public GridBlock(Point _position,BlockType _type)
        {
            position = _position;
            type = _type;
            width = 18;
            height = 18;
            rect = new Rectangle(position.X, position.Y, width, height);
        }

        public GridBlock(int _width, int _height, Point _position, BlockType _type)
        {
            position = _position;
            type = _type;
            width = _width;
            height = _height;
            rect = new Rectangle(position.X, position.Y, width, height);
        }

        public BlockType Type
        {
            get { return type; }
            set { type = value; }
        }

        public Point Position
        {
            get { return position; }
        }

        public Rectangle Rect
        {
            get { return rect; }
        }

        public static bool operator ==(GridBlock _block1, GridBlock _block2)
        {
            return (_block1.position == _block2.position && _block1.Type == _block2.Type);
        }

        public static bool operator !=(GridBlock _block1, GridBlock _block2)
        {
            return !(_block1 == _block2);
        }

        public override bool Equals(object obj)
        {
            bool result = false;
            if (obj is GridBlock)
            {
                GridBlock _block = obj as GridBlock;
                result = (this.position == _block.position && this.Type == _block.Type);
            }
            return result;           
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
