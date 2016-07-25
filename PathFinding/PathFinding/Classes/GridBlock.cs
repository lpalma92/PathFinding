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
            Way
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
            width = 20;
            height = 20;
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
    }
}
