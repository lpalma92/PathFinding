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
    /// Class with the definition for drawing the node in the form, 
    /// this class use the Sytem.Drawing to create a visual representation of the GridBlock
    /// </summary>
    class GridBlock
    {
        Rectangle rect;
        BlockType type;
        Point position;
        int width;
        int height;

        /// <summary>
        /// Enum with the list of BlockType
        /// </summary>
        public enum BlockType
        {
            Start,
            End,
            Obstacle,
            Way,
            OpenNode,
            PathNode,
        }

        /// <summary>
        /// Create a new GridBlock with a defined width and height
        /// </summary>
        /// <param name="_position">The position of the new GridBlock</param>
        public GridBlock(Point _position)
        {
            position = _position;
            width = 18;
            height = 18;
            rect = new Rectangle(position.X, position.Y, width, height);
        }

        /// <summary>
        /// Create a new GridBlock with a defined width and height
        /// </summary>
        /// <param name="_position">The position of the new GridBlock</param>
        /// <param name="_type">The BlockType of the new GridBlock</param>
        public GridBlock(Point _position, BlockType _type)
        {
            position = _position;
            type = _type;
            width = 18;
            height = 18;
            rect = new Rectangle(position.X, position.Y, width, height);
        }

        /// <summary>
        /// Create a new GridBlock
        /// </summary>
        /// <param name="_width">Width of the new GridBlock</param>
        /// <param name="_height">Height of the new GridBlock</param>
        /// <param name="_position">The position of the new GridBlock</param>
        /// <param name="_type">The BlockType of the new GridBlock</param>
        public GridBlock(int _width, int _height, Point _position, BlockType _type)
        {
            position = _position;
            type = _type;
            width = _width;
            height = _height;
            rect = new Rectangle(position.X, position.Y, width, height);
        }

        /// <summary>
        /// Get the BlockType of the GridBlock
        /// </summary>
        public BlockType Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// Get the position of the GridBlock
        /// </summary>
        public Point Position
        {
            get { return position; }
        }

        /// <summary>
        /// Get the Rectangle of the GridBlock
        /// </summary>
        public Rectangle Rect
        {
            get { return rect; }
        }


        /// <summary>
        /// Compare is the GridBlock object is equal to another GridBlock based on their position and type
        /// </summary>
        /// <param name="obj">A GridBlock object to compare with</param>
        /// <returns>True if the obj has the same position and BlockType</returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
